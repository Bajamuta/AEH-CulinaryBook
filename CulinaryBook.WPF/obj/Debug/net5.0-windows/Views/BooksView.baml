   M S B A M L   `   `   `  ����  CulinaryBook.WPF&     CulinaryBook.WPF.Views.BooksView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � $��20q�6     � ColumnDefinitions  5	   
   �� 5
      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��
Books page��6   � 5      $��1��6   $��Center=�6%   $��0 20 0 0q�6@   .+�5      �� $	��200��6   ��6&   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��20 0 0 0q�6   $��Search��6+   ��6<   �� *SearchBookCommand+5      �� 5      $��2��6   $��Get All��6"   ��64   �� *GetAllBooksCommand+�� 5      $��3��6   $��0 20 0 0q�6#   $��Center=�65   
������ ��5   0   �� *Books+$ PropertyChanged=� �� SelectedItem 5      �� *SelectedBook+��5      �� 5      .R�5      � $��10q�6    5       �� 5!   "   $��* �60     5#      �� 5$   "   $��* �63   �� 5%   "   $	��100 �63   .+�5'      �� $��0��6(   ��68   �� *Name+$ PropertyChanged=�5(      5)      5+      5,      � 5-   
   $��1��6   ��5.      �� 5/       �� 
TargetType" �6   .�50      ��  �� Property � y� �� Value$ Hidden=�63    �� Triggers 51      �� 52       �� Binding 53      �� *
IsLogged+$ PropertyChanged=�	 �� Value	 True54      .a�55      ��  � y�$ Visible=�6;   56      58       5:      �� 5;      $
��Auto �6    �� 5<      $
��Auto �6    .+�5>      �� $��0��6   .+�5?      �� $
��Name��6   $
��Auto��6'   �� 5@      $	��300��6   $��10 0 0 0q�6&   ��68   �� *
BookName+$ PropertyChanged=�5A      �� 5B      $��1��6   $��Add Book��6"   ��65   �� *AddBookCommand+5C      � 5D   
   $��1��6   ��5E      �� 5F      " �6   .�5G      ��  � y�$ Hidden=�63    5H      �� 5I       5J      �� *
IsLogged+$ PropertyChanged=�		 False5K      .a�5L      ��  � y�$ Visible=�6;   5M      5O       5Q      �� 5R      $
��Auto �6    �� 5S      $
��Auto �6    �� 5T      $
��Auto �6    .+�5V      �� $��0��6   .+�5W      �� ��6   �� *SelectedBook.Name+$ PropertyChanged=�5X      �� 5Y      $��1��6   5Z      5^      5_      5`      