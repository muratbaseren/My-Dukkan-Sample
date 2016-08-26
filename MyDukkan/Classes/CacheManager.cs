using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDukkan.Classes
{
    public class CacheManager<T>
    {
        public string pkey { get; private set; }


        public CacheManager()
        {
            pkey = this.GetType().GenericTypeArguments[0].Name;
        }

        public CacheManager(string cache_key)
        {
            pkey = cache_key;
        }


        public bool HasCache()
        {
            return HasCache(pkey);
        }

        public bool HasCache(string key)
        {
            if (HttpContext.Current.Cache[key] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<T> Get()
        {
            return Get(pkey);
        }

        public List<T> Get(string key)
        {
            if (HttpContext.Current.Cache[key] != null)
            {
                return HttpContext.Current.Cache[key] as List<T>;
            }

            return null;
        }


        public void Set(List<T> list)
        {
            Set(pkey, list);
        }

        public void Set(string key, List<T> list)
        {
            HttpContext.Current.Cache.Insert(key, list);
        }


        public T GetById(Func<T, bool> expression)
        {
            return GetById(pkey, expression);
        }

        public T GetById(string key, Func<T, bool> expression)
        {
            T result = default(T);

            if (HttpContext.Current.Cache[key] != null)
            {
                List<T> list = HttpContext.Current.Cache[key] as List<T>;

                result = list.FirstOrDefault(expression);
            }

            return result;
        }
    }
}