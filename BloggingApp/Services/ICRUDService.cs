using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.Services
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch>
    {
        T Insert(TInsert request);

        T Update(string slug, TUpdate request);
        bool Delete(string slug);
    }
}
