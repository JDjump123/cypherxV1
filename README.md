# cypherX

cypherX is a powerful and user-friendly Windows Console application designed to simplify various Android device operations. Whether you need to reboot into different modes, unlock the bootloader, run ADB commands, or root your device, cypherX has you covered.

## Features

- Reboot to Fastboot
- Reboot to Recovery
- Reboot to Sideload
- Unlock Bootloader
- Run ADB Commands
- Root Device
- Flash TWRP
- Boot Image
- SURoot (Root without Bootloader Unlock)
- Factory Reset (Works on a few devices)
- Fake Brick (Harmless prank)

## Installation

1. Ensure you have the Android SDK installed and `adb` and `fastboot` accessible from your system PATH.
2. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/cypherX.git
    ```
3. Open the solution file `cypherX.sln` in Visual Studio.
4. Build the solution.

## Usage

1. Open a terminal and navigate to the directory where `cypherX.exe` is located.
2. Run the application:
    ```sh
    cypherX.exe
    ```
3. Follow the on-screen instructions to navigate through the menu and perform various actions.

## Menu Options

1. **Reboot to Fastboot**: Reboot your device into Fastboot mode.
2. **Reboot to Recovery**: Reboot your device into Recovery mode.
3. **Reboot to Sideload**: Reboot your device into Sideload mode.
4. **Unlock Bootloader**: Unlock the bootloader of your device. (This will erase all data on your device)
5. **Run ADB Command**: Execute any ADB command directly from the console.
6. **Root Device**: Root your device using a patched boot image.
7. **Flash TWRP**: Flash TWRP recovery image onto your device.
8. **Boot Image**: Boot your device from a specified image file.
9. **SURoot**: Root your device without unlocking the bootloader. (Proceed with caution)
10. **Factory Reset**: Perform a factory reset on your device. (This will erase all data on your device)
11. **Fake Brick**: Initiate a harmless fake brick prank.
12. **Exit**: Exit the application.


## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any enhancements, bug fixes, or features.

## Disclaimer

Use this tool at your own risk. The author is not responsible for any damage caused to your device by using this tool.
