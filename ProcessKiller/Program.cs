using System;
using System.Diagnostics;
using System.Linq;

namespace ProcessKiller {
    class Program {
        private const int LINE_WIDTH = 60;
        private static bool ccEnd = false;

        static void Main(string[] args) {
            printHeader();

            int lProcessID = 0;

            while (ccEnd == false) {
                Console.Write("Please enter a process-ID: ");

                string lInput = Console.ReadLine();
                if (int.TryParse(lInput, out lProcessID)) {
                    handlePocessID(lProcessID);

                } else {
                    Console.WriteLine("Your input '{0}' is not a valid Number!\n", lInput);
                }

            }

            Console.WriteLine("Exit...");

        }


        private static void printHeader() {
            Console.WriteLine("".PadRight(LINE_WIDTH, '='));
            Console.WriteLine("|".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("| ProcessKiller".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("|".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("|".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("| Kills processes by ID".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("| Input an ID to end the process.".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("| A number below or equal to 0 closes this tool.".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("|".PadRight(LINE_WIDTH - 1, ' ') + "|");
            Console.WriteLine("".PadRight(LINE_WIDTH, '='));
            Console.WriteLine();
        }

        private static void handlePocessID(int xProcessID) {
            if (xProcessID <= 0) {
                Console.WriteLine("ID is lower or equal to 0. Program will exit now..");
                ccEnd = true;
            } else {
                Process lProcess = Process.GetProcesses().FirstOrDefault(x => x.Id.Equals(xProcessID));

                if (lProcess == null) {
                    Console.WriteLine("No process with ID {0} found..\n", xProcessID);
                } else {
                    killProcess(lProcess);
                }
            }
        }

        private static void killProcess(Process xProcess) {
            Console.WriteLine("Killing process: {0} - {1}", xProcess.Id, xProcess.ProcessName);
            try {
                xProcess.Kill();
            } catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error occured!! {0}", ex);
                Console.ResetColor();
            }
            Console.WriteLine("Process killed!");
        }


    }
}
