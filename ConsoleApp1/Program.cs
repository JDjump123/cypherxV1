using System;
using System.Diagnostics;

namespace AndroidUtilityMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============================");
                Console.WriteLine(" Android  Menu BETA");
                Console.WriteLine("============================");
                Console.WriteLine("1. Reboot to Fastboot");
                Console.WriteLine("2. Reboot to Recovery");
                Console.WriteLine("3. Reboot to Sideload");
                Console.WriteLine("4. Unlock Bootloader");
                Console.WriteLine("5. Run ADB Command");
                Console.WriteLine("6. Root Device");
                Console.WriteLine("7. Flash TWRP");
                Console.WriteLine("8. Boot Image");
                Console.WriteLine("9. SURoot (Root without Bootloader Unlock)");
                Console.WriteLine("10. FACTORY RESET (Works on a few devices)");
                Console.WriteLine("11. Fake brick");
                Console.WriteLine("12. Exit");
                Console.WriteLine("===========================");
                Console.Write("Select an option (1-12): ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RebootToFastboot();
                        break;
                    case "2":
                        RebootToRecovery();
                        break;
                    case "3":
                        RebootToSideload();
                        break;
                    case "4":
                        UnlockBootloader();
                        break;
                    case "5":
                        RunADBCommand();
                        break;
                    case "6":
                        RootDevice();
                        break;
                    case "7":
                        FlashTWRP();
                        break;
                    case "8":
                        BootImage();
                        break;
                    case "9":
                        SURoot();
                        break;
                    case "10":
                        FactoryReset();
                        break;
                    case "11":
                        FakeBrick();
                        break;
                    case "12":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            Process process = Process.Start(processInfo);
            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Close();
        }

        static void RebootToFastboot()
        {
            Console.WriteLine("Rebooting to Fastboot...");
            ExecuteCommand("adb reboot fastboot");
            Console.WriteLine("[LOG] Rebooted to Fastboot");
            Pause();
        }

        static void RebootToRecovery()
        {
            Console.WriteLine("Rebooting to Recovery...");
            ExecuteCommand("adb reboot recovery");
            Console.WriteLine("[LOG] Rebooted to Recovery");
            Pause();
        }

        static void RebootToSideload()
        {
            Console.WriteLine("Rebooting to Sideload...");
            ExecuteCommand("adb reboot sideload");
            Console.WriteLine("[LOG] Rebooted to Sideload");
            Pause();
        }

        static void UnlockBootloader()
        {
            Console.WriteLine("Unlocking Bootloader... This will wipe all data!");
            Console.Write("Continue? (yes/no): ");
            var confirm = Console.ReadLine();
            if (confirm.ToLower() == "yes")
            {
                ExecuteCommand("adb reboot bootloader");
                ExecuteCommand("fastboot oem unlock");
                Console.WriteLine("[LOG] Bootloader unlocked");
            }
            else
            {
                Console.WriteLine("[LOG] Bootloader unlock canceled");
            }
            Pause();
        }

        static void RunADBCommand()
        {
            Console.Write("Enter the ADB command: ");
            var adbcmd = Console.ReadLine();
            ExecuteCommand($"adb {adbcmd}");
            Console.WriteLine("[LOG] Command executed");
            Pause();
        }

        static void RootDevice()
        {
            Console.WriteLine("Rooting Device...");
            Console.Write("Enter the path to the patched boot image: ");
            var bootimage = Console.ReadLine();
            ExecuteCommand("adb reboot bootloader");
            ExecuteCommand($"fastboot flash boot {bootimage}");
            ExecuteCommand("fastboot reboot");
            Console.WriteLine("[LOG] Device rooted");
            Pause();
        }

        static void FlashTWRP()
        {
            Console.WriteLine("Flashing TWRP...");
            Console.Write("Enter the path to the TWRP image: ");
            var twrpImg = Console.ReadLine();
            ExecuteCommand("adb reboot bootloader");
            ExecuteCommand($"fastboot flash recovery {twrpImg}");
            Console.WriteLine("[LOG] TWRP flashed");
            Pause();
        }

        static void BootImage()
        {
            Console.Write("Enter the path to the image file you want to boot: ");
            var imgfile = Console.ReadLine();
            ExecuteCommand($"fastboot boot {imgfile}");
            Console.WriteLine("[LOG] Image booted");
            Pause();
        }

        static void SURoot()
        {
            Console.WriteLine("Rooting device without unlocking bootloader... Proceed with caution!");
            Console.Write("Continue? (yes/no): ");
            var confirm = Console.ReadLine();
            if (confirm.ToLower() == "yes")
            {
                ExecuteCommand("adb reboot bootloader");
                ExecuteCommand("fastboot flash recovery twrp.img");
                ExecuteCommand("adb push magisk.zip /sdcard/");
                ExecuteCommand("adb shell twrp install /sdcard/magisk.zip");
                ExecuteCommand("adb shell chmod 755 /system");
                ExecuteCommand("adb shell chmod 755 /system/bin");
                Console.WriteLine("[LOG] SURoot completed");
            }
            else
            {
                Console.WriteLine("[LOG] SURoot canceled");
            }
            Pause();
        }

        static void FactoryReset()
        {
            Console.WriteLine("Factory Reset... This will erase all data!");
            Console.Write("Continue? (yes/no): ");
            var confirm = Console.ReadLine();
            if (confirm.ToLower() == "yes")
            {
                ExecuteCommand("adb reboot bootloader");
                ExecuteCommand("fastboot erase userdata");
                Console.WriteLine("[LOG] Factory reset done");
            }
            else
            {
                Console.WriteLine("[LOG] Factory reset canceled");
            }
            Pause();
        }

        static void FakeBrick()
        {
            Console.WriteLine("Initiating fake brick mode...");
            Console.WriteLine("[WARNING] This is a prank and won’t brick your device.");
            Console.Write("Enter \"qwertyuiopasdfghjklzxcvbnm1234567890\" to confirm: ");
            var confirmation = Console.ReadLine();
            if (confirmation == "qwertyuiopasdfghjklzxcvbnm1234567890")
            {
                ExecuteCommand("adb reboot bootloader");
                System.Threading.Thread.Sleep(10000);
                ExecuteCommand("fastboot reboot fastboot");
                System.Threading.Thread.Sleep(5000);
                ExecuteCommand("fastboot reboot sideload");
                System.Threading.Thread.Sleep(5000);
                ExecuteCommand("fastboot reboot");
                Console.WriteLine("[LOG] Fake brick done");
            }
            else
            {
                Console.WriteLine("[LOG] Incorrect code. Fake brick canceled.");
            }
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
