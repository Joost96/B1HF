using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HaarlemFestival.Model;

namespace HaarlemFestival.Repositories
{
    public class CuisineRepository : ICuisineRepository
    {
        private DBHF db;
        public CuisineRepository(DBHF db)
        {
            this.db = db;
        }
        public List<Cuisine> GetCuisines()
        {
            return db.Cuisines.ToList();
                
                //Where(c => c.Id.Equals(id))
                //.Select(c => new {
                //    c = c..Where
                //    //d = p.PageDescriptions.Where(pd => pd.Language == language)
                //    //    .OrderBy(pd => pd.Section)
                //} ).AsEnumerable()
                //.Select(x => x.p).First();
        }
    }
}