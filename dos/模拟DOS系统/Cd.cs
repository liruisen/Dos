using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 模拟DOS系统
{
    public class Cd : Adress
    {
        /// <summary>
        /// 显示帮助信息
        /// </summary>
        public void cdhelp()
        {
            Console.WriteLine("\n实现的功能\n");
            Console.WriteLine("cd命令：\n1.	显示功能信息			输入cd/?（模拟DOS系统帮助信息）\n2.	返回根目录      		输入cd\\");
            Console.WriteLine("3.	返回上层目录    		输入cd..\n4.	进入下层目录			输入cd 当前目录的下层名称（区分大小写，必须按照原格式输入）\n5.	跳转到其他盘符	             	输入需要跳转的盘符：（不区分大小写）\n");
            Console.WriteLine("dir命令\n1.  输出当前目录下的目录以及文件信息			输入dir(不区分大小写)\n2.  输出指定目录下的文件目录及文件信息		        输入dir 指定路径（区分大小写）\n3.  输出当前目录下指定文件的详细信息			输入dir 文件名（区分大小写）\n4.  输出当前目录下同一类型文件的详细信息		输入dir *.扩展名（区分大小写）\n");
        }
        /// <summary>
        /// 返回根目录
        /// </summary>
        public void cdagain()
        {
            path = path.Root;                           //更新目录路径
            adress = path.ToString();
        }
        /// <summary>
        /// 返回上层目录
        /// </summary>
        public void cdup()
        {
            if (adress != null)
            {
                string adre = adress;
                adress = Path.GetDirectoryName(adress);
                path = new DirectoryInfo(adress);
            }
        }
        /// <summary>
        /// 进入下一层目录
        /// </summary>
        public void cdnext(string subString)
        {
            string f = Path.Combine(adress, subString);
            DirectoryInfo a = new DirectoryInfo(f);
            bool b = a.Exists;
            if (b)
            {
                adress = f;
                path = new DirectoryInfo(adress);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("系统找不到指定的路径。");
            }
        }
        //进入其他盘符
        public void othercd(string inputString)
        {
            Detector a = new Detector();
            if (a.cdstring(inputString))
            {
                adress = inputString.ToUpper() + '\\';
                path = new DirectoryInfo(adress);
            }
            else
            {
                Console.WriteLine("系统找不到指定的驱动器。");
            }
        }
    }
}
