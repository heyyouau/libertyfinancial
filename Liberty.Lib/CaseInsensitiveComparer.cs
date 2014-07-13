using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Lib
{
    class CaseInsensitiveComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLower().Contains(y.ToLower());
        }

        public int GetHashCode(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
