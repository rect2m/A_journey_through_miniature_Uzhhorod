   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  5      q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      V    PA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditFeedbackPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        � 	Resources  5         BoolToVisibilityConverterZ   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToVisibilityConverter  NullToVisibilityConverterT   NA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToBoolConverter  NullToBoolConverter��%W   &	        &	      &	 &     �� 5   
   6'     5   
   6)     5   
   6#   5      .��5      � $��20q�6   .+�5   
   �� $��0,30,0,0q�5      $��Center=�5      $��Center=�5      $��16(�5      $��SemiBold"�5      
���������5      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *	NoMessage+y�5      �� *Feedbacks.Count+ �� 	Converter# [  �� 5    
   $
��Auto=�6   .��5!      �� ��6   �� *	Feedbacks+��5"      �� 5#      .R�5$      �� 5%      ��5'      �� 5(      .R�5*      �� $��0,0,0,15q�5+       �� Padding$ 15q�5,        panelOverColor#��[ 5-        color11#��[ 5.      $��1q�5/       �� CornerRadius$ 12��50      ._�51      �� .+�54   "   �� $��0,5,0,2q�55   %   $��
Montserrat)�56   %   $��12(�57   %   $��Medium"�58   %   
���������5:   %     *User+�� 5;   "    �� Orientation$ 
Horizontal=�6-   $��0,5,0,0q�6F   .+�5<   &   A� $��27��5=   )   $��27��5>   )   $��0,-5,0,0q�5?   )   ��5@   *   �� 5A   .    j� Stretch$ UniformToFill=�6]    �� ImageSource 69   �� *AvatarImage+6]   5C   '   �� 5E   &   $��5,-3,0,0q�5F   )   $��15(�5G   )   $��SemiBold"�5H   )     titleColor1#��[ 5I   )   ��5J   )   �� *
UserName+�� 5K   &   $��5,0,0,0q�5L   )   $��Right=�5M   )   $��12(�5N   )   #��[ 5O   )   ��5P   )   �� *Feedback.SentAt+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}��5Q   #   �� 5T   "   $��0,5,0,5q�5U   %   $��13(�5V   %   #��[ 5W   %   ��5X   %   �� *Feedback.Email+�� 5[   "   $��0,5,0,0q�5\   %   $��
Montserrat)�5]   %   $��12(�5^   %   $��Medium"�5_   %   
���������5a   %     *
Category+�� 5b   "   $��0,2,0,5q�5c   %   $��14(�5d   %   $��Medium"�5e   %   ��5f   %   �� *CategoryBrush+��5g   %   �� *Feedback.Category+�� 5k   "   $��0,5,0,0q�5l   %   $��
Montserrat)�5m   %   $��12(�5n   %   $��Medium"�5o   %   
���������5q   %     *	Message+�� 5r   "   $��0,2,0,5q�5s   %   $��16(�5t   %   #��[ 5u   %   $
��Wrap=�5w   %   ��5v   %   �� *Feedback.Message+5w   %   9� 5z   "   $��0,10,0,0q�5{   %   
������ $��13(�5}   %   $
��Bold"�5~   %   #��[ 5   %   ��5�   %     *AdminResponse+y�5�   %   �� *Feedback.AdminResponse+# [ .��5�   &   �� $��5,7,0,0q�5�   )   $��13(�5�   )   #��[ 5�   )   $
��Wrap=�5�   )   ��5�   )   �� *Feedback.AdminResponse+5�   )   5�   #   � 5�   "   $��0,10,0,0q�6'    � ColumnDefinitions 5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   .+�5�   &   �� $��0��5�   )   $��5q�5�   )   $��Center=�5�   )   	 �� AcceptsReturn$
	 True��5�   )   
������ #��[ 5�   )   $��0,0,0,2q�5�   )   $��13(�5�   )   #��[ 5�   )   
 �� TextWrapping$

 Wrap=�5�   )   " �� VerticalScrollBarVisibility$
 Auto=�5�   )   ��5�   )   �� *AdminReplyText+ �� UpdateSourceTrigger$ PropertyChanged=�5�   )   �� 5�   &   $��1��5�   )   $��10q�5�   )   $
��Left=�5�   )     
IconButton#��[ 5�   )   
 � Tag# [ 5�   )   ��5�   )   �� *SendReplyCommand+.��5�   *   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 
PaperPlane=�67     iconButtonIcon#��[ 6I   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      