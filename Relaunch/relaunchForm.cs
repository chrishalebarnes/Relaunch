using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;
using Microsoft.Win32;

namespace Relaunch
{
    public partial class RelaunchForm : Form
    {
        public String chromePath;
        public String internetExplorerPath;
        public String operaPath;
        public String kyloPath;
        public String huluPath;
        public string steamPath;

        public RelaunchForm()
        {
            //keyboard shortcut is win+alt+enter
            //which is 0x5B+0x12+0x0D
            InitializeComponent();

            //Check for relaunch folder
            if (!System.IO.Directory.Exists(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\"))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\");
                }
                catch { MessageBox.Show("Error: Could not create Relaunch directory"); }
            }
            if (!System.IO.Directory.Exists(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\"))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\");
                }
                catch { MessageBox.Show("Error: Could not create Relaunch directory"); }
            }

            checkBrowsers();
            addApp.Text = "Custom";
            checkCurrentApps();
        }
        public void checkCurrentApps()
        {
            //Checks for current MCLs and adds them to the listbox
            currentApps.Items.Clear();
            string[] fileNames = Directory.GetFiles(Environment.GetEnvironmentVariable("AppData") + @"\Media Center Programs");
            for (int i=0;i<fileNames.Length; i++)
            {
                String appNameFromXml = null;
                try
                {
                    StreamReader stream = new StreamReader(fileNames[i]);
                    XmlDocument xml = new XmlDocument();
                    xml.Normalize();
                    xml.Load(stream);
                    stream.Close();
                    appNameFromXml = xml.SelectSingleNode("/application/@Name").Value;
                    if (!currentApps.Items.Contains(appNameFromXml))
                        currentApps.Items.Add(appNameFromXml);
                }
                catch { MessageBox.Show("Trouble validating MCL: "+appNameFromXml); Environment.Exit(1); }
            }
        }

