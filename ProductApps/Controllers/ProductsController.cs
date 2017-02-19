using ProductApps.Models;
using ProductsApps.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductApps.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsContext db = new ProductsContext();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Products products = db.Products.Find(id);
            if (products == null)
                return HttpNotFound();
            return View(products);
        }

        // GET: Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Products products)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    db.Products.Add(products);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(products);
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Products products = db.Products.Find(id);
            if (products == null)
                return HttpNotFound();
            return View(products);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Products products)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(products).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges(); 
                    return RedirectToAction("Index");
                }
                return View(products);
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Products products = db.Products.Find(id);
            if (products == null)
                return HttpNotFound();
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Products prod)
        {
            try
            {
                Products products = new Products();
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    products = db.Products.Find(id);
                    if (products == null)
                        return HttpNotFound();
                    db.Products.Remove(products);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(products);
            }
            catch
            {
                return View();
            }
        }
    }
}
