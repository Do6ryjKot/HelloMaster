   M S B A M L   `   `   `  ????F  BHelloMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HelloWorker.Wpf.ViewsHelloWorker.Wpf.Views  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5      4    .HelloWorker.Wpf.Views.PriceListCalculationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:HelloWorker.Wpf.Views     5      Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase     5      .??5      ?   ? RowDefinitions  5      ?? 5      $
??auto ?6   ?? 5      .+?5      ?? .+?5      ? $??30??6
    ? ColumnDefinitions 5      ?? 5      $
??auto ?6   ?? 5      ?? 5      $
??auto ?6   .+?5      ?? $??Center=?6   $??0??6+   $??Объект: ??6;   ?? 5      $??1??5      $??25??5       ?? SelectedValuePath$ Id??5!       ?? DisplayMemberPath$
 Name??5"       ?? SelectedValue 5       ?? *CurrentWorkplaceId+??5#      ?? *
Workplaces+?? 5&      $??2 0 0 0q?6   $??2??6"    ?? Orientation$ 
Horizontal=?62   .+?5'      ??    addWorkplaceButtonTip ? ToolTip# [  5(      ??5)      ?? *AddWorkplaceCommand+.??5*      ??  
 addImg#??[ 6   5+      ?? 5-        editWorkplaceButtonTip# [ 5.      ??5/      ?? *EditWorkplaceCommand+.??50      ??   editImg#??[ 6   51      ?? 53        removeWorkplaceButtonTip# [ 54      ??55      ?? *DeleteWorkplaceCommand+.??56      ??   	removeImg#??[ 6   57       ? 	Resources 59       ?? 
TargetType  dataGridDeleteRowButtin	 ?? BasedOn
 ?? Property ?? Value??%?   '??       7  ?? 5:      " ??6   8	   .?5;   	   ?? 
 ? ??$ 1q?6"   ?? 5<   	   
 ? ??$ 25??6!   ?? 5=   	   
 ? ??$ 25??6"   5>   	   5?      5@      5A      ?? 5D      $	??0 5q?6   $
??Wrap=?6   ?? 5E      $?Адрес: ??6
    ?? 5F      ?6
   ?? *WorkplaceAddress+ ?? Mode$ OneWay=?5G      5H      ? 5K      $??1??6	    5L      ?? 5M      $??* ?6   ?? 5N      $??3 ?6   ?? 5O      $??* ?6     5Q      ?? 5R      $
??auto ?6   ?? 5S      $??30 ?6   ?? 5T      .+?5X      ?? $??0??5Y      $??0??5Z      $
??Left=?5[      $??1q?5\      $ 
Horizontal=?5]      .+?5`      ?? $??Center=?5a        mainFont#??[ 5b        fontSize#??[ 5c      $	??220??5e      ??5d      ?? *PriceListSearchFilter+ ?? UpdateSourceTrigger$ PropertyChanged=?5e      ?? 5h      $
 Name??5k      $	??170??5l      $??5 0 0 0q?5m      ??5i      ?? *
WorkGroups+ ?? SelectedItem 5j      ?? *PriceListWorkGroupFilter+5m      ?? 5p      $
 Name??5s      $	??170??5t      $??5 0 0 0q?5u      ??5q      ?? *WorkCategories+ 5r      ?? *WorkCategoryFilter+5u      5v      ?? 5y      $??0??5z      $??2??5{      $??Right=?5|      $??1q?5}      $ 
Horizontal=?5~      .+?5?      ??  .	 *exportCompanyPricesWorkplaceWorksButtonTip# [	 5?      ??5?      ?? *,*ExportCompanyCostWorkplacePositionsCommand+.??5?      ??  
 	exportImg#??[
 6   5?      ?? 5?       - )exportMasterPricesWorkplaceWorksButtonTip# [ 5?      ??5?      ?? *+)ExportMasterCostWorkplacePositionsCommand+.??5?      ??   exportMasterCostImg#??[ 6   5?      ?? 5?       " refreshWorkplaceWorksButtonTip# [ 5?      ??5?      ?? *" RefreshWorkplacePositionsCommand+.??5?      ??   
