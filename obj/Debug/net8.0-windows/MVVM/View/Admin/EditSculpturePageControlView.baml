   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      W    QA_journey_through_miniature_Uzhhorod.MVVM.View.Admin.EditSculpturePageControlView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      .��5      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5         �Name$ Search��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      !  FontAwesome.Sharp.IconImage  $��0��5       $��20��5!      $��20��5"      $��	40,0,10,0q�5#         titleColor2�  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground# [  5$         Icon$ Search=�5%      �� 5'      $��1��5(      $	��200��5)      $��28��5*      $��0,5,0,0q�5+      $��Center=�5,      
������ 
�������$��0,0,0,2q�5/       �� 
CaretBrush
 �����$��
Montserrat)�51      $��13(�52      $��Medium"�53      
���������55      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=��� 57      $��2��58      $��Center=�59      $��Center=�5:       �� Orientation$ 
Horizontal=�5;      .+�5<      �� $��Center=�5=      $��16(�5>      $
��Bold"�5?        titleColor1#��[ 5@       �� TextAlignment$ Center=�5B      $
��Wrap=�5C      ��5A      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *TotalMiniatures+5C      �� 5E      $��Center=�5F      $��16(�5G      $
��Bold"�5H      #��[ 5I      $ Center=�5K      $
��Wrap=�5L      ��5J      �� *TotalMiniaturesCount+5L      5M      �� 5O      $��3��5P      $	��160��5Q      $��50��5R      $��0,0,40,0q�5S      	 � Cursor$
	 Hand��5V       
 button#��[ 5W      ��5T      �� *OpenAddDetailsViewCommand+��5U        *AddSculpture+5W      5X      �� 5Z   
   $��1��6   $
��Auto=�6$   .��5[      � $��10q�6   $��Center=�6$   .+�5\      �� ��6   �� *PagedMiniatures+��5]      �� 5^      .R�5_      � 5`      ��5c      �� 5d      .R�5e      �� $	��220��5f   !   $��10q�5g   !   
 �� Padding$
 10q�5h   !     panelOverColor#��[ 5i   !     color11#��[ 5j   !   $��2q�5k   !    �� CornerRadius$ 10��5l   !   $
	 Hand��5m   !    J� RenderTransformOrigin$ 0.5,0.5&�5n   !   z�5p   "   �� 5q   &    �� ScaleX$ 1Q�65    �� ScaleY$ 1Q�6@   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5u   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5v   &      	EventName$ MouseLeftButtonUp��65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5w   *   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6@   �� *$"DataContext.OpenDetailsViewCommand+ �� RelativeSource ��  �� AncestorType UserControl   CommandParameter 6�   �� 5x   '    � Triggers 5{   "   :� 5}   &    :� RoutedEvent$ 
MouseEnter��63   .[�5~   *   �� .��5   .   �� .��5�   2   W�  �� TargetProperty$ RenderTransform.ScaleX�5�   5   	 W� To 1.15�   5    g� Duration$ 0:0:0.2D�5�   5   W� 5�   2   $ RenderTransform.ScaleY�5�   5    1.15�   5   $ 0:0:0.2D�5�   5   5�   /   5�   +   5�   '   :� 5�   &   $ 
MouseLeave��63   .[�5�   *   �� .��5�   .   �� .��5�   2   W� $ RenderTransform.ScaleX�5�   5    15�   5   $ 0:0:0.2D�5�   5   W� 5�   2   $ RenderTransform.ScaleY�5�   5    15�   5   $ 0:0:0.2D�5�   5   5�   /   5�   +   5�   '   ._�5�   "   �� .+�5�   &   �� $	��200��5�   )   $	��150��5�   )   $��5q�5�   )   $
��Fill=�5�   )   ��5�   )   �� *ImageSource+ J� Clip 5�   *   �� 5�   .    �� RadiusX$ 10Q�5�   1    �� RadiusY$ 10Q�5�   1    �� Rect$ 0,0,185,150�5�   1   5�   '   �� 5�   &   $��5q�5�   )   $��16(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   $ Center=�5�   )   $
��Wrap=�5�   )   ��5�   )   �� *Name+5�   )   5�   #   5�      5�      5�      5�      5�      �� 5�   
   $��2��5�      $��	0,0,0,-10q�5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� $��10q�5�      $
	 Hand��5�        
IconButton#��[ 5�      
 � Tag# [ 5�      ��5�      �� *PrevPageCommand+.��5�        $ 	AngleLeft=�6     iconButtonIcon#��[ 60   5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *CurrentPage+�� 5�      $��Center=�5�      #��[ 5�      $	�� / ��5�      �� 5�      $��5q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
TotalPages+�� 5�      $��10q�5�      $
	 Hand��5�      #��[ 5�      # [ 5�      ��5�      �� *NextPageCommand+.��5�        $ 
AngleRight=�6   #��[ 61   5�      5�      5�      5�      