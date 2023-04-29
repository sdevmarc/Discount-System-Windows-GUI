using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuarezDiscountSystem
{
    internal class DiscountRate
    {
        private double serviceDiscountPremium = 0.2;
        private double serviceDiscountGold = 0.15;
        private double serviceDiscountSilver = 0.1;
        private double productDiscountPremium = 0.1;
        private double productDiscountGold = 0.1;
        private double productDiscountSilver = 0.1;

        public double ServiceDiscountRate(string type)
        {
            if (type == "Premium")
            {
                return serviceDiscountPremium;
            }
            else if (type == "Gold")
            {
                return serviceDiscountGold;
            }
            else if(type == "Null")
            {
                return 0;
            }
            else
            {
                return serviceDiscountSilver;
            }
        }
        public double ProductDiscountRate(string type)
        {
            if (type == "Premium")
            {
                return productDiscountPremium;
            }
            else if (type == "Gold")
            {
                return productDiscountGold;
            }
            else if (type == "Null")
            {
                return 0;
            }
            else
            {
                return productDiscountSilver;
            }
        }
    }
}
