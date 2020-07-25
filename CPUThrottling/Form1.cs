using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private bool allowVisible = true;

        public Form1()
        {
            InitializeComponent();

             _computer = new Computer { CPUEnabled = true };
            _computer.Open();

            allowVisible = !Settings.Default.StartMinimized;

            LoadSettings();

            // reset CPU max speed on startup
            var activePowerScheme = NativeMethods.GetActivePowerScheme();
            NativeMethods.PowerWriteValueIndex(activePowerScheme, ref NativeMethods.GUID_PROCESSOR_SETTINGS_SUBGROUP,
                ref NativeMethods.GUID_PROCESSOR_THROTTLE_MAXIMUM, (uint)numericUpDownThrottleEndMaxCPU.Value);

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in milliseconds
            timer1.Start();
        }

        private void LoadSettings()
        {
            this.numericUpDownThrottleStart.Value = Settings.Default.ThrottleStartTemperature;
            this.numericUpDownThrottleEnd.Value = Settings.Default.ThrotleEndTemperature;
            this.numericUpDownThrottleStartMaxCPU.Value = Settings.Default.ThrottleStartMaxCpu;
            this.numericUpDownThrottleEndMaxCPU.Value = Settings.Default.ThrottleEndMaxCpu;
            this.checkBoxStartMinimized.Checked = Settings.Default.StartMinimized;
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                myNotifyIcon.Visible = true;
                
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                myNotifyIcon.Visible = false;
            }
        }

        private void MyNotifyIcon_Click(object sender, System.EventArgs e)
        {
            allowVisible = true;
            Show();
            this.WindowState = FormWindowState.Normal;
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
            myNotifyIcon.Text = text;
        }

        // https://stackoverflow.com/a/1732294
        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.ThrottleStartTemperature = (uint) numericUpDownThrottleStart.Value;
            Settings.Default.ThrotleEndTemperature = (uint) numericUpDownThrottleEnd.Value;
            Settings.Default.ThrottleStartMaxCpu = (uint) numericUpDownThrottleStartMaxCPU.Value;
            Settings.Default.ThrottleEndMaxCpu = (uint) numericUpDownThrottleEndMaxCPU.Value;
            Settings.Default.StartMinimized = checkBoxStartMinimized.Checked;
            Settings.Default.Save();
        }
    }
}
