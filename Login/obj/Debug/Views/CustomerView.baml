   M S B A M L   `   `   `  ����@  <Login, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Login.ViewsLogin.Views  5          Login.Views.CustomerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      g cMahApps.Metro.IconPacks.Fontisto, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj	 fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae
 aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Coolicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am  iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah! dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj" fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag# cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac$ _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag% cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae& aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137axIcon-http://metro.mahapps.com/winfx/xaml/iconpacks!    	 
                        ! " # $ % & 5      elocalclr-namespace:Login.Views!    	 
                        ! " # $ % & 5      -   5          � 	Resources  5         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value   OptionMark.Static.Background �� Color  OptionMark.Static.Border  OptionMark.Static.Glyph # OptionMark.MouseOver.Background  OptionMark.MouseOver.Border  OptionMark.MouseOver.Glyph ! OptionMark.Pressed.Background  OptionMark.Pressed.Border 	 OptionMark.Pressed.Glyph "
 OptionMark.Disabled.Background  OptionMark.Disabled.Border  OptionMark.Disabled.Glyph  CheckBoxStyle1 �� 
TargetType �Name J� SnapsToDevicePixels � ColumnDefinitions	 ��Name
 �� CornerRadius �� Padding F�Name J� Opacity �� Stretch ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%  &	        &	 L     &	 o     &	 �     &	 �     &	 �     &	 �     &	     &	 A    &		 d    &	
 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  7 
 7  7  7  7  7 	 7 	 �� 5   
   "  62   .�5      ��  � ��$ Center=�64   5      �� 5   
   $ 	#FFFFFFFF��6?   �� 5   
   $ 	#FF707070��6;   �� 5   
   $ 	#FF212121��6:   �� 5   
   $ 	#FFF3F9FF��6B   �� 5   
   $ 	#FF5593FF��6>   �� 5   
   $ 	#FF212121��6=   �� 5   
   $ 	#FFD9ECFF��6@   �� 5   
   $ 	#FF3C77DD��6<   �� 5   
   $ 	#FF212121��6;   �� 5   
   $ 	#FFE6E6E6��6A   �� 5   
   $ 	#FFBCBCBC��6=   �� 5   
   $ 	#FF707070��6<   �� 5   
   " ��6'   .�5      ��  �@�FocusVisualStyle 61   Z� �� 5       � ��8   6+   �� 5       � �� �#DAE2EA6,   �� 5       � ��# � ��6+   �� 5        � ��$ 1q�60   �� 5!       � �� 5"      �� 5#      " ��6&   .R�5$      � $ templateRoot��6   
������  .  5%      �� 5&   "   $
��Auto �63   �� 5'   "   $��* �63   .+�5)      �� $	 checkBoxBorder��6%   $
 3��6=   $ 1q�6N   #��z��6Z   #��z��6�   #��z��6�   #��z��6�   $��1q�6'  #��z��62  ._�5*   "   � $ markGrid��6'   .+�5+   &   F� $ 
optionMark��6+   Y�����4� �� Ѽ�G dԊ Ѩ�D dԊ �    ^>O ��z r�5 ��@ ��\ 
ܺ��� @�j�  �>��4� �� 8�� $��1q�6  $ 0Q�6  $
 None=�6  �� 5,   &   $ indeterminateMark��60   8�� $��2q�6{   $ 0Q�6�   5-   #   5.      �� 5/      $ contentPresenter��6/   $��1��6I   |�.  #��z��6k   #��z��6�   ��. # z 6�   #��z��6(  50       51      P� 52       � �� . . �53   "   ��  6E   Z�  �@�FocusVisualStyle�� 54   "    � ��$ 4,-1,0,0q�6<   55      P� 56       �@J�IsMouseOver . . �57   "   �� $ checkBoxBorder��6?   8   � ��6[   �� 58   "   $ checkBoxBorder��6@    � �� �#9575CD6\   �� 59   "   $ 
optionMark��69   8   � ��6Q   �� 5:   "   $ indeterminateMark��69   8   � ��6X   5;      P� 5<       � {� .  . �5=   "   �� $ checkBoxBorder��6?   8   � ��6[   �� 5>   "   $ checkBoxBorder��6@   8   � ��6\   �� 5?   "   $ 
optionMark��69   8   � ��6Q   �� 5@   "   $ indeterminateMark��69   8 	  � ��6X   5A      P� 5B       � �� . . �5C   "   �� $ checkBoxBorder��6?   8 
  � ��6[   �� 5D   "   $ checkBoxBorder��6@    � �� �#9575CD6\   �� 5E   "   $ 
optionMark��69   8   � ��6Q   �� 5F   "   $ indeterminateMark��69   8   � ��6X   5G      P� 5H       �@d�	IsChecked$
 trueY�6;   . �5I   "   �� $ 
optionMark��6<    �@J�Opacity$ 1Q�6T   �� 5J   "   $ indeterminateMark��6<    �@J�Opacity$ 0Q�6[   5K      P� 5L       6;   Z�  �@d�	IsChecked. �5M   "   �� $ 
optionMark��6<    �@J�Opacity$ 0Q�6T   �� 5N   "   $ indeterminateMark��6<    �@J�Opacity$ 1Q�6[   5O      5Q      5S      5T      5U      .��5V      �  5W   
   �� 5Y      $	��21* �6   �� 5Z      $��4* �6    � RowDefinitions 5\   
   �� 5]      $��50 �6   �� 5^      .+�5`   
   � $��0��6   $��2��6    5a      �� 5b      $	��438 �6#   .+�5k      �� $��30��6   $��30��6    $��0,10,-552,0q�6,   $��Right=�6A   $	��Top=�6]   ��5l      �� 5m      " ��6   .�5n      ��  � �� �#0072BC67   �� 5o       � �� 5p      �� 5q   "   " ��62   .R�5r   &   �� $��30��6-   $��30��68   $
 15��6D   #��z��6V   ._�5s   *   � .+�5t   .   �� $��Center=�6?   $��Center=�6\   5u   +   5v   '   5w   #   5y       �� Triggers 5z      P� 5{       �@J�IsMouseOver . . �5|   "   ��  � �� �#0053896?   5}      5      .��5�      �� $��Center=�6!   $��Center=�6>   .��5�      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Rotate=�6#   $��16��61   $��16��6=      
