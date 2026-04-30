using MySql.Data.MySqlClient;
using OOP_MidProject.BL;
using OOP_MidProject.UI;
using System.Collections.Generic;

namespace OOP_MidProject.DL
{
    internal class CustomerDL
    {
        public static List<Customer> customers = new List<Customer>();

        public static void addCustomerToList(Customer C)
        {

            string query =
                "INSERT INTO customer (CustomerID, CustomerName, CustomerCNIC, NoOfOrder, PhoneModel, EmployeeID) " +
                $"VALUES ('{C.getCusId()}', '{C.getCustomerName()}', '{C.getCustomerCNIC()}', {C.getNoOfOrder()}, '{C.getPhoneModel()}', '{C.getEmpId()}')";
            DatabaseHelper.Update(query);
            for (int i = 0; i < C.getNoOfOrder(); i++) 
            {
                query = "INSERT INTO orders (OrderID, OrderType, OrderCondition, Status, Cost, CustomerID) " +
                 $"VALUES ('{C.getPlacedOrders()[i].getId()}', '{C.getPlacedOrders()[i].getType()}', '{C.getPlacedOrders()[i].getCondition()}', '{C.getPlacedOrders()[i].getStatus()}', {C.getPlacedOrders()[i].getCost()}, '{C.getCusId()}')";
                DatabaseHelper.Update(query);
            }
            customers.Add(C);
        }

        public static bool updateCustomer(Customer C)
        {
            foreach (Customer c in customers)
            {
                if (c.getCusId() == C.getCusId())
                {
                    string query =
                        "UPDATE customer SET " +
                        $"CustomerName = '{C.getCustomerName()}', " +
                        $"CustomerCNIC = '{C.getCustomerCNIC()}', " +
                        $"NoOfOrder = {C.getNoOfOrder()}, " +
                        $"PhoneModel = '{C.getPhoneModel()}', " +
                        $"EmployeeID = '{C.getEmpId()}' " +
                        $"WHERE CustomerID = '{C.getCusId()}'";
                    DatabaseHelper.Update(query);
                    return true;
                }
            }
            return false;
        }

        public static bool isIdExist(string id)
        {
            foreach (Customer C in customers)
            {
                if (C.getCusId() == id) return true;
            }
            return false;
        }

        public static Customer readCustomer(string id)
        {
            foreach (Customer c in customers)
            {
                if (c.getCusId() == id) return c;
            }
            return null;
        }

        public static void deleteCustomer(string id)
        {
            for (int i = customers.Count - 1; i >= 0; i--)
            {
                if (customers[i].getCusId() == id)
                {
                    string query = $"DELETE FROM customer WHERE CustomerID = '{id}'";
                    DatabaseHelper.Update(query);
                    customers.RemoveAt(i);
                }
            }
        }

        public static void loadCustomerData(string conString)
        {
            customers.Clear();
            using (var connection = DatabaseHelper.getConnection())
            {
                string query = "SELECT CustomerID, CustomerName, CustomerCNIC, NoOfOrder, PhoneModel, EmployeeID FROM customer";
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer C = new Customer(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetString(5)
                        );
                        customers.Add(C);
                    }
                }
                // to load customers's order in list
                foreach (var C in customers)
                {
                    var Olist = new List<Order>();
                    string oq = $"SELECT OrderID, OrderType, OrderCondition, Status, Cost, CustomerID FROM orders WHERE CustomerID = '{C.getCusId()}'";
                    var ocmd = new MySqlCommand(oq, connection);
                    using (var oreader = ocmd.ExecuteReader())
                    {
                        while (oreader.Read())
                        {
                            Order O = new Order(
                                oreader.GetString(0),
                                oreader.GetString(1),
                                oreader.GetString(2),
                                oreader.GetString(3),
                                oreader.GetInt32(4),
                                oreader.GetString(5)
                            );
                            Olist.Add(O);
                        }
                    }
                    C.setPlacedOrders(Olist);
                }
            }
        }
    }
}
