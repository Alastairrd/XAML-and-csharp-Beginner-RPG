using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : LivingEntity
    {
        private string _characterClass;
        private int _level;
        private int _experiencePoints;

        public string CharacterClass
        {
            get { return _characterClass; }

            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int Level
        {
            get { return _level; }

            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }

            set 
            { 
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
            Quests = new ObservableCollection<QuestStatus>();
        }
        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach(ItemQuantity item in items)
            {
                if(Inventory.Count(i => i.ItemTypeId == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
