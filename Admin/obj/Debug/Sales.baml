   M S B A M L   `   `   `  ����@  <Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:farmersMarketfarmersMarket  5   	       farmersMarket.Sales   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:farmersMarket     5   	     � Title$  Sales��5   	   $	��450��6   $	��800��6$   .��5	      � ��5
   
   �� 5       �� ImageSource$w q/abstract-soft-pink-background-modern-and-clean-banner-landing-page-concept-with-pastel-color-free-vector (1).jpg��6   .+�5   
   �� -   5         ��Name$ 	orderpage��5      $��
Sales Page��6#   $
��Left=�68   $��
262,26,0,0q�6S   $	��Top=�6g   $��36(�6   $��BroadwayEngraved BT)�6�   ���	#FFFF174C6�   �� 5   
   -   5         ��Name$
 Name��5      $
��Left=�6    $��168,109,0,0q�6;    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $	��120��6|   $��16(�6�    J� RenderTransformOrigin$ 1.869,0.696&�6�   �� 5   
   -   5        $ label1��5      $��Product Name��6    $
��Left=�67   $��
38,105,0,0q�6R   $	��Top=�6f   $ 0.471,-0.626&�6~   $��16(�6�   ���	#FFE817FF$
��Bold"�6�   �� 5   
   -   5        $ amountTextBox��5      $
��Left=�6)   $��168,180,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   $��16(�6�   $ 1.869,0.696&�6�   �� 5   
   -   5        $ label2��5      $��
Amount(KG)��6    $
��Left=�65   $��
38,176,0,0q�6P   $	��Top=�6d   $ 0.471,-0.626&�6|   $��16(�6�   $
��Bold"�6�   ���	#FFE817FF6�   �� 5   
   -   5        $ salesTextBox��5      $
��Left=�6(   $��171,315,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��120��6�   $��16(�6�   $ 1.869,0.696&�6�   �� 5   
   -   5        $ label3��5      $��Total Amount��6    $
��Left=�67   $��
37,311,0,0q�6R   $	��Top=�6f   $ 0.471,-0.626&�6~   $��16(�6�   $
��Bold"�6�   ���	#FFE817FF6�   �� 5   
   -   5         ��Name$ showme��5      $��Show Me Amount��6!   $
��Left=�6:   $��
48,252,0,0q�6U   $	��Top=�6i   ���	#FFF150EB���	#FFF9F6F6$��Haan Somang B)�6�   $��3,3,3,3q�6�   ���	#FFA230F56�   �� 5   
   -	   5        $ clear��5      $��Clear��6    $
��Left=�60   $��213,252,0,0q�6K   $	��Top=�6`   ���	#FFF150EB���	#FFF9F6F6$��Haan Somang B)�6�   ���	#FFA230F5$��3,3,3,3q�6�   6�   �� 5   
   -
   5        $ proceed��5      $��Please Proceed��6"   $
��Left=�6;   $��
90,376,0,0q�6V   $	��Top=�6j   ���	#FFF150EB���	#FFF9F6F6$��Haan Somang B)�6�   $��3,3,3,3q�6�   ���	#FFA230F56�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProductList��5      $��320,110,10,150q�6(      AutoGenerateColumns . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Product Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ProductName+6[     5      $
 ID��6%   $	 110 6O    61   �� *	ProductID+6O     5      $
 Amount (KG)��6%   $	 110 6W    6:   �� *
AmountKG+6W     5      $
 Price Per KG��6%   $	 110 6Z    6;   �� *
PricePerKG+6Z   5      5      5!      