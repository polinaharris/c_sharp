   M S B A M L   `   `   `  ����   Polia02    Polia02.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Register��$	��700��$	��600��.���� .��� ����  �� Color$ 	LightPink�� � ColumnDefinitions �� $��1* �.+�� $��0��$��0��$��30q�.+��  �� $��1* ��� $��5* � � RowDefinitions �� $��5* ��� $��5* ��� $��5* ��� $��5* ��� $��5* �.+��� $��0��$��0��$��16(�$��0q�
�������$��Center=�$��Center=�.��Name�� $��0��$��1��
���   � �� TextWrapping$
 Wrap=�
������� �� TextAlignment$
 Left=�$��Center=�$��32(�$��8q����� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��0��$��16(�$��0q�
�������$��Center=�$��Center=�.��	Surname�� $��1��$��1��
���   �$
 Wrap=�
�������$
 Left=�$��Center=�$��32(�$��8q����� *	Surname+$ TwoWay=�$ PropertyChanged=��� $��2��$��0��$��16(�$��0q�
�������$��Center=�$��Center=�.��Email�� $��2��$��1��
���   �$
 Wrap=�
�������$��Italic$�$
 Left=�$��Center=�$��32(�$��8q����� *Email+$ TwoWay=�$ PropertyChanged=��� $��3��$��0��$��16(�$��0q�
�������$��Center=�$��Center=�.��
Birthday(� $��3��$��1��$��Center=�$��Center=�.��(  "System.Windows.Controls.DatePicker  -   $��BirthDatePicker��   FirstDayOfWeek$ Monday=�	   SelectedDate	 �� *
Birthday+$ TwoWay=�$ PropertyChanged=�
   Text
 �� *BirthdayText+$ OneWayToSource=�$ PropertyChanged=��� $��4��$��1��$��30q����� *RegisterCommand+.���� $��30(�	Proceed