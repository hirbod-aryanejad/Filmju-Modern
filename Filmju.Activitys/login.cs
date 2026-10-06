using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class login : Form
{
	private AppConfig ac;

	private int ans_capcha;

	private IContainer components;

	private Button btn_login;

	private TextBox textBox_mobile;

	private TextBox textBox_pass;

	private Label label1;

	private Label label2;

	private Button btn_close;

	private Label label3;

	private Button btn_register;

	private Button btn_forget_pass;

	private Button btn_support;

	private Label label5;

	private Label label_capcha;

	private TextBox textBox_capch;

	public login()
	{
		InitializeComponent();
	}

	private void login_Load(object sender, EventArgs e)
	{
		ac = new AppConfig();
		Random rnd = new Random();
		int num_1 = rnd.Next(1, 10);
		int num_2 = rnd.Next(1, 10);
		ans_capcha = num_1 + num_2;
		label_capcha.Text = num_1 + " + " + num_2 + " = ";
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		try
		{
			DialogResult = DialogResult.OK;
			Close();
		}
		catch (Exception)
		{
			Close();
		}
	}

	private void btn_register_Click(object sender, EventArgs e)
	{
		register frm_register = new register();
		DialogResult res = frm_register.ShowDialog();
		if (res == DialogResult.OK)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void btn_login_Click(object sender, EventArgs e)
	{
		string mobile = textBox_mobile.Text.ToString();
		string pass = textBox_pass.Text.ToString();
		string capcha = textBox_capch.Text.ToString();
		if (mobile == null)
		{
			mobile = "";
		}
		if (pass == null)
		{
			pass = "";
		}
		if (capcha == null)
		{
			capcha = "";
		}
		if (capcha.Equals(""))
		{
			capcha = "0";
		}
		int capcha_ans = int.Parse(capcha);
		if (mobile.Length == 11 && pass.Length > 0 && capcha_ans == ans_capcha)
		{
			PostData(mobile, pass);
		}
		else if (mobile.Length != 11)
		{
			MessageBox.Show("شماره موبایل وارد شده اشتباه است");
		}
		else if (mobile.Length == 0)
		{
			MessageBox.Show("شماره موبایل نمی تواند خالی باشد");
		}
		else if (pass.Length == 0)
		{
			MessageBox.Show("رمز ورود نمی تواند خالی باشد");
		}
		else if (capcha_ans != ans_capcha)
		{
			MessageBox.Show("پاسخ سوال امنیتی اشتباه می باشد");
		}
	}

	private void PostData(string user_name, string pass)
	{
		Global.user_name_config = user_name;
		string url = Global.CurrentURL + ac.FontEditor + Global.keyURL + ac.action_equal + "login";
		classes myclass = new classes();
		string Args2 = myclass.CreateArgs("pass", pass);
		string Args3 = Args2;
		string Data = myclass.PostData(url, Args3);
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string login2 = mJsonObject.GetValue("login").ToString();
		string msg = mJsonObject.GetValue("msg").ToString();
		Global.LoginState = login2;
		switch (login2)
		{
		case "T":
		{
			MessageBox.Show("با موفقیت وارد شدید");
			Global.LoginState = "T";
			Global.CheckLoginAccount = "T";
			Global.StateAcc_Config = mJsonObject.GetValue("stete_account").ToString();
			Global.name_Config = mJsonObject.GetValue("name").ToString();
			Global.sal_Config = mJsonObject.GetValue("tosal").ToString();
			Global.token_config = mJsonObject.GetValue("token").ToString();
			Global.state_user_Config = mJsonObject.GetValue("state_user").ToString();
			Global.user_name_config = mJsonObject.GetValue("user_name").ToString();
			Global.Langueg_Title_Movies = mJsonObject.GetValue("langueg_title_movies").ToString();
			string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Rubiuser.txt";
			using (StreamWriter sw = new StreamWriter(FilePath))
			{
				sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|" + Global.user_name_config);
				sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|" + Global.token_config);
			}
			DialogResult = DialogResult.OK;
			Close();
			break;
		}
		case "F":
			MessageBox.Show(msg);
			Global.user_name_config = "";
			break;
		case "E":
		{
			Global.user_name_config = mJsonObject.GetValue("user_name").ToString();
			string msg2 = "حساب کاربری شما نیاز به فعالسازی دارد. عملیات فعالسازی را شروع میکنید؟";
			DialogResult dialogResult = MessageBox.Show(msg2, "فعالسازی", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				active_user active_user2 = new active_user();
				DialogResult res = active_user2.ShowDialog();
				if (res == DialogResult.OK && Global.LoginState.Equals("T"))
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			else
			{
				_ = 7;
			}
			break;
		}
		}
	}

	private void textBox_mobile_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
	}

	private void btn_forget_pass_Click(object sender, EventArgs e)
	{
		forget_pass forget_pass2 = new forget_pass();
		forget_pass2.Show();
	}

	private void btn_support_Click(object sender, EventArgs e)
	{
		MessageBox.Show("در صورتی که در ورود به حساب کاربری یا ثبت نام مشکل دارید به آیدی تلگرامی که در صفحه ویترین قید شده است پیام دهید");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.login));
		this.btn_login = new System.Windows.Forms.Button();
		this.textBox_mobile = new System.Windows.Forms.TextBox();
		this.textBox_pass = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.btn_register = new System.Windows.Forms.Button();
		this.btn_forget_pass = new System.Windows.Forms.Button();
		this.btn_support = new System.Windows.Forms.Button();
		this.btn_close = new System.Windows.Forms.Button();
		this.label5 = new System.Windows.Forms.Label();
		this.label_capcha = new System.Windows.Forms.Label();
		this.textBox_capch = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.btn_login.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_login.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_login.ForeColor = System.Drawing.Color.White;
		this.btn_login.Location = new System.Drawing.Point(150, 321);
		this.btn_login.Name = "btn_login";
		this.btn_login.Size = new System.Drawing.Size(111, 38);
		this.btn_login.TabIndex = 4;
		this.btn_login.Text = "ورود";
		this.btn_login.UseVisualStyleBackColor = false;
		this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
		this.textBox_mobile.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_mobile.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_mobile.ForeColor = System.Drawing.Color.White;
		this.textBox_mobile.Location = new System.Drawing.Point(121, 114);
		this.textBox_mobile.Name = "textBox_mobile";
		this.textBox_mobile.Size = new System.Drawing.Size(185, 27);
		this.textBox_mobile.TabIndex = 1;
		this.textBox_mobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_mobile_KeyPress);
		this.textBox_pass.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_pass.Font = new System.Drawing.Font("Tahoma", 12f);
		this.textBox_pass.ForeColor = System.Drawing.Color.White;
		this.textBox_pass.Location = new System.Drawing.Point(121, 189);
		this.textBox_pass.Name = "textBox_pass";
		this.textBox_pass.Size = new System.Drawing.Size(185, 27);
		this.textBox_pass.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(207, 92);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(99, 19);
		this.label1.TabIndex = 3;
		this.label1.Text = "شماره موبایل";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(244, 167);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(62, 19);
		this.label2.TabIndex = 4;
		this.label2.Text = "رمز ورود";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(222, 14);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(206, 23);
		this.label3.TabIndex = 6;
		this.label3.Text = "ورود به حساب کاربری";
		this.btn_register.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
		this.btn_register.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_register.ForeColor = System.Drawing.Color.White;
		this.btn_register.Location = new System.Drawing.Point(195, 422);
		this.btn_register.Name = "btn_register";
		this.btn_register.Size = new System.Drawing.Size(111, 38);
		this.btn_register.TabIndex = 6;
		this.btn_register.Text = "ثبت نام";
		this.btn_register.UseVisualStyleBackColor = false;
		this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
		this.btn_forget_pass.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
		this.btn_forget_pass.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_forget_pass.ForeColor = System.Drawing.Color.White;
		this.btn_forget_pass.Location = new System.Drawing.Point(12, 422);
		this.btn_forget_pass.Name = "btn_forget_pass";
		this.btn_forget_pass.Size = new System.Drawing.Size(166, 38);
		this.btn_forget_pass.TabIndex = 7;
		this.btn_forget_pass.Text = "فراموشی رمز ورود";
		this.btn_forget_pass.UseVisualStyleBackColor = false;
		this.btn_forget_pass.Click += new System.EventHandler(this.btn_forget_pass_Click);
		this.btn_support.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
		this.btn_support.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_support.ForeColor = System.Drawing.Color.White;
		this.btn_support.Location = new System.Drawing.Point(317, 422);
		this.btn_support.Name = "btn_support";
		this.btn_support.Size = new System.Drawing.Size(111, 38);
		this.btn_support.TabIndex = 5;
		this.btn_support.Text = "پشتیبانی";
		this.btn_support.UseVisualStyleBackColor = false;
		this.btn_support.Click += new System.EventHandler(this.btn_support_Click);
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 12);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 8;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label5.ForeColor = System.Drawing.Color.White;
		this.label5.Location = new System.Drawing.Point(93, 249);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(213, 19);
		this.label5.TabIndex = 20;
		this.label5.Text = "سوال امنیتی زیر را پاسخ دهید";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label_capcha.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label_capcha.ForeColor = System.Drawing.Color.White;
		this.label_capcha.Location = new System.Drawing.Point(117, 274);
		this.label_capcha.Name = "label_capcha";
		this.label_capcha.Size = new System.Drawing.Size(110, 19);
		this.label_capcha.TabIndex = 19;
		this.label_capcha.Text = "سوال";
		this.label_capcha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox_capch.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_capch.Font = new System.Drawing.Font("Tahoma", 12f);
		this.textBox_capch.ForeColor = System.Drawing.Color.White;
		this.textBox_capch.Location = new System.Drawing.Point(237, 271);
		this.textBox_capch.Name = "textBox_capch";
		this.textBox_capch.Size = new System.Drawing.Size(69, 27);
		this.textBox_capch.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		base.ClientSize = new System.Drawing.Size(440, 487);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label_capcha);
		base.Controls.Add(this.textBox_capch);
		base.Controls.Add(this.btn_support);
		base.Controls.Add(this.btn_forget_pass);
		base.Controls.Add(this.btn_register);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox_pass);
		base.Controls.Add(this.textBox_mobile);
		base.Controls.Add(this.btn_login);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "login";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "login";
		base.TopMost = true;
		base.Load += new System.EventHandler(this.login_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
