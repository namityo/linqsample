using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinqSharp
{
    class Data1
    {
        public string Group { get; set; }

        public int GroupId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Data1(string group, int groupId, string name, int age)
        {
            Group = group;
            GroupId = groupId;
            Name = name;
            Age = age;
        }
    }
}
