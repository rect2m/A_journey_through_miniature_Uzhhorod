   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      R    LA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditHelpPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Mloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � $��20q�6     � RowDefinitions  5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $	��200��5      $��0,0,0,10q�5         panelOverColor#��[  5       �� DisplayMemberPath$ Content��5       �� SelectedItem$ Українська��5       �� SelectedValuePath$	 Tag��5        ComboBoxStyle#��[ 5       �� SelectedValue 5      �� *CurrentLanguageCode+ �� Mode$ TwoWay=�.@�5      �� $��Українська��6   
 � Tag$ uk��60   �� 5      $��English��6   $ en��6-   5      �� 5    
   $��1��5!      #��[  5"        color11#��[ 5#      $��2q�5$       �� CornerRadius$ 10��5%      ._�5&      �� $��10q�5'       �� AcceptsReturn$
 True��5(      
������ $��0q�5*        titleColor1	 �� 
CaretBrush#	 [ 5+      $��
Montserrat)�5,      $��16(�5-      $��Medium"�5.      
�������
 �� TextWrapping$

 Wrap=�51      " �� VerticalScrollBarVisibility$
 Auto=�52      ��50      �� *
HelpText+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�52      53      �� 55   
   $��2��56      $��0,10,0,0q�57      $��Center=�58       
 button#��[ 5;      ��59      �� *SaveCommand+��5:      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *
ButtonSave+5;      5<      5=      