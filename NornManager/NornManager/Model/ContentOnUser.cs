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
        public string detail;

        public override string ToString()
        {
            return title + " (" + detail + ")";
        }
    }
}
