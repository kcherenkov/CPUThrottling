using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUThrottling
{
    public partial class Form1 : Form
    {
        private readonly Computer _computer;
        private Timer timer1;
        private bool currentlyThrottling = false;

        public Form1()
        {
            InitializeComponent();

             _computer = new Computer { CPUEnabled = true };
            _computer.Open();

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var coreAndTemperature = new Dictionary<string, float>();

            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update(); //use hardware.Name to get CPU model
                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                        coreAndTemperature.Add(sensor.Name, sensor.Value.Value);
                }
            }

            

            if (!currentlyThrottling && coreAndTemperature.Any(x=>x.Value >= (float)numericUpDownThrottleStart.Value))
            {
                currentlyThrottling = true;
                var activePowerScheme = NativeMethods.GetActivePowerScheme();
                NativeMethods.PowerWriteValueIndex(activePowerScheme, ref NativeMethods.GUID_PROCESSOR_SETTINGS_SUBGROUP,
                    ref NativeMethods.GUID_PROCESSOR_THROTTLE_MAXIMUM, (uint)numericUpDownThrottleStartMaxCPU.Value);
                
                label1.ForeColor = Color.Red;
            }

            else if (currentlyThrottling && coreAndTemperature.All(x=>x.Value < (float)numericUpDownThrottleEnd.Value))
            {
                currentlyThrottling = false;
                var activePowerScheme = NativeMethods.GetActivePowerScheme();
                NativeMethods.PowerWriteValueIndex(activePowerScheme, ref NativeMethods.GUID_PROCESSOR_SETTINGS_SUBGROUP,
                    ref NativeMethods.GUID_PROCESSOR_THROTTLE_MAXIMUM, (uint)numericUpDownThrottleEndMaxCPU.Value);

                label1.ForeColor = Color.Black;
            }

            var text = string.Join(Environment.NewLine, coreAndTemperature.Select(x => x.Key + " " + x.Value.ToString()));
            label1.Text = text;
        }
    }
}
