using OOP_MidProject.BL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace OOP_MidProject.DL
{
    internal class ServiceDL
    {
        public static List<Service> services = new List<Service>();

        public static void addServiceToList(Service S)
        {
            string query =
                "INSERT INTO service (ServiceID, ServiceName, Cost, TimeRequired) " +
                $"VALUES ('{S.getServiceId()}', '{S.getServiceName()}', {S.getCost()}, '{S.getTimeRequired()}')";
            DatabaseHelper.Update(query);
            services.Add(S);
        }

        public static bool updateService(Service S)
        {
            foreach (Service s in services)
            {
                if (s.getServiceId() == S.getServiceId())
                {
                    string query =
                        "UPDATE service SET " +
                        $"ServiceName = '{S.getServiceName()}', " +
                        $"Cost = {S.getCost()}, " +
                        $"TimeRequired = '{S.getTimeRequired()}' " +
                        $"WHERE ServiceID = '{S.getServiceId()}'";
                    DatabaseHelper.Update(query);
                    return true;
                }
            }
            return false;
        }

        public static Service readService(string id)
        {
            foreach (Service S in services)
            {
                if (S.getServiceId() == id) return S;
            }
            return null;
        }

        public static bool isIdExist(string id)
        {
            foreach (Service S in services)
            {
                if (S.getServiceId() == id) return true;
            }
            return false;
        }

        public static void deleteService(string id)
        {
            for (int i = services.Count - 1; i >= 0; i--)
            {
                if (services[i].getServiceId() == id)
                {
                    string query = $"DELETE FROM service WHERE ServiceID = '{id}'";
                    DatabaseHelper.Update(query);
                    services.RemoveAt(i);
                }
            }
        }

        public static void addServiceToOrder(string sid, string oid)
        {
            if (isIdExist(sid) && OrderDL.isIdExist(oid))
            {
                string query = $"INSERT INTO orderservice (OrderID, ServiceID) VALUES ('{oid}', '{sid}')";
                DatabaseHelper.Update(query);
            }
        }
        public static void deleteServiceToOrder(string sid, string oid)
        {
            if (isIdExist(sid) && OrderDL.isIdExist(oid))
            {
                string query = $"delete from orderservice where OrderID = '{oid}' and ServiceID ='{sid}'";
                DatabaseHelper.Update(query);
            }
        }

        public static void loadServiceData(string conString)
        {
            services.Clear();
            using (var connection = DatabaseHelper.getConnection())
            {
                string query = "SELECT ServiceID, ServiceName, Cost, TimeRequired FROM service";
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Service S = new Service(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetString(3)
                        );
                        services.Add(S);
                    }
                }

                foreach (var S in services)
                {
                    var Olist = new List<Order>();
                    string oq =
                        "SELECT o.OrderID, o.OrderType, o.OrderCondition, o.Status, o.Cost, o.CustomerID " +
                        "FROM orders o INNER JOIN orderservice os ON o.OrderID = os.OrderID " +
                        $"WHERE os.ServiceID = '{S.getServiceId()}'";
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
                    S.setOrdersList(Olist);

                    var SPlist = new List<SparePart>();
                    string spq =
                        "SELECT sp.PartID, sp.PartName, sp.Price, sp.Stock " +
                        "FROM sparepart sp INNER JOIN servicesparepart ss ON sp.PartID = ss.PartID " +
                        $"WHERE ss.ServiceID = '{S.getServiceId()}'";
                    var spcmd = new MySqlCommand(spq, connection);
                    using (var spreader = spcmd.ExecuteReader())
                    {
                        while (spreader.Read())
                        {
                            SparePart SP = new SparePart(
                                spreader.GetString(0),
                                spreader.GetString(1),
                                spreader.GetInt32(2),
                                spreader.GetInt32(3)
                            );
                            SPlist.Add(SP);
                        }
                    }
                    S.setPartList(SPlist);
                }
            }
        }
    }
}
