   M S B A M L   `   `   `  ����C  ?pomodoro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:pomodoropomodoro  5   	       pomodoro.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:pomodoro     5   	     � Title$  
MainWindow��5   	   $��403.756��6   $	��800��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ tbc_pomodoro��5
      $
��Left=�6+   $	��324��6F   $��	25,23,0,0q�6S   $	��Top=�6f   $	��742��6~   .@�5      �� -   5         ��Name$ tbi_pomodoro��5      $��Pomodoro��6,   .��5      � -   5         �Name$ grid_pomodoro��5      ���	#FFE5E5E5.+�5      �� -   5         ��Name$ 	btn_start��5      $��Start��60   $
��Left=�6@   $��229,198,0,0q�6[   $	��Top=�6p   $	��134��6�   $��61��6�   $��36(�6�   $
��Bold"�6�   6�   �� 5      -   5        $ 	btn_pause��5      $��Pause��60   $
��Left=�6@   $��374,198,0,0q�6[   $	��Top=�6p   $	��134��6�   $��61��6�   $��36(�6�   $
��Bold"�6�   6�   �� 5      -   5         ��Name$ lbl_time��5      $��00:00��6.   $
��Left=�6>   $��
274,88,0,0q�6Y   $	��Top=�6m   $	��105��6�   $	��188��6�   $��72(�6�   �� 5      -   5        $ 	lbl_titre��5      $��Pomodoro��6/   $
��Left=�6B   $��
271,10,0,0q�6]   $	��Top=�6q   $��36(�6�   $
��Bold"�6�   �� 5      -   5        $ lbl_indication��5      $B��<Vous devez ajouter une nouvelle session dans les paramètres��64   $
��Left=�6z   $��	67,63,0,0q�6�   $	��Top=�6�   $��22(�6�    J� RenderTransformOrigin$ 
-0.2,0.974&�6�   5      5      �� 5      -	   5        $ tbi_parametre��5      $��
Paramètre��6-   .��5      � -
   5        $ grid_parametre��5      ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $	��15* �6+   �� 5      $	��71* �6+   �� 5      $
��650* �6+   .+�5      �� -   5         ��Name$ tbx_tagSession��5      $
��Left=�66   $��23��6Q   $��
28,121,0,0q�6]   	 �� TextWrapping$
	 Wrap=�6q   $	��Top=�6�   $	��120��6�   $ -0.105,-0.38&�6�   $��2��6�   �� 5      -   5        $ lbl_ajoutSession��5      $"��Ajouter une nouvelle session��66   $
��Left=�6]   $��2,46,0,0q�6x   $	��Top=�6�   $
��Bold"�6�   $��2��6�   �� 5      -   5        $ btn_valider��5      $��Ajouter��62   $
��Left=�6D   $��
47,161,0,0q�6_   $	��Top=�6s   $��75��6�   $��2��6�   �� 5      -   5        $ lbl_historiqueSession��5      $��
Historique��6;   $
��Left=�6P   $��
435,46,0,0q�6k   $	��Top=�6   $
��Bold"�6�   $��2��6�   �� 5      -   5        
 ��Name$
 lbx_historiqueSession��5      $��2��6=   $
��Left=�6M   $	��142��6h   $��
397,77,0,0q�6u   $	��Top=�6�   $	��149��6�   �� 5       -   5        $ lbl_session��5       $��Tag de la session :��61   $��2��6O   $
��Left=�6_   $��
24,101,0,0q�6z   $	��Top=�6�   5!      5"      5#      5%      5&      