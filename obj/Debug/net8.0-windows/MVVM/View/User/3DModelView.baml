   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  5      A    ;A_journey_through_miniature_Uzhhorod.MVVM.View._3DModelView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X THelixToolkit.Wpf, Version=2.26.0.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d$hhttp://helix-toolkit.org/wpf  5      Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$*  $A_journey_through_miniature_Uzhhorod��5	      $	��800��5
      $	��450��5       � AllowsTransparency$
 True��5      
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      ��    color11#��[  5   	   $��2q�5   	    �� CornerRadius$ 12��5   	   ��5   
   �� 5       �� 
StartPoint$	 1,1&�6"    �� EndPoint$	 0,0&�63   .��5      �  � Offset$ 1Q�6     primaryBackColor1	 � Color#	 [ 6*   � 5      $
 0.25Q�6     primaryBackColor2#	 [ 6-   5      ._�5   
   � 
 � RowDefinitions
 5      �� 5       $��35 �6    �� 5!      .+�5%      � -   5        $��0��5&      $��35��5'      .+�5)      �� $��15,0,0,0q�5*      $��Center=�5+      $
��Bold"�5,        titleColor1#��[ 5-      $&�� Перегляд 3D моделі��5.      �� 5/      -   5         ��Name$ ButtonClose��50      $��2��51      $��0,0,5,0q�52      $��Right=�53        buttonClose#��[ 54      $��0q�55      $��X��57       � Cursor$
 Hand��58      $��
Montserrat)�59      $��12(�5:      
�������  ControlBarButton2#��[ 5<      5=      A� 5?      $��1��5@      $	��170��5A      $	��170��5B      $��
228,0,0,36q�5C      $
��Left=�5D      $��Bottom=�5E      
������� J� Opacity$
 0.05Q�5G      � 5I      $��1��5J      $��-93,-258,0,0q�5K      $
��Left=�5L      $	��Top=�5M      
�������$
 0.04Q�5O       � Points' �    �� �������� �� ��5P      A� 5R      $��1��5S      $	��200��5T      $	��200��5U      $��
0,42,-98,0q�5V      $��Right=�5W      $	��Top=�5X      $	 0.3Q�5Y      ��5Z      
� 5[      .��5\      � $	 0.2Q�6'   $	 	Goldenrod��64   � 5]      $ 1Q�6'   $	 Transparent��62   5^      5`      � 5b      -   5         �Name$ LoadingOverlay��5c      $��1��5d       K� ZIndex$ 99��5e      ���	#AA000000$y�	Collapsed=�5g      .+�5h      �� $��Center=�6   $��Center=�6:   .+�5i      � $	��200��5j      $��20��5k       � IsIndeterminate$
 True��5l      �� 5m      $��10q�5n      $��Center=�5o      
�������$.��(Завантаження моделі...��5q      5r      5s      &   HelixToolkit.Wpf.HelixViewport3D  5w      -   5        $��viewPort��5w       $��1��60      Camera 5y      =� 5z      -   5        
mainCamera�� =� FieldOfView$ 45Q�5|       � LookDirection$ 0 0 -15�5}       � Position$ 0 0 101�5~       � UpDirection$ 0 1 05�5         Children. 5�        HelixToolkit.Wpf.SunLight  5�      5�      5�      5�      