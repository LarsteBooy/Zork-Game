using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Zork_BR.Models
{
    public class Player
    {
        public string name;
        public int currentHealth;
        public int maxHealth;
        public List<Item> inventory = new List<Item>();

    }
}