   M S B A M L   `   `   `  ����@  <Login, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Login.WindowViewLogin.WindowView  5   	   &     Login.WindowView.ForgotPassWorld   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Login.WindowView     5   	     � Title$  Đổi mật khẩu��5   	   $	��250��6   $	��350��6+    � WindowStartupLocation$ CenterScreen=�67   $	��350��6\   $	��250��6k   ���	#FFDCD6D6 � WindowStyle$ 
ToolWindow=�6�   .��5	      � .+�5
   
   G� -   5         G�Name$ txt_mkcu��5
      $
��Left=�6(   $��
130,50,0,0q�6C   $	��Top=�6W   $	��130��6o   $��20��6{   6�   G� 5   
   -   5        $ 
txt_mkmoi1��5      $
��Left=�6*   $��
130,75,0,0q�6E   $	��Top=�6Y   $	��130��6q   $��20��6}   6�   G� 5   
   -   5        $ 
txt_mkmoi2��5      $
��Left=�6*   $��130,100,0,0q�6E   $	��Top=�6Z   $	��130��6r   $��20��6~   �� 5   
   $��Mật khẩu cũ��6   $
��Left=�6&   $��	36,47,0,0q�6A   $	��Top=�6T   $��81��6l   �� 5   
   $��Mật khẩu mới��6   $
��Left=�6'   $��	36,72,0,0q�6B   $	��Top=�6U   $��89��6m   �� 5   
   $��Nhập lại ��6   $
��Left=�6$   $��	36,97,0,0q�6?   $	��Top=�6R   $��81��6j   �� 5   
   -   5         ��Name$ lb_thongbao��5      $��Center=�6%   $��	0,125,0,0q�6B   $	��Top=�6U   $	��246��6m   $��27��6y   $��Center=�6�   �� 5   
   -   5         ��Name$ bt_boqua��5      $��Bỏ qua��6#   $
��Left=�64   $��30��6O   $��
65,164,0,0q�6[   $	��Top=�6o   $��90��6�   
���������5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#0072BC63   �� 5       � �� 5      �� 5      	 �� 
TargetType"	 ��6.   .R�5   "   �� $��30��6)   
 �� CornerRadius$
 5��5   5   #��z��5   5   ._�5   &   �� $��Center=�67   $��Center=�5   G   5   #   5      5        �� Triggers 5!      P� 5"       P� Property �@J�IsMouseOver P� Value . . �5#      ��  � �� �#836EFB6;   5$      5&      5(      �� 5)   
   -   5        $ bt_doimk��5)      $��	Đổi MK��6#   $
��Left=�64   $��30��6O   $��186,164,0,0q�6[   $	��Top=�6p   $��90��6�   
���������5*      �� 5+      " ��6   .�5,      ��  � �� �#0072BC63   �� 5-       � �� 5.      �� 5/      "	 ��6.   .R�50   "   �� $��30��6)   $
 5��51   5   #��z��52   5   ._�53   &   �� $��Center=�67   $��Center=�54   G   55   #   56      58       59      P� 5:       �@J�IsMouseOver . . �5;      ��  � �� �#836EFB6;   5<      5>      5@      5A      5B      