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
        public IEnumerable<Cuisine> GetCuisines()
        {
            return db.Cuisines.AsEnumerable();
        }

        //public List<Cuisine> GetCuisines(Activity activity)
        //{
        //    return db.Cuisines
                
        //        .Where(c => c.Activities.Contains(activity)).ToList();
        //    //.Where(c => c.Activities.Select(a => a.Id).Contains(activity.Id)).ToList(); 
        //    //.Where(c => c.)
        //}

        public List<Cuisine> GetCuisines(Activity activity)
        {
            return db.Cuisines

               //.Where(c => c.Activities.Contains(activity)).ToList();
            .Where(c => c.Activities.Select(a => a.Id).AsEnumerable().Contains(activity.Id)).ToList(); 
            //.Where(c => c.)
        }


    }
}