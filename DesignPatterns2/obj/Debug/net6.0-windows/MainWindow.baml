   M S B A M L   `   `   `  ����J  FDesignPatterns2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DesignPatterns2DesignPatterns2  5   	        DesignPatterns2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DesignPatterns2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   � -   5         �Name$ grd_NewGame��5
      .+�5      �� $
��Left=�6   $��
128,34,0,0q�63   $
��Wrap=�6G   $��Staring Contest��6[   $	��Top=�6r   �� 5      $
��Name��6   $
��Left=�6#   $��	57,66,0,0q�6>   $	��Top=�6Q   �� 5      $��Uniform Color��6   $
��Left=�6,   $��	57,97,0,0q�6G   $	��Top=�6Z   �� 5      $��	Gem Stone��6   $
��Left=�6(   $��
57,128,0,0q�6C   $	��Top=�6W   �� 5      $��Starting Item 1��6   $
��Left=�6.   $��
57,159,0,0q�6I   $	��Top=�6]   �� 5      $��Starting Item 2��6   $
��Left=�6.   $��
57,190,0,0q�6I   $	��Top=�6]   �� 5      -   5         ��Name$ dd_UniformSelector��5      $
��Left=�63   $��165,101,0,0q�6N   $	��Top=�6c   $	��120��6{   �� 5      -   5        $ dd_GemSelector��5      $
��Left=�6/   $��165,132,0,0q�6J   $	��Top=�6_   $	��120��6w   �� 5      -   5        $ dd_Item1Selector��5      $
��Left=�61   $��165,163,0,0q�6L   $	��Top=�6a   $	��120��6y   �� 5      -   5        $ dd_Item2Selector��5      $
��Left=�61   $��165,194,0,0q�6L   $	��Top=�6a   $	��120��6y   �� 5      -   5         ��Name$ tb_NameInput��5      $
��Left=�6,   $��
165,74,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��120��6�   �� 5      -   5         ��Name$ 	btn_Start��5      $��Start��6(   $
��Left=�68   $��
57,283,0,0q�6S   $	��Top=�6g   $	��228��6   6�   �� 5      -   5         ��Name$ tb_ErrorOutput��5      $
��Left=�60   $��
439,74,0,0q�6K   $
��Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��229��6�   $	��296��6�   5      � 5   
   -	   5        $ grd_Game��5      .+�5      �� -
   5        $ tb_PlayerOutput��5      $
��Left=�61   $��	63,45,0,0q�6L   $
��Wrap=�6_   $�� ��6s   $	��Top=�6{   $��45��6�   $	��505��6�   �� 5      -   5        $ tb_CompetitorOutput��5      $
��Left=�65   $��	63,95,0,0q�6P   $
��Wrap=�6c   $�� ��6w   $	��Top=�6   $��45��6�   $	��505��6�   �� 5      -   5        $ btn_NextTurn��5      $��	Next Turn��6+   $
��Left=�6?   $��221,378,0,0q�6Z   $	��Top=�6o   $	��347��6�   6�   �� 5      -   5        $ tb_Inventory��5      $
��Left=�6.   $��
573,68,0,0q�6I   $
��Wrap=�6]   $��	Inventory��6q   $	��Top=�6�   $	��217��6�   $	��305��6�   �� 5      -   5        $ btn_UseItem��5      $��Use First item��6*   $
��Left=�6C   $��598,378,0,0q�6^   $	��Top=�6s   $	��124��6�   6�   �� 5       -   5        $ btn_SeeResult��5       $��See results��6,   $
��Left=�6B   $��221,378,0,0q�6]   $	��Top=�6r   $	��347��6�   6�   5#      � 5$   
   -   5        $ grd_GameOver��5$      .+�5%      �� $��Center=�6   $��	0,139,0,0q�65   $
��Wrap=�6H   $��
Game Over!��6\   $	��Top=�6n   �� 5&      -   5        $ tb_ResultOutput��5&      $��Center=�61   $��	0,160,0,0q�6N   $
��Wrap=�6a   $�� ��6u   $	��Top=�6}   5(      5)      5*      