using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuarezDiscountSystem
{
    internal class Customer : DiscountRate
    {
        private string name;
        private bool member = false;
        private string PmemberType;
        private string SmemberType;
        LinkedList<string> nameList = new LinkedList<string>();

        public Customer(string name)
        {
            this.name = name;
            nameList.AddFirst("admin");
        }
        public string Name { get { return name; } set { name = value; } }
        public bool isMember { get { return member; } set { member = value; } }
        public string PMemberType { get { return PmemberType; } set { PmemberType = value; } }
        public string SMemberType { get { return SmemberType; } set { SmemberType = value; } }
        public string toString()
        {
            return name;
        }
        public string listAdd(string a)
        {
            nameList.AddFirst(a);
            member = true;
            return nameList.ToString();
        }

        public bool checkList(string a)
        {
            if (nameList.Contains(a) == true)
            {
                return member = true;
            }
            else
            {
                return member = false;
            }
        }

    }
}
