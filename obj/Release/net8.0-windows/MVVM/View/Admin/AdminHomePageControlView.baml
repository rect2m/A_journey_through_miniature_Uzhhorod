   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters  [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF q=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  S    MA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.AdminHomePageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     YconvHclr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  cliveXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � 	Resources  Z   TA_journey_through_miniature_Uzhhorod.MVVM.Model.Converters.BoolToVisibilityConverter   BoolToVisibilityConverter��%   &	          .��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��$��0,0,0,10q�$��Center=����� *	InfoCards+���� .R�� $��0q� K� IsItemsHost$
 True������ .R��� $	��220��$��10q� �� Padding$ 15q�  panelOverColor#��[   color11#��[ $��1q� �� CornerRadius$ 10��._�]� $��Center=�.+�!  FontAwesome.Sharp.IconImage  $��30��$��30��$��0,0,15,0q�$��Center=�$
��Left=��  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground
 �����   Icon �� *Icon+�� .+��� $��16(�$
��Bold"�
����������� *Title+�� $��18(�$��SemiBold"�
����������� *Value+� $��2�� � ColumnDefinitions �� $��* ��� $��* �.+�/  )LiveChartsCore.SkiaSharpView.WPF.PieChart  $��0��$	��600��$	��600��,  &LiveChartsCore.SkiaSharpView.WPF.Chart   LegendPosition$ Bottom=�	   Series	 �� *	PieSeries+�� $��1��$	��600��$��20q�$ 10q�#��[ #��[ $��1q�$ 10��._��  �� $
��Auto ��� $��* �.+��� $��0��$��0,0,0,10q�$��Center=�$��18(�$
��Bold"�
���������B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *LatestMessages+�� $��1��$��Center=�$��Center=�$��14(�$��Italic$�
���������  *	NoMessage+y��� *IsFeedbackEmpty+
 �� 	Converter#
 [  �� $��1��$	��600��$��0,5,0,0q�$��Disabled=�$
��Auto=�.���� ���� *FeedbackEntries+���� .R��� ���� .R��� $��0,0,0,10q�$ 10q�
������ #��[ $��1q�$ 10��._��  �� $
��Auto ��� $
��Auto ��� $��* �.+�]� $��0��$��0,0,0,5q�.+�A� $��24��$��24��$��0,-2,0,0q�����  j� Stretch$ UniformToFill=� �� ImageSource �� *AvatarImage+�� $��5,0,0,0q�$
��Bold"�  titleColor1#��[ ���� *
Username+�� $��10,0,0,0q�$��Right=�$��Right=�$��11(�#��[ ���� *	Timestamp+�� $��1��$��0,0,0,4q�$��14(�$��SemiBold"�
����������� *Title+�� $��2��$��60��$��13(�#��[ $��CharacterEllipsis=�$
��Wrap=����� *	Message+