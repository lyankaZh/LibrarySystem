   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	   +    %Library.AddWindows.AddNewReaderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  Add new reader��5   	   $��325.881��6    $��296.455��61    � 
ResizeMode$ CanMinimize=�6A   .��5	      � .+�5
   
   �� -   5         ��Name$ 	nameLabel��5
      $��
First name��6#   $
��Left=�68   $��	28,66,0,0q�6S   $	��Top=�6f   $��89��6~   �� 5   
   -   5        $ surnameLabel��5      $��	Last name��6&   $
��Left=�6:   $��	28,40,0,0q�6U   $	��Top=�6h    J� RenderTransformOrigin$ -0.627,-0.572&�6�   $��74��6�   �� 5   
   -   5        $ 
phoneLabel��5      $��Phone number��6$   $
��Left=�6;   $��
28,128,0,0q�6V   $	��Top=�6j   $	��108��6�   �� 5   
   -   5        $ label��5      $��Address��6   $
��Left=�61   $��
28,159,0,0q�6L   $	��Top=�6`   $	��108��6x   �� 5   
   -   5        $ middleNameLabel��5      $��Middle name��6)   $
��Left=�6?   $��	28,97,0,0q�6Z   $	��Top=�6m   $��89��6�   �� 5   
   -   5         ��Name$ lastNameTextBox��5      $
��Left=�6+   $��20��6F   $��
138,46,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��105��6�   �� 5   
   -   5        $ firstNameTextBox��5      $
��Left=�6,   $��20��6G   $��
138,72,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��105��6�   �� 5   
   -   5        $ middleNameTextBox��5      $
��Left=�6-   $��20��6H   $��138,103,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��105��6�   �� 5   
   -	   5        $ phoneNumberTextBox��5      $
��Left=�6.   $��20��6I   $��138,134,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��105��6�   �� 5   
   -
   5        $ addressTextBox��5      $
��Left=�6*   $��20��6E   $��138,165,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��105��6�   �� 5   
   -   5         ��Name$ 
saveButton��5      $
��Save��6%   $
��Left=�64   $��
59,241,0,0q�6O   $	��Top=�6c   $��58��6{   $��22��6�   6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $
��Left=�68   $��152,241,0,0q�6S   $	��Top=�6h   $��64��6�   $��22��6�   6�   �� 5   
   -   5        $ 	dateLabel��5      $��Registration Date��6#   $
��Left=�6?   $��
28,185,0,0q�6Z   $	��Top=�6n   $	��108��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��138,190,0,0q�6D   $	��Top=�6Y   $	��105��6q   5      5      