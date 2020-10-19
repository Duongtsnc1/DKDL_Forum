﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DLDK_Forum.Models;
using DLDK_Forum.Models.N_models;

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
        public List<HotPost> GetHotBaiViets()
        {
            List<HotPost> NDBV = new List<HotPost>();
            var BV = a.BaiViets.ToList();
            HotPost tmp;
            foreach (var item in BV)
            {
                tmp = new HotPost();
                tmp.ID = item;
                tmp.tuongtac = item.CamXucs.Where(s=>s.Thich==1).Count();
                NDBV.Add(tmp);
            }
            NDBV.Sort((a, b) => a.tuongtac.CompareTo(b.tuongtac));
            NDBV.Reverse();
            return NDBV;
        }

    }
}