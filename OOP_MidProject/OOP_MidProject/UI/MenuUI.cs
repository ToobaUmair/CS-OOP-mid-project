using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.UI
{
    internal class MenuUI
    {
        public static int mainMenu()
        {

            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m"); // coral red
            Console.WriteLine("\x1b[96m                 Welcome To Mobile Repairing Shop Management System\x1b[0m");                                               // Neon Blue color
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93m1\x1b[0m to Manage customer "); // Yellow color
            Console.WriteLine("Enter \x1b[93m2\x1b[0m to Manage order");
            Console.WriteLine("Enter \x1b[93m3\x1b[0m to Manage service");
            Console.WriteLine("Enter \x1b[93m4\x1b[0m to Manage employee");
            Console.WriteLine("Enter \x1b[93m5\x1b[0m to Manage spare part");
            Console.WriteLine("Enter \x1b[93m6\x1b[0m to Manage Association (Many to many )");
            
            Console.WriteLine("Enter \x1b[93m0\x1b[0m to Save data and Exit the program");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            

            Console.Write( "\x1b[38;2;255;138;101m Input the option \x1b[0m : ");
            
            return int.Parse(Console.ReadLine());


        }
        public static char customerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("\n\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("\x1b[96m Manage Customer \x1b[0m");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93mC\x1b[0m to Add customer");
            Console.WriteLine("Enter \x1b[93mR\x1b[0m to read customers ");
            Console.WriteLine("Enter \x1b[93mU\x1b[0m to update customer");
            Console.WriteLine("Enter \x1b[93mD\x1b[0m to delete customer");
            Console.WriteLine("Enter \x1b[93mV\x1b[0m to view all customer");
            Console.WriteLine("Enter \x1b[93mA\x1b[0m to view all order of customer"); 
            Console.WriteLine("Enter \x1b[93mE\x1b[0m go back to the menu ");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.Write("\x1b[38;2;255;138;101mEnter operation  :\x1b[0m");

            return char.Parse(Console.ReadLine());

        }


        public static char orderMenu()
        {
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("\x1b[96m Manage Order \x1b[0m");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93mC\x1b[0m to Add customer's order ");
            Console.WriteLine("Enter \x1b[93mR\x1b[0m to read customer's order ");
            Console.WriteLine("Enter \x1b[93mU\x1b[0m to update customer's order");
            Console.WriteLine("Enter \x1b[93mD\x1b[0m to delete customer's order");
            Console.WriteLine("Enter \x1b[93mV\x1b[0m to View all order");
            Console.WriteLine("Enter \x1b[93mS\x1b[0m to view all order by Status");
            Console.WriteLine("Enter \x1b[93m$\x1b[0m to update order's Status");
            Console.WriteLine("Enter \x1b[93mA\x1b[0m to view services used in order");
            Console.WriteLine("Enter \x1b[93mE\x1b[0m go back to the menu ");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.Write("\x1b[38;2;255;138;101mEnter operation  :\x1b[0m");

            return char.Parse(Console.ReadLine());

        }
  
    
        public static char serviceMenu()
        {
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("\x1b[96m Manage Service \x1b[0m");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93mC\x1b[0m to Add service ");
            Console.WriteLine("Enter \x1b[93mR\x1b[0m to read service ");
            Console.WriteLine("Enter \x1b[93mU\x1b[0m to update service");
            Console.WriteLine("Enter \x1b[93mD\x1b[0m to delete service");
            Console.WriteLine("Enter \x1b[93mV\x1b[0m to View all service"); ;
            Console.WriteLine("Enter \x1b[93mA\x1b[0m to View spare Parts of a service");// *****
            Console.WriteLine("Enter \x1b[93mE\x1b[0m to go back to the menu");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.Write("\x1b[38;2;255;138;101mEnter operation  :\x1b[0m");

            return char.Parse(Console.ReadLine());

        }
        public static char employeeMenu()
        {
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("\x1b[96m Manage Employee \x1b[0m");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93mC\x1b[0m to Add employee ");
            Console.WriteLine("Enter \x1b[93mR\x1b[0m to read employee ");
            Console.WriteLine("Enter \x1b[93mU\x1b[0m to update employee");
            Console.WriteLine("Enter \x1b[93mD\x1b[0m to delete employee");
            Console.WriteLine("Enter \x1b[93mV\x1b[0m to View all employee");
            Console.WriteLine("Enter \x1b[93mA\x1b[0m to View all Handle customer of a employee");//*****
            Console.WriteLine("Enter \x1b[93mE\x1b[0m to go back to the menu");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.Write("\x1b[38;2;255;138;101mEnter operation  :\x1b[0m");

            return char.Parse(Console.ReadLine());

        }
        public static char AddAssociation()
        {
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("\x1b[96m Manage Association  \x1b[0m");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93mS\x1b[0m to add association to Service and spare part ");
            Console.WriteLine("Enter \x1b[93mO\x1b[0m to add association to Service and order  ");
            Console.WriteLine("Enter \x1b[93m$\x1b[0m to delete association to Service and spare part ");
            Console.WriteLine("Enter \x1b[93m0\x1b[0m to delete association to Service and order  ");
            Console.WriteLine("Enter \x1b[93mE\x1b[0m to go back to the menu");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.Write("\x1b[38;2;255;138;101mEnter operation  :\x1b[0m");

            return char.Parse(Console.ReadLine());

        }

        public static char spartPartMenu()
        {
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("\x1b[96m Manage Spare Part \x1b[0m");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.WriteLine("Enter \x1b[93mC\x1b[0m to Add spare part ");
            Console.WriteLine("Enter \x1b[93mR\x1b[0m to read spare part ");
            Console.WriteLine("Enter \x1b[93mU\x1b[0m to update spare part");
            Console.WriteLine("Enter \x1b[93mD\x1b[0m to delete spare part");
            Console.WriteLine("Enter \x1b[93mV\x1b[0m to View all spare part");
            Console.WriteLine("Enter \x1b[93mA\x1b[0m to View all service that used spare part");
            Console.WriteLine("Enter \x1b[93mE\x1b[0m to go back to the menu");
            Console.WriteLine("\x1b[38;2;255;241;118m***************************************************************************************************\x1b[0m");
            Console.Write("\x1b[38;2;255;138;101mEnter operation  :\x1b[0m");

            return char.Parse(Console.ReadLine());

        }

    }
}
