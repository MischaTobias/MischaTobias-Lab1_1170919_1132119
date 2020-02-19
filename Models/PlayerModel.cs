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
        public int Id { get; set; }

        public PlayerModel()
        {
            id++;
            Id = id;
        }

        public void Save()
        {
            try
            {
                Storage.Instance.playersList.Add(this);
            }
            catch
            {

            }
        }

        public static Comparison<PlayerModel> FindById = delegate (PlayerModel player1, PlayerModel player2)
        {
            return player1.CompareTo(player2);
        };

        public int CompareTo (object obj)
        {
            var comparer = ((PlayerModel)obj).Id;
            return comparer < 1 ? 1 : comparer == Id ? 0 : -1;
        }
    }
}