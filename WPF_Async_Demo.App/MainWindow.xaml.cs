using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Async_Demo.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private async void ButtonStartTask1_OnClick(object sender, RoutedEventArgs e)
        {
            Task1Output.Text = (await Calculator.FactorialAsync(10)).ToString();
        }
        
        private async void ButtonStartTask2_OnClick(object sender, RoutedEventArgs e)
        {
            await TaskSleep(Task2Output);
        }

        private async Task TaskSleep(TextBlock output)
        {
            output.Text = "Start";
            await Task.Delay(3000);
            output.Text = "Completed";
        }
    }
}