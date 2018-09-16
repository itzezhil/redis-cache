using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMVC.Repository
{
    public interface ICache<T>
    {
        T Get(string key);
        void Set(string key, T objecttoCache);
    }
}
