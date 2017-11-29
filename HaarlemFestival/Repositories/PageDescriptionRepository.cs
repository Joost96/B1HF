using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HaarlemFestival.Model;

namespace HaarlemFestival.Repositories
{
    public class PageDescriptionRepository : IPageDescriptionRepository
    {
        private DBHF db;

        public PageDescriptionRepository(DBHF db)
        {
            this.db = db;
        }

        public PageDescription GetImg(string section, string title)
        {
            return db.PageDescriptions.Single(a => a.Section.Equals(section) && a.Title.Equals(title)); 
        } 
    }
}