   M S B A M L   `   `   `  ����E  ACourseProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CourseProj.MVVM.ViewsCourseProj.MVVM.Views  5      A%clr-namespace:CourseProj.UserControlsCourseProj.UserControls  5      )    #CourseProj.MVVM.Views.RegisteryView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CourseProj.MVVM.Views     5      9uscontr%clr-namespace:CourseProj.UserControls     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $	��130 �6   �� 5      �� 5      �� 5      $��117.377 �6   �� 5      $��12.623 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��
Назад��6   $��22(�5      $��40��5       $	��120��5!      $��0��5"      $��0��5#         buttonStyle#��[  5%      ��5$      �� *NavigateBackCommand+5%      �� 5'   
   $��Регистрация��6   $��1��5(      $��1��5)      $��Center=�5*      $��Center=�5+      $��28(�5,      $��2��5-        textBlockStyle#��[ 5.      �� 50   
   $%��Имя пользователя��6    �� TextAlignment$ Right=�51      $��22(�52      $��1��53      $��2��54      $��Center=�55      $��0,0,20,0q�56      #��[ 57      �� 59   
   $��24(�6   $��2��5:      $��2��5;      $��40��5<      $	��210��5=        textBoxStyle#��[ 5?      ��5>      �� *
UserName+5?      �� 5A   
   $'��!Электронная почта��6   $ Right=�5B      $��22(�5C      $��1��5D      $��3��5E      $��Center=�5F      $��0,0,20,0q�5G      #��[ 5H      �� 5J   
   $��Пароль��6   $ Right=�5K      $��22(�5L      $��1��5M      $��4��5N      $��Center=�5O      $��0,0,20,0q�5P      #��[ 5Q      �� 5S   
   -   5         ��Name$ MailTextBox��5T      $��24(�5S      $��2��5U      $��3��5V      $��40��5W      $	��210��5X      #��[ 5Y      ��5Z      �� *Email+6)   �� 5]   
   $��4��6   $��2��5^      $	��0.3q�5_      
���   �$	��210��5a      $��40��5b      ._�5c      :   4CourseProj.UserControls.BindableWatermarkPasswordBox  -   5          Name$ PasswordTextBox��5c   3   :   4CourseProj.UserControls.BindableWatermarkPasswordBox   	LostFocus$! PasswordTextBox_OnLostFocus��5j   3   $	��210��5d   3   $��40��5e   3   $��22(�5f   3   $��1q�5g   3   
���� K�   Password 5i   3   �� *
Password+5j   3   5k      �� 5m   
   $%��Повторите пароль��6   $ Right=�5n      $��22(�5o      $��1��5p      $��5��5q      $��Center=�5r      $��0,0,20,0q�5s      #��[ 5t      �� 5v   
   $��5��6   $��2��5w      $	��0.3q�5x      
���   �$	��210��5z      $��40��5{      ._�5|        -   5        $ ConfirmPasswordTextBox��5|   3   $	��210��5}   /   $��40��5~   /   $��22(�5   /   $��1q�5�   /   
���� K� 5�   *   �� *ConfirmPassword+5�      �� 5�   
   $*��$Зарегистрироваться��6   $��22(�5�      $��45��5�      $	��240��5�      $��1��5�      $��6��5�      $��2��5�      #��[  5�      ��5�      �� *RegisterUserCommand+5�      5�      5�      