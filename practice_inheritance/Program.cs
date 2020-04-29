using System;

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

            var ma = new MyAssistant("高橋");

            var lunch = new LunchMenu { 
            food = "カレー",
            drink="ラッシー"
            };
            Console.WriteLine(lunch.Show());

            //アップキャスト。WorkingPersonオブジェクトをPerson型の変数pに代入
            Person p = new WorkingPerson { FirstName ="木村",LastName="花子"};
            //継承先で隠蔽されたメソッドの場合、基底クラスのメソッドが呼び出される
            Console.WriteLine(p.Show());
            //オーバーライドされたメソッドが呼び出される
            Console.WriteLine(p.Show2());
            //ダウンキャスト。pをWorkingPerson型の変数wpに型変換しながら代入する
            if (p is WorkingPerson wp)//実行時エラー避けるために型チェック
            {
                Console.WriteLine(wp.Show());
                Console.WriteLine(wp.Work());
            }
            //ダウンキャスト別構文.キャストに失敗した場合はnullを返す
            var wp2 = p as WorkingPerson;
            if (wp2 != null)
            {
                Console.WriteLine(wp2.Show());
                Console.WriteLine(wp2.Work());
            }
        }
    }
    #region Person基底クラスを定義
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
    #endregion

    #region WorkingPerson継承クラスを定義
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
    #endregion


    #region MyBoss基底クラスを定義
    class MyBoss
    {
        //引数ありのコンストラクター定義（デフォルトコンストラクターではない）
        public MyBoss(string assistantName)
        {
            Console.WriteLine($"{assistantName}の上司です");
        }
    }
    #endregion

    #region MyAssistant継承クラスを定義
    class MyAssistant :MyBoss
    {
        //コンストラクター定義。デフォルトコンストラクターでない場合、baseキーワードで呼び出す必要あり
        public MyAssistant(string assistantName) :base(assistantName)
        {
            Console.WriteLine($"部下の{assistantName}です");
        }
    }
    #endregion

    //継承を禁止するクラス
    sealed class LunchMenu
    {
        public string food { get; set; }
        public string drink { get; set; }
        public string Show()
        {
            return $"今日のメニューは{food}と{drink}です";
        }

    }
}
