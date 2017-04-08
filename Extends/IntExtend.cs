using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extends
{
   public static  class IntExtend
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="obj"></param>
       /// <param name="defval">默认值=0</param>
       /// <returns></returns>
       public static int ObjToInt(this object obj, int defval=0) {
           try
           {
               if (obj == null) {
                   return defval;
               }

               return Convert.ToInt32(obj); 
           }
           catch (Exception e)
           { 
           }

           return defval;
       }

       public static long ObjToLong(this object obj, long defval = 0)
       {
           try
           {
               if (obj == null)
               {
                   return defval;
               }

               return Convert.ToInt64(obj);
           }
           catch (Exception e)
           {
           }

           return defval;
       }
    }
}
