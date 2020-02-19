using System;
using System.Collections.Generic;
using CustomGenerics.Structures;
using Lab1_1170919_1132119.Models;
using System.Web;
using System.Linq;
using System.Web.Mvc;

namespace Lab1_1170919_1132119.Controllers
{
    public class PlayerController : Controller
    {
        public static List<PlayerModel> playersList = new List<PlayerModel>();
        // GET: Player
        public ActionResult ListElection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListElection(FormCollection collection)
        {
            var useHandmadeList = collection["useHandMadeList"].Split(',')[0];
            if (useHandmadeList.ToLower() == "true")
            {
                //usar handmade list
            }
            else
            {
                //usar lista c#
            }
            return RedirectToAction("PlayersListDisplay");
        }

        // GET: Player/Create


        public ActionResult PlayersListDisplay()
        {
            var Pablo = new PlayerModel()
            {
                Name = "Pablo",
                Salary = 1645
            }; var Pedro = new PlayerModel()
            {
                Name = "Pedro",
                Salary = 1645
            }; var Manuel = new PlayerModel()
            {
                Name = "Manuel",
                Salary = 1645
            }; var Gerardo = new PlayerModel()
            {
                Name = "Gerardo",
                Salary = 1645
            }; var asdasd = new PlayerModel()
            {
                Name = "asdasd",
                Salary = 1645
            };
            //ctrl+r+r
            playersList.Add(Pablo);
            playersList.Add(Pedro);
            playersList.Add(Gerardo);
            playersList.Add(asdasd);
            return View(playersList);
        }

        // POST: Player/Create
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

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Player/Edit/5
       

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Player/Delete/5
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
