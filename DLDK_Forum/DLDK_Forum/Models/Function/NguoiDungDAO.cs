using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLDK_Forum.Models.Function
{
    public class NguoiDungDAO
    {
        MyDB a;
        public NguoiDungDAO()
        {
            a = new MyDB();
        }
        //public IQueryable<NguoiDung> GetHotNguoiDung()
        //{
        //    var result = (from ND in a.NguoiDungs join BV in a.BaiViets
        //                select );
        //    return result;
        //}
    }
}