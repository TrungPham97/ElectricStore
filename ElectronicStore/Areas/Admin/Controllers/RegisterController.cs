﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Areas.Admin.Models;
using Model.DAO;

namespace ElectronicStore.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Register/Create
        public ActionResult Create()
        {
            TMDT db = new TMDT();
            return View();
        }

        // POST: Admin/Register/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
