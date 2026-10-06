using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class register : Form
{
	private int ans_capcha;

	private AppConfig ac;

	private IContainer components;

	private Label label2;

	private Label label1;

	private TextBox textBox_mobile;

	private TextBox textBox_name;

	private Button btn_register;

	private Label label3;

	private TextBox textBox_pass;

	private Button btn_login;

	private Label label4;

	private Button btn_close;

	private TextBox textBox_capch;

	private Label label_capcha;

	private Label label5;

	public register()
	{
		InitializeComponent();
	}

	private void register_Load(object sender, EventArgs e)
	{
		ac = new AppConfig();
		Random rnd = new Random();
		int num_1 = rnd.Next(1, 10);
		int num_2 = rnd.Next(1, 10);
		ans_capcha = num_1 + num_2;
		label_capcha.Text = num_1 + " + " + num_2 + " = ";
	}

	private void btn_login_Click(object sender, EventArgs e)
	{
		login frm_login = new login();
		DialogResult res = frm_login.ShowDialog();
		if (res == DialogResult.OK)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btn_register_Click(object sender, EventArgs e)
	{
		string name = textBox_name.Text.ToString();
		string mobile = textBox_mobile.Text.ToString();
		string pass = textBox_pass.Text.ToString();
		string capcha = textBox_capch.Text.ToString();
		if (name == null)
		{
			name = "";
		}
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
		if (name.Length > 0 && pass.Length > 5 && mobile.Length == 11 && capcha_ans == ans_capcha)
		{
			string msg2 = "کد فعالسازی به شماره موبایل " + mobile + " ارسال خواهد شد . از درست بودن شماره موبایل اطمینان دارید؟";
			switch (MessageBox.Show(msg2, "فعالسازی", MessageBoxButtons.YesNo))
			{
			case DialogResult.Yes:
				PostData(mobile, pass, name);
				break;
			}
		}
		else if (name.Length < 1)
		{
			MessageBox.Show("نام خود را وارد کنید");
		}
		else if (pass.Length < 6)
		{
			MessageBox.Show("رمز ورود باید حداقل 6 کاراکتر باشد");
		}
		else if (mobile.Length != 11)
		{
			MessageBox.Show("شماره موبایل را به درستی وارد نمایید");
		}
		else if (capcha_ans != ans_capcha)
		{
			MessageBox.Show("پاسخ سوال امنیتی اشتباه می باشد");
		}
	}

	private void textBox_mobile_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
	}

	private void textBox_capch_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
	}

	private void PostData(string user_name, string pass, string name)
	{
		Global.user_name_config = user_name;
		string url = Global.CurrentURL + ac.FontEditor + Global.keyURL + ac.action_equal + "new";
		classes myclass = new classes();
		string Args1 = myclass.CreateArgs("name", name);
		string Args2 = myclass.CreateArgs("pass", pass);
		string Args3 = Args1 + "&" + Args2;
		string Data = myclass.PostData(url, Args3);
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string login2 = mJsonObject.GetValue("login").ToString();
		string msg = mJsonObject.GetValue("msg").ToString();
		if (login2.Equals("E"))
		{
			active_user active_user2 = new active_user();
			DialogResult res = active_user2.ShowDialog();
			if (res == DialogResult.OK)
			{
				if (Global.LoginState.Equals("T"))
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			else
			{
				MessageBox.Show("اگر به صورت خودکار وارد حساب کاربری نشدید از بخش ورود اقدام به ورود کنید");
			}
		}
		else
		{
			MessageBox.Show(msg);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.register));
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox_mobile = new System.Windows.Forms.TextBox();
		this.textBox_name = new System.Windows.Forms.TextBox();
		this.btn_register = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox_pass = new System.Windows.Forms.TextBox();
		this.btn_login = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.btn_close = new System.Windows.Forms.Button();
		this.textBox_capch = new System.Windows.Forms.TextBox();
		this.label_capcha = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(211, 143);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(99, 19);
		this.label2.TabIndex = 9;
		this.label2.Text = "شماره موبایل";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(283, 68);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(27, 19);
		this.label1.TabIndex = 8;
		this.label1.Text = "نام";
		this.textBox_mobile.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_mobile.Font = new System.Drawing.Font("Tahoma", 12f);
		this.textBox_mobile.ForeColor = System.Drawing.Color.White;
		this.textBox_mobile.Location = new System.Drawing.Point(125, 165);
		this.textBox_mobile.Name = "textBox_mobile";
		this.textBox_mobile.Size = new System.Drawing.Size(185, 27);
		this.textBox_mobile.TabIndex = 2;
		this.textBox_mobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_mobile_KeyPress);
		this.textBox_name.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_name.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_name.ForeColor = System.Drawing.Color.White;
		this.textBox_name.Location = new System.Drawing.Point(125, 90);
		this.textBox_name.Name = "textBox_name";
		this.textBox_name.Size = new System.Drawing.Size(185, 27);
		this.textBox_name.TabIndex = 1;
		this.btn_register.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_register.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_register.ForeColor = System.Drawing.Color.White;
		this.btn_register.Location = new System.Drawing.Point(144, 371);
		this.btn_register.Name = "btn_register";
		this.btn_register.Size = new System.Drawing.Size(111, 38);
		this.btn_register.TabIndex = 5;
		this.btn_register.Text = "ثبت";
		this.btn_register.UseVisualStyleBackColor = false;
		this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(248, 214);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(62, 19);
		this.label3.TabIndex = 11;
		this.label3.Text = "رمز ورود";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox_pass.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_pass.Font = new System.Drawing.Font("Tahoma", 12f);
		this.textBox_pass.ForeColor = System.Drawing.Color.White;
		this.textBox_pass.Location = new System.Drawing.Point(125, 236);
		this.textBox_pass.Name = "textBox_pass";
		this.textBox_pass.Size = new System.Drawing.Size(185, 27);
		this.textBox_pass.TabIndex = 3;
		this.btn_login.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
		this.btn_login.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_login.ForeColor = System.Drawing.Color.White;
		this.btn_login.Location = new System.Drawing.Point(92, 441);
		this.btn_login.Name = "btn_login";
		this.btn_login.Size = new System.Drawing.Size(231, 38);
		this.btn_login.TabIndex = 6;
		this.btn_login.Text = "قبلا ثبت نام کرده ام / ورود";
		this.btn_login.UseVisualStyleBackColor = false;
		this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.White;
		this.label4.Location = new System.Drawing.Point(222, 14);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(203, 23);
		this.label4.TabIndex = 14;
		this.label4.Text = "ساخت حساب کاربری";
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 12);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 7;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.textBox_capch.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_capch.Font = new System.Drawing.Font("Tahoma", 12f);
		this.textBox_capch.ForeColor = System.Drawing.Color.White;
		this.textBox_capch.Location = new System.Drawing.Point(241, 322);
		this.textBox_capch.Name = "textBox_capch";
		this.textBox_capch.Size = new System.Drawing.Size(69, 27);
		this.textBox_capch.TabIndex = 4;
		this.textBox_capch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_capch_KeyPress);
		this.label_capcha.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label_capcha.ForeColor = System.Drawing.Color.White;
		this.label_capcha.Location = new System.Drawing.Point(121, 325);
		this.label_capcha.Name = "label_capcha";
		this.label_capcha.Size = new System.Drawing.Size(110, 19);
		this.label_capcha.TabIndex = 16;
		this.label_capcha.Text = "سوال";
		this.label_capcha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label5.ForeColor = System.Drawing.Color.White;
		this.label5.Location = new System.Drawing.Point(97, 300);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(213, 19);
		this.label5.TabIndex = 17;
		this.label5.Text = "سوال امنیتی زیر را پاسخ دهید";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		base.ClientSize = new System.Drawing.Size(440, 491);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label_capcha);
		base.Controls.Add(this.textBox_capch);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.btn_login);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBox_pass);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox_mobile);
		base.Controls.Add(this.textBox_name);
		base.Controls.Add(this.btn_register);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "register";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "register";
		base.TopMost = true;
		base.Load += new System.EventHandler(this.register_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
