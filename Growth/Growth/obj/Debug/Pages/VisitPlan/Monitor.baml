   M S B A M L   `   `   `  ����A  =Growth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Growth.Pages.VisitPlanGrowth.Pages.VisitPlan  5      $    Growth.Pages.VisitPlan.Monitor   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Growth.Pages.VisitPlan     5      Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        N� Title$  Monitor��5
      .��5      � $��Stretch=�6   $��Stretch=�5      .+�5   
   � $��Stretch=�6   ���#EEEEEE$	��Top=�6B   $��40��6Z   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��20 0 0 0q�6M   .+�5      "  FontAwesome.WPF.ImageAwesome     Icon$ LocationArrow=�6"      
Foreground �#3A3A3A$��14��6L   $��14��6X   �� 5       �� Padding$ 5 0 0 0q�6   $��Segoe UI)�6.   $��14(�6D   
Visit Plan6^   5      5      �� 5   
   $��20 60 20 20q�6   $��Stretch=�6,   $��Stretch=�6J   $��Hidden=�6f   .��5      �� $ Vertical=�6   .+�5      � ���#EEEEEE$��40��6,   $��0 0 0 0q�68   $	��Top=�6I   .+�5      �� $ 
Horizontal=�6!   $��Center=�6:   $��10 0 0 0q�6U   .+�5        $ CheckSquareOutline=�6*    �#3A3A3A$��14��6Y   $��14��6e   �� 5      $��Segoe UI)�6$   $��14(�6:   $��20 0 0 0q�6H   Visiting Monitor6l   5      5      � 5      $��Stretch=�6   $��Stretch=�65   $��20q�6Q   .+�5      �� $ Vertical=�6!   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	listVisit��5   #   $��0 15 0 0q�66   $��13(�6H   
���   �   AutoGenerateColumns .     
IsReadOnly .    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!   "   ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Kode Visit��65   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 112 6I   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *id+  5"   "   $	 Sales Force��65   $	
 112 6J    6V   �� *
nm_sales+  5#   "   $	 Nama Outlet��65   $	
 112 6J    6V   �� *	nm_outlet+  5$   "   $	 Alamat Outlet��65   $	
 112 6L    6X   �� *alamat_outlet+  5%   "   $	 Kota Outlet��65   $	
 112 6J    6V   �� *kota+  5&   "   $	 Actual Visit��65   $	
 112 6K    6W   �� *date_visiting+  5'   "   $	 Status Visit��65   $	
 112 6K    6W   �� *status_visit_string+  5(   "   $	 Skip Order Reason��65   $	
 112 6P    6\   �� *skip_order_reason+  5)   "   $	 Unvisited Reason��65   $	
 112 6O    6[   �� *skip_reason+4  .System.Windows.Controls.DataGridTemplateColumn  5*   "   $	 Action��6:   $
 78 6J      CellTemplate 5+   &   �� 5,   *   .R�5-   .   �� $ 
Horizontal=�69   $��Center=�6R   .+�5.   2     -   5        $
 Edit=�5.   B   $��12��6N   $��12��6Z   $��0 0 20 0q�6e   
 �   �50   W     51   2   -   5        $ Trash=�51   B   $��12��6O   $��12��6[   $��0 0 0 0q�6f   
 �   �53   W   54   /   55   +   57   #   59      5:      5;      5<      5=      5>      5?      