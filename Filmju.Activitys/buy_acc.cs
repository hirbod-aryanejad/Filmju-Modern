using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class buy_acc : Form
{
	private AppConfig ac;

	private string url_p;

	private IContainer components;

	private Label label_des;

	private Button button1;

	private Button button2;

	private Button button3;

	private Button button4;

	private Button button5;

	public buy_acc()
	{
		InitializeComponent();
	}

	private void buy_acc_Load(object sender, EventArgs e)
	{
		if (Global.user_name_config == null)
		{
			Global.user_name_config = "";
		}
		url_p = "";
		ac = new AppConfig();
		GetData();
	}

	private void GetData()
	{
		string url = Global.CurrentURL + ac.wiinapUsers + Global.keyURL + ac.action_equal + "accountprice";
		classes myclass = new classes();
		string Args = "";
		string Data = myclass.PostData(url, Args);
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string des = mJsonObject.GetValue("des").ToString();
		url_p = mJsonObject.GetValue("url").ToString();
		string price1 = mJsonObject.GetValue("price1").ToString();
		string price3 = mJsonObject.GetValue("price3").ToString();
		string price6 = mJsonObject.GetValue("price6").ToString();
		string price12 = mJsonObject.GetValue("price12").ToString();
		des = des.Replace("\n", Environment.NewLine);
		label_des.Text = des;
		button1.Text = "خرید اشتراک یک ماه (" + price1 + ") تومان";
		button2.Text = "خرید اشتراک سه ماه (" + price3 + ") تومان";
		button3.Text = "خرید اشتراک شش ماه (" + price6 + ") تومان";
		button4.Text = "خرید اشتراک یک سال (" + price12 + ") تومان";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (url_p == null)
		{
			url_p = "";
		}
		if (url_p.Length > 5 && !Global.user_name_config.Equals(""))
		{
			string url = url_p + "request.php?id=" + Global.user_name_config + "&post=1&ref=win";
			Process.Start(url);
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (url_p == null)
		{
			url_p = "";
		}
		if (url_p.Length > 5 && !Global.user_name_config.Equals(""))
		{
			string url = url_p + "request.php?id=" + Global.user_name_config + "&post=2&ref=win";
			Process.Start(url);
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (url_p == null)
		{
			url_p = "";
		}
		if (url_p.Length > 5 && !Global.user_name_config.Equals(""))
		{
			string url = url_p + "request.php?id=" + Global.user_name_config + "&post=3&ref=win";
			Process.Start(url);
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		if (url_p == null)
		{
			url_p = "";
		}
		if (url_p.Length > 5 && !Global.user_name_config.Equals(""))
		{
			string url = url_p + "request.php?id=" + Global.user_name_config + "&post=4&ref=win";
			Process.Start(url);
		}
	}

	private void button5_Click(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.buy_acc));
		this.label_des = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label_des.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_des.ForeColor = System.Drawing.Color.White;
		this.label_des.Location = new System.Drawing.Point(12, 48);
		this.label_des.Name = "label_des";
		this.label_des.Size = new System.Drawing.Size(581, 276);
		this.label_des.TabIndex = 0;
		this.label_des.Text = "label1";
		this.label_des.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.button1.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.White;
		this.button1.Location = new System.Drawing.Point(175, 327);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(241, 44);
		this.button1.TabIndex = 1;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.button2.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.ForeColor = System.Drawing.Color.White;
		this.button2.Location = new System.Drawing.Point(175, 377);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(241, 44);
		this.button2.TabIndex = 2;
		this.button2.Text = "button2";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.button3.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.ForeColor = System.Drawing.Color.White;
		this.button3.Location = new System.Drawing.Point(175, 427);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(241, 44);
		this.button3.TabIndex = 3;
		this.button3.Text = "button3";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.button4.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button4.ForeColor = System.Drawing.Color.White;
		this.button4.Location = new System.Drawing.Point(175, 477);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(241, 44);
		this.button4.TabIndex = 4;
		this.button4.Text = "button4";
		this.button4.UseVisualStyleBackColor = false;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.button5.BackColor = System.Drawing.Color.Red;
		this.button5.Image = (System.Drawing.Image)resources.GetObject("button5.Image");
		this.button5.Location = new System.Drawing.Point(12, 12);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(33, 33);
		this.button5.TabIndex = 5;
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		base.ClientSize = new System.Drawing.Size(605, 542);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label_des);
		this.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "buy_acc";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "buy_acc";
		base.Load += new System.EventHandler(this.buy_acc_Load);
		base.ResumeLayout(false);
	}
}
