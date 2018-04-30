using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 模拟DOS系统
{
    class Program:Adress
    {
        static void Main(string[] args)
        {
            bool flag = true;       //程序可以一直循环执行下去
            Console.WriteLine("Microsoft Windows  [版本 6.1.7601]");
            Console.WriteLine("版权所有 <c> 2009 Microsoft Corporation.  保留所有权力。\n");
            while (flag)
            {
                Console.Write(path + ">");
                Detector inputString = new Detector(Console.ReadLine());        //实例化Detector对象，用来接收输入的字符
                inputString.detectorString();                                   //调用判断函数，对输入进来的字符进行判别
            }
        }
    }
}
