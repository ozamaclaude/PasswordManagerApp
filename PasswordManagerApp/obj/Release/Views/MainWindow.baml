   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   PasswordManagerApp)   #PasswordManagerApp.Views.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Y UPrism.Unity.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�$	��510��$	��700�� � Title �� *Title+.��� 
����  � � ColumnDefinitions �� $��10 ��� $��* ��� $��10 � � RowDefinitions �� $��30 ��� $	��250 ��� $��10 ��� $	��130 ��� $��5 ��� $��40 ��� $��10 �.+�� $��1��$��1��.+�&   System.Windows.Controls.DataGrid  $��	50 0 50 0q�   AutoGenerateColumns .     CanUserAddRows .  ���� *
Accounts+ �� Mode$ TwoWay=�   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .��� 	 �� Property	 � ��
 �� Value$
 20(��� 	 � ��$

 Bold"��� 	 � ��$
 Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ タイトル��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *AccountTitle+  $ ID�� �� *UserId+  $ パスワード�� �� *
Password+� $��1��$��3�� �� $��50 ��� $��* ��� $��10 ��� $��* ��� $��50 � �� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 �.+��� $��1��$��1��$��タイトル��
�������$��18(�$��30 0 0 0q��� $��1��$��3��$��ID��
�������$��18(�$��30 0 0 0q��� $��1��$��5��$��パスワード��
�������$��18(�$��30 0 0 0q��� $��3��$��1��
����ح�
����  �$��18(�$��30 0 0 0q����� *AccountTitle+�� $��3��$��3��
����ح�
����  �$��18(�$��30 0 0 0q����� *	AccountId+�� $��3��$��5��
����ح�
����  �$��18(�$��30 0 0 0q����� *AccountPassword+� $��1��$��5�� �� $	��150 ��� $��50 ��� $	��150 ��� $	��150 ��� $	��150 �.+��� $��2��$��追加��
�������
����  �$��15(�$��10 0 0 0q�$	��120������ *
AddCommand+�� $��3��$��登録��
�������
���  ��$��15(�$��0 0 0 0q�$	��120������ *RegisterCommand+�� $��4��$��snapshot��
�������
��� � �$��15(�$��0 0 0 0q�$	��120������ *SnapshotCommand+