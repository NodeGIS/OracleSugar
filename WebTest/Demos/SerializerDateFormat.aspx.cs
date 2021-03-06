﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OracleSugar;
using WebTest.Dao;
using OracleSugar;
using Models;
namespace WebTest.Demos
{
    /// <summary>
    /// 设置序列化后的JSON格式
    /// </summary>
    public partial class SerializerDateFormat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlSugarClient db = SugarDao.GetInstance())
            {
                db.SerializerDateFormat = "yyyy-mm/dd";
                var jsonStr = db.Queryable<INSERTTEST>().OrderBy("id").Take(1).ToJson();
                var jsonStr2 = db.Sqlable().From<INSERTTEST>("t").SelectToJson(" top 1 *");
                var jsonStr3 = db.SqlQueryJson("select top 1 * from InsertTest");
            }
        }
    }
}