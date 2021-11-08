using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Actions
{
    public class AttackWithWeapon : IAction
    {
        private readonly GameItem _weapon;
        private readonly int _maximumDamage;
        private readonly int _minimumDamage;

        public event EventHandler<string> OnActionPerformed;

        public AttackWithWeapon(GameItem weapon, int minimumDamage, int maximumDamage)
        {
            if(weapon.Category != GameItem.ItemCategory.Weapon)
            {
                throw new ArgumentException($"{weapon.Name} is not a weapon.");
            }

            if(minimumDamage < 0)
            {
                throw new ArgumentException("minimumDamage must be 0 or larger.");
            }

            if(maximumDamage < minimumDamage)
            {
                throw new ArgumentException("maximumDamage must be >= minimumDamage.");
            }

            _weapon = weapon;
            _minimumDamage = minimumDamage;
            _maximumDamage = maximumDamage;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            int damage = RandomNumberGenerator.NumberBetween(_minimumDamage, _maximumDamage);

            //if the actor is the player, actorName will equal "You", otherwise it will be "The...(monster or w/e)"
            string actorName = (actor is Player) ? "You" : $"The {actor.Name.ToLower()}";
            //same as above, targetName will be "you" if it is a player, otherwise it will be "The (monster etc)"
            string targetName = (target is Player) ? "you" : $"The {target.Name.ToLower()}";

            if (damage == 0)
            {
                ReportResult($"{actorName} missed {targetName}.");
            }
            else
            {
                //if damage is greater than 1, will add an 's' to 'point' to become plural
                ReportResult($"{actorName} hit {targetName} for {damage} point{(damage > 1 ? "s" : "")}.");
                target.TakeDamage(damage);
            }
        }

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
