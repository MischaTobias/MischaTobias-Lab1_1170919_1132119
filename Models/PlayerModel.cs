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
        //public int Number { get; set; }
        public string Name { get; set; }
        [Required]//Displayname
        public string LastName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Club { get; set; }

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
    }
}