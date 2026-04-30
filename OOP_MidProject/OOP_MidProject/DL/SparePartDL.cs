using OOP_MidProject.BL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace OOP_MidProject.DL
{
    internal class SparePartDL
    {
        public static List<SparePart> spareparts = new List<SparePart>();

        public static void addSparePartToList(SparePart SP)
        {
            string query =
                "INSERT INTO sparepart (PartID, PartName, Price, Stock) " +
                $"VALUES ('{SP.getPartID()}', '{SP.getPartName()}', {SP.getPrice()}, {SP.getStock()})";
            DatabaseHelper.Update(query);
            spareparts.Add(SP);
        }

        public static bool isIdExist(string id)
        {
            foreach (SparePart SP in spareparts)
            {
                if (SP.getPartID() == id) return true;
            }
            return false;
        }

        public static bool updateSparePart(SparePart SP)
        {
            foreach (SparePart sp in spareparts)
            {
                if (sp.getPartID() == SP.getPartID())
                {
                    string query =
                        "UPDATE sparepart SET " +
                        $"PartName = '{SP.getPartName()}', " +
                        $"Price = {SP.getPrice()}, " +
                        $"Stock = {SP.getStock()} " +
                        $"WHERE PartID = '{SP.getPartID()}'";
                    DatabaseHelper.Update(query);
                    return true;
                }
            }
            return false;
        }

        public static SparePart readSparePart(string id)
        {
            foreach (SparePart sp in spareparts)
            {
                if (sp.getPartID() == id) return sp;
            }
            return null;
        }

        public static void deleteSparePart(string id)
        {
            for (int i = spareparts.Count - 1; i >= 0; i--)
            {
                if (spareparts[i].getPartID() == id)
                {
                    string query = $"DELETE FROM sparepart WHERE PartID = '{id}'";
                    DatabaseHelper.Update(query);
                    spareparts.RemoveAt(i);
                }
            }
        }

        public static bool addServiceToSparePart(string sid, string spid)
        {
            if (isIdExist(spid) && ServiceDL.isIdExist(sid))
            {
                string query = $"INSERT INTO servicesparepart (ServiceID, PartID) VALUES ('{sid}', '{spid}')";
                DatabaseHelper.Update(query);
                return true;
            }
            return false;
        }
        public static bool deleteServiceToSparePart(string sid, string spid)
        {
            if (isIdExist(spid) && ServiceDL.isIdExist(sid))
            {
                string query = $"delete from servicesparepart where ServiceID = '{sid}'and PartID = '{spid}'";
                DatabaseHelper.Update(query);
                return true;
            }
            return false;
        }

        public static void loadSparePartData(string conString)
        {
            spareparts.Clear();
            using (var connection = DatabaseHelper.getConnection())
            {
                string query = "SELECT PartID, PartName, Price, Stock FROM sparepart";
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SparePart SP = new SparePart(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3)
                        );
                        spareparts.Add(SP);
                    }
                }

                foreach (var SP in spareparts)
                {
                    var Slist = new List<Service>();
                    string sq =
                        "SELECT s.ServiceID, s.ServiceName, s.Cost, s.TimeRequired " +
                        "FROM service s INNER JOIN servicesparepart ss ON s.ServiceID = ss.ServiceID " +
                        $"WHERE ss.PartID = '{SP.getPartID()}'";
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
                    SP.setServiceList(Slist);
                }
            }
        }
    }
}
