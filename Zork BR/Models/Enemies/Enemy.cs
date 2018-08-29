using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Enemies
{
    public abstract class Enemy
    {
        [Key]
        public int Id { get; set; }

        public abstract string Name { get;}
        public abstract int DamageToPlayer { get;}
        public abstract int Hp { get; set; }


        private bool isDead;
        public bool IsDead {
            get { return this.isDead; }
            set {
                if (Hp <= 0)
                {
                    this.isDead = true;
                }
            }
        }
    }
}