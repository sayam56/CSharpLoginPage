   M S B A M L   `   `   `  ����  BookStoreGUI    BookStoreGUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  XY's BookStore��5   	   $	��484��6    $	��550��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ 
LayoutRoot��5
       �� Orientation$ Vertical=�5      $
��Left=�6   $
��auto��68   $
��auto��6F    � DataContext 5
   )   �� .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� $��Categories:��6   $��18,0,0,0q�6.   �� 5      -   5         ��Name$ categoriesComboBox��5   3   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5       �� DisplayMemberPath$
 Name��5      $��23��6    $��12q�6,   $	��200��68   ��5      �� ��5      �� 5      .R�5      $� 5      5      �� 5      -   5         ��Name$ loginButton��5   5   $��Login��6   $��25��6)   $��75��5      $��28,2,0,0q�6   6$   �� 5      -   5        $ 
exitButton��5   4   $
��Exit��6   $��25��6(   $��75��5      $��20,2,0,0q�6   6$   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ProductsDataGrid��5      	   AutoGenerateColumns	 .  $	��165��5   3   
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�5      $	��490��5      $
��Left=�6   $��
20,0,20,10q�6*      SelectionMode$ Single=�5       ��5      �� *
drCat_Book+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      -   5        titleColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Title��5$         Width5  /System.Windows.Controls.DataGridLengthConverter$	 50* 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5#      �� *Title+5$        5%      -   5        authorColumn��$ Author��5'      $	 18* 6    5&      �� *Author+5'        5(      -	   5        priceColumn��$ Price��5*      $	 12* 6      CanUserSort .   5)      �� *Price+5*        5+      -
   5        
yearColumn��$
 Year��5-      $ 8* 6    5,      �� *Year+5-      5/      �� 50      $ Vertical=�6   .+�51      �� -   5         ��Name$ orderListView��51      $	��150��62   $	��490��6B    �� SelectionMode$ Single=�52      ��6   ��  �� View 53      �� 54      .P�55      ��  �� Width$ 80��6-   $
��ISBN��68    �� DisplayMemberBinding 56      �� *BookID+�� 57      $	 285��6-   $��Title��69    58      �� *	BookTitle+�� 59      $ 60��6-   $��Quantity��68    5:      �� *
Quantity+�� 5;      $ 60��6-   $��Subtotal��68    5<      �� *
SubTotal+5=      5?      5@      �� 5A      $ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�5B      �� -   5        $ 	addButton��5B      $��25��6,   $	��100��6;   $��Add Book��5C      6   �� 5D      -   5        $ removeButton��5D      $��25��6/   $��80��6>   $��Remove Book��5E      $��5,0,0,0q�68   �� 5F      -   5        $ checkoutOrderButton��5F      $��25��66   $��80��6E   $��Proceed to Checkout��5G      $	��121��6B   $��	180,0,0,0q�6N   5H      5I      �� 5J   
   $��Bottom=�6   $��Stretch=�6/   .@�5K      �� -   5         ��Name$ statusTextBlock��5K      �� 62   $1�+Please login before proceeding to checkout.��66   6l   5L      5M      5N      