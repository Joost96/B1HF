using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HaarlemFestival.Model;

namespace HaarlemFestival.Repositories
{
    public class PageRepository : IPageRepository
    {
        private DBHF db;
        public PageRepository(DBHF db)
        {
            this.db = db;
        }
        public Page GetPage(string name)
        {
            return db.Pages.Include(p => p.PageDescriptions).FirstOrDefault(p => p.Name.Equals(name));
        }

        public void UpdatePage(Page page)
        {
            throw new NotImplementedException();
        }
    }
}