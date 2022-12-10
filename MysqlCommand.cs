using MySql.Data.MySqlClient;
using System;

namespace SMP_cs
{
    internal class MysqlCommand
    {
        private string v;
        private MySqlConnection conn;

        public MysqlCommand(string v, MySqlConnection conn)
        {
            this.v = v;
            this.conn = conn;
        }

        public static implicit operator MySqlCommand(MysqlCommand v)
        {
            throw new NotImplementedException();
        }
    }
}