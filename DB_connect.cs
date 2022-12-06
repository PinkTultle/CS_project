using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SMP_cs
{
   class DB_connect
    {
            string _server = "43.200.223.225"; //DB 서버 주소, 로컬일 경우 localhost
            int _port = 3306; //DB 서버 포트
            string _database = "todolist"; //DB 이름
            string _id = "admin"; //계정 아이디
            string _pw = "!#admin"; //계정 비밀번호
            string _connectionAddress = "";
            public MySqlConnection conn;


            public void Open()
            {
                try
                {
                    _connectionAddress = $"Server={_server};Port={_port};Database={_database};Uid={_id};Pwd={_pw}";
                    if (conn == null)
                    {
                        conn = new MySqlConnection(_connectionAddress);
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public void Close()
            {
                try
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public void SQLQuery(string query)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
   }
}
