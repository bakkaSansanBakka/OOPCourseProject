   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      +    %CourseProj.MVVM.Views.OrdersAdminView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� BitmapScalingMode$ HighQuality=�6   ��5      �� 5       �� 	UriSource$y sE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\JewelryLogo1.png?�6   5      �� 5!   
   $��Каталог��6   $��0��5"      $��1��5#      $��24(�5$         MenuButtonTheme#��[  5%      ��5&      �� *NavigateToStoreAdminCommand+�� 5(   
   $��Заказы��6   $��0��5)      $��2��5*      $��24(�5+        SelectedMenuButtonTheme#��[ 5,      �� 5.   
   $��
Выйти��6   $
��Left=�5/      $��22(�50      $��0��51      $��7��52        MenuExitTheme#��[ 53      ��54      �� *NavigateToExitCommand+�� 56   
   $��1��6   $!��Заказы изделий��57      $��26(�58       �� TextAlignment$ Center=�59      $��Center=�5:      $��	20,0,20,0q�5;      
���� K�5<      �� 5>   
   $��2��6   $&�� Заказы на починку��5?      $��26(�5@      $ Center=�5A      $��Center=�5B      $��	20,0,20,0q�5C      
���� K�5D      �� 5F   
   -   5         ��Name$ 	ScrollBar��5F      $��1��5G      $��1��5H      $��7��5I      $
��Auto=�5J      $��Hidden=�5K      $��10q�5L      .��5M      �� -   5         ��Name$ 	ItemsList��5N      
�������$��Stretch=�5P      $��0q�5Q      ��5O      ��  �� Path$ JewelryOrdersList� �� SelectedItem 5R      �� *SelectedItem+	 �� Mode$	 TwoWay=�
 � 	Resources
 5U       �� 
TargetType �� Property & "JewelryOrdersListViewTemplateAdmin �� Value��%R   '��       7  �� 5V      " ��6   .�5W      ��  � ��8   65   5X      5Y      5Z      5[      �� 5]   
   -   5        $ ScrollBarNew��5]      $��2��5^      $��1��5_      $��7��5`      $
��Auto=�5a      $��Hidden=�5b      $��10q�5c      .��5d      �� -   5        $ RepairItemsList��5e      
�������$��Stretch=�5g      $��0q�5h      ��5f      �� $ RepairOrdersList� 5i      �� *SelectedRepairItem+$	 TwoWay=�
 5l       % !RepairOrdersListViewAdminTemplate��%R   '��       7  �� 5m      " ��6   .�5n      ��  � ��8   65   5o      5p      5q      5r      5t      5u      