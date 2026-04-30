using OOP_MidProject.DL;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.BL
{
    internal class Employee
    {
        // Attribute
        private string employeeID ;
        private string employeeName ;
        private string empContact ;
        private DateTime hiredDate ;
        private long salary ;
        private int noOfCustomerHandled ;
        private List<Customer> handledCustomer = new List<Customer>();



        // Constructor Overloading
        public Employee() { }
        public Employee(string employeeID, string employeeName, string empContact, DateTime dateOfHired, long salary)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.empContact = empContact;
            this.hiredDate = dateOfHired;
            this.salary = salary;
        }
        // constructor without id parameter
        public Employee(string employeeName, string empContact, DateTime dateOfHired, long salary)
        {
            this.employeeID = GenerateEmployeeID();
            this.employeeName = employeeName;
            this.empContact = empContact;
            this.hiredDate = dateOfHired;
            this.salary = salary;
        }
        // Setter
     
        // automatic id generating

        private static int employee_id_no = 5;
        public static string GenerateEmployeeID()
        {
            employee_id_no++;
            return "EM" + employee_id_no.ToString("D3");
        }

        // Setter
        public bool setEmployeeID(string employeeID)
        {
            if (!EmployeeDL.isIdExist(employeeID))
                return false;

            this.employeeID = employeeID.Trim();
            return true;
        }

        public bool setEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                return false;

            this.employeeName = employeeName.Trim();
            return true;
        }

        public bool setEmpContact(string empContact)
        {
            // basic validation: not empty + length check (adjust as needed)
            if (string.IsNullOrWhiteSpace(empContact) || empContact.Length < 10)
                return false;

            this.empContact = empContact.Trim();
            return true;
        }

        public bool setHiredDate(DateTime hiredDate)
        {
            // hired date should not be in the future
            if (hiredDate > DateTime.Now)
                return false;

            this.hiredDate = hiredDate;
            return true;
        }

        public bool setSalary(int salary)
        {
            // salary must be positive
            if (salary < 0)
                return false;

            this.salary = salary;
            return true;
        }
        public void setHandledCustomer(List<Customer> Clist) { handledCustomer = Clist; }
        public bool setNoOfCustomerHandled(int noOfCustomerHandled)
        {
            if (noOfCustomerHandled < 0)
                return false;

            this.noOfCustomerHandled = noOfCustomerHandled;
            return true;
        }
        // Getter
        public string getEmployeeID() { return employeeID; }
        public string getEmployeeName() { return employeeName; }
        public string getEmpContact( ) { return empContact; } 
        public DateTime getHiredDate ( ) { return hiredDate; }
        public long getSalary ( ) { return salary; }
        public int getNoOfCustomerHandled( ) { return noOfCustomerHandled; }
        public List<Customer> getHandledCustomer()
        {
            return handledCustomer;
        }

        public void getnewID()
        {
            employee_id_no++;
            employeeID = "EM" + employee_id_no.ToString("D3");
        }







    }
}
