using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenFood.Models;

namespace GreenFood.Common
{
    
    [Serializable]
    public class User
    {
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public int UserID { get; set; }
        public string UserName { get; set; }

        
        
    }
    
}