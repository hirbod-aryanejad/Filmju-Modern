using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Filmju.Activitys;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju;

public class Splash : Form
{
	private string FilePath;

	private string[] Paths;

	private AppConfig ac;

	private string User_Name;

	private string Token;

	private string Ldkso;

	private string WEpdid = "win";

	private string SFdoidsop = ".";

	private string osCdsofsdf = "txt";

	private int time_loading;

	private IContainer components;

	private Timer timer1;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label label5;

	public Splash()
	{
		InitializeComponent();
	}

	private void Splash_Load(object sender, EventArgs e)
	{
		Global.CheckLoginAccount = "F";
		User_Name = "";
		Token = "";
		Ldkso = "";
		try
		{
			FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Rubiuser.txt";
			if (!File.Exists(FilePath))
			{
				FileStream outFile = File.Create(FilePath);
				outFile.Close();
			}
			else
			{
				SetInfos();
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Error : 01");
		}
		SetColor();
		string state = SetLoading();
		Global.DFoieriwpdpfsd = "directlinktest.";
		DownloadUpdate();
		ChekingFormSize();
		ChekingFormSize();
		string Fodisdpc = "key";
		Global.ULPdisjskfdlkf = Global.Hepdskcd + state + Global.ULPdisjskfdlkf;
		string Fdsoif = Fodisdpc + "=a7ed9scqfdcoixoec2yi4";
		PlayerId(Fdsoif);
		SetImage();
		ac = new AppConfig();
		Ldkso = ac.FontEditor + Global.Psdiuisdufscds + ac.key5548112 + "login";
		timer1.Enabled = true;
	}

	public bool SetInfos()
	{
		try
		{
			if (File.Exists(FilePath))
			{
				using StreamReader sr = new StreamReader(FilePath);
				string temp = sr.ReadToEnd();
				temp = temp.Replace('\r', ' ');
				if (!string.IsNullOrEmpty(temp))
				{
					Paths = temp.Split('\n');
					Paths = CleanArray(Paths);
					if (Paths.Length == 2)
					{
						User_Name = Paths[0].Split('|')[1];
						Token = Paths[1].Split('|')[1];
						return true;
					}
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Error : 02");
		}
		return false;
	}

	private void SetDataUser()
	{
		string OFSFsudyiusud = Global.ULPdisjskfdlkf + Ldkso;
		Global.user_name_config = User_Name;
		Global.token_config = Token;
		classes myclass = new classes();
		string Data = myclass.PostData(OFSFsudyiusud, "");
		if (Data == null)
		{
			Data = "";
		}
		if (Data.Equals("Error"))
		{
			CheckDevice();
			return;
		}
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string login2 = mJsonObject.GetValue("login").ToString();
		string body_pic = mJsonObject.GetValue("auth").ToString();
		Global.Body_f = body_pic;
		Global.LoginState = login2;
		if (login2 == "T")
		{
			Global.CheckLoginAccount = "F";
			Global.StateAcc_Config = mJsonObject.GetValue("stete_account").ToString();
			Global.name_Config = mJsonObject.GetValue("name").ToString();
			Global.sal_Config = mJsonObject.GetValue("tosal").ToString();
			Global.token_config = mJsonObject.GetValue("token").ToString();
			Global.state_user_Config = mJsonObject.GetValue("state_user").ToString();
			Global.user_name_config = mJsonObject.GetValue("user_name").ToString();
			Global.Langueg_Title_Movies = mJsonObject.GetValue("langueg_title_movies").ToString();
			using StreamWriter sw = new StreamWriter(FilePath);
			sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|" + Global.user_name_config);
			sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|" + Global.token_config);
		}
		else
		{
			Global.user_name_config = "";
			Global.token_config = "";
		}
		ShowFF();
	}

	private void ShowFF()
	{
		Hide();
		main_activity main_activity2 = new main_activity();
		DialogResult aa = main_activity2.ShowDialog();
		if (aa == DialogResult.OK)
		{
			Close();
		}
	}

	private void DownloadUpdate()
	{
		string Fdoidspigp = "download";
		string SDCdsiuioewur = "CheckUpdate";
		string Dssscodsifio = "app";
		string wrrettreee = "files";
		_ = SDCdsiuioewur + Dssscodsifio + "pl";
		string oidcsp = Fdoidspigp + wrrettreee;
		Global.ifodsicodisfs = oidcsp;
	}

	public static string[] CleanArray(string[] s)
	{
		List<string> list = new List<string>();
		try
		{
			foreach (string item in s)
			{
				if (!string.IsNullOrEmpty(item))
				{
					list.Add(item);
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Error : 03");
		}
		return list.ToArray();
	}

	private void CheckDevice()
	{
		string state = SetLoading();
		string DSfdsdiocds = Global.Hepdskcd + state + "raw" + SFdoidsop;
		string pweoDsaud = DSfdsdiocds + "gi" + ac.Fpddddddsi + "ent" + SFdoidsop;
		string WEdiaspof = pweoDsaud + ac.Oeuiodsiaodicsdf + ac.Spcszipds + "irubi" + ac.Psosiscix;
		string Ascdifudf = WEdiaspof + ac.Spcszipds + ac.mliskow + "-" + WEpdid + SFdoidsop + osCdsofsdf;
		classes myclass = new classes();
		string Data = myclass.GetPage(Ascdifudf);
		if (Data == null)
		{
			Data = "";
		}
		if (!Data.Equals("Error") && !Data.Equals(""))
		{
			Data = Data.Replace("\n", "");
			Data = Data.Replace("\r", "");
			Global.ULPdisjskfdlkf = Data;
			SetDataUser();
		}
		else
		{
			MessageBox.Show("در اتصال به سرور مشکل پیش آمده است لطفا جهت کسب اطلاعات بیشتر با پشتیبانی تلگرام در ارتباط باشید");
		}
	}

	private void ChekingFormSize()
	{
		string Resolation = "r";
		string Width_size = "1024";
		string Height_size = "720";
		string iosdc = "i";
		_ = Width_size + "x" + Height_size;
		string FDSfdosfiosd = Global.DFoieriwpdpfsd + iosdc + Resolation;
		Global.ULPdisjskfdlkf = Global.ifodsicodisfs + FDSfdosfiosd;
	}

	private void SetColor()
	{
		string color_id0 = "y";
		string color_id1 = "h";
		string color_id2 = "o";
		string color_id3 = "a";
		string color_id4 = "t";
		string color_id6 = "z";
		string color_id7 = "p";
		string color_id8 = "j";
		string color_id9 = "s";
		_ = color_id0 + color_id2 + color_id4 + color_id8 + color_id9;
		Global.Hepdskcd = color_id1 + color_id4 + color_id4 + color_id7;
		_ = color_id1 + color_id6 + color_id9 + color_id1 + color_id3;
	}

	private string SetLoading()
	{
		return "://";
	}

	private void SetImage()
	{
		string Windowns_local = "locall";
		string Windowns_path = "wiinn";
		string Windowns_drive = "a";
		string Windowns_drive2 = "c";
		string Windowns_drive3 = "p";
		string Windowns_drive4 = "d";
		_ = Windowns_drive4 + Global.SLfhjdsucdsu;
		Global.SLfhjdsucdsu = Windowns_path + Windowns_drive + Windowns_drive3;
		_ = Windowns_path + Windowns_drive2 + Windowns_local;
	}

	private void PlayerId(string id)
	{
		Global.Psdiuisdufscds = id + "c0xb6nuqi4ssirp&";
	}

	private void timer1_Tick_1(object sender, EventArgs e)
	{
		time_loading++;
		if (time_loading == 4)
		{
			timer1.Enabled = false;
			SetDataUser();
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

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Splash));
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(196, 188);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(150, 25);
		this.label1.TabIndex = 1;
		this.label1.Text = "Filmju - فیلمجو";
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label2.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(234, 444);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(64, 19);
		this.label2.TabIndex = 2;
		this.label2.Text = "نسخه 1";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label3.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(103, 284);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(315, 69);
		this.label3.TabIndex = 3;
		this.label3.Text = "در صورت وجود مشکل به آیدی تلگرامی\r\nFilmju_sup\r\nپیام دهید";
		this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label4.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Yellow;
		this.label4.Location = new System.Drawing.Point(103, 364);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(314, 69);
		this.label4.TabIndex = 4;
		this.label4.Text = "اطلاعیه ها را در کانال تلگرامی به آیدی\r\nFilmju\r\nدنبال کنید";
		this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label5.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Yellow;
		this.label5.Location = new System.Drawing.Point(53, 237);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(420, 25);
		this.label5.TabIndex = 5;
		this.label5.Text = "هنگام ورود حتما فیلترشکن خود را خاموش کنید";
		this.pictureBox1.Image = Filmju.Properties.Resources.logo300;
		this.pictureBox1.Location = new System.Drawing.Point(196, 26);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(150, 150);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DarkSlateGray;
		base.ClientSize = new System.Drawing.Size(548, 472);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Splash";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Form1";
		base.Load += new System.EventHandler(this.Splash_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
