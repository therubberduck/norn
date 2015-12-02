using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NornManager.Model
{
    public class Content
    {
        public string id;
        public string typeid;
        public string title;
        public string content;
        public string visible;

        public bool Visible()
        {
            return visible.Equals("1");
        }

        public override string ToString()
        {
            return title;
        }
    }
}
