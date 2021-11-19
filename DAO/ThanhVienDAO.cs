using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GreenFood.Models;

namespace GreenFood.DAO
{
    
    public class ThanhVienDAO
    {
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public long InsertForFacebook(THANHVIEN entity)
        {
            var user = db.THANHVIENs.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.THANHVIENs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaTV;
            }
            else
            {
                return user.MaTV;
            }
            
        }
    }
}