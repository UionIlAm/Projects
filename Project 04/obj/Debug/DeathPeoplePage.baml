   M S B A M L   `   `   `  ????E  AProject 04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Project_04
Project_04  5           Project_04.DeathPeoplePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Project_04     5      -   5        .??5	      ?   ? ColumnDefinitions  5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $??3* ?6   ?? 5      $	??19* ?6   .+?5   
   ?? -   5         ??Name$ Delete??5      $??Удалить??6!   $??1??63   $??	10,2,10,2q?6C   6V   ?? 5   
   -   5         ??Name$ GroupingByGenderCB??5      $??2??6/   $??0??6?   $??	10,2,10,2q?6L   6_   ?? 5   
   -   5        $ GroupingByAgeCB??5      $??3??6,   $??0??6<   $??	10,2,10,2q?6I   6\   ?? 5   
   -   5        $ GroupingByCauseOfDeathCB??5      $??4??65   $??0??6E   $??	10,2,10,2q?6R   6e   ?? 5   
   -   5        $ Reset??5      $??Сбросить??6    $??0??63   $??0??6C   $??	10,2,10,2q?6P   6c   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridDemography??5      $??1??6,   $??0??69   $??5??6I   $??2q?6]   $??Center=?6h      AutoGenerateColumns .     
IsReadOnly .    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя??6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6K   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   ?? *Name+6K     5"      $ Фамилия??6%   $		 100 6R   
 66   ?? *	Surname+6R     5#      $ Отчество??6%   $		 100 6V   
 67   ?? *
Patronymic+6V     5$      $ Пол??6%   $	 70 6X   
 62   ?? *GenderType.Gender+6X     5%      $ Дата рождения??6%   $	 95 6Y   
 6<   ?? *
Birthday+6Y     5&      $! Место рождения??6%   $		 150 6j   
 6=   ?? *CountryInfo.PlaceOfBirth+6j     5'      $ Дата смерти??6%   $		 100 6W   
 6:   ?? *
Deathday+6W     5(      $ Место смерти??6%   $	 90 6i   
 6;   ?? *CountryInfo1.PlaceOfBirth+6i     5)      $! Причина смерти??6%   $		 200 6l   
 6=   ?? *CauseOfDeath.CauseOfDeath1+6l   5+      5-      5.      