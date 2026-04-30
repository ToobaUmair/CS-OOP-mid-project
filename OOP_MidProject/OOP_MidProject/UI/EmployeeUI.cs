using OOP_MidProject.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.UI
{
    internal class EmployeeUI
    {
        public static void viewEmployee(List<Employee> Elist)
        {
            Console.WriteLine("_________________________________________________________________________________________________");
            Console.WriteLine($"{"Employee Id",-15}{"Employee Name",-15}{"Contact",-20}{"Salary",-20}{"Hired Date",-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
            foreach (Employee e in Elist)
                Console.WriteLine($"{e.getEmployeeID(),-15}{e.getEmployeeName(),-15}{e.getEmpContact(),-20}{e.getSalary(),-20}{e.getHiredDate(),-20}");
            Console.WriteLine("_________________________________________________________________________________________________");
        }

        public static Employee addEmployee()
        {
            string name, contact;
            int salary;
            DateTime hiredDate;
            Console.WriteLine("Enter employee's name          : ");
            name = Console.ReadLine();
            Console.Write("Enter employee's contact           : ");
            contact = Console.ReadLine();
            Console.Write("Enter employee's salary            : ");
            salary = int.Parse(Console.ReadLine());
            Console.Write("Enter employee's hired Date        : ");
            hiredDate = DateTime.Parse(Console.ReadLine());
 
            Employee e = new Employee();
            bool validity = e.setEmployeeName(name) && e.setEmpContact(contact) && e.setSalary(salary) && e.setHiredDate(hiredDate);
            if (validity) {
                e.getnewID();
                Console.WriteLine("Employee Added Successfully");
                return e; }
            else
                Console.WriteLine("Error : Wrong Input");
            return null;
        }
        public static void displayEmployee(Employee E)
        {

            Console.WriteLine("Employee's name               : " + E.getEmployeeName());
            Console.WriteLine("Employee's no of HandledPerson: " + E.getNoOfCustomerHandled());
            Console.WriteLine("Employee's contact no.        : " + E.getEmpContact());
            Console.WriteLine("Employee's salary             : " + E.getSalary());
            Console.WriteLine("Employee's date of hired      : " + E.getHiredDate());

        }
     
    }
}
