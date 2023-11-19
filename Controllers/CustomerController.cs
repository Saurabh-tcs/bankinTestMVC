using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using bankingMvcTestApp.DataContext;
using bankingMvcTestApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace bankingMvcTestApp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.customerObject.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            CustomerClass customerClass = db.customerObject.Find(id);
            if (customerClass == null)
            {
                return NotFound();
            }
            return View(customerClass);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "customerid,customer_name,customer_accounttype,customer_accountbalance,email")] CustomerClass customerClass)
        // #MigrationChages-SaurabhG - Removing Include
        public ActionResult Create([Bind("customerid,customer_name,customer_accounttype,customer_accountbalance,email")] CustomerClass customerClass)
        {
            if (ModelState.IsValid)
            {
                db.customerObject.Add(customerClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerClass);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            CustomerClass customerClass = db.customerObject.Find(id);
            if (customerClass == null)
            {
                return NotFound();
            }
            return View(customerClass);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "customerid,customer_name,customer_accounttype,customer_accountbalance,email")] CustomerClass customerClass)
        // # MigrationChanges- Remove include
        public ActionResult Edit([Bind("customerid,customer_name,customer_accounttype,customer_accountbalance,email")] CustomerClass customerClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerClass);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            CustomerClass customerClass = db.customerObject.Find(id);
            if (customerClass == null)
            {
                return NotFound();
            }
            return View(customerClass);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerClass customerClass = db.customerObject.Find(id);
            db.customerObject.Remove(customerClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
