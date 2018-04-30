using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace 模拟DOS系统
{

    class Dir : Adress
    {
        /// <summary>
        /// 输出当前目录下的目录以及文件信息
        /// </summary>
        public void nowdir()
        {
            Console.WriteLine("\n  {0} 的目录\n", path);
            long fSize = freeSpace();
            int x = 0;
            int i = 0;
            DirectoryInfo now = path;
            DirectoryInfo[] a = now.GetDirectories();
            string b = Path.GetFileNameWithoutExtension(adress);
            FileInfo[] files = path.GetFiles();
            long fileSize = 0;
            for (i = 0; i < a.Length; i++)
            {
                Console.WriteLine("{0,-20}        <DIR>        {1,-20}", a[i].CreationTime, a[i]);
            }
            for (x = 0; x < files.Length; x++)
            {
                Console.WriteLine("{0,-20}                     {1,-20}", files[x].CreationTime, files[x]);
                fileSize += files[x].Length;
            }

            Console.WriteLine("  {0,25}个文件          {1,10} 字节", x, this.zhuanhuan(fileSize));
            Console.WriteLine("  {0,25}个目录          {1,10} 字节可用\n", i, this.zhuanhuan(fSize));

        }
        /// <summary>
        /// 把数字3位用","分隔开
        /// </summary>
        /// <param name="num">传进去的long类型的值</param>
        /// <returns>处理后的字符串</returns>
        private string zhuanhuan(long num)
        {
            string numer = num.ToString();
            string flt = numer.IndexOf('.') < 0 ? "" : numer.Split('.')[1];
            numer = numer.Split('.')[0];
            int pnt = numer.Length % 3;
            if (numer.Length > 3)
            {
                while (pnt + 1 < numer.Length)
                {
                    int i = pnt % 4 == 0 ? pnt : pnt + 1;
                    if (i > 0) numer = numer.Insert(i - 1, ",");
                    pnt += 4;
                }
            }
            return numer + flt;
        }
        /// <summary>
        /// 输出指定目录下的文件目录及文件信息
        /// </summary>
        public void otherdir(string inputstring)
        {
            string a = inputstring;
            a = a.Substring(4, inputstring.Length - 4);
            if (Directory.Exists(a))                                            //检查路径是否存在
            {
                DirectoryInfo nowpath = new DirectoryInfo(a);
                Console.WriteLine("\n  {0} 的目录\n", nowpath);
                long fSize = freeSpace();
                int x = 0;
                int i = 0;
                DirectoryInfo now = nowpath;
                DirectoryInfo[] abcd = now.GetDirectories();
                string b = Path.GetFileNameWithoutExtension(a);
                FileInfo[] files = now.GetFiles();
                long fileSize = 0;
                for (i = 0; i < abcd.Length; i++)
                {
                    Console.WriteLine("{0,-20}        <DIR>        {1,-20}", abcd[i].CreationTime, abcd[i]);
                }
                for (x = 0; x < files.Length; x++)
                {
                    Console.WriteLine("{0,-20}                     {1,-20}", files[x].CreationTime, files[x]);
                    fileSize += files[x].Length;
                }

                Console.WriteLine("  {0,25}个文件          {1,10} 字节", x, this.zhuanhuan(fileSize));
                Console.WriteLine("  {0,25}个目录          {1,10} 字节可用\n", i, this.zhuanhuan(fSize));

            }
            else
            {
                Console.WriteLine("系统找不到指定的文件\n");
            }
        }
        /// <summary>
        /// 输出当前目录下的指定文件信息
        /// </summary>
        public void filedir(string inputstring)
        {
            string a = inputstring;
            a = a.Substring(4, inputstring.Length - 4);

            if (File.Exists(a))
            {
                FileInfo nowfile = new FileInfo(a);
                Console.WriteLine("\n  {0} 的目录\n", path);
                long fileSize = 0;
                long fSize = freeSpace();
                Console.WriteLine("{0,-20}                     {1,-20}", nowfile.CreationTime, a);
                fileSize += nowfile.Length;
                Console.WriteLine("  {0,25}个文件          {1,10} 字节", 1, this.zhuanhuan(fileSize));
                Console.WriteLine("  {0,25}个目录          {1,10} 字节可用\n", 0, this.zhuanhuan(fSize));
            }
            else
            {
                Console.WriteLine(a + "文件不存在\n");
            }
        }
        /// <summary>
        /// 输出当前目录下的同一类型文件的信息
        /// </summary>
        /// <param name="inputing"></param>
        public void inquireFlie(string inputing)
        {
            int x = 0;
            bool flag = false;
            long fileSize = 0;
            long fSize = freeSpace();
            int i = inputing.IndexOf('*');
            string a = inputing.Substring(i + 1, inputing.Length - i - 1);
            FileInfo[] files = path.GetFiles();
            foreach (FileInfo item in files)
            {
                if (item.Name.EndsWith(a))
                {
                    flag = true;
                    x++;
                }
            }
           
            if (flag == false)
            {
                Console.WriteLine("找不到指定文件\n");
            }
            else
            {
                Console.WriteLine("\n{0}的目录\n", path);
                foreach (FileInfo item in files)
                {
                    if (item.Name.EndsWith(a))
                    {
                        Console.WriteLine("{0,-20}                     {1,-20}", item.CreationTime, item);
                        fileSize += item.Length;
                    }
                }
                Console.WriteLine("  {0,25}个文件          {1,10} 字节", x, this.zhuanhuan(fileSize));
                Console.WriteLine("  {0,25}个目录          {1,10} 字节可用\n", 0, this.zhuanhuan(fSize));
            }
        }
        /// <summary>
        /// 返回当前的磁盘剩余空间
        /// </summary>
        /// <returns></returns>
        public long freeSpace()
        {
            long fSize = 0;
            DriveInfo[] drive = DriveInfo.GetDrives();
            string str_f = adress.Substring(0, 3);
            foreach (DriveInfo drives in drive)
            {
                if (drives.Name == str_f)
                {
                    fSize = drives.TotalFreeSpace;              //获取当前磁盘的剩余空间
                }
            }
            return fSize;
        }
    }
}


