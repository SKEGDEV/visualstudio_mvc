using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TEST_C.Models;
using MVC_TEST_C.Models.View_model;

namespace MVC_TEST_C.Controllers
{
    public class mvc_tableController : Controller
    {
        // GET: mvc_table
        public ActionResult Index()
        {
            List<table_view_model> lst;
            using(mvc_testEntity db = new mvc_testEntity())
            {
                 lst = (from d in db.mvc_table
                           select new table_view_model
                           {
                               id = d.id,
                               name_user = d.name_user,
                               email = d.email,
                               birthday = (DateTime)d.birthday
                           }).ToList();
            }
            return View(lst);
        }

        public ActionResult new_user()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult new_user(mvc_table_add model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (mvc_testEntity db = new mvc_testEntity())
                    {
                        var table_array = new mvc_table();
                        table_array.id = model.id;
                        table_array.name_user = model.name_user;
                        table_array.email = model.email;
                        table_array.birthday = model.birthday;

                        db.mvc_table.Add(table_array);
                        db.SaveChanges();
                    }
                    return Redirect("/mvc_table");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}