using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;

namespace Filmju.Activitys;

public class tiket_new : Form
{
	private string TiketId;

	private string Action;

	private AppConfig ac;

	private IContainer components;

	private Button btn_back;

	public TextBox txt_tiket_id;

	public TextBox txt_action;

	private Panel panel_main;

	private Label label2;

	private Label label_title;

	private Button btn_submit;

	private TextBox txt_des;

	private TextBox txt_title;

	public tiket_new()
	{
		InitializeComponent();
	}

	private void tiket_new_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
		WindowState = FormWindowState.Maximized;
		int panel_main_width = panel_main.Width;
		int MainForm_width = Width;
		int defrent_width = MainForm_width - panel_main_width;
		panel_main.Left = defrent_width / 2;
		btn_back.Left = defrent_width / 2;
		TiketId = txt_tiket_id.Text;
		Action = txt_action.Text;
		ac = new AppConfig();
		if (TiketId == null)
		{
			TiketId = "";
		}
		if (Action == null)
		{
			Action = "";
		}
		if (!TiketId.Equals("") && !Action.Equals(""))
		{
			if (Action.Equals("Answer"))
			{
				txt_title.Visible = false;
				label_title.Visible = false;
			}
			else
			{
				txt_title.Visible = true;
				label_title.Visible = true;
			}
		}
	}

	private void btn_back_Click(object sender, EventArgs e)
	{
		OnBack();
	}

	private void OnBack()
	{
		try
		{
			if (Action.Equals("Answer"))
			{
				tiket_show tiket_show2 = new tiket_show();
				tiket_show2.textBox_tiket_id.Text = TiketId;
				tiket_show2.Show();
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
		}
		catch (Exception)
		{
		}
		Close();
	}

	private void SendTiket(string tit, string des)
	{
		string ac_ul = "";
		if (Action.Equals("Answer"))
		{
			ac_ul = "answer_tiket";
		}
		else
		{
			ac_ul = "new_tiket";
			TiketId = "";
		}
		string url = Global.CurrentURL + ac.wiinapVll + Global.keyURL + ac.action_equal + ac_ul;
		classes myclass = new classes();
		string Args1 = myclass.CreateArgs("tit", tit);
		string Args2 = myclass.CreateArgs("des", des);
		string Args3 = myclass.CreateArgs("child_id", TiketId);
		string Args4 = Args1 + "&" + Args2 + "&" + Args3;
		string Data = myclass.PostData(url, Args4);
		MessageBox.Show(Data);
		OnBack();
	}

	private void btn_submit_Click_1(object sender, EventArgs e)
	{
		string title = txt_title.Text;
		string des = txt_des.Text;
		if (title == null)
		{
			title = "";
		}
		if (title.Equals(" "))
		{
			title = "";
		}
		if (des == null)
		{
			des = "";
		}
		if (des.Equals(" "))
		{
			des = "";
		}
		bool is_error = false;
		if (!Action.Equals("Answer") && title.Length < 1)
		{
			is_error = true;
			MessageBox.Show("عنوان پیام را وارد کنید");
		}
		if (des.Length < 1)
		{
			is_error = true;
			MessageBox.Show("متن پیام را وارد کنید");
		}
		if (!is_error)
		{
			SendTiket(title, des);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.tiket_new));
		this.btn_back = new System.Windows.Forms.Button();
		this.txt_tiket_id = new System.Windows.Forms.TextBox();
		this.txt_action = new System.Windows.Forms.TextBox();
		this.panel_main = new System.Windows.Forms.Panel();
		this.label2 = new System.Windows.Forms.Label();
		this.label_title = new System.Windows.Forms.Label();
		this.btn_submit = new System.Windows.Forms.Button();
		this.txt_des = new System.Windows.Forms.TextBox();
		this.txt_title = new System.Windows.Forms.TextBox();
		this.panel_main.SuspendLayout();
		base.SuspendLayout();
		this.btn_back.BackColor = System.Drawing.Color.Red;
		this.btn_back.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_back.ForeColor = System.Drawing.Color.Yellow;
		this.btn_back.Image = Filmju.Properties.Resources.back_icon;
		this.btn_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_back.Location = new System.Drawing.Point(28, 12);
		this.btn_back.Name = "btn_back";
		this.btn_back.Size = new System.Drawing.Size(172, 40);
		this.btn_back.TabIndex = 4;
		this.btn_back.Text = "برگشت";
		this.btn_back.UseVisualStyleBackColor = false;
		this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
		this.txt_tiket_id.Location = new System.Drawing.Point(232, 24);
		this.txt_tiket_id.Name = "txt_tiket_id";
		this.txt_tiket_id.Size = new System.Drawing.Size(100, 20);
		this.txt_tiket_id.TabIndex = 5;
		this.txt_tiket_id.Visible = false;
		this.txt_action.Location = new System.Drawing.Point(348, 24);
		this.txt_action.Name = "txt_action";
		this.txt_action.Size = new System.Drawing.Size(100, 20);
		this.txt_action.TabIndex = 6;
		this.txt_action.Visible = false;
		this.panel_main.BackColor = System.Drawing.Color.MidnightBlue;
		this.panel_main.Controls.Add(this.label2);
		this.panel_main.Controls.Add(this.label_title);
		this.panel_main.Controls.Add(this.btn_submit);
		this.panel_main.Controls.Add(this.txt_des);
		this.panel_main.Controls.Add(this.txt_title);
		this.panel_main.Location = new System.Drawing.Point(28, 74);
		this.panel_main.Name = "panel_main";
		this.panel_main.Size = new System.Drawing.Size(474, 356);
		this.panel_main.TabIndex = 13;
		this.label2.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(338, 81);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(100, 23);
		this.label2.TabIndex = 17;
		this.label2.Text = "متن پیام";
		this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label_title.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_title.ForeColor = System.Drawing.Color.White;
		this.label_title.Location = new System.Drawing.Point(338, 15);
		this.label_title.Name = "label_title";
		this.label_title.Size = new System.Drawing.Size(100, 23);
		this.label_title.TabIndex = 16;
		this.label_title.Text = "عنوان پیام";
		this.label_title.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.btn_submit.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_submit.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_submit.ForeColor = System.Drawing.Color.White;
		this.btn_submit.Location = new System.Drawing.Point(153, 305);
		this.btn_submit.Name = "btn_submit";
		this.btn_submit.Size = new System.Drawing.Size(147, 36);
		this.btn_submit.TabIndex = 15;
		this.btn_submit.Text = "ارسال";
		this.btn_submit.UseVisualStyleBackColor = false;
		this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click_1);
		this.txt_des.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.txt_des.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txt_des.ForeColor = System.Drawing.Color.White;
		this.txt_des.Location = new System.Drawing.Point(36, 107);
		this.txt_des.Multiline = true;
		this.txt_des.Name = "txt_des";
		this.txt_des.Size = new System.Drawing.Size(402, 189);
		this.txt_des.TabIndex = 14;
		this.txt_des.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.txt_title.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.txt_title.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txt_title.ForeColor = System.Drawing.Color.White;
		this.txt_title.Location = new System.Drawing.Point(36, 41);
		this.txt_title.Name = "txt_title";
		this.txt_title.Size = new System.Drawing.Size(402, 26);
		this.txt_title.TabIndex = 13;
		this.txt_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		base.ClientSize = new System.Drawing.Size(541, 442);
		base.Controls.Add(this.panel_main);
		base.Controls.Add(this.txt_action);
		base.Controls.Add(this.txt_tiket_id);
		base.Controls.Add(this.btn_back);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "tiket_new";
		this.Text = "tiket_new";
		base.Load += new System.EventHandler(this.tiket_new_Load);
		this.panel_main.ResumeLayout(false);
		this.panel_main.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
