   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  5      J    DA_journey_through_miniature_Uzhhorod.MVVM.View.EventsPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5         �Name$ Search��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5!      !  FontAwesome.Sharp.IconImage  $��0��5"      $��20��5#      $��20��5$      $��	40,0,10,0q�5%         titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [  5&         Icon$ Search=�5'      �� 5)      -   5         ��Name$ TextBoxSearch��5*      $��1��5+      $	��200��5,      $��28��5-      $��0,5,0,0q�5.      $
��Left=�5/      $��Center=�50      
������ 
�������$��0,0,0,2q�53       �� 
CaretBrush
 �����$��
Montserrat)�55      $��13(�56      $��Medium"�57      
���������59      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip 5:      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *EventTextBoxSearchToolTip+d� 5<      $��3��5=      $	��180��5>      $��40��5?      $��5,5,46,5q�5@      $��Right=�5A        FilerButton#��[ 5D      ��5B      �� *ToggleSortingCommand+��5C      �� *
SortIcon+5D      5E      �� 5G   
   $��1��5H      $��0,5,0,0q�5I      $
��Auto=�5J      .��5K      �� $��20q�6   ��6'   �� *Events+��5L      �� 5M      .R�5N      �  5O      �� 5P   "   $��60 �63   �� 5Q   "   $��* �63   .+�5T      �� $��0��5U   !   $��4��5V   !     color11#��[ 5W   !   A� 5Y      $��0��5Z   !   $��22��5[   !   $��22��5\   !   $��0,0,0,15q�5]   !   $��Center=�5^   !   $��Center=�5_   !   #��[ 5`   !   
�������$��3��5b   !   	 J� Effect	 5c   "   3  -System.Windows.Media.Effects.DropShadowEffect  5d   &   
   
BlurRadius$
 10Q�5e   )      Opacity$	 0.3Q�5f   )      Color$ Black��5g   )   5i      �� 5k      $��1��5l   !   $��
10,5,10,20q�5m   !    �� Padding$ 15q�5n   !     panelOverColor#��[ 5o   !   #��[ 5p   !   $��1q�5q   !    �� CornerRadius$ 12��5r   !   ._�5s   "   �� .+�5t   &   �� $��18(�5u   )   $
��Bold"�5v   )     titleColor1#��[ 5w   )   $
��Wrap=�5y   )   ��5x   )   �� *Title+5y   )   �� 5z   &   $
��Left=�5{   )   $��Center=�5|   )    �� Orientation$ 
Horizontal=�5}   )   .+�5~   *   �� $��14(�5   -   #��[ 5�   -   ��5�   -     *	EventDate+�� 5�   *   $��14(�5�   -   #��[ 5�   -   ��5�   -   �� *	EventDate+5�   '   �� 5�   &   $��14(�5�   )   #��[ 5�   )   $
��Wrap=�5�   )   ��5�   )   �� *Description+5�   )   5�   #   5�      5�      5�      5�      5�      �� 5�   
   $��2��5�      $��	0,0,0,-10q�5�      $��Center=�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $��10q�5�        
IconButton#��[ 5�      
 � Tag# [ 5�      ��5�      �� *PrevPageCommand+ 5�        *PrewPageToolTip+.��5�        $ 	AngleLeft=�6     iconButtonIcon#��[ 60   5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *CurrentPage+�� 5�      $��Center=�5�      #��[ 5�      $	�� / ��5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
TotalPages+�� 5�      $��10q�5�      #��[ 5�      # [ 5�      ��5�      �� *NextPageCommand+ 5�        *NextPageToolTip+.��5�        $ 
AngleRight=�6   #��[ 61   5�      5�      5�      5�      