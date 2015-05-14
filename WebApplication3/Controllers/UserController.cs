﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Register()
        {
            return View();
        } 
        [HttpPost ]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc=new MyDatabaseEntities())
                {
                    dc.Users.Add(u);
                    dc.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "succsfully reg done";
                }
             

            }
            return View(u);
        }
	}
}