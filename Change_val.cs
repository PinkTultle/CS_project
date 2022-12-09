using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SMP_cs
{
    internal class Change_val
    {
        string val_str,Rt_str;
        int Rt_int;
        double Rt_double;
        bool Rt_bool;

        //입력 값 : val, 변형후 반환할 자료형 : type
        public object Change_type<T>(T val, string type)
        {
            val_str= val.ToString();
            try
            {
                switch (type)
                {   //int형 반환
                    case "int":
                        return int.Parse(val_str);
                    //str형 반환
                    case "str":
                        return val_str;
                    //bool형 반환
                    case "bool":
                        return bool.Parse(val_str);
                    //double형 반환
                    case "double":
                        return double.Parse(val_str);

                    default:
                        return null;

                }
            } catch
            {
                return null;
            }

        }












    }
}
