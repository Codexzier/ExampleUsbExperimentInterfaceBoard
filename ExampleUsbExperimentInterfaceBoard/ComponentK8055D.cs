using System;
using System.Runtime.InteropServices;

namespace ExampleUsbExperimentInterfaceBoard
{
    public class ComponentK8055D : IDisposable
    {
        #region add dll

        [DllImport("K8055D.dll")]
        private static extern int OpenDevice(int CardAddress);

        [DllImport("K8055D.dll")]
        private static extern void CloseDevice();

        [DllImport("K8055D.dll")]
        private static extern bool ReadDigitalChannel(int Channel);

        [DllImport("K8055D.dll")]
        private static extern void SetDigitalChannel(int Channel);

        [DllImport("K8055D.dll")]
        private static extern void ClearDigitalChannel(int Channel);

        [DllImport("K8055D.dll")]
        private static extern int ReadAnalogChannel(int Channel);

        [DllImport("K8055D.dll")]
        private static extern void OutputAnalogChannel(int Channel, int Data);

        #endregion

        #region public methods

        /// <summary>
        /// get the address int setup by sk5 and sk6.
        /// </summary>
        /// <returns>Return the address number</returns>
        public int Open(bool sk5, bool sk6)
        {
            // sk5     | ON | OFF |  ON | OFF
            // sk6     | ON |  ON | OFF | OFF
            // -------------------------------
            // address |  0 |   1 |   2 |   3

            int result = 3;

            result -= sk5 ? 1 : 0;
            result -= sk6 ? 2 : 0;

            OpenDevice(result);

            return result;
        }

        /// <summary>
        /// close the actual connection to the board
        /// </summary>
        internal void Close() => CloseDevice();

        /// <summary>
        /// Write digital output
        /// </summary>
        /// <param name="outputNumber">set output number between 1 to 8</param>
        /// <param name="setupOnOff">Set true for set output high</param>
        public void WriteOutputDigital(int outputNumber, bool setupOnOff)
        {
            outputNumber = this.MinMaxValue(outputNumber, 1, 8);

            if (setupOnOff)
            {
                SetDigitalChannel(outputNumber);
            }
            else
            {
                ClearDigitalChannel(outputNumber);
            }
        }

        /// <summary>
        /// Write analog output
        /// </summary>
        /// <param name="outputNumber">Set output 1 or 2.</param>
        /// <param name="value">Set value between 0 to 255.</param>
        public void WriteOutputAnalog(int outputNumber, int value)
        {
            outputNumber = this.MinMaxValue(outputNumber, 1, 2);
            value = this.MinMaxValue(value, 0, 255);

            OutputAnalogChannel(outputNumber, value);
        }

        /// <summary>
        /// can from 1 to 5.
        /// </summary>
        /// <param name="inputNumber">Set digital input number 1, 2, 3, 4 or 5</param>
        /// <returns></returns>
        public bool ReadDigitalInput(int inputNumber)
        {
            inputNumber = this.MinMaxValue(inputNumber, 1, 5);

            return ReadDigitalChannel(inputNumber);
        }

        /// <summary>
        /// Get analog value
        /// </summary>
        /// <param name="inputNumber">Set number 1 or 2</param>
        /// <returns></returns>
        public int ReadAnalogInput(int inputNumber)
        {
            inputNumber = this.MinMaxValue(inputNumber, 1, 2);

            return ReadAnalogChannel(inputNumber);
        }

        #endregion

        #region private methods

        private int MinMaxValue(int value, int limitMin, int limitMax)
        {
            if(value < limitMin)
            {
                value = limitMin;
            }

            if(value > limitMax)
            {
                value = limitMax;
            }

            return value;
        }

        #endregion

        public void Dispose() => CloseDevice();
    }
}
