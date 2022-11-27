using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SMP_cs
{
    internal class Item
    {
        private string code, name;
        private int count, price;

        // 새로운 물품 등록, 기존 물품, 삭제 정보변경 사용할 클래스
        // 클래스 생성자 : 데이터 베이스에 저장된 데이터 or 사용자가 입력하는 데이터를 받아
        // 클래스로 만드는 역할 
        public Item (string code, string name, int count, int price)
        {
            this.code = code;
            this.name = name;
            this.count = count;
            this.price = price;
        }

        // 새로운 물품 등록시에 사용
        // 기능 : 데이터 베이스에 데이터 저장
        public bool New_item()
        {
            //데이터 베이스에 정보 삽입기능구현

            //동작 검증후 정상 작동시 true 반환
            //실패시 false 반환
            return false;
            return true;
        }

        //정보 변경 메서드 변경 항목 : target / 바꿀 값 : var
        static public void Update_val<T> (string target, T val)
        {
            
        }

        //삭제 메서드


        //검색 메서드






    }
}
