   M S B A M L   `   `   `  ����K  GCulinaryBook.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CulinaryBook.WPF.ControlsCulinaryBook.WPF.Controls  5      U/clr-namespace:CulinaryBook.WPF.State.Navigators!CulinaryBook.WPF.State.Navigators  5      -    'CulinaryBook.WPF.Controls.NavigationBar   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CulinaryBook.WPF.Controls     5      ?nav/clr-namespace:CulinaryBook.WPF.State.Navigators     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��CULINARY BOOKS��6!      SecondaryBrush3#��[  67   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      	� $��0��6   $
��HOME��6*   0   *CulinaryBook.WPF.State.Navigators.ViewType   Home#��Z 5      ��5      �� *UpdateCurrentViewModelCommand+5      	� 5       $��1��6   $��BOOKS��6*      Books#��Z 5!      ��5    :   �� *UpdateCurrentViewModelCommand+5!      	� 5"      $��2��6   $��
CATEGORIES��6*      
Categories#��Z 5#      ��5"   ?   �� *UpdateCurrentViewModelCommand+5#      	� 5$      $��3��6   $��RECIPES��6*      Recipes#��Z 5%      ��5$   <   �� *UpdateCurrentViewModelCommand+5%      	� 5&      $��4��6   $��INGREDIENTS��6*      Ingredients#��Z 5'      ��5&   @   �� *UpdateCurrentViewModelCommand+5'      	� 5(      $��5��6   $��AUTHORS��6*      Authors#��Z 5)      ��5(   <   �� *UpdateCurrentViewModelCommand+5)      	� 5*      $��6��6   $��SHOWTIME��6*      Showtime#��Z 5+      ��5*   =   �� *UpdateCurrentViewModelCommand+5+      	� 5,      $��8��6   $��STEPS��6*   	   Steps#��Z	 5-      ��5,   :   �� *UpdateCurrentViewModelCommand+��5.      �� 5/      
 �� 
TargetType"
 	�6   .�50      ��  �� Property � y� �� Value$ Hidden=�67   6H    �� Triggers 51      �� 52       �� Binding 53   !   �� *Authenticator.IsLoggedIn+ �� UpdateSourceTrigger$ PropertyChanged=� �� Value True54   !   .a�55   "   ��  � y�$ Visible=�6?   56      58      5:      	� 5;      $��8��6   $��LOGIN��6*      Login#��Z 5<      ��5;   :   �� *UpdateCurrentViewModelCommand+��5=      �� 5>      "
 	�6   .�5?      ��  � y�$ Visible=�67   6I    5@      �� 5A       5B   !   �� *Authenticator.IsLoggedIn+$ PropertyChanged=� True5C   !   .a�5D   "   ��  � y�$ Hidden=�6?   5E      5G      5I      5J      � 5K   
   $��2��6   ��5L      �� 5M      "
 �6   .�5N      ��  � y�$ Hidden=�63    5O      �� 5P       5Q      �� *Authenticator.IsLoggedIn+$ PropertyChanged=� True5R      .a�5S      ��  � y�$ Visible=�6;   5T      5V       5X      �� 5Y      $��* �6#   �� 5Z      $
��Auto �6#   �� 5[      $
��Auto �6#   .+�5]      � $��1��6   $��0 0 20 0q�6(   .+�5^      �� $��	Logged as��6   $��0 0 20 0q�6-   �� 5_      ��6   �� * Authenticator.CurrentUser.Name+5`      	� 5a      $��2��6   $��LOGOUT��6*      Logout#��Z 5b      ��5a   ;   �� *LogoutCommand+5b      5c      5d      5e      