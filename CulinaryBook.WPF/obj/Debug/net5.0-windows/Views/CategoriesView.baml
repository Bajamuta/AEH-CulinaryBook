   M S B A M L   `   `   `  ����K  GCulinaryBook.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CulinaryBook.WPF.ViewsCulinaryBook.WPF.Views  5      +    %CulinaryBook.WPF.Views.CategoriesView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CulinaryBook.WPF.Views     5      .��5	      � $��20q�6     � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $��* �6    6-   .+�5      �� $��0��6   $��Categories page��6%   � 5      $��1��6   $��Center=�6%   $��0 20 0 0q�6@   .+�5      �� $	��200��6   ��6&   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��20 0 0 0q�6   $��Search��6+   ��6<   �� *SearchCategoryCommand+5      �� 5      $��2��6   $��Get All��6"   ��64   �� *GetAllCategoriesCommand+�� 5      $��3��6   $��0 20 0 0q�6#   $��Center=�65   
������ ��5   0   �� *
Categories+$ PropertyChanged=� �� SelectedItem 5      �� *SelectedCategory+��5      �� 5      .R�5       � $��10q�6    5!      �� 5"   "   $��* �60     5$      �� 5%   "   $��* �63   �� 5&   "   $	��100 �63   .+�5(      �� $��0��6(   ��68   �� *Name+$ PropertyChanged=�5)      5*      5,      5-      � 5.   
   $��1��6   ��5/      �� 50       �� 
TargetType" �6   .�51      ��  �� Property � y� �� Value$ Hidden=�63    �� Triggers 52      �� 53       �� Binding 54      �� *
IsLogged+$ PropertyChanged=�	 �� Value	 True55      .a�56      ��  � y�$ Visible=�6;   57      59       5;      �� 5<      $
��Auto �6    �� 5=      $
��Auto �6    �� 5>      $
��Auto �6    .+�5@      �� $��0��6   .+�5A      �� $
��Name��6   $
��Auto��6'   �� 5B      $	��300��6   $��10 0 0 0q�6&   ��68   �� *CategoryName+$ PropertyChanged=�5C      �� 5D      $��1��6   .+�5E      �� $��Description��6   $
��Auto��6.   �� 5F      $	��300��6   $��10 0 0 0q�6&   ��68   �� *CategoryDescription+$ PropertyChanged=�5G      �� 5H      $��2��6   $��Add Category��6"   ��69   �� *AddCategoryCommand+5I      � 5J   
   $��1��6   ��5K      �� 5L      " �6   .�5M      ��  � y�$ Hidden=�63    5N      �� 5O       5P      �� *
IsLogged+$ PropertyChanged=�		 False5Q      .a�5R      ��  � y�$ Visible=�6;   5S      5U       5W      �� 5X      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5Z      $
��Auto �6    .+�5\      �� $��0��6   .+�5]      �� ��6   �� *SelectedCategory.Name+$ PropertyChanged=��� 5^      ��6   �� *SelectedCategory.Description+$ PropertyChanged=�5_      �� 5`      $��1��6   5a      5e      5f      5h      