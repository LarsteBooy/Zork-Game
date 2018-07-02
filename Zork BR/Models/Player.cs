﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Items;

namespace Zork_BR.Models
{
    public class Player
    {
        private string PlayerName { get; set; }
        private int CurrentHealth { get; set; }
        private int MaxHealth { get; set; }
        private List<Item> Inventory { get; set; }
        private Weapon SelectedWeapon { get; set; }



    }
}