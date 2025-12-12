# How to use custom control with calcengine 

This example demonstrates how to use the custom control with CalcEngine

You can use any of Tools to in our [CalcEngine](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Calculate.CalcEngine.html). But it should be derived from [ICalcData](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Calculate.ICalcData.html).

``` csharp
this.grid.ItemsSource = dt.DefaultView; 
engine = new CalcEngine(this.grid); 
 
public class CustomGrid : DataGrid,ICalcData 
{ 
    public CustomGrid() 
    { } 
 
    public event ValueChangedEventHandler ValueChanged; 
 
    public object GetValueRowCol(int row, int col) 
    { 
        if (row < 0 || col < 0) 
            return "Invalid cell"; 
        string s = (this.Items[row-1] as DataRowView).Row.ItemArray[col-1].ToString(); 
        return s; 
    } 
 
    public void SetValueRowCol(object value, int row, int col) 
    { 
        //To set the value to specific cell.    
    } 
 
    public void WireParentObject() 
    { 
         //To trigger any of event for parent. This method is called when calcEngine assigned the parent object as CustomDataGrid. 
    } 
}
```