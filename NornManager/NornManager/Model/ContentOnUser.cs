using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NornManager.Model
{
    public class ContentOnUser
    {
        public string id;
        public string contentid;
        public string title;
        public string number;
        public string detail;

        public override string ToString()
        {
            string toString = title;
            if (!string.IsNullOrEmpty(number) && number != "1")
            {
                toString += "(" + number + ")";
            }
            if (!string.IsNullOrEmpty(detail))
            {
                toString += " (" + detail + ")";
            }
            return toString;
        }
    }
}
