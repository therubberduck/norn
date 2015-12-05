using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NornManager.Model
{
    public class ContentType
    {
        public string id;
        public string title;

        public override string ToString()
        {
            return title;
        }
    }
}
