   M S B A M L   `   `   `  ����G  CInventoryWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:InventoryWpf.ViewModelsInventoryWpf.ViewModels  5   	   *    $InventoryWpf.Views.AddEditItemWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4vm%clr-namespace:InventoryWpf.ViewModels     5   	     � Title$  Add / Edit Item��5   	   $	��350��6!   $	��400��6.    � WindowStartupLocation$ CenterOwner=�6:   ���#F2F2F2 � DataContext 5      4   .InventoryWpf.ViewModels.InventoryItemViewModel  5   
    � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value
 �� RelativeSource��%&  '��       �� 5   
   " ��6    5      P� 5       �@=�HasError$
 True��69   . �5      ��  �@�ToolTip	 5      �� *%#(Validation.Errors)[0].ErrorContent+
 �� *Self+�� 5       � ��
	 �  ��64   �� 5       � ��$	 2q�68   5      5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $��* �6   .+�5&   
   �� $��Name:��6   $
��Bold"�6!   $��Center=�63   $	��0,5q�6N   �� 5'   
   $��1��6   $��5q�6"   ��6-   �� *	Item.Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True���� 5+   
   $��1��6   $��	Category:��6!   $
��Bold"�62   $��Center=�6D   $	��0,5q�6_   �� 5,   
   $��1��6   $��1��6   $��5q�6/   ��6:   �� *Item.Category+$ PropertyChanged=��� 5/   
   $��2��6   $��Stock:��6!   $
��Bold"�6/   $��Center=�6A   $	��0,5q�6\   �� 50   
   -   5        $��2��50      $��1��6   $��5q�6/   ��6j   �� *Item.StockQuantity+$ PropertyChanged=�$
 True��$
 True��.��6�   52      �� 55   
   $��3��6   $��Last Updated:��6!   $
��Bold"�66   $��Center=�6H   $	��0,5q�6c   �� 56   
   $��3��6   $��1��6!   $��5q�61   ��6<   �� *Item.LastUpdated+�� 59   
   $��4��6   $��2��6   $
��Save��62   $��Center=�5;      $	��100��6.   $��10q�6:   ���#2D89EF
�������$
��Bold"�5<   9   ��5:      �� *SaveCommand+5<   9   5=      5>      