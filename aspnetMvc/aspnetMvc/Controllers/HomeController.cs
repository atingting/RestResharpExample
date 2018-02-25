using aspnetMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
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

        [HttpPost]
        public ActionResult ResharpPostRequest() {
            byte[] bytes = new byte[HttpContext.Request.InputStream.Length];
            HttpContext.Request.InputStream.Read(bytes,0,bytes.Length);
            string req = System.Text.Encoding.Default.GetString(bytes);
            req = HttpContext.Server.UrlDecode(req);
            var person = JsonConvert.DeserializeObject<Person>(req);
            var persons = new List<Person> { new Person { Name = "Postztt", Age = 2, WifeName = "hl" }, new Person { Name = "Posthl", Age = 25, WifeName = "ztt" } };
            persons.Add(person);
            return  Json(persons);
        }
        [HttpGet]
        public ActionResult ResharpGetRequest()
        { 
            var persons = new Person { Name = "Getztt", Age = 2, WifeName = "hl" };
            return Json("rfsc", JsonRequestBehavior.AllowGet);
        }
        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
