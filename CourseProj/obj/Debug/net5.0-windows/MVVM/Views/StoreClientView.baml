   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      +    %CourseProj.MVVM.Views.StoreClientView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      $
��480* �6   �� 5      $
��230* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� BitmapScalingMode$ HighQuality=�6   ��5      �� 5       �� 	UriSource$y sE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\JewelryLogo1.png?�6   5      �� 5!   
   $��Каталог��6   $��0��5"      $��1��5#      $��24(�5$         SelectedMenuButtonTheme#��[  5%      �� 5'   
   $#��Починка изделий��6   $��0��5(      $��2��5)      $��24(�5*        MenuButtonTheme#��[ 5+      ��5,      �� *NavigateToRepairCommand+�� 5.   
   $��Контакты��6   $��0��5/      $��3��50      $��24(�51      #��[ 52      ��53      �� *NavigateToContactsCommand+�� 55   
   $��Мои заказы��6   $��0��56      $��6��57      $��24(�58      #��[ 59      ��5:      �� *NavigateToOrdersClientCommand+�� 5<   
   $��
Выйти��6   $
��Left=�5=      $��22(�5>      $��0��5?      $��7��5@        MenuExitTheme#��[ 5A      ��5B      �� *NavigateToExitCommand+�� 5D   
   $��2q�6   $��2��5E      $��2��5F       �� Padding$ 3q�5G      $��10q�5H      
�������._�5K      ��  �� Orientation$ 
Horizontal=�6   .+�5L      �� $��45��6   $
��Fill=�5M      $ HighQuality=�5N      $w��qE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\searchIcon.png��5O      �� 5Q      $	��140��6   $��20(�5R      $��5q�5S      $��0q�5T      $��Center=�5V      $��Center=�5W      ��5U      �� *SearchExpression+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5W      5X      5Z      �� 5\   
   -   5         ��Name$ 	ScrollBar��5\      $��1��5]      $��8��5^      $
��Auto=�5_      $��Hidden=�5`      $��10q�5a      .��5b      �� -   5        	 ��Name$	 	ItemsList��5c      
�������$��Stretch=�5e      $��0q�5f      ��5d      �� 
 �� Path$
 JewelryItemsList� �� SelectedItem 5g      �� *SelectedItem+$ TwoWay=� � 	Resources 5j       �� 
TargetType �� Property   JewelryItemsListViewTemplate �� Value��%R   '��       7  �� 5k      " ��6   .�5l      ��  � ��8   65   5m      5n      5o      5p      5q      5r      