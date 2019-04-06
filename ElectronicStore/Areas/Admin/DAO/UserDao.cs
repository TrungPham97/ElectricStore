using ElectronicStore.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Model.DAO
{
    public class UserDao
    {
        TMDT db = null;
        public UserDao()
        {
            db = new TMDT();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        
        public User GetById(string UserName)
        {
            return db.Users.SingleOrDefault(x => x.taiKhoan == UserName);
        }
        public bool Login(string UserName,string Password)
        {

            var result = db.Users.Count(x => x.matKhau == UserName && x.matKhau == Password);
            if (result > 0)
            {
                return true;

            }
            else
                return false;
        }
    }
}
