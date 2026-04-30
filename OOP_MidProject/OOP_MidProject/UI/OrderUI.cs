using OOP_MidProject.BL;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.UI
{
    internal class OrderUI
    {       // ord
        public static void viewOrder(List<Order> Olist)
        {
            Console.WriteLine("_________________________________________________________________________________________________");
            Console.WriteLine($"{"Customer Id",-15}{"Order Id",-15}{"Order type",-20}{"Order Condition",-20}{"Order Cost",-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
            foreach (Order o in Olist)
                Console.WriteLine($"{o.getCustomerId(),-15}{o.getId(),-15}{o.getType(),-20}{o.getCondition(),-20}{o.getCost(),-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
        }
        public static void viewOrderByStatus(List<Order> Olist, string status)
        {
            {
                Console.WriteLine("_________________________________________________________________________________________________");
                Console.WriteLine($"{"Customer Id",-15}{"Order Id",-15}{"Order type",-20}{"Order Condition",-20}{"Order Cost",-20}{"Order Status",-20}");
                Console.WriteLine("_________________________________________________________________________________________________");
                foreach (Order o in Olist)
                    if(o.getStatus() == status)
                    Console.WriteLine($"{o.getCustomerId(),-15}{o.getId(),-15}{o.getType(),-20}{o.getCondition(),-20}{o.getCost(),-20}{o.getStatus(),-20}");
                Console.WriteLine("_________________________________________________________________________________________________");
            }
        }

        public static Order addOrder()
        {
            string orderType, orderTime, orderCondition, cusId;
            int orderCost;

            Console.Write("Enter Customer id             : ");
            cusId = Console.ReadLine();
            Console.Write("Enter order type              : ");
            orderType = Console.ReadLine();
            Console.Write("Enter order's Condition       : ");
            orderCondition = Console.ReadLine();
            Console.Write("Enter order costs             : ");
            orderCost = int.Parse(Console.ReadLine());
            Order o = new Order(orderType, orderCondition, orderCost,cusId);
            bool validity = o.setType(orderType) && o.setstatus(orderCondition) && o.setCost(orderCost) && o.setCost(orderCost);
            if (validity)
            {
                Console.WriteLine("Order Added Successfully");
                return o;
            }
            else
                Console.WriteLine("Error : Wrong Input");
            return null;
        }

        public static void displayOrder(Order O)
        {
            Console.WriteLine("Customer id                   : " + O.getCustomerId());
            Console.WriteLine("Order type                    : " + O.getType());
            Console.WriteLine("Order's Condition             : " + O.getCondition());
            Console.WriteLine("Order costs                   : " + O.getCost());

        }


    }
}
