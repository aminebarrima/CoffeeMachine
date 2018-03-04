using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Models
{
   public class Badge
    {
       
        public int badgeId { get; set; }
        public string keyBadge { get; set; }
        public virtual ICollection<Commande> commandes { get; set; }
        
    }
}
