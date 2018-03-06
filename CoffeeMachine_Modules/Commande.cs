using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Models
{
  public  class Commande
    {
        public int commandeId { get; set; }
        public bool withMug { get; set; }
        public DateTime dateCommande { get; set; }
        public int badgeId { get; set; }
        public int boissonId { get; set; }
        public bool memoeryFlage { get; set; }
        public int sucre { get; set; }
        public virtual  Boisson boisson { get; set; }
        public virtual Badge badge { get; set; }
    }
}
