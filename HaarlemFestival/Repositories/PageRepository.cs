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
        public Page GetPage(string name , Language language)
        {
            return db.Pages.Where(p => p.Name.Equals(name))
                .Select(p => new {
                    p,
                    d = p.PageDescriptions.Where(pd => pd.Language == language)
                        .OrderBy(pd => pd.Section)
                } ).AsEnumerable()
                .Select(x => x.p).First();
        }

        public void UpdatePage(Page page)
        {
            db.Entry(page).State = EntityState.Modified;
            foreach(PageDescription dp in page.PageDescriptions)
            {
                db.Entry(dp).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}