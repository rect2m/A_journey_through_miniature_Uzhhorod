   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  I    CA_journey_through_miniature_Uzhhorod.MVVM.View.QuestPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  -   .��� 
������   � RowDefinitions  �� $
��Auto ��� $��* �.+�� $��0��.+��� $��5q�   panelOverColor#��[    color11#��[ $��2q� �� CornerRadius$ 10��._��  � ColumnDefinitions �� $��* ��� $��* ��� $
��Auto �.+��� $��0��$��Center=�$��Center=� �� Orientation$ 
Horizontal=�.+���  �� Padding$ 5q�$��14(�$
��Bold"�  titleColor1#��[  J� Opacity$	 0.8Q���B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TextBlockQuestScale+�� -    ��Name$ ZoomIndicator��$ 5q�$��14(�$
��Bold"�#��[ $	 0.8Q�$
��100%���� $��1��$��Center=�$��Center=�$ 
Horizontal=�.+��� $��5q�$ 5q�$��14(�$
��Bold"�#��[ $	 0.8Q���  *TextBlockQuestCenter+�� -   $��5q�  
IconButton#��[ 
 � Tag# [  � ToolTip   *TextBlockQuestCenter+.��!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]	   Icon$	 ArrowsToDot=�  iconButtonIcon#��[ �� $��2��$��5q�$��Center=�$��Center=�$ 
Horizontal=�.+�A� $��16��$��16��$	��5,0q�
��� � ��� $��0,0,10,0q�$��Center=�$��12(�#��[ ��  *TextBlockQuestDone+A� $��16��$��16��$	��5,0q�
��������� $��0,0,10,0q�$��Center=�$��12(�#��[ ��  *TextBlockQuestInProcess+A� $��16��$��16��$	��5,0q�
��������� $��Center=�$��12(�#��[ ��  *TextBlockQuestBlocked+� -   $��1��
 K� ZIndex$
 0��.+��� $��5q�#��[  #��[ $��2q�$ 10���� $��5q�
������ $ 10��._��� -    ��Name$ ScrollViewer��
������ $��Hidden=�$��Hidden=�.���� -    ��Name$ CanvasWrapper��
������ .+��� -   $ QuestCanvas��
������  J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� -   CanvasScaleTransform�� �� ScaleX$ 1Q� �� ScaleY$ 1Q�T� -	   CanvasTranslateTransform�� T� X$ 0Q� T� Y$ 0Q