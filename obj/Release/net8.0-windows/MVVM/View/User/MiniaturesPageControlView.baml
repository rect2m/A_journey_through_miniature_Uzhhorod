   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  N    HA_journey_through_miniature_Uzhhorod.MVVM.View.MiniaturesPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  .���   � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+�� -    �Name$ Search�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+�!  FontAwesome.Sharp.IconImage  $��0��$��20��$��20��$��	40,0,10,0q�   titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [     Icon$ Search=��� -    ��Name$ TextBoxSearch��$��1��$	��200��$��28��$��0,5,0,0q�$
��Left=�$��Center=�
������ 
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TextBoxSearchToolTip+�� $��2��$��Center=�$��Center=�	 �� Orientation$	 
Horizontal=�.+��� $��Center=�$��16(�$
��Bold"�  titleColor1#��[ 
 �� TextAlignment$
 Center=�$
��Wrap=���  *TotalMiniatures+�� $��Center=�$��16(�$
��Bold"�#��[ $
 Center=�$
��Wrap=����� *TotalMiniaturesCount+�� $��3��$��10q�$
��Left=� ! FavoriteListToggleButtonStyle#��[  
 color4
 � Tag# [ ���� *ToggleFavoritesFilterCommand+   *ButtonFavoriteToolTip+.��  $ Heart=�  iconButtonIcon#��[ d� $��4��$	��180��$��40��$��5,5,46,5q�$��Right=�  FilerButton#��[ ���� *ToggleSortingCommand+���� *
SortIcon+�� $��1��$
��Auto=�.��� $��10q�$��Center=�.+��� ���� *PagedMiniatures+���� .R�� ���� .R��� $	��220��$��10q� �� Padding$ 10q�  panelOverColor#��[   color11#��[ $��2q� �� CornerRadius$ 10�� � Cursor$
 Hand�� J� RenderTransformOrigin$ 0.5,0.5&�   *SculptureDetailOpen+z���  �� ScaleX$ 1Q� �� ScaleY$ 1Q�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseLeftButtonUp��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *$"DataContext.SelectMiniatureCommand+ �� RelativeSource ��  �� AncestorType ItemsControl   CommandParameter ��  � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W�  �� TargetProperty$ RenderTransform.ScaleX�	 W� To 1.1 g� Duration$ 0:0:0.2D�W� $ RenderTransform.ScaleY� 1.1$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ RenderTransform.ScaleX� 1$ 0:0:0.2D�W� $ RenderTransform.ScaleY� 1$ 0:0:0.2D�._��� .+��� $	��200��$	��150��$��5q�$
��Fill=����� *ImageSource+ J� Clip ��  �� RadiusX$ 10Q�  �� RadiusY$  10Q�! �� Rect$! 0,0,185,150��� $��5q�$��16(�$
��Bold"�#��[ $
 Center=�$
��Wrap=����� *Name+�� $��2��$��	0,0,0,-10q�$��Center=�$��Bottom=�$	 
Horizontal=�.+��� $��10q�  
IconButton#��[ # [ ���� *PrevPageCommand+   *PrewPageToolTip+.��  $ 	AngleLeft=�#��[ �� $��5q�$��Center=�#��[ ���� *CurrentPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *
TotalPages+�� $��10q�#��[ # [ ���� *NextPageCommand+   *NextPageToolTip+.��  $ 
AngleRight=�#��[ 