   M S B A M L   `   `   `  ????F  BHelloMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HelloWorker.Wpf.ComponentsHelloWorker.Wpf.Components  5      &     HelloWorker.Wpf.Components.PopUp   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:HelloWorker.Wpf.Components     5      .??5
      ? y?6   ?? *
HasContent+    BooleanToVisibilityConverter  ?? 	Converter#  [  ??5      ?? 5       ?? Color$ 	LightGray??6    ?? Opacity$	 0.4Q?6'    ? ColumnDefinitions 5      ?? 5      ?? 5      $
??auto ?6   ?? 5       ? RowDefinitions 5      ?? 5      ?? 5      $
??auto ?6   ?? 5      .+?5      ?? $??1??5      $??1??5       ?? CornerRadius$ 3??5        popUpBackground#??[ 5       J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 5Q?6      
BlurRadius$ 25Q?6'   	   Color$	 	SlateGray??67   ._?5"      ?  5#      ?? 5$      $??45 ?6   ?? 5%      $
??auto ?6   ?? 5&      $
??auto ?6    5(      ?? 5)      $??5 ?6   ?? 5*      $
??auto ?6   ?? 5+      $??5 ?6   .+?5.      ??   popUpHeaderBackground#??[ 5/      $ 3 3 0 0??50      $??0??51      $??3??52      ?? 54      
 K? ZIndex$
 10??55      $??1??56      $??0??57      $??32??58      $??35??59      $??Right=?5:      $	??2 2q?5;       ? Cursor$
 Hand??5<      $??X??5=      $??18(?5>      #??[ 5?      ??5@      ?? *ClosePopUpCommand+??5B      ?? 5C       ?? 
TargetType" ??6   .R?5D   	   ?? $ 0 3 0 0??5E   	   #??z??5F   	   ._?5H   
   ?? #??z??5I   
   #??z??5J   
   #??z??5K   
   5L   
   5W   	   5Y      ?? 5[        popUpLineColor#??[ 5\      $??2??5]      $??1??5^      $??1??5_      ?? 5a      $??2??5c      $??1??5d      $	??0 5q?5e      ??5b      ?? *CurrentViewModel+5e      5f      5g      5h      5i      