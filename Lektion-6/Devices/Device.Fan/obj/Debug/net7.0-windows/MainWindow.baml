   M S B A M L   `   `   `  ����E  ADevice.Fan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Device.Fan
Device.Fan  5   	       Device.Fan.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Device.Fan     5   	     � Title$   ��5   	   $	��250��6   $	��200��6   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   .+�5      ��    FontAwesome-Regular#��[  6   $	����6J   $	��120(�6Z   $��Center=�6i   $��Center=�6�   A� 5      $��80��6   $��80��6"   $��	2 -12 0 0q�6-   
�������6@   �� 5       J� RenderTransformOrigin$ 0.5 0.5&�6     FontAwesome-Solid#��[ 68   $	����6h   $��80(�6x   $��	0 -14 0 0q�6�   $��Center=�6�   $��Center=�6�   z�5      �� 5      -   5        FanBlade�� �� Angle$ 0Q�5   8   5      5      �� 5   
   -   5         ��Name$ ConnectivityStatus��5      $��1��60   $��Center=�6=   $
��5 20q�6Z   $��Disconnected��6h   5       � 	Resources 5        FanStoryboard �� 
TargetName �� TargetProperty W� From		 W� To
 g� RepeatBehavior��%�   &	       �� 5   
   .��5       W� $ FanBlade��5!      $ Angle�5"       05#      	 -3606   $
 Forever��5$      5&      5(      5)      