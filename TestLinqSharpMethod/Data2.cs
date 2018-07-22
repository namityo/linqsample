using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinqSharp
{
    class Data2
    {
        public int GroupId { get; set; }

        public string Address { get; set; }

        public List<string> Clients { get; set; }

        public Data2(int groupId, string address, List<string> clients)
        {
            GroupId = groupId;
            Address = address;
            Clients = clients;
        }
    }
}
