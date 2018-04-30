using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 模拟DOS系统
{
    public class Adress
    {
        public static string adress = Directory.GetCurrentDirectory();      //获取当前路径；
        public static DirectoryInfo path = new DirectoryInfo(adress);       //创建当前目录对象；
    }
}
