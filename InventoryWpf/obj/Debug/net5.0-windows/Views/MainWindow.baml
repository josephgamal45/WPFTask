   M S B A M L   `   `   `  ����G  CInventoryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:InventoryWpf.ViewModelsInventoryWpf.ViewModels  5   	   #    InventoryWpf.Views.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4vm%clr-namespace:InventoryWpf.ViewModels     5   	     � Title$  Inventory Manager��5   	   $	��700��6#   $
��1200��60    � WindowStartupLocation$ CenterScreen=�6=    � DataContext 5      +   %InventoryWpf.ViewModels.MainViewModel  5   
   .��5
      ]� 
�������$��10q�6(   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��0,0,0,10q�6C   $
��1116��6U   .+�5      �� $��24��6   .��6    Search Text:6.   �� 5      -   5        $
��10,5q�5      $	��479��6%   $��27��6R   �� 5      $��Add Item��6   $��5q�6(   $
��10,5q�63   $	��100��6B   ��6N   �� *OpenAddItemCommand+�� 5      $��	Edit Item��6   $��5q�6)   $
��10,5q�64   $	��100��6C   ��6O   �� *OpenEditItemCommand+�� 5      $��View Details��6   $
��10,5q�6,   $	��120��6;   ��6G   �� *OpenDetailsCommand+5      �� 5   
   $ Vertical=�6   $	��Top=�6,   $��0,0,0,10q�6A   $��Right=�6S   5      &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5      $��0q�5      $��14(�5         	RowHeight$ 30Q�5         GridLinesVisibility$ 
Horizontal=�5      	   HeadersVisibility$	 Column=�5       ��5      �� *Items+
 �� SelectedItem
 5      �� *SelectedItem+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5#      $ Category��6%   $ * 6T    67   �� *
Category+6T     5$      $ Stock��6%   $
 Auto 6V    64   �� *StockQuantity+6V     5%      $ Last Updated��6%   $	 200 6[    6;   �� *LastUpdated+6[   5'      5(      5)      