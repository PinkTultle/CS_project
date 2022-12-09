using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;

namespace SMP_cs
{
    class DB_connect
    {
        string _server = "wwater.xyz"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 31001; //DB 서버 포트
        string _database = "todolist"; //DB 이름
        string _id = "todolist"; //계정 아이디
        string _pw = "yJma3IHh"; //계정 비밀번호
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


        //데이터 베이스의 테이블을 복사해서 각 폼에서 사용할 데이터 테이블에 삽입 반환
        public DataTable Copy_DT(DataTable dataTable, string target)
        {
            try
            {
                DataSet ds = new DataSet();

                DataTable table= new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = new MySqlCommand($"select * From {target} ORDER BY `Name` ASC;", conn);
                da.Fill(table);

                return dataTable = table;
            }
            catch ( Exception ex)
            {
                MessageBox.Show($"{ex}");
                return null;
            }
        }




    }
}
