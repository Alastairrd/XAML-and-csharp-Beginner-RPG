   M S B A M L   `   `   `  ����A  =Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE/clr-namespace:Engine.ViewModels;assembly=EngineEngine.ViewModels  5   	   	 WPFUI   WPFUI.TradeScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   F
viewModels/clr-namespace:Engine.ViewModels;assembly=Engine     5   	     � WindowStartupLocation$  CenterOwner=�5
   	   $��11(�5   	    � Title$ TradeScreen��5   	   $	��480��6   $	��640��6*   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��2��5      $��Center=�5       ��5!      �� *CurrentTrader.Name+�� 5#   
   $��1��6   $��0��6   $��Center=�5$      $��Your Inventory��5%      �� 5&   
   $��1��6   $��1��6   $��Center=�5'      $��Trader's Inventory��5(      &   System.Windows.Controls.DataGrid  5-   
   $��2��6   $��0��6    $��10q�5.         AutoGenerateColumns$ False��50         HeadersVisibility$ Column=�51         CanUserAddRows$ False��52         CanUserDeleteRows$ False��53      "   VerticalScrollBarVisibility$
 Auto=�54      ��5/      �� * CurrentPlayer.GroupedInventory+	   Columns	 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Description��6%      
IsReadOnly$
 True��59   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5:   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5;   %   �� *	Item.Name+  5<      $	
 Qty��6%   $
 True��5=   %   $
 Auto 5>   %    5?   %   �� *
Quantity+  5@      $
 Price��6%   $
 True��5A   %   $
 Auto 5B   %    5C   %   �� *
Item.Price+4  .System.Windows.Controls.DataGridTemplateColumn  5F         MinWidth$ 75Q�6)      CellTemplate 5G      �� 5H      .R�5I      �� -   5        $��55��5J   %   $��Sell 1��5K   %   5L      5N      5Q        5T   
   $��2��6   $��1��6    $��10q�5U      $ False��5W      $ Column=�5X      $ False��5Y      $ False��5Z      $
 Auto=�5[      ��5V      �� * CurrentTrader.GroupedInventory+	 5]        5^      $
 Description��6%   $
 True��5_   %   $ * 5`   %    5a   %   �� *	Item.Name+  5b      $	
 Qty��6%   $
 True��5c   %   $
 Auto 5d   %    5e   %   �� *
Quantity+  5f      $
 Price��6%   $
 True��5g   %   $
 Auto 5h   %    5i   %   �� *
Item.Price+  5j      $ 75Q�6)    5k      �� 5l      .R�5m      �� -   5        $��55��5n   %   $��Buy 1��5o   %   5p      5r      5u      �� 5x   
   -   5        $��3��5x      $��1��6   $��Right=�5y      $��75��5z      $��Close��5{      5|      5}      5~      