using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Actions;

namespace Engine.Models
{
    public class GameItem
    {
        public enum ItemCategory
        {
            Miscellaneous,
            Weapon
        }
        //No setters as once item is created these properties should not be changed
        public ItemCategory Category { get; }
        public int ItemTypeID { get; }
        public string  Name { get; }
        public int Price { get; }
        public bool IsUnique { get; }
        public AttackWithWeapon Action { get; set; }


        //bool isUnique is set to a default value of false if not specified in the constructor ie: we only pass in the first 3 parameters
        //setting a default value like this can only be done on the final parameter of constructor
        public GameItem(ItemCategory category, int itemTypeID, string name, int price, 
                        bool isUnique = false, AttackWithWeapon action = null)
        {
            Category = category;
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            Action = action;
        }

        public void PerformAction(LivingEntity actor, LivingEntity target)
        {
            Action?.Execute(actor, target);
        }
        public GameItem Clone()
        {
            return new GameItem(Category, ItemTypeID, Name, Price, 
                                IsUnique, Action);
        }
    }
}
