using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuarezDiscountSystem
{
    internal class Visit : Customer
    {
        private Customer customer;
        private DateTime date = DateTime.Now;
        private double serviceExpense;
        private double productExpense;

        public Visit(string name, DateTime date)
            : base(name)
        {
            customer = new Customer(name);
            this.date = date;
        }
        public string getName { get { return Name; } set { Name = value; } }
        public double ServiceExpense { get { return serviceExpense; } set { serviceExpense = value; } }
        public double ProductExpense { get { return productExpense; } set { productExpense = value; } }
        public double TotalExpense{ get { return (ProductExpense - (ProductExpense * ProductDiscountRate(PMemberType))) + (ServiceExpense - (ServiceExpense * ServiceDiscountRate(SMemberType))); } }
        public new string toString()
        {
            return "Your total expense is: " + TotalExpense + " - " + date;
        }
    }
}