Foreground
 �����6H   5�      5�      �� 5�       �� Orientation$ 
Horizontal=�6   $��Center=�5�      $��0��5�      $��522,0,-522,0q�6)   $��28��6@   .+�5�        $ Search=�6   $��20��6-   $��20��69    �#0072BC6D   �� 5�      -   5         ��Name$ 
txttimkiem��5�      $��	Search...��6.   $��13(�5�      $��24��5�      $	��300��5�      
������ $��Medium"�5�      $��
Montserrat)�5�      
������� �� 
CaretBrush
 �����
�������$��0,0,0,1q�5�      $��Center=�5�      5�      5�      �� 5�      -   5         ��Name$ 	bttimkiem��5�      $��Tìm kiếm��5�      $��12(�5�      $��
Montserrat)�5�       � Cursor$
 Hand��5�      $��Medium"�5�      $��0q�5�      
�������$	��Top=�5�      $��0,10,-507,0q�6E   $��90��6Z   $��30��6e   $��Right=�6q   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#0072BC67   �� 5�       � �� 5�      �� 5�   "   " ��62   .R�5�   &   �� $��30��6-   $
 5��5�   5   #��z��5�   5   ._�5�   *   �� $��Center=�6;   $��Center=�5�   G   5�   '   5�   #   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   ��  � �� �#0053896?   5�      5�      5�      �� 5�      -   5        $ btxoakhachhang��5�      $
��Xoá��5�      $��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��Medium"�5�      $��0q�5�      
�������$��Center=�5�      $��30��6I   $��103,0,245,0q�6U   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#0072BC67   �� 5�       � �� 5�      �� 5�   "   " ��62   .R�5�   &   �� $��30��6-   $
 5��5�   )   #��z��5�   )   ._�5�   *   �� $��Center=�6;   $��Center=�5�   -   5�   '   5�   #   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   ��  � �� �#0053896?   5�      5�      5�      5�      �� 5�   
   $��1��6   ���#F0F8FF$
 5��5�      $ 10q�5�      $��2��6   ._�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ dgkhachhang��5�   �     DataGridStyle1#���  6     DataGridCellStyle1   	CellStyle# �  6@     DataGridColumnHeaderStyle1    ColumnHeaderStyle#  �  6q     DataGridRowStyle1!   RowStyle#! �  6�   $��5��6�     5�        StackPanelStyle��%�   &	       �� 5�      " ��64   .�5�      ��  �@��Orientation$ 
