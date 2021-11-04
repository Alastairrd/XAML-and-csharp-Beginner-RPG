using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        //No setters as once item is created these properties should not be changed
        public int ItemTypeID { get; }
        public string  Name { get; }
        public int Price { get; }
        public bool IsUnique { get; }

        //bool isUnique is set to a default value of false if not specified in the constructor ie: we only pass in the first 3 parameters
        //setting a default value like this can only be done on the final parameter of constructor
        public GameItem(int itemTypeID, string name, int price, bool isUnique = false)
        {
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
            IsUnique = isUnique;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemTypeID, Name, Price, IsUnique);
        }
    }
}
