using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1_1170919_1132119.Controllers
{
    public class ListSelectionController : Controller
    {
        // GET: ListSelection
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListSelection/Details/5
        public void Details(int id)
        {
            PlayerController nextPagePlayerController = new PlayerController();
            nextPagePlayerController.Index();
        }

        // GET: ListSelection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListSelection/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string listaArtesanal = collection["listaArtesanal"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListSelection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListSelection/Edit/5
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

        // GET: ListSelection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListSelection/Delete/5
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
