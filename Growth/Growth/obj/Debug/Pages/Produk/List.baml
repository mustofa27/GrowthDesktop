   M S B A M L   `   `   `  ����A  =Growth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Growth.Pages.ProdukGrowth.Pages.Produk  5          Growth.Pages.Produk.List   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Growth.Pages.Produk     5      Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        N� Title$
  List��5
      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � ���#EEEEEE$��40��6(   $��0 0 0 0q�64   $	��Top=�6E   .+�5      �� $ 
Horizontal=�6   $��Center=�66   $��10 0 0 0q�6Q   .+�5      "  FontAwesome.WPF.ImageAwesome     Icon$
 User=�6&      
Foreground �#3A3A3A$��14��6G   $��14��6S   �� 5      $��Segoe UI)�6    $��14(�66   $��20 0 0 0q�6D   Produk List6c   5      5      � 5      $��Stretch=�6   $��Stretch=�61   $��20q�6M   .+�5      �� $ Vertical=�6   .+�5      �� -   5        $
��Left=�5      ���#2D89EF
�������$��	10 5 10 5q�6`   .��6�   Tambah Produk6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
listProduk��5      $��0 15 0 0q�63   $��15(�6E   
���   �   AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��61   	   MaxWidth$	 0Q�6=   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6J   �� *id+  5      $ Kode Produk��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 366 6F   
 6R   �� *	kd_produk+  5      $ Nama Produk��61   $	 365 6F   
 6R   �� *	nm_produk+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��65   $	 365 6E      CellTemplate 5   "   �� 5   &   .R�5    *   �� $ 
Horizontal=�65   $��Center=�6N   .+�5!   .     -   5        $
 Edit=�5!   >   $��12��6J   $��12��6V   $��0 0 30 0q�6a   
 �   �5#   W     5$   .   -   5        $ Trash=�5$   >   $��12��6K   $��12��6W   $��0 0 0 0q�6b   
 �   �5&   W   5'   +   5(   '   5*      5,      5-      5.      5/      50      51      