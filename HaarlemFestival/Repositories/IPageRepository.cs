using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    public interface IPageRepository
    {
        Page GetPage(string name, Language language);
        void UpdatePage(Page page);
    }
}