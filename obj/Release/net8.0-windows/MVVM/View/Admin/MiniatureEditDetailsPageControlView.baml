   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  ^    XA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.MiniatureEditDetailsPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � 	Resources  Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter   BoolToVisibilityConverterU   OA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.InverseBoolConverter  InverseBoolConverter  ValidationTemplate��%�   &	        &	      &	 
         �� .R�]� $
��True��.+��� $��5,0,0,0q�$��Right=�$��10(�
���  ��$��!���� .���  � RowDefinitions �� $��70 ��� $��* ��� $��80 � � ColumnDefinitions �� $	��320 ��� $��* �.+��� $��0��$��10q�$
��Left=�  
IconButton#��[   color11
 � Tag# [ ���� *BackToListCommand+ � ToolTip B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *ButtonBackToolTip+.��!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 	AngleLeft=�  iconButtonIcon#��[ �� $��0��$��1��$	��200��$��35��$��0,0,0,10q�
������  � Cursor$
 Hand�� �� SelectedValuePath$	 Tag��  ComboBoxStyle#��[  �� SelectedValue �� *$"SelectedMiniature.SelectedLanguage+	 �� Mode$	 TwoWay=�.@��� $��Українська��$ uk���� $��English��$ en��� $��1��$��1��$��10q� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��0,0,0,10q�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *SculptureName+�� $��0,5,0,0q�
������ #��[ $��0,0,0,2q�  titleColor1
 �� 
CaretBrush#
 [ $��24(�$
��Bold"�#��[  �� TextAlignment$ Center=� =� ErrorTemplate# [ ���� *SelectedMiniature.Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True���� $��1��$��
Montserrat)�$��12(�$��Medium"�
���������  *SculptureDescription+�� $��1��$��0,20,0,0q�#��[ $��2q� �� CornerRadius$ 10��._��� $
��Auto=�.���� $��10q� �� AcceptsReturn$
 True��
������ $��0q�#
 [ $��
Montserrat)�$��16(�$��Medium"�
������� �� TextWrapping$
 Wrap=�# [ " �� VerticalScrollBarVisibility$
 Auto=����� *SelectedMiniature.Description+$ PropertyChanged=�$
 True���� $��1��$��0,0,0,10q�$��Center=�$��Center=�.+��� $��14(�$
��Bold"�
��� �����  *Saving+y��� *
IsSaving+ �� 	Converter# [  � $	��200��$��6��$��0,5,0,0q�
��� ��� � IsIndeterminate$
 True��y��� *
IsSaving+# [  �� $��2��$��0,10,0,0q�$��Center=� �� Orientation$ 
Horizontal=�.+��� $	��150��$��45��$��10q�$
 Hand�� 
 button#��[ ���� *SaveCommand+��  *
ButtonSave+{��� *
IsSaving+# [ �� $	��150��$��45��$��10q�$
 Hand��
�������#��[ ���� *DeleteCommand+��  *PersonalOfficeButtonDelete+� $��1��$��2��$��0��$��10q� �� $	��250 ��� $��* �.+��� $��0��#��[ $��3q�$ 20��$
 Hand��   *ImageChange+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseLeftButtonUp��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2	  ,Microsoft.Xaml.Behaviors.InvokeCommandAction	   	  Command �� *ChangeImageCommand+����  j� Stretch$ UniformToFill=� �� ImageSource �� *SelectedMiniature.ImageSource+�� $��1��$��
10,10,10,0q�.+��� -    ��Name$ Button3DModel��$��0,5,0,0q�$
 Hand��$��
Montserrat)�$��15(�
������� 	 button3DModel#��[	 ���� *ChangeModelCommand+��  *Change3DModel+�� $��0��$��	0,10,0,10q�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *TextBlockLatitude+�� 
������ #��[ $��0,0,0,2q�#
 [ $��14(�#��[ # [ ���� *SelectedMiniature.Latitude+$ PropertyChanged=�$
 True���� $��0��$��0,5,0,10q�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *TextBlockLongitude+�� 
������ #��[ $��0,0,0,2q�#
 [ $��14(�#��[ # [ ���� *SelectedMiniature.Longitude+$ PropertyChanged=�$
 True��