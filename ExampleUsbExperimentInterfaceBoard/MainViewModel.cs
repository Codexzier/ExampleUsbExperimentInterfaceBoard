using System.Collections.Generic;
using System.ComponentModel;

namespace ExampleUsbExperimentInterfaceBoard
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICollection<int> _intervalSetupValues;
        private bool _setupSk5;
        private bool _setupSk6;
        private int _selectedIntervalSetupItem;
        private bool _initSetupEnable;
        private bool _digitalInput1;
        private bool _digitalInput2;
        private bool _digitalInput3;
        private bool _digitalInput4;
        private bool _digitalInput5;
        private int _analogInput1;
        private int _analogInput2;
        private bool _digitalOutput1;
        private bool _digitalOutput2;
        private bool _digitalOutput3;
        private bool _digitalOutput4;
        private bool _digitalOutput5;
        private bool _digitalOutput6;
        private bool _digitalOutput7;
        private bool _digitalOutput8;
        private int _analogOutput1;
        private int _analogOutput2;

        public MainViewModel()
        {
            this.IntervalSetupValues = new List<int>();
            this.IntervalSetupValues.Add(10);
            this.IntervalSetupValues.Add(100);
            this.IntervalSetupValues.Add(1000);

            this.InitSetupEnable = true;
        }

        #region setup

        public bool InitSetupEnable
        {
            get => this._initSetupEnable;
            set
            {
                this._initSetupEnable = value;
                this.OnPropertyChanged(nameof(this.InitSetupEnable));
            }
        }

        public bool SetupSk5
        {
            get => this._setupSk5;
            set
            {
                this._setupSk5 = value;
                this.OnPropertyChanged(nameof(this.SetupSk5));
            }
        }

        public bool SetupSk6
        {
            get => this._setupSk6;
            set
            {
                this._setupSk6 = value;
                this.OnPropertyChanged(nameof(this.SetupSk6));
            }
        }
        public ICollection<int> IntervalSetupValues
        {
            get => this._intervalSetupValues;
            set
            {
                this._intervalSetupValues = value;
                this.OnPropertyChanged(nameof(this.IntervalSetupValues));
            }
        }

        public int SelectedIntervalSetupItem
        {
            get =>
                  this._selectedIntervalSetupItem;
            set
            {
                this._selectedIntervalSetupItem = value;
                this.OnPropertyChanged(nameof(this.SelectedIntervalSetupItem));
            }
        }

        #endregion

        #region inputs

        public bool DigitalInput1
        {
            get => this._digitalInput1;
            set
            {
                this._digitalInput1 = value;
                this.OnPropertyChanged(nameof(this.DigitalInput1));
            }
        }

        public bool DigitalInput2
        {
            get => this._digitalInput2;
            set
            {
                this._digitalInput2 = value;
                this.OnPropertyChanged(nameof(this.DigitalInput2));
            }
        }

        public bool DigitalInput3
        {
            get => this._digitalInput3;
            set
            {
                this._digitalInput3 = value;
                this.OnPropertyChanged(nameof(this.DigitalInput3));
            }
        }

        public bool DigitalInput4
        {
            get => this._digitalInput4;
            set
            {
                this._digitalInput4 = value;
                this.OnPropertyChanged(nameof(this.DigitalInput4));
            }
        }

        public bool DigitalInput5
        {
            get => this._digitalInput5;
            set
            {
                this._digitalInput5 = value;
                this.OnPropertyChanged(nameof(this.DigitalInput5));
            }
        }

        public int AnalogInput1
        {
            get => this._analogInput1;
            set
            {
                this._analogInput1 = value;
                this.OnPropertyChanged(nameof(this.AnalogInput1));
            }
        }
        public int AnalogInput2
        {
            get => this._analogInput2;
            set
            {
                this._analogInput2 = value;
                this.OnPropertyChanged(nameof(this.AnalogInput2));
            }
        }

        #endregion

        #region output

        public bool DigitalOutput1
        {
            get => this._digitalOutput1;
            set
            {
                this._digitalOutput1 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput1));
            }
        }

        public bool DigitalOutput2
        {
            get => this._digitalOutput2;
            set
            {
                this._digitalOutput2 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput2));
            }
        }

        public bool DigitalOutput3
        {
            get => this._digitalOutput3;
            set
            {
                this._digitalOutput3 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput3));
            }
        }

        public bool DigitalOutput4
        {
            get => this._digitalOutput4;
            set
            {
                this._digitalOutput4 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput4));
            }
        }

        public bool DigitalOutput5
        {
            get => this._digitalOutput5;
            set
            {
                this._digitalOutput5 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput5));
            }
        }

        public bool DigitalOutput6
        {
            get => this._digitalOutput6;
            set
            {
                this._digitalOutput6 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput6));
            }
        }

        public bool DigitalOutput7
        {
            get => this._digitalOutput7;
            set
            {
                this._digitalOutput7 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput7));
            }
        }

        public bool DigitalOutput8
        {
            get => this._digitalOutput8;
            set
            {
                this._digitalOutput8 = value;
                this.OnPropertyChanged(nameof(this.DigitalOutput8));
            }
        }

        public int AnalogOutput1
        {
            get => this._analogOutput1;
            set
            {
                this._analogOutput1 = value;
                this.OnPropertyChanged(nameof(this.AnalogInput1));
            }
        }

        public int AnalogOutput2
        {
            get => this._analogOutput2;
            set
            {
                this._analogOutput2 = value;
                this.OnPropertyChanged(nameof(this.AnalogInput2));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
