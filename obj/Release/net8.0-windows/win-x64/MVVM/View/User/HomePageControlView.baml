   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  H    BA_journey_through_miniature_Uzhhorod.MVVM.View.HomePageControlView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Mloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� .+��� $
��Auto=�.��� $��20q�  � RowDefinitions  �� $��* ��� $��* �.+��� $��0��.+��� $��
10,20,0,10q�$��20(�$
��Bold"�   titleColor1#��[  ��B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *HomeTitleEvents+�� $��10q� �� Padding$ 10q�  panelOverColor#��[   color11#��[ $��2q� �� CornerRadius$ 10��._��� .+��� $��22(�$
��Bold"�#��[  ���� *RandomEvent.Title+�� $
��Left=�$��Center=� �� Orientation$ 
Horizontal=�.+��� $��20(�#��[  ��  *RandomEventDate+�� $��20(�#��[  ���� *RandomEvent.EventDate+�� $��20(�#��[  $
��Wrap=����� *RandomEvent.Description+�� $��1��$��10q�$ 10q�#��[ #��[ $��2q�$ 10��._�� .+�A� $	��150��$	��150��$��
0,42,-98,0q�$
��Left=�$	��Top=� J� Opacity$	 0.3Q���
� .���  � Offset$	 0.2Q� � Color$ 	Goldenrod��� $ 1Q�$ Transparent��� $��
0,-40,20,0q�$��Right=�$	��Top=�
�������$
 0.04Q� � Points' �   ��� '������ �� ��� $��0,170,180,0q�$��Center=�$��Center=�
�������$
 0.04Q�' �    �� �������� �� ���� $��0,20,0,0q�$��Center=�$��20(�$
��Bold"�#��[  ��  *HomeTitleSculptures+(� $
��1000��$	��700��$��Center=�$��Bottom=� (� Stretch$ Uniform=�.��� $��Stretch=�$��Bottom=�	 � ColumnDefinitions	 �� $��1* ��� $��1* ��� $��1* �.+��� $��3��$	��900��$��80��$��	0,0,0,-10q�$��Bottom=�$ 10������ 
 �� 
StartPoint$	
 0,1&� �� EndPoint$ 1,0.3&�.��� $	 0.0Q�  colorThirdPlace# [ � $	 0.5Q�  colorFirstPlace# [ � $	 1.0Q�  colorSecondPlace# [ �� $��0��$��0,0,0,70q�$��Center=�$��Bottom=�.+��� -   $��0q�
������ $��0q�  NoHighlightButtonStyle#��[ 
 � Tag �� *TopRatedMiniatures[2]+.���� $	��200��$	��180��$��
15,0,0,-10q� J� RenderTransformOrigin$ 0.5,0.5&�$
��Fill=����� *#!TopRatedMiniatures[2].ImageSource+ J� Clip ��  �� RadiusX$ 10Q� �� RadiusY$ 10Q� �� Rect$ 0,0,185,150�z���  �� ScaleX$ 1Q� �� ScaleY$ 1Q� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W�  �� TargetProperty$- 'RenderTransform.(ScaleTransform.ScaleX)�	 W� To 1.1 g� Duration$ 0:0:0.2D�W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1.1$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)� 1$ 0:0:0.2D�W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1$ 0:0:0.2D��� $��0,0,0,10q�$��16(�$
��Bold"�#��[   �� TextAlignment$ Center=����� *TopRatedMiniatures[2].Name+�� $	��200��$��60�� 
 color4#��[ $ 	10,10,0,0��._��� $��Center=�$��Center=�$��20(�$
��Bold"�
�������$��3���� $��1��$��0,0,0,70q�$��Center=�$��Bottom=�.+��� -   $��0q�
������ $��0q�#��[  �� *TopRatedMiniatures[0]+.���� $	��220��$	��200��$��
15,0,0,-10q�$ 0.5,0.5&�$
��Fill=����� *#!TopRatedMiniatures[0].ImageSource+ �� $ 10Q�$ 10Q�$ 0,0,205,170�z��� $ 1Q�$ 1Q� :� $ 
MouseEnter��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)� 1.1$ 0:0:0.2D�W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1.1$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)� 1$ 0:0:0.2D�W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1$ 0:0:0.2D��� $��0,0,0,10q�$��16(�$
��Bold"�#��[  $ Center=����� *TopRatedMiniatures[0].Name+�� $	��220��$	��130�� 
 color6#��[ $ 	10,10,0,0��._��� $��Center=�$��Center=�$��22(�$
��Bold"�
�������$��1���� $��2��$��0,0,0,70q�$��Center=�$��Bottom=�.+��� -   $��0q�
������ $��0q�#��[  �� *TopRatedMiniatures[1]+.���� $	��200��$	��180��$��
15,0,0,-10q�$ 0.5,0.5&�$
��Fill=����� *#!TopRatedMiniatures[1].ImageSource+ �� $ 10Q�$ 10Q�$ 0,0,185,150�z��� $ 1Q�$ 1Q� :� $ 
MouseEnter��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)� 1.1$ 0:0:0.2D�W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1.1$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)� 1$ 0:0:0.2D�W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1$ 0:0:0.2D��� $��0,0,0,10q�$��16(�$
��Bold"�#��[  $ Center=����� *TopRatedMiniatures[1].Name+�� $	��200��$��90�� 
	 color3#��[	 $ 	10,10,0,0��._��� $��Center=�$��Center=�$��20(�$
��Bold"�
�������$��2��