refreshImg#??[ 6   5?       5?      ??%?   '??       7  ?? 5?      " ??6   8	   .?5?      ?? 
 ? ??$ 25??6    ?? 5?      
 ? ??$ 1q?6!   ?? 5?      
 ? ??$ 25??6!   5?      5?      5?      ?? 5?        dataGridHeaderBackground#??[ 5?      $??0 5 0 0q?5?       ?? CornerRadius$ 4 4 0 0??5?      $??0??5?      $??1??5?      ._?5?      ?? $??Center=?5?      $??Center=?5?      #??[ 5?      #??[ 5?         dataGridHeaderTextBackground#??[ 5?      $??Прайс-лист??5?      5?      ?? 5?      #??[ 5?      $??0 5 0 0q?5?      $ 4 4 0 0??5?      $??2??5?      $??1??5?      ._?5?      ?? $??Center=?5?      $??Center=?5?      #??[ 5?      #??[ 5?      #??[ 5?      $#??Позиции объекта??5?      5?      &   System.Windows.Controls.DataGrid  5?         SelectionMode$ Single=?5?         AutoGenerateColumns .     
IsReadOnly . $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5?      $??0??5?      $??2??5?      ??5?      ?? *	PriceList+   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Группа работ??5?         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5?        centralizedColumn1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5?         Binding 5?      ?? *WorkGroupName+5?        5?      $
 auto 5?      # [ 5?       5?      ?? *	SortOrder+5?      4  .System.Windows.Controls.DataGridTemplateColumn  5?      $ Вид работ??6   $ * 61      CellTemplate 5?      ?? 5?   	   .R?5?   
   ?? $??Center=?6.   $
??Wrap=?6I   $	??3 1q?6^   ??6   ?? *
WorkName+6^   5?   
   5?        5?      $ Ед. измерения??5?      $
 auto 5?      # [ 5?       5?      ?? *WorkMeasureUnit+5?        5?      $ Стоимость, р.??5?      $
 auto 5?      # [ 5?       5?      ?? *	WorkPrice+5?       J? InputBindings 5?      d? 5?       d? MouseAction$ LeftDoubleClicke?5?       ?? Command 5?      ?? * AddToWorkplacePositionsCommand+ ?? CommandParameter 5?      ?? *
PriceList/+5?      ?? 5?      $??1??6   $??2??6"   $??Stretch=?6/   $??Stretch=?6K     5?         CanUserAddRows .     CanUserDeleteRows .  $ Single=?5?       .  $??2??5?      $??2??5?      ??5?      ?? *WorkplacePositions+ 5?        5     $ 30 6    5     ?? 5  	   .R?5  
   ?? $??X??5  
   #??[ 5  
   ??5  
   ?? *DeletePositionCommand+5  
   5  
   5
       5     $
 auto 5     # [ 5      5     ?? *	SortOrder+5       5         
IsReadOnly  . $ Группа работ??5     $
 auto 5     # [ 5      5     ?? *WorkGroupName+5       5"       . $ Вид работ??60   $ * 6C    5#     ?? 5$  	   .R?5%  
   ?? $??Center=?6.   $
??Wrap=?6I   $	??3 1q?6]   ??6   ?? *
WorkName+6]   5&  
   5(       5*     $ Квадратура??5+     $
 auto 5-     # [ 5.      5,     ?? *
Quadrature+$ TwoWay=?$ 	LostFocus=?5.       50       . $ Стоимость??52     $
 auto 54     # [ 55      53     ?? *Cost+55       57       . $' !Стоимость мастера??59     $
 auto 5;     # [ 5<      5:     ?? *
MasterCost+5<     5?     5@     5A      5C       positionsDataGrid  datagridScrollBar??%t  '??       7  7  '?? d     7  7  '  ?     7  '??     7  ?? 5D     " ??6
   .?5E     ?? 
 ? ??8   6"   ?? 5F     
 ? ??8  6    5G     ?? 5H     " ??6
   .?5I     ?? 
 ? ??8   6"   ?? 5J     
 ? ??8  6    ?? 5K     
 ? ??$ Center=?60   5L     ?? 5M     "  6
   8	   6    ?? 5N     " ??6
   8	   6!   5O     5P     