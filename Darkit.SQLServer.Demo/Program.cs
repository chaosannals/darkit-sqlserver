using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.SQLServer.Demo
{
    class Tester
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始");
            using (SQLServerSession session = new SQLServerSession())
            {
                session.The("tester")
                    .Column<string>("")
                    .Create();
                session.From("tester")
                    .Select<Tester>();
            }
            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }
}
