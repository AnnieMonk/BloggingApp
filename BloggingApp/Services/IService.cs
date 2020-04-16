using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.Services
{
    public interface IService<T, TSearch>
    {
      
        T GetOne(TSearch search);

        T GetBySlug(string slug);
    }
}
