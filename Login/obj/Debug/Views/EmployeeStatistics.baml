   M S B A M L   `   `   `  ����@  <Login, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Login.ViewsLogin.Views  5      $    Login.Views.EmployeeStatistics   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      %localclr-namespace:Login.Views  5      -   5        .��5      � ���#E7EBEE  � ColumnDefinitions  5   
   �� 5      $	��11* �6   �� 5      $	��37* �6    � RowDefinitions 5   
   �� 5      $
��120* �6   �� 5      $
��187* �6   .+�5   
   �� ���#F0F8FF �� CornerRadius$ 1��5       �� Padding$ 10q�5      $��
10,165,0,0q�6   $��1��62   $��2��6B   $	��844��6S   $
��Left=�6_   $	��Top=�6z   $	��390��6�   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgUser��5         DataGridStyle1#���   5        DataGridCellStyle1   	CellStyle# �  6:     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  6k     DataGridRowStyle1   RowStyle# �  6�      AutoGenerateColumns .  	   RowHeaderWidth$	 0Q�5   =   
   GridLinesVisibility$

 None=�6P   $��Hidden=�6k   ���#F0F8FF   CanUserAddRows .  $��0q�5       ��5   (   �� *
products+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã nhân viên��6)      
IsReadOnly .    CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6s   �� *manv+  5'      $ Tên nhân viên��6)    .  .  $	 150 6h    6t   �� *ten+  5(      $ Mã hóa đơn��6)    .  .  $	 150 6e    6q   �� *mhd+  5*      $ 
Ngày bán��6)    .  .  $ 90 6c    6n   �� *ngayban.Date+ �� StringFormat$ 
dd/MM/yyyy��   ElementStyle 5+      �� 5,       �� 
TargetType" ��6$   .�5-   "   ��  �� Property � �� �� Value$ Right=�6H   5.      50        51      $ Tổng tiền��6)    .  .  $	 110 6d    6p   �� *
tongtien+$ {0:N0}đ�� 52      �� 53      " ��6$   .�54   "   ��  � ��$ Right=�6H   55      57      5H      5I      � 5K   
   $��10,8,0,0q�6   $	��265��6!   $
��Left=�6-   $	��Top=�6H   $	��592��6`   $��2��6m   .+�5L      �� $ ��Tra cứu theo nhân viên��6   $
��15.5(�67   
����������#0072bc$��2q�6p   $��0,0,0,35q�6�   ��5M      �� 5N       �� Color$ #0072bc��6&   .��5P      �  5Q      �� 5R      �� 5S        5U      �� 5V      $
��Auto �6+   �� 5W      $
��Auto �6+   .+�5Z      �� $��Mã nhân viên��6   ���#0072bc$��0��6H   $��0��6U   $	��122��6e   $��-1,35,127,184q�6q   �� 5[      -   5         ��Name$ 
cmbDanhMuc��5[      $��0��63   $	��136��6@   $��22��6{   $��112,41,0,202q�6�   $��2��6�   5\      5]      5^      � 5e   
   ���#E7EBEE$��2��6$   $��1��68   $
��Left=�6E   $	��Top=�6`   $��270,187,0,0q�6x   $��2��6�   .+�5g      ��  �� Orientation$ 
Horizontal=�6   
�������$��70��6E   $	��280��6Q   $��14,-373,0,0q�6]   $
��Left=�6r   $	��Top=�6�   .+�5h      �� 
�������$��1q�6-   $��5,0,13,0q�6A   $ 50��6S   $��50��6e   $��50��6p   ��5i      �� 5j      $ #0072bc��6*   ._�5l      �� 
������ $��Center=�6:   .+�5m      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Tags=�6'   $��25��63   $��25��6>      
Foreground
 �����$��5,0,5,0q�6]   $��Center=�6n   5n      5o      �� 5p      $��Center=�6   $��70��69   $	��172��6E   .+�5q      �� -   5         ��Name$ txtTongHoaDon��5q       $��73��67   $	��172��6A   $��	0,10,0, 5q�6N   $��25��6a   $
��21px(�6m   ���#0072bc6}   �� 5r      $��TỔNG SỐ ĐƠN��6    $
��Wrap=�63   $��25��6G   $	��171��6S   $
��Bold"�6_   ���#90a4ae$
��11.5(�6�   5s      5t      �� 5w      $ 
Horizontal=�6   
�������$��70��6E   $	��280��6Q   $��296,-373,0,0q�6]   $
��Left=�6s   $	��Top=�6�   .+�5x      �� 
�������$��1q�6-   $��5,0,13,0q�6A   $ 50��6S   $��50��6e   $��50��6p   ��5y      �� 5z      $ #0072bc��6*   ._�5|      �� 
������ $��Center=�6:   .+�5}        $ CartArrowDown=�6'   $��25��6<   $��25��6G   
 �����$��5,0,5,0q�6f   $��Center=�6w   5~      5      �� 5�      $��Center=�6   $��70��69   $	��172��6E   .+�5�      �� -   5        $ txtTongTien��5�       $��
10,050,050��65   $	��172��6G   $��	0,10,0, 5q�6T   $��25��6g   $
��21px(�6s   ���#0072bc6�   �� 5�      $��	DOANH THU��6    $
��Wrap=�61   $��25��6E   $	��171��6Q   $
��Bold"�6]   ���#90a4ae$
��11.5(�6�   5�      5�      �� 5�      $ 
Horizontal=�6   
�������$��70��6E   $	��280��6Q   $��579,-373,0,0q�6]   $
��Left=�6s   $	��Top=�6�   .+�5�      �� 
�������$��1q�6-   $��5,0,13,0q�6A   $ 50��6S   $��50��6e   $��50��6p   ��5�      �� 5�      $ #0072bc��6*   ._�5�      �� 
������ $��Center=�6:   .+�5�        $ Medium=�6'   $��25��65   $��25��6@   
 �����$��5,0,5,0q�6_   $��Center=�6p   5�      5�      �� 5�      $��Center=�6   $��70��69   $	��172��6E   .+�5�      �� -   5        $ txtGiaTriTrungBinh��5�       $��
10,050,050��6<   $	��172��6N   $��	0,10,0, 5q�6[   $��25��6n   $
��21px(�6z   ���#0072bc6�   �� 5�      $��TRUNG BÌNH/1 HÓA ĐƠN��6    $
��Wrap=�6<   $��25��6P   $	��171��6\   $
��Bold"�6h   ���#90a4ae$
��11.5(�6�   5�      5�      5�      �� 5�   
   $)��#Lịch sử giao dịch hóa đơn:��6   $
��Left=�65   $��
10,134,0,0q�6P   $	��Top=�6d   $	��158��6|   $��1��6�   �� 5�   
   -   5         ��Name$ btUpdate��5�      $��12(�5�      $��
Montserrat)�5�       � Cursor$
 Hand��5�      $��0q�5�      
�������$	��Top=�5�      $��0,7,9,0q�6%   $��30��5�   $   $��30��60   $��Right=�6;   $��1��6W   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#0072BC63   �� 5�       � �� 5�      �� 5�       �� 
TargetType" ��6.   .R�5�   "   �� $��30��6)   $��30��64   $ 15��6@   #��z��6R   ._�5�   &   � .+�5�   *     $ Rotate=�67   $��16��6E   $��16��6P   
 �����$��Center=�6o   $��Center=�6�   5�   '   5�   #   5�      5�        �� Triggers  5�      P� 5�      ! P� Property! �@J�IsMouseOver" P� Value" . . �5�      ��  � �� �#836EFB6;   5�      5�      5�      5�      5�      