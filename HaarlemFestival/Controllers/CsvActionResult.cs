using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class CsvActionResult<T> : FileResult
    {
        private string[] columNames;
        private char separator;
        private IList<T> list;
       
        public CsvActionResult(IList<T> list,string fileName, string[] columNames, char separator=';') : base("text/csv")
        {
            this.list = list;
            this.separator = separator;
            this.columNames = columNames;

            FileDownloadName = fileName;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            Stream outputStream = response.OutputStream;
            using(MemoryStream memoryStream = new MemoryStream())
            {
                WriteList(memoryStream);
                outputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }

        private void WriteList(MemoryStream memoryStream)
        {
            StreamWriter streamwriter = new StreamWriter(memoryStream, Encoding.Default);
            //header
            foreach(string name in columNames)
            {
                WriteValue(streamwriter, name);
            }

            streamwriter.WriteLine();
            //line
            foreach (T line in list)
            {
                foreach(MemberInfo member in typeof(T).GetProperties())
                {
                    WriteValue(streamwriter, line.GetType().GetProperty(member.Name).GetValue(line).ToString());
                }
                streamwriter.WriteLine();
            }

            streamwriter.Flush();
        }

        private void WriteValue(StreamWriter streamwriter, string value)
        {
            streamwriter.Write("\"");
            streamwriter.Write(value);
            streamwriter.Write("\""+ separator);
        }
    }
}