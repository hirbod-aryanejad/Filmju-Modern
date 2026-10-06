using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Filmju.utiles;
using Microsoft.VisualBasic.PowerPacks;

namespace Filmju.Activitys;

public class select_player : Form
{
	private string[] Paths;

	private string KMPlayer;

	private string VLC;

	private string PotPlayer;

	private string FilePath;

	private IContainer components;

	public TextBox text_play_link;

	private Button button1;

	private Button button2;

	private Button button3;

	private Button btn_player_settings;

	private Label label1;

	private Button btn_close;

	private ShapeContainer shapeContainer1;

	private RectangleShape rectangleShape1;

	public Label label_title;

	private Button btn_learn;

	public select_player()
	{
		InitializeComponent();
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
		}
		return list.ToArray();
	}

	private void btn_player_settings_Click(object sender, EventArgs e)
	{
		GoToSelectPlayer();
	}

	private void GoToSelectPlayer()
	{
		SetPaths();
		frmGetPaths frmPath = new frmGetPaths();
		frmPath.IsEdit = true;
		frmPath.KMPlayerPath = KMPlayer;
		frmPath.VLCpath = VLC;
		frmPath.POTpath = PotPlayer;
		frmPath.Show();
	}

	private void select_player_Load(object sender, EventArgs e)
	{
		FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\RubiPaths.txt";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			SetPaths();
			Process.Start(VLC, text_play_link.Text);
		}
		catch
		{
			MessageBox.Show("!پخش کننده یافت نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			GoToSelectPlayer();
		}
	}

	public bool SetPaths()
	{
		if (File.Exists(FilePath))
		{
			try
			{
				using StreamReader sr = new StreamReader(FilePath);
				string temp = sr.ReadToEnd();
				temp = temp.Replace('\r', ' ');
				if (!string.IsNullOrEmpty(temp))
				{
					Paths = temp.Split('\n');
					Paths = CleanArray(Paths);
					if (Paths.Length == 3)
					{
						KMPlayer = Paths[0].Split('|')[1];
						VLC = Paths[1].Split('|')[1];
						PotPlayer = Paths[2].Split('|')[1];
						return true;
					}
				}
			}
			catch (Exception)
			{
			}
		}
		return false;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			SetPaths();
			Process.Start(KMPlayer, text_play_link.Text);
		}
		catch
		{
			MessageBox.Show("!پخش کننده یافت نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			GoToSelectPlayer();
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		try
		{
			SetPaths();
			Process.Start(PotPlayer, text_play_link.Text);
		}
		catch
		{
			MessageBox.Show("!پخش کننده یافت نشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			GoToSelectPlayer();
		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btn_learn_Click(object sender, EventArgs e)
	{
		if (Global.LinkLearnPlayOnline == null)
		{
			Global.LinkLearnPlayOnline = "";
		}
		if (!Global.LinkLearnPlayOnline.Equals(""))
		{
			Process.Start(Global.LinkLearnPlayOnline);
		}
		else
		{
			MessageBox.Show("هنوز لینک آموزش وارد نشده است");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.select_player));
		this.text_play_link = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.btn_player_settings = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.btn_close = new System.Windows.Forms.Button();
		this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
		this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
		this.label_title = new System.Windows.Forms.Label();
		this.btn_learn = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.text_play_link.Location = new System.Drawing.Point(16, 190);
		this.text_play_link.Multiline = true;
		this.text_play_link.Name = "text_play_link";
		this.text_play_link.Size = new System.Drawing.Size(90, 19);
		this.text_play_link.TabIndex = 0;
		this.text_play_link.Visible = false;
		this.button1.BackColor = System.Drawing.Color.FromArgb(192, 0, 192);
		this.button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.White;
		this.button1.Location = new System.Drawing.Point(329, 87);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(148, 38);
		this.button1.TabIndex = 1;
		this.button1.Text = "VLC Player پخش با";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.button2.BackColor = System.Drawing.Color.FromArgb(192, 0, 192);
		this.button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
		this.button2.ForeColor = System.Drawing.Color.White;
		this.button2.Location = new System.Drawing.Point(175, 87);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(148, 38);
		this.button2.TabIndex = 2;
		this.button2.Text = "KM Player پخش با";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.button3.BackColor = System.Drawing.Color.FromArgb(192, 0, 192);
		this.button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
		this.button3.ForeColor = System.Drawing.Color.White;
		this.button3.Location = new System.Drawing.Point(13, 87);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(148, 38);
		this.button3.TabIndex = 3;
		this.button3.Text = "POT Player پخش با";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.btn_player_settings.BackColor = System.Drawing.Color.FromArgb(192, 0, 192);
		this.btn_player_settings.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
		this.btn_player_settings.ForeColor = System.Drawing.Color.White;
		this.btn_player_settings.Location = new System.Drawing.Point(175, 181);
		this.btn_player_settings.Name = "btn_player_settings";
		this.btn_player_settings.Size = new System.Drawing.Size(148, 37);
		this.btn_player_settings.TabIndex = 4;
		this.btn_player_settings.Text = "تنظیمات پخش کننده";
		this.btn_player_settings.UseVisualStyleBackColor = false;
		this.btn_player_settings.Click += new System.EventHandler(this.btn_player_settings_Click);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(12, 46);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(456, 19);
		this.label1.TabIndex = 5;
		this.label1.Text = "جهت پخش آنلاین ، یکی از پخش کننده های زیر را انتخاب کنید";
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 7);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 8;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
		this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
		this.shapeContainer1.Name = "shapeContainer1";
		this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[1] { this.rectangleShape1 });
		this.shapeContainer1.Size = new System.Drawing.Size(488, 231);
		this.shapeContainer1.TabIndex = 9;
		this.shapeContainer1.TabStop = false;
		this.rectangleShape1.BorderColor = System.Drawing.Color.White;
		this.rectangleShape1.BorderWidth = 3;
		this.rectangleShape1.FillColor = System.Drawing.Color.White;
		this.rectangleShape1.Location = new System.Drawing.Point(1, 1);
		this.rectangleShape1.Name = "rectangleShape1";
		this.rectangleShape1.Size = new System.Drawing.Size(485, 229);
		this.label_title.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_title.ForeColor = System.Drawing.Color.White;
		this.label_title.Location = new System.Drawing.Point(66, 12);
		this.label_title.Name = "label_title";
		this.label_title.Size = new System.Drawing.Size(373, 23);
		this.label_title.TabIndex = 10;
		this.label_title.Text = "label2";
		this.label_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_learn.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.btn_learn.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
		this.btn_learn.ForeColor = System.Drawing.Color.Black;
		this.btn_learn.Location = new System.Drawing.Point(329, 181);
		this.btn_learn.Name = "btn_learn";
		this.btn_learn.Size = new System.Drawing.Size(148, 37);
		this.btn_learn.TabIndex = 12;
		this.btn_learn.Text = "آموزش پخش آنلاین";
		this.btn_learn.UseVisualStyleBackColor = false;
		this.btn_learn.Click += new System.EventHandler(this.btn_learn_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Navy;
		base.ClientSize = new System.Drawing.Size(488, 231);
		base.Controls.Add(this.btn_learn);
		base.Controls.Add(this.label_title);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btn_player_settings);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.text_play_link);
		base.Controls.Add(this.shapeContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "select_player";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "select_player";
		base.Load += new System.EventHandler(this.select_player_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
