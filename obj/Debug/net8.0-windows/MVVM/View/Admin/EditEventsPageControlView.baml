   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  5      q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      T    NA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditEventsPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        � 	Resources  5      Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToVisibilityConverter   NullToVisibilityConverterZ   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter��%:   &	        &	        5   
   6)     5   
   6)   5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      � -   5         �Name$ Search��5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5       $
��Auto �6'   �� 5!      $��* �6'   �� 5"      $
��Auto �6'   .+�5%      !  FontAwesome.Sharp.IconImage  $��0��5&      $��20��5'      $��20��5(      $��	40,0,10,0q�5)        titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [ 5*         Icon$ Search=�5+      �� 5-      -   5         ��Name$ TextBoxSearch��5.      $��1��5/      $	��200��50      $��28��51      $��0,5,0,0q�52      $
��Left=�53      $��Center=�54      
������ 
�������$��0,0,0,2q�57       �� 
CaretBrush
 �����$��
Montserrat)�59      $��13(�5:      $��Medium"�5;      
���������5=      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�	 � ToolTip	 5>      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *EventTextBoxSearchToolTip+�� 5@      $��3��5A      $	��160��5B      $��50��5C      $��0,0,40,0q�5D      
 � Cursor$

 Hand��5G       
 button#��[ 5H      ��5E      �� *OpenAddDetailsViewCommand+��5F        *
AddEvent+5H      5I      �� 5K      $��1��5L      $��0,5,0,0q�5M      $
��Auto=�5N      .��5O      �� $��20q�6   ��6+   �� *Events+��5P      �� 5Q      .R�5R      �  5S   "   �� 5T   &   $��60 �67   �� 5U   &   $��* �67   .+�5X   "   �� $��0��5Y   %   $��4��5Z   %     color11#��[ 5[   %   A� 5]   "   $��0��5^   %   $��22��5_   %   $��22��5`   %   $��0,0,0,15q�5a   %   $��Center=�5b   %   $��Center=�5c   %   #��[ 5d   %   
�������$��3��5f   %    J� Effect 5g   &   3  -System.Windows.Media.Effects.DropShadowEffect  5h   *      
BlurRadius$ 10Q�5i   -      Opacity$	 0.3Q�5j   -      Color$ Black��5k   -   5m   #   �� 5o   "   $��1��5p   %   $��
10,5,10,20q�5q   %   $��15q�5r   %     panelOverColor#��[ 5s   %   #��[ 5t   %   $��1q�5u   %   $

 Hand��5x   %   ��5v   %   �� * DataContext.SelectEventCommand+ �� RelativeSource ��  �� AncestorType UserControl��5w   %   �� ��5y   &   �� 5z   *    �� 
TargetType" ��6:   .R�5{   .   ��  �� Padding# z��5|   1   #��z��5}   1   #��z��5~   1   #��z��5   1    �� CornerRadius$ 12��5�   1   ._�5�   2   �� 5�   /   5�   +   .��5�   &   �� .+�5�   *   �� $��18(�5�   -   $
��Bold"�5�   -     titleColor1#��[ 5�   -   $
��Wrap=�5�   -   ��5�   -   �� *Title+5�   -   �� 5�   *   $
��Left=�5�   -   $��Center=�5�   -    �� Orientation$ 
Horizontal=�5�   -   .+�5�   .   �� $��14(�5�   1   #��[ 5�   1   ��5�   1     *	EventDate+�� 5�   .   $��14(�5�   1   #��[ 5�   1   ��5�   1   �� *	EventDate+5�   +   �� 5�   *   $��14(�5�   -   #��[ 5�   -   $
��Wrap=�5�   -   ��5�   -   �� *Description+5�   -   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��2��5�      $��	0,0,0,-10q�5�      $��Center=�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $��10q�5�        
IconButton#��[ 5�      
 � Tag# [ 5�      ��5�      �� *PrevPageCommand+	 5�        *PrewPageToolTip+.��5�        $ 	AngleLeft=�6#     iconButtonIcon#��[ 64   5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *CurrentPage+�� 5�      $��Center=�5�      #��[ 5�      $	�� / ��5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
TotalPages+�� 5�      $��10q�5�      #��[ 5�      # [ 5�      ��5�      �� *NextPageCommand+	 5�        *NextPageToolTip+.��5�        $ 
AngleRight=�6#   #��[ 65   5�      5�      5�      �� 5�   
   $	��500��5�      $��
0,20,20,20q�5�      $ 20q�5�      $��Right=�5�      $��Stretch=�5�       K� ZIndex$ 10��5�      #��[ 5�      #��[ 5�      $��1q�5�      $ 12��5�      y�5�      �� *IsPanelOpen+ �� 	Converter# [ ._�5�      �� .��5�      �� .+�5�      �� $��Right=�5�      $

 Hand��5�      #��[ 5�       	 buttonClose# [	 5�      ��5�      �� *DeselectEventCommand+.��5�        $ Xmark=�6'   #��[ 64   5�      �� 5�      $	��200��5�      $��0,0,0,10q�5�      #��[ 5�       �� DisplayMemberPath$ Content��5�       �� SelectedValuePath$	 Tag��5�       
 ComboBoxStyle#��[
 5�       �� SelectedValue 5�      �� *SelectedLanguage+ �� Mode$ TwoWay=�.@�5�      �� $��Українська��6'   $ uk��6<   �� 5�      $��English��6'   $ en��69   5�      �� 5�      $��0,0,0,10q�6!   .+�5�      �� $��
Montserrat)�5�      $��12(�5�      $��Medium"�5�      
���������5       *Title+�� 5     -   5        $��0,5,0,0q�5     
������ #��[ 5     $��0,0,0,2q�5     # [ 5     $��20(�5     $
��Bold"�5	     #��[ 5
      �� TextAlignment$ Center=�5      �� TextWrapping$
 Wrap=�5     ��5     �� *SelectedTranslation.Title+$ PropertyChanged=�5     5     �� 5     $��
Montserrat)�5     $��12(�5     $��Medium"�5     
���������5       *Description+�� 5     $��0,20,0,0q�5     #��[ 5     $��2q�5     $ 10��5     ._�5     �� $
��Auto=�6'   .��5     �� -   5        $��10q�5  !    �� AcceptsReturn$
 True��5  !   
������ $��0q�5!  !   # [ 5"  !   $��
Montserrat)�5#  !   $��16(�5$  !   $��Medium"�5%  !   
�������$
 Wrap=�5)  !   " �� VerticalScrollBarVisibility$
 Auto=�5*  !   ��5(  !   �� *!SelectedTranslation.Description+$ PropertyChanged=�5*  !   5+     5,     (  "System.Windows.Controls.DatePicker  5.     $��0,20,0,0q�5/     
������ #��[ 51     $��0,0,0,2q�52     $��
Montserrat)�53     $��16(�54     $��Medium"�55     #��[ 56         SelectedDate  57     �� *SelectedEvent.EventDate+$ PropertyChanged=�  58     :  4System.Windows.Controls.Primitives.DatePickerTextBox! �� 
TargetType" �� Property# �� Value��%  '        7  �� 59     "!  6$   .�5:  "   �� " � ��
# ���� 6?   �� 5;  "   " � ��$# 0q�6D   �� 5<  "   " � ��8#   6?   �� 5=  "   " � ��$# 
Montserrat)�6?   �� 5>  "   " � ��$# 16(�6=   �� 5?  "   " � ��$# 4q�6<   5@     5A     5B     �� 5E     $��0,20,0,0q�5F     $��Center=�5G     $ 
Horizontal=�5H     .+�5J     �� $	��150��5K     $��45��5L     $��10q�5M     $

 Hand��5Q     
�������#��[ 5S     ��5N     �� *SaveCurrentEventCommand+��5O     �� *SelectedEvent+��5P       *
ButtonSave+5S     �� 5U     $	��150��5V     $��45��5W     $��10q�5X     $

 Hand��5\     
�������#��[ 5^     ��5Y     �� *DeleteEventCommand+��5Z     �� *SelectedEvent+��5[       *PersonalOfficeButtonDelete+y�5_     �� *CanDeleteSelectedEvent+# [ 5`     5c     5d     5e     5f     5g     