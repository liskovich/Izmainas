   M S B A M L   `   `   `  ����H  DIzmainasAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:IzmainasAdmin.ViewsIzmainasAdmin.Views  5   	   #    IzmainasAdmin.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:IzmainasAdmin.Views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Stundu Izmaiņas - Admin��5	   	   $	��600��6)   $
��1000��66   $	��600��5
   	   $
��1000��6    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name	 �� Triggers
 P� Property P� Value��%�  '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6+   �� 5       � ��$ 20(�6)   �� 5       �@J�SnapsToDevicePixels$
 True��64   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 0��6!   #��z��62   ._�5      � .+�5   "   � 
����  �$��10��69   $
��Left=�6D   �� 5   "   $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0 0 0 0q�6�   5      5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5    "   ��  � �� �#66a1ff6?   �� 5"   "    � ��
 �����6?   5$      P� 5&      
 � ��$
 True��6;   . �5'   "   ��  � ��
 �����6?   �� 5(   "    � ��
 �����6?   5)      P� 5+      
 � {�$ False��6;   . �5,   "   ��  � ��
 �����6?   �� 5-   "    � ��
 �����6?   5.      50      52      53      54      .��56      �  � ColumnDefinitions 57   
   �� 58      $	��200 �6   �� 59      $��* �6   .+�5<   
   � $��0��6   
�������.+�5>      �� .+�5?      � $	��150��6   ��5@      �� 5A       �� 
StartPoint$ 0,0.5&�6.    �� EndPoint$ 1,0.5&�6A   .��5B      �  � Color$
 Blue��6+    � Offset$ 0Q�68   � 5C      $ DeepSkyBlue��6+   $ 1Q�6?   5D      .+�5F      �� $��Izvēlne��6    $
��Bold"�5G       
�������$��30(�5I       $��Bottom=�5J       $��Center=�5K       $��0 0 0 20q�5L       5M      �� 5N      -   5         ��Name$ PublishList��5P      $��	Jaunākie��5N      $��40��5O      5P      �� 5Q      -   5        $ ViewAll��5S      $��Saraksts��5Q      $��40��5R      5S      5T      5U      � 5V   
   $��1��6   .+�5W      �� -   5         ��Name$ 
ActiveItem��5W      5X      5Y      5Z      