   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  T    NA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditEventsPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � 	Resources  Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.NullToVisibilityConverter   NullToVisibilityConverterZ   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter��%   &	        &	          .��� .+��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�� -    �Name$ Search�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�!  FontAwesome.Sharp.IconImage  $��0��$��20��$��20��$��	40,0,10,0q�  titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [    Icon$ Search=��� -    ��Name$ TextBoxSearch��$��1��$	��200��$��28��$��0,5,0,0q�$
��Left=�$��Center=�
������ 
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�	 � ToolTip	 B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *EventTextBoxSearchToolTip+�� $��3��$	��160��$��50��$��0,0,40,0q�
 � Cursor$

 Hand�� 
 button#��[ ���� *OpenAddDetailsViewCommand+��  *
AddEvent+�� $��1��$��0,5,0,0q�$
��Auto=�.���� $��20q����� *Events+���� .R��  �� $��60 ��� $��* �.+��� $��0��$��4��  color11#��[ A� $��0��$��22��$��22��$��0,0,0,15q�$��Center=�$��Center=�#��[ 
�������$��3�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Opacity$	 0.3Q�   Color$ Black���� $��1��$��
10,5,10,20q�$��15q�  panelOverColor#��[ #��[ $��1q�$

 Hand������ * DataContext.SelectEventCommand+ �� RelativeSource ��  �� AncestorType UserControl���� ����  �� 
TargetType" ��.R���  �� Padding# z��#��z��#��z��#��z�� �� CornerRadius$ 12��._��� .���� .+��� $��18(�$
��Bold"�  titleColor1#��[ $
��Wrap=����� *Title+�� $
��Left=�$��Center=� �� Orientation$ 
Horizontal=�.+��� $��14(�#��[ ��  *	EventDate+�� $��14(�#��[ ���� *	EventDate+�� $��14(�#��[ $
��Wrap=����� *Description+�� $��2��$��	0,0,0,-10q�$��Center=�$��Bottom=�$ 
Horizontal=�.+��� $��10q�  
IconButton#��[ 
 � Tag# [ ���� *PrevPageCommand+	   *PrewPageToolTip+.��  $ 	AngleLeft=�  iconButtonIcon#��[ �� $��5q�$��Center=�#��[ ���� *CurrentPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *
TotalPages+�� $��10q�#��[ # [ ���� *NextPageCommand+	   *NextPageToolTip+.��  $ 
AngleRight=�#��[ �� $	��500��$��
0,20,20,20q�$ 20q�$��Right=�$��Stretch=� K� ZIndex$ 10��#��[ #��[ $��1q�$ 12��y��� *IsPanelOpen+ �� 	Converter# [ ._��� .���� .+��� $��Right=�$

 Hand��#��[  	 buttonClose# [	 ���� *DeselectEventCommand+.��  $ Xmark=�#��[ �� $	��200��$��0,0,0,10q�#��[  �� DisplayMemberPath$ Content�� �� SelectedValuePath$	 Tag�� 
 ComboBoxStyle#��[
  �� SelectedValue �� *SelectedLanguage+ �� Mode$ TwoWay=�.@��� $��Українська��$ uk���� $��English��$ en���� $��0,0,0,10q�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *Title+�� -   $��0,5,0,0q�
������ #��[ $��0,0,0,2q�# [ $��20(�$
��Bold"�#��[  �� TextAlignment$ Center=� �� TextWrapping$
 Wrap=����� *SelectedTranslation.Title+$ PropertyChanged=��� $��
Montserrat)�$��12(�$��Medium"�
���������  *Description+�� $��0,20,0,0q�#��[ $��2q�$ 10��._��� $
��Auto=�.���� -   $��10q� �� AcceptsReturn$
 True��
������ $��0q�# [ $��
Montserrat)�$��16(�$��Medium"�
�������$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *!SelectedTranslation.Description+$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  $��0,20,0,0q�
������ #��[ $��0,0,0,2q�$��
Montserrat)�$��16(�$��Medium"�#��[     SelectedDate  �� *SelectedEvent.EventDate+$ PropertyChanged=�  :  4System.Windows.Controls.Primitives.DatePickerTextBox! �� 
TargetType" �� Property# �� Value��%�   '        7  �� "!  .��� " � ��
# ���� �� " � ��$# 0q��� " � ��8#   �� " � ��$# 
Montserrat)��� " � ��$# 16(��� " � ��$# 4q��� $��0,20,0,0q�$��Center=�$ 
Horizontal=�.+��� $	��150��$��45��$��10q�$

 Hand��
�������#��[ ���� *SaveCurrentEventCommand+���� *SelectedEvent+��  *
ButtonSave+�� $	��150��$��45��$��10q�$

 Hand��
�������#��[ ���� *DeleteEventCommand+���� *SelectedEvent+��  *PersonalOfficeButtonDelete+y��� *CanDeleteSelectedEvent+# [ 