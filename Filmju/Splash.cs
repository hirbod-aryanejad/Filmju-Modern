using Filmju.Activitys;
using Filmju.utiles;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Filmju;

public class Splash : Form
{
    string User_Name;
    string Token;
    string FilePath;


    int time_loading;

    IContainer components;

    Timer timer1;
    static int TickCount = 4;

    PictureBox pictureBox1;

    Label label1;
    Label label2;
    Label label3;
    Label label4;
    Label label5;


    public Splash()
    {
        InitializeComponent();
    }

    void InitializeComponent()
    {
        // 1. Create the WinForms component container
        components = new Container();

        // 2. Create the resource manager
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Filmju.Splash));

        // 3. Create the UI controls
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        pictureBox1 = new PictureBox();
        ((ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();

        // 4. Create & configure the timer
        timer1 = new Timer(components);
        timer1.Interval = 1000;

        // 5. IMPORTANT:Tell the timer which function to execute every tick
        timer1.Tick += new EventHandler(timer1_Tick_1);

        // 7. More UI configuration
        #region UI
        label1.AutoSize = true;
        label1.BackColor = System.Drawing.Color.DarkSlateGray;
        label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        label1.ForeColor = System.Drawing.Color.White;
        label1.Location = new System.Drawing.Point(196, 188);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(150, 25);
        label1.TabIndex = 1;
        label1.Text = "Filmju - فیلمجو";
        label2.AutoSize = true;
        label2.BackColor = System.Drawing.Color.DarkSlateGray;
        label2.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        label2.ForeColor = System.Drawing.Color.White;
        label2.Location = new System.Drawing.Point(234, 444);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(64, 19);
        label2.TabIndex = 2;
        label2.Text = "نسخه 1";
        label3.AutoSize = true;
        label3.BackColor = System.Drawing.Color.DarkSlateGray;
        label3.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        label3.ForeColor = System.Drawing.Color.White;
        label3.Location = new System.Drawing.Point(103, 284);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(315, 69);
        label3.TabIndex = 3;
        label3.Text = "در صورت وجود مشکل به آیدی تلگرامی\r\nFilmju_sup\r\nپیام دهید";
        label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        label4.AutoSize = true;
        label4.BackColor = System.Drawing.Color.DarkSlateGray;
        label4.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        label4.ForeColor = System.Drawing.Color.Yellow;
        label4.Location = new System.Drawing.Point(103, 364);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(314, 69);
        label4.TabIndex = 4;
        label4.Text = "اطلاعیه ها را در کانال تلگرامی به آیدی\r\nFilmju\r\nدنبال کنید";
        label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        label5.AutoSize = true;
        label5.BackColor = System.Drawing.Color.DarkSlateGray;
        label5.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        label5.ForeColor = System.Drawing.Color.Yellow;
        label5.Location = new System.Drawing.Point(53, 237);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(420, 25);
        label5.TabIndex = 5;
        label5.Text = "هنگام ورود حتما فیلترشکن خود را خاموش کنید";
        pictureBox1.Image = Filmju.Properties.Resources.logo300;
        pictureBox1.Location = new System.Drawing.Point(196, 26);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(150, 150);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSlateGray;
        ClientSize = new System.Drawing.Size(548, 472);
        Controls.Add(this.label5);
        Controls.Add(this.label4);
        Controls.Add(this.label3);
        Controls.Add(this.label2);
        Controls.Add(this.label1);
        Controls.Add(this.pictureBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        Name = "Splash";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        #endregion

        // 8. IMPORTANT: Tell the form which function to execute when it loads
        Load += new EventHandler(SplashLoad);

        // 7. Finish UI initialization
        ((ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    void SplashLoad(object sender, EventArgs e)
    {
        Global.CheckLoginAccount = "F";
        User_Name = "";
        Token = "";

        Global.CurrentURL = Global.DefaultURL;

        LoadUserInfo();

        timer1.Enabled = true;
    }

    void LoadUserInfo()
    {
        try
        {
            FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Rubiuser.txt";

            if (File.Exists(FilePath))
            {
                SetUserInfo();
                return;
            }

            FileStream outFile = File.Create(FilePath);
            outFile.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("Error : 01");
        }
    }

    void SetUserInfo()
    {
        try
        {
            using StreamReader sr = new StreamReader(FilePath);
            string temp = sr.ReadToEnd();
            temp = temp.Replace('\r', ' ');

            if (string.IsNullOrEmpty(temp))
                return;

            string[] paths = temp.Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            if (paths.Length == 2)
            {
                User_Name = paths[0].Split('|')[1];
                Token = paths[1].Split('|')[1];
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Error : 02");
        }
    }

    void timer1_Tick_1(object sender, EventArgs e)
    {
        time_loading++;

        if (time_loading == TickCount)
        {
            timer1.Enabled = false;
            SetUserData();
        }
    }

    void SetUserData()
    {
        string url = Global.CurrentURL + Global.loginURL;

        Global.user_name_config = User_Name;
        Global.token_config = Token;

        classes myclass = new classes();
        string data = myclass.PostData(url, "");

        if (string.IsNullOrEmpty(data) || data == "Error")
        {
            UpdateServerAddress();
            return;
        }

        UpdateUserData(data);

        ShowMainWindow();
    }

    void UpdateUserData(string data)
    {
        JArray response = JArray.Parse(data);
        JObject userData = JObject.Parse(response[0].ToString());

        string loginState = userData.GetValue("login").ToString();
        string auth = userData.GetValue("auth").ToString();

        Global.Body_f = auth;
        Global.LoginState = loginState;

        if (loginState != "T")
        {
            Global.user_name_config = "";
            Global.token_config = "";
            return;
        }

        Global.CheckLoginAccount = "F";
        Global.StateAcc_Config = userData.GetValue("stete_account").ToString();
        Global.name_Config = userData.GetValue("name").ToString();
        Global.sal_Config = userData.GetValue("tosal").ToString();
        Global.token_config = userData.GetValue("token").ToString();
        Global.state_user_Config = userData.GetValue("state_user").ToString();
        Global.user_name_config = userData.GetValue("user_name").ToString();
        Global.Langueg_Title_Movies = userData.GetValue("langueg_title_movies").ToString();

        using StreamWriter sw = new StreamWriter(FilePath);
        sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|" + Global.user_name_config);
        sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|" + Global.token_config);
    }


    void UpdateServerAddress()
    {

        classes myclass = new classes();
        string data = myclass.GetPage(Global.AlternateURL);

        if (string.IsNullOrEmpty(data) || data == "Error")
        {
            MessageBox.Show("در اتصال به سرور مشکل پیش آمده است لطفا جهت کسب اطلاعات بیشتر با پشتیبانی تلگرام در ارتباط باشید");
            return;
        }

        data = data.Trim();

        Global.CurrentURL = data.Trim();

        SetUserData();
    }

    void ShowMainWindow()
    {
        Hide();

        main_activity main_activity2 = new main_activity();
        DialogResult aa = main_activity2.ShowDialog();

        if (aa == DialogResult.OK)
        {
            Close();
        }
    }


    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }
}