   M S B A M L   `   `   `  ????E  AProject 04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Project_04
Project_04  5      "    Project_04.NewbornPeoplePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Project_04     5      -   5          N? Title$  MainPage??5	      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $??3* ?6   ?? 5      $	??19* ?6   .+?5   
   ?? -   5         ??Name$ Delete??5      $??Удалить??6!   $??4??63   $??	10,2,10,2q?6C   6V   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridDemography??5      $??1??6,   $??1??69   $??0??6J   $??5??6Z   $??2q?6n   $??Center=?6y      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя??6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 90 6K   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   ?? *Name+6K     5      $ Фамилия??6%   $		 100 6R   
 66   ?? *	Surname+6R     5      $ Отчество??6%   $		 100 6V   
 67   ?? *
Patronymic+6V     5       $ Пол??6%   $	 60 6X   
 62   ?? *GenderType.Gender+6X     5!      $ Дата рождения??6%   $	 95 6]   
 6<   ?? *BirthdayDate+6]     5"      $! Место рождения??6%   $		 155 6j   
 6=   ?? *CountryInfo.PlaceOfBirth+6j     5#      $* $Информация о матери??6%   $		 200 6a   
 6B   ?? *
MotherInfo+6a     5$      $( "Информация об отце??6%   $		 200 6`   
 6A   ?? *
FatherInfo+6`   5&      5(      5)      