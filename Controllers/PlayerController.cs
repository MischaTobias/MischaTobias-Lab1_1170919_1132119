using System;
using System.Collections.Generic;
using CustomGenerics.Structures;
using Lab1_1170919_1132119.Models;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Lab1_1170919_1132119.Helpers;

namespace Lab1_1170919_1132119.Controllers
{
    public class PlayerController : Controller
    {
        public static bool useHandMadeList;
        // GET: Player
        public ActionResult ListElection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListElection(FormCollection collection)
        {
            var useHMList = collection["useHandMadeList"].Split(',')[0];
            if (useHMList.ToLower() == "true")
            {
                useHandMadeList = true;
            }
            else
            {
                useHandMadeList = false;
            }
            return RedirectToAction("PlayersListDisplay");
        }


        public ActionResult PlayersListDisplay()
        {
            //ctrl+r+r
            if (useHandMadeList)
            {
                return View(Storage.Instance.playersHandMadeList);
            }
            else
            {
                return View(Storage.Instance.playersList);
            }
        }

        public ActionResult IndividualCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndividualCreate(FormCollection collection)
        {
            var player = new PlayerModel
            {
                Name = collection["Name"],
                LastName = collection["LastName"],
                Position = collection["Position"],
                Salary = Convert.ToInt32(collection["Salary"]),
                Club = collection["Club"]
            };

            if (useHandMadeList)
            {
                player.Save();
            }
            else
            {
                Storage.Instance.playersList.AddFirst(player);
            }

            return RedirectToAction("PlayersListDisplay");
        }

        public ActionResult FileCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileCreate(FormCollection collection)
        {
            StreamReader streamReader = new StreamReader(collection["path"]);
            var playerArray = (streamReader.ReadToEnd()).Split('\n');//careful with \r

            for (int i = 0; i < playerArray.Length; i++)
            {
                if (playerArray[i][0] == '\n')
                {
                    playerArray[i] = playerArray[i].Substring(1);
                }
            }

            foreach (var playerAttributes in playerArray)
            {
                var playerAttributesArray = playerAttributes.Split(',');
                PlayerModel player = new PlayerModel
                {
                    Name = playerAttributesArray[0],
                    LastName = playerAttributesArray[1],
                    Position = playerAttributesArray[2],
                    Salary = Convert.ToInt32(playerAttributesArray[3]),
                    Club = playerAttributesArray[4]
                };

                if (useHandMadeList)
                {
                    //Enqueue
                }
                else
                {
                    Storage.Instance.playersList.AddFirst(player);
                }
            }
            return RedirectToAction("PlayersListDisplay");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                foreach (var item in Storage.Instance.playersList)
                {
                    if (item.playerId == id)
                    {
                        item.Club = collection["Club"];
                        item.Salary = Convert.ToInt32(collection["Salary"]);
                    }
                }
                return RedirectToAction("PlayersListDisplay");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var playerToRemove = Storage.Instance.playersList.FirstOrDefault(i => i.playerId == id);
                Storage.Instance.playersList.Remove(playerToRemove);
                return RedirectToAction("PlayersListDisplay");
            }
            catch
            {
                return View("PlayersListDisplay");
            }
        }

        public ActionResult SearchBy()
        {
            return View();
        }
    }
}
