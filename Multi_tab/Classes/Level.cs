using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Multi_tab.Classes
{
   public class Level
    {
       private int level_id;
       private string level_name;
       private string fees;

       public int Level_id
       {
           get
           {
               return level_id;
           }
           set
           {
               level_id = value;
           }
       }
       public string Level_Name
       {
           get
           {
               return level_name;
           }
           set
           {
               level_name = value;
           }
       }
       public string Level_Fees
       {
           get
           {
               return fees;
           }
           set
           {
               fees = value;
           }
       }
       public override string ToString()
       {
           return level_name;
       }
    }
}
