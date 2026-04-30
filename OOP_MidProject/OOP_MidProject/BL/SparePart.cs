using OOP_MidProject.DL;
using OOP_MidProject.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MidProject.BL
{

    internal class SparePart
    {
       
       // Attribute
        private string partID;
        private string partName;
        private int price;
        private int stock;
        private List<Service> usedInServices = new List<Service>();



        // automatic id generating
        private static int sparepart_id_no = 5;
        public static string GenerateSparePartID()
        {
            sparepart_id_no++;
            return "SP" + sparepart_id_no.ToString("D3");
        }


        // Constructor Overloading
        public SparePart(string partID, string partName, int price, int stock)
        {
            this.partID = partID;
            this.partName = partName;
            this.price = price;
            this.stock = stock;
        }
        public SparePart(string partName, int price, int stock)
        {
            this.partID = GenerateSparePartID();
            this.partName = partName;
            this.price = price;
            this.stock = stock;
        }
        public SparePart() { }


        // Setter
        public bool setPartID(string partID)
        {
            if (!SparePartDL.isIdExist(partID)) return false;
            this.partID = partID.Trim();
            return true;
        }

        public bool setPartName(string partName)
        {
            if (string.IsNullOrWhiteSpace(partName)) return false;
            this.partName = partName.Trim();
            return true;
        }

        public bool setPrice(int price)
        {
            if (price < 0) return false;
            this.price = price;
            return true;
        }

        public bool setStock(int stock)
        {
            if (stock < 0) return false;
            this.stock = stock;
            return true;
        }

        public bool setServiceList(List<Service> services)
        {
            if (services == null) return false;
            usedInServices = services;
            return true;
        }



        // Getter
        public List<Service> getServiceList(){ return usedInServices;}

        public string getPartID() { return partID; }
        // association
        public string getPartName() { return partName; }
        public int getPrice() { return price; }
        public int getStock() { return stock; }

        public void getNewID()
        {
            sparepart_id_no++;
            partID = "SP" + sparepart_id_no.ToString("D3");
            
        }




 

    }
}
