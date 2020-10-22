using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLDK_Forum.Models;
using DLDK_Forum.Models.N_models;
using DLDK_Forum.Models.Function;
namespace DLDK_Forum.Controllers
{
    public class HomeController : Controller
    {
        MyDB MyDBContext = new MyDB();
        public ActionResult Login_Logout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung model)
        {
            ViewBag.mes = "";
            NguoiDungDAO DAO = new NguoiDungDAO();
            var result = DAO.login(model.Email, model.MatKhau);
            if (result == true)
            {
                ViewBag.mes = "Thành công";
                return RedirectToAction("Home");
            }
            else
            {
                TempData["Error"] = "Tài Khoản Hoặc Mật Khẩu Không Đúng!!!!!!";
                return RedirectToAction("Login_Logout");
            } 
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemPhanHoi(PhanHoi model)
        {
            ViewBag.mes = "";

            if (ModelState.IsValid) { 
                PhanHoi tmp = new PhanHoi();
                tmp.Email = model.Email;
                tmp.HoTen = model.HoTen;
                tmp.NoiDung = model.NoiDung;
                tmp.ThoiGian = DateTime.Now;
                MyDBContext.PhanHois.Add(tmp);
                MyDBContext.SaveChanges();
                ViewBag.mes = "Cảm ơn bạn! Vì chúng tôi luôn luôn lắng nghe và thấu hiểu!";
            }
            else
            {
                ViewBag.mes = "Hãy điền đầy đủ thông tin! Cảm ơn bạn";
            }
            return View("Contact");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Account(string idAccount)
        {
            var TaiKhoan = MyDBContext.NguoiDungs.SingleOrDefault(s => s.Email == idAccount);
            return View(TaiKhoan);
        }
        public ActionResult List_Topic()
        {
            return View();
        }
        public ActionResult HotAccount()
        {
            NguoiDungDAO DAO = new NguoiDungDAO();
            return View(DAO.GetHotNguoiDung().GetRange(0,4));
        }
        public ActionResult HotBaiViet()
        {
            BaiVietDAO DAO = new BaiVietDAO();
            return View(DAO.GetHotBaiViets().GetRange(0, 4));
        }
        public ActionResult tesst()
        {
            
            return View();

        }
    }
}