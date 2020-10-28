using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLDK_Forum.Models;
using DLDK_Forum.Models.Function;

namespace DLDK_Forum.Controllers
{
    public class PostController : Controller
    {
        MyDB MyDBContext = new MyDB();

        // GET: Post
        public ActionResult ListPost(string idChuDe)
        {
            BaiVietDAO Dao = new BaiVietDAO();
            List<BaiViet> BV = Dao.GetBaiViets(idChuDe).ToList();
            return View(BV);
            
        }
        public ActionResult TableOfContents()
        {
            List<ChuDe> Topics = MyDBContext.ChuDes.ToList();
            return View(Topics);
        }
        public ActionResult Single_Post(string idPost)
        {
            var BaiViet = MyDBContext.BaiViets.SingleOrDefault(s => s.MaBaiViet == idPost);
            return View(BaiViet);
        }
        public ActionResult NewPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangbai(BaiViet BV,HttpPostedFileBase file)
        {
            BaiVietDAO DAO = new BaiVietDAO();
            BV.Email = "user1@gmail.com";
            BV.TinhTrang = 1;
            BV.ThoiGian = DateTime.Now;
            BV.MaBaiViet = DAO.BaiMoi();
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/images/"), filename);
                file.SaveAs(imgpath);
                BV.DuongDanHinhAnh = "images/" + file.FileName;
            }
            else
            {
                BV.DuongDanHinhAnh = "images/Ha_long_1.jpg";
            }
            MyDBContext.BaiViets.Add(BV);
            MyDBContext.SaveChanges();
            return Redirect("/Post/Single_Post?idPost="+BV.MaBaiViet);
        }
    }
}