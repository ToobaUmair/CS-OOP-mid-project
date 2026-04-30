using OOP_MidProject.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.BL
{
    internal class Service
    { 
        // Attribute
        public string serviceId ;
        private List<SparePart> usedParts = new List<SparePart>();
        private List<Order> usedInOrder = new List<Order>();
        public string serviceName ;
        public int cost ;
        public string timeRequired ;



        // Constructor Overloading
        public Service() { }
        // constructor without id parameter
        public Service(string serviceName, int cost, string timeRequired)
        {
            this.serviceName = GenerateServiceID();
            this.serviceName = serviceName;
            this.cost = cost;
            this.timeRequired = timeRequired;
        }
        public Service(string serviceId, string serviceName, int cost, string timeRequired)
        {
            this.serviceId = serviceId;
            this.serviceName = serviceName;
            this.cost = cost;
            this.timeRequired = timeRequired;
        }


        // automatic id generating
        private static int service_id_no = 5;
        public static string GenerateServiceID()
        {
            service_id_no++;
            return "SE" + service_id_no.ToString("D3");
        }



        // Setter
        public bool setOrdersList(List<Order> olist)
        {
            if (olist == null) return false;
            usedInOrder = olist;
            return true;
        }
        public bool setServiceId(string serviceId)
        {
            if (!ServiceDL.isIdExist(serviceId)) return false;
            this.serviceId = serviceId.Trim();
            return true;
        }
        public bool setServiceName(string serviceName)
        {
            if (string.IsNullOrWhiteSpace(serviceName)) return false;
            this.serviceName = serviceName.Trim();
            return true;
        }
        public bool setCost(int cost)
        {
            if (cost < 0) return false;
            this.cost = cost;
            return true;
        }
        public bool setTimeRequired(string timeRequired)
        {
            if (string.IsNullOrWhiteSpace(timeRequired)) return false;
            this.timeRequired = timeRequired.Trim();
            return true;
        }
        public bool setPartList(List<SparePart> parts)
        {
            if (parts == null) return false;
            this.usedParts = parts;
            return true;
        }


        // Getter
        public List<Order> getOrdersList() { return usedInOrder; }
        public string getServiceId() {  return serviceId; }
        public List<SparePart> getPartList() {  return usedParts; }
        public string getServiceName() {  return serviceName; }
        public int getCost() {  return cost; }
        public string getTimeRequired() {  return timeRequired; }
      
        public void getnewID()
        {
            service_id_no++;
            serviceId =  "SE" + service_id_no.ToString("D3");
        }
    }
}
