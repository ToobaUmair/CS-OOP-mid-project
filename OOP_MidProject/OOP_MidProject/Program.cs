using OOP_MidProject.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_MidProject.BL;
using OOP_MidProject.DL;

namespace OOP_MidProject
{
    internal class Program


    { 

  

        static void loadAllData(string constring)
        {
            CustomerDL.loadCustomerData(constring);
            EmployeeDL.loadEmployeeData(constring);
            ServiceDL.loadServiceData(constring);
            OrderDL.loadOrderData(constring);
            SparePartDL.loadSparePartData(constring);

        }
        static string connectionString = DL.DatabaseHelper.ConnectionString;

        static void Main(string[] args)
        {
            bool exitFromMain = false;
            while(!exitFromMain){
            loadAllData(connectionString);
            bool exit = true;
            char ch;
            int opt = MenuUI.mainMenu();
                while (exit && !exitFromMain)
                {
                    ConsoleClear();
                    switch (opt)
                    {
                        case 1:
                            ch = MenuUI.customerMenu();
                            ConsoleClear();
                            exit = manageCustomer(ch);
                            break;
                        case 2:
                            ch = MenuUI.orderMenu();
                            ConsoleClear();
                            exit = manageOrder(ch);
                            break;
                        case 3:
                            ch = MenuUI.serviceMenu();
                            ConsoleClear();
                            exit = manageService(ch);
                            break;
                        case 4:
                            ch = MenuUI.employeeMenu();
                            ConsoleClear();
                            exit = manageEmployee(ch);
                            break;
                        case 5:
                            ch = MenuUI.spartPartMenu();
                            ConsoleClear();
                            exit = manageSparePart(ch);
                            break;
                        case 6:
                            ch = MenuUI.AddAssociation();
                            ConsoleClear();
                            manageAssociation(ch);
                            break;
                        case 0:
                            exitFromMain = true;
                            break;

                    }
                }
}
            }


        static void ConsoleClear()
        {
            Console.WriteLine("Press Any Enter.....");
            Console.ReadLine();
            Console.Clear();
        }

