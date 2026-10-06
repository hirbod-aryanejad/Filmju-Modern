using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Filmju.utiles;
using Microsoft.VisualBasic.PowerPacks;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class active_user : Form
{
	private int time_resend;

	private AppConfig ac;

	private IContainer components;

	private TextBox textBox_code;

	private Button btn_submit;

	private Label label_text;

	private Button btn_close;

	private ShapeContainer shapeContainer1;

	private RectangleShape rectangleShape1;

	private Timer timer1;

	private Label label_timer;

	private Button btn_resend;

	public active_user()
	{
		InitializeComponent();
	}

	private void active_user_Load(object sender, EventArgs e)
	{
		if (Global.user_name_config == null)
		{
			Global.user_name_config = "";
		}
		ac = new AppConfig();
		time_resend = 130;
		label_text.Text = "کد فعالسازی ارسال شده به شماره موبایل " + Global.user_name_config + " را در کادر زیر وارد نمایید";
		if (!Global.user_name_config.Equals(""))
		{
			SendSms();
		}
	}

	private void btn_submit_Click(object sender, EventArgs e)
	{
		string code = textBox_code.Text.ToString();
		if (code == null)
		{
			code = "";
		}
		if (code.Length > 0)
		{
			SetEnCode(code);
		}
		else
		{
			MessageBox.Show("کد فعالسازی را وارد کنید");
		}
	}

	private void SendSms()
	{
		btn_resend.Visible = false;
		timer1.Start();
		string url = Global.CurrentURL + ac.FontEditor + Global.keyURL + ac.action_equal + "resend_encode";
		classes myclass = new classes();
		string Args = "";
		string Data = myclass.PostData(url, Args);
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string state = mJsonObject.GetValue("state").ToString();
		string msg = mJsonObject.GetValue("msg").ToString();
		if (state.Equals("F"))
		{
			MessageBox.Show(msg);
		}
	}

	private void SetEnCode(string code)
	{
		string url = Global.CurrentURL + ac.FontEditor + Global.keyURL + ac.action_equal + "enable";
		classes myclass = new classes();
		string Args = myclass.CreateArgs("encode", code);
		string Data = myclass.PostData(url, Args);
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string login2 = mJsonObject.GetValue("login").ToString();
		string msg = mJsonObject.GetValue("msg").ToString();
		Global.LoginState = login2;
		MessageBox.Show(msg);
		if (login2.Equals("T"))
		{
			Global.LoginState = "T";
			Global.token_config = mJsonObject.GetValue("token").ToString();
			Global.user_name_config = mJsonObject.GetValue("user_name").ToString();
			Global.sal_Config = mJsonObject.GetValue("tosal").ToString();
			Global.StateAcc_Config = mJsonObject.GetValue("stete_account").ToString();
			Global.name_Config = mJsonObject.GetValue("name").ToString();
			string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Rubiuser.txt";
			using (StreamWriter sw = new StreamWriter(FilePath))
			{
				sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|" + Global.user_name_config);
				sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|" + Global.token_config);
			}
			DialogResult = DialogResult.OK;
		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		time_resend--;
		if (time_resend > 0)
		{
			label_timer.Text = time_resend + " ثانیه تا دریافت مجدد کد فعالسازی ";
			return;
		}
		timer1.Stop();
		btn_resend.Visible = true;
		label_timer.Text = "0";
	}

	private void btn_resend_Click(object sender, EventArgs e)
	{
		time_resend = 130;
		SendSms();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.active_user));
		this.textBox_code = new System.Windows.Forms.TextBox();
		this.btn_submit = new System.Windows.Forms.Button();
		this.label_text = new System.Windows.Forms.Label();
		this.btn_close = new System.Windows.Forms.Button();
		this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
		this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.label_timer = new System.Windows.Forms.Label();
		this.btn_resend = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox_code.BackColor = System.Drawing.Color.Green;
		this.textBox_code.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_code.ForeColor = System.Drawing.Color.White;
		this.textBox_code.Location = new System.Drawing.Point(98, 116);
		this.textBox_code.Name = "textBox_code";
		this.textBox_code.Size = new System.Drawing.Size(174, 27);
		this.textBox_code.TabIndex = 0;
		this.btn_submit.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_submit.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_submit.ForeColor = System.Drawing.Color.White;
		this.btn_submit.Location = new System.Drawing.Point(132, 160);
		this.btn_submit.Name = "btn_submit";
		this.btn_submit.Size = new System.Drawing.Size(100, 32);
		this.btn_submit.TabIndex = 1;
		this.btn_submit.Text = "تایید";
		this.btn_submit.UseVisualStyleBackColor = false;
		this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
		this.label_text.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_text.ForeColor = System.Drawing.Color.White;
		this.label_text.Location = new System.Drawing.Point(37, 63);
		this.label_text.Name = "label_text";
		this.label_text.Size = new System.Drawing.Size(321, 50);
		this.label_text.TabIndex = 2;
		this.label_text.Text = "روبی باکس";
		this.label_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 12);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 6;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
		this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
		this.shapeContainer1.Name = "shapeContainer1";
		this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[1] { this.rectangleShape1 });
		this.shapeContainer1.Size = new System.Drawing.Size(389, 282);
		this.shapeContainer1.TabIndex = 7;
		this.shapeContainer1.TabStop = false;
		this.rectangleShape1.BackColor = System.Drawing.Color.White;
		this.rectangleShape1.BorderColor = System.Drawing.Color.White;
		this.rectangleShape1.BorderWidth = 3;
		this.rectangleShape1.Location = new System.Drawing.Point(1, 0);
		this.rectangleShape1.Name = "rectangleShape1";
		this.rectangleShape1.Size = new System.Drawing.Size(385, 279);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		this.label_timer.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_timer.ForeColor = System.Drawing.Color.White;
		this.label_timer.Location = new System.Drawing.Point(37, 245);
		this.label_timer.Name = "label_timer";
		this.label_timer.Size = new System.Drawing.Size(281, 23);
		this.label_timer.TabIndex = 8;
		this.label_timer.Text = "00:00";
		this.label_timer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_resend.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_resend.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_resend.ForeColor = System.Drawing.Color.White;
		this.btn_resend.Location = new System.Drawing.Point(74, 210);
		this.btn_resend.Name = "btn_resend";
		this.btn_resend.Size = new System.Drawing.Size(209, 32);
		this.btn_resend.TabIndex = 9;
		this.btn_resend.Text = "دریافت مجدد کد فعالسازی";
		this.btn_resend.UseVisualStyleBackColor = false;
		this.btn_resend.Visible = false;
		this.btn_resend.Click += new System.EventHandler(this.btn_resend_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		base.ClientSize = new System.Drawing.Size(389, 282);
		base.Controls.Add(this.btn_resend);
		base.Controls.Add(this.label_timer);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.label_text);
		base.Controls.Add(this.btn_submit);
		base.Controls.Add(this.textBox_code);
		base.Controls.Add(this.shapeContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "active_user";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "active_user";
		base.TopMost = true;
		base.Load += new System.EventHandler(this.active_user_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
