   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  R    LA_journey_through_miniature_Uzhhorod.MVVM.View.PersonalOfficePageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � 	Resources  Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter   BoolToVisibilityConverterZ   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToVisibilityConverter  NullToVisibilityConverter��%   &	        &	          .��� .+��� $
��Auto=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��
10,20,0,10q�$��20(�$
��Bold"�  titleColor1#��[ ��B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *PersonalOfficeEditTitle+� $��2�� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� $��0��$��10,0,0,0q�$��20(�$
��Bold"�#��[ ��  *PersonalOfficeInfoTitle+�� $��1��$	��200��$��20,0,0,0q�  panelOverColor#��[   ComboBoxStyle#��[ ���� *DisplayOptions+ �� SelectedItem �� *SelectedDisplayOption+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��20q� �� Padding$ 10q�#��[   color11#��[ $��2q� �� CornerRadius$ 10��._��  �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��0��$��0��$��Center=�.+��� -    ��Name$ AvatarButton��$	��170��$	��170��$��10,10,-10,-10q�
������ $��0q� � Cursor$
 Hand������ *ChangeAvatarCommand+	 � ToolTip	   *AvatarButtonToolTip+���� 
 �� 
TargetType"
 ��.R�� .+�A� $	��170��$	��170��#��[ $��1������  j� Stretch$ UniformToFill=� �� ImageSource �� *
AvatarPath+�� $��0��$��1��$��40,10,40,10q�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *
Username+�� -    ��Name$ TextBoxUser��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� *NewUsername+$ PropertyChanged=�.������  j� 
AlignmentX$
 Left=�$ /Icons/user.png��$
 None=�.���� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *PersonalOfficeOldPassword+G� -    G�Name$ OldPasswordBox��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q� G� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� $
 Left=�$ /Icons/key.png��$
 None=��� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *PersonalOfficeNewPassword+G� -   $ NewPasswordBox��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q�
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� $
 Left=�$ /Icons/key.png��$
 None=��� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *Email+�� -   $ TextBoxMail��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q�
 �����$��
Montserrat)�$��13(�$��Medium"�
�������$4	 .Приклад: ВашаАдреса@gmail.com������ *
NewEmail+$ PropertyChanged=�.������ $
 Left=�$ /Icons/mail-icon.png��$
 None=�.���� $��1��$��2��$��10q�$��Center=� �� Orientation$ 
Horizontal=�.+��� #��[  
 button#��[ ���� *UpdateProfileCommand+��  *PersonalOfficeButtonSave+�� $��10,0,0,0q�#��[ #��[ ���� *DataContext.LogoutCommand+ �� RelativeSource ��  �� AncestorType
 Window��  *PersonalOfficeButtonLeave+�� $��10,0,0,0q�#��[ #��[ ���� *" DataContext.DeleteAccountCommand+ �� 
 Window��  *PersonalOfficeButtonDelete+� $��3��.+��� $
��Auto=�.���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+�� $��4��y��� *IsReviewSelected+ �� 	Converter# [  .+��� $��0��$��20q�$ 10q�#��[ #��[ $��2q�$ 10��._��� .+�� $��0,0,0,10q�$��Stretch=�.+��� $
��Left=�$��Center=�$��16(�$
��Bold"�#��[ ��  *PersonalOfficeYourReviews+�� $��10q�$��Right=�#��[ #��[ ���� *ClearAllReviewsCommand+��  *" PersonalOfficeButtonClearReviews+	   *#!PersonalOfficeClearReviewsToolTip+�  �� $��* ��� $
��Auto �.+��� $��1��$��	0,0,0,-10q�$��Center=�$��Bottom=�$ 
Horizontal=�����  �� 
TargetType" ��.���  �� Property � y� �� Value$ Visible=� �� Triggers ��  �� Binding �� *UserReviews.Count+ �� Value 0.a���  � y�$ 	Collapsed=�.+��� $��10q�  
IconButton#��[ 
 � Tag# [ ���� *PrevReviewPageCommand+	   *PrewPageToolTip+.��!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 	AngleLeft=�  iconButtonIcon#��[ �� $��5q�$��Center=�#��[ ���� *CurrentReviewPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *TotalReviewPages+�� $��10q�#��[ # [ ���� *NextReviewPageCommand+	   *NextPageToolTip+.��  $ 
AngleRight=�#��[ �� $��0��$	��300��$
��Auto=�.���� ���� *UserReviews+���� .R��� $��5q�$ 10q�#��[ $��1q�$ 10��._�� .+��� $
��Left=�.+��� $ 
Horizontal=�.+��� $��16(�$
��Bold"�#��[ ���� *MiniatureName+�� $��10,3,0,0q�$��13(�#��[ ���� *	CreatedAt+ �� StringFormat$  {0:dd.MM.yyyy HH:mm}���� $ 
Horizontal=�.+��� $��14(�#��[ ��  *PersonalOfficeTextBlockRate+�� $��14(� 
	 color6#��[	 ���� *Rating+  $��18��$��18��$��3,0,0,0q�   
Foreground# [	 $
 Star=�#��[ �� $��15(�#��[ $
��Wrap=����� *	Comment+�� $ DeleteRevievButton��$��15q�$��Right=�#��[ $ #c78c54������ *!DataContext.DeleteReviewCommand+ ��  UserControl���� 	   *" PersonalOfficeButtonDeleteReview+.��     Name$  MenuIcon��$ Trash=�#��[ �� $��Center=�$��Center=�$��16(�$��SemiBold"�#��[ ��  *PersonalOfficeDontHaveReviews+���� " ��.���  � y�$ 	Collapsed=� ��  �� *UserReviews.Count+ 0.a���  � y�$ Visible=�� $��4��y��� *IsActivitySelected+# [  .+��� $��1��$��20q�$ 10q�#��[ #��[ $��2q�$ 10��._��� .+�� $��0,0,0,10q�$��Stretch=�.+��� $
��Left=�$��Center=�$��16(�$
��Bold"�#��[ ��  *%#PersonalOfficeTextBlockHistoryTitle+�� $	��200��$��10q�#��[ ���� *ActivityFilters+ �� *SelectedFilter+$ PropertyChanged=��� $��10q�$��Right=�#��[ #��[ ���� *ClearHistoryCommand+��  *" PersonalOfficeButtonClearHistory+	   *POButtonClearHistoryToolTip+�  �� $��* ��� $
��Auto �.+��� $��1��$��	0,0,0,-10q�$��Center=�$��Bottom=�$ 
Horizontal=����� " ��.���  � y�$ Visible=� ��  �� *UserActivities.Count+ 0.a���  � y�$ 	Collapsed=�.+��� $��10q�#��[ # [ ���� *PrevActivityPageCommand+	   *PrewPageToolTip+.��  $ 	AngleLeft=�#��[ �� $��5q�$��Center=�#��[ ���� *CurrentActivityPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *TotalActivityPages+�� $��10q�#��[ # [ ���� *NextActivityPageCommand+	   *NextPageToolTip+.��  $ 
AngleRight=�#��[ �� $��0��$	��300��$
��Auto=�.���� ���� *UserActivities+���� .R��� $��5q�$ 10q�#��[ $��1q�$ 10��._�� .+��� .+��� $ 
Horizontal=�.+��� $��16(�$
��Bold"�#��[ ���� *Action+�� $��10,3,0,0q�$��13(�#��[ ���� *	Timestamp+$  {0:dd.MM.yyyy HH:mm}���� $��15(�#��[ $
��Wrap=����� *	Details+�� $ DeleteHistoryButton��$��15q�$��Right=�#��[ $ #c78c54������ *)'DataContext.DeleteSingleActivityCommand+ ��  UserControl���� 	   *" PersonalOfficeButtonDeleteRecord+.��  $  MenuIcon��$ Trash=�#��[ �� $��Center=�$��Center=�$��16(�$��SemiBold"�#��[ ��  *PersonalOfficeDontHaveHistory+���� " ��.���  � y�$ 	Collapsed=� ��  �� *UserActivities.Count+ 0.a���  � y�$ Visible=�� $��4��y��� *IsFeedbackSelected+# [  .+��� $��20q�$ 10q�#��[ #��[ $��2q�$ 10��._��� .+�� $��0,0,0,10q�$��Stretch=�.+��� $��	0,20,0,20q�$
��Left=�$��Center=�$��16(�$
��Bold"�#��[ ��  *PersonalOfficeFeedbackTitle+�  �� $��* ��� $
��Auto �.+��� $��0��$	��300��$
��Auto=�.���� ���� *UserFeedbacks+���� .R��� $��5q�$ 10q�#��[ $��1q�$ 10��._��  �� $��* ��� $
��Auto �.+��� $��0��.+��� $ 
Horizontal=�.+��� $��16(�$
��Bold"�#��[ ���� *
Username+�� $��10,3,0,0q�$��13(�#��[ ���� *SentAt+$  {0:dd.MM.yyyy HH:mm}���� $��14(�
����������� *Email+�� $��14(�$��SemiBold"�#��[ ���� *
Category+�� $��15(�#��[ $
��Wrap=����� *	Message+9� $��0,10,0,0q�
������ $��13(�$
��Bold"�#��[ ��  *AdminResponse+y��� *AdminResponse+# [ .���� $��5,7,0,0q�$��13(�#��[ $
��Wrap=����� *AdminResponse+�� $��1��$��15,0,0,0q�$��Center=�#��[ # [ ���� *#!DataContext.DeleteFeedbackCommand+ ��  UserControl���� 	   *$"PersonalOfficeButtonDeleteFeedback+.��  $ Trash=�#��[ �� $��1��$��	0,0,0,-10q�$��Center=�$��Bottom=�$ 
Horizontal=����� " ��.���  � y�$ Visible=� ��  �� *UserFeedbacks.Count+ 0.a���  � y�$ 	Collapsed=�.+��� $��10q�#��[ # [ ���� *PrevFeedbackPageCommand+	   *PrewPageToolTip+.��  $ 	AngleLeft=�#��[ �� $��5q�$��Center=�#��[ ���� *CurrentFeedbackPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *TotalFeedbackPages+�� $��10q�#��[ # [ ���� *NextFeedbackPageCommand+	   *NextPageToolTip+.��  $ 
AngleRight=�#��[ �� $��0��$��Center=�$��Center=�$��16(�$��SemiBold"�#��[ ��  *!PersonalOfficeDontHaveFeedbacks+���� " ��.���  � y�$ 	Collapsed=� ��  �� *UserFeedbacks.Count+ 0.a���  � y�$ Visible=