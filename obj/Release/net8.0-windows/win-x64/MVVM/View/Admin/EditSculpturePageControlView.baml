   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  W    QA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditSculpturePageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  .���   � RowDefinitions  �� $��50 ��� $��* ��� $
��Auto �.+�� -    �Name$ Search�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�!  FontAwesome.Sharp.IconImage  $��0��$��20��$��20��$��	40,0,10,0q�   titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [     Icon$ Search=��� $��1��$	��200��$��28��$��0,5,0,0q�$��Center=�
������ 
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
����������� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$��Center=�$��Center=� �� Orientation$ 
Horizontal=�.+��� $��Center=�$��16(�$
��Bold"�  titleColor1#��[  �� TextAlignment$ Center=�$
��Wrap=���B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TotalMiniatures+�� $��Center=�$��16(�$
��Bold"�#��[ $ Center=�$
��Wrap=����� *TotalMiniaturesCount+�� $��3��$	��160��$��50��$��0,0,40,0q�	 � Cursor$
	 Hand�� 
 button#��[ ���� *OpenAddDetailsViewCommand+��  *AddSculpture+�� $��1��$
��Auto=�.��� $��10q�$��Center=�.+��� ���� *PagedMiniatures+���� .R�� ���� .R��� $	��220��$��10q�
 �� Padding$
 10q�  panelOverColor#��[   color11#��[ $��2q� �� CornerRadius$ 10��$
	 Hand�� J� RenderTransformOrigin$ 0.5,0.5&�z���  �� ScaleX$ 1Q� �� ScaleY$ 1Q�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseLeftButtonUp��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *$"DataContext.OpenDetailsViewCommand+ �� RelativeSource ��  �� AncestorType UserControl   CommandParameter ��  � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W�  �� TargetProperty$ RenderTransform.ScaleX�	 W� To 1.1 g� Duration$ 0:0:0.2D�W� $ RenderTransform.ScaleY� 1.1$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ RenderTransform.ScaleX� 1$ 0:0:0.2D�W� $ RenderTransform.ScaleY� 1$ 0:0:0.2D�._��� .+��� $	��200��$	��150��$��5q�$
��Fill=����� *ImageSource+ J� Clip ��  �� RadiusX$ 10Q� �� RadiusY$ 10Q� �� Rect$ 0,0,185,150��� $��5q�$��16(�$
��Bold"�#��[ $ Center=�$
��Wrap=����� *Name+�� $��2��$��	0,0,0,-10q�$��Center=�$ 
Horizontal=�.+��� $��10q�$
	 Hand��  
IconButton#��[ 
 � Tag# [ ���� *PrevPageCommand+.��  $ 	AngleLeft=�  iconButtonIcon#��[ �� $��5q�$��Center=�#��[ ���� *CurrentPage+�� $��Center=�#��[ $	�� / ���� $��5q�$��Center=�#��[ ���� *
TotalPages+�� $��10q�$
	 Hand��#��[ # [ ���� *NextPageCommand+.��  $ 
AngleRight=�#��[ 