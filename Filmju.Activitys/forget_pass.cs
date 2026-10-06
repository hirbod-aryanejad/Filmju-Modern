using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.utiles;

namespace Filmju.Activitys;

public class forget_pass : Form
{
	private int ans_capcha;

	private int time_resend;

	private AppConfig ac;

	private IContainer components;

	private Panel panel_1;

	private Label label1;

	private TextBox textBox_mobile;

	private Button btn_1;

	private Panel panel_2;

	private Label label_encode;

	private TextBox textBox_code;

	private Button btn_2;

	private Panel panel_3;

	private Label label3;

	private TextBox textBox_pass;

	private Button btn_3;

	private Label label5;

	private Label label_capcha;

	private TextBox textBox_capch;

	private Button btn_close;

	private Label label2;

	private Timer timer1;

	private Button btn_resend;

	private Label label_timer;

	public forget_pass()
	{
		InitializeComponent();
	}

	private void forget_pass_Load(object sender, EventArgs e)
	{
		panel_1.Left = 12;
		panel_1.Top = 50;
		panel_2.Left = 12;
		panel_2.Top = 50;
		panel_3.Left = 12;
		panel_3.Top = 50;
		time_resend = 130;
		ac = new AppConfig();
		Random rnd = new Random();
		int num_1 = rnd.Next(1, 10);
		int num_2 = rnd.Next(1, 10);
		ans_capcha = num_1 + num_2;
		label_capcha.Text = num_1 + " + " + num_2 + " = ";
	}

