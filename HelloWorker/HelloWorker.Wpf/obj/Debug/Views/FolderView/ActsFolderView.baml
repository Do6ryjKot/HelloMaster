   M S B A M L   `   `   `  ????F  BHelloMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:HelloWorker.Wpf.Views.FolderView HelloWorker.Wpf.Views.FolderView  5      5    /HelloWorker.Wpf.Views.FolderView.ActsFolderView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:HelloWorker.Wpf.Views.FolderView     5      .??5      ?    folderViewBackground#??[  6     ? RowDefinitions  5      ?? 5      $??45 ?6   ?? 5      .+?5      ?? $??0??6     folderViewHeaderBackground#??[ 6   ._?5      ?  ? ColumnDefinitions 5      ?? 5      $
??auto ?6   ?? 5      ?? 5      $
??auto ?6   .+?5      ?? $??0??5      $	??5 0q?5        backToWorkplacesButtonTip ? ToolTip# [ 5      ??5      ?? *WorkplacesNavigationCommand+.??5       ??   backImg#??[ 6   $??0 0 2 0q?6/   5!      ?? 5#      #??[  5$      $??1??5%      $??18(?5&      $??Center=?5'      $??WordEllipsis=?5(      ??5)      ?? *WorkplaceName+?? 5+      $??2??5,      $	??5 0q?5-        addActButtonTip# [ 5/      ??5.      ?? *AddActCommand+.??51      ?? $??20??6   $??20??6     addBlackImg#??[ 6$   52       ? 	Resources 54       ?? 
TargetType  
buttonBase ?? BasedOn ?? Property ?? Value??%?   '??       7  7   ?? 55      " ??6   8   .?56      ??  ? ??$ 30??6    ?? 57       ? ??$ 30??6!   ?? 58       ? ??8  6%   ?? 59       ? ??$ Center=?6,   5:      5;      5<      5=      ?? 5?      $??1??6   ??6   ?? *Acts+??5@      ?? 5A      .R?5B      ? $??70??6   .+?5C      ?  K? ZIndex$ 5??6i   y?6   ?? *CanBeEdited+   BooleanToVisibilityConverter	 ?? 	Converter#	 [  5D   	   ?? 5E   
   ?? 5F   
   $??25 ?6   .+?5I   	   ?? $??1??6   .+?5J   
   ??   editActButtonTip# [ 5L   
   ??5K   
   ?? *OpenEditActPopUpCommand+.??5N      ??  	 editImg#??[	 6   5O      ?? 5P   
    
 deleteActButtonTip# [
 5R   
   ??5Q   
   ?? *DeleteActCommand+.??5T      ??   	removeImg#??[ 6   5U       5V   
    " folderViewDmlButtonsBackground??%?   '??       7  7  ?? 5W      " ??6   8   .?5X      ??  ? ??$ 25??6$   ?? 5Y       ? ??$ 25??6%   ?? 5Z       ? ??$ 0 0 0 5q?6%   ?? 5[       ? ??8  6)   5\      5]      5^   
   5_   	   ? 5`       5a   	   ?? 5b   
   $
??auto ?6   ?? 5c   
   $
??1000 ?6   .+?5f   	   ?? $??70??6   $??0??6     fileImg#??[ 6*   ?? 5g   	   $
??Wrap=?5h   	   $??WordEllipsis=?5i   	   $
??5 10q?5j   	   $??14(?5k   	   $??1??5l   	   ??5m   	   ?? *	ActName+5n   	   
 J? InputBindings
 5o      d? 5p   	    d? MouseAction$ LeftDoubleClicke?5q   	    ?? Command 5r   	   ?? *OpenActContentCommand+ ?? CommandParameter 5s   	   ?? *Act+5u      5v      5x      5y       5{        textBlockBase??%`   '??       7  '?? "     7  ?? 5|      " ??6
   8   6   ?? 5}      " ??6
   8   6!   5~      5      