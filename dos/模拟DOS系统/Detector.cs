using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 模拟DOS系统
{
    class Detector
    {
        Cd cd = new Cd();
        Dir dir = new Dir();
        private string inputString;
        public Detector(string inputString)
        {
            this.inputString = inputString;                                 //获取到输入的字符串
        }
        public Detector()
        { }
        public void detectorString()
        {
            if (this.inputString.Contains("cd"))
            {
                if (this.inputString == "cd/?")                                                 //显示帮助字符
                {
                    cd.cdhelp();
                }
                else if (this.inputString == @"cd\")                                            //返回根目录
                {
                    cd.cdagain();
                }
                else if (this.inputString == @"cd..")                                           //返回上层目录
                {
                    cd.cdup();
                }
                else if (this.inputString.Contains("cd "))                                      //进入下层目录
                {
                    string sub = inputString;
                    int index = sub.IndexOf(' ');
                    string subString = sub.Substring(index + 1, inputString.Length - index - 1);
                    bool a = subString.Contains(@"\");
                    if (a == false)
                    {
                        cd.cdnext(subString);
                    }
                    else
                    {
                        Console.WriteLine("'{0}'不是内部或外部命令，也不是可运行的程序\n或批处理文件。\n", this.inputString);
                    }
                }
                else
                {
                    Console.WriteLine("'{0}'不是内部或外部命令，也不是可运行的程序\n或批处理文件。\n", this.inputString);
                }
            }
            else if (cdstring(this.inputString))                                               //进入其他盘符
            {
               
                    cd.othercd(this.inputString);
              
                
            }
            else if (this.inputString.Contains("dir") || this.inputString == "DIR")           //dir命令
            {
                if (this.inputString == "dir" || this.inputString == "DIR")                     //输出当前目录下的文件与目录信息
                {
                    dir.nowdir();
                }
                else if (this.inputString.Contains(@"\"))                                     //输出指定目录下的文件目录与文件信息
                {
                    dir.otherdir(this.inputString);
                }
                else if (dirstring(this.inputString))
                {
                    dir.inquireFlie(this.inputString);                                          //输出当前目录下同一类型文件的信息
                }
                else if (this.inputString.Contains("."))
                {
                    dir.filedir(this.inputString);                                              //输出当前目录下指定文件的详细信息
                }
                else
                {
                    Console.WriteLine("系统找不到指定的文件");
                }
            }
            else
            {
                Console.WriteLine("'{0}'不是内部或外部命令，也不是可运行的程序\n或批处理文件。\n", this.inputString);
            }
        }
        /// <summary>
        /// 判断dir命令中查找指定文件信息字符的方法
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private bool dirstring(string inputString)
        {
            if (inputString.Contains("*"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 判断cd转到其他盘符字符的方法
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public bool cdstring(string inputString)
        {
            bool x = false;
            DriveInfo[] s = DriveInfo.GetDrives();
            foreach (DriveInfo item in s)
            {
                if (item.Name.ToString() == inputString.ToUpper() + '\\')
                {
                    x = true;
                }
            }
            return x;
        }
        

    }
}
