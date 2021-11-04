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
        public int ExperiencePoints
        {
            get { return _experiencePoints; }

            private set 
            { 
                _experiencePoints = value;

                OnPropertyChanged(nameof(ExperiencePoints));

                //could potentially keep this code in setter as it it only called here
                //however arguably better to call a function with a descriptive name and keep the setter clean
                SetLevelAndMaximumHitPoints();
            }
        }
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player(string name, string characterClass, int experiencePoints,
                     int maximumHitPoints, int currentHitPoints, int gold) :
           base(name, maximumHitPoints, currentHitPoints, gold)
        {
            CharacterClass = characterClass;
            ExperiencePoints = experiencePoints;

            Quests = new ObservableCollection<QuestStatus>();
        }

        public event EventHandler OnLeveledUp;

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach(ItemQuantity item in items)
            {
                if(Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        private void SetLevelAndMaximumHitPoints()
        {
            int originalLevel = Level;

            Level = (ExperiencePoints / 100) + 1;

            if (Level != originalLevel)
            {
                MaximumHitPoints = Level * 10;

                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
    }
}
