using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace JavaDocConverter
{
    public partial class JavaDocConverter : Form
    {
        private const string OtkOlLibDocs = @"otk\openjvs\ol_lib\docs";
        private const string OtkOpenjvsDocs = @"otk\openjvs\docs";

        public JavaDocConverter()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            this.Process();
            return;
        }


        private void BrowseSrcButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog srcDirectory;

            srcDirectory = new FolderBrowserDialog();
            if (srcDirectory.ShowDialog() == DialogResult.OK)
            {
                SrcDirectoryBox.Text = srcDirectory.SelectedPath;
            }
        }

        private void BrowseOutputButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputDirectory;
            outputDirectory = new FolderBrowserDialog();
            if (outputDirectory.ShowDialog() == DialogResult.OK)
            {
                OutputDirBox.Text = outputDirectory.SelectedPath;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Do the work to unzip the JAR file and change all of the necessary files
        /// </summary>
        private void Process()
        {
            string SrcPath, OutputPath, WorkPath, tmpFolder;
            List<string> jarList = new List<string>(); //Contains a list of all the paths to .jar files in the user-given directory

            SrcPath = SrcDirectoryBox.Text;
            if ((SrcPath == null) || (!Directory.Exists(SrcPath)))
            {
                MessageBox.Show("Source Directory is empty or invalid.");
                return;
            }

            OutputPath = OutputDirBox.Text;
            if (OutputPath == null)
            {
                MessageBox.Show("Output Directory is empty.");
                return;
            }
            if (!Directory.Exists(OutputPath))
                Directory.CreateDirectory(OutputPath);
            else
                clearFolder(OutputPath);

            tmpFolder = System.IO.Path.GetTempPath();
            WorkPath = tmpFolder + "\\JavaDocConversion";
            if (Directory.Exists(WorkPath))
                clearFolder(WorkPath);

            // Copy and unzip the JAR files for processing
            AddToList(jarList, SrcPath);
            UnzipFiles(jarList, WorkPath, SrcPath);

            // Convert the .html files extensions to .aspx files and any links in the file
            Reference.Process(WorkPath, OutputPath);
            deleteFolderRecursive(WorkPath);
            MessageBox.Show("Conversion completed successfully!");
            return;
        }

        // This method deletes the named folder and all of its contents
        private void deleteFolderRecursive(string folderName)
        {
            if (Directory.Exists(folderName))
            {
                clearFolder(folderName);
                try
                {
                    Directory.Delete(folderName);
                }
                catch (DirectoryNotFoundException)
                {
                    return;
                }
            }
            return;
        }
        private void clearFolder(string FolderName)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(FolderName);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(di.FullName);
                    di.Delete();
                }
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }

            return;
        }


        private string Get_OTK_OpenJVS_docs_path(string path)
        {
            //Returns one of the two paths that contain desired .jar files             
            return Path.Combine(path, OtkOpenjvsDocs);
        }

        private string Get_OTK_OpenJVS_lib_path(string path)
        {
            //Returns one of the two paths that contain desired .jar files

            return Path.Combine(path, OtkOlLibDocs);

        }

        /// <summary>
        /// Adds all the .jar file's paths to 'jarList'
        /// </summary>
        /// <param name="jarList"></param>
        private void AddToList(List<string> jarList, string path)
        {

            //contains the path to where the .jar files are in the openjvs\docs folder
            string openJvsDocsPath = Get_OTK_OpenJVS_docs_path(path);
            string[] filesInDocsPath = Directory.GetFiles(openJvsDocsPath);

            //contains the path to where the .jar files are in the openjvs\ol_lib\docs folder
            string libPath = Get_OTK_OpenJVS_lib_path(path);
            string[] filesInLibPath = Directory.GetFiles(libPath);

            foreach (string fullFilePath in filesInDocsPath)
            {
                FileInfo fileInfo = new FileInfo(fullFilePath);
                string ext = Path.GetExtension(fileInfo.ToString());

                if (ext.Equals(".jar"))
                {
                    string addList = Path.GetFullPath(fileInfo.ToString());
                    jarList.Add(addList);
                }
            }

            foreach (string fullFilePath in filesInLibPath)
            {
                FileInfo fileInfo = new FileInfo(fullFilePath);
                string ext = Path.GetExtension(fileInfo.ToString());

                if (ext.Equals(".jar"))
                {
                    string addList = Path.GetFullPath(fileInfo.ToString());
                    jarList.Add(addList);
                }
            }

            return;
        }

        /// <summary>
        /// Unzips the .jar files to the given path
        /// </summary>
        /// <param name="jarList"></param>
        /// <param name="unzippedFolderPath"></param>
        private void UnzipFiles(List<string> jarList, string OutputPath, string SrcPath)
        {
            foreach (string jarFile in jarList)
            {
                string jarFileName = Path.GetFileNameWithoutExtension(jarFile);
                if (jarFileName != null)
                {
                    string endPath2 = Path.Combine(OutputPath, jarFileName);
                    ZipFile.ExtractToDirectory(jarFile, endPath2);
                }
            }
            return;
        }

            }

}
