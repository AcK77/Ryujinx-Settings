using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Ryujinx_Settings
{
    public partial class frmConfig : Form
    {
        private string OpenALPath;
        IniParser IniFile;
        public frmConfig()
        {
            InitializeComponent();
            OpenALPath = Path.Combine(Application.StartupPath, "OpenAL11CoreSDK.zip");
        }

        private void LoadConf()
        {
            checkBox8.Checked = Convert.ToBoolean(IniFile.Value("Enable_Memory_Checks"));

            checkBox1.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Info"));
            checkBox2.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Trace"));
            checkBox3.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Debug"));
            checkBox4.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Warn"));
            checkBox5.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Error"));
            checkBox6.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Fatal"));
            checkBox7.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_LogFile"));
            checkBox9.Checked = Convert.ToBoolean(IniFile.Value("Logging_Enable_Ipc"));

            comboBox1.DataSource = Enum.GetValues(typeof(Key));
            comboBox2.DataSource = Enum.GetValues(typeof(Key));
            comboBox3.DataSource = Enum.GetValues(typeof(Key));
            comboBox4.DataSource = Enum.GetValues(typeof(Key));
            comboBox5.DataSource = Enum.GetValues(typeof(Key));
            comboBox6.DataSource = Enum.GetValues(typeof(Key));
            comboBox7.DataSource = Enum.GetValues(typeof(Key));
            comboBox8.DataSource = Enum.GetValues(typeof(Key));
            comboBox9.DataSource = Enum.GetValues(typeof(Key));
            comboBox10.DataSource = Enum.GetValues(typeof(Key));
            comboBox11.DataSource = Enum.GetValues(typeof(Key));
            comboBox12.DataSource = Enum.GetValues(typeof(Key));
            comboBox13.DataSource = Enum.GetValues(typeof(Key));
            comboBox14.DataSource = Enum.GetValues(typeof(Key));
            comboBox15.DataSource = Enum.GetValues(typeof(Key));
            comboBox16.DataSource = Enum.GetValues(typeof(Key));
            comboBox17.DataSource = Enum.GetValues(typeof(Key));
            comboBox18.DataSource = Enum.GetValues(typeof(Key));
            comboBox19.DataSource = Enum.GetValues(typeof(Key));
            comboBox20.DataSource = Enum.GetValues(typeof(Key));
            comboBox21.DataSource = Enum.GetValues(typeof(Key));
            comboBox22.DataSource = Enum.GetValues(typeof(Key));
            comboBox23.DataSource = Enum.GetValues(typeof(Key));
            comboBox24.DataSource = Enum.GetValues(typeof(Key));

            comboBox1.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Stick_Up"));
            comboBox2.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Stick_Down"));
            comboBox3.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Stick_Left"));
            comboBox4.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Stick_Right"));
            comboBox5.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Stick_Button"));
            comboBox6.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_DPad_Up"));
            comboBox7.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_DPad_Down"));
            comboBox8.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_DPad_Left"));
            comboBox9.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_DPad_Right"));
            comboBox10.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Button_Minus"));
            comboBox11.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Button_L"));
            comboBox12.SelectedIndex = int.Parse(IniFile.Value("Controls_Left_FakeJoycon_Button_ZL"));

            comboBox13.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Stick_Up"));
            comboBox14.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Stick_Down"));
            comboBox15.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Stick_Left"));
            comboBox16.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Stick_Right"));
            comboBox17.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Stick_Button"));
            comboBox18.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_A"));
            comboBox19.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_B"));
            comboBox20.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_X"));
            comboBox21.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_Y"));
            comboBox22.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_Plus"));
            comboBox23.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_R"));
            comboBox24.SelectedIndex = int.Parse(IniFile.Value("Controls_Right_FakeJoycon_Button_ZR"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string FilePath = Path.Combine(Application.StartupPath, "Ryujinx.conf");
            if(File.Exists(FilePath))
            {
                IniFile = new IniParser(FilePath);
                LoadConf();
            }
            else MessageBox.Show("Put this program inside Ryujinx folder!" + Environment.NewLine + "Be sure Ryujinx.conf exist!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Ini = new Dictionary<string, string>();

            Ini.Add("Enable_Memory_Checks", checkBox8.Checked.ToString());

            Ini.Add("Logging_Enable_Info", checkBox1.Checked.ToString());
            Ini.Add("Logging_Enable_Trace", checkBox2.Checked.ToString());
            Ini.Add("Logging_Enable_Debug", checkBox3.Checked.ToString());
            Ini.Add("Logging_Enable_Warn", checkBox4.Checked.ToString());
            Ini.Add("Logging_Enable_Error", checkBox5.Checked.ToString());
            Ini.Add("Logging_Enable_Fatal", checkBox6.Checked.ToString());
            Ini.Add("Logging_Enable_LogFile", checkBox7.Checked.ToString());

            Ini.Add("Logging_Enable_Ipc", checkBox9.Checked.ToString());

            Ini.Add("Controls_Left_FakeJoycon_Stick_Up", comboBox1.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Stick_Down", comboBox2.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Stick_Left", comboBox3.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Stick_Right", comboBox4.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Stick_Button", comboBox5.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_DPad_Up", comboBox6.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_DPad_Down", comboBox7.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_DPad_Left", comboBox8.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_DPad_Right", comboBox9.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Button_Minus", comboBox10.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Button_L", comboBox11.SelectedIndex.ToString());
            Ini.Add("Controls_Left_FakeJoycon_Button_ZL", comboBox12.SelectedIndex.ToString());

            Ini.Add("Controls_Right_FakeJoycon_Stick_Up", comboBox13.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Stick_Down", comboBox14.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Stick_Left", comboBox15.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Stick_Right", comboBox16.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Stick_Button", comboBox17.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_A", comboBox18.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_B", comboBox19.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_X", comboBox20.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_Y", comboBox21.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_Plus", comboBox22.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_R", comboBox23.SelectedIndex.ToString());
            Ini.Add("Controls_Right_FakeJoycon_Button_ZR", comboBox24.SelectedIndex.ToString());

            IniFile.WriteFile(Path.Combine(Application.StartupPath, "Ryujinx.conf"), Ini);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                wc.DownloadFileAsync(new System.Uri("https://openal.org/downloads/OpenAL11CoreSDK.zip"), OpenALPath);
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string Message = "Download of OpenAL is completed!" + Environment.NewLine + "Do you want run installation of OpenAL?";
            if (MessageBox.Show(Message, "Download completed!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ZipFile.ExtractToDirectory(OpenALPath, Application.StartupPath);
                Process.Start(Path.Combine(Application.StartupPath, "OpenAL11CoreSDK.exe"));
            }
        }

        private void frmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(OpenALPath)) File.Delete(OpenALPath);
        }
    }
}
