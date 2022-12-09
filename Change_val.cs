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
        string val_str;
        bool Cheak_type;

        //입력 값 : val, 변형후 반환할 자료형 : type
        public object Change_type<T>(T val, string type)
        {
            //입력받은 변수 스트링 형으로 변환
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
                    //사용법이 틀린 경우 null값 반환
                    default:
                        return null;

                }
            } catch
            {
                //int >> bool / bool > int 과 같이 변환 불가능한 자료형끼리 자료형 변환 시도한 경우 예외처리
                return null;
            }

        }

        public object Cheak_dt<T> ( T val, string type)
        {
            string val_type = val.GetType().Name,
                int_ty = "int",
                str_ty = "str",
                bool_ty = "bool",
                double_ty = "double";
            

            if( type== int_ty )
            {
                if(val_type == "Int32")
                {
                    return true;
                }
                else return false;
            } 
            else if (type == str_ty)
            {
                if (val_type == "String")
                {
                    return true;
                }
                else return false;
            }
            else if (type == bool_ty)
            {
                if (val_type == "Boolean")
                {
                    return true;
                }
                else return false;
            }
            else if (type == double_ty)
            {
                if (val_type == "Double")
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return null;
            }



        }















    }
}
