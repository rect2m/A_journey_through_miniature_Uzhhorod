   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      S    MA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditUsersPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .��5      �� $��20q�5   	     �� Padding$  10q�5   	      panelOverColor#��[  5   	     color11#��[ 5   	   $��2q�5   	    �� CornerRadius$ 10��5   	   ._�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5$      � $��1��6   $��
0,10,0,-10q�6     � ColumnDefinitions 5%      �� 5&      $��* �6'   �� 5'      $��* �6'   �� 5(      $��* �6'   �� 5)      $��* �6'   .+�5,      �� $��0��5-      $��Center=�5.      $��18(�5/      $
��Bold"�50        titleColor1#��[ 51      ��52      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *
Username+�� 53      $��1��54      $��Center=�55      $��18(�56      $
��Bold"�57      #��[ 58      ��59        *Role+�� 5:      $��2��5;      $��Center=�5<      $��18(�5=      $
��Bold"�5>      #��[ 5?      ��5@        *Status+�� 5A      $��3��5B      $��Center=�5C      $��18(�5D      $
��Bold"�5E      #��[ 5F      ��5G        *	Actions+5H      �� 5J      $��0��5K      $
��Left=�5L       �� Orientation$ 
Horizontal=�5M      .+�5N      !  FontAwesome.Sharp.IconImage  $��20��5O      $��20��5P      $��	40,0,10,0q�5Q        titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [ 5R         Icon$ Search=�5S      �� 5U      -   5         ��Name$ TextBoxSearch��5V      $	��200��5W      $��28��5X      $��0,5,0,0q�5Y      $
��Left=�5Z      $��Center=�5[      
������ 
�������$��0,0,0,2q�5^       �� 
CaretBrush
 �����$��
Montserrat)�5`      $��13(�5a      $��Medium"�5b      
���������5d      �� *SearchQuery+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 � ToolTip
 5e        *TextBoxSearchToolTip+5f      �� 5h      $��0��5i      $	��200��5j      $��0,5,5,5q�5k      $��Right=�5l        ComboBoxStyle#��[ 5o      ��5m      �� *UserFilters+ �� SelectedItem 5n      �� *SelectedFilter+$	 PropertyChanged=�5o      �� 5s      $��2��5t      $��0,10,0,0q�5u      $��10q�5v      $
��Auto=�5w      .��5x      �� ��6   �� *Users+��5y      �� 5z      .R�5{      �� $��7q�5|   !   $  	0,10,0,10q�5}   !   #��[ 5~   !   $��1q�5   !   $ 10��5�   !   ._�5�   "   �  5�   &   �� 5�   *   $��* �6;   �� 5�   *   $��* �6;   �� 5�   *   $��* �6;   �� 5�   *   $��* �6;   .+�5�   &   �� $��0��5�   )   $��Center=�5�   )   $��Center=�5�   )   $��18(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   ��5�   )   �� *
Username+�� 5�   &   $��1��5�   )   $��Center=�5�   )   $��Center=�5�   )   $��18(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   ��5�   )   �� *Role+�� 5�   &   $��2��5�   )   $��5,0,0,0q�5�   )   $��Center=�5�   )   $��Center=�5�   )   $��18(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   ��5�   )   �� *Status+�� 5�   &   $��3��5�   )   $��5,0,0,0q�5�   )   $��Center=�5�   )   $ 
Horizontal=�5�   )   .+�5�   *   �� $��5,0,0,0q�5�   -     
IconButton#��[ 5�   -   
 � Tag# [ 5�   -   ��5�   -   �� *DataContext.ChangeRoleCommand+ �� RelativeSource ��  �� AncestorType UserControl��5�   -   �� 
 5�   -     *
ChangeRole+.��5�   .     $ ArrowsRotate=�6;     iconButtonIcon#��[ 6O   5�   +   �� 5�   *   $��5,0,0,0q�5�   -   #��[ 5�   -   # [ 5�   -   ��5�   -   �� * DataContext.ToggleBlockCommand+ ��  UserControl��5�   -   �� 
 5�   -     *ChangeStatus+.��5�   .     $	 Ban=�6;   #��[ 6F   5�   +   �� 5�   *   $��5,0,0,0q�5�   -   #��[ 5�   -   # [ 5�   -   ��5�   -   �� *DataContext.DeleteUserCommand+ ��  UserControl��5�   -   �� 
 5�   -     *ChangeStatus+.��5�   .     $ Trash=�6;   #��[ 6H   5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��3��5�      $��0,10,0,0q�5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� #��[ 5�      # [ 5�      ��5�      �� *PrevPageCommand+
 5�        *PrewPageToolTip+.��5�        $ 	AngleLeft=�6#   #��[ 64   5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *CurrentPage+�� 5�      $��Center=�5�      #��[ 5�      $	�� / ��5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
TotalPages+�� 5�      #��[ 5�      # [ 5�      ��5�      �� *NextPageCommand+
 5�        *NextPageToolTip+.��5�        $ 
AngleRight=�6#   #��[ 65   5�      5�      �� 5�      $��2��5�      $��Center=�5�      $��Center=�5�      $��16(�5�      $��SemiBold"�5�      #��[ 5�      ��5�        *	NoUsers+��5�      �� 5�       �� 
TargetType" ��6   .�5�      ��  �� Property � y� �� Value$ 	Collapsed=�67    �� Triggers 5�      �� 5�       �� Binding 6*   �� *Users.Count+ �� Value 06J   .a�5�   "   ��  � y�$ Visible=�6?   5      5     5     5     5     5     