using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP_cs
{
    internal class Company
    {

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



    }
}
