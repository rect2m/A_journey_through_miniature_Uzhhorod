   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  J    DA_journey_through_miniature_Uzhhorod.MVVM.View.EventsPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  .���   � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+�� -    �Name$ Search�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�!  FontAwesome.Sharp.IconImage  $��0��$��20��$��20��$��	40,0,10,0q�   titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [     Icon$ Search=��� -    ��Name$ TextBoxSearch��$��1��$	��200��$��28��$��0,5,0,0q�$
��Left=�$��Center=�
������ 
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *EventTextBoxSearchToolTip+d� $��3��$	��180��$��40��$��5,5,46,5q�$��Right=�  FilerButton#��[ ���� *ToggleSortingCommand+���� *
SortIcon+�� $��1��$��0,5,0,0q�$
��Auto=�.���� $��20q����� *Events+���� .R��  �� $��60 ��� $��* �.+��� $��0��$��4��  color11#��[ A� $��0��$��22��$��22��$��0,0,0,15q�$��Center=�$��Center=�#��[ 
�������$��3��	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   
BlurRadius$
 10Q�   Opacity$	 0.3Q�   Color$ Black���� $��1��$��
10,5,10,20q� �� Padding$ 15q�  panelOverColor#��[ #��[ $��1q� �� CornerRadius$ 12��._��� .+��� $��18(�$
��Bold"�  titleColor1#��[ $
��Wrap=����� *Title+�� $
��Left=�$��Center=� �� Orientation$ 
Horizontal=�.+��� $��14(�#��[ ��  *	EventDate+�� $��14(�#��[ ���� *	EventDate+�� $��14(�#��[ $
��Wrap=����� *Description+�� $��2��$��	0,0,0,-10q�$��Center=�$��Bottom=�$ 
Horizontal=�.+��� $��10q�  
IconButton#��[ 
 � Tag# [ ���� *PrevPageCommand+   *PrewPageToolTip+.��  $ 	AngleLeft=�  iconButtonIcon#��[ �� $��5q�$��Center=�#��[ ���� *CurrentPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *
TotalPages+�� $��10q�#��[ # [ ���� *NextPageCommand+   *NextPageToolTip+.��  $ 
AngleRight=�#��[ 