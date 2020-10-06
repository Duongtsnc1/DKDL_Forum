using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLDK_Forum.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult ListPost()
        {
            return View();
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