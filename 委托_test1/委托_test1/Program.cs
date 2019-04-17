using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托_test1
{
    public delegate int MyDelegate(int x, int y);  //声明委托，限定参数数目、类型和返回值。
 
    class Delegate_Demo
    {
        //声明事件
        static event MyDelegate myEvent;



        static void Main(string[] args)
        {

            //注册事件的方式进行调用时不需要实例化被委托者
            //Helper helper = new Helper();

            //交代事件
            //调用者无法访问委托对象
            myEvent += new Helper().Add;            
            int sum3 = myEvent(3, 4);



            //使用回调函数          
            int sum1 = MyAdd(7, 3, new Helper().Add);
            Console.WriteLine("   " + sum3 + "   "+sum1 );
            Console.ReadKey();

        }


        //回调函数
        //可传入任何符合这个委托的方法
        private static int MyAdd(int x, int y, MyDelegate myDele)
        {
            return myDele(x, y);
        }

    }

}