        static bool manageCustomer(char ch)
        {
            CustomerDL.loadCustomerData(connectionString);
            Customer C = new Customer();
            switch (ch)
            {
                case 'C':
                    Console.WriteLine(" \x1b[96m*** Add Customer ***\x1b[0m");

                    C = CustomerUI.addCustomer();
                    if (C != null)
                        CustomerDL.addCustomerToList(C);

                    break;
                case 'R':
                    Console.WriteLine(" \x1b[96m*** Read Customer ***\x1b[0m");
                    Console.Write("Enter customer's ID          : ");
                    string id = Console.ReadLine();
                    C = CustomerDL.readCustomer(id);
                    CustomerUI.displayCustomer(C);
                    break;
                case 'U':
                    Console.WriteLine(" \x1b[96m*** Update Customer ***\x1b[0m");
                    Console.Write("Enter customer's ID          : ");
                    id = Console.ReadLine();
                    C = CustomerUI.addCustomer();
                    C.setCusId(id);
                    if (CustomerDL.updateCustomer(C)) 
                    { Console.WriteLine("Wrong User"); }
                    break;
                case 'D':
                    Console.WriteLine(" \x1b[96m*** Delete Customer ***\x1b[0m");
                    Console.Write("Enter customer's ID          : ");
                    id = Console.ReadLine();
                    CustomerDL.deleteCustomer(id);
                    break;
                case 'V':
                    Console.WriteLine(" \x1b[96m*** View Customer ***\x1b[0m");
                    CustomerUI.viewCustomers(CustomerDL.customers);
                    break;
                case 'A':
                    Console.WriteLine(" \x1b[96m*** View Order of Customer ***\x1b[0m");
                    Console.Write("Enter customer's ID          : ");
                    Console.WriteLine("The OrderList of Customer    : ");
                    id = Console.ReadLine();
                    if (CustomerDL.isIdExist(id)){
                        Console.WriteLine("The OrderList of Customer   : ");

                        C = CustomerDL.readCustomer(id);
                        OrderUI.viewOrder(C.getPlacedOrders());
                    } else
                        Console.WriteLine("ERROR ! You have entered wrong input...");
                    break;
                case 'E':
                    Console.WriteLine(" \x1b[96m*** Exit Menu ***\x1b[0m");

                    Console.WriteLine("Customer Data has been save successfully \n\n");
                    return false;
                default: break;
            }
            return true;
        }
        static bool manageService(char ch)
        {
            ServiceDL.loadServiceData(connectionString);

            Service S = new Service();
            switch (ch)
            {
                case 'C':
                    Console.WriteLine(" \x1b[96m*** Add Service ***\x1b[0m");
                    S = ServiceUI.addService();
                    if (S != null)
                        ServiceDL.addServiceToList(S);

                    break;
                case 'R':
                    Console.WriteLine(" \x1b[96m*** Read Service ***\x1b[0m");
                    Console.Write("Enter service's ID           : ");
                    string id = Console.ReadLine();
                    S = ServiceDL.readService(id);
                    ServiceUI.displayService(S);
                    break;
                case 'U':
                    Console.WriteLine(" \x1b[96m*** Update Service ***\x1b[0m");
                    Console.Write("Enter service's ID           : ");
                    id = Console.ReadLine();
                    S.setServiceId(id);

                    S = ServiceUI.addService();
                    if (ServiceDL.updateService(S))
                    { Console.WriteLine("Wrong User"); }
                    break;
                case 'D':
                    Console.WriteLine(" \x1b[96m*** Delete Service ***\x1b[0m");
                    Console.Write("Enter service's ID           : ");
                    id = Console.ReadLine();
                    ServiceDL.deleteService(id);
                    break;
                case 'V':
                    Console.WriteLine(" \x1b[96m*** View Service ***\x1b[0m");
                    ServiceUI.viewServices(ServiceDL.services);
                    break;
                case 'A':
                    Console.WriteLine(" \x1b[96m*** View Spare Part To Service ***\x1b[0m");
                    Console.Write("Enter Service Id : ");
                    string sid = Console.ReadLine();
                    if (ServiceDL.isIdExist(sid))
                    {
                        S = ServiceDL.readService(sid);
                        SparePartUI.viewSparePart(S.getPartList());
                    }else
                        Console.WriteLine("ERROR ! You have entered wrong input...");
                    break;

                case 'E':
                    Console.WriteLine(" \x1b[96m*** Exit Service ***\x1b[0m");
                    Console.WriteLine("Service Data has been save successfully ");

                    return false;
                    break;
                default: break;
            }return true;
        }

        static bool manageOrder(char ch)
        {
            OrderDL.loadOrderData(connectionString);

            Order O = new Order();
            switch (ch)
            {
                case 'C':
                    Console.WriteLine(" \x1b[96m*** Add Order ***\x1b[0m");
                    O = OrderUI.addOrder();
                    if(O !=  null)
                    OrderDL.addOrderToList(O);

                    break;
                case 'R':
                    Console.WriteLine(" \x1b[96m*** Read Order ***\x1b[0m");
                    Console.Write("Enter order's ID             : ");
                    string id = Console.ReadLine();
                    O = OrderDL.readOrder(id);
                    OrderUI.displayOrder(O);
                    break;
                case 'U':
                    Console.WriteLine(" \x1b[96m*** Update Order ***\x1b[0m");
                    Console.Write("Enter order's ID             : ");
                    id = Console.ReadLine();
                    O = OrderUI.addOrder();
                    O.setId(id);
                    if (OrderDL.updateOrder(O))
                    { Console.WriteLine("Wrong User"); }
                    break;
                case 'D':
                    Console.WriteLine(" \x1b[96m*** Delete Order ***\x1b[0m");
                    Console.Write("Enter order's ID             : ");
                    id = Console.ReadLine();
                    OrderDL.deleteOrder(id);
                    break;
                case 'V':
                    Console.WriteLine(" \x1b[96m*** View Order ***\x1b[0m");
                    OrderUI.viewOrder(OrderDL.orders);
                    break;
                case 'S':
                    Console.WriteLine(" \x1b[96m*** View Order By Status ***\x1b[0m");
                    Console.Write("Enter the status(pending, delivered, completed) : ");
                    string status = Console.ReadLine();
                    OrderUI.viewOrderByStatus(OrderDL.orders, status);
                    break;

                case '$':
                    Console.WriteLine(" \x1b[96m*** View Order By Status ***\x1b[0m");
                    Console.Write("Enter order's ID             : ");
                     id = Console.ReadLine();
                    O = OrderDL.readOrder(id);
                    Console.Write("Enter the status(pending, delivered, completed) : ");
                     status = Console.ReadLine();
                    O.setstatus(status);
                    break;

                case 'A':
                    Console.WriteLine(" \x1b[96m*** View Order By Status ***\x1b[0m");
                    Console.Write("Enter the OrderId : ");
                     id = Console.ReadLine();
                    if( OrderDL.isIdExist(id)){
                    O = OrderDL.readOrder(id);
                        ServiceUI.viewServices(O.GetServices());
                    }else
                        Console.WriteLine("ERROR ! You have entered wrong input...");
                    break;

                case 'E':
                    Console.WriteLine(" \x1b[96m*** Exit Order ***\x1b[0m");

                    Console.WriteLine("Order Data has been save successfully ");

                    return false;
                    
                default: break;
            }
            return true;
        }

