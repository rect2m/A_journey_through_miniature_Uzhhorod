   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  e aMicrosoft.Web.WebView2.Wpf, Version=1.0.3124.44, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf G    AA_journey_through_miniature_Uzhhorod.MVVM.View.MapPageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  VwpfLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf  
������ .���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $��* �.+�� -    �Name$ SearchPanel��$��0��$��10q� K� ZIndex$	 150�� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��1��$	��250��$
��Left=� �� Orientation$ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  $��0��$��20��$��20��$��	10,0,10,0q�   titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [     Icon$ Search=��� -    ��Name$ TextBoxSearch��$	��250��$��35��$��5q�
������ 
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
�������	 � ToolTip	 B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TextBoxSearchToolTip+�� $��1��$��10q�$
��Left=�$	 150��$ 
Horizontal=�.+��� $��1��$��0,10,0,0q�$��
Montserrat)�$��16(�$��Medium"�  titleColor1#��[ ��  *
From where+�� -   
 ��Name$
 ComboBoxFrom��$	��200��$��	10,0,10,0q�  ComboBoxStyle#��[ �� $��1��$��0,10,0,0q�$��
Montserrat)�$��16(�$��Medium"�#��[ ��  *	ToWhere+�� -   $
 
ComboBoxTo��$	��200��$��	10,0,10,0q�#��[ �� -    
 button#��[ ��  *ButtonRoute+�� -   $��10,0,0,0q�#��[ ��  *ButtonClearRoute+)  #Microsoft.Web.WebView2.Wpf.WebView2  -     Name$ WebMap��$��2��$��0,10,0,0q�$ 0��