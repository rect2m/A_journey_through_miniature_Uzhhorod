   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  5      e aMicrosoft.Web.WebView2.Wpf, Version=1.0.3124.44, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf 5
      G    AA_journey_through_miniature_Uzhhorod.MVVM.View.MapPageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      VwpfLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf  5
      
������ .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ SearchPanel��5      $��0��5      $��10q�5       K� ZIndex$	 150��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5"      �� $��1��5#      $	��250��5$      $
��Left=�5%       �� Orientation$ 
Horizontal=�5&      .+�5'      !  FontAwesome.Sharp.IconImage  $��0��5(      $��20��5)      $��20��5*      $��	10,0,10,0q�5+         titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [  5,         Icon$ Search=�5-      �� 5.      -   5         ��Name$ TextBoxSearch��5/      $	��250��50      $��35��51      $��5q�52      
������ 
�������$��0,0,0,2q�55       �� 
CaretBrush
 �����$��
Montserrat)�57      $��13(�58      $��Medium"�59      
�������	 � ToolTip	 5<      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TextBoxSearchToolTip+5=      5>      �� 5A   
   $��1��5B      $��10q�5C      $
��Left=�5D      $	 150��5E      $ 
Horizontal=�5F      .+�5G      �� $��1��5H      $��0,10,0,0q�5I      $��
Montserrat)�5J      $��16(�5K      $��Medium"�5L        titleColor1#��[ 5M      ��5N        *
From where+�� 5O      -   5        
 ��Name$
 ComboBoxFrom��5P      $	��200��5Q      $��	10,0,10,0q�5R        ComboBoxStyle#��[ 5S      �� 5T      $��1��5U      $��0,10,0,0q�5V      $��
Montserrat)�5W      $��16(�5X      $��Medium"�5Y      #��[ 5Z      ��5[        *	ToWhere+�� 5\      -   5        $
 
ComboBoxTo��5]      $	��200��5^      $��	10,0,10,0q�5_      #��[ 5`      �� 5a      -   5         
 button#��[ 5d      ��5c        *ButtonRoute+5d      �� 5e      -   5        $��10,0,0,0q�5f      #��[ 5i      ��5h        *ButtonClearRoute+5i      5j      )  #Microsoft.Web.WebView2.Wpf.WebView2  5m   
   -   5          Name$ WebMap��5n      $��2��5o      $��0,10,0,0q�5p      $ 0��5q      5r      5s      