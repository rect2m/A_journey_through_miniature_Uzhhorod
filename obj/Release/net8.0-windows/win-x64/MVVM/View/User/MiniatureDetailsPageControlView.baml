   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  T    NA_journey_through_miniature_Uzhhorod.MVVM.View.MiniatureDetailsPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  .���   � RowDefinitions  �� $��70 ��� $��* ��� $��70 � � ColumnDefinitions �� $	��320 ��� $��* �.+��� -    ��Name$ 
ButtonBack��$��0��$��10q�$
��Left=�   
IconButton#��[    color11
 � Tag# [ ���� *BackToListCommand+ � ToolTip B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *ButtonBackToolTip+.��!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 	AngleLeft=�  iconButtonIcon#��[ �� $��0��$��1��$��
10,20,10,0q�$��24(�$
��Bold"�  titleColor1#��[  �� TextAlignment$ Center=����� *SelectedMiniature.Name+�� $��0��$��1��$��10,10,50,10q�$��Right=�  FavoriteDetailsButtonStyle#��[  
 color4# [ ���� *ToggleFavoriteCommand+   *ButtonAddFavoriteToolTip+.��  $ Heart=�#��[ �� $��1��$��1��$��10q� �� Padding$ 15q�$��1q� �� CornerRadius$ 10��._�� .+��� $
��Auto=�.���� .+��� $��0,0,0,20q�$��18(�#��[ $
��Wrap=����� *SelectedMiniature.Description+�� $��0,30,0,5q�$��16(�$
��Bold"�#��[ ��  *MiniatureTextBlockAddReview+�� 
������ #��[ $��1q�$ 10��._��� $��70��$��5q�	 �� AcceptsReturn$
	 True��
������ $��0q�
 �� 
CaretBrush#
 [ $��14(�#��[  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *ReviewComment+ �� UpdateSourceTrigger$ PropertyChanged=��� $��10q�$��0q� � Cursor$
 Hand��$��
Montserrat)�$��12(�
������� 
 button#��[ ���� *SubmitReviewCommand+��  *MiniatureButtonAddReview+�� $��0,30,0,5q�$��16(�$
��Bold"�#��[ ��  *MiniatureTextBlockReview+�� $��0,30,0,0q�$��Center=�$��Center=�$��14(�#��[ ��  *AnavaibleReviews+����  �� 
TargetType" ��.���  �� Property � y� �� Value$ 	Collapsed=� �� Triggers ��  �� Binding �� *Reviews.Count+ �� Value 0.a���  � y�$ Visible=��� ���� *	Reviews+���� .R��� $��5q�$ 10q�#��[ $��1q�$ 10��._��� .+���  �� Orientation$ 
Horizontal=�.+��� $ 
Horizontal=�.+�A� $��24��$��24������  j� Stretch$ UniformToFill=� �� ImageSource �� *AvatarImage+�� $��5,0,0,0q�$��16(�$
��Bold"�#��[ ���� *
UserName+�� $��10,3,0,0q�$��13(�#��[ ���� *	CreatedAt+�� $ 
Horizontal=�.+��� $��14(�#��[ ��  *TextBlockReviewRate+�� $��14(� 
 color6#��[ ���� *Rating+  $��18��$��18��$��3,0,0,0q�   
Foreground# [ $
 Star=�#��[ �� $��15(�#��[ $
��Wrap=����� *	Comment+� $��1��$��0��  �� $	��250 ��� $��* �.+��� $��0��#��[ $��3q�$ 20������ $ UniformToFill=� �� *SelectedMiniature.ImageSource+�� $��1��$��10q�$��Center=�$ Vertical=�.+��� -   $ Button3DModel��$��0,5,0,0q�$
 Hand��$��
Montserrat)�$��15(�
�������  button3DModel#��[ ���� *View3DModelCommand+��  *Button3DModel+�� $��2��$��0��$��0,5,0,0q�$��Center=�$��Center=�$��LeftToRight=�$ 
Horizontal=�.+��� $��18(�$
��Bold"�#��[ $ Center=���  *MiniatureTextBlockRating+�� $��18(�$
��Bold"�#��[ $ Center=����� *!SelectedMiniature.AverageRating+  $��10,0,0,0q�# [ $
 Star=�#��[ �� $��0,5,0,0q�$��Center=�$ 
Horizontal=�.+��� $��0,5,10,0q�$��Center=�$��16(�$��SemiBold"�#��[ $
��GPS:���� $ Vertical=�.+��� $
��Left=�$��Center=�$ 
Horizontal=�.+��� $��Center=�$��16(�$��SemiBold"�#��[ ��  *TextBlockLatitude+�� $��Center=�$��16(�$��SemiBold"�#��[ ���� *SelectedMiniature.Latitude+�� $
��Left=�$��Center=�$ 
Horizontal=�.+��� $��Center=�$��16(�$��SemiBold"�#��[ ��  *TextBlockLongitude+�� $��Center=�$��16(�$��SemiBold"�#��[ ���� *SelectedMiniature.Longitude+� $��2��$��2��.+��� $��Center=�$ 
Horizontal=�.+��� $��0,0,0,0q�$��Center=�$��Center=�$��25(�$
��Bold"�#��[ ��  *MiniatureTextBlockRate+�� -   $��	StarPanel��$��40,0,0,0q�$��Center=�$��Center=�$��LeftToRight=�$ 
Horizontal=�.+��� -   $��10q�$��1�� 	 
StarButton#��[	 $ 1������ *RateCommand+.��  $
 Star=� 
 StarButtonIcon#��[
 �� -   $��10q�$��2��#��[	 $ 2������ *RateCommand+.��  $
 Star=�#��[
 �� -   $��10q�$��3��#��[	 $ 3������ *RateCommand+.��  $
 Star=�#��[
 �� -   $��10q�$��4��#��[	 $ 4������ *RateCommand+.��  $
 Star=�#��[
 �� -   $��10q�$��5��#��[	 $ 5������ *RateCommand+.��  $
 Star=�#��[
 