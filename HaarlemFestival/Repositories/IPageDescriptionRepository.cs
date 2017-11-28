using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaarlemFestival.Model;


namespace HaarlemFestival.Repositories
{
    interface IPageDescriptionRepository
    {
        PageDescription GetImg(string section, string title);
    }
}
