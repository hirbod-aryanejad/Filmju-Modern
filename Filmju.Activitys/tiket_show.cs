using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class tiket_show : Form
{
	private string TiketID;

	private AppConfig ac;

	private string StateOpen;

	private IContainer components;

	public TextBox textBox_tiket_id;

	private Button btn_back;

	public ListView listView_tikets;

	private Button btn_answer;

	public tiket_show()
	{
		InitializeComponent();
	}

	private void tiket_show_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
		WindowState = FormWindowState.Maximized;
		int Main_Form_Width = Width;
		int Main_Form_Height = Height;
		listView_tikets.Width = Main_Form_Width - 50;
		listView_tikets.Height = Main_Form_Height - listView_tikets.Top - 30;
		listView_tikets.View = View.Details;
		listView_tikets.Columns.Add("وضعیت پاسخ");
		listView_tikets.Columns.Add("پیام");
		listView_tikets.Columns[0].Width = 200;
		listView_tikets.Columns[1].Width = listView_tikets.Width - 250;
		listView_tikets.Columns[0].TextAlign = HorizontalAlignment.Center;
		listView_tikets.Columns[1].TextAlign = HorizontalAlignment.Right;
		ac = new AppConfig();
		TiketID = textBox_tiket_id.Text;
		if (TiketID == null)
		{
			TiketID = "";
		}
		if (!TiketID.Equals(""))
		{
			SetData();
		}
	}

	private void SetData()
	{
		int itemHeight = 100;
		ImageList imgList = new ImageList();
		imgList.ImageSize = new Size(1, itemHeight);
		listView_tikets.SmallImageList = imgList;
		string url = Global.ULPdisjskfdlkf + ac.CheckDevice + Global.Psdiuisdufscds + ac.key5548112 + "select_tiket";
		classes myclass = new classes();
		string Args1 = myclass.CreateArgs("id", TiketID);
		string Data = myclass.PostData(url, Args1);
		JArray arr_links = JArray.Parse(Data);
		int Len_Json = arr_links.Count;
		for (int i = 0; i < Len_Json; i++)
		{
			string ObjectsArray = arr_links[i].ToString();
			JObject mJsonObject = JObject.Parse(ObjectsArray);
			string id = mJsonObject.GetValue("id").ToString();
			mJsonObject.GetValue("tit").ToString();
			string des = mJsonObject.GetValue("des").ToString();
			mJsonObject.GetValue("sal").ToString();
			mJsonObject.GetValue("state").ToString();
			mJsonObject.GetValue("child_id").ToString();
			StateOpen = mJsonObject.GetValue("StateOpen").ToString();
			string user_name = mJsonObject.GetValue("user_name").ToString();
			ListViewItem lvi1 = new ListViewItem();
			if (user_name.Equals("Admin"))
			{
				user_name = "پاسخ مدیر";
				lvi1.BackColor = Color.Navy;
			}
			else
			{
				user_name = "پاسخ کاربر";
				lvi1.BackColor = Color.FromArgb(0, 0, 64);
			}
			lvi1.Text = user_name;
			lvi1.Name = id;
			lvi1.SubItems.Add(des);
			listView_tikets.Items.Add(lvi1);
		}
	}

	private void btn_back_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btn_answer_Click(object sender, EventArgs e)
	{
		tiket_new tiket_new2 = new tiket_new();
		tiket_new2.txt_tiket_id.Text = TiketID;
		tiket_new2.txt_action.Text = "Answer";
		tiket_new2.Show();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.tiket_show));
		this.textBox_tiket_id = new System.Windows.Forms.TextBox();
		this.listView_tikets = new System.Windows.Forms.ListView();
		this.btn_answer = new System.Windows.Forms.Button();
		this.btn_back = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox_tiket_id.Location = new System.Drawing.Point(502, 12);
		this.textBox_tiket_id.Name = "textBox_tiket_id";
		this.textBox_tiket_id.Size = new System.Drawing.Size(100, 20);
		this.textBox_tiket_id.TabIndex = 0;
		this.textBox_tiket_id.Visible = false;
		this.listView_tikets.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.listView_tikets.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_tikets.ForeColor = System.Drawing.Color.White;
		this.listView_tikets.Location = new System.Drawing.Point(38, 58);
		this.listView_tikets.Name = "listView_tikets";
		this.listView_tikets.Size = new System.Drawing.Size(505, 379);
		this.listView_tikets.TabIndex = 7;
		this.listView_tikets.UseCompatibleStateImageBehavior = false;
		this.btn_answer.BackColor = System.Drawing.Color.Green;
		this.btn_answer.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_answer.ForeColor = System.Drawing.Color.Yellow;
		this.btn_answer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_answer.Location = new System.Drawing.Point(226, 12);
		this.btn_answer.Name = "btn_answer";
		this.btn_answer.Size = new System.Drawing.Size(172, 40);
		this.btn_answer.TabIndex = 8;
		this.btn_answer.Text = "پاسخ";
		this.btn_answer.UseVisualStyleBackColor = false;
		this.btn_answer.Click += new System.EventHandler(this.btn_answer_Click);
		this.btn_back.BackColor = System.Drawing.Color.Red;
		this.btn_back.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_back.ForeColor = System.Drawing.Color.Yellow;
		this.btn_back.Image = Filmju.Properties.Resources.back_icon;
		this.btn_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_back.Location = new System.Drawing.Point(38, 12);
		this.btn_back.Name = "btn_back";
		this.btn_back.Size = new System.Drawing.Size(172, 40);
		this.btn_back.TabIndex = 3;
		this.btn_back.Text = "برگشت";
		this.btn_back.UseVisualStyleBackColor = false;
		this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		base.ClientSize = new System.Drawing.Size(760, 490);
		base.Controls.Add(this.btn_answer);
		base.Controls.Add(this.listView_tikets);
		base.Controls.Add(this.btn_back);
		base.Controls.Add(this.textBox_tiket_id);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "tiket_show";
		this.Text = "tiket_show";
		base.Load += new System.EventHandler(this.tiket_show_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
