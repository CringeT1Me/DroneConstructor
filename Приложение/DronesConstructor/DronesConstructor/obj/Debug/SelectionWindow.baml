   M S B A M L   `   `   `  ����L  HDronesConstructor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DronesConstructorDronesConstructor  5   	   '    !DronesConstructor.SelectionWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DronesConstructor     5   	     � Title$'  !Выбор компонентов��5   	   $	��720��6#   $
��1280��60   
���iii� � WindowState$ 	Maximized=�6R   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.2* �6   6,   �� 5      6   �� 5      $
��0.2* �6   6,   .+�5   
   �� -   5         ��Name$ 	stepLabel��5      $��0��6#   $��0��60   $!��Выберите мотор��6@   $��Center=�6Y   $��Center=�6v   $��25(�6�   $��2q�6�   
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5       $��1��6   $��Center=�62   $��Center=�6O   $��25(�6j   $��2q�6x   
�������   RowBackground
 �iii�   AlternatingRowBackground
 �iii�   CanUserAddRows .     CanUserDeleteRows .  	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6  
   SelectionMode$
 Single=�6     HeadersVisibility$ Column=�6-     
IsReadOnly .  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%]   '        7 �� 5      8   "  6Q   .�5      ��  � ��
 �iii�63   5      5      5      �� 5   
   -   5         ��Name$ applyButton��5      $��2��6   $
��50,0q�63   $��30(�6A   $��Center=�6O   $��Center=�6s   $��50��6�   $	��200��6�   $��
Далее��6�   $��Right=�6�   $	��500��6�   $��Stretch=�6�   6$  5      5      