        private void checkBrowsers()
        {
            if(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\Google Chrome\shell\open\command", "", null)!=null)
            {
                chromePath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\Google Chrome\shell\open\command", "", null).ToString();
                typeBox.Items.Add("Chrome");
                chromePath=chromePath.Replace("\"", "");
            }
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\IEXPLORE.EXE\shell\open\command", "", null)!=null)
            {
                internetExplorerPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\IEXPLORE.EXE\shell\open\command", "", null).ToString();
                typeBox.Items.Add("Internet Explorer");
                internetExplorerPath = internetExplorerPath.Replace("\"", "");
            }
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\Opera\shell\open\command", "", null) != null)
            {
                operaPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\Opera\shell\open\command", "", null).ToString();
                typeBox.Items.Add("Opera");             
                operaPath = operaPath.Replace("\"", "");
            }
            
            if(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Kylo Browser\")!=null)
            {
                //Kylo 64 bit All users
                RegistryKey kyloRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Kylo Browser\");
                kyloPath = kyloRegKey.GetValue("UninstallString").ToString();
                kyloPath = kyloPath.Substring(0, kyloPath.Length - 15) + "Kylo.exe";    //remove "uninstall.exe" and add "Kylo.exe"
                kyloRegKey.Close();
                typeBox.Items.Add("Kylo");
                kyloPath = kyloPath.Replace("\"", "");
            } else if (Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Kylo Browser\") != null)
            {
                //Kylo 32 bit all users
                RegistryKey kyloRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Kylo Browser\");
                kyloPath = kyloRegKey.GetValue("UninstallString").ToString();
                kyloPath = kyloPath.Substring(0, kyloPath.Length - 15) + "Kylo.exe";    //remove "uninstall.exe" and add "Kylo.exe"
                kyloRegKey.Close();
                typeBox.Items.Add("Kylo");
                kyloPath = kyloPath.Replace("\"", "");
             } else if (Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Kylo Browser")!=null)
             {
                //Kylo single user 32+64 bit
                RegistryKey kyloRegKey32 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Kylo Browser");
                kyloPath = kyloRegKey32.GetValue("UninstallString").ToString();
                kyloPath = kyloPath.Substring(0, kyloPath.Length - 15) + "Kylo.exe";    //remove "uninstall.exe" and add "Kylo.exe"
                kyloRegKey32.Close();
                typeBox.Items.Add("Kylo");
                if (typeBox.Text == null)
                    typeBox.Text = "Kylo";
                kyloPath = kyloPath.Replace("\"", "");
             }
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\hulu\shell\open\command", "", null) != null)
            {
                //HKEY_CLASSES_ROOT\hulu\shell\open\command
                huluPath = Registry.GetValue(@"HKEY_CLASSES_ROOT\hulu\shell\open\command", "", null).ToString();
                huluPath = huluPath.Replace("\"", "");
                huluPath = Path.GetDirectoryName(huluPath) + @"\"+ Path.GetFileNameWithoutExtension(huluPath)+".exe";   //sanitize out any arguments
            }
            if (Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam") != null)
            {
                RegistryKey steamKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");
                steamPath = steamKey.GetValue("SteamExe").ToString();
                steamPath = steamPath.Replace("\"", "");
                steamPath = Path.GetDirectoryName(steamPath) + @"\" + Path.GetFileNameWithoutExtension(steamPath) + ".exe";   //sanitize out any arguments
            }

            typeBox.Items.Add("Program");
            typeBox.SelectedIndex = 0;
            bringBackType.SelectedIndex = 0;
        }

        private void mRecreateAllExecutableResources()
        {
            //From the very helpful http://www.cs.nyu.edu/~vs667/articles/embed_executable_tutorial/
            // Get Current Assembly refrence
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            // Get all imbedded resources
            string[] arrResources = currentAssembly.GetManifestResourceNames();

            foreach (string resourceName in arrResources)
            {
                if (resourceName.EndsWith(".exe")||resourceName.EndsWith(".bin"))
                { //or any other extension desired
                    //Name of the file saved on disk
                    string saveAsName = resourceName.Substring(9);  //remove Relaunc. from resource
                    FileInfo fileInfoOutputFile = new FileInfo(saveAsName);

                    if (fileInfoOutputFile.Exists)
                    {
                        //overwrite if desired or break (depending on your needs)
                        //fileInfoOutputFile.Delete();
                    }
                    //OPEN NEWLY CREATING FILE FOR WRITTING
                    FileStream streamToOutputFile = fileInfoOutputFile.OpenWrite();
                    //GET THE STREAM TO THE RESOURCES
                    Stream streamToResourceFile = currentAssembly.GetManifestResourceStream(resourceName);

                    //---------------------------------
                    //SAVE TO DISK OPERATION
                    //---------------------------------
                    const int size = 4096;
                    byte[] bytes = new byte[4096];
                    int numBytes;
                    while ((numBytes = streamToResourceFile.Read(bytes, 0, size)) > 0)
                    {
                        streamToOutputFile.Write(bytes, 0, numBytes);
                    }

                    streamToOutputFile.Close();
                    streamToResourceFile.Close();
                }//if

            }//end_foreach
        }//end_mRecreateAllExecutableResources

        private void Save(object sender, EventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 6;
            string fakeBoolean;
            if(Fullscreen.Checked==true)
                fakeBoolean = "true";
            else
                fakeBoolean = "false";
            string[] args = {pathBox.Text.Trim(), imageBox.Text.Trim(), nameBox.Text.Trim(), typeBox.Text.Trim(), fakeBoolean, bringBackType.Text.Trim()};
            addWorker.RunWorkerAsync(args);
        }

        private void Cancel(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void imageBoxTextChanged(object sender, EventArgs e)
        {         
            previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if(!imageBox.Text.Equals("Embeded: Change if you want a different image"))                
                previewBox.ImageLocation = imageBox.Text.Trim();
        }

        private void nameBoxTextChanged(object sender, EventArgs e)
        {
            previewLabel.Text = nameBox.Text;
        }

        private void typeBoxChanged(object sender, EventArgs e)
        {         
            if (typeBox.Text.Trim().Equals("Program"))
            {
                pathBrowse.Show();                
                Fullscreen.Hide();
                pathLabel.Text = "Path:";
            }
            else if (typeBox.Text.Trim().Equals("Kylo"))
            {
                pathBrowse.Hide();
                Fullscreen.Hide();
                pathLabel.Text = "URL:";
            }
            else
            {
                pathBrowse.Hide();
                Fullscreen.Show();
                pathLabel.Text = "URL:";
            }
        }

        private void imageClick(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                imageBox.Text = openFileDialog1.FileName;
            }
        }

        private void pathClick(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result1 = openFileDialog2.ShowDialog();
            if (result1 == DialogResult.OK) // Test result.
            {
                pathBox.Text = openFileDialog2.FileName;
            }
        }

        private void createLauncher(object sender, DoWorkEventArgs e)
        {
            mRecreateAllExecutableResources();  //recreate executables
              //parse the arguments
            String address,imagePath,name,prog,bBackType;
            Boolean fullScreened;

            string[] args = e.Argument as string[];
            address = args[0];
            imagePath = args[1];
            name = args[2];
            prog = args[3];                

            if(args[4].Equals("true"))
                fullScreened=true;
            else
                fullScreened=false;
            bBackType = args[5];
            
            //Construct the MCL file
            String mediaCenterName = string.Copy(name);
            name = name.Replace(" ", "").ToLower();   //to avoid spaces in exe

            //If name is the same as any browsers exe things will break, append something to it
            name = name + "_relaunch";
            
            //little validation to check if files already exist to head off errors at the pass
            if (System.IO.File.Exists(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\" + name + Path.GetExtension(imagePath)))
            {
                MessageBox.Show("Error: The image already exists. Remove it and try again.");
                Environment.Exit(1);
            }
            if (System.IO.File.Exists(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\" + name + ".exe"))
            {
                MessageBox.Show("Error: The exe already exists. Remove it and try again.");
                Environment.Exit(1);
            }
            if (System.IO.File.Exists(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl"))
            {
                MessageBox.Show("Error: The mcl already exists. Remove it and try again.");
                Environment.Exit(1);
            }

            //Copy over image
            try
            {
                if (imagePath.Equals("Embeded: Change if you want a different image"))
                {
                    previewBox.Image.Save(Environment.GetEnvironmentVariable("LocalAppData")+@"\Relaunch\" + name + ".png");
                    imagePath = Environment.GetEnvironmentVariable("LocalAppData")+@"\Relaunch\" + name + ".png";
                }
                else
                {
                    System.IO.File.Copy(imagePath, Environment.GetEnvironmentVariable("LocalAppData")+@"\Relaunch\" + name + Path.GetExtension(imagePath), true);
                }
            }
            catch
            { 
                MessageBox.Show("Error processing the image: "+Path.GetFileName(imagePath));
                if (System.IO.File.Exists(name + ".exe")) { System.IO.File.Delete(name + ".exe"); }
                if (System.IO.File.Exists(name + ".au3")) { System.IO.File.Delete(name + ".au3"); }
                if (System.IO.File.Exists("Aut2exe.exe")) { System.IO.File.Delete("Aut2exe.exe"); }
                if (System.IO.File.Exists("AutoItSC.bin")) { System.IO.File.Delete("AutoItSC.bin"); }
                Environment.Exit(1);
            }

            //write MCL file
            String[] mclfile = new String[7];
            mclfile[0] = "<application run=\""+Environment.GetEnvironmentVariable("LocalAppData")+@"\Relaunch\" + name + ".exe\"";
            mclfile[1] = "Name = \"" + mediaCenterName + "\"";
            mclfile[2] = "bgcolor=\"RGB(0,0,0)\"";
            mclfile[3] = "startimage=\"" + Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\" + name + Path.GetExtension(imagePath) + "\"";
            mclfile[4] = "thumbnailImage=\"\"";
            mclfile[5] = "sharedviewport=\"false\" >";
            mclfile[6] = "</application>";

            //check for directory to store files, if it is not there, then create it
            if (!System.IO.Directory.Exists(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\"))
            {
                System.IO.Directory.CreateDirectory(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\");
            }

            try
            {
                System.IO.File.WriteAllLines(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl", mclfile);
            }
            catch 
            {
                MessageBox.Show("Error writing the MCL file");
                if(System.IO.File.Exists(imagePath)){System.IO.File.Delete(imagePath);}
                if (System.IO.File.Exists(name + ".exe")) { System.IO.File.Delete(name + ".exe"); }
                if (System.IO.File.Exists(name + ".au3")) { System.IO.File.Delete(name + ".au3"); }
                if (System.IO.File.Exists("Aut2exe.exe")) { System.IO.File.Delete("Aut2exe.exe"); }
                if (System.IO.File.Exists("AutoItSC.bin")) { System.IO.File.Delete("AutoItSC.bin"); }
                Environment.Exit(1); 
            }
            
            String[] autoitscript = new String[5];
            if (prog.Equals("Chrome"))
            {
                if (fullScreened == true)
                    autoitscript[0] = "Run(\"" + chromePath + " -kiosk " + address + "\", \"" + Path.GetDirectoryName(chromePath) + "\", @SW_MAXIMIZE)";
                else
                    autoitscript[0] = "Run(\""+chromePath+" " + address + "\", \""+Path.GetDirectoryName(chromePath)+"\", @SW_MAXIMIZE)";
                if (bBackType.Equals("Close  App"))
                {
                    //Wait for spawned process to close
                    autoitscript[1] = "ProcessWaitClose(\""+Path.GetFileName(chromePath)+"\")";
                    autoitscript[2] = "Run(@WindowsDir&\"\\ehome\\ehshell.exe\",@WindowsDir&\"\\ehome\")";
                }
                else
                {
                    //Wait for Media Center focus
                    autoitscript[1] = "sleep(1000)";
                    autoitscript[2] = "WinWaitActive(\"Windows Media Center\")";
                    autoitscript[3] = "ProcessClose(\""+Path.GetFileName(chromePath)+"\")";

                }
            }
            else if (prog.Equals("Internet Explorer"))
            {
                if (fullScreened == true)
                    autoitscript[0] = "Run(\"" + internetExplorerPath + " -k " + address + "\", \"" + Path.GetDirectoryName(internetExplorerPath) + "\", @SW_MAXIMIZE)";
                else
                    autoitscript[0] = "Run(\"" + internetExplorerPath + " " + address + "\", \"" + Path.GetDirectoryName(internetExplorerPath) + "\", @SW_MAXIMIZE)";
                if (bBackType.Equals("Close  App"))
                {
                    //Wait for spawned process to close
                    autoitscript[1] = "ProcessWaitClose(\""+Path.GetFileName(internetExplorerPath)+"\")";
                    autoitscript[2] = "Run(@WindowsDir&\"\\ehome\\ehshell.exe\",@WindowsDir&\"\\ehome\")";
                }
                else
                {
                    //Wait for Media Center focus
                    autoitscript[1] = "sleep(1000)";
                    autoitscript[2] = "WinWaitActive(\"Windows Media Center\")";
                    autoitscript[3] = "ProcessClose(\"" + Path.GetFileName(internetExplorerPath) + "\")";
                }                
            }
            else if (prog.Equals("Opera"))
            {
                if (fullScreened == true)
                    autoitscript[0] = "Run(\"" + operaPath + " -fullscreen " + address + "\", \"" + Path.GetDirectoryName(operaPath) + "\", @SW_MAXIMIZE)";
                else
                    autoitscript[0] = "Run(\"" + operaPath + " " + address + "\", \"" + Path.GetDirectoryName(operaPath) + "\", @SW_MAXIMIZE)";
                if (bBackType.Equals("Close  App"))
                {
                    //Wait for spawned process to close
                    autoitscript[1] = "ProcessWaitClose(\"" + Path.GetFileName(operaPath) + "\")";
                    autoitscript[2] = "Run(@WindowsDir&\"\\ehome\\ehshell.exe\",@WindowsDir&\"\\ehome\")";
                }
                else
                {
                    //Wait for Media Center focus
                    autoitscript[1] = "sleep(1000)";
                    autoitscript[2] = "WinWaitActive(\"Windows Media Center\")";
                    autoitscript[3] = "ProcessClose(\"" + Path.GetFileName(operaPath) + "\")";
                }               
            }
            else if (prog.Equals("Kylo"))
            {
                //Add Kylo path for 32 and 64 bit here
                if (fullScreened == true)
                    autoitscript[0] = "Run(\"" + kyloPath + " -fullscreen " + address + "\", \"" + Path.GetDirectoryName(kyloPath) + "\", @SW_MAXIMIZE)";
                else
                    autoitscript[0] = "Run(\"" + kyloPath + " " + address + "\", \"" + Path.GetDirectoryName(kyloPath) + "\", @SW_MAXIMIZE)";
                if (bBackType.Equals("Close  App"))
                {
                    //Wait for spawned process to close
                    autoitscript[1] = "ProcessWaitClose(\"" + Path.GetFileName(kyloPath) + "\")";
                    autoitscript[2] = "Run(@WindowsDir&\"\\ehome\\ehshell.exe\",@WindowsDir&\"\\ehome\")";
                }
                else
                {
                    //Wait for Media Center focus
                    autoitscript[1] = "sleep(1000)";
                    autoitscript[2] = "WinWaitActive(\"Windows Media Center\")";
                    autoitscript[3] = "ProcessClose(\"" + Path.GetFileName(kyloPath) + "\")";
                }
            }
            else if (prog.Equals("Steam"))
            {
                autoitscript[0] = "Run(\"" + steamPath + " -fullscreen " + address + "\", \"" + Path.GetDirectoryName(steamPath) + "\", @SW_MAXIMIZE)";
                if (bBackType.Equals("Close  App"))
                {
                    //Wait for spawned process to close
                    autoitscript[1] = "ProcessWaitClose(\"" + Path.GetFileName(steamPath) + "\")";
                    autoitscript[2] = "Run(@WindowsDir&\"\\ehome\\ehshell.exe\",@WindowsDir&\"\\ehome\")";
                }
                else
                {
                    //Wait for Media Center focus
                    autoitscript[1] = "sleep(1000)";
                    autoitscript[2] = "WinWaitActive(\"Windows Media Center\")";
                    autoitscript[3] = "ProcessClose(\"" + Path.GetFileName(steamPath) + "\")";
                }
            }
            else if (prog.Equals("Program"))
            {
                autoitscript[0] = "Run(\"" + address + "\",\"" + Path.GetDirectoryName(address) + "\"," + "@SW_MAXIMIZE)";
                if(bBackType.Equals("Close  App"))
                {
                    autoitscript[1] = "ProcessWaitClose(\"" + Path.GetFileName(address) + "\")";
                    autoitscript[2] = "Run(@WindowsDir&\"\\ehome\\ehshell.exe\",@WindowsDir&\"\\ehome\")";
                }
                else
                {
                    autoitscript[1] = "sleep(1000)";
                    autoitscript[2] = "WinWaitActive(\"Windows Media Center\")";
                    autoitscript[3] = "ProcessClose(\"" + Path.GetFileName(address) + "\")";
                }
                
            }
            else
            {
                //This should never happen
                MessageBox.Show("You Must Select a Browser or Program");
                Environment.Exit(1);
            }
            try
            {
                System.IO.File.WriteAllLines(name + ".au3", autoitscript);
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                //proc.StartInfo.Arguments = @"/C Aut2exe.exe /in " + name + ".au3 " + "/out " + name + ".exe";
                proc.StartInfo.Arguments = @"/C Aut2exe.exe /in " + name + ".au3 " + "/out " + name + ".exe /nopack";
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
                proc.WaitForExit();
            }
            catch
            {
                MessageBox.Show("Error compiling the exe.");
                //get rid of image and MCL file created earlier
                if (System.IO.File.Exists(imagePath)) { System.IO.File.Delete(imagePath); }
                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl"))
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl");
                if (System.IO.File.Exists(name + ".exe")) { System.IO.File.Delete(name + ".exe"); }
                if (System.IO.File.Exists(name + ".au3")) { System.IO.File.Delete(name + ".au3"); }
                if (System.IO.File.Exists("Aut2exe.exe")) { System.IO.File.Delete("Aut2exe.exe"); }
                if (System.IO.File.Exists("AutoItSC.bin")) { System.IO.File.Delete("AutoItSC.bin"); }
                Environment.Exit(1); 
            }

            //copy the new exe to Relaunch folder to sit along side the image
            try
            {
                System.IO.File.Copy(name + ".exe", Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\" + name + ".exe", true);
            }
            catch 
            {
                MessageBox.Show("Error copying the exe.");
                if (System.IO.File.Exists(imagePath)) { System.IO.File.Delete(imagePath); }
                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl"))
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl");
                if(System.IO.File.Exists(name + ".au3")){System.IO.File.Delete(name+"au3");}
                if (System.IO.File.Exists(name + ".exe")) { System.IO.File.Delete(name + ".exe"); }
                if (System.IO.File.Exists(name + ".au3")) { System.IO.File.Delete(name + ".au3"); }
                if (System.IO.File.Exists("Aut2exe.exe")) { System.IO.File.Delete("Aut2exe.exe"); }
                if (System.IO.File.Exists("AutoItSC.bin")) { System.IO.File.Delete("AutoItSC.bin"); }
                Environment.Exit(1); 
            }
            try
            {
                System.IO.File.Delete(name + ".exe");
                System.IO.File.Delete(name + ".au3");
                System.IO.File.Delete("Aut2exe.exe");
                //System.IO.File.Delete("Aut2exe_x64.exe");     //for later 64 bit support
                System.IO.File.Delete("AutoItSC.bin");
                //System.IO.File.Delete("AutoItSC_x64.bin");    //for later 64 bit support
                //System.IO.File.Delete("upx.exe");             //for compression support, not needed wtih /unpack switch
            }
            catch 
            {
                MessageBox.Show("Error cleaning up.");
                if (System.IO.File.Exists(imagePath)) { System.IO.File.Delete(imagePath); }
                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl"))
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("appdata") + "\\Media Center Programs\\" + name + ".mcl");
                if (System.IO.File.Exists(name + ".au3")) { System.IO.File.Delete(name + "au3"); }
                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\" + name + ".exe"))
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("LocalAppData") + @"\Relaunch\" + name + ".exe");
                if (System.IO.File.Exists(name + ".exe")) { System.IO.File.Delete(name + ".exe"); }
                if (System.IO.File.Exists(name + ".au3")) { System.IO.File.Delete(name + ".au3"); }
                if (System.IO.File.Exists("Aut2exe.exe")) { System.IO.File.Delete("Aut2exe.exe"); }
                if (System.IO.File.Exists("AutoItSC.bin")) { System.IO.File.Delete("AutoItSC.bin"); }
                Environment.Exit(1);
            }
        }

        void createLauncher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            progressBar1.Value = e.ProgressPercentage;
        }

        void create_Launcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Hide();
            progressBar1.Show();
            checkCurrentApps();
        }

        private void addApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addApp.Text.Trim().Equals("Youtube TV"))
            {
                pathBox.Text = "http://www.youtube.com/tv";
                nameBox.Text = "Youtube TV";
                if(typeBox.Text.Equals("Program")){typeBox.SelectedIndex = 0;}
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.youtube;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("YoutubeXL"))
            {
                pathBox.Text = "http://www.youtube.com/XL";
                nameBox.Text = "YoutubeXL";
                if(typeBox.Text.Equals("Program")){typeBox.SelectedIndex = 0;}
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.youtube;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Youtube Leanback"))
            {
                pathBox.Text = "http://www.youtube.com/leanback";
                nameBox.Text = "Youtube Leanback";
                if(typeBox.Text.Equals("Program")){typeBox.SelectedIndex = 0;}
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.youtube;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Pandora"))
            {
                pathBox.Text = "https://tv.pandora.com/?mouseEnabled=true&dPadEnabled=true&vendor=microsoft&model=xbox&type=console&modelYear=2013";
                nameBox.Text = "Pandora";
                if (typeBox.Text.Equals("Program")) { typeBox.SelectedIndex = 0; }
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.pandora;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Clicker.tv"))
            {
                pathBox.Text = "http://www.clicker.tv";
                nameBox.Text = "Clicker.tv";
                if (typeBox.Text.Equals("Program")) { typeBox.SelectedIndex = 0; }
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.clicker;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Hulu Desktop"))
            {
                pathBox.Text = huluPath;
                nameBox.Text = "Hulu";
                typeBox.Text = "Program";
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.hulu;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Google TV Spotlight"))
            {
                pathBox.Text = "http://www.google.com/tv/spotlight-gallery.html";
                nameBox.Text = "Google TV";
                if (typeBox.Text.Equals("Program")) { typeBox.SelectedIndex = 0; }
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.gtv;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Vimeo Couch Mode"))
            {
                pathBox.Text = "http://www.vimeo.com/couchmode";
                nameBox.Text = "Vimeo";
                if (typeBox.Text.Equals("Program")) { typeBox.SelectedIndex = 0; }
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.vimeo;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if (addApp.Text.Trim().Equals("Google Reader Play"))
            {
                pathBox.Text = "http://www.google.com/reader/play/";
                nameBox.Text = "Google Reader Play";
                if (typeBox.Text.Equals("Program")) { typeBox.SelectedIndex = 0; }
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.gread;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else if(addApp.Text.Trim().Equals("Custom"))
            {
                pathBox.Text = "";
                nameBox.Text = "";
                if (typeBox.Text.Equals("Program")) { typeBox.SelectedIndex = 0; }
                imageBox.Text = "";

            }
            else if (addApp.Text.Trim().Equals("Steam"))
            {
                pathBox.Text = steamPath;
                nameBox.Text = "Steam";
                typeBox.Text = "Program";
                previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                previewBox.Image = Relaunch.Properties.Resources.steam;
                imageBox.Text = "Embeded: Change if you want a different image";
            }
            else
            {
                MessageBox.Show("That is not a valid app selection");
            }
        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Remove selection of currentApps
            progressBar1.MarqueeAnimationSpeed = 6;
            deleteWorker.RunWorkerAsync(currentApps.Text.Trim());

        }

        void removeApplication_ProgressChanged(String appToDelete, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            progressBar1.Value = e.ProgressPercentage;
        }

        private void removeApplication_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Hide();
            progressBar1.Show();
            checkCurrentApps();
        }

        private void removeApplication(object sender, DoWorkEventArgs e)
        {
            String appToDelete = e.Argument as String;
            string[] fileNames = Directory.GetFiles(Environment.GetEnvironmentVariable("AppData") + @"\Media Center Programs");
            for (int i = 0; i < fileNames.Length; i++)
            {
                String appNameFromXml = null;
                try
                {
                    StreamReader stream = new StreamReader(fileNames[i]);
                    XmlDocument xml = new XmlDocument();
                    xml.Normalize();
                    xml.Load(stream);
                    stream.Close();
                    appNameFromXml = xml.SelectSingleNode("/application/@Name").Value;
                    if (appNameFromXml.Equals(appToDelete))
                    {
                        System.IO.File.Delete(fileNames[i]);
                        System.IO.File.Delete(xml.SelectSingleNode("/application/@startimage").Value);
                        System.IO.File.Delete(xml.SelectSingleNode("/application/@run").Value);
                    }
                }
                catch { MessageBox.Show("Trouble validating MCL and removing tile: "+appNameFromXml); Environment.Exit(1); }
            }
        }

        private void currentApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(Environment.GetEnvironmentVariable("AppData") + @"\Media Center Programs");
            for (int i = 0; i < fileNames.Length; i++)
            {
                try
                {
                    StreamReader stream = new StreamReader(fileNames[i]);
                    XmlDocument xml = new XmlDocument();
                    xml.Normalize();
                    xml.Load(stream);
                    stream.Close();
                    String appNameFromXml = xml.SelectSingleNode("/application/@Name").Value;
                    if (currentApps.Text.Trim().Equals(appNameFromXml))
                    {
                        nameBox.Text = xml.SelectSingleNode("application/@Name").Value;
                        imageBox.Text = xml.SelectSingleNode("application/@startimage").Value;
                        previewBox.ImageLocation = xml.SelectSingleNode("application/@startimage").Value;
                        pathBox.Text = "";
                    }
                }
                catch { MessageBox.Show("Trouble validating MCL"); Environment.Exit(1); }                    
            }
        }
    }
}
