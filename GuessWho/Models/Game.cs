using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessWho.Models
{
    public class Game : TableEntity
    {        
        public string Status { get; set; }
        public string Character { get; set; }
        public int Turns { get; set; }
    }
}