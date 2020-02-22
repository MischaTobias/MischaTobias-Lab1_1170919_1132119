using Lab1_1170919_1132119.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1_1170919_1132119.Models
{
    public class PlayerModel
    {
        public static int id;
        public string Name { get; set; }
        [Required]//Displayname
        public string LastName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Club { get; set; }
        public int playerId { get; set; }

        public PlayerModel()
        {
            id++;
            playerId = id;
        }

        public void Save()
        {
            Storage.Instance.playersList.AddFirst(this);
        }

        public void HandMadeListSave()
        {
            Storage.Instance.playersHandMadeList.Add(this);
        }

        public static Comparison<PlayerModel> FindById = delegate (PlayerModel player1, PlayerModel player2)
        {
            return player1.CompareTo(player2);
        };

        public int CompareTo (object obj)
        {
            var comparer = ((PlayerModel)obj).playerId;
            return comparer < 1 ? 1 : comparer == playerId ? 0 : -1;
        }
    }
}