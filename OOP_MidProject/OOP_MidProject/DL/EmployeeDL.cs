using OOP_MidProject.BL;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace OOP_MidProject.DL
{
    internal class EmployeeDL
    {
        public static List<Employee> employees = new List<Employee>();

        public static void addEmployeeToList(Employee E)
        {
            string hired = E.getHiredDate().ToString("yyyy-MM-dd");
            string query =
                "INSERT INTO employee (EmployeeID, EmployeeName, EmpContact, DateOfHired, Salary) " +
                $"VALUES ('{E.getEmployeeID()}', '{E.getEmployeeName()}', '{E.getEmpContact()}', '{hired}', {E.getSalary()})";
            DatabaseHelper.Update(query);
            employees.Add(E);
        }

        public static bool updateEmployee(Employee E)
        {
            foreach (Employee e in employees)
            {
                if (e.getEmployeeID() == E.getEmployeeID())
                {
                    string hired = E.getHiredDate().ToString("yyyy-MM-dd");
                    string query =
                        "UPDATE employee SET " +
                        $"EmployeeName = '{E.getEmployeeName()}', " +
                        $"EmpContact = '{E.getEmpContact()}', " +
                        $"DateOfHired = '{hired}', " +
                        $"Salary = {E.getSalary()} " +
                        $"WHERE EmployeeID = '{E.getEmployeeID()}'";
                    DatabaseHelper.Update(query);
                    return true;
                }
            }
            return false;
        }

        public static bool isIdExist(string id)
        {
            foreach (Employee E in employees)
            {
                if (E.getEmployeeID() == id) return true;
            }
            return false;
        }

        public static Employee readEmployee(string id)
        {
            foreach (Employee e in employees)
            {
                if (e.getEmployeeID() == id) return e;
            }
            return null;
        }

        public static void deleteEmployee(string id)
        {
            for (int i = employees.Count - 1; i >= 0; i--)
            {
                if (employees[i].getEmployeeID() == id)
                {
                    string query = $"DELETE FROM employee WHERE EmployeeID = '{id}'";
                    DatabaseHelper.Update(query);
                    employees.RemoveAt(i);
                }
            }
        }

        public static void loadEmployeeData(string conString)
        {
            employees.Clear();
            using (var connection = DatabaseHelper.getConnection())
            {
                string query = "SELECT EmployeeID, EmployeeName, EmpContact, DateOfHired, Salary FROM employee";
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee E = new Employee(
                            reader.GetString(0),
                            reader.IsDBNull(1) ? "" : reader.GetString(1),
                            reader.IsDBNull(2) ? "" : reader.GetString(2),
                            reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            reader.IsDBNull(4) ? 0L : reader.GetInt64(4)
                        );
                        employees.Add(E);
                    }
                }

                // second pass: handled customers
                foreach (var E in employees)
                {
                    var Clist = new List<Customer>();
                    string cq = $"SELECT CustomerID, CustomerName, CustomerCNIC, NoOfOrder, PhoneModel, EmployeeID FROM customer WHERE EmployeeID = '{E.getEmployeeID()}'";
                    var ccmd = new MySqlCommand(cq, connection);
                    using (var creader = ccmd.ExecuteReader())
                    {
                        while (creader.Read())
                        {
                            Customer C = new Customer(
                                creader.GetString(0),
                                creader.GetString(1),
                                creader.GetString(2),
                                creader.GetInt32(3),
                                creader.GetString(4),
                                creader.GetString(5)
                            );
                            Clist.Add(C);
                        }
                    }
                    E.setHandledCustomer(Clist);
                }
            }
        }
    }
}
