   M S B A M L   `   `   `  ����K  GCulinaryBook.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CulinaryBook.WPF.ControlsCulinaryBook.WPF.Controls  5      ,    &CulinaryBook.WPF.Views.IngredientsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <controls'clr-namespace:CulinaryBook.WPF.Controls     5      .��5
      � $��20q�6     � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��0��6   $��Ingredients page��6)   � 5      $��1��6   $��Center=�6)   $��0 20 0 0q�6D   .+�5      �� $	��200��6   ��6*   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��20 0 0 0q�6   $��Search��6/   ��6@   �� *SearchIngredientCommand+5      �� 5      $��2��6   $��Get All��6&   ��68   �� *GetAllIngredientsCommand+�� 5      $��3��6   $��0 20 0 0q�6'   $��Center=�69   
������ ��5   4   �� *Ingredients+$ PropertyChanged=� �� SelectedItem 5      �� *SelectedIngredient+��5       �� 5!      .R�5"      � $��10q�6#    5#   "   �� 5$   &   $��* �64     5&   "   �� 5'   &   $��* �67   �� 5(   &   $	��100 �67   .+�5*   "   �� $��0��6,   ��6<   �� *Name+$ PropertyChanged=�5+      5,      5.      5/      50      � 51   
   $��1��6   ��52      �� 53       �� 
TargetType" �6   .�54      ��  �� Property � y� �� Value$ Hidden=�63    �� Triggers 55      �� 56       �� Binding 57      �� *
IsLogged+$ PropertyChanged=�	 �� Value	 True58      .a�59      ��  � y�$ Visible=�6;   5:      5<       5>      �� 5?      $
��Auto �6    �� 5@      $
��Auto �6    �� 5A      $
��Auto �6    .+�5C      �� $��0��6   .+�5D      �� $
��Name��6   $
��Auto��6'   �� 5E      $	��300��6   $��10 0 0 0q�6&   ��68   �� *IngredientName+$ PropertyChanged=�5F      �� 5G      $��1��6   .+�5H      �� $��Junit��6   $
��Auto��6(   �� 5I      $	��300��6   $��10 0 0 0q�6&   ��68   �� *IngredientJunit+$ PropertyChanged=�5J      �� 5K      $��2��6   $��Add Ingredient��6"   ��6;   �� *AddIngredientCommand+5L      � 5M   
   $��1��6   ��5N      �� 5O      " �6   .�5P      ��  � y�$ Hidden=�63    5Q      �� 5R       5S      �� *
IsLogged+$ PropertyChanged=�		 False5T      .a�5U      ��  � y�$ Visible=�6;   5V      5X       5Z      �� 5[      $
��Auto �6    �� 5\      $
��Auto �6    �� 5]      $
��Auto �6    .+�5_      �� $��0��6   .+�5`      �� ��6   �� *SelectedIngredient.Name+$ PropertyChanged=��� 5a      ��6   �� *SelectedIngredient.Junit+$ PropertyChanged=�5b      �� 5c      $��1��6   5d      5h      5i      5j      