   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      .    (CourseProj.MVVM.Views.ItemInfoClientView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� BitmapScalingMode$ HighQuality=�6   ��5      �� 5       �� 	UriSource$y sE:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\JewelryLogo1.png?�6   5      �� 5!   
   $��Каталог��6   $��0��5"      $��1��5#      $��24(�5$         SelectedMenuButtonTheme#��[  5%      �� 5'   
   $#��Починка изделий��6   $��0��5(      $��2��5)      $��24(�5*        MenuButtonTheme#��[ 5+      ��5,      �� *NavigateToRepairCommand+�� 5.   
   $��Контакты��6   $��0��5/      $��3��50      $��24(�51      #��[ 52      ��53      �� *NavigateToContactsCommand+�� 55   
   $��Мои заказы��6   $��0��56      $��6��57      $��24(�58      #��[ 59      ��5:      �� *NavigateToOrdersClientCommand+�� 5<   
   $��
Выйти��6   $
��Left=�5=      $��22(�5>      $��0��5?      $��7��5@        MenuExitTheme#��[ 5A      ��5B      �� *NavigateToExitCommand+�� 5D   
   $��
Назад��6   $��1��5E      $��1��5F      $��20(�5G      $��45��5H      $	��130��5I      $
��Left=�5J      $��20,0,0,0q�5K        buttonStyle#��[ 5L      ��5M      �� *NavigateToStoreClientCommand+�� 5O   
   $��1��6   $��2��5P      $��4��5Q      $��20q�5R      $
��Fill=�5S      $ HighQuality=�5U      ��5T      �� *Image+5U      �� 5W   
   $��2��5X      $��2��5Y      $��22(�5Z      $��60��5[       �� TextAlignment$
 Left=�5\      $��Center=�5]      $��	20,0,20,0q�5^      $
��Wrap=�5_        textBlockStyle#��[ 5`      ��5W      ��  �� Path$
 Name�5`      �� 5b   
   $��2��5c      $��3��5d      $��2��5e      $��22(�5f      $	��130��5g      $
 Left=�5h      $
��Wrap=�5i      $��Center=�5j      $��	20,0,20,0q�5k      
���� K���5b      �� $ Description�5l      �� 5n   
   $��2��5o      $��5��5p      $��22(�5q      $
 Left=�5r      $��Center=�5s      $��	20,0,20,0q�5t      
���� K���5n      ��  �� StringFormat$ {0} руб.��$ Price�5u      �� 5w   
   $��Заказать��6   $��1��5x      $��2��5y      $��6��5z      $��45��5{      $	��190��5|      $��20(�5}      #��[ 5~      ��5      �� *NavigateToOrderClientCommand+5�      5�      