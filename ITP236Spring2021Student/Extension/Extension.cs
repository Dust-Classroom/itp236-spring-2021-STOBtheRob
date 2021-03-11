using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public static class Extension
    {
        public static string ZipCode(this int zip)
        {
            string zipCode = zip.ToString();
            
            if (zipCode.Length == 0)
            {
                zipCode = "00000";
            }
            if (zipCode.Length == 1)
            {
                zipCode = "0000" + zipCode;
            }
            if (zipCode.Length == 2)
            {
                zipCode = "000" + zipCode;
            }
            if (zipCode.Length == 3)
            {
                zipCode = "00" + zipCode;
            }
            if (zipCode.Length == 4)
            {
                zipCode = "0" + zipCode;
            }
            if (zipCode.Length == 5)
            {
                zipCode = zipCode;
            }
            if (zipCode.Length > 5)
            {
                zipCode =  zipCode.Substring(0, 5);
            }

            return zipCode;
        }

        public static string Left(this string name, int length)
        {
            if (name == null)
            {
                return null;
            }

            int stringLength = name.Length;
            if (length >= stringLength || stringLength < 1)
            {
                return name;
            }
            return name.Substring(0, length);
        }
        public static string Right(this string name, int length)
        {
            if (name == null)
            {
                return null;
            }

            int stringLength = name.Length;
            if (length >= stringLength || stringLength < 1)
            {
                return name;
            }
            return name.Substring(stringLength - length, length);

        }
        
    }

}
    


