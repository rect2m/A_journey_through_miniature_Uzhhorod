   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  V    PA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditFeedbackPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � 	Resources     BoolToVisibilityConverterZ   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToVisibilityConverter  NullToVisibilityConverterT   NA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToBoolConverter  NullToBoolConverter��%-   &	        &	      &	 
     ��     .��� $��20q�.+��� $��0,30,0,0q�$��Center=�$��Center=�$��16(�$��SemiBold"�
���������B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *	NoMessage+y��� *Feedbacks.Count+ �� 	Converter# [  �� $
��Auto=�.���� ���� *	Feedbacks+���� .R��� ���� .R��� $��0,0,0,15q� �� Padding$ 15q�  panelOverColor#��[   color11#��[ $��1q� �� CornerRadius$ 12��._��� .+��� $��0,5,0,2q�$��
Montserrat)�$��12(�$��Medium"�
���������  *User+��  �� Orientation$ 
Horizontal=�$��0,5,0,0q�.+�A� $��27��$��27��$��0,-5,0,0q�����  j� Stretch$ UniformToFill=� �� ImageSource �� *AvatarImage+�� $��5,-3,0,0q�$��15(�$��SemiBold"�  titleColor1#��[ ���� *
UserName+�� $��5,0,0,0q�$��Right=�$��12(�#��[ ���� *Feedback.SentAt+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}���� $��0,5,0,5q�$��13(�#��[ ���� *Feedback.Email+�� $��0,5,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *
Category+�� $��0,2,0,5q�$��14(�$��Medium"����� *CategoryBrush+���� *Feedback.Category+�� $��0,5,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *	Message+�� $��0,2,0,5q�$��16(�#��[ $
��Wrap=����� *Feedback.Message+9� $��0,10,0,0q�
������ $��13(�$
��Bold"�#��[ ��  *AdminResponse+y��� *Feedback.AdminResponse+# [ .���� $��5,7,0,0q�$��13(�#��[ $
��Wrap=����� *Feedback.AdminResponse+� $��0,10,0,0q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$��5q�$��Center=�	 �� AcceptsReturn$
	 True��
������ #��[ $��0,0,0,2q�$��13(�#��[ 
 �� TextWrapping$

 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *AdminReplyText+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��10q�$
��Left=�  
IconButton#��[ 
 � Tag# [ ���� *SendReplyCommand+.��!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 
PaperPlane=�  iconButtonIcon#��[ 