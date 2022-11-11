using System;
using System.Threading;
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
            var cts = new CancellationTokenSource();
            cts.Token.Register(() => MessageBox.Show("Stop calculate factorial", 
                "STOP TASK", MessageBoxButton.OK, MessageBoxImage.Stop));
            
            ButtonStartTask1.IsEnabled = false;
            ButtonStopTask1.IsEnabled = true;
            ButtonStopTask1.Click += (_, _) => cts.Cancel();
            
            Task1Output.Text = "Start calculate factorial 10";
            var progress = new Progress<int>();
            progress.ProgressChanged += (_, i) => ProgressTask1.Value = i;
            ProgressTask1.Minimum = 1;
            ProgressTask1.Maximum = 10;
            
            Task1Output.Text = $"10! = {(await Calculator.FactorialAsync(10, progress, cts.Token)).ToString()}";
            ButtonStartTask1.IsEnabled = true;
            ButtonStopTask1.IsEnabled = false;
        }

        private async void ButtonStartTask2_OnClick(object sender, RoutedEventArgs e)
        {
            await TaskSleep(Task2Output);
        }

        private async Task TaskSleep(TextBlock output)
        {
            output.Text = "Start";
            await Task.Delay(10000);
            output.Text = "Completed";
        }
    }
}