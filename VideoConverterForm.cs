using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoConverter.Auxiliary;

namespace VideoConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadConfig();
            loadFiles();
        }

        private void InputTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadConfig()
        {
            inputDirText.Text = "D:/Videos";
            outputDirText.Text = "\\\\Antares-server\\k\\Source\\NodeServer\\videos";
        }

        private void loadFiles() 
        {
            DirectoryInfo inputDirectory = new DirectoryInfo(inputDirText.Text); //Assuming Test is your Folder

            FileInfo[] inputFiles = inputDirectory.GetFiles("*.mkv"); //Getting Text files
            string inputString = "";

            DirectoryInfo outputDirectory = new DirectoryInfo(outputDirText.Text); //Assuming Test is your Folder

            FileInfo[] outputFiles = outputDirectory.GetFiles("*.mp4"); //Getting Text files
            string outputString = "";

            foreach (FileInfo file in inputFiles)
            {
                inputString = inputString + TextAdjust.InputName(file.Name);
                inputString = inputString + Environment.NewLine;
            }

            foreach (FileInfo file in outputFiles)
            {
                outputString = outputString + TextAdjust.OutputName(file.Name);
                outputString = outputString + Environment.NewLine;
            }
            filesComboBox.Items.Clear();
            foreach (FileInfo inputFile in inputFiles)
            {
                bool isNew = true;
                foreach (FileInfo outputFile in outputFiles)
                {              
                    if (TextAdjust.InputName(inputFile.Name) == TextAdjust.OutputName(outputFile.Name)) { isNew = false; break; }
                }
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


            Console.WriteLine("Importing file:"+ filesComboBox.Text);
            string bufferedFile = importFile(filesComboBox.Text);
            string outputValue = bufferedFile.Replace(".mkv", "-out.mp4");


            Console.WriteLine("Converting ...");
            string parameter = " -i " + bufferedFile + " -vf subtitles=" + bufferedFile + ":si=" + Subtitles.subtitles("por","Erai-raws") + " " + outputValue;

            Console.WriteLine(Execute(@"C:\Projects\ffmpeg\bin\ffmpeg", parameter));

            Console.WriteLine("Conversion Finished");

            exportFile(outputValue);
            Console.WriteLine("Archive Exported");

            deleteBufferedFile(bufferedFile);
            Console.WriteLine("Buffer cleared");


        }

        private static string Execute(string exePath, string parameters)
        {
            string result = String.Empty;

            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = exePath;
                p.StartInfo.Arguments = parameters;
                p.Start();
                p.WaitForExit();

                result = p.StandardOutput.ReadToEnd();
            }

            return result;
        }


        private string importFile(string completeFileName)
        {
            try
            {
                string fileToMove = inputDirText.Text +"/" + completeFileName;
                string moveTo = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" +completeFileName;
                //moving file
                Console.WriteLine(fileToMove);
                Console.WriteLine(moveTo);
                File.Copy(fileToMove, moveTo);

                string oldFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + completeFileName;
                string newFileName = TextAdjust.InputName(completeFileName) + ".mkv";
                string newFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + newFileName;
            

                System.IO.File.Move(oldFilePath, newFilePath);

                Console.WriteLine("Imported: "+newFileName);

                return newFileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        private string exportFile(string completeFileName)
        {
            try
            {
                string fileToMove = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + completeFileName;
                string moveTo  = outputDirText.Text + "/" + completeFileName;
                //moving file
                Console.WriteLine(fileToMove);
                Console.WriteLine(moveTo);
                File.Move(fileToMove, moveTo);
                return moveTo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        private void deleteBufferedFile(string completeFileName)
        {
            try
            {
            string fileToDelete = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + completeFileName;
            File.Delete(fileToDelete);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.SetOut(new MultiTextWriter(new TextStreamWriter(consoleTextBox), Console.Out));
            consoleTextBox.SelectionStart = consoleTextBox.Text.Length;
            consoleTextBox.ScrollToCaret();

            Console.WriteLine("Now redirecting output to the text box");
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            loadFiles();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo inputDirectory = new DirectoryInfo(inputDirText.Text); //Assuming Test is your Folder

            FileInfo[] inputFiles = inputDirectory.GetFiles("*.mkv"); //Getting Text files
            foreach (FileInfo file in inputFiles)
            {
                string oldFileName = inputDirectory.FullName +"\\"+ file.Name;
                string newFileName = inputDirectory.FullName + "\\" + TextAdjust.InputName(file.Name) + ".mkv";
                System.IO.File.Move(oldFileName, newFileName);
            }
            loadFiles();
        }
    }
}
