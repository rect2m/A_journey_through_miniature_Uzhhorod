   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  5      q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  5	      R    LA_journey_through_miniature_Uzhhorod.MVVM.View.PersonalOfficePageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
        � 	Resources  5      Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter   BoolToVisibilityConverterZ   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToVisibilityConverter  NullToVisibilityConverter��%:   &	        &	        5   
   6)     5   
   6)   5      .��5      � .+�5   
   �� $
��Auto=�6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��0��5      $��
10,20,0,10q�5       $��20(�5!      $
��Bold"�5"        titleColor1#��[ 5#      ��5$      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *PersonalOfficeEditTitle+� 5&      $��2��6    � ColumnDefinitions 5'      �� 5(      $��* �6+   �� 5)      $��* �6+   �� 5*      $��* �6+   .+�5-      �� $��0��5.      $��10,0,0,0q�5/      $��20(�50      $
��Bold"�51      #��[ 52      ��53        *PersonalOfficeInfoTitle+�� 55      $��1��56      $	��200��57      $��20,0,0,0q�58        panelOverColor#��[ 59        ComboBoxStyle#��[ 5<      ��5:      �� *DisplayOptions+ �� SelectedItem 5;      �� *SelectedDisplayOption+ �� UpdateSourceTrigger$ PropertyChanged=�5<      5=      �� 5?      $��1��5@      $��20q�5A       �� Padding$ 10q�5B      #��[ 5C        color11#��[ 5D      $��2q�5E       �� CornerRadius$ 10��5F      ._�5G      �  5H      �� 5I      $
��Auto �6,   �� 5J      $
��Auto �6,    5L      �� 5M      $
��Auto �6/   �� 5O      $��* �6/   .+�5T      �� $��0��5U      $��0��5V      $��Center=�5W      .+�5X      �� -   5         ��Name$ AvatarButton��5Y   !   $	��170��5Z   !   $	��170��5[   !   $��10,10,-10,-10q�5\   !   
������ $��0q�5^   !    � Cursor$
 Hand��5`   !   ��5_   !   �� *ChangeAvatarCommand+	 � ToolTip	 5a   !     *AvatarButtonToolTip+��5d   "   �� 5e   &   
 �� 
TargetType"
 ��66   .R�5f   *   � .+�5g   .   A� $	��170��5h   1   $	��170��5i   1   #��[ 5j   1   $��1��5k   1   ��5l   2   �� 5m   6    j� Stretch$ UniformToFill=�6d    �� ImageSource 6A   �� *
AvatarPath+6d   5o   /   5p   +   5q   '   5s      5u      �� 5x      $��0��5y      $��1��5z      $��40,10,40,10q�5{      .+�5|      �� $��
Montserrat)�5}   !   $��12(�5~   !   $��Medium"�5   !   
���������5�   !     *
Username+�� 5�      -   5         ��Name$ TextBoxUser��5�   !   $��28��5�   !   $��0,5,0,0q�5�   !   $��25,0,0,0q�5�   !   $��Center=�5�   !   
�������$��0,0,0,2q�5�   !    �� 
CaretBrush
 �����$��
Montserrat)�5�   !   $��13(�5�   !   $��Medium"�5�   !   
���������5�   !   �� *NewUsername+$ PropertyChanged=�.��6c   ��5�   "   �� 5�   &    j� 
AlignmentX$
 Left=�5�   )   $ /Icons/user.png��5�   )   $
 None=�5�   )   .��5�   6   5�      �� 5�      $��0,15,0,0q�5�   !   $��
Montserrat)�5�   !   $��12(�5�   !   $��Medium"�5�   !   
���������5�   !     *PersonalOfficeOldPassword+G� 5�      -   5         G�Name$ OldPasswordBox��5�   !   $��28��5�   !   $��0,5,0,0q�5�   !   $��25,0,0,0q�5�   !   $��Center=�5�   !   
�������$��0,0,0,2q�5�   !    G� 
CaretBrush
 �����$��
Montserrat)�5�   !   $��13(�5�   !   $��Medium"�5�   !   
���������5�   "   �� 5�   &   $
 Left=�5�   )   $ /Icons/key.png��5�   )   $
 None=�5�   )   5�      �� 5�      $��0,15,0,0q�5�   !   $��
Montserrat)�5�   !   $��12(�5�   !   $��Medium"�5�   !   
���������5�   !     *PersonalOfficeNewPassword+G� 5�      -   5        $ NewPasswordBox��5�   !   $��28��5�   !   $��0,5,0,0q�5�   !   $��25,0,0,0q�5�   !   $��Center=�5�   !   
�������$��0,0,0,2q�5�   !   
 �����$��
Montserrat)�5�   !   $��13(�5�   !   $��Medium"�5�   !   
���������5�   "   �� 5�   &   $
 Left=�5�   )   $ /Icons/key.png��5�   )   $
 None=�5�   )   5�      �� 5�      $��0,15,0,0q�5�   !   $��
Montserrat)�5�   !   $��12(�5�   !   $��Medium"�5�   !   
���������5�   !     *Email+�� 5�      -   5        $ TextBoxMail��5�   !   $��28��5�   !   $��0,5,0,0q�5�   !   $��25,0,0,0q�5�   !   $��Center=�5�   !   
�������$��0,0,0,2q�5�   !   
 �����$��
Montserrat)�5�   !   $��13(�5�   !   $��Medium"�5�   !   
�������$4	 .Приклад: ВашаАдреса@gmail.com��5�   !   ��5�   !   �� *
NewEmail+$ PropertyChanged=�.��5�   I   ��5�   "   �� 5�   &   $
 Left=�5�   )   $ /Icons/mail-icon.png��5�   )   $
 None=�5�   )   .��5�   6   5�      5�      �� 5�      $��1��5�      $��2��5�      $��10q�5�      $��Center=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� #��[ 5�   !    
 button#��[ 5�   !   ��5�   !   �� *UpdateProfileCommand+��5�   !     *PersonalOfficeButtonSave+5�   !   �� 5�      $��10,0,0,0q�5�   !   #��[ 5   !   #��[ 5  !   ��5�   !   �� *DataContext.LogoutCommand+ �� RelativeSource ��  �� AncestorType
 Window��5�   !     *PersonalOfficeButtonLeave+5  !   �� 5     $��10,0,0,0q�5  !   #��[ 5  !   #��[ 5  !   ��5  !   �� *" DataContext.DeleteAccountCommand+ �� 
 Window��5  !     *PersonalOfficeButtonDelete+5  !   5     5	     5
     � 5     $��3��6   .+�5     �� $
��Auto=�6#   .��5     �  5     �� 5  "   $
��Auto �60   �� 5  "   $
��Auto �60   �� 5  "   $
��Auto �60   �� 5  "   $
��Auto �60   �� 5  "   $��* �60   .+�5     � $��4��6#   y�60   �� *IsReviewSelected+ �� 	Converter# [  .+�5  "   �� $��0��5  %   $��20q�5  %   $ 10q�5  %   #��[ 5  %   #��[ 5  %   $��2q�5  %   $ 10��5   %   ._�5!  &   �� .+�5"  *   � $��0,0,0,10q�6/   $��Stretch=�6A   .+�5#  .   �� $
��Left=�5$  1   $��Center=�5%  1   $��16(�5&  1   $
��Bold"�5'  1   #��[ 5(  1   ��5)  1     *PersonalOfficeYourReviews+�� 5*  .   $��10q�5+  1   $��Right=�5,  1   #��[ 5/  1   #��[ 50  1   ��5-  1   �� *ClearAllReviewsCommand+��5.  1     *" PersonalOfficeButtonClearReviews+	 51  1     *#!PersonalOfficeClearReviewsToolTip+52  +   � 54  *    55  .   �� 56  2   $��* �6@   �� 57  2   $
��Auto �6@   .+�5:  .   �� $��1��5;  1   $��	0,0,0,-10q�5<  1   $��Center=�5=  1   $��Bottom=�5>  1   $ 
Horizontal=�5?  1   ��5@  2   �� 5A  6    �� 
TargetType" ��6<   .�5B  :   ��  �� Property � y� �� Value$ Visible=�6W    �� Triggers 5C  :   �� 5D  >    �� Binding 6J   �� *UserReviews.Count+ �� Value 06p   .a�5E  B   ��  � y�$ 	Collapsed=�6_   5F  ?   5H  7   .+�5J  2   �� $��10q�5K  5     
IconButton#��[ 5M  5   
 � Tag# [ 5N  5   ��5L  5   �� *PrevReviewPageCommand+	 5O  5     *PrewPageToolTip+.��5P  6   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 	AngleLeft=�6C     iconButtonIcon#��[ 6T   5Q  3   �� 5R  2   $��5q�5S  5   $��Center=�5T  5   #��[ 5U  5   ��5V  5   �� *CurrentReviewPage+�� 5W  2   $��Center=�5X  5   #��[ 5Y  5   $	�� / ��5Z  5   �� 5[  2   $��5q�5\  5   $��Center=�5]  5   #��[ 5^  5   ��5_  5   �� *TotalReviewPages+�� 5`  2   $��10q�5a  5   #��[ 5c  5   # [ 5d  5   ��5b  5   �� *NextReviewPageCommand+	 5e  5     *NextPageToolTip+.��5f  6     $ 
AngleRight=�6C   #��[ 6U   5g  3   5h  /   �� 5j  .   $��0��5k  1   $	��300��5l  1   $
��Auto=�5m  1   .��5n  2   �� ��6?   �� *UserReviews+��5o  6   �� 5p  :   .R�5q  >   �� $��5q�5r  A   $ 10q�5s  A   #��[ 5t  A   $��1q�5u  A   $ 10��5v  A   ._�5x  B   � .+�5y  F   �� $
��Left=�6Q   .+�5{  J   �� $ 
Horizontal=�6U   .+�5|  N   �� $��16(�5}  Q   $
��Bold"�5~  Q   #��[ 5  Q   ��5�  Q   �� *MiniatureName+�� 5�  N   $��10,3,0,0q�5�  Q   $��13(�5�  Q   #��[ 5�  Q   ��5�  Q   �� *	CreatedAt+ �� StringFormat$  {0:dd.MM.yyyy HH:mm}��5�  K   �� 5�  J   $ 
Horizontal=�6U   .+�5�  N   �� $��14(�5�  Q   #��[ 5�  Q   ��5�  Q     *PersonalOfficeTextBlockRate+�� 5�  N   $��14(�5�  Q    
	 color6#��[	 5�  Q   ��5�  Q   �� *Rating+  5�  N   $��18��5�  Q   $��18��5�  Q   $��3,0,0,0q�5�  Q      
Foreground# [	 5�  Q   $
 Star=�5�  Q   #��[ 5�  Q   5�  K   �� 5�  J   $��15(�5�  M   #��[ 5�  M   $
��Wrap=�5�  M   ��5�  M   �� *	Comment+5�  M   5�  G   �� 5�  F   $ DeleteRevievButton��5�  I   $��15q�5�  I   $��Right=�5�  I   #��[ 5�  I   $ #c78c54��5�  I   ��5�  I   �� *!DataContext.DeleteReviewCommand+ ��  UserControl��5�  I   �� 	 5�  I     *" PersonalOfficeButtonDeleteReview+.��5�  J        Name$  MenuIcon��5�  M   $ Trash=�5�  M   #��[ 5�  M   5�  G   5�  C   5�  ?   5�  ;   5�  3   5�  /   �� 5�  .   $��Center=�5�  1   $��Center=�5�  1   $��16(�5�  1   $��SemiBold"�5�  1   #��[ 5�  1   ��5�  1     *PersonalOfficeDontHaveReviews+��5�  2   �� 5�  6   " ��6<   .�5�  :   ��  � y�$ 	Collapsed=�6W    5�  :   �� 5�  >    6J   �� *UserReviews.Count+ 06p   .a�5�  B   ��  � y�$ Visible=�6_   5�  ?   5�  7   5�  /   5�  +   5�  '   5�  #   5�     � 5�     $��4��6#   y�60   �� *IsActivitySelected+# [  .+�5�  "   �� $��1��5�  %   $��20q�5�  %   $ 10q�5�  %   #��[ 5�  %   #��[ 5�  %   $��2q�5�  %   $ 10��5�  %   ._�5�  &   �� .+�5�  *   � $��0,0,0,10q�6/   $��Stretch=�6A   .+�5�  .   �� $
��Left=�5�  1   $��Center=�5�  1   $��16(�5�  1   $
��Bold"�5�  1   #��[ 5�  1   ��5�  1     *%#PersonalOfficeTextBlockHistoryTitle+�� 5�  .   $	��200��5�  1   $��10q�5�  1   #��[ 5�  1   ��5�  1   �� *ActivityFilters+ 5�  1   �� *SelectedFilter+$ PropertyChanged=�5�  1   �� 5�  .   $��10q�5�  1   $��Right=�5�  1   #��[ 5�  1   #��[ 5�  1   ��5�  1   �� *ClearHistoryCommand+��5�  1     *" PersonalOfficeButtonClearHistory+	 5�  1     *POButtonClearHistoryToolTip+5�  +   � 5�  *    5�  .   �� 5�  2   $��* �6@   �� 5�  2   $
��Auto �6@   .+�5�  .   �� $��1��5�  1   $��	0,0,0,-10q�5�  1   $��Center=�5�  1   $��Bottom=�5�  1   $ 
Horizontal=�5�  1   ��5�  2   �� 5   6   " ��6<   .�5  :   ��  � y�$ Visible=�6W    5  :   �� 5  >    6J   �� *UserActivities.Count+ 06s   .a�5  B   ��  � y�$ 	Collapsed=�6_   5  ?   5  7   .+�5	  2   �� $��10q�5
  5   #��[ 5  5   # [ 5  5   ��5  5   �� *PrevActivityPageCommand+	 5  5     *PrewPageToolTip+.��5  6     $ 	AngleLeft=�6C   #��[ 6T   5  3   �� 5  2   $��5q�5  5   $��Center=�5  5   #��[ 5  5   ��5  5   �� *CurrentActivityPage+�� 5  2   $��Center=�5  5   #��[ 5  5   $	�� / ��5  5   �� 5  2   $��5q�5  5   $��Center=�5  5   #��[ 5  5   ��5  5   �� *TotalActivityPages+�� 5  2   $��10q�5   5   #��[ 5"  5   # [ 5#  5   ��5!  5   �� *NextActivityPageCommand+	 5$  5     *NextPageToolTip+.��5%  6     $ 
AngleRight=�6C   #��[ 6U   5&  3   5'  /   �� 5)  .   $��0��5*  1   $	��300��5+  1   $
��Auto=�5,  1   .��5-  2   �� ��6?   �� *UserActivities+��5.  6   �� 5/  :   .R�50  >   �� $��5q�51  A   $ 10q�52  A   #��[ 53  A   $��1q�54  A   $ 10��55  A   ._�56  B   � .+�57  F   �� .+�58  J   �� $ 
Horizontal=�6U   .+�59  N   �� $��16(�5:  Q   $
��Bold"�5;  Q   #��[ 5<  Q   ��5=  Q   �� *Action+�� 5>  N   $��10,3,0,0q�5?  Q   $��13(�5@  Q   #��[ 5A  Q   ��5B  Q   �� *	Timestamp+$  {0:dd.MM.yyyy HH:mm}��5C  K   �� 5D  J   $��15(�5E  M   #��[ 5F  M   $
��Wrap=�5H  M   ��5G  M   �� *	Details+5H  M   5I  G   �� 5K  F   $ DeleteHistoryButton��5L  I   $��15q�5M  I   $��Right=�5N  I   #��[ 5Q  I   $ #c78c54��5R  I   ��5O  I   �� *)'DataContext.DeleteSingleActivityCommand+ ��  UserControl��5P  I   �� 	 5S  I     *" PersonalOfficeButtonDeleteRecord+.��5T  J     $  MenuIcon��5U  M   $ Trash=�5V  M   #��[ 5W  M   5X  G   5Y  C   5Z  ?   5[  ;   5]  3   5^  /   �� 5`  .   $��Center=�5a  1   $��Center=�5b  1   $��16(�5c  1   $��SemiBold"�5d  1   #��[ 5e  1   ��5f  1     *PersonalOfficeDontHaveHistory+��5g  2   �� 5h  6   " ��6<   .�5i  :   ��  � y�$ 	Collapsed=�6W    5j  :   �� 5k  >    6J   �� *UserActivities.Count+ 06s   .a�5l  B   ��  � y�$ Visible=�6_   5m  ?   5o  7   5q  /   5r  +   5s  '   5t  #   5u     � 5x     $��4��6#   y�60   �� *IsFeedbackSelected+# [  .+�5y  "   �� $��20q�5z  %   $ 10q�5{  %   #��[ 5|  %   #��[ 5}  %   $��2q�5~  %   $ 10��5  %   ._�5�  &   �� .+�5�  *   � $��0,0,0,10q�6/   $��Stretch=�6A   .+�5�  .   �� $��	0,20,0,20q�5�  1   $
��Left=�5�  1   $��Center=�5�  1   $��16(�5�  1   $
��Bold"�5�  1   #��[ 5�  1   ��5�  1     *PersonalOfficeFeedbackTitle+5�  +   � 5�  *    5�  .   �� 5�  2   $��* �6@   �� 5�  2   $
��Auto �6@   .+�5�  .   �� $��0��5�  1   $	��300��5�  1   $
��Auto=�5�  1   .��5�  2   �� ��6?   �� *UserFeedbacks+��5�  6   �� 5�  :   .R�5�  >   �� $��5q�5�  A   $ 10q�5�  A   #��[ 5�  A   $��1q�5�  A   $ 10��5�  A   ._�5�  B   �  5�  F   �� 5�  J   $��* �6[   �� 5�  J   $
��Auto �6[   .+�5�  F   �� $��0��6Q   .+�5�  J   �� $ 
Horizontal=�6U   .+�5�  N   �� $��16(�5�  Q   $
��Bold"�5�  Q   #��[ 5�  Q   ��5�  Q   �� *
Username+�� 5�  N   $��10,3,0,0q�5�  Q   $��13(�5�  Q   #��[ 5�  Q   ��5�  Q   �� *SentAt+$  {0:dd.MM.yyyy HH:mm}��5�  K   �� 5�  J   $��14(�5�  M   
���������5�  M   �� *Email+�� 5�  J   $��14(�5�  M   $��SemiBold"�5�  M   #��[ 5�  M   ��5�  M   �� *
Category+�� 5�  J   $��15(�5�  M   #��[ 5�  M   $
��Wrap=�5�  M   ��5�  M   �� *	Message+5�  M   9� 5�  J   $��0,10,0,0q�5�  M   
������ $��13(�5�  M   $
��Bold"�5�  M   #��[ 5�  M   ��5�  M     *AdminResponse+y�5�  M   �� *AdminResponse+# [ .��5�  N   �� $��5,7,0,0q�5�  Q   $��13(�5�  Q   #��[ 5�  Q   $
��Wrap=�5�  Q   ��5�  Q   �� *AdminResponse+5�  Q   5�  K   5�  G   �� 5�  F   $��1��5�  I   $��15,0,0,0q�5�  I   $��Center=�5�  I   #��[ 5�  I   # [ 5�  I   ��5�  I   �� *#!DataContext.DeleteFeedbackCommand+ ��  UserControl��5�  I   �� 	 5�  I     *$"PersonalOfficeButtonDeleteFeedback+.��5�  J     $ Trash=�6W   #��[ 6d   5�  G   5�  C   5�  ?   5�  ;   5�  3   5�  /   �� 5�  .   $��1��5�  1   $��	0,0,0,-10q�5�  1   $��Center=�5�  1   $��Bottom=�5�  1   $ 
Horizontal=�5�  1   ��5�  2   �� 5�  6   " ��6<   .�5�  :   ��  � y�$ Visible=�6W    5�  :   �� 5�  >    6J   �� *UserFeedbacks.Count+ 06r   .a�5�  B   ��  � y�$ 	Collapsed=�6_   5�  ?   5�  7   .+�5�  2   �� $��10q�5�  5   #��[ 5�  5   # [ 5�  5   ��5�  5   �� *PrevFeedbackPageCommand+	 5�  5     *PrewPageToolTip+.��5�  6     $ 	AngleLeft=�6C   #��[ 6T   5�  3   �� 5   2   $��5q�5  5   $��Center=�5  5   #��[ 5  5   ��5  5   �� *CurrentFeedbackPage+�� 5  2   $��Center=�5  5   #��[ 5  5   $	�� / ��5  5   �� 5	  2   $��5q�5
  5   $��Center=�5  5   #��[ 5  5   ��5  5   �� *TotalFeedbackPages+�� 5  2   $��10q�5  5   #��[ 5  5   # [ 5  5   ��5  5   �� *NextFeedbackPageCommand+	 5  5     *NextPageToolTip+.��5  6     $ 
AngleRight=�6C   #��[ 6U   5  3   5  /   �� 5  .   $��0��5  1   $��Center=�5  1   $��Center=�5  1   $��16(�5  1   $��SemiBold"�5  1   #��[ 5  1   ��5   1     *!PersonalOfficeDontHaveFeedbacks+��5!  2   �� 5"  6   " ��6<   .�5#  :   ��  � y�$ 	Collapsed=�6W    5$  :   �� 5%  >    6J   �� *UserFeedbacks.Count+ 06r   .a�5&  B   ��  � y�$ Visible=�6_   5'  ?   5)  7   5+  /   5,  +   5-  '   5.  #   5/     51     52     53     54     55     56     57     