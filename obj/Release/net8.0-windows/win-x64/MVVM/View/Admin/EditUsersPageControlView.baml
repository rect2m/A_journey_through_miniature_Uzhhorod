   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  S    MA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditUsersPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  .���� $��20q�  �� Padding$  10q�   panelOverColor#��[    color11#��[ $��2q� �� CornerRadius$ 10��._��  � RowDefinitions �� $��40 ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+�� $��1��$��
0,10,0,-10q� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��Center=�$��18(�$
��Bold"�  titleColor1#��[ ��B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *
Username+�� $��1��$��Center=�$��18(�$
��Bold"�#��[ ��  *Role+�� $��2��$��Center=�$��18(�$
��Bold"�#��[ ��  *Status+�� $��3��$��Center=�$��18(�$
��Bold"�#��[ ��  *	Actions+�� $��0��$
��Left=� �� Orientation$ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  $��20��$��20��$��	40,0,10,0q�  titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [    Icon$ Search=��� -    ��Name$ TextBoxSearch��$	��200��$��28��$��0,5,0,0q�$
��Left=�$��Center=�
������ 
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� *SearchQuery+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 � ToolTip
   *TextBoxSearchToolTip+�� $��0��$	��200��$��0,5,5,5q�$��Right=�  ComboBoxStyle#��[ ���� *UserFilters+ �� SelectedItem �� *SelectedFilter+$	 PropertyChanged=��� $��2��$��0,10,0,0q�$��10q�$
��Auto=�.���� ���� *Users+���� .R��� $��7q�$  	0,10,0,10q�#��[ $��1q�$ 10��._��  �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��Center=�$��Center=�$��18(�$
��Bold"�#��[ ���� *
Username+�� $��1��$��Center=�$��Center=�$��18(�$
��Bold"�#��[ ���� *Role+�� $��2��$��5,0,0,0q�$��Center=�$��Center=�$��18(�$
��Bold"�#��[ ���� *Status+�� $��3��$��5,0,0,0q�$��Center=�$ 
Horizontal=�.+��� $��5,0,0,0q�  
IconButton#��[ 
 � Tag# [ ���� *DataContext.ChangeRoleCommand+ �� RelativeSource ��  �� AncestorType UserControl���� 
   *
ChangeRole+.��  $ ArrowsRotate=�  iconButtonIcon#��[ �� $��5,0,0,0q�#��[ # [ ���� * DataContext.ToggleBlockCommand+ ��  UserControl���� 
   *ChangeStatus+.��  $	 Ban=�#��[ �� $��5,0,0,0q�#��[ # [ ���� *DataContext.DeleteUserCommand+ ��  UserControl���� 
   *ChangeStatus+.��  $ Trash=�#��[ �� $��3��$��0,10,0,0q�$��Center=�$ 
Horizontal=�.+��� #��[ # [ ���� *PrevPageCommand+
   *PrewPageToolTip+.��  $ 	AngleLeft=�#��[ �� $��5q�$��Center=�#��[ ���� *CurrentPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *
TotalPages+�� #��[ # [ ���� *NextPageCommand+
   *NextPageToolTip+.��  $ 
AngleRight=�#��[ �� $��2��$��Center=�$��Center=�$��16(�$��SemiBold"�#��[ ��  *	NoUsers+����  �� 
TargetType" ��.���  �� Property � y� �� Value$ 	Collapsed=� �� Triggers ��  �� Binding �� *Users.Count+ �� Value 0.a���  � y�$ Visible=