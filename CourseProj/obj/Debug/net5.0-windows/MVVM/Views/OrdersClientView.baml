   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      ,    &CourseProj.MVVM.Views.OrdersClientView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� BitmapScalingMode$ HighQuality=�6   ��5      �� 5       �� 	UriSource$y sE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\JewelryLogo1.png?�6   5      �� 5!   
   $��Каталог��6   $��0��5"      $��1��5#      $��24(�5$         MenuButtonTheme#��[  5%      ��5&      �� *NavigateToStoreClientCommand+�� 5(   
   $#��Починка изделий��6   $��0��5)      $��2��5*      $��24(�5+      #��[  5,      ��5-      �� *NavigateToRepairCommand+�� 5/   
   $��Контакты��6   $��0��50      $��3��51      $��24(�52      #��[  53      ��54      �� *NavigateToContactsCommand+�� 56   
   $��Мои заказы��6   $��0��57      $��6��58      $��24(�59        SelectedMenuButtonTheme#��[ 5:      �� 5<   
   $��
Выйти��6   $
��Left=�5=      $��22(�5>      $��0��5?      $��7��5@        MenuExitTheme#��[ 5A      ��5B      �� *NavigateToExitCommand+�� 5D   
   $��1��6   $!��Заказы изделий��5E      $��26(�5F       �� TextAlignment$ Center=�5G      $��Center=�5H      $��	20,0,20,0q�5I      
���� K�5J      �� 5L   
   $��2��6   $&�� Заказы на починку��5M      $��26(�5N      $ Center=�5O      $��Center=�5P      $��	20,0,20,0q�5Q      
���� K�5R      �� 5T   
   -   5         ��Name$ 	ScrollBar��5T      $��1��5U      $��1��5V      $��7��5W      $
��Auto=�5X      $��Hidden=�5Y      $��10q�5Z      .��5[      �� -   5         ��Name$ 	ItemsList��5\      
�������$��Stretch=�5^      $��0q�5_      ��5]      ��  �� Path$ JewelryOrdersList� �� SelectedItem 5`      �� *SelectedItem+	 �� Mode$	 TwoWay=�
 � 	Resources
 5c       �� 
TargetType �� Property ! JewelryOrdersListViewTemplate �� Value��%R   '��       7  �� 5d      " ��6   .�5e      ��  � ��8   65   5f      5g      5h      5i      �� 5k   
   -   5        $ ScrollBarNew��5k      $��2��5l      $��1��5m      $��7��5n      $
��Auto=�5o      $��Hidden=�5p      $��10q�5q      .��5r      �� -   5        $ RepairItemsList��5s      
�������$��Stretch=�5u      $��0q�5v      ��5t      �� $ RepairOrdersList� 5w      �� *SelectedRepairItem+$	 TwoWay=�
 5z         RepairOrdersListViewTemplate��%R   '��       7  �� 5{      " ��6   .�5|      ��  � ��8   65   5}      5~      5      5�      5�      5�      