using Lab1_1170919_1132119.Models;
using CustomGenerics.Structures;

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

        public HandMadeList<PlayerModel> playerList = new HandMadeList<PlayerModel>();
    }
}