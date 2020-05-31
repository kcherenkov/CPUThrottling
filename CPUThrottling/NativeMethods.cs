using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CPUThrottling
{
    public static class NativeMethods
    {
        [DllImport("powrprof.dll")]
        public static extern uint PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll")]
        public static extern uint PowerWriteACValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, uint AcValueIndex);

        [DllImport("powrprof.dll")]
        public static extern uint PowerWriteDCValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, uint DcValueIndex);

        public static Guid GetActivePowerScheme()
        {
            IntPtr ptrActiveGuid = IntPtr.Zero;

            try
            {
                var hr = NativeMethods.PowerGetActiveScheme(IntPtr.Zero, ref ptrActiveGuid);
                if (hr == 0)
                {
                    var activeScheme = (Guid)Marshal.PtrToStructure(ptrActiveGuid, typeof(Guid));
                    return activeScheme;
                }
                return Guid.Empty;
            }
            finally
            {
                Marshal.FreeHGlobal(ptrActiveGuid);
            }
        }

        // Helper method that changes both the AC power setting and the DC (battery) power
        // setting.
        public static void PowerWriteValueIndex(Guid schemeGuid,
            ref Guid subGroupOfPowerSettingsGuid, ref Guid powerSettingGuid, uint valueIndex)
        {
            // When on AC power
            var hr = NativeMethods.PowerWriteACValueIndex(IntPtr.Zero, ref schemeGuid,
                ref subGroupOfPowerSettingsGuid, ref powerSettingGuid, valueIndex);
            if (hr != 0)
            {
                Console.WriteLine("Failed to write AC value");
            }

            // When on DC power (battery)
            hr = NativeMethods.PowerWriteDCValueIndex(IntPtr.Zero, ref schemeGuid,
                ref subGroupOfPowerSettingsGuid, ref powerSettingGuid, valueIndex);
            if (hr != 0)
            {
                Console.WriteLine("Failed to write DC value");
            }
        }

        public static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = new Guid("54533251-82be-4824-96c1-47b60b740d00");
        public static Guid GUID_PROCESSOR_THROTTLE_MAXIMUM = new Guid("BC5038F7-23E0-4960-96DA-33ABAF5935EC");
    }

}
