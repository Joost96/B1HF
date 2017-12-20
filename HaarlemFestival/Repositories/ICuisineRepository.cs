using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    public interface ICuisineRepository
    {
        IEnumerable<Cuisine> GetCuisines();
        List<Cuisine> GetCuisines(Activity activity);
    }
}