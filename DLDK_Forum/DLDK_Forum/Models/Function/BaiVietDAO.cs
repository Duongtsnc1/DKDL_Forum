using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DLDK_Forum.Models;

namespace DLDK_Forum.Models.Function
{
    public class BaiVietDAO
    {
        MyDB a;
        public BaiVietDAO()
        {
            a = new MyDB();
        }

        public IQueryable<BaiViet> GetBaiViets(string idChuDe)
        {
            var result = (from s in a.BaiViets
                           where s.MaChuDe == idChuDe
                           select s);
            return result;
        }
        public IQueryable<BaiViet> GetHotBaiViets(string idChuDe)
        {
            var result = (from s in a.BaiViets
                          where s.MaChuDe == idChuDe
                          select s);
            return result;
        }
    }
}