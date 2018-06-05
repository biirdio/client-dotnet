using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biird_Client
{
    public class BiirdClient
    {

    }

    class Entity
    {

    }
    public static class Extentions
    {
        public static void Merge<TKey,TValue>(this IDictionary<TKey,TValue> dictionary)
        {
            var mutableCopy = new Dictionary<TKey,TValue>(dictionary);

        }
    }
}
