   M S B A M L   `   `   `  ???? E  AProject 04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Project_04
Project_04       Project_04.DeathPeoplePage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Project_04       N? Title$  MainPage??.???  ? ColumnDefinitions ?? ?? ?? ?? ??  ? RowDefinitions ?? $??3* ??? $	??19* ?.+??? -    ??Name$ GroupingByGenderCB??$??2??$??0??$??	10,2,10,2q??? -   $ GroupingByAgeCB??$??3??$??0??$??	10,2,10,2q??? -   $ GroupingByCauseOfDeathCB??$??4??$??0??$??	10,2,10,2q??? -    ??Name$ Reset??$??Сбросить??$??0??$??0??$??	10,2,10,2q?&   System.Windows.Controls.DataGrid  -     Name$ DGridDemography??$??1??$??0??$??5??$??2q?$??Center=?   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Имя??	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 ?? *Name+  $ Фамилия??$		 100 
 ?? *	Surname+  $ Отчество??$		 100 
 ?? *
Patronymic+  $ Пол??$	 70 
 ?? *GenderType.Gender+  $ Дата рождения??$	 95 
 ?? *
Birthday+  $! Место рождения??$		 150 
 ?? *CountryInfo.PlaceOfBirth+  $ Дата смерти??$		 100 
 ?? *
Deathday+  $ Место смерти??$		 150 
 ?? *CountryInfo1.PlaceOfBirth+  $! Причина смерти??$		 150 
 ?? *CauseOfDeath.CauseOfDeath1+