   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  A    ;A_journey_through_miniature_Uzhhorod.MVVM.View._3DModelView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X THelixToolkit.Wpf, Version=2.26.0.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d$hhttp://helix-toolkit.org/wpf  Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � Title$*  $A_journey_through_miniature_Uzhhorod��$	��800��$	��450�� � AllowsTransparency$
 True��
������  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�.����    color11#��[  $��2q� �� CornerRadius$ 12������  �� 
StartPoint$	 1,1&� �� EndPoint$	 0,0&�.���  � Offset$ 1Q�  primaryBackColor1	 � Color#	 [ � $
 0.25Q�  primaryBackColor2#	 [ ._�� 
 � RowDefinitions
 �� $��35 ��� .+�� -   $��0��$��35��.+��� $��15,0,0,0q�$��Center=�$
��Bold"�  titleColor1#��[ $&�� Перегляд 3D моделі���� -    ��Name$ ButtonClose��$��2��$��0,0,5,0q�$��Right=�  buttonClose#��[ $��0q�$��X�� � Cursor$
 Hand��$��
Montserrat)�$��12(�
�������  ControlBarButton2#��[ A� $��1��$	��170��$	��170��$��
228,0,0,36q�$
��Left=�$��Bottom=�
������� J� Opacity$
 0.05Q�� $��1��$��-93,-258,0,0q�$
��Left=�$	��Top=�
�������$
 0.04Q� � Points' �    �� �������� �� ��A� $��1��$	��200��$	��200��$��
0,42,-98,0q�$��Right=�$	��Top=�$	 0.3Q���
� .��� $	 0.2Q�$	 	Goldenrod��� $ 1Q�$	 Transparent��� -    �Name$ LoadingOverlay��$��1�� K� ZIndex$ 99�����	#AA000000$y�	Collapsed=�.+��� $��Center=�$��Center=�.+�� $	��200��$��20�� � IsIndeterminate$
 True���� $��10q�$��Center=�
�������$.��(Завантаження моделі...��&   HelixToolkit.Wpf.HelixViewport3D  -   $��viewPort��$��1��   Camera =� -   
mainCamera�� =� FieldOfView$ 45Q� � LookDirection$ 0 0 -15� � Position$ 0 0 101� � UpDirection$ 0 1 05�   Children.   HelixToolkit.Wpf.SunLight  