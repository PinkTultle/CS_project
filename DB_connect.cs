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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using System.Xml;

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
        public DataTable readSQL(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable table = new DataTable();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(table);
                return table;


            }
            catch (Exception e)
            {
                return null;
            }
        }
        public DataSet GetData(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void ProceDureSQLQuey(string query,string s1, string s2, string s3, string s4)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CP_Name", s1);
                cmd.Parameters.AddWithValue("@It_Name", s2);
                cmd.Parameters.AddWithValue("@It_Count", s3);
                cmd.Parameters.AddWithValue("@SL_Record", s4);
                cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        // Mysql 저장 프로시저를 위한 메소드
        public MySqlConnection Conn
        {
            get
            {
                return conn;
            }
            set
            {
                conn = value;
            }
        }




    }
}
