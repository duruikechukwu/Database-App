   M S B A M L   `   `   `  ����G  CDatabase App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Database_AppDatabase_App  5   	       Database_App.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Database_App     5   	     � Title$  Database Application��5   	   $	��768��6&   $
��1366��63    � WindowState$ 	Maximized=�6@   .��5	      � 
�������.+�5
   
   o� $
��Left=�6   $��25��6*   $	��Top=�66   $
��1366��6N   .@�5      m� $
��File��6   $��7,0,7,0q�6%   $��25��67   .@�5      m� -   5         m�Name$ 
manuopendb��5      $��Open Database Version��6/   $��25��6N   m� 5      -   5        $ 
menusavedb��5      $��Save Database Version��6/   $��25��6N   m� 5      -   5        $ menuexitapp��5      $
��Exit��60   $��25��6>   5      m� 5      $
��Edit��6   $��7,0,7,0q�6%   $��25��67   .@�5      m� -   5        $ manudeleteselected��5      $��Delete selected record��67   $��25��6W   5      5      c� 5   
   $��25��6   $��0,25,0,0q�6   $	��Top=�61   .@�5      �� -   5         ��Name$ 	btnopendb��5      $��25��6(   $��25��64    � ToolTip$! Open Saved Database Version��6?   .��5      �� $��icons/open.jpg��6   5      �� 5      -   5        $ 	btnsavedb��5      $��25��6(   $��25��64   $��15,0,0,0q�6?   $# Save Current Database version��6Q   .��5      �� $��icons/save.jpg��6   5      �� 5      -   5        $ 
btnsearcdb��5      $��25��6)   $��25��65   $��	950,0,0,0q�6@   $ search by name or id��6S   .��5      �� $ ��icons/magnifying-glass.png��6   5      �� 5       -   5         ��Name$ txtsearchdb��5       $��25��6+   $��15,0,0,0q�67    �� TextWrapping$ NoWrap=�6I   $��Search Records��6_   $	��Top=�6u   $	��220��6�   6�   5!      �� 5$   
    �� TabStripPlacement$
 Left=�6   $
��Left=�6/   $	��600��6J   $��0,50,0,0q�6W   $	��Top=�6i   $
��1366��6�   .@�5%      �� $��CREATE RECORD��6   .��5&      � 
�������.+�5'      �� -	   5        $ btncreaterecord��5'      $��
CREATE NEW��66   $��7,0,7,0q�6K   $��25��6]   $��107,516,0,53q�6j   $
��Left=�6�   6�   �� 5(      -
   5        $ txtupdateid��5(      $
��Left=�63   $��25��6N   $��617,516,0,0q�6Z   $ NoWrap=�6o   $��Enter ID��6�   $	��Top=�6�   $	��120��6�   6�   �� 5)      -   5        $ btnupdaterecord��5)      $��UPDATE EXISTING��66   $��7,0,7,0q�6P   $��25��6b   $��759,516,0,53q�6n   $
��Left=�6�   6�   �� 5*      $
��Left=�6!   $	��447��6=   $��
107,10,0,0q�6J   $	��Top=�6^   $	��118��6v   .+�5+      �� $��25��6    $��3q�6,   $��0, 10q�68   $��	Client ID��6G   $
��Bold"�6[   �� 5,      $��25��6    $��3q�6,   $
��0,10q�68   $
��Name��6F   $
��Bold"�6U   �� 5-      $��25��6    $��3q�6,   $
��0,10q�68   $��SurName��6F   $
��Bold"�6X   �� 5.      $��25��6    $��3q�6,   $
��0,10q�68   $��
Birth Date��6F   $
��Bold"�6[   50      �� 51      $
��Left=�6!   $	��447��6<   $��
225,10,0,0q�6I   $	��Top=�6]   $	��396��6u   .+�52      �� -   5        $ txtclientid��52   "   $
��Left=�67   $
��0,10q�6R   $��25��6`   $	��350��6l   $
��Bold"�6x   $��3q�6�   �� 53      -   5        $ txtname��53   "   $
��Left=�63   $
��0,10q�6N   $��25��6\   $	��350��6h   $
��Bold"�6t   $��3q�6�   �� 54      -   5        $ 
txtsirname��54   "   $
��0,10q�68   $��25��6F   $	��350��6R   $
��Left=�6^   $
��Bold"�6y   $��3q�6�   (  "System.Windows.Controls.DatePicker  56      -   5          Name$ datebirthdate��56   %   $��25��6<   	   SelectedDateFormat$	 Short=�6I   $
��0,10q�6d   $
��Left=�6r   $	��350��6�   $
��Bold"�6�   57      59      5:      �� 5;      $��VIEW RECORD��6   .��5<      � 
�������.+�5>      �� -   5        $ btndeleteselected��5>      $��DELETE SELECTED��68   $��7,0,7,0q�6R   $��25��6d   $��107,516,0,53q�6p   $
��Left=�6�   6�   �� 5?      -   5        $ txtdeletebyid��5?      $
��Left=�66   $��25��6Q   $��440,516,0,0q�6]   $��Enter ID��6r   
 �� TextAlignment$

 Left=�6�   $��Center=�6�   $ NoWrap=�6�   $	��Top=�6�   $	��120��6�   6  �� 5@      -   5        $ btndeletebyid��5@      $��DELETE BY ID��64   $��7,0,7,0q�6K   $��25��6]   $��565,516,0,53q�6i   $
��Left=�6   6�   &   System.Windows.Controls.DataGrid  5A      -   5          Name$ datdbrecords��5A         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6c   $	��429��6~   $
��1258��6�   $	��Top=�6�      Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6r      Header$ 	CLIENT ID��6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
clientid+   ClipboardContentBinding 6O   Z� 6|     5D      $ * 6n   $
 NAME��6x    62   �� *name+ 6K   Z� 6x     5E      $ * 6q   $ SURNAME��6{    62   �� *	surname+ 6N   Z� 6{     5F      $ * 6l   $ ID��6v    62   �� *id+ 6I   Z� 6v     5G      $ * 6s   $ 
BIRTH DATE��6}    62   �� *	birthdate+ 6P   Z� 6}     5H      $ * 6m   $	 AGE��6w    62   �� *age+ 6J   Z� 6w   5K      �� 5L      -   5        $ 
btnrefresh��5L      $��REFRESH��61   $��7,0,7,0q�6C   $��25��6U   $��967,516,0,53q�6a   $
��Left=�6w   6�   5N      5O      5Q      5T      5U      