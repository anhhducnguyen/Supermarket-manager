   M S B A M L   `   `   `  ����@  <Login, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Login.ViewsLogin.Views  5          Login.Views.EmployeeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      %localclr-namespace:Login.Views  5      -   5          � 	Resources  5
         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value   OptionMark.Static.Background �� Color  OptionMark.Static.Border  OptionMark.Static.Glyph # OptionMark.MouseOver.Background  OptionMark.MouseOver.Border  OptionMark.MouseOver.Glyph ! OptionMark.Pressed.Background  OptionMark.Pressed.Border 	 OptionMark.Pressed.Glyph "
 OptionMark.Disabled.Background  OptionMark.Disabled.Border  OptionMark.Disabled.Glyph  CheckBoxStyle1 �� 
TargetType �Name J� SnapsToDevicePixels � ColumnDefinitions	 ��Name
 �� CornerRadius �� Padding F�Name J� Opacity �� Stretch ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName  gridEditButton �� Triggers  gridRemoveButton �� BasedOn  gridButtonIcon!  FontAwesome.Sharp.IconImage��%2  &	        &	 L     &	 o     &	 �     &	 �     &	 �     &	 �     &	     &	 A    &		 d    &	
 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  7 
 7  7  7  7  7 	 7 	 &	 �
    &	 �    7  &	 �    �� 5   
   "  62   .�5      ��  � ��$ Center=�64   5      �� 5   
   $ 	#FFFFFFFF��6?   �� 5   
   $ 	#FF707070��6;   �� 5   
   $ 	#FF212121��6:   �� 5   
   $ 	#FFF3F9FF��6B   �� 5   
   $ 	#FF5593FF��6>   �� 5   
   $ 	#FF212121��6=   �� 5   
   $ 	#FFD9ECFF��6@   �� 5   
   $ 	#FF3C77DD��6<   �� 5   
   $ 	#FF212121��6;   �� 5   
   $ 	#FFE6E6E6��6A   �� 5   
   $ 	#FFBCBCBC��6=   �� 5   
   $ 	#FF707070��6<   �� 5   
   " ��6'   .�5      ��  �@�FocusVisualStyle 61   Z� �� 5       � ��8   6+   �� 5       � �� �#DAE2EA6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5        � �� 5!      �� 5"      " ��6&   .R�5#      � $ templateRoot��6   
������  .  5$      �� 5%   "   $
��Auto �63   �� 5&   "   $��* �63   .+�5(      �� $	 checkBoxBorder��6%   $
 3��6=   $ 1q�6N   #��z��6Z   #��z��6�   #��z��6�   #��z��6�   $��1q�6'  #��z��62  ._�5)   "   � $ markGrid��6'   .+�5*   &   F� $ 
optionMark��6+   Y�����4� �� Ѽ�G dԊ Ѩ�D dԊ �    ^>O ��z r�5 ��@ ��\ 
ܺ��� @�j�  �>��4� �� 8�� $��1q�6  $ 0Q�6  $
 None=�6  �� 5+   &   $ indeterminateMark��60   8�� $��2q�6{   $ 0Q�6�   5,   #   5-      �� 5.      $ contentPresenter��6/   $��1��6I   |�.  #��z��6k   #��z��6�   ��. # z 6�   #��z��6(  5/       50      P� 51       � �� . . �52   "   ��  6E   Z�  �@�FocusVisualStyle�� 53   "    � ��$ 4,-1,0,0q�6<   54      P� 55       �@J�IsMouseOver . . �56   "   �� $ checkBoxBorder��6?   8   � ��6[   �� 57   "   $ checkBoxBorder��6@    � �� �#9575CD6\   �� 58   "   $ 
optionMark��69   8   � ��6Q   �� 59   "   $ indeterminateMark��69   8   � ��6X   5:      P� 5;       � {� .  . �5<   "   �� $ checkBoxBorder��6?   8   � ��6[   �� 5=   "   $ checkBoxBorder��6@   8   � ��6\   �� 5>   "   $ 
optionMark��69   8   � ��6Q   �� 5?   "   $ indeterminateMark��69   8 	  � ��6X   5@      P� 5A       � �� . . �5B   "   �� $ checkBoxBorder��6?   8 
  � ��6[   �� 5C   "   $ checkBoxBorder��6@    � �� �#9575CD6\   �� 5D   "   $ 
optionMark��69   8   � ��6Q   �� 5E   "   $ indeterminateMark��69   8   � ��6X   5F      P� 5G       �@d�	IsChecked$
 trueY�6;   . �5H   "   �� $ 
optionMark��6<    �@J�Opacity$ 1Q�6T   �� 5I   "   $ indeterminateMark��6<    �@J�Opacity$ 0Q�6[   5J      5L      5N      5O      �� 5P   
   " ��6'   .�5Q      ��  � �� �#512DA86+   �� 5R       � �� �#4A148C6,   �� 5S       � �� �#ffffff6+   �� 5T       �@�FocusVisualStyle 61   Z� �� 5U       � ��$ Center=�62   �� 5V       � �� 5W      �� 5X      " ��6&   .R�5Y      �� #��z��6!   #��z��6K   $ 5q�6w   $��1q�6�   $
 5��6�   ._�5Z      �� $��Center=�6/   $��Center=�6J   5[      5\      5^       5_      P� 5`       �@J�IsMouseOver . . �5a      ��  � �� �#673AB763   5b      5d      �� 5g   
   " ��6)   8   .�5h      ��  � �� �#D32F2F6+   �� 5i       � �� �#B71C1C6,    5j      P� 5k       �@J�IsMouseOver . . �5l      ��  � �� �#F4433663   5m      5o      �� 5r   
   "  6'   .�5s      ��  � ��$ Center=�62   �� 5t       � ��$ 12��6&   �� 5u       � ��$ 12��6'   5v      5w      .��5x      � 
