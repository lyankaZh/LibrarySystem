   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	   '    !Library.MainWindows.ReadersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  ReadersWindow��5   	   $��550.568��6   $��785.796��60    � 	Resources 5	         Edit �� Text 
 Delete��%R   &	        &	      �� 5
   
   $
 Edit��6'   �� 5   
   $ Delete��6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6]     5   
   -   5        # [ 5      6a   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��923* �6   �� 5      $��3* �6   .+�5   
   c� -   5         c�Name$ toolBar��5      $
��Left=�6#   $	��Top=�6>   $	��926��6V   $��50��6b   $��2��6n   .@�5      �� -   5         ��Name$ addReaderButton��5      $��
Add Reader��6.   $��37��6C   $	��Top=�6O   $��75��6g   6r   �� 5      -   5        $ editReaderButton��5      #��[  6/   $
��Edit��6P   $��37��6_   $	��Top=�6k   $��58��6�   �� 5      -   5        $ deleteReaderButton��5      #��[ 61   $��Delete��6T   $��37��6e   $	��Top=�6q   $��62��6�   �� 5      -   5         ��Name$ label��5      $��Search criteria:��6#   $��37��6>   $	��Top=�6J   $��0,5,0,-5q�6b   �� 5      -   5        	 ��Name$	 searchCriteriaComboBox��5      $��37��67   $��0q�6C   $	��Top=�6N   $	��120��6f   
 �� Text$#
 Критерій пошуку��6r   ��6�   �� *	criterias+�� 5      -	   5         ��Name$ searchTextTextBox��5      $��37��61   $��0q�6=    �� TextWrapping$
 Wrap=�6H   $	��Top=�6\   $	��120��6t   $��Enter text here...��6�   6�   �� 5      -
   5        $ searchButton��5      $��Search��6+   $��37��6<   $	��Top=�6H   $��59��6`   6k   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ readersTable��5      $��
16,55,29,0q�6)   $	��Top=�6=   $	��294��6U      AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .  ��6~   �� *	Readers+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
ReaderId+  5"      $ 
First Name��6%    69   �� *	FirstName+  5#      $ Middle name��6%    6:   �� *
MiddleName+  5$      $ 	Last Name��6%    68   �� *
LastName+  5%      $ Address��6%    66   �� *	Address+  5&      $ Phone number��6%    6;   �� *PhoneNumber+  5'      $ Registration date��6%    6@   �� *RegistrationDate+ �� StringFormat$ {0:dd.MM.yy}��5)      5+      5,      