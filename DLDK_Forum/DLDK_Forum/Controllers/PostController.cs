using System;
using System.Collections.Generic;
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
        public ActionResult Single_Post()
        {
            return View();
        }
        public ActionResult NewPost()
        {
            return View();
        }
        
    }
}