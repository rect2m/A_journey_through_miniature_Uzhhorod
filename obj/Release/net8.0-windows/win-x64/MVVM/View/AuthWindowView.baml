   M S B A M L   `   `   `  ���� _  [A_journey_through_miniature_Uzhhorod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model/A_journey_through_miniature_Uzhhorod.MVVM.Model  o<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View.A_journey_through_miniature_Uzhhorod.MVVM.View  C    =A_journey_through_miniature_Uzhhorod.MVVM.View.AuthWindowView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Mloc=clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.Model     Nlocal<clr-namespace:A_journey_through_miniature_Uzhhorod.MVVM.View     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $	��800��$	��550��$	��300��$	��500��$	��800��$	��550��  � AllowsTransparency$
  True��
������  � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 	Resources    	HidePanel �� TargetProperty	 W� To g� Duration  	ShowPanel��%r   &	        &	 /     �� .��W� $ Opacity� 0$ 0:0:0.5D��� .��W� $ Opacity� 1$ 0:0:0.5D�.���� $��3q� �� CornerRadius$ 10������ 	 �� 
StartPoint$		 0,1&�
 �� EndPoint$	
 1,0&�.���  � Offset$ 0Q�  winBorderColor1 � Color# [ � $
 0.55Q�  winBorderColor2# [ � $
 0.80Q�  winBorderColor3# [ ���� $		 0,1&�$	
 1,0&�.��� $
 0.45Q�  primaryBackColor1# [ � $ 1Q�  primaryBackColor2# [ ._��  � RowDefinitions �� $��30 ��� �� $��60 �.+��  � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��0��$��10,0,0,0q�$��Center=�$��
Montserrat)�$��12(�  titleColor1#��[ $��	AUTH MENU���� -    ��Name$ ButtonMinimize��$��1��$��-7,0,0,0q�  buttonMinimize#��[ $��0q�$��-�� � Cursor$
 Hand��$��
Montserrat)�$��16(�
������� 	 ControlBarButton2#��[	 �� -   $ ButtonClose��$��2�� 
 buttonClose#��[
 $��0q�$��X��$
 Hand��$��
Montserrat)�$��12(�
�������#��[	 �� .+�A�  �� Left$	 600��
 �� Top$	 350��$	��300��$	��300�� J� Opacity$
 0.25Q���
� .��� $	 0.2Q�$ 	Goldenrod��� $ 1Q�$ Transparent��A� $
 -100��$
 -100��$	��300��$	��300��$
 0.25Q���
� .��� $	 0.2Q�$ 	Goldenrod��� $ 1Q�$ Transparent��A� $	 175��$	 450��$	��150��$	��150��$
 0.25Q���
� .��� $	 0.2Q�$ 	Goldenrod��� $ 1Q�$ Transparent��F� $	 0.2Q�
�������$��1����� .��B� .��E�  E� 
StartPoint$ 0,500&�.����  �� Point1$ 450,0&� �� Point2$ 300,200&� �� Point3$ 500,150&��� $ 450,120&�$ 500,380&�$ 800,20&��� ���� .R�� ���� .R�A� $��3��$��3��
�������$	 0.1Q�A� $ 50��$ 50��$	��200��$	��200��
�������$
 0.05Q�� 
�������$
 0.07Q� � Points' �   ��, �� �5����6�&���A� $	 200��$	 470��$	��100��$	��100��
�������$
 0.07Q��� $��1��.+��� -    ��Name$ AuthLogoImage��$	��105��$	��105��$��0,15,0,0q�� .+��� -    ��Name$ LoginStackPanel��$	��220��$��0,20,0,0q�$ 1Q� �� Orientation$ Vertical=�.+��� $��0,10,0,0q�$��Center=�$��
Montserrat)�$��20(�$��Medium"�
���������B   <A_journey_through_miniature_Uzhhorod.MVVM.Model.LocExtension  *AuthorizationTitle+�� $��0,35,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *
Username+�� -    ��Name$ LoginTextBoxUser��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q� �� 
CaretBrush
 �����$��
Montserrat)�$��13(�$��Medium"�
�������.������  j� 
AlignmentX$
 Left=� �� ImageSource$ /Icons/user.png��  j� Stretch$
  None=�.���� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *
Password+G� -   ! G�Name$! LoginPasswordBoxPass��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q�" G� 
CaretBrush
" �����$��
Montserrat)�$��13(�$��Medium"�
����������� $
 Left=�$ /Icons/key.png��$
  None=��� -   $ ButtonLogin��$��0,40,0,0q�$��0q�$
 Hand��$��
Montserrat)�$��12(�
�������# �� 	IsDefault$
# True�� 
 button#��[ ��  *LoginButton+�� $��0,20,0,0q�$��Center=�$ 
Horizontal=�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *DontHaveAcount+�� -	   $ ��Name$$ TextBlockRegistration��$��8,0,0,0q�$
 Hand��$��
Montserrat)�$��12(�$��Medium"�  link#��[ ��  *Registration+�� -
   $ RegStackPanel��$��2��$	��220��$��0,5,0,0q�$ 0Q�$ Vertical=�$y�	Collapsed=�.+��� $��0,10,0,0q�$��Center=�$��
Montserrat)�$��20(�$��Medium"�
���������  *Registration+�� $��0,25,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *
Username+�� -   $ RegTextBoxUser��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q�
 �����$��
Montserrat)�$��13(�$��Medium"�
�������% �� 	MaxLength$% 20��& � ToolTip&   *UsernameToolTip+.������ $
 Left=�$ /Icons/user.png��$
  None=�.���� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *
Password+G� -   $! RegPasswordBoxPass��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q�
" �����$��
Montserrat)�$��13(�$��Medium"�
�������&   *PasswordToolTip+���� $
 Left=�$ /Icons/key.png��$
  None=��� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���������  *Email+�� -   $ RegTextBoxMail��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
�������$��0,0,0,2q�
 �����$��
Montserrat)�$��13(�$��Medium"�
�������&   *EmailToolTip+.������ $
 Left=�$ /Icons/mail-icon.png��$
  None=�.���� -   $ ButtonRegistration��$��0,20,0,0q�$��0q�$
 Hand��$��
Montserrat)�$��12(�
�������$
# True��#��[ ��  *ButtonRegistry+�� $��0,15,0,0q�$��Center=�$ 
Horizontal=�.+��� $��
Montserrat)�$��12(�$��Medium"�
���������  *AlreadyHaveAnAccount+�� -   $$ TextBlockLogin��$��8,0,0,0q�$
 Hand��$��
Montserrat)�$��12(�$��Medium"�#��[ ��  *AuthorizationTitle+�� $��3��$��Center=�$ 
Horizontal=�.+��� -   $$ TextBlockBack��$
 Hand��$��
Montserrat)�$��12(�$��Medium"�#��[ ��  *
MainMenu+