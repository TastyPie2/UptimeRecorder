using System;
using System.Collections.Generic;
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
using UptimeRecorder.Backend;

namespace UptimeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FillDataGrid(DateTime.Now.DayOfYear / 7);
        }
        
        private void FillDataGrid(int weekNumber)
        {
            WeekTextBox.Content = WeekTextBox.Content.ToString().Split(" ").First() + " " + weekNumber.ToString();

            var runtime = RuntimeTasks.Instance;

            var sessions = runtime.GetSessions().Select(s => s.Get()).Where(i => i.StartDateTime.DayOfYear / 7 == weekNumber || i.StopDateTime.Value.DayOfYear  / 7 == weekNumber).ToList();
            UptimeDataGrid.ItemsSource = sessions;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
