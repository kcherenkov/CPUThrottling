# CPUThrottling

This program enables CPU throttling when the temperature becomes too high to prevent chip overheating and PC turning off.
It is useful for the old CPUs/laptops which don't have hardware/BIOS implemented throttling.

Currently, it supports Windows OS and is implemented using the Windows Power Plan setting "Maximum processor state".
When a certain CPU temperature is reached, this program dynamically adjust current power plan and limits the "Maximum processor state",
what helps to reduce the heat.
