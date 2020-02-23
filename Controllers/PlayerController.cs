using System;
using System.Diagnostics;
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
        public static Stopwatch aTimer = new Stopwatch();
        static TimeSpan ts;
        public static string elapsedTime;

        public static bool useHandMadeList;
        public static List<PlayerModel> playerListCopy = new List<PlayerModel>();
        
        public ActionResult Time()
        {
            string time = "<script>alert('El tiempo de ejecucion fue: " + elapsedTime + "');</script>";
            TempData["msg"] = time;
            return View();
        }
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
            aTimer.Restart();
            aTimer.Start();
            var player = new PlayerModel
            {
                Name = collection["Name"],
                LastName = collection["LastName"],
                Position = collection["Position"],
                Salary = Convert.ToInt32(collection["Salary"]),
                Club = collection["Club"]
            };

            AddingFunc AddingFunction;

            if (useHandMadeList)
            {
                AddingFunction = new AddingFunc(HandMadeListAdd);
            }
            else
            {
                AddingFunction = new AddingFunc(ListAdd);
            }
            AddingFunction(player);
            aTimer.Stop();
            ts = aTimer.Elapsed;
            elapsedTime = String.Format("{0} h, {1} min, {2} s, {3} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.TotalMilliseconds * 10000);
            return RedirectToAction("Time");
        }

        public ActionResult FileCreate()
        {
            return View();
        }

        public delegate void AddingFunc(PlayerModel player);

        public void ListAdd(PlayerModel player)
        {
            player.Save();
        }

        public void HandMadeListAdd(PlayerModel player)
        {
            Storage.Instance.playersHandMadeList.Add(player);
        }

        [HttpPost]
        public ActionResult FileCreate(FormCollection collection)
        {
            aTimer.Restart();
            aTimer.Start();
            StreamReader streamReader = new StreamReader(collection["path"]);
            var playerArray = (streamReader.ReadToEnd()).Split('\r');//careful with \r

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

                AddingFunc AddingFunction;

                if (useHandMadeList)
                {
                    AddingFunction = new AddingFunc(HandMadeListAdd);
                }
                else
                {
                    AddingFunction = new AddingFunc(ListAdd);
                }
                AddingFunction(player);
            }
            aTimer.Stop();
            ts = aTimer.Elapsed;
            elapsedTime = String.Format("{0} h, {1} min, {2} s, {3} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.TotalMilliseconds * 10000);
            return RedirectToAction("Time");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            aTimer.Restart();
            aTimer.Start();
            EditFunc EditFunction;
            if (useHandMadeList)
            {
                EditFunction = new EditFunc(HandmadeListEdit);
            }
            else
            {
                EditFunction = new EditFunc(ListEdit);
            }
            EditFunction(id, collection);
            aTimer.Stop();
            ts = aTimer.Elapsed;
            elapsedTime = String.Format("{0} h, {1} min, {2} s, {3} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.TotalMilliseconds * 10000);
            return RedirectToAction("Time");
        }

        public delegate void EditFunc(int id, FormCollection collection);

        public void ListEdit(int id, FormCollection collection)
        {
            foreach (var item in Storage.Instance.playersList)
            {
                if (item.playerId == id)
                {
                    item.Club = collection["Club"];
                    item.Salary = Convert.ToInt32(collection["Salary"]);
                }
            }
        }

        public void HandmadeListEdit(int id, FormCollection collection)
        {
            //editing handmade list
        }

        public delegate void DeleteFunc(int id);

        public ActionResult Delete(int id)
        {
            aTimer.Restart();
            aTimer.Start();
            var DeleteFunction = new DeleteFunc(ListDelete);
            if (useHandMadeList)
            {
                DeleteFunction = new DeleteFunc(HandMadeListDelete);
            }
            DeleteFunction(id);
            aTimer.Stop();
            ts = aTimer.Elapsed;
            elapsedTime = String.Format("{0} h, {1} min, {2} s, {3} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.TotalMilliseconds * 10000);
            return RedirectToAction("Time");
        }

        public void ListDelete(int id)
        {
            var playerToRemove = Storage.Instance.playersList.FirstOrDefault(i => i.playerId == id);
            Storage.Instance.playersList.Remove(playerToRemove);
        }

        public void HandMadeListDelete(int id)
        {
            //delete for handmade list
        }

        public ActionResult SearchBy()
        {
            return View();
        }

        public delegate void SearchFunc(string searchingParameter, string searchingValue, string range);

        [HttpPost]
        public ActionResult SearchBy(FormCollection collection)
        {
            aTimer.Restart();
            aTimer.Start();
            try
            {
                var searchingParameter = collection["SearchingParameter"];
                var searchingValue = collection["SearchedValue"];
                var range = collection["Range"];
                SearchFunc searchFunction;
                if (useHandMadeList)
                {
                    searchFunction = new SearchFunc(HandMadeListSearch);
                }
                else
                {
                    searchFunction = new SearchFunc(ListSearch);
                }
                searchFunction(searchingParameter, searchingValue, range);
            }
            catch 
            {

            }
            aTimer.Stop();
            ts = aTimer.Elapsed;
            elapsedTime = String.Format("{0} h, {1} min, {2} s, {3} ms", ts.Hours, ts.Minutes, ts.Seconds, ts.TotalMilliseconds * 10000);

            string time = "<script>alert('El tiempo de ejecucion fue: " + elapsedTime + "');</script>";
            TempData["msg"] = time;
            return View("ShowCopyList",playerListCopy);
        }

        public ActionResult ShowCopyList()
        {
            return View(playerListCopy);
        }

        public void HandMadeListSearch(string searchingParameter, string searchingValue, string range)
        {
            if (searchingParameter.ToLower() != "salary")
            {
                switch (searchingParameter.ToLower())
                {
                    case "name":
                        playerListCopy = Storage.HandMadeListSearch(searchingValue, range, Storage.CompareByName);
                        break;
                    case "lastname":
                        playerListCopy = Storage.HandMadeListSearch(searchingValue, range, Storage.CompareByLastName);
                        break;
                    case "position":
                        playerListCopy = Storage.HandMadeListSearch(searchingValue, range, Storage.CompareByPosition);
                        break;
                    case "club":
                        playerListCopy = Storage.HandMadeListSearch(searchingValue, range, Storage.CompareByClub);
                        break;
                }
            }
            else
            {
                playerListCopy = Storage.HandMadeListSearchSalary(int.Parse(searchingValue), range, Storage.CompareBySalary);
            }
        }

        public void ListSearch(string searchingParameter, string searchingValue, string range)
        {
            if (searchingParameter.ToLower() != "salary")
            {
                switch (searchingParameter.ToLower())
                {
                    case "name":
                        playerListCopy = Storage.ListSearch(searchingValue, Storage.CompareByName);
                        break;
                    case "lastname":
                        playerListCopy = Storage.ListSearch(searchingValue, Storage.CompareByLastName);
                        break;
                    case "position":
                        playerListCopy = Storage.ListSearch(searchingValue, Storage.CompareByPosition);
                        break;
                    case "club":
                        playerListCopy = Storage.ListSearch(searchingValue, Storage.CompareByClub);
                        break;
                }
            }
            else
            {
                playerListCopy = Storage.ListSearch(int.Parse(searchingValue), Storage.CompareBySalary, range);
            }
        }
    }
}