        static bool manageEmployee(char ch)
        {
            EmployeeDL.loadEmployeeData(connectionString);

            Employee E = new Employee();
            switch (ch)
            {

                case 'C':
                    Console.WriteLine(" \x1b[96m*** Add Employee ***\x1b[0m");
                    E = EmployeeUI.addEmployee();
                    if (E != null)
                        EmployeeDL.addEmployeeToList(E);

                    break;
                case 'R':
                    Console.WriteLine(" \x1b[96m*** Read Employee ***\x1b[0m");
                    Console.Write("Enter employee's ID          : ");
                    string id = Console.ReadLine();
                      E = EmployeeDL.readEmployee(id);
                    EmployeeUI.displayEmployee(E);
                    break;
                case 'U':
                    Console.WriteLine(" \x1b[96m*** Update Employee ***\x1b[0m");
                    Console.Write("Enter employee's ID          : ");
                    id = Console.ReadLine();
                    E.setEmployeeID(id);

                    E = EmployeeUI.addEmployee();
                    if (EmployeeDL.updateEmployee(E))
                    { Console.WriteLine("Wrong User"); }
                    break;
                case 'D':
                    Console.WriteLine(" \x1b[96m*** Delete Employee ***\x1b[0m");
                    Console.Write("Enter employee's ID          : ");
                    id = Console.ReadLine();
                    EmployeeDL.deleteEmployee(id);
                    break;
                case 'V':
                    Console.WriteLine(" \x1b[96m*** View Employee ***\x1b[0m");
                    EmployeeUI.viewEmployee(EmployeeDL.employees);
                    break;
                case 'A':
                    Console.WriteLine(" \x1b[96m*** View Handled Customer of Employee ***\x1b[0m");
                    Console.Write("Enter Employee's ID          : ");
                    id = Console.ReadLine();
                    if(EmployeeDL.isIdExist(id)){
                    Console.WriteLine("The Handled Customer of Employee   : ");
                    E = EmployeeDL.readEmployee(id);
                        CustomerUI.viewCustomers(E.getHandledCustomer());
                    } else
                        Console.WriteLine("ERROR ! You have entered wrong input...");

                    break;
                case 'E':
                    Console.WriteLine(" \x1b[96m*** Exit Employee ***\x1b[0m");
                    Console.WriteLine("Employee Data has been save successfully ");

                    return false;
                    break;
                default: break;
            }
            return true;
        }

