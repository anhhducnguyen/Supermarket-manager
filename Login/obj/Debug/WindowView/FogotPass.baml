   M S B A M L   `   `   `  ����@  <Login, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Login.WindowViewLogin.WindowView  5   	        Login.WindowView.FogotPass   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Login.WindowView     5   	     � WindowStyle$
  None=�5   
    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � AllowsTransparency .  � Title$ 	FogotPass��5   	   $	��200��6   $	��420��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� 
������� �� CornerRadius$ 10��5      
���   � �� Padding$ 10q�5      ._�5      � $��0,0,-2,0q�6   .+�5      �� -   5         ��Name$ 
btMinimize��5      $��0q�5      $��-��5      
�������$��16(�5      $��
Montserrat)�5       	 � Cursor$
	 Hand��5!      $	��Top=�5"      $��Right=�5#      $��0,0,30,0q�5$      ��5'      �� 5(      
 �� 
TargetType"
 ��6    .�5)      ��  �� Property � �� �� Value �#0072BC6;    �� Triggers 5*      P� 5+   "    P� Property �@J�IsMouseOver P� Value . . �5,   &   ��  � �� �#0072BC6C   5-   #   5/      ��51      �� 52       �� 
TargetType" ��6*   .R�53      �� $��20��6%   $��20��60   $ 1��6<   #��z��54   !   ._�55   "   �� $��Center=�63   $��Center=�56   /   57      58      5:      �� 5;      -   5        $ btQuit��5;      $��0q�5<      $��X��5=      
�������$��12(�5?      $��
Montserrat)�5@      $	��Top=�5A      $
��Left=�5B      $
	 Hand��5C      $��	372,0,0,0q�5D   *   $��25��6=   ��5E      �� 5F      "
 ��6    .�5G      ��  � ��
 �  ��6;    5H      P� 5I   "    �@J�IsMouseOver . . �5J   &   ��  � ��
 �  ��6C   5K   #   5M      ��5O      �� 5P      " ��6*   .R�5Q      �� $��20��6%   $��20��60   $ 1��6<   #��z��5R   !   ._�5S   "   �� $��Center=�63   $��Center=�5T   /   5U      5V      5X      G� 5Y      -   5         G�Name$ txt_mkcu��5Y      $
��Left=�60   $��
191,47,0,0q�6K   $	��Top=�6_   $	��130��6w   $��20��6�   6�   G� 5Z      -   5        $ 
txt_mkmoi1��5Z      $
��Left=�62   $��
191,72,0,0q�6M   $	��Top=�6a   $	��130��6y   $��20��6�   6�   G� 5[      -   5        $ 
txt_mkmoi2��5[      $
��Left=�62   $��191,100,0,0q�6M   $	��Top=�6b   $	��130��6z   $��20��6�   �� 5\      $��Mật khẩu cũ��6   $
��Left=�6.   $��	85,44,0,0q�6I   $	��Top=�6\   $��80��6t   �� 5]      $��Mật khẩu mới��6   $
��Left=�6/   $��	85,68,0,0q�6J   $	��Top=�6]   $��88��6u   �� 5^      $��Nhập lại ��6   $
��Left=�6,   $��	85,94,0,0q�6G   $	��Top=�6Z   $��81��6r   �� 5_      -   5         ��Name$ lb_thongbao��5_      $��Center=�6-   $��	0,125,0,0q�6J   $	��Top=�6]   $	��246��6u   $��27��6�   $��Center=�6�   �� 5`      -   5        $ bt_boqua��5`      $��Bỏ qua��6+   $
��Left=�6<   $��30��6W   $��
85,138,0,0q�6c   $	��Top=�6w   $��90��6�   
���������5a      �� 5b      "
 ��6    .�5c      ��  � �� �#0072BC6;   �� 5d       � �� 5e   "   �� 5f   &   " ��66   .R�5g   *   �� $��30��61   $ 5��5h   5   #��z��5i   5   ._�5j   .   �� $��Center=�6?   $��Center=�5k   G   5l   +   5m   '   5o       5p      P� 5q   "    �@J�IsMouseOver . . �5r   &   ��  � �� �#0053896C   5s   #   5u      5w      �� 5x      -   5        $ bt_doimk��5x      $��	Đổi MK��6+   $
��Left=�6<   $��30��6W   $��231,138,0,0q�6c   $	��Top=�6x   $��90��6�   
���������5y      �� 5z      "
 ��6    .�5{      ��  � �� �#0072BC6;   �� 5|       � �� 5}   "   �� 5~   &   " ��66   .R�5   *   �� $��30��61   $ 5��5�   5   #��z��5�   5   ._�5�   .   �� $��Center=�6?   $��Center=�5�   G   5�   +   5�   '   5�       5�      P� 5�   "    �@J�IsMouseOver . . �5�   &   ��  � �� �#0053896C   5�   #   5�      5�      5�      5�      5�      5�      