�������.+�5z   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�5{      $��
0,14,169,0q�61   $��25��6E   $��Right=�6Q   $	��331��6m   .+�5|        �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��20��6)   $��20��65      
Foreground �#0072BC6@   �� 5}      -   5         ��Name$ 	txtSearch��5}      $(��"Tìm theo tên, mã nhân viên...��6)   $��13(�5~      $��24��5      $	��270��5�      
������ $��Medium"�5�      $��
Montserrat)�5�      
������� �� 
CaretBrush
 �   �
�������$��0,0,0,1q�5�      $��Center=�5�      $	��Top=�5�   <   5�      �� 5�   
   -   5         ��Name$ 	btnSearch��5�      $��Tìm kiếm��5�      $��12(�5�      $��
Montserrat)�5�       � Cursor$
 Hand��5�      $��0q�5�      
�������$	��Top=�5�      $��	0,10,95,0q�5�   &   $��90��69   $��30��6D   $��Right=�6P   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#0072BC63   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $��30��6)   $
 5��5�   5   #��z��5�   5   ._�5�   &   �� $��Center=�67   $��Center=�5�   G   5�   #   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � �� �#0053896;   5�      5�      5�      �� 5�   
   -   5        $ btAdd��5�      $��Thêm��5�      $��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0q�5�      
�������$��Bottom=�5�      $��10,0,850,14q�6,   $��36��5�   %   $��90��61   $
��Left=�6<   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#0072BC63   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $��30��6)   $
 5��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   -   5�   #   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � �� �#0053896;   5�      5�      5�      �� 5�   
   -   5        $ btDelete��5�      $
��Xóa��5�      $��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0q�5�      
�������$��Bottom=�5�      $��109,0,751,14q�6(   $��36��5�   $   $��90��60   $
��Left=�6;   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#0072BC63   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $��30��6)   $
 5��5�   %   #��z��5�   %   ._�5�   &   �� $��Center=�67   $��Center=�5�   )   5�   #   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � �� �#0053896;   5�      5�      5�      �� 5�   
   ���#F0F8FF$
 5��5�      $ 10q�5�      $��	0,60,0,51q�6   ._�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgNhanVien��5�        DataGridStyle1#���  5�        DataGridCellStyle1   	CellStyle# �  6A     DataGridColumnHeaderStyle1    ColumnHeaderStyle#  �  6r     DataGridRowStyle1!   RowStyle#! �  6�   "   AutoGenerateColumns" .  #   RowHeaderWidth$# 0Q�5�   A   $   GridLinesVisibility$
$ None=�6T   $��Hidden=�6o   ���#F0F8FF%   CanUserAddRows% .  $��0q�5     $��	0,0,0,-10q�6V   ��5   (   �� *
products+&   Columns& 5     4  .System.Windows.Controls.DataGridTemplateColumn  5     ,  &System.Windows.Controls.DataGridColumn'   CanUserResize' .  (   Width5  /System.Windows.Controls.DataGridLengthConverter$
( Auto 6C   )   HeaderTemplate) 5     �� 5     .R�5  "   �� * ��Name$* chkSelectAll��6S   -   5        #��[ 5  +   + d� 	IsChecked+ 6i   �� *IsAllSelected+6�   5     ,   CellTemplate, 5
     �� 5     .R�5  "   �� $* dg��6+   -   5        #��[ 5  e   + 6�   �� *
IsSelected+- �� UpdateSourceTrigger$- PropertyChanged=�. �� Mode$. TwoWay=�5     5       5     /   Header$/  ��6-   0   
IsReadOnly0 . $
( Auto 6I   , 5     �� 5     .R�5  "   �� $ 
Horizontal=�6-   .+�5  &   �� $ btedit��6-   -	   5        ���#2980b9$��5 0 0 0q�5  R   #��[ 6c   .��5  *     $ PenToSquare=�67   
 �����#��[ 6]   5  '   �� 5  &   $ btxoale��6-   -
   5        $��6 0 0 0q�5  >   #��[ 6O   .��5  *     $ Trash=�67   
 �����#��[ 6W   5  '   5  #   5      5"       5$     $/  ��6-   0 . $( 90 6I   , 5%     �� 5&     .R�5'  "   � $��45��6'   $��50��62   .+�5(  &   A� $��45��6.   $��45��69   
�������$	��0.5��6S   ��5)  *   �� 5*  .   1 j� Stretch$1 UniformToFill=�6_   2 �� ImageSource2 69   �� 3 �� Path$3 anhImage�6_   5,  '   5-  #   5.     50     0  *System.Windows.Controls.DataGridTextColumn  52     $/ Mã nhân viên��6)   0 . ' .  $	( 120 6g   1	  +System.Windows.Controls.DataGridBoundColumn4 	  Binding4 6s   �� *manv+  53     $/ Tên nhân viên��6)   0 . ' .  $	( 150 6h   4 6t   �� *tennv+  54     $/ Tài khoản��6)   0 . ' .  $	( 120 6d   4 6p   �� *tk+  55     $/ Trạng thái làm việc��6)   0 . ' .  $	( 170 6n   4 6z   �� *trangthailv+  56     $/ Giới tính��6)   0 . ' .  $	( 120 6d   4 6p   �� *gt+  57     $
/ SĐT��6)   0 . ' .  $	( 120 6^   4 6j   �� *sdt+  58     $/ 
Ngày sinh��6)   0 . ' .  $	( 120 6d   4 6p   �� *ngaysinh.Date+5 �� StringFormat$5 
dd/MM/yyyy��  59     $/ Địa chỉ��6)   0 . ' .  $	( 120 6b   4 6n   �� *diachi+  5:     $/ 	Số CCCD��6)   0 . ' .  $	( 120 6b   4 6n   �� *cccd+  5;     $/ 
Nơi cấp��6)   0 . ' .  $	( 120 6b   4 6n   �� *noicap+  5<     $/ Ngày cấp��6)   0 . ' .  $	( 120 6c   4 6o   �� *ngaycap.Date+$5 
dd/MM/yyyy��  5=     $%/ Ngày làm việc chính thức��6)   0 . ' .  $	( 140 6s   4 6   �� *ngaylvct.Date+$5 
dd/MM/yyyy��  5>     $/ Lương��6)   0 . ' .  $	( 120 6`   4 6l   �� *luong+$5 {0:N0}đ��  5?     $/ Ảnh��6)   0 . ' .  $	( 120 6^   4 6j   �� *anh+5C     5F     �� 5G  
   $��Tổng nhân viên:��6   $
��Left=�6*   $��	11,10,0,0q�6E   $	��Top=�6X   $	��105��6p   $��DemiBold"�6|   ���#0072bc6�   �� 5H  
   -   5        6 ��Name$6 	txtTongNV��5H     $��13(�5I     
������ $��Normal"�5K     $��
Montserrat)�5L     $
��Left=�5O     $��
116,16,0,0q�6-   $
��Wrap=�6A   $	��Top=�6U   $��31��6m   7 J� RenderTransformOrigin$7 0.366,0.559&�6x   �� 5P  
   -   5        $ btHuy��5Q     $��Hủy��5S     $��12(�5T     $��
Montserrat)�5U     $
 Hand��5V     $��0q�5W     
�������$��Bottom=�5Y     $��816,0,44,10q�6(   $��36��5Z  !   $��90��6-   $��Right=�68   ��5R     �� *LoginCommand+��5\     �� 5]     " ��6   .�5^     ��  � �� �#FF000063   �� 5_      � �� 5`     �� 5a     " ��6.   .R�5b  "   �� $��30��6)   $
 5��5c  %   #��z��5d  %   ._�5e  &   �� $��Center=�67   $��Center=�5f  )   5g  #   5h     5j      5k     P� 5l      �@J�IsMouseOver . . �5m     ��  � �� �#0053896;   5n     5p     5r     �� 5t  
   -   5        $ btUpdate��5t     $��12(�5v  	   $��
Montserrat)�5w  	   $
 Hand��5x  	   $��0q�5y  	   
�������$	��Top=�5{  	   $��	0,10,54,0q�5|      $��30��63   $��30��6?   $��Right=�6J   ��5u  	   �� *LoginCommand+��5}     �� 5~     " ��6   .�5     ��  � �� �#0072BC63   �� 5�      � �� 5�     �� 5�     " ��6.   .R�5�  "   �� $��30��6)   $��30��64   $
 15��6@   #��z��6R   ._�5�  &   � .+�5�  *     $ Rotate=�67   $��16��6E   $��16��6P   
 �����$��Center=�6o   $��Center=�6�   5�  '   5�  #   5�     5�      5�     P� 5�      �@J�IsMouseOver . . �5�     ��  � �� �#0053896;   5�     5�     5�     5�     5�     