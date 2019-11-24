using System;
using System.Windows;
using System.Windows.Threading;

namespace ExampleUsbExperimentInterfaceBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly ComponentK8055D _8055D = new ComponentK8055D();

        private DispatcherTimer _timer = new DispatcherTimer();

        public MainWindow()
        {
            this.InitializeComponent();

            this._timer.Tick += this._timer_Tick;
            this._viewModel = (MainViewModel)this.DataContext;
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (this._viewModel.SelectedIntervalSetupItem < 0)
            {
                return;
            }

            this._viewModel.InitSetupEnable = false;
            this._8055D.Open(this._viewModel.SetupSk5, this._viewModel.SetupSk6);
            this._timer.Interval = TimeSpan.FromMilliseconds(this._viewModel.SelectedIntervalSetupItem);
            this._timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            this._viewModel.AnalogInput1 = this._8055D.ReadAnalogInput(1);
            this._viewModel.AnalogInput2 = this._8055D.ReadAnalogInput(2);

            this._viewModel.DigitalInput1 = this._8055D.ReadDigitalInput(1);
            this._viewModel.DigitalInput2 = this._8055D.ReadDigitalInput(2);
            this._viewModel.DigitalInput3 = this._8055D.ReadDigitalInput(3);
            this._viewModel.DigitalInput4 = this._8055D.ReadDigitalInput(4);
            this._viewModel.DigitalInput5 = this._8055D.ReadDigitalInput(5);


            this._8055D.WriteOutputAnalog(1, this._viewModel.AnalogOutput1);
            this._8055D.WriteOutputAnalog(2, this._viewModel.AnalogOutput2);

            this._8055D.WriteOutputDigital(1, this._viewModel.DigitalOutput1);
            this._8055D.WriteOutputDigital(2, this._viewModel.DigitalOutput2);
            this._8055D.WriteOutputDigital(3, this._viewModel.DigitalOutput3);
            this._8055D.WriteOutputDigital(4, this._viewModel.DigitalOutput4);
            this._8055D.WriteOutputDigital(5, this._viewModel.DigitalOutput5);
            this._8055D.WriteOutputDigital(6, this._viewModel.DigitalOutput6);
            this._8055D.WriteOutputDigital(7, this._viewModel.DigitalOutput7);
            this._8055D.WriteOutputDigital(8, this._viewModel.DigitalOutput8);
        }

        private void ButtonDisconnect_Click(object sender, RoutedEventArgs e)
        {
            this._viewModel.InitSetupEnable = true;
            this._timer.Stop();
            this._8055D.Close();
        }
    }
}
