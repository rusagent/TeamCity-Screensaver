   M S B A M L   `   `   `  ���� N  JTeamCityScreensaver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Mo.TeamCityScreensaver.controlsMo.TeamCityScreensaver.controls  O,clr-namespace:Mo.TeamCityScreensaver.convertMo.TeamCityScreensaver.convert  (    "Mo.TeamCityScreensaver.ScreenSaver   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Bcontrols-clr-namespace:Mo.TeamCityScreensaver.controls     >local,clr-namespace:Mo.TeamCityScreensaver.convert     -     � Title$  Screensaver��
������ $	��300��$	��300�� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � Topmost .  � DataContext ��  �� RelativeSource �� *Self+ � 	Resources 9   3Mo.TeamCityScreensaver.convert.ProjectFailConverter   projectFailConverter3   -Mo.TeamCityScreensaver.convert.BrushConverter  brushConverter��%   &	        &	          .��]� ��. .+��� -    ��Name$ ProjectsPanelCtrl��$��Right=�$��5,40,5,0q����� *ProjectList.Items+���� .R�A� 	 A� Columns$	 1��
������ ���� .R�]� 
 ]�Name$
 dockFail����`�  `� 	Converter# [ .1���  �� Path$ Error�.+��� $
��Left=�
������� �� Padding$ 	10,10,0,0q����� *Name+�� $�� has ��
�������$ 0,10,0,0q��� $	��Top=�
�������$ 	0,10,10,0q���`� # [  .1��� $ Error���  �� ElementName$ dockFail��$ .�5   /Mo.TeamCityScreensaver.controls.ProjectsControl  -     Name$ ProjectsCtrl��$	��Top=�
������ 