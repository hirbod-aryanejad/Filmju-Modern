using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Filmju.utiles;

namespace Filmju.Activitys;

public class frmGetPaths : Form
{
	public string KMPlayerPath = string.Empty;

	public string VLCpath = string.Empty;

	public string POTpath = string.Empty;

	public bool IsEdit;

	private string FilePath;

	private IContainer components;

	private Button btnVLC;

	private TextBox txtVLC;

	private Button btnKMPlayer;

	private Button btnPOT;

	private Button button4;

	private TextBox txtKmplayer;

	private TextBox txtPot;

	private Label label1;

	private Button btn_close;

	private Button button1;

	public frmGetPaths()
	{
		InitializeComponent();
	}

	private void frmGetPaths_Load(object sender, EventArgs e)
	{
		try
		{
			FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\RubiPaths.txt";
			if (!File.Exists(FilePath))
			{
				FileStream outFile = File.Create(FilePath);
				outFile.Close();
			}
			if (IsEdit)
			{
				txtKmplayer.Text = KMPlayerPath;
				txtVLC.Text = VLCpath;
				txtPot.Text = POTpath;
			}
		}
		catch
		{
			Application.Restart();
		}
	}

	private void btnVLC_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "exe file|*.exe";
		using OpenFileDialog ofd = openFileDialog;
		if (ofd.ShowDialog() == DialogResult.OK)
		{
			VLCpath = ofd.FileName;
			txtVLC.Text = ofd.FileName;
			txtVLC.Text = ofd.FileName;
		}
	}

	private void btnKMPlayer_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "exe file|*.exe";
		using OpenFileDialog ofd = openFileDialog;
		if (ofd.ShowDialog() == DialogResult.OK)
		{
			KMPlayerPath = ofd.FileName;
			txtKmplayer.Text = ofd.FileName;
			txtKmplayer.Text = ofd.FileName;
		}
	}

	private void btnPOT_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "exe file|*.exe";
		using OpenFileDialog ofd = openFileDialog;
		if (ofd.ShowDialog() == DialogResult.OK)
		{
			POTpath = ofd.FileName;
			txtPot.Text = ofd.FileName;
			txtPot.Text = ofd.FileName;
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		using (StreamWriter sw = new StreamWriter(FilePath))
		{
			sw.WriteLine("KMPlayer|" + KMPlayerPath);
			sw.WriteLine("VLC|" + VLCpath);
			sw.WriteLine("POT|" + POTpath);
		}
		Close();
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.frmGetPaths));
		this.btnVLC = new System.Windows.Forms.Button();
		this.txtVLC = new System.Windows.Forms.TextBox();
		this.btnKMPlayer = new System.Windows.Forms.Button();
		this.btnPOT = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.txtKmplayer = new System.Windows.Forms.TextBox();
		this.txtPot = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.btn_close = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.btnVLC.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btnVLC.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnVLC.ForeColor = System.Drawing.Color.White;
		this.btnVLC.Location = new System.Drawing.Point(3, 72);
		this.btnVLC.Name = "btnVLC";
		this.btnVLC.Size = new System.Drawing.Size(160, 35);
		this.btnVLC.TabIndex = 0;
		this.btnVLC.Text = "VLC انتخاب پخش کننده";
		this.btnVLC.UseVisualStyleBackColor = false;
		this.btnVLC.Click += new System.EventHandler(this.btnVLC_Click);
		this.txtVLC.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.txtVLC.ForeColor = System.Drawing.Color.White;
		this.txtVLC.Location = new System.Drawing.Point(168, 80);
		this.txtVLC.Name = "txtVLC";
		this.txtVLC.ReadOnly = true;
		this.txtVLC.Size = new System.Drawing.Size(569, 20);
		this.txtVLC.TabIndex = 1;
		this.btnKMPlayer.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btnKMPlayer.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.btnKMPlayer.ForeColor = System.Drawing.Color.White;
		this.btnKMPlayer.Location = new System.Drawing.Point(3, 130);
		this.btnKMPlayer.Name = "btnKMPlayer";
		this.btnKMPlayer.Size = new System.Drawing.Size(160, 36);
		this.btnKMPlayer.TabIndex = 2;
		this.btnKMPlayer.Text = "KM انتخاب پخش کننده";
		this.btnKMPlayer.UseVisualStyleBackColor = false;
		this.btnKMPlayer.Click += new System.EventHandler(this.btnKMPlayer_Click);
		this.btnPOT.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btnPOT.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.btnPOT.ForeColor = System.Drawing.Color.White;
		this.btnPOT.Location = new System.Drawing.Point(3, 188);
		this.btnPOT.Name = "btnPOT";
		this.btnPOT.Size = new System.Drawing.Size(160, 30);
		this.btnPOT.TabIndex = 3;
		this.btnPOT.Text = "POT انتخاب پخش کننده";
		this.btnPOT.UseVisualStyleBackColor = false;
		this.btnPOT.Click += new System.EventHandler(this.btnPOT_Click);
		this.button4.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button4.ForeColor = System.Drawing.Color.White;
		this.button4.Location = new System.Drawing.Point(597, 263);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(114, 39);
		this.button4.TabIndex = 4;
		this.button4.Text = "ذخیره تغییرات";
		this.button4.UseVisualStyleBackColor = false;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.txtKmplayer.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.txtKmplayer.ForeColor = System.Drawing.Color.White;
		this.txtKmplayer.Location = new System.Drawing.Point(169, 139);
		this.txtKmplayer.Name = "txtKmplayer";
		this.txtKmplayer.ReadOnly = true;
		this.txtKmplayer.Size = new System.Drawing.Size(568, 20);
		this.txtKmplayer.TabIndex = 5;
		this.txtPot.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.txtPot.ForeColor = System.Drawing.Color.White;
		this.txtPot.Location = new System.Drawing.Point(170, 194);
		this.txtPot.Name = "txtPot";
		this.txtPot.ReadOnly = true;
		this.txtPot.Size = new System.Drawing.Size(568, 20);
		this.txtPot.TabIndex = 6;
		this.label1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(49, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(662, 60);
		this.label1.TabIndex = 7;
		this.label1.Text = "در صورتی که تمایل دارید با هرکدام از پخش کننده های زیر بتوانید پخش آنلاین کنید ، فایل اجرایی پخش کننده را از محل نصب پخش کننده انتخاب کنید";
		this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(3, 4);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 10;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.button1.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.button1.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.Location = new System.Drawing.Point(233, 263);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(272, 39);
		this.button1.TabIndex = 11;
		this.button1.Text = "آموزش انتخاب مسیر پخش کننده";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		base.ClientSize = new System.Drawing.Size(749, 314);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtPot);
		base.Controls.Add(this.txtKmplayer);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.btnPOT);
		base.Controls.Add(this.btnKMPlayer);
		base.Controls.Add(this.txtVLC);
		base.Controls.Add(this.btnVLC);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmGetPaths";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmGetPaths";
		base.Load += new System.EventHandler(this.frmGetPaths_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