        static bool manageSparePart(char ch)
        {
            SparePartDL.loadSparePartData(connectionString);
            SparePart SP = new SparePart();
            switch (ch)
            {
                case 'C':
                    Console.WriteLine(" \x1b[96m*** Add SparePart ***\x1b[0m");
                    SP = SparePartUI.addSparePart();
                    SparePartDL.addSparePartToList(SP);

                    break;
                case 'R':
                    Console.WriteLine(" \x1b[96m*** Read SparePart ***\x1b[0m");
                    Console.Write("Enter Spare Part's ID        : ");
                    string id = Console.ReadLine();
                    SP = SparePartDL.readSparePart(id);
                    SparePartUI.displaySparePart(SP);
                    break;
                case 'U':
                    Console.WriteLine(" \x1b[96m*** Update SparePart ***\x1b[0m");
                    Console.Write("Enter Spare Part's ID        : ");
                    id = Console.ReadLine();
                    SP.setPartID(id);
                    SP = SparePartUI.addSparePart();
                    if (SparePartDL.updateSparePart(SP))
                    { Console.WriteLine("Wrong User"); }
                    break;
                case 'D':
                    Console.WriteLine(" \x1b[96m*** Delete SparePart ***\x1b[0m");
                    Console.Write("Enter Spare Part's ID        : ");
                    id = Console.ReadLine();
                    SparePartDL.deleteSparePart(id);
                    break;
                case 'V':
                    Console.WriteLine(" \x1b[96m*** View SparePart ***\x1b[0m");
                    SparePartUI.viewSparePart(SparePartDL.spareparts);
                    break;
                case 'A':
                    Console.WriteLine(" \x1b[96m*** View Service to spare parts ***\x1b[0m");
                    Console.Write("Enter SparePart Id : ");
                    string spid = Console.ReadLine();
                    if (SparePartDL.isIdExist(spid))
                    {
                        SP = SparePartDL.readSparePart(spid);
                        ServiceUI.viewServices(SP.getServiceList());
                    }
                    else
                        Console.WriteLine("ERROR ! You have entered wrong input...");

                    break;
                case 'E':
                    Console.WriteLine(" \x1b[96m*** Exit SparePart ***\x1b[0m");

                    Console.WriteLine("SparePart Data has been save successfully ");

                    return false;
                    break;
                default: break;
            }
            return true;
        }
        static bool manageAssociation(char ch)
        {
            switch (ch)
            {
                case 'S':
                    Console.WriteLine(" \x1b[96m*** Add service to spare parts ***\x1b[0m");
                    Console.Write("Enter service Id : ");
                    string serid = Console.ReadLine();
                    Console.Write("Enter SparePart Id : ");
                    string spid = Console.ReadLine();
                    SparePartDL.addServiceToSparePart(serid, spid);

                    break;
                case 'O':
                    Console.WriteLine(" \x1b[96m*** Add service association to Order  ***\x1b[0m");
                    Console.Write("Enter service Id : ");
                    serid = Console.ReadLine();
                    Console.Write("Enter Order Id : ");
                    string oid = Console.ReadLine();
                    ServiceDL.addServiceToOrder(serid, oid);
                    break;
                case '$':
                    Console.WriteLine(" \x1b[96m*** Delete service to spare parts ***\x1b[0m");
                    Console.Write("Enter service Id : ");
                     serid = Console.ReadLine();
                    Console.Write("Enter SparePart Id : ");
                     spid = Console.ReadLine();
                    SparePartDL.deleteServiceToSparePart(serid, spid);
                    Console.WriteLine("Deleted ");

                    break;
                case '0':
                    Console.WriteLine(" \x1b[96m*** Delete service association to Order  ***\x1b[0m");
                    Console.Write("Enter service Id : ");
                    serid = Console.ReadLine();
                    Console.Write("Enter Order Id : ");
                     oid = Console.ReadLine();
                    ServiceDL.deleteServiceToOrder(serid, oid);
                    Console.WriteLine("Deleted ");
                    break;
                case 'E':
                    Console.WriteLine(" \x1b[96m*** Exit SparePart ***\x1b[0m");

                    Console.WriteLine("Association Data has been save successfully ");

                    return false;
                    break;
                default: break;
            }
            return true;
        }

    }
}
