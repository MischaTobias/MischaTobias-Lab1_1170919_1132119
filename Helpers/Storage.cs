using Lab1_1170919_1132119.Models;
using CustomGenerics.Structures;
using System.Collections.Generic;

namespace Lab1_1170919_1132119.Helpers
{
    public class Storage
    {
        public static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public static HandMadeList<PlayerModel> playersHandMadeList = new HandMadeList<PlayerModel>();
        public LinkedList<PlayerModel> playersList = new LinkedList<PlayerModel>();

        public delegate bool DelString(PlayerModel value1, string value2);
        public delegate int DelInt(PlayerModel value1, int value2);

        public static bool CompareByName(PlayerModel value1, string value2)
        {
            if (value1.Name == value2)
            {
                return true;
            }
            return false;
        }

        public static bool CompareByLastName(PlayerModel value1, string value2)
        {
            if (value1.LastName == value2)
            {
                return true;
            }
            return false;
        }

        public static bool CompareByPosition(PlayerModel value1, string value2)
        {
            if (value1.Position == value2)
            {
                return true;
            }
            return false;
        }

        public static bool CompareByClub(PlayerModel value1, string value2)
        {
            if (value1.Club == value2)
            {
                return true;
            }
            return false;
        }

        public static int CompareBySalary(PlayerModel value1, int value2)
        {
            if (value1.Salary > value2)
            {
                return 1;
            }
            else if (value1.Salary == value2)
            {
                return 0;
            }
            return -1;
        }

        public static List<PlayerModel> HandMadeListSearch(string searchingValue, string range, DelString delegateString)
        {
            return new List<PlayerModel>();
        }

        public static List<PlayerModel> HandMadeListSearchSalary(string searchingValue, string range, DelInt delInt)
        {
            return new List<PlayerModel>();
        }

        public static List<PlayerModel> ListSearch(string searchingValue, DelString delegateString)
        {
            List<PlayerModel> newList = new List<PlayerModel>();
            foreach (var item in Storage.Instance.playersList)
            {
                if (delegateString(item, searchingValue))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        public static List<PlayerModel> ListSearch(int searchingValue, DelInt delegateInt, string range)
        {
            List<PlayerModel> newList = new List<PlayerModel>();
            foreach (var item in Storage.Instance.playersList)
            {
                switch (range)
                {
                    case "menor":
                        if (delegateInt(item, searchingValue) < 0)
                        {
                            newList.Add(item);
                        }
                        break;
                    case "igual":
                        if (delegateInt(item, searchingValue) == 0)
                        {
                            newList.Add(item);
                        }
                        break;
                    case "mayor":
                        if (delegateInt(item, searchingValue) > 0)
                        {
                            newList.Add(item);
                        }
                        break;
                }
            }
            return newList;
        }
    }
}