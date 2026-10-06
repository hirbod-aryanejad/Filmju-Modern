using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class frm_comments : Form
{
	private string DataComment;

	private AppConfig ac;

	private string video_id;

	private string action;

	private IContainer components;

	private Button btn_back;

	public TextBox textBox1;

	private Panel panel_new_com;

	private TextBox textBox_des_com;

	private Button btn_submit_comment;

	private Button btn_close;

	private Label label_select;

	public TextBox textBox_video_id;

	private ListView listView_comments;

	public Button btn_new_comment;

	public TextBox textBox_action;

	public frm_comments()
	{
		InitializeComponent();
	}

	private void frm_comments_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
		WindowState = FormWindowState.Maximized;
		ac = new AppConfig();
		video_id = textBox_video_id.Text;
		listView_comments.Width = Width - 40;
		listView_comments.Height = Height - 80;
		listView_comments.View = View.Details;
		listView_comments.Columns.Add("کاربر");
		listView_comments.Columns.Add("متن نظر");
		listView_comments.Columns[0].Width = 150;
		listView_comments.Columns[1].Width = Width - 250;
		listView_comments.Columns[0].TextAlign = HorizontalAlignment.Right;
		listView_comments.Columns[1].TextAlign = HorizontalAlignment.Right;
		int panel_main_width = panel_new_com.Width;
		int MainForm_width = Width;
		int defrent_width = MainForm_width - panel_main_width;
		panel_new_com.Left = defrent_width / 2;
		DataComment = textBox1.Text;
		action = textBox_action.Text;
		if (DataComment == null)
		{
			DataComment = "";
		}
		if (action == null)
		{
			action = "";
		}
		if (!DataComment.Equals(""))
		{
			if (DataComment.Equals("MyComments"))
			{
				SetDataMyComments();
			}
			else
			{
				SetData();
			}
		}
	}

	private void btn_back_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void SetData()
	{
		int itemHeight = 70;
		ImageList imgList = new ImageList();
		imgList.ImageSize = new Size(1, itemHeight);
		listView_comments.SmallImageList = imgList;
		JArray arr_links = JArray.Parse(DataComment);
		int Len_Json = arr_links.Count;
		bool row_color = true;
		for (int i = 0; i < Len_Json; i++)
		{
			string ObjectsArray = arr_links[i].ToString();
			JObject mJsonObject = JObject.Parse(ObjectsArray);
			string id = mJsonObject.GetValue("id").ToString();
			string name = mJsonObject.GetValue("name").ToString();
			string des = mJsonObject.GetValue("des").ToString();
			string des_admin = mJsonObject.GetValue("des_admin").ToString();
			mJsonObject.GetValue("sal").ToString();
			if (action.Equals("my-comments"))
			{
				name = mJsonObject.GetValue("video_title").ToString();
			}
			ListViewItem lvi1 = new ListViewItem();
			if (row_color)
			{
				row_color = false;
				lvi1.BackColor = Color.FromArgb(0, 0, 64);
			}
			else
			{
				row_color = true;
				lvi1.BackColor = Color.Navy;
			}
			lvi1.Text = name;
			lvi1.Name = id;
			lvi1.SubItems.Add(des);
			listView_comments.Items.Add(lvi1);
			if (des_admin.Length > 0)
			{
				ListViewItem lvi2 = new ListViewItem();
				lvi2.BackColor = Color.FromArgb(0, 64, 0);
				des_admin = "پاسخ مدیر به " + name + " : " + des_admin;
				lvi2.Text = "پاسخ مدیر";
				lvi2.Name = id;
				lvi2.SubItems.Add(des_admin);
				listView_comments.Items.Add(lvi2);
			}
		}
	}

	private void listView_comments_MouseClick(object sender, MouseEventArgs e)
	{
	}

	private void listView_comments_ItemActivate(object sender, EventArgs e)
	{
	}

	private void ItemSelectList()
	{
		int i = listView_comments.SelectedIndices[0];
		MessageBox.Show(listView_comments.Items[i].Text);
	}

	private void btn_new_comment_Click(object sender, EventArgs e)
	{
		if (Global.LoginState == null)
		{
			Global.LoginState = "F";
		}
		if (Global.LoginState.Equals("T"))
		{
			panel_new_com.Visible = true;
		}
		else
		{
			MessageBox.Show("جهت ارسال نظر باید ابتدا وارد حساب کاربری خود شوید");
		}
	}

	private void btn_submit_comment_Click(object sender, EventArgs e)
	{
		if (Global.LoginState == null)
		{
			Global.LoginState = "F";
		}
		if (Global.LoginState.Equals("T"))
		{
			string text = textBox_des_com.Text;
			if (text == null)
			{
				text = "";
			}
			if (text.Length > 0)
			{
				SendComment(text);
			}
			else
			{
				MessageBox.Show("نظر خود را بنویسید و سپس دکمه ثبت نظر را بزنید");
			}
		}
		else
		{
			MessageBox.Show("جهت ارسال نظر باید ابتدا وارد حساب کاربری خود شوید");
		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		panel_new_com.Visible = false;
	}

	private void SendComment(string text)
	{
		string url = Global.ULPdisjskfdlkf + ac.CheckDevice + Global.Psdiuisdufscds + ac.key5548112 + "send_comment";
		classes myclass = new classes();
		string Args1 = myclass.CreateArgs("video_id", video_id);
		string Args2 = myclass.CreateArgs("comment_des", text);
		string Args3 = Args1 + "&" + Args2;
		string Data = myclass.PostData(url, Args3);
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string msg = mJsonObject.GetValue("msg").ToString();
		string state = mJsonObject.GetValue("state").ToString();
		if (state.Equals("T"))
		{
			string id_comment = mJsonObject.GetValue("id").ToString();
			mJsonObject.GetValue("sal").ToString();
			string name_user = mJsonObject.GetValue("name_user").ToString();
			ListViewItem lvi1 = new ListViewItem();
			lvi1.BackColor = Color.Green;
			lvi1.Text = name_user;
			lvi1.Name = id_comment;
			lvi1.SubItems.Add(text);
			listView_comments.Items.Add(lvi1);
			textBox_des_com.Text = "";
			panel_new_com.Visible = false;
		}
		MessageBox.Show(msg);
	}

	private void SetDataMyComments()
	{
		string url = Global.ULPdisjskfdlkf + ac.CheckDevice + Global.Psdiuisdufscds + ac.key5548112 + action;
		classes myclass = new classes();
		string Args = "";
		string Data = myclass.PostData(url, Args);
		JObject obj_all = JObject.Parse(Data);
		string all = obj_all.GetValue("all").ToString();
		DataComment = all;
		SetData();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.frm_comments));
		this.listView_comments = new System.Windows.Forms.ListView();
		this.btn_back = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.btn_new_comment = new System.Windows.Forms.Button();
		this.panel_new_com = new System.Windows.Forms.Panel();
		this.label_select = new System.Windows.Forms.Label();
		this.btn_close = new System.Windows.Forms.Button();
		this.textBox_des_com = new System.Windows.Forms.TextBox();
		this.btn_submit_comment = new System.Windows.Forms.Button();
		this.textBox_video_id = new System.Windows.Forms.TextBox();
		this.textBox_action = new System.Windows.Forms.TextBox();
		this.panel_new_com.SuspendLayout();
		base.SuspendLayout();
		this.listView_comments.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.listView_comments.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_comments.ForeColor = System.Drawing.Color.White;
		this.listView_comments.Location = new System.Drawing.Point(20, 60);
		this.listView_comments.Name = "listView_comments";
		this.listView_comments.Size = new System.Drawing.Size(245, 356);
		this.listView_comments.TabIndex = 0;
		this.listView_comments.UseCompatibleStateImageBehavior = false;
		this.listView_comments.ItemActivate += new System.EventHandler(this.listView_comments_ItemActivate);
		this.listView_comments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_comments_MouseClick);
		this.btn_back.BackColor = System.Drawing.Color.Red;
		this.btn_back.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_back.ForeColor = System.Drawing.Color.Yellow;
		this.btn_back.Image = Filmju.Properties.Resources.back_icon;
		this.btn_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_back.Location = new System.Drawing.Point(20, 12);
		this.btn_back.Name = "btn_back";
		this.btn_back.Size = new System.Drawing.Size(172, 40);
		this.btn_back.TabIndex = 3;
		this.btn_back.Text = "برگشت";
		this.btn_back.UseVisualStyleBackColor = false;
		this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
		this.textBox1.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox1.Location = new System.Drawing.Point(503, 12);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(159, 40);
		this.textBox1.TabIndex = 4;
		this.textBox1.Visible = false;
		this.btn_new_comment.BackColor = System.Drawing.Color.Green;
		this.btn_new_comment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_new_comment.ForeColor = System.Drawing.Color.White;
		this.btn_new_comment.Location = new System.Drawing.Point(208, 14);
		this.btn_new_comment.Name = "btn_new_comment";
		this.btn_new_comment.Size = new System.Drawing.Size(172, 40);
		this.btn_new_comment.TabIndex = 5;
		this.btn_new_comment.Text = "ارسال نظر جدید";
		this.btn_new_comment.UseVisualStyleBackColor = false;
		this.btn_new_comment.Click += new System.EventHandler(this.btn_new_comment_Click);
		this.panel_new_com.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.panel_new_com.Controls.Add(this.label_select);
		this.panel_new_com.Controls.Add(this.btn_close);
		this.panel_new_com.Controls.Add(this.textBox_des_com);
		this.panel_new_com.Controls.Add(this.btn_submit_comment);
		this.panel_new_com.Location = new System.Drawing.Point(298, 70);
		this.panel_new_com.Name = "panel_new_com";
		this.panel_new_com.Size = new System.Drawing.Size(420, 359);
		this.panel_new_com.TabIndex = 6;
		this.panel_new_com.Visible = false;
		this.label_select.AutoSize = true;
		this.label_select.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_select.ForeColor = System.Drawing.Color.White;
		this.label_select.Location = new System.Drawing.Point(170, 8);
		this.label_select.Name = "label_select";
		this.label_select.Size = new System.Drawing.Size(87, 19);
		this.label_select.TabIndex = 9;
		this.label_select.Text = "ارسال نظر";
		this.label_select.Visible = false;
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(3, 3);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 8;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.textBox_des_com.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		this.textBox_des_com.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_des_com.ForeColor = System.Drawing.Color.White;
		this.textBox_des_com.Location = new System.Drawing.Point(3, 39);
		this.textBox_des_com.Multiline = true;
		this.textBox_des_com.Name = "textBox_des_com";
		this.textBox_des_com.Size = new System.Drawing.Size(414, 265);
		this.textBox_des_com.TabIndex = 1;
		this.textBox_des_com.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.btn_submit_comment.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_submit_comment.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_submit_comment.ForeColor = System.Drawing.Color.White;
		this.btn_submit_comment.Location = new System.Drawing.Point(156, 310);
		this.btn_submit_comment.Name = "btn_submit_comment";
		this.btn_submit_comment.Size = new System.Drawing.Size(123, 36);
		this.btn_submit_comment.TabIndex = 0;
		this.btn_submit_comment.Text = "ثبت نظر";
		this.btn_submit_comment.UseVisualStyleBackColor = false;
		this.btn_submit_comment.Click += new System.EventHandler(this.btn_submit_comment_Click);
		this.textBox_video_id.Location = new System.Drawing.Point(693, 15);
		this.textBox_video_id.Name = "textBox_video_id";
		this.textBox_video_id.Size = new System.Drawing.Size(82, 20);
		this.textBox_video_id.TabIndex = 7;
		this.textBox_video_id.Visible = false;
		this.textBox_action.Location = new System.Drawing.Point(693, 44);
		this.textBox_action.Name = "textBox_action";
		this.textBox_action.Size = new System.Drawing.Size(82, 20);
		this.textBox_action.TabIndex = 8;
		this.textBox_action.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		base.ClientSize = new System.Drawing.Size(797, 538);
		base.Controls.Add(this.textBox_action);
		base.Controls.Add(this.textBox_video_id);
		base.Controls.Add(this.panel_new_com);
		base.Controls.Add(this.btn_new_comment);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.btn_back);
		base.Controls.Add(this.listView_comments);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frm_comments";
		this.Text = "frm_comments";
		base.Load += new System.EventHandler(this.frm_comments_Load);
		this.panel_new_com.ResumeLayout(false);
		this.panel_new_com.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
