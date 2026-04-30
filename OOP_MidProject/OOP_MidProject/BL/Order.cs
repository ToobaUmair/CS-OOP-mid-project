using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_MidProject.DL;

namespace OOP_MidProject.BL
{
    internal class Order
    {
        // Attribute
        private string orderID;
        private List<Service> usedService = new List<Service>();
        private string orderType;
        private string orderCondition;
        private string customerID;
        private string status;
        private int cost;


        // Constructor Overloading
        public Order() { }

        public Order(string orderType, string condition, int cost, string customerId)
        {
            this.orderID = GenerateOrderID();
            this.orderType = orderType;
            this.orderCondition = condition;
            this.status = "pending";
            this.cost = cost;
            this.customerID = customerId;
        }

        public Order(string id, string orderType, string condition, string status, int cost, string customerId)
        {
            this.orderID = id;
            this.orderType = orderType;
            this.orderCondition = condition;
            this.status = status;
            this.cost = cost;
            this.customerID = customerId;
        }


        // automatic id generating
        private static int order_id_no = 5;
        public static string GenerateOrderID()
        {
            order_id_no++;
            return "OR" + order_id_no.ToString("D3");
        }



              // Setter
        public bool setId(string id)
        {
            if (!OrderDL.isIdExist(id)) return false;
            orderID = id.Trim();
            return true;
        }

        public bool setCustomerid(string customerid)
        {
            if (string.IsNullOrWhiteSpace(customerid)) return false;
            this.customerID = customerid.Trim();
            return true;
        }

        public bool setType(string OrderType)
        {
            if (string.IsNullOrWhiteSpace(OrderType)) return false;
            this.orderType = OrderType.Trim();
            return true;
        }

        public bool setCondition(string condition)
        {
            if (string.IsNullOrWhiteSpace(condition)) return false;
            orderCondition = condition.Trim();
            return true;
        }

        public bool setstatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) return false;
            this.status = status.Trim();
            return true;
        }

        public bool setCost(int Cost)
        {
            if (Cost < 0) return false;
            this.cost = Cost;
            return true;
        }

        public bool setServices(List<Service> service)
        {
            if (service == null) return false;
            usedService = service;
            return true;
        }

        // Getter 
        public string getCustomerId() { return customerID; }
        public string getId() { return orderID; }
        public string getType() { return orderType; }
        public string getCondition() { return orderCondition; }
        public string getStatus() { return status; }
        public int getCost() { return cost; }
        public List<Service> GetServices() { return usedService; }

        public  void getNewID()
        {
            order_id_no++;
            orderID =  "OR" + order_id_no.ToString("D3");
        }

    }
}
