using System;
using System.IO;
using System.Text;

namespace CoreBase.Help
{
    public static class FileExtensions
    {
        /// <summary>
        /// 取得文件編碼
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        public static Encoding GetEncodingType(this FileStream fs)
        {
            /*byte[] Unicode=new byte[]{0xFF,0xFE};  
            byte[] UnicodeBIG=new byte[]{0xFE,0xFF};  
            byte[] UTF8=new byte[]{0xEF,0xBB,0xBF};*/

            BinaryReader r = new BinaryReader(fs, Encoding.Default);
            byte[] ss = r.ReadBytes(3);
            r.Close();
            //編碼類型 Coding=編碼類型.ASCII;   
            if (ss[0] >= 0xEF)
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    Console.WriteLine(fs.Name.ToString() + "__UTF8");
                    return Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF)
                {
                    Console.WriteLine(fs.Name.ToString() + "__BIG5");
                    return Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE)
                {
                    return Encoding.Unicode;
                }
                else
                {
                    return Encoding.Default;
                }
            }
            else
            {
                return Encoding.Default;
            }
        }
    }
}
