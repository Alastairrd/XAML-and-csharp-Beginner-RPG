using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Actions
{
    public class Heal : IAction
    {
        private readonly GameItem _item;
        private readonly int _hitPointsToHeal;

        public event EventHandler<string> OnActionPerformed;

        public Heal(GameItem item, int hitPointsToHeal)
        {
            if(item.Category != GameItem.ItemCategory.Consumable)
            {
                throw new ArgumentException($"{item.Name} is not a consumable");
            }

            _item = item;
            _hitPointsToHeal = hitPointsToHeal;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            //if the actor is the player, actorName will equal "You", otherwise it will be "The...(monster or w/e)"
            string actorName = (actor is Player) ? "You" : $"The {actor.Name.ToLower()}";
            //same as above, targetName will be "you" if it is a player, otherwise it will be "The (monster etc)"
            string targetName = (target is Player) ? "yourself" : $"The {target.Name.ToLower()}";

            ReportResult($"{actorName} heal {targetName} for {_hitPointsToHeal} point{(_hitPointsToHeal > 1 ? "s" : "")}.");
            target.Heal(_hitPointsToHeal);
        }

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
