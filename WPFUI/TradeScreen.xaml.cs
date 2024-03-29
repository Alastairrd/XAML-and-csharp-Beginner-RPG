﻿using Engine.Models;
using Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        //This below is a property which is a gamesession called session, which then wraps the datacontext as that gamesession object
        //allows us to treat the datacontext as a gamesession object
        public GameSession Session => DataContext as GameSession;
        public TradeScreen()
        {
            InitializeComponent();
        }

        //
        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            //Gets the row (item) from trade screen that sent the click to sell, which is determined by the framework element sender.data context
            //converts it to game item
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            //make sure its not null to prevent problems
            if(groupedInventoryItem !=null)
            {
                //our gold property has an event handler that will notify of changes already so need to need to worry
                //methods set up already to handle the addition and removal from inventory in trader and player classes
                Session.CurrentPlayer.ReceiveGold(groupedInventoryItem.Item.Price);
                Session.CurrentTrader.AddItemToInventory(groupedInventoryItem.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);            
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if(groupedInventoryItem != null)
            {
                //Extra check here to make sure player has enough gold to buy item
                if(Session.CurrentPlayer.Gold >= groupedInventoryItem.Item.Price)
                {
                    Session.CurrentPlayer.ReceiveGold(groupedInventoryItem.Item.Price);
                    Session.CurrentTrader.RemoveItemFromInventory(groupedInventoryItem.Item);
                    Session.CurrentPlayer.AddItemToInventory(groupedInventoryItem.Item);
                }
                else
                {
                    MessageBox.Show("You do not have enough gold");
                }               
            }
        }

        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
