using OOP_MidProject.BL;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.UI
{
    internal class SparePartUI
    {       //sp
        public static void viewSparePart(List<SparePart> Splist)
        {
            Console.WriteLine("_________________________________________________________________________________________________");
            Console.WriteLine($"{"SparePart Id",-20}{"Part Name",-25}{"Price",-20}{"Stock",-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
            foreach (SparePart sp in Splist)
                Console.WriteLine($"{sp.getPartID(),-20}{sp.getPartName(),-25}{sp.getPrice(),-20}{sp.getStock(),-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
        }

        public static SparePart addSparePart()
        {
            string name;
            int price , stock;
            Console.Write("Enter spare part's name          : ");
            name = Console.ReadLine();
            Console.Write("Enter spare part's price         : ");
            price = int.Parse(Console.ReadLine());
            Console.Write("Enter spare part's stock         : ");
            stock = int.Parse(Console.ReadLine());

            SparePart sp = new SparePart();
            bool validity = sp.setPrice(price)&& sp.setStock(stock)&& sp.setPartName(name);
            if (validity)
            {
                sp.getNewID();
                Console.WriteLine("SparePart Added Successfully");
                return sp;
            }
            else
                Console.WriteLine("Error : Wrong Input");
            return null;
        }
        public static void displaySparePart(SparePart SP)
        {
            Console.WriteLine("Spare part's name             : " + SP.getPartName());
            Console.WriteLine("SparePart's price             : " + SP.getPrice());
            Console.WriteLine("SparePart's stock             : " + SP.getStock());


        }

    }
}
