using Model.DAO;
using ElectronicStore.Areas.Admin.Models;
using ElectronicStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        TMDT db = new TMDT();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = db.Users.Count(x => x.taiKhoan == model.UserName && x.matKhau == model.Password);
                if (result>0)
                {
                    var user = db.Users.SingleOrDefault(x => x.taiKhoan == model.UserName && x.matKhau == model.Password);
                    var userSession = new UserLogin
                    {
                        UserName = user.taiKhoan,
                        UserID = user.ID
                    };
                    Session.Add(CommonConstants.User_Session, userSession);
                    return RedirectToAction("index", "DashBoard");
                }
            }
             return View();
        }
    }
}