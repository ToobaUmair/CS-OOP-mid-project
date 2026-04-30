using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_MidProject.DL;

namespace OOP_MidProject.BL
{//att
//    para
//   genert
//    sett
//        gett

    internal class Customer
    {
        // Attribute
        private string cusId;
        private string employeeId;
        private string customerName;
        private string customerCNIC;
        private int noOfOrder;
        private string phoneModel;

         // Constructor Overloading
        public Customer() { }
        public Customer(string cusId, string customerName, string customerCNIC, int noOfOrder, string phoneModel, string EmployeeID)
        {
            this.cusId = cusId;
            this.customerName = customerName;
            this.customerCNIC = customerCNIC;
            this.noOfOrder = noOfOrder;
            this.phoneModel = phoneModel;
            this.employeeId = EmployeeID;
        }
        // constructor without id parameter
        public Customer(string customerName, string customerCNIC, int noOfOrder, string phoneModel, List<Order> orders, string employeeId)
        {
            this.cusId = GenerateCustomerID();
            this.customerName = customerName;
            this.customerCNIC = customerCNIC;
            this.noOfOrder = noOfOrder;
            this.phoneModel = phoneModel;
            this.employeeId = employeeId;
        }

        // automatic id generating
        private static int customer_id_no = 5;
        public static string GenerateCustomerID()
        {
            customer_id_no++;
            return "CU" + customer_id_no.ToString("D3");
        }
        

        // Setter
        public string getEmpId() { return employeeId; }
        private List<Order> placedOrders = new List<Order>();
        public bool setEmpId(string employeeId) { if (!EmployeeDL.isIdExist(employeeId)) return false;
            this.employeeId = employeeId;
            return true;
        }
        public List<Order> getPlacedOrders( )
        {
           return placedOrders;
        }
        public bool setCusId(string cusId)
        {
            if (!CustomerDL.isIdExist(cusId)) return false;
            this.cusId = cusId.Trim();
            return true;
        }
        public bool setCustomerName(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName)) return false;
            this.customerName = customerName.Trim();
            return true;
        }
        public bool setCustomerCNIC(string customerCNIC)
        {
            if (string.IsNullOrWhiteSpace(customerCNIC) || customerCNIC.Length < 13)
                return false;

            this.customerCNIC = customerCNIC.Trim();
            return true;
        }
        public bool setNoOfOrder(int noOfOrder)
        {
            if (noOfOrder < 0) return false;
            this.noOfOrder = noOfOrder;
            return true;
        }
        public bool setPhoneModel(string phoneModel)
        {
            if (string.IsNullOrWhiteSpace(phoneModel)) return false;
            this.phoneModel = phoneModel.Trim();
            return true;
        }
        public bool setPlacedOrders(List<Order> olist)
        {
            if (olist == null) return false;
            placedOrders = olist;
            return true;
        }

        // Getter
        public string getCusId( ) { return cusId; }
        public string getCustomerName( ) { return customerName; }
        public string getCustomerCNIC( ) { return customerCNIC; }
        public int getNoOfOrder() { return noOfOrder; }
        public string getPhoneModel( ) { return phoneModel; }
        public void getnewID()
        {
            customer_id_no++;
            cusId =  "CU" + customer_id_no.ToString("D3");
        }

    }
}
