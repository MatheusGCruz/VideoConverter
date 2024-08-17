using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace VideoConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadFiles();
        }

        private void InputTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadFiles() 
        {
            inputDirText.Text = "D:/Videos";
            outputDirText.Text = "D:/Videos";



            DirectoryInfo inputDirectory = new DirectoryInfo(inputDirText.Text); //Assuming Test is your Folder

            FileInfo[] inputFiles = inputDirectory.GetFiles("*.mkv"); //Getting Text files
            string inputString = "";

            DirectoryInfo outputDirectory = new DirectoryInfo(outputDirText.Text); //Assuming Test is your Folder

            FileInfo[] outputFiles = outputDirectory.GetFiles("*.mp4"); //Getting Text files
            string outputString = "";

            foreach (FileInfo file in inputFiles)
            {
                inputString = inputString + file.Name.Replace(".mkv","");
                inputString = inputString + Environment.NewLine;
            }

            foreach (FileInfo file in outputFiles)
            {
                outputString = outputString + file.Name.Replace(".mp4", "");
                outputString = outputString + Environment.NewLine;
            }

            foreach (FileInfo inputFile in inputFiles)
            {
                bool isNew = true;
                foreach (FileInfo outputFile in outputFiles)
                {
                    Console.WriteLine(inputFile.Name.Replace(".mkv", "")+"-"+outputFile.Name.Replace(".mp4", ""));
                    
                    if (inputFile.Name.Replace(".mkv", "") == outputFile.Name.Replace(".mp4", "")) { isNew = false; break; }
                }
                Console.WriteLine(isNew.ToString());
                if (isNew)
                {
                    filesComboBox.Items.Add(inputFile.Name);
                }
            }


            InputTextbox.Text = inputString;
            OutputTextbox.Text = outputString;
        
        }

        private void convert_Click(object sender, EventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            string fileName = filesComboBox.Text.Replace(".mkv","");
            string inputValue = inputDirText.Text+"/"+fileName+".mkv";
            string outputValue = outputDirText.Text + "/" + fileName + ".mp4";

            var process = new Process { StartInfo = startInfo };

            process.Start();
            process.StandardInput.WriteLine(@"D:");
            process.StandardInput.WriteLine(@"cd Videos\");
            Console.WriteLine(@"C:\Projects\ffmpeg\bin\ffmpeg -i " + inputValue + " -vf subtitles=" + inputValue + " " + outputValue);
            process.StandardInput.WriteLine(@"C:\Projects\ffmpeg\bin\ffmpeg -i "+ inputValue + " -vf subtitles="+ inputValue + " "+ outputValue);
            process.StandardInput.WriteLine("exit");

            process.WaitForExit();
        }
    }
}
