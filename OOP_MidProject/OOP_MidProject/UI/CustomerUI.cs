using OOP_MidProject.BL;
using OOP_MidProject.DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.UI
{
    internal class CustomerUI
    {

        public static void viewCustomers(List<Customer> clist)
        {

            Console.WriteLine( "_________________________________________________________________________________________________" );
            Console.WriteLine($"{"Customer Id",-15}{"Name",-25}{"CNIC",-20}{"No. of Order",-15}{"Phone Model",-20}{"Employeeid",-15}");
            Console.WriteLine( "_________________________________________________________________________________________________" );
            foreach (Customer c in clist)
            {
                Console.WriteLine($"{c.getCusId(),-15}{c.getCustomerName(),-25}{c.getCustomerCNIC(),-20}{c.getNoOfOrder(),-20}{c.getPhoneModel(),-20}{c.getEmpId(),-15}");
            }
            Console.WriteLine( "_________________________________________________________________________________________________" );
        }
        // As Order Cant be exist without Customer


        // Add 
        public static Customer addCustomer( )
        {
            int orderno;
            string customerName, CNIC, PhoneModel, customerID, EmpID;

            Console.Write("Enter customer's name         : ");
            customerName = Console.ReadLine();
            Console.Write("Enter customer's CNIC         : ");
            CNIC  = Console.ReadLine();
            Console.Write("Enter customer's phone detail : ");
            PhoneModel = Console.ReadLine();
            Console.Write("Enter customer's no of order  : ");
            orderno = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Id : ");
            EmpID = (Console.ReadLine());
            List<Order> Olist = new List<Order>();
            for (int i =0; i < orderno; i++)
            { 
                Console.WriteLine("Input Customers Order "+(i+1)+" details ");
                Olist.Add(OrderUI.addOrder());
            }// use parameter con
            Customer C = new Customer();
            bool validity = C.setCustomerName(customerName) && C.setCustomerCNIC(CNIC) && C.setEmpId(EmpID)
                && C.setPhoneModel(PhoneModel) && C.setNoOfOrder(orderno) && C.setPlacedOrders(Olist);
            if (validity)
            {
                C.getnewID();
                Console.WriteLine("Customer Added Successfully");
                return C;
            }
            else
                Console.WriteLine("Error : Wrong Input");
            return null;
        }
       
        public static void displayCustomer(Customer C)
        {
            Console.WriteLine("Customer's name               : " + C.getCustomerName());
            Console.WriteLine("Customer's CNIC               : " + C.getCustomerCNIC());
            Console.WriteLine("Customer's no of order        : " + C.getNoOfOrder() );
            Console.WriteLine("Customer's phone detail       : " + C.getPhoneModel() );
            Console.WriteLine("Employee's name               : " + C.getEmpId());

        }
        
        /*
         *
                     Console.WriteLine( setw(15) << left << "Customer Id" << setw(20) << left << "Name" << setw(20) << left << "CNIC" << setw(15) << left << "No. of Order" << setw(15) << left << "Phone Model" <<  setw(15) << left << "Employeeid");
                Console.WriteLine(setw(15) << left << c.getCusId() << setw(15) << left << c.getCustomerName() << setw(20) << left << c.getNoOfOrder() << setw(20) << left << c.getPhoneModel() << c.getHandledBy()");
                   //
        Console.WriteLine(setw(15) << left << "Customer Id" << setw(15) << left << "Order Id" << setw(20) << left
                << "Order type" << setw(20) << left << "Order Conditon" << setw(20) << left << "Order Cost");

                      Console.WriteLine(setw(15) << left << o.getCustomerid() << setw(15) << left << o.getId() << setw(20) << left << o.getType()
                      << setw(20) << left << o.getCondition() << setw(20) << left << o.getCost());

                    Console.WriteLine( setw(30) << left << "Service Type" << setw(20) << left << "Required time(min)" << setw(20) << left << "Service cost" );
                        Console.WriteLine(setw(30) << left << s.getServiceId() <<  setw(20) << left << s.getServiceName() << setw(20) << left << s.getTimeRequired() << setw(20) << left << s.getCost());



            Console.WriteLine(setw(15) << left << "Employee Id" << setw(15) << left << "Employee Name" << setw(20) << left
                << "Contact" << setw(20) << left << "Salary" << setw(20) << left << "Hired Date" );
           Console.WriteLine(setw(15) << left << e.getEmployeeID() << setw(15) << left << e.getEmployeeName() << setw(20) << left << e.getEmpContact()
                      << setw(20) << left << e.getSalary() << setw(20) << left << e.getHiredDate());


           Console.WriteLine(setw(15) << left << "SparePart Id" << setw(15) << left << "Part Name" << setw(20) << left
                << "Price " << setw(20) << left << "Stock " );
            
          Console.WriteLine(setw(15) << left << sp.getPartID() << setw(15) << left << sp.getPartName() << setw(20) << left << sp.getPrice()
                      << setw(20) << left << sp.getStock() );


         
         */
    }
}
