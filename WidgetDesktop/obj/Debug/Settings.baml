   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   H DWidgetDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WidgetDesktop.PropertiesWidgetDesktop.Properties 5   	      WidgetDesktop.Settings   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jext:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   =
properties&clr-namespace:WidgetDesktop.Properties     5   	     � Title$  Settings��5   	   $	��500��6   $	��325��6'    � 
ResizeMode$ NoResize=�63      AlternateBackgroundBrush#���   5   	     ControlTextBrush#���  5   	   .��5	      �  � RowDefinitions 5
   
   �� 5      $��25 �6   �� 5      $	��125 �6   �� 5      $��25 �6   �� 5      $	��100 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��Drives To Monitor��6   $��0��6-   $��0��6=   $��Bottom=�6J   $��Center=�6e   6�   $   Xceed.Wpf.Toolkit.CheckListBox  5   
   -   5          Name$ clb_HDDS��5      +   %Xceed.Wpf.Toolkit.Primitives.Selector   	Delimiter$ ,��6-   $��0��6;   $��1��6K   $	��100��6X   $	��100��6d   $
��25,0q�6q   ��6�   Z� �� 5   
   $��Drive Options��6   $��1��6)   $��0��69   $��Bottom=�6F   $��Center=�6a   6�   �� 5   
   $��1��6   $��1��6    
������ $��0q�6v   ��6I   Z� ��6`   Z� .��5       �� -   5         ��Name$ DO_StackPanel��5       .+�5!      �� -   5         ��Name$ LDS_Warn��5!       d� 	IsChecked 6-   �� ' !WidgetDesktop.Properties.Settings	   Default
 �� Source#
 Z	  �� Path$ LDS_Warn���5"      �� 5#      $"��Low Disk Space Warning < 10%��6+   6X   5%      �� 5&      -   5        $ HDU_Warn��5&       6-   �� #
 Z	 $ HDU_Warn���5'      �� 5(      $��High Disk Usage Warning��6+   6O   5*      �� 5+      -   5        $ DOS_Act��5+       6,   �� #
 Z	 $ DOS_Act���5,      �� 5-      $��Display Widget On Start��6+   6O   5/      �� 50      -   5        $ SID_Act��50       6,   �� #
 Z	 $ AOT_Act���51      �� 52      $��Always On Top��6+   6E   54      �� 55      $��Display Orientation��6   $��Center=�67   #���  6T   $��0,5,0,0q�6�   � 56       57      �� 58      $	��50* �6+   �� 59      $	��50* �6+   .+�5;      	� -   5         	�Name$ rad_HDD_OrientationH��5;   "   $��0��6@   $��Center=�6P   ��5<      �� 5=      $��
Horizontal��6/   5?      	� 5@      -   5        $ rad_HDD_OrientationV��5@   "   $��1��6@   $��Center=�6P   ��5A      �� 5B      $��Vertical��6/   5D      5E      5F      5H      �� 5J   
   $��Memory Options��6   $��0��6*   $��2��6:   $��Center=�6G   $��2��6d   $��Bottom=�6x   6�   �� 5L   
   $��3��6   $��0��6    $��2��60   $��0q�6q   ��6D   Z� ��6Z   Z� .��5M      �� -	   5        $ MemOpts��5M      $��	4,10,5,10q�6*   .+�5N      �� -
   5        $ chk_LMW��5N       6C   �� #
 Z	 $ WarnMem���5O      �� 5P      $��Low Memory Warning��6+   5R      $   Xceed.Wpf.Toolkit.DoubleUpDown  5S      -   5          Name$ 
dud_MemVal��5T      �   �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ P��5U         	Increment$
 .001X�6&   �   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 .95X�5W         Minimum$	 .05X�6#      UpdateValueOnEnterKey . {�.     Value 5V      �� #
 Z	 $ MemPercentage�5Y      5Z      5[      �� 5]   
   $&�� Display Options (Color Settings)��6   $��0��6<   $��4��6L   $��Center=�6Y   $��Center=�6v   $��2��6�   6�   �� 5_   
   $��5��6   $��0��6    $��0q�6]   ��60   Z� ��6G   Z� ��5`      �� 5a       �� Color$ 	#2CD3D3D3��6"    �� Opacity$ 0Q�64   .��5c      �� -   5        $ Color_Stack��5c      .+�5d      	� -   5        $ ColorPick_Hard_Drives��5d      ��5e      �� 5f      $��
Hard Drive��6$   $
��Wrap=�66   5h      	� 5i      -   5        $ ColorPick_Memory��5i      ��5j      �� 5k      $��Memory��6$   $
��Wrap=�62   5m      5n      5o      �� 5q   
   $��5��6   $��1��6"   $��Center=�63   $��-5,0,5,0q�6N   .+�5r      �� -   5         ��Name$ ColorPick_ValueType1��5r      $��Free Space Color��64   6N   #   Xceed.Wpf.Toolkit.ColorPicker  5s      6    �� 5t      -   5        $ ColorPick_ValueType2��5t      $��Used Space Color��64   6N     5u      ���	#FFDE060667   5v      �� 5w   
   -   5         ��Name$ saveSettings��5w      $
��Save��6'   $��6��66   $��2��6C   $	��100��6W   $��25��6c     Button.Static.Background#��[ 6�   5x      5y      