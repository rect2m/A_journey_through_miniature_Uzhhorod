   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  5      q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5	      ^    XA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.MiniatureEditDetailsPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
        � 	Resources  5      Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter   BoolToVisibilityConverterU   OA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.InverseBoolConverter  InverseBoolConverter  ValidationTemplate��%�   &	        &	      &	 &       5   
   6)     5   
   6$   �� 5   
   .R�5      ]� $
��True��6   .+�5      �� $��5,0,0,0q�5      $��Right=�5      $��10(�5      
���  ��$��!��5      �� 5      5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $��70 �6   �� 5#      $��* �6   �� 5$      $��80 �6    � ColumnDefinitions 5'   
   �� 5(      $	��320 �6   �� 5)      $��* �6   .+�5-   
   �� $��0��5.      $��10q�5/      $
��Left=�50        
IconButton#��[ 52        color11
 � Tag# [ 53      ��51      �� *BackToListCommand+ � ToolTip 54      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *ButtonBackToolTip+.��55      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 	AngleLeft=�6     iconButtonIcon#��[ 6,   56      �� 59   
   $��0��5:      $��1��5;      $	��200��5<      $��35��5=      $��0,0,0,10q�5>      
������  � Cursor$
 Hand��5@       �� SelectedValuePath$	 Tag��5B        ComboBoxStyle#��[ 5C       �� SelectedValue 5A      �� *$"SelectedMiniature.SelectedLanguage+	 �� Mode$	 TwoWay=�.@�5D      �� $��Українська��6   $ uk��60   �� 5E      $��English��6   $ en��6-   5F      � 5I   
   $��1��5J      $��1��5K      $��10q�5L       5M      �� 5N      $
��Auto �6    �� 5O      $��* �6    �� 5P      $
��Auto �6    .+�5T      �� $��0��6   $��0,0,0,10q�6&   .+�5U      �� $��
Montserrat)�5V      $��12(�5W      $��Medium"�5X      
���������5Z        *SculptureName+�� 5[      $��0,5,0,0q�5\      
������ #��[ 5^      $��0,0,0,2q�5_        titleColor1
 �� 
CaretBrush#
 [ 5`      $��24(�5a      $
��Bold"�5b      #��[ 5c       �� TextAlignment$ Center=�5e       =� ErrorTemplate# [ 5f      ��5d      �� *SelectedMiniature.Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��5f      5g      �� 5i      $��1��5j      $��
Montserrat)�5k      $��12(�5l      $��Medium"�5m      
���������5o        *SculptureDescription+�� 5p      $��1��5q      $��0,20,0,0q�5r      #��[ 5s      $��2q�5t       �� CornerRadius$ 10��5u      ._�5v      �� $
��Auto=�6   .��5w      �� $��10q�5x       �� AcceptsReturn$
 True��5y      
������ $��0q�5{      #
 [ 5|      $��
Montserrat)�5}      $��16(�5~      $��Medium"�5      
������� �� TextWrapping$
 Wrap=�5�      # [ 5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      ��5�      �� *SelectedMiniature.Description+$ PropertyChanged=�$
 True��5�      5�      5�      �� 5�      $��1��5�      $��0,0,0,10q�5�      $��Center=�5�      $��Center=�5�      .+�5�      �� $��14(�5�      $
��Bold"�5�      
��� �����5�        *Saving+y�5�      �� *
IsSaving+ �� 	Converter# [  � 5�      $	��200��5�      $��6��5�      $��0,5,0,0q�5�      
��� ��� � IsIndeterminate$
 True��5�      y�5�      �� *
IsSaving+# [  5�      �� 5�      $��2��5�      $��0,10,0,0q�5�      $��Center=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� $	��150��5�      $��45��5�      $��10q�5�      $
 Hand��5�       
 button#��[ 5�      ��5�      �� *SaveCommand+��5�        *
ButtonSave+{�5�      �� *
IsSaving+# [ 5�      �� 5�      $	��150��5�      $��45��5�      $��10q�5�      $
 Hand��5�      
�������#��[ 5�      ��5�      �� *DeleteCommand+��5�        *PersonalOfficeButtonDelete+5�      5�      5�      � 5�   
   $��1��5�      $��2��5�      $��0��5�      $��10q�5�       5�      �� 5�      $	��250 �6    �� 5�      $��* �6    .+�5�      �� $��0��5�      #��[ 5�      $��3q�5�      $ 20��5�      $
 Hand��5�       5�        *ImageChange+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$ MouseLeftButtonUp��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�      2	  ,Microsoft.Xaml.Behaviors.InvokeCommandAction	   	  Command 60   �� *ChangeImageCommand+5�      ��5�      �� 5�       j� Stretch$ UniformToFill=�6W    �� ImageSource 6!   �� *SelectedMiniature.ImageSource+6W   5�      �� 5�      $��1��6   $��
10,10,10,0q�6&   .+�5�      �� -   5         ��Name$ Button3DModel��5�      $��0,5,0,0q�5�      $
 Hand��5�      $��
Montserrat)�5�      $��15(�5�      
������� 	 button3DModel#��[	 5�      ��5�      �� *ChangeModelCommand+��5�        *Change3DModel+5�      �� 5�      $��0��6   $��	0,10,0,10q�6*   .+�5�      �� $��
Montserrat)�5�      $��12(�5�      $��Medium"�5�      
���������5�        *TextBlockLatitude+�� 5�      
������ #��[ 5�      $��0,0,0,2q�5�      #
 [ 5�      $��14(�5�      #��[ 5�      # [ 5�      ��5�      �� *SelectedMiniature.Latitude+$ PropertyChanged=�$
 True��5�      5�      �� 5�      $��0��6   $��0,5,0,10q�6*   .+�5�      �� $��
Montserrat)�5�      $��12(�5�      $��Medium"�5�      
���������5�        *TextBlockLongitude+�� 5�      
������ #��[ 5�      $��0,0,0,2q�5      #
 [ 5     $��14(�5     #��[ 5     # [ 5     ��5     �� *SelectedMiniature.Longitude+$ PropertyChanged=�$
 True��5     5     5     5     5	     5
     