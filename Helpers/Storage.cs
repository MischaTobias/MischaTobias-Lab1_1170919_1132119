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

        public HandMadeList<PlayerModel> playersHandMadeList = new HandMadeList<PlayerModel>();
        public LinkedList<PlayerModel> playersList = new LinkedList<PlayerModel>();

        public delegate bool DelString(PlayerModel value1, PlayerModel value2);
        public delegate int DelInt(PlayerModel value1, PlayerModel value2);

        public static bool CompareByName(PlayerModel value1, PlayerModel value2)
        {
            if (value1.Name == value2.Name)
            {
                return true;
            }
            return false;
        }

        public static bool CompareByLastName(PlayerModel value1, PlayerModel value2)
        {
            if (value1.LastName == value2.LastName)
            {
                return true;
            }
            return false;
        }

        public static bool CompareByPosition(PlayerModel value1, PlayerModel value2)
        {
            if (value1.Position == value2.Position)
            {
                return true;
            }
            return false;
        }

        public static bool CompareByClub(PlayerModel value1, PlayerModel value2)
        {
            if (value1.Club == value2.Club)
            {
                return true;
            }
            return false;
        }

        public static int CompareBySalary(PlayerModel value1, PlayerModel value2)
        {
            if (value1.Salary > value2.Salary)
            {
                return 1;
            }
            else if (value1.Salary == value2.Salary)
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
    }
}