   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      (    "CourseProj.MVVM.Views.ContactsView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      $	��200 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� BitmapScalingMode$ HighQuality=�6   ��5      �� 5       �� 	UriSource$y sE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\JewelryLogo1.png?�6   5       �� 5"   
   $��Каталог��6   $��0��5#      $��1��5$      $��24(�5%         MenuButtonTheme#��[  5&      ��5'      �� *NavigateToStoreClientCommand+�� 5)   
   $#��Починка изделий��6   $��0��5*      $��2��5+      $��24(�5,      #��[  5-      ��5.      �� *NavigateToRepairCommand+�� 50   
   $��Контакты��6   $��0��51      $��3��52      $��24(�53        SelectedMenuButtonTheme#��[ 54      �� 56   
   $��Мои заказы��6   $��0��57      $��6��58      $��24(�59      #��[  5:      ��5;      �� *NavigateToOrdersClientCommand+�� 5=   
   $��
Выйти��6   $
��Left=�5>      $��22(�5?      $��0��5@      $��7��5A        MenuExitTheme#��[ 5B      ��5C      �� *NavigateToExitCommand+�� 5E   
   $��1��6   $��1��5F      $��Center=�5G      $��10q�5H      $ HighQuality=�5I      ��5J      �� 5K      $� �E:\2 курс\2 семестр\OOP 2\курсач\CourseProject\CourseProj\CourseProj\Images\ikonka-telefona-dliya-vizitki-01.png?�6   5M      �� 5O   
   $#��Телефон: +375299763488��6   $��1��5P      $��2��5Q      $��22(�5R      $
��Wrap=�5S       �� TextAlignment$ Center=�5T      $��Center=�5U      $��	20,0,20,0q�5V      
���� K�5W      �� 5Y   
   $��2��6   $��1��5Z      $��Center=�5[      $��10q�5\      $ HighQuality=�5]      ��5^      �� 5_      $r lE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\CourseProj\CourseProj\Images\address--v1.png?�6   5a      �� 5c   
   $A��;Наш адрес: г.Минск, ул.Сурганова,5��6   $��2��5d      $��2��5e      $��22(�5f      $
��Wrap=�5g      $ Center=�5h      $��Center=�5i      
���� K�5j      �� 5l   
   $��3��6   $��1��5m      $��Center=�5n      $��10q�5o      $ HighQuality=�5p      ��5q      �� 5r      $� �E:\2 курс\2 семестр\OOP 2\курсач\CourseProject\CourseProj\CourseProj\Images\w512h5121377939682185078emailmailstreamline.png?�6   5t      �� 5v   
   $#��Email: jewelryStore11@mail.ru��6   $��3��5w      $��2��5x      $��22(�5y      $
��Wrap=�5z      $ Center=�5{      $��Center=�5|      
���� K�5}      �� 5   
   $C��=Также наши товары представлены в:��6   $��1��5�      $��3��5�      $��3��5�      $��22(�5�      $ Center=�5�      $��Center=�5�      $��	20,0,20,0q�5�        textBlockStyle#��[ 5�      �� 5�   
   $G��AЮвелирный магазин "Облачное золото"��6   $��1��5�      $��3��5�      $��4��5�      $��22(�5�      $ Center=�5�      $��Center=�5�      $��	20,0,20,0q�5�      
���� K�5�      �� 5�   
   $O��IЮвелирный магазин "Ювелирные украшения"��6   $��1��5�      $��3��5�      $��5��5�      $��22(�5�      $ Center=�5�      $��Center=�5�      $��	20,0,20,0q�5�      
���� K�5�      5�      5�      