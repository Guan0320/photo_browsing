   M S B A M L   `   `   `  ����J  FShowImageRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ShowImageRemake.PagesShowImageRemake.Pages  5      %    ShowImageRemake.Pages.ApplePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ShowImageRemake.Pages     5        N� Title$  	ApplePage��5	      .��5      �  J� 	AllowDrop . 
������  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5   
   �� -   5         ��Name$ ImagePathTextBox��5      $��0q�5   
    �� TextWrapping$
 Wrap=�5   
   $��Center=�5   
   $��50��5      
���   �5      � 5   
   $��1��6    5      �� 5      $��3* �6    6.   �� 5      $��2* �6    6.   .+�5      �� -   5         ��Name$ middleButton��5      5      � 5       $��1��6    5!      �� 5"      $��3* �6$   62   �� 5#      $��* �6$   61   .+�5%      �  � ColumnDefinitions 5&      �� 5'      $��* �6+   67   �� 5(      $��50 �6+   68   �� 5)      $��* �6+   67   .+�5+      �� -   5         ��Name$ stack_panel_right��5-      $��2��5,       �� Orientation$ 
Horizontal=�5.      $
��Left=�5/      �� 50      -   5        $ stack_panel_left��52      $��0��51      $ 
Horizontal=�53      $��Right=�54      55      �� 56      -   5        	 ��Name$	 slider��56      $��1��6)   68   57      59      5:      5;      