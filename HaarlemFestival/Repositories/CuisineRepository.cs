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

        public List<Cuisine> GetCuisines(Activity activity)
        {
            return db.Cuisines
                .Include(C => C.Activities).AsEnumerable()
                .Where(c => c.Activities.Contains(activity)).ToList();
        }
    }
}