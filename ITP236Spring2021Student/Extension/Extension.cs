using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public static class Extension
    {
        public static string Left(this string name, int length)
        {
            return name;
        }
        public static string Right(this string name, int length)
        {
            return name;
        }
        public static string ZipCode(this int zip) 
        {
            return string.Empty;
        }
    }
    

}
