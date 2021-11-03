using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemTypeId { get; set; }
        public string  Name { get; set; }
        public int Price { get; set; }
        public bool IsUnique { get; set; }

        //bool isUnique is set to a default value of false if not specified in the constructor ie: we only pass in the first 3 parameters
        //setting a default value like this can only be done on the final parameter of constructor
        public GameItem(int itemTypeId, string name, int price, bool isUnique = false)
        {
            ItemTypeId = itemTypeId;
            Name = name;
            Price = price;
            IsUnique = isUnique;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemTypeId, Name, Price, IsUnique);
        }
    }
}
