   M S B A M L   `   `   `  ����N  JTeamCityScreensaver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Mo.TeamCityScreensaver.controlsMo.TeamCityScreensaver.controls  5   @   O,clr-namespace:Mo.TeamCityScreensaver.convertMo.TeamCityScreensaver.convert  5   	   (    "Mo.TeamCityScreensaver.ScreenSaver   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    66   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bcontrols-clr-namespace:Mo.TeamCityScreensaver.controls     6@   >local,clr-namespace:Mo.TeamCityScreensaver.convert     5   	   -   5          � Title$  Screensaver��5   D   
������ $	��300��6q   $	��300��5   	    � 
ResizeMode$ NoResize=�6    � WindowState$ 	Maximized=�6+    � WindowStyle$
 None=�5   ]    � Topmost .  � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5      9   3Mo.TeamCityScreensaver.convert.ProjectFailConverter   projectFailConverter3   -Mo.TeamCityScreensaver.convert.BrushConverter  brushConverter��%:   &	        &	        5      6!     5	      6   5
      .��5      ]� ��. .+�5      �� -   5         ��Name$ ProjectsPanelCtrl��5      $��Right=�6X   $��5,40,5,0q�5      ��5   .   �� *ProjectList.Items+��5      �� 5   
   .R�5      A� 	 A� Columns$	 1��6   
������ 6$   5      ��5      �� 5   
   .R�5      ]� 
 ]�Name$
 dockFail��6   ��5      `� 5       `� 	Converter# [ 6   .1�5      ��  �� Path$ Error�6   5      .+�5      �� $
��Left=�6.   
���������6   �� *Name+6D   �� 5      $�� has ��6   
�������6%   �� 5      $	��Top=�6   
���������5      `� 5       # [  6   .1�5!      �� $ Error�6   �� 5"       �� ElementName$ dockFail��6   $ .�63   5#      5%      5&      5'      5)      5   /Mo.TeamCityScreensaver.controls.ProjectsControl  5*      -   5          Name$ ProjectsCtrl��5*      $	��Top=�65   
������ 5+      5,      5.      