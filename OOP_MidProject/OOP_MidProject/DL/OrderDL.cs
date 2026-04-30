using OOP_MidProject.BL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace OOP_MidProject.DL
{
    internal class OrderDL
    {
        public static List<Order> orders = new List<Order>();

        public static void addOrderToList(Order O)
        {
            string query =
                "INSERT INTO orders (OrderID, OrderType, OrderCondition, Status, Cost, CustomerID) " +
                $"VALUES ('{O.getId()}', '{O.getType()}', '{O.getCondition()}', '{O.getStatus()}', {O.getCost()}, '{O.getCustomerId()}')";


            DatabaseHelper.Update(query);
            orders.Add(O);
        }

        public static bool updateOrder(Order O)
        {
            foreach (Order o in orders)
            {
                if (o.getId() == O.getId())
                {
                    string customerId = string.IsNullOrEmpty(O.getCustomerId()) ? o.getCustomerId() : O.getCustomerId();
                    string query =
                        "UPDATE orders SET " +
                        $"OrderType = '{O.getType()}', " +
                        $"OrderCondition = '{O.getCondition()}', " +
                        $"Status = '{O.getStatus()}', " +
                        $"Cost = {O.getCost()}, " +
                        $"CustomerID = '{customerId}' " +
                        $"WHERE OrderID = '{O.getId()}'";
                    DatabaseHelper.Update(query);
                    return true;
                }
            }
            return false;
        }

        public static bool isIdExist(string id)
        {
            foreach (Order O in orders)
            {
                if (O.getId() == id) return true;
            }
            return false;
        }

        public static Order readOrder(string id)
        {
            foreach (Order o in orders)
            {
                if (o.getId() == id) return o;
            }
            return null;
        }

        public static void deleteOrder(string id)
        {
            for (int i = orders.Count - 1; i >= 0; i--)
            {
                if (orders[i].getId() == id)
                {
                    string query = $"DELETE FROM orders WHERE OrderID = '{id}'";
                    DatabaseHelper.Update(query);
                    orders.RemoveAt(i);
                }
            }
        }

        public static void loadOrderData(string conString)
        {
            orders.Clear();
            using (var connection = DatabaseHelper.getConnection())
            {
                string query = "SELECT OrderID, OrderType, OrderCondition, Status, Cost, CustomerID FROM orders";
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order O = new Order(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetString(5)
                        );
                        orders.Add(O);
                    }
                }

                // second pass: services for each order
                foreach (var O in orders)
                {
                    var Slist = new List<Service>();
                    string sq =
                        "SELECT s.ServiceID, s.ServiceName, s.Cost, s.TimeRequired " +
                        "FROM service s INNER JOIN orderservice os ON s.ServiceID = os.ServiceID " +
                        $"WHERE os.OrderID = '{O.getId()}'";
                    var scmd = new MySqlCommand(sq, connection);
                    using (var sreader = scmd.ExecuteReader())
                    {
                        while (sreader.Read())
                        {
                            Service S = new Service(
                                sreader.GetString(0),
                                sreader.GetString(1),
                                sreader.GetInt32(2),
                                sreader.GetString(3)
                            );
                            Slist.Add(S);
                        }
                    }
                    O.setServices(Slist);
                }
            }
        }
    }
}
