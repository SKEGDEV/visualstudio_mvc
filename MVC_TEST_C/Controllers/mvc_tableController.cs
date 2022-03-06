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
        /*
         * View characters in a table using method get
         */
        public ActionResult Index()
        {
            List<table_view_model> lst;
            using (mvc_testEntity db = new mvc_testEntity())
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
        /*
         * finishied view characters
         * */

        /*
         *Add new with c# using method get and post 
         */

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*
         * Finishied the add new
         * */

        /*
         *on here i have the edit a character with methods get and post 
         * */
        public ActionResult Edit(int id) {
            mvc_table_add model = new mvc_table_add();
            using (mvc_testEntity db = new mvc_testEntity()) {
                var table_result = db.mvc_table.Find(id);
                model.id = table_result.id;
                model.name_user = table_result.name_user;
                model.email = table_result.email;
                model.birthday = (DateTime)table_result.birthday;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(mvc_table_add model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (mvc_testEntity db = new mvc_testEntity())
                    {
                        var table_result = db.mvc_table.Find(model.id);
                        table_result.name_user = model.name_user;
                        table_result.email = model.email;
                        table_result.birthday = model.birthday;
                        db.Entry(table_result).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return Redirect("/mvc_table");
                    }
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
         *finishied edit character
         * */

        /*
         *delete a character
         */
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (mvc_testEntity db = new mvc_testEntity())
            {
                var table_result = db.mvc_table.Find(id);
                db.mvc_table.Remove(table_result);
                db.SaveChanges();
            }
            return Redirect("/mvc_table");
        }
        /*
         *finishied delete
         */
        
    }
}
