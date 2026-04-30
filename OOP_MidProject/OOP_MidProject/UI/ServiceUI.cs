using OOP_MidProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.UI
{
    internal class ServiceUI
    {
        public static  void viewServices(List<Service> slist)
        {
            Console.WriteLine("_________________________________________________________________________________________________");
            Console.WriteLine($"{"Service Id",-30}{"Service Type",-30}{"Required time(min)",-20}{"Service cost",-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
            foreach (Service s in slist)
                Console.WriteLine($"{s.getServiceId(),-30}{s.getServiceName(),-30}{s.getTimeRequired(),-20}{s.getCost(),-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
        }
        public static Service addService()
        {
            string serviceType, serviceTime;
            int serviceCost;
            Console.Write("Enter the service type          : ");
            serviceType = Console.ReadLine();
            Console.Write("Enter the time required         : ");
            serviceTime = Console.ReadLine();
            Console.Write("Enter the service costs         : ");
            serviceCost = int.Parse(Console.ReadLine());
            Service s = new Service(serviceType, serviceCost, serviceTime);
            bool validity = s.setServiceName(serviceType) && s.setTimeRequired(serviceTime)&& s.setCost(serviceCost);
            if (validity)
            {
                s.getnewID();
                s.setServiceId(Service.GenerateServiceID());
                Console.WriteLine("\n\nService.: "+s.getServiceId());

                Console.WriteLine("Service Added Successfully");
                return s;
            }
            else
                Console.WriteLine("Error : Wrong Input");
            return null;
        }
        public static void displayService(Service S)
        {
            Console.WriteLine("Service Name                  : " + S.getServiceName());
            Console.WriteLine("Required time in minutes      : " + S.getTimeRequired());
            Console.WriteLine("Service costs                 : " + S.getCost());

        }
    }
}
