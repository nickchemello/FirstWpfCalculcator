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

namespace FirstWpfCalculcator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpwindow = new HelpWindow();
            helpwindow.ShowDialog();
        }
         
        private bool ValidInputs(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";

            //
            // set bool value and build out the user feedback message
            //

            if (textbox_speed.Text != "" && !double.TryParse(textbox_speed.Text, out double tempspeed))
            {
                validInputs = false;
                userFeedback += "It appears that the value entered for Speed is not a valid number." + Environment.NewLine;
            }
            if (textbox_distance.Text != "" && !double.TryParse(textbox_distance.Text, out double tempdistance))
            {
                validInputs = false;
                userFeedback += "It appears that the value entered for Distance is not a valid number." + Environment.NewLine;
            }
            if (textbox_time.Text != "" && !double.TryParse(textbox_time.Text, out double temptime))
            {
                validInputs = false;
                userFeedback += "It appears that the value entered for Time is not a valid number." + Environment.NewLine;
            }

            return validInputs;
        }

        private void Button_answer_Click(object sender, RoutedEventArgs e)
        {

            double.TryParse(textbox_speed.Text, out double speed);
            double.TryParse(textbox_distance.Text, out double distance);
            double.TryParse(textbox_time.Text, out double time);

            if (ValidInputs(out string userFeedback))
            {

                if ((bool)radiobutton_speed.IsChecked)
                {
                    textbox_answer.Text = (distance / time).ToString();
                }
                if ((bool)radiobutton_distance.IsChecked)
                {
                    textbox_answer.Text = (speed * time).ToString();
                }
                if ((bool)radiobutton_time.IsChecked)
                {
                    textbox_answer.Text = (distance / speed).ToString();
                }

            }
            else
            {
                MessageBox.Show(userFeedback);
            }
        }

        private void Radiobutton_Calculations_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UpdateCalculations();
            }
        }

        private void UpdateCalculations()
        {
            if ((bool)radiobutton_speed.IsChecked)
            {
                textblock_speed.Visibility = Visibility.Hidden;
                textbox_speed.Visibility = Visibility.Hidden;
                textbox_distance.Visibility = Visibility.Visible;
                textblock_distance.Visibility = Visibility.Visible;
                textbox_time.Visibility = Visibility.Visible;
                textblock_time.Visibility = Visibility.Visible;
            }
            else if ((bool)radiobutton_distance.IsChecked)
            {
                textblock_distance.Visibility = Visibility.Hidden;
                textbox_distance.Visibility = Visibility.Hidden;
                textblock_speed.Visibility = Visibility.Visible;
                textbox_speed.Visibility = Visibility.Visible;
                textbox_time.Visibility = Visibility.Visible;
                textblock_time.Visibility = Visibility.Visible;

            }
            else if ((bool)radiobutton_time.IsChecked)
            {
                textbox_time.Visibility = Visibility.Hidden;
                textblock_time.Visibility = Visibility.Hidden;
                textblock_speed.Visibility = Visibility.Visible;
                textbox_speed.Visibility = Visibility.Visible;
                textbox_distance.Visibility = Visibility.Visible;
                textblock_distance.Visibility = Visibility.Visible;

            }
        }
    }
}