Horizontal=�68   �� 5�       � ��$ Center=�6>   5�      5�      "   Columns" 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn#   CanUserResize# .  $   Width5  /System.Windows.Controls.DataGridLengthConverter$
$ Auto 6C   %   HeaderTemplate% 5�      �� 5�      .R�5�   "   �� & ��Name$& chkSelectAll��6S   -   5        #��[ 5�   +   ' d� 	IsChecked' 6i   �� *IsAllSelected+6�   5�      (   CellTemplate( 5�      �� 5�      .R�5�   "   �� -   5        #��[ 5�   e   ' 6�   �� *
IsSelected+) �� UpdateSourceTrigger$) PropertyChanged=�* �� Mode$* TwoWay=�5�      5�        5�      +   
IsReadOnly+ . $
$ auto 6@   ( 5�      �� 5�      .R�5�   "   �� $ 
Horizontal=�6-   .+�5  &   �� $ btdgsua��6-   -   5        ���#2980b9  gridEditButton#��[ 5  T   $��11 0 0 0q�6|   .��5  *   . # (MahApps.Metro.IconPacks.PackIconMaterial  ,   Kind$, PencilOutline=�6@     gridButtonIcon#��[ 6U   5  '   �� 5  &   $ btdgxoa��6-   -	   5          gridRemoveButton#��[ 5  >   $��10 0 0 0q�6h   .��5  *     $, DeleteOutline=�6@   #��[ 6U   5	  '   5
  #   5     5     0	  *System.Windows.Controls.DataGridTextColumn	  5     -   Header$	- STT��6)   + . $$ 50 6H   1
  +System.Windows.Controls.DataGridBoundColumn. 
  Binding. 6S   �� *stt+	  5     $- Mã khách hàng��6)   + . $	$ 120 6R   . 6^   �� *ma+	  5     $- Tên khách hàng��6)   + . $	$ 120 6S   . 6_   �� *ten+	  5     $- 
Ngày sinh��6)   + . # .  $	$ 100 6d   . 6p   �� *
ngaysinh+	  5     $- Giới tính��6)   + . $$ 80 6N   . 6Y   �� *
gioitinh+	  5     $- Địa chỉ��6)   + . $	$ 100 6M   . 6Y   �� *diachi+	  5     $- Số điện thoại��6)   + . $	$ 110 6S   . 6_   �� *sdt+	  5     $- 	Số CCCD��6)   + . $	$ 120 6M   . 6Y   �� *cccd+	  5     $- Ngày cấp��6)   + . # .  $	$ 100 6c   . 6o   �� *	ngaycap+	  5     $- 
Nơi cấp��6)   + . $	$ 100 6M   . 6Y   �� *noicap+	  5     $- Ngày tạo thẻ��6)   + . # .  $	$ 100 6g   . 6s   �� *	ngaytao+	  5     $- Điểm thưởng��6)   + . $	$ 110 6Q   . 6]   �� *diem+5     51     �� 53  
   -
   5        $ btthemkhachhang��53     $��0��6*   $��Thêm��55     $��12(�56     $��
Montserrat)�57     $
 Hand��58     $��Medium"�59     $��0q�5:     
�������$��Center=�5<     $
��Left=�6N   $��90��6i   $��10,0,0,0q�6t   ��54     �� *LoginCommand+��5=     �� 5>     " ��6   .�5?     ��  � �� �#0072BC63   �� 5@      � �� 5A     �� 5B     " ��6.   .R�5C  "   �� $��30��6)   $
 5��5D  5   #��z��5E  5   ._�5F  &   �� $��Center=�67   $��Center=�5G  G   5H  #   5I     5K      5L     P� 5M      �@J�IsMouseOver . . �5N     ��  � �� �#0053896;   5O     5Q     5S     5W     5X     