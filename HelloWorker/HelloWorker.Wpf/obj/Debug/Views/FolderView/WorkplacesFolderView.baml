   M S B A M L   `   `   `  ????F  BHelloMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:HelloWorker.Wpf.Views.FolderView HelloWorker.Wpf.Views.FolderView  5      ;    5HelloWorker.Wpf.Views.FolderView.WorkplacesFolderView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:HelloWorker.Wpf.Views.FolderView     5      .??5      ?    folderViewBackground#??[  6     ? RowDefinitions  5      ?? 5      $??45 ?6   ?? 5      .+?5      ?? $??0??6     folderViewHeaderBackground#??[ 6   ._?5      ?? #??[  5      $??30??5      $??30??5      $??0 0 5 0q?5      $??Right=?5      $??Center=?5        addWorkplaceButtonTip ? ToolTip# [ 5      ??5      ?? *AddWorkplaceCommand+.??5      ?? $??20??6   $??20??6     addBlackImg#??[ 6#   5      5      ?? 5!      $??1??5#      $??Center=?5$      $??Disabled=?5%      ??5"      ?? *
Workplaces+??5'      ?? 5(      .R?5)      ?  ? Orientation$ 
Horizontal=?6   5*      ??5-      ?? 5.      .R?5/      ? .+?50      ?  K? ZIndex$ 5??6   $??5q?6    ? ColumnDefinitions 51   	   ?? 52   
   ?? 53   
   $??25 ?6   .+?55   	   ?? $??1??6   .+?56   
   ?? ??6   ?? *OpenEditWorkplacePopUpCommand+.??57      ??   editImg#??[ 6     editWorkplaceButtonTip# [ 63   58      ?? 59   
   ??6   ?? *DeleteWorkplaceCommand+.??5:      ??   	removeImg#??[ 6     removeWorkplaceButtonTip# [ 65   5;       ? 	Resources 5<   
    ?? 
TargetType  
buttonBase ?? BasedOn ?? Property	 ?? Value "	 folderViewDmlButtonsBackground??%?   '??       7  7 	 ?? 5=      " ??6   8   .?5>      ??  ? ??$	 25??6$   ?? 5?       ? ??$	 25??6%   ?? 5@       ? ??$	 0 0 0 5q?6%   ?? 5A       ? ??8	  6)   5B      5C      5D   
   5E   	   ? 5F      $	??180??6     5G   	   ?? 5H   
   $	??150 ?6   ?? 5I   
   $
??auto ?6   .+?5L   	   ?? $	??100??5M   	   $	??100??5N   	    
 	folderImg#??[
 5O   	   $??0??5P   	   ?? 5R   	   $??1??6   .+?5S   
   ?? ??6   ?? *WorkplaceName+?? 5T   
   $??0 5 0 0q?6   ??6%   ?? *WorkplaceAddress+ 5V   
     folderViewTextBlock??%?   '??       7  ?? 5W      " ??6   8   .?5X      ??  ? ??$	 Center=?62   ?? 5Y       ? ??$	 50??6(   ?? 5Z       ? ??$	 WordEllipsis=?6+   ?? 5[       ? ??$
	 Wrap=?6+   5\      5]      5^   
   5_   	   
 J? InputBindings
 5`      d? 5a   	    d? MouseAction$ LeftDoubleClicke?5b   	    ?? Command 5c   	   ?? *OpenWorkplaceContentCommand+ ?? CommandParameter 5d   	   ?? *	Workplace+5f      5g      5i      5j       5l        textBlockBase??%`   '??       7  &	 "     7  ?? 5m      " ??6
   8   6   ?? 5n      " ??6&   8   6=   5o      5p      