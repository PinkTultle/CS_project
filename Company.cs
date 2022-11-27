using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SMP_cs
{
    internal class Company
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=Company;Uid=admin;Pwd=!#admin");

        public string Name { get; set; }
        public string Number{ get; set; } 
        public string Code { get; set; }

        //클래스 생성자
        public Company(string name, string phone, string ID)
        {
            Name = name;
            Number = phone;
            Code = ID;
        }

        //회사 정보 변경
        public void Update_val<T>(string target, T val)
        {

        }

        public bool Connect_check()
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM Items";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                while (table.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", table["ItemID"], table["Name"], table["Price"], table["Count"]);
                }
                return true;
            }
            catch
            {
                Console.WriteLine("don't connect table");
                return false;
            }
            

        }

    }
}