	private void btn_1_Click(object sender, EventArgs e)
	{
		string mobile = textBox_mobile.Text.ToString();
		string capcha = textBox_capch.Text.ToString();
		if (mobile == null)
		{
			mobile = "";
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
		if (mobile.Length == 11 && capcha_ans == ans_capcha)
		{
			string msg2 = "کد فعالسازی به شماره موبایل " + mobile + " ارسال خواهد شد . از درست بودن شماره موبایل اطمینان دارید؟";
			switch (MessageBox.Show(msg2, "فعالسازی", MessageBoxButtons.YesNo))
			{
			case DialogResult.Yes:
			{
				Global.user_name_config = mobile;
				string step = "1";
				PostData(step, "", "");
				break;
			}
			}
		}
		else if (mobile.Length != 11)
		{
			MessageBox.Show("شماره موبایل وارد شده اشتباه است");
		}
		else if (capcha_ans != ans_capcha)
		{
			MessageBox.Show("پاسخ سوال امنیتی اشتباه می باشد");
		}
	}

	private void PostData(string step, string encode, string new_pass)
	{
		btn_resend.Visible = false;
		timer1.Start();
		string url = Global.CurrentURL + ac.FontEditor + Global.keyURL + ac.action_equal + "change_pass";
		classes myclass = new classes();
		string Args1 = myclass.CreateArgs("step", step);
		string Args2 = myclass.CreateArgs("code_forget", encode);
		string Args3 = myclass.CreateArgs("new_pass", new_pass);
		string Args4 = Args1 + "&" + Args2 + "&" + Args3;
		string Data = myclass.PostData(url, Args4);
		if (step.Equals("1"))
		{
			if (Data.Equals("T"))
			{
				panel_1.Visible = false;
				panel_2.Visible = true;
				label_encode.Text = "کد فعالسازی ارسال شده به شماره موبایل " + Global.user_name_config + " را در کادر زیر وارد نمایید";
				btn_resend.Visible = false;
				timer1.Start();
			}
			else
			{
				MessageBox.Show(Data);
			}
		}
		else if (step.Equals("2"))
		{
			if (Data.Equals("T"))
			{
				panel_2.Visible = false;
				timer1.Stop();
				panel_3.Visible = true;
			}
			else
			{
				MessageBox.Show(Data);
			}
		}
		else if (step.Equals("3"))
		{
			if (Data.Equals("T"))
			{
				MessageBox.Show("رمز ورود با موفقیت ثبت گردید. از بخش ورود اقدام به ورود کنید");
				Close();
			}
			else
			{
				MessageBox.Show(Data);
			}
		}
	}

	private void btn_resend_Click(object sender, EventArgs e)
	{
		time_resend = 130;
		PostData("1", "", "");
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

	private void btn_2_Click(object sender, EventArgs e)
	{
		string code = textBox_code.Text.ToString();
		if (code == null)
		{
			code = "";
		}
		if (code.Length > 0)
		{
			string step = "2";
			PostData(step, code, "");
		}
		else
		{
			MessageBox.Show("کد فعالسازی را وارد کنید");
		}
	}

	private void btn_3_Click(object sender, EventArgs e)
	{
		string pass = textBox_pass.Text.ToString();
		if (pass == null)
		{
			pass = "";
		}
		if (pass.Length > 5)
		{
			string step = "3";
			PostData(step, "", pass);
		}
		else
		{
			MessageBox.Show("رمز ورود باید حداقل 6 کاراکتر باشد");
		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.forget_pass));
		this.panel_1 = new System.Windows.Forms.Panel();
		this.label5 = new System.Windows.Forms.Label();
		this.label_capcha = new System.Windows.Forms.Label();
		this.textBox_capch = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox_mobile = new System.Windows.Forms.TextBox();
		this.btn_1 = new System.Windows.Forms.Button();
		this.panel_2 = new System.Windows.Forms.Panel();
		this.btn_resend = new System.Windows.Forms.Button();
		this.label_timer = new System.Windows.Forms.Label();
		this.label_encode = new System.Windows.Forms.Label();
		this.textBox_code = new System.Windows.Forms.TextBox();
		this.btn_2 = new System.Windows.Forms.Button();
		this.panel_3 = new System.Windows.Forms.Panel();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox_pass = new System.Windows.Forms.TextBox();
		this.btn_3 = new System.Windows.Forms.Button();
		this.btn_close = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel_1.SuspendLayout();
		this.panel_2.SuspendLayout();
		this.panel_3.SuspendLayout();
		base.SuspendLayout();
		this.panel_1.Controls.Add(this.label5);
		this.panel_1.Controls.Add(this.label_capcha);
		this.panel_1.Controls.Add(this.textBox_capch);
		this.panel_1.Controls.Add(this.label1);
		this.panel_1.Controls.Add(this.textBox_mobile);
		this.panel_1.Controls.Add(this.btn_1);
		this.panel_1.Location = new System.Drawing.Point(12, 50);
		this.panel_1.Name = "panel_1";
		this.panel_1.Size = new System.Drawing.Size(362, 230);
		this.panel_1.TabIndex = 0;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label5.ForeColor = System.Drawing.Color.White;
		this.label5.Location = new System.Drawing.Point(68, 122);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(213, 19);
		this.label5.TabIndex = 23;
		this.label5.Text = "سوال امنیتی زیر را پاسخ دهید";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label_capcha.Font = new System.Drawing.Font("Tahoma", 12f);
		this.label_capcha.ForeColor = System.Drawing.Color.White;
		this.label_capcha.Location = new System.Drawing.Point(68, 147);
		this.label_capcha.Name = "label_capcha";
		this.label_capcha.Size = new System.Drawing.Size(110, 19);
		this.label_capcha.TabIndex = 22;
		this.label_capcha.Text = "سوال";
		this.label_capcha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox_capch.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_capch.Font = new System.Drawing.Font("Tahoma", 12f);
		this.textBox_capch.ForeColor = System.Drawing.Color.White;
		this.textBox_capch.Location = new System.Drawing.Point(187, 144);
		this.textBox_capch.Name = "textBox_capch";
		this.textBox_capch.Size = new System.Drawing.Size(69, 27);
		this.textBox_capch.TabIndex = 21;
		this.label1.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(12, 27);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(327, 56);
		this.label1.TabIndex = 2;
		this.label1.Text = "شماره موبایلی که با آن قبلا در برنامه ثبت نام کرده اید را جهت بازیابی رمز ورود وارد کرده و سپس دکمه ثبت را بزنید";
		this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.textBox_mobile.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_mobile.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_mobile.ForeColor = System.Drawing.Color.White;
		this.textBox_mobile.Location = new System.Drawing.Point(105, 86);
		this.textBox_mobile.Name = "textBox_mobile";
		this.textBox_mobile.Size = new System.Drawing.Size(151, 23);
		this.textBox_mobile.TabIndex = 1;
		this.btn_1.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_1.ForeColor = System.Drawing.Color.White;
		this.btn_1.Location = new System.Drawing.Point(125, 177);
		this.btn_1.Name = "btn_1";
		this.btn_1.Size = new System.Drawing.Size(97, 34);
		this.btn_1.TabIndex = 0;
		this.btn_1.Text = "ثبت";
		this.btn_1.UseVisualStyleBackColor = false;
		this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
		this.panel_2.Controls.Add(this.btn_resend);
		this.panel_2.Controls.Add(this.label_timer);
		this.panel_2.Controls.Add(this.label_encode);
		this.panel_2.Controls.Add(this.textBox_code);
		this.panel_2.Controls.Add(this.btn_2);
		this.panel_2.Location = new System.Drawing.Point(12, 286);
		this.panel_2.Name = "panel_2";
		this.panel_2.Size = new System.Drawing.Size(362, 230);
		this.panel_2.TabIndex = 3;
		this.panel_2.Visible = false;
		this.btn_resend.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_resend.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_resend.ForeColor = System.Drawing.Color.White;
		this.btn_resend.Location = new System.Drawing.Point(72, 157);
		this.btn_resend.Name = "btn_resend";
		this.btn_resend.Size = new System.Drawing.Size(209, 32);
		this.btn_resend.TabIndex = 11;
		this.btn_resend.Text = "دریافت مجدد کد فعالسازی";
		this.btn_resend.UseVisualStyleBackColor = false;
		this.btn_resend.Visible = false;
		this.btn_resend.Click += new System.EventHandler(this.btn_resend_Click);
		this.label_timer.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_timer.ForeColor = System.Drawing.Color.White;
		this.label_timer.Location = new System.Drawing.Point(35, 192);
		this.label_timer.Name = "label_timer";
		this.label_timer.Size = new System.Drawing.Size(281, 23);
		this.label_timer.TabIndex = 10;
		this.label_timer.Text = "00:00";
		this.label_timer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.label_encode.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_encode.ForeColor = System.Drawing.Color.White;
		this.label_encode.Location = new System.Drawing.Point(12, 19);
		this.label_encode.Name = "label_encode";
		this.label_encode.Size = new System.Drawing.Size(327, 56);
		this.label_encode.TabIndex = 2;
		this.label_encode.Text = "کد ارسال شده";
		this.label_encode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.textBox_code.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_code.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_code.ForeColor = System.Drawing.Color.White;
		this.textBox_code.Location = new System.Drawing.Point(105, 78);
		this.textBox_code.Name = "textBox_code";
		this.textBox_code.Size = new System.Drawing.Size(151, 23);
		this.textBox_code.TabIndex = 1;
		this.btn_2.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_2.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_2.ForeColor = System.Drawing.Color.White;
		this.btn_2.Location = new System.Drawing.Point(125, 117);
		this.btn_2.Name = "btn_2";
		this.btn_2.Size = new System.Drawing.Size(97, 34);
		this.btn_2.TabIndex = 0;
		this.btn_2.Text = "ثبت";
		this.btn_2.UseVisualStyleBackColor = false;
		this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
		this.panel_3.Controls.Add(this.label3);
		this.panel_3.Controls.Add(this.textBox_pass);
		this.panel_3.Controls.Add(this.btn_3);
		this.panel_3.Location = new System.Drawing.Point(424, 50);
		this.panel_3.Name = "panel_3";
		this.panel_3.Size = new System.Drawing.Size(362, 230);
		this.panel_3.TabIndex = 4;
		this.panel_3.Visible = false;
		this.label3.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(12, 66);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(327, 26);
		this.label3.TabIndex = 2;
		this.label3.Text = "رمز ورود جدید را وارد کنید";
		this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.textBox_pass.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_pass.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_pass.ForeColor = System.Drawing.Color.White;
		this.textBox_pass.Location = new System.Drawing.Point(105, 95);
		this.textBox_pass.Name = "textBox_pass";
		this.textBox_pass.Size = new System.Drawing.Size(151, 23);
		this.textBox_pass.TabIndex = 1;
		this.btn_3.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_3.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_3.ForeColor = System.Drawing.Color.White;
		this.btn_3.Location = new System.Drawing.Point(125, 134);
		this.btn_3.Name = "btn_3";
		this.btn_3.Size = new System.Drawing.Size(97, 34);
		this.btn_3.TabIndex = 0;
		this.btn_3.Text = "ثبت";
		this.btn_3.UseVisualStyleBackColor = false;
		this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 12);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 9;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(222, 14);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(151, 23);
		this.label2.TabIndex = 10;
		this.label2.Text = "بازیابی رمز ورود";
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Purple;
		base.ClientSize = new System.Drawing.Size(388, 300);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.panel_3);
		base.Controls.Add(this.panel_2);
		base.Controls.Add(this.panel_1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "forget_pass";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "forget_pass";
		base.TopMost = true;
		base.Load += new System.EventHandler(this.forget_pass_Load);
		this.panel_1.ResumeLayout(false);
		this.panel_1.PerformLayout();
		this.panel_2.ResumeLayout(false);
		this.panel_2.PerformLayout();
		this.panel_3.ResumeLayout(false);
		this.panel_3.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
