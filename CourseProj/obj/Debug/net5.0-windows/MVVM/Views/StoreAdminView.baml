   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      *    $CourseProj.MVVM.Views.StoreAdminView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      �� 5      $	��100 �6   �� 5      $	��130 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� BitmapScalingMode$ HighQuality=�6   ��5      �� 5       �� 	UriSource$y sE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\JewelryLogo1.png?�6   5       �� 5"   
   $��Каталог��6   $��0��5#      $��1��5$      $��24(�5%         SelectedMenuButtonTheme#��[  5&      �� 5(   
   $��Заказы��6   $��0��5)      $��2��5*      $��24(�5+        MenuButtonTheme#��[ 5,      ��5-      �� *NavigateToOrdersAdminCommand+�� 5/   
   $��
Выйти��6   $
��Left=�50      $��22(�51      $��0��52      $��7��53        MenuExitTheme#��[ 54      ��55      �� *NavigateToExitCommand+�� 5C   
   $��2q�6   $��2��5D      $��2��5E       �� Padding$ 3q�5F      $��10q�5G      
�������._�5J      ��  �� Orientation$ 
Horizontal=�6   .+�5K      �� $��45��6   $
��Fill=�5L      $ HighQuality=�5M      $w��qE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\searchIcon.png��5N      �� 5P      $	��140��6   $��20(�5Q      $��10q�5R      $��0q�5S      $��Center=�5U      $��Center=�5V      ��5T      �� *SearchExpression+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5V      5W      5X      �� 5Z   
   $��2��6   $��2��5[      $��1��5\      $��Удалить��5]      $��45��5^      $	��190��5_      $��20(�5`        buttonStyle#��[ 5a       J� InputBindings 5b      d� 5c      	 d� MouseAction$	 	LeftClicke�6   
 �� Command
 5d      �� *DelteSelectedItemCommand+ �� CommandParameter 5e      �� *SelectedItem+5g      �� 5i   
   $��2��6   $��2��5j      $��2��5k      $��Изменить��5l      $��45��5m      $	��190��5n      $��20(�5o      #��[ 5p       5q      d� 5r      $	 	LeftClicke�6   
 5s      �� *NavigateToEditItemCommand+ 5t      �� *SelectedItem+5v      �� 5x   
   $��Добавить��6   $��2��5y      $��2��5z      $��3��5{      $��45��5|      $	��190��5}      $��20(�5~      #��[ 5�      ��5      �� *NavigateToAddItemCommand+5�      �� 5�   
   -   5         ��Name$ VerticalScrollBar��5�      $��1��5�      $��8��5�      $
��Auto=�5�      $��Hidden=�5�      $��10q�5�      .��5�      �� -   5         ��Name$ 	ItemsList��5�      
�������$��Stretch=�5�      $��0q�5�      ��5�      ��  �� Path$ JewelryItemsList� �� SelectedItem 5�      �� *SelectedItem+$ TwoWay=� � 	Resources 5�       �� 
TargetType �� Property ( $JewelryItemsListViewTemplateForAdmin �� Value��%R   '��       7  �� 5�      " ��6   .�5�      ��  � ��8   65   5�      5�      5�      5�      5�      5�      