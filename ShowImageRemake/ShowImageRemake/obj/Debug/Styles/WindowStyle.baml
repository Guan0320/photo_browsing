   M S B A M L   `   `   `  ����J  FShowImageRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ShowImageRemake.WindowsShowImageRemake.Windows  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TitleBarButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name J� Opacity ��Name J� SnapsToDevicePixels	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName  RestoreWhite � UseLayoutRounding  
CloseWhite  MaximizeWhite  MinimizeWhite  WindowStyle*    $ShowImageRemake.Windows.CustomWindow'  !System.Windows.Shell.WindowChrome   CornerRadius   GlassFrameThickness   UseAeroCaptionButtons   NonClientFrameEdges&   System.Windows.Media.TextOptions � RowDefinitions � ColumnDefinitions
 � Tag   IsHitTestVisibleInChrome ��Name �� Orientation ��Name � ToolTip#  System.Windows.SystemCommands   MinimizeWindowCommand �� Source   RestoreWindowCommand   MaximizeWindowCommand   CloseWindowCommand-  'System.Windows.Input.KeyboardNavigation    	IsTabStop!   TabNavigation�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1windows%clr-namespace:ShowImageRemake.Windows  5      %�  &	        &	 /    &	 �    &	 �    &	 �    &	 �    7  7   7  7   7  7   7  7   �� 5      "  ��5      .�5   
   ��  � |� .  5	      �� 5
   
    � �� �	#66FFFFFF6'   �� 5   
    � ��$ 36��5      �� 5   
    � ��$ Center=�5      �� 5   
    � ��$ Center=�5      �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � $ 
LayoutRoot��6   
������ .+�5      �� $ ButtonBackground��6$   #��z��5   $   $ 0Q�5   $   �� 5      $ ButtonBorder��6!    . ._�5      �� $$	 TitleBarButtonContentPresenter��6/   |�.  #��z��5   /   #��z��5   /   ��. # z 5    /   #��z��5!   /   5"      5#      
 5%      P� 5&       �@J�IsMouseOver . . �5(      �� $ ButtonBackground��5*   %    �@J�Opacity$ 1Q�5)   %   5*   %   5+      P� 5,       � �� . . �5.      �� $ ButtonBackground��50   %    �@J�Opacity$	 0.6Q�5/   %   50   %   51      P� 52       � {� .  . �54      �� $$ TitleBarButtonContentPresenter��6%    �@J�Opacity$ .5Q�56   %   57      59      5;      5<      �� 5>      .R�5?   
   �  . .+�5@      F� �����@B ��- �@B �ا �@T� �ا �@T� ��- ���- @B ���- �� р�� �� р�� @T� ��ا @T� ��ا @B ���     � �     � � ��� р�� ��� р��  � �     � �    �� р� �� 	$��12��5A      $��12��5B       . $��Center=�5D      $��Center=�5E      
�������5F      5G      5H      �� 5J      .R�5K   
   �  . .+�5L      F� s����@B     р�[ @KL ��ا     � � @B ���j ��[ � � �ا ��ا  � р�[ ��j �@B  � �    �ا �@KL ��[ �    @B 	$��12��5M      $��12��5N       . $��Center=�5P      $��Center=�5Q      
�������5R      5S      5T      �� 5V      .R�5W   
   � .+�5X      F� O����@B @B �@B �ا ��ا �ا ��ا @B �        � �     � �  � �     � 	$��12��5Y      $��12��5Z       . $��Center=�5\      $��Center=�5]      
�������5^      5_      5`      �� 5b      .R�5c   
   � .+�5d      F� +����    @KL � � @KL � � ��[ �    ��[ 	$��12��5e      $��12��5f       . $��Center=�5h      $��Center=�5i      
�������5j      5k      5l      �� 5q      "    6    .�5s   
   ��  �@ WindowChrome 5t        5u      $ 0��6   $ 0q�5v       .  $
 None=�5x      5|      �� 5~   
    � ��
 �����6'   �� 5   
    � �� �#1F1F1F6(   �� 5�   
    �@�
ResizeMode$ CanResizeWithGrip=�6'   �� 5�   
    �@�UseLayoutRounding . 5�      �� 5�   
    �@ TextFormattingMode$ Display=�5�      �� 5�   
    �@�WindowStyle$ SingleBorderWindow=�5�      �� 5�   
    � ��$ Segoe UI)�5�      �� 5�   
    � �� 5�      �� 5�      "   6"   .R�5�      �� $ WindowBorder��6   ._�5�      � $ 
LayoutRoot��6   #��z��63    5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��* �60   .+�5�      � $ PART_WindowTitleGrid��6#   $��0��5�   #   $
��26.4��5�   #   #��z��5�   #    5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� #��z 63    . 5�   b   �� 5�   "   $$ WindowCommandButtonsStackPanel��6-   $��1��5�   -   $��Right=�5�   -   $��Stretch=�5�   -   $ 
Horizontal=�5�   -    . .+�5�   &   �� $ Minimize��6-   $ Minimize��5�   -    . 8��  8�� ��.  ��5�   -   �� # Z 5�   -   � 5�   &   $��1,0,1,0q�6+   .+�5�   *   �� $ Restore��61   $ Restore��5�   1    . 8�� 8�� $y�	Collapsed=�5�   1   ��.  ��5�   1   �� # Z 5�   1   �� 5�   *   $ Maximize��61   $ Maximize��5�   1    . 8�� 8�� ��.  ��5�   1   �� # Z 5�   1   5�   '   �� 5�   &   $ Close��6-    . 8�� 8�� ��5�   -   �� # Z 5�   -   5�   #   5�      �� 5�      $��1��6/     .  .u�5�   "   �� $	 MainContentPresenter��63   $! Cycle=�5�   3   5�      �� 5�      $��1��6/   5�      5�      5�      
 5�      P� 5�       �@�WindowState$ 	Maximized=�69   . �5�      �� $ Maximize��6%    � y�$ 	Collapsed=�5�   %   �� 5�      $ Restore��6%    � y�$ Visible=�5�   %   �� 5�      $ 
LayoutRoot��6%    � ��$ 8,8,8,8q�5�   %   5�      P� 5      �@�WindowState$ Normal=�69   . �5     �� $ Maximize��6%    � y�$ Visible=�5  ;   �� 5     $ Restore��6%    � y�$ 	Collapsed=�5  ;   5     P� 5      �@�
ResizeMode$ NoResize=�68   . �5	     �� $ Minimize��6%    � y�$ 	Collapsed=�5
  ;   �� 5     $ Maximize��6%    � y�$ 	Collapsed=�5  ;   �� 5     $ Restore��6%    � y�$ 	Collapsed=�5  ;   5     5     5     5     5     