   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  R    LA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditHelpPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Mloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� $��20q�  � RowDefinitions  �� $��40 ��� $��* ��� $
��Auto �.+��� $	��200��$��0,0,0,10q�   panelOverColor#��[   �� DisplayMemberPath$ Content�� �� SelectedItem$ Українська�� �� SelectedValuePath$	 Tag��  ComboBoxStyle#��[  �� SelectedValue �� *CurrentLanguageCode+ �� Mode$ TwoWay=�.@��� $��Українська��
 � Tag$ uk���� $��English��$ en���� $��1��#��[    color11#��[ $��2q� �� CornerRadius$ 10��._��� $��10q� �� AcceptsReturn$
 True��
������ $��0q�  titleColor1	 �� 
CaretBrush#	 [ $��
Montserrat)�$��16(�$��Medium"�
�������
 �� TextWrapping$

 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *
HelpText+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$��0,10,0,0q�$��Center=� 
 button#��[ ���� *SaveCommand+��B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *
ButtonSave+