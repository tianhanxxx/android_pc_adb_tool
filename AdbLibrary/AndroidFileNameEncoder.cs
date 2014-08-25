using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdbLibrary
{
    //修改命名编码（未使用）
    public class AndroidFileNameEncoder
    {
        //从UTF8变更为GB2312
        public static string UTF8ToGB2312(string str)   
        {             
            try       
            {                 
                Encoding utf8 = Encoding.GetEncoding(65001);                
                Encoding gb2312 = Encoding.GetEncoding("gb2312");//Encoding.Default ,936 
                byte[] temp = utf8.GetBytes(str);                 
                byte[] temp1 = Encoding.Convert(utf8, gb2312, temp);
                string result = gb2312.GetString(temp1); 
                return result;   
            }    
            catch  (Exception ex)  
            { 
        return null;  
            }   
        }
       //从GB2312变更为UTF8
        public static string GB2312ToUTF8(string str)  
        {             
            try             
            { 
                Encoding uft8 = Encoding.GetEncoding(65001); 
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] temp = gb2312.GetBytes(str);
                byte[] temp1 = Encoding.Convert(gb2312, uft8, temp); 
                string result = uft8.GetString(temp1);
                return result; 
            }
            catch  (Exception ex)//(UnsupportedEncodingException ex) 
            {
                return null;
            }        
        }

        public static string ToUTF8(string str)
        {
            byte[] buffer = System.Text.Encoding.GetEncoding("utf-8").GetBytes(str);
            string temp = System.Text.Encoding.Default.GetString(buffer);
            return temp;
        }
    }
}
