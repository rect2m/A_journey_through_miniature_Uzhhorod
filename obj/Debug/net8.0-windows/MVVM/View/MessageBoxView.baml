   M S B A M L   `   `   `  ����_  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  5      o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  5      C    =A_journey_through_miniature_Uzhhorod.MVVM.View.MessageBoxView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Gloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model  5      Hlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        � Title$  Message��5
      $	��800��5      $	��450��5       � AllowsTransparency$
 True��5      
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �� $	��330��5   	   $	��110��5   	   $��3q�5   	    �� CornerRadius$ 25��5   	   ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Offset$
 0.45Q�6      primaryBackColor1	 � Color#	 [  6-   � 5      $ 0Q�6     primaryBackColor2#	 [ 6*   5      ��5    
   �� 5!      $	 0,1&�6"   $	 1,0&�63   .��5"      � $ 0Q�6     winBorderColor1#	 [ 6*   � 5#      $
 0.55Q�6     winBorderColor2#	 [ 6-   � 5$      $
 0.80Q�6     winBorderColor3#	 [ 6-   5%      ._�5'   
   � .+�5)      �� �� 5,      -   5        
 ��Name$
 TextBlockProblem1��5-      $	��200��5.      $��	0,5,30,50q�5/      $��Right=�50      $��Center=�51        titleColor1#��[ 52      $��Помилка��53      $
��Wrap=�54      �� 55      -   5         ��Name$ MessageBoxTextBox��56      $	��200��57      $��20��58      $��	0,5,10,15q�59      $��Right=�5:      $��Center=�5;      $��Center=�5<      
������ 
�������$��0,0,0,2q�5?       �� 
CaretBrush
 �����$��
Montserrat)�5A      $��13(�5B      $��Medium"�5C      
�������5D      G� 5F      -   5         G�Name$ MessageBoxPasswordBox��5G      $	��200��5H      $��20��5I      $��	0,5,10,15q�5J      $��Right=�5K      $��Center=�5L      $��Center=�5M      
������ 
�������$��0,0,0,2q�5P       G� 
CaretBrush
 �����$��
Montserrat)�5R      $��13(�5S      $��Medium"�5T      
�������5U      �� 5X      -   5         ��Name$ ButtonOk��5Y      $��	0,0,20,10q�5Z      $��Right=�5[      $��Bottom=�5\      $��Ok��5^      #��[ 5_       �� 	IsDefault$
 True��5`        buttonmessage#��[ 5a      �� 5b      -   5        $ 	ButtonYes��5c      $��	60,0,0,10q�5d      $��Center=�5e      $��Bottom=�5f      #��[ 5i      #��[ 5j      ��5h      B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *Yes+5j      �� 5k      -   5        $ ButtonNo��5l      $��	0,0,30,10q�5m      $��Right=�5n      $��Bottom=�5o      #��[ 5r      #��[ 5s      ��5q        *No+5s      �� 5v      -   5         ��Name$ 	IconError��5w      $��70��5x      $��70��5y      $��12q�5z      $
��Left=�5{      $��/Icons/error.png��5|      �� 5~      -   5        $ IconSuccess��5      $��70��5�      $��70��5�      $��12q�5�      $
��Left=�5�      $��/Icons/success.png��5�      �� 5�      -	   5        $ 	IconThink��5�      $��70��5�      $��70��5�      $��12q�5�      $
��Left=�5�      $��/Icons/think.png��5�      5�      5�      5�      