using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuessWho.Models
{
    public enum Gender
    {
        male = 0,
        female = 1
    }   

    public class Character : TableEntity
    {
        [Display(Name = "Gender")]
        public int Gender { get; set; }
        [Display(Name = "Bald")]
        public bool Bald { get; set; }
        [Display(Name = "Moustache")]
        public bool Moustache { get; set; }
        [Display(Name = "Beard")]
        public bool Beard { get; set; }
        [Display(Name = "Hair Colour")]
        public string HairColour { get; set; }
        [Display(Name = "Eye Colour")]
        public string EyeColour { get; set; }
        [Display(Name = "Glasses")]
        public bool Glasses { get; set; }
        [Display(Name = "Hat")]
        public bool Hat { get; set; }        
    }
}