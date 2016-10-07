using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Models
{
    public class Unit
    {
        public string UserLocation { get; set; }
        public string UserName { get; set; }

        public Unit() { }
        public Unit(string unitCode, string unitName)
        {
            UserLocation = unitCode;
            UserName = unitName;
        }
    }
}
