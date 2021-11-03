using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    //abstract class so ut cannot be instantiated, only used as a base class for our living entities, 
    //inherits from basenotification class so that we can still notify about property changes
    public abstract class LivingEntity : BaseNotificationClass
    {
        private string _name;
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _gold;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }

        public int MaximumHitPoints
        {
            get { return _maximumHitPoints; }
            set
            {
                _maximumHitPoints = value;
                OnPropertyChanged(nameof(MaximumHitPoints));
            }
        }

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public ObservableCollection<GameItem> Inventory { get; set; }
        public ObservableCollection<GroupedInventoryItem> GroupedInventory { get; set; }
        public List<GameItem> Weapons =>
            Inventory.Where(i => i is Weapon).ToList();

        //protected constructor can only be seen and used by child classes, further protecting it from being used
        protected LivingEntity()
        {
            Inventory = new ObservableCollection<GameItem>();
            GroupedInventory = new ObservableCollection<GroupedInventoryItem>();
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            //if item is unique, we add it to grouped inventory with quantity of 1
            if (item.IsUnique)
            {
                GroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            //if not unique
            else
            {
                //first check to see if it already exists in inventory
                if (!GroupedInventory.Any(gi => gi.Item.ItemTypeId == item.ItemTypeId))
                {
                    //if not, add it as groupedinventory item with quantity of 0, as we will increase quantity anyway always below
                    GroupedInventory.Add(new GroupedInventoryItem(item, 0));
                }

                GroupedInventory.First(gi => gi.Item.ItemTypeId == item.ItemTypeId).Quantity++;
            }

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);

            //gets first item rom groupedinventory where the item matches what we've passed in
            GroupedInventoryItem groupedInventoryItemToRemove =
                GroupedInventory.FirstOrDefault(gi => gi.Item == item);

            //check we actually got something, should not be null but safety check
            if(groupedInventoryItemToRemove != null)
            {
                //if item's quantity is 1, just remove it
                if(groupedInventoryItemToRemove.Quantity == 1)
                {
                    GroupedInventory.Remove(groupedInventoryItemToRemove);
                }
                //if quantity is not 1, just lower quantity by 1
                else
                {
                    groupedInventoryItemToRemove.Quantity--;
                }
            }

            OnPropertyChanged(nameof(Weapons));
        }
    }
}