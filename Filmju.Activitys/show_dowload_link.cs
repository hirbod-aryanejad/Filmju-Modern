using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Filmju.Activitys;

public class show_dowload_link : Form
{
	private IContainer components;

	private Button btn_copy;

	private Label label1;

	private Button button5;

	public TextBox textBox_download_link;

	private Label label_copyed;

	public Label label_title;

	public show_dowload_link()
	{
		InitializeComponent();
	}

	private void btn_copy_Click(object sender, EventArgs e)
	{
		string dl_link = textBox_download_link.Text.ToString();
		if (dl_link == null)
		{
			dl_link = "";
		}
		if (!dl_link.Equals(""))
		{
			Clipboard.SetText(textBox_download_link.Text);
			label_copyed.Visible = true;
			btn_copy.Visible = false;
		}
		else
		{
			MessageBox.Show("لینک دانلود در دسترس نمی باشد");
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void show_dowload_link_Load(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.show_dowload_link));
		this.btn_copy = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.button5 = new System.Windows.Forms.Button();
		this.textBox_download_link = new System.Windows.Forms.TextBox();
		this.label_copyed = new System.Windows.Forms.Label();
		this.label_title = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.btn_copy.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_copy.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_copy.ForeColor = System.Drawing.Color.White;
		this.btn_copy.Location = new System.Drawing.Point(101, 129);
		this.btn_copy.Name = "btn_copy";
		this.btn_copy.Size = new System.Drawing.Size(147, 43);
		this.btn_copy.TabIndex = 0;
		this.btn_copy.Text = "کپی لینک دانلود";
		this.btn_copy.UseVisualStyleBackColor = false;
		this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
		this.label1.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Yellow;
		this.label1.Location = new System.Drawing.Point(9, 57);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(331, 57);
		this.label1.TabIndex = 1;
		this.label1.Text = "لینک را کپی کرده و آن را در دانلودر دلخواه یا مرورگر وارد کنید تا دانلود شروع شود";
		this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.button5.BackColor = System.Drawing.Color.Red;
		this.button5.Image = (System.Drawing.Image)resources.GetObject("button5.Image");
		this.button5.Location = new System.Drawing.Point(12, 12);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(33, 33);
		this.button5.TabIndex = 6;
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.textBox_download_link.Location = new System.Drawing.Point(15, 167);
		this.textBox_download_link.Name = "textBox_download_link";
		this.textBox_download_link.Size = new System.Drawing.Size(30, 20);
		this.textBox_download_link.TabIndex = 7;
		this.textBox_download_link.Visible = false;
		this.label_copyed.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_copyed.ForeColor = System.Drawing.Color.Yellow;
		this.label_copyed.Location = new System.Drawing.Point(91, 129);
		this.label_copyed.Name = "label_copyed";
		this.label_copyed.Size = new System.Drawing.Size(172, 43);
		this.label_copyed.TabIndex = 8;
		this.label_copyed.Text = "لینک دانلود کپی شد";
		this.label_copyed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label_copyed.Visible = false;
		this.label_title.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_title.ForeColor = System.Drawing.Color.White;
		this.label_title.Location = new System.Drawing.Point(51, 17);
		this.label_title.Name = "label_title";
		this.label_title.Size = new System.Drawing.Size(270, 23);
		this.label_title.TabIndex = 9;
		this.label_title.Text = "label2";
		this.label_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		base.ClientSize = new System.Drawing.Size(356, 199);
		base.Controls.Add(this.label_title);
		base.Controls.Add(this.label_copyed);
		base.Controls.Add(this.textBox_download_link);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btn_copy);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "show_dowload_link";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "show_dowload_link";
		base.Load += new System.EventHandler(this.show_dowload_link_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
