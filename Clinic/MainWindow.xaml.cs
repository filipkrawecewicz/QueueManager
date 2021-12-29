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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QueueManager queueManager = new QueueManager();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainViewBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewController.Template =  FindResource("MainView") as ControlTemplate;
        }

        private void AddAppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewController.Template = FindResource("AddAppointmentView") as ControlTemplate;
        }

        private void PatientViewBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewController.Template = FindResource("PatientView") as ControlTemplate;
        }

        private void AddAppointmentBtn_Add(object sender, RoutedEventArgs e)
        {
            TextBlock nameBox = (TextBlock) ViewController.Template.FindName("AddForm_Name", ViewController);
            TextBlock testName = (TextBlock)ViewController.Template.FindName("AddForm_TestName", ViewController);
            DatePicker appointmentDate = (DatePicker)ViewController.Template.FindName("AddForm_Date", ViewController);

            if (nameBox.Text.Length == 0 || testName.Text.Length == 0 || appointmentDate.SelectedDate == null)
            {
                // animate error message. Source: https://stackoverflow.com/a/45712293
                TextBlock errMsg = (TextBlock) ViewController.Template.FindName("AddForm_ErrorMsg", ViewController);

                Storyboard? sb = Resources["sbHideAnimation"] as Storyboard;
                sb!.Begin(errMsg);
            }
            else
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentDate = DateOnly.FromDateTime(appointmentDate.SelectedDate!.Value.Date);
                appointment.TestName = testName.Text;
                appointment.PatientName = nameBox.Text;

                queueManager.Add(appointment);
            }
        }
    }
}
