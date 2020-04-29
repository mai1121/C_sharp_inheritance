﻿using System;

namespace practice_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var wp1 = new WorkingPerson
            {
                FirstName = "佐藤",
                LastName = "愛子"
            };
            Console.WriteLine(wp1.Show());
            Console.WriteLine(wp1.Work());
            Console.WriteLine(wp1.Area("六本木"));
            Console.WriteLine(wp1.Show2());
        }
    }
    //基底クラスを定義
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Show()
        {
            return $"私の名前は{this.FirstName}{this.LastName}です";
        }
        //オーバーライド用の仮想メソッド定義
        public virtual string Show2()
        {
            return $"{this.FirstName}{this.LastName}は休職中です";
        }
    }
    //継承クラスを定義
    class WorkingPerson : Person
    {
        public string Work()
        {
            return $"{this.FirstName}{this.LastName}は働いています";
        }
        //メソッドの隠蔽①（基底クラスのメソッドを上書き）
        public new string Show()
        {
            return $"私は会社員の{this.FirstName}{this.LastName}です";
        }
        //メソッドの隠蔽②(基底クラスのメソッド呼び出し)
        public string Area(string a)
        {
            var result = base.Show();
            return $"{result}。{a}で働いています。";
        }
        //基底クラスのメソッドをオーバーライド
        public override string Show2()
        {
            return $"{this.FirstName}{this.LastName}は病気療養中です";
        }
    }
}