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
            var weekSumary = new UptimeWeekData();
            
            //Weekdays
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Monday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Monday).ToList()));
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Tuesday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Tuesday).ToList()));
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Wednesday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Wednesday).ToList()));
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Thursday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Thursday).ToList()));
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Friday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Friday).ToList()));
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Saturday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Saturday).ToList()));
            weekSumary.weekDays.Add(new UptimeDayInfo(sessions.Where(i => i.StartDateTime.DayOfWeek == DayOfWeek.Sunday || i.StopDateTime.Value.DayOfWeek == DayOfWeek.Sunday).ToList()));


            UptimeDataGrid.ItemsSource = new List<UptimeWeekData>() { weekSumary };
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
