using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NornManager.Model
{
    public class User
    {
        public string id;
        public string userName;

        public override string ToString()
        {
            return userName;
        }
    }
}
