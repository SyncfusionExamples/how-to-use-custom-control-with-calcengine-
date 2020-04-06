using Syncfusion.Calculate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculateWithCustomControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalcEngine engine = null;
        public MainWindow()
        {
            InitializeComponent();
            dt = CreateTable();
            this.grid.ItemsSource = dt.DefaultView;
            engine = new CalcEngine(this.grid);

        }

        #region "Create DataTable"
        string[] name1 = new string[] { "John", "Peter", "Smith", "Jay", "Krish", "Mike" };
        string[] country = new string[] { "UK", "USA", "Pune", "India", "China", "England" };
        string[] city = new string[] { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" };
        string[] scountry = new string[] { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" };
        DataTable dt = new DataTable();
        Random r = new Random();
        int col = 0;
        private DataTable CreateTable()
        {

            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Columns.Add("D");
            dt.Columns.Add("E");
            dt.Columns.Add("F");
            dt.Columns.Add("G");
            dt.Columns.Add("H");
            dt.Columns.Add("I");
            dt.Columns.Add("J");
            dt.Columns.Add("K");

            for (int l = 0; l < 100; l++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = r.Next(100, 2000);
                dr[1] = r.Next(10000, 20000);
                dr[2] = r.Next(1000, 2000);
                dr[3] = r.Next(1000, 2000);
                dr[4] = r.Next(1000, 2000);
                dr[5] = r.Next(1000, 2000);
                dr[6] = r.Next(1000, 2000);
                dr[7] = r.Next(10 + (r.Next(600000, 600100)));
                dr[8] = r.Next(14000, 20000);
                dr[9] = r.Next(r.Next(2000, 4000));
                dr[10] = r.Next(300, 1000);

                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.textBox.Text))
            {
                string value = engine.ParseAndComputeFormula(this.textBox.Text);
                this.result.Content = value;
            }
        }
    }

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
}
