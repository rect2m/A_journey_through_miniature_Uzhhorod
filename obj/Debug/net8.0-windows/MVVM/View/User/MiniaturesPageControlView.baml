   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  5	      N    HA_journey_through_miniature_Uzhhorod.MVVM.View.MiniaturesPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5         �Name$ Search��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5       $
��Auto �6#   .+�5$      !  FontAwesome.Sharp.IconImage  $��0��5%      $��20��5&      $��20��5'      $��	40,0,10,0q�5(         titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [  5)         Icon$ Search=�5*      �� 5,      -   5         ��Name$ TextBoxSearch��5-      $��1��5.      $	��200��5/      $��28��50      $��0,5,0,0q�51      $
��Left=�52      $��Center=�53      
������ 
�������$��0,0,0,2q�56       �� 
CaretBrush
 �����$��
Montserrat)�58      $��13(�59      $��Medium"�5:      
���������5<      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip 5=      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TextBoxSearchToolTip+�� 5?      $��2��5@      $��Center=�5A      $��Center=�5B      	 �� Orientation$	 
Horizontal=�5C      .+�5D      �� $��Center=�5E      $��16(�5F      $
��Bold"�5G        titleColor1#��[ 5H      
 �� TextAlignment$
 Center=�5J      $
��Wrap=�5K      ��5I        *TotalMiniatures+5K      �� 5M      $��Center=�5N      $��16(�5O      $
��Bold"�5P      #��[ 5Q      $
 Center=�5S      $
��Wrap=�5T      ��5R      �� *TotalMiniaturesCount+5T      5U      �� 5W      $��3��5X      $��10q�5Y      $
��Left=�5Z       ! FavoriteListToggleButtonStyle#��[ 5\       
 color4
 � Tag# [ 5]      ��5[      �� *ToggleFavoritesFilterCommand+ 5^        *ButtonFavoriteToolTip+.��5_        $ Heart=�6     iconButtonIcon#��[ 6,   5`      d� 5b      $��4��5c      $	��180��5d      $��40��5e      $��5,5,46,5q�5f      $��Right=�5g        FilerButton#��[ 5j      ��5h      �� *ToggleSortingCommand+��5i      �� *
SortIcon+5j      5l      �� 5m   
   $��1��6   $
��Auto=�6$   .��5n      � $��10q�6   $��Center=�6$   .+�5o      �� ��6   �� *PagedMiniatures+��5p      �� 5q      .R�5r      � 5s      ��5v      �� 5w      .R�5x      �� $	��220��5y   !   $��10q�5z   !    �� Padding$ 10q�5{   !     panelOverColor#��[ 5|   !     color11#��[ 5}   !   $��2q�5~   !    �� CornerRadius$ 10��5   !    � Cursor$
 Hand��5�   !    J� RenderTransformOrigin$ 0.5,0.5&�5�   !    5�   !     *SculptureDetailOpen+z�5�   "   �� 5�   &    �� ScaleX$ 1Q�65    �� ScaleY$ 1Q�6@   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   &      	EventName$ MouseLeftButtonUp��65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�   *   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6@   �� *$"DataContext.SelectMiniatureCommand+ �� RelativeSource ��  �� AncestorType ItemsControl   CommandParameter 6�   �� 5�   '    � Triggers 5�   "   :� 5�   &    :� RoutedEvent$ 
MouseEnter��63   .[�5�   *   �� .��5�   .   �� .��5�   2   W�  �� TargetProperty$ RenderTransform.ScaleX�5�   5   	 W� To 1.15�   5    g� Duration$ 0:0:0.2D�5�   5   W� 5�   2   $ RenderTransform.ScaleY�5�   5    1.15�   5   $ 0:0:0.2D�5�   5   5�   /   5�   +   5�   '   :� 5�   &   $ 
MouseLeave��63   .[�5�   *   �� .��5�   .   �� .��5�   2   W� $ RenderTransform.ScaleX�5�   5    15�   5   $ 0:0:0.2D�5�   5   W� 5�   2   $ RenderTransform.ScaleY�5�   5    15�   5   $ 0:0:0.2D�5�   5   5�   /   5�   +   5�   '   ._�5�   "   �� .+�5�   &   �� $	��200��5�   )   $	��150��5�   )   $��5q�5�   )   $
��Fill=�5�   )   ��5�   )   �� *ImageSource+ J� Clip 5�   *   �� 5�   .    �� RadiusX$ 10Q�5�   1     �� RadiusY$  10Q�5�   1   ! �� Rect$! 0,0,185,150�5�   1   5�   '   �� 5�   &   $��5q�5�   )   $��16(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   $
 Center=�5�   )   $
��Wrap=�5�   )   ��5�   )   �� *Name+5�   )   5�   #   5�      5�      5�      5�      5�      �� 5�   
   $��2��5�      $��	0,0,0,-10q�5�      $��Center=�5�      $��Bottom=�5�      $	 
Horizontal=�5�      .+�5�      �� $��10q�5�        
IconButton#��[ 5�      # [ 5�      ��5�      �� *PrevPageCommand+ 5�        *PrewPageToolTip+.��5�        $ 	AngleLeft=�6   #��[ 60   5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *CurrentPage+�� 5�      $��Center=�5�      #��[ 5�      $	�� / ��5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
TotalPages+�� 5�      $��10q�5�      #��[ 5�      # [ 5�      ��5�      �� *NextPageCommand+ 5�        *NextPageToolTip+.��5�        $ 
AngleRight=�6   #��[ 61   5�      5�      5�      5�      