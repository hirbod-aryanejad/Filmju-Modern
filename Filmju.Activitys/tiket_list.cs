using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class tiket_list : Form
{
	private AppConfig ac;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	private Button btn_new_comment;

	public ListView listView_tikets;

	private Timer timer1;

	private Button btn_reload;

	public tiket_list()
	{
		InitializeComponent();
	}

	private void tiket_list_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		int Main_Form_Width = Width;
		_ = Height;
		listView_tikets.Width = Main_Form_Width;
		ac = new AppConfig();
		listView_tikets.View = View.Details;
		listView_tikets.Columns.Add("عنوان");
		listView_tikets.Columns.Add("وضعیت پاسخ");
		listView_tikets.Columns.Add("تاریخ");
		listView_tikets.Columns[0].Width = 400;
		listView_tikets.Columns[1].Width = 200;
		listView_tikets.Columns[2].Width = 200;
		listView_tikets.Columns[0].TextAlign = HorizontalAlignment.Right;
		listView_tikets.Columns[1].TextAlign = HorizontalAlignment.Center;
		listView_tikets.Columns[2].TextAlign = HorizontalAlignment.Center;
		timer1.Enabled = true;
	}

	private void SetData()
	{
		try
		{
			int itemHeight = 50;
			ImageList imgList = new ImageList();
			imgList.ImageSize = new Size(1, itemHeight);
			listView_tikets.SmallImageList = imgList;
			string url = Global.CurrentURL + ac.wiinapVll + Global.keyURL + ac.action_equal + "show-tikets";
			classes myclass = new classes();
			string Data = myclass.PostData(url, "");
			JArray arr_links = JArray.Parse(Data);
			int Len_Json = arr_links.Count;
			bool row_color = true;
			for (int i = 0; i < Len_Json; i++)
			{
				string ObjectsArray = arr_links[i].ToString();
				JObject mJsonObject = JObject.Parse(ObjectsArray);
				string id = mJsonObject.GetValue("id").ToString();
				string tit = mJsonObject.GetValue("tit").ToString();
				mJsonObject.GetValue("des").ToString();
				string sal = mJsonObject.GetValue("sal").ToString();
				mJsonObject.GetValue("state").ToString();
				mJsonObject.GetValue("child_id").ToString();
				mJsonObject.GetValue("StateOpen").ToString();
				string StateAnswer = mJsonObject.GetValue("StateAnswer").ToString();
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
				lvi1.Text = tit;
				lvi1.Name = id;
				lvi1.SubItems.Add(StateAnswer);
				lvi1.SubItems.Add(sal);
				listView_tikets.Items.Add(lvi1);
			}
			btn_new_comment.Enabled = true;
		}
		catch (Exception)
		{
		}
		ShowLableLoaing("hide");
	}

	private void ShowLableLoaing(string state)
	{
		if (frm_loading == null)
		{
			frm_loading = new frm_loading();
		}
		if (state.Equals("show"))
		{
			frm_loading.Show();
		}
		else if (state.Equals("hide"))
		{
			frm_loading.Hide();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		ShowLableLoaing("show");
		timee++;
		if (timee == 2)
		{
			timee = 0;
			timer1.Enabled = false;
			SetData();
		}
	}

	private void listView_tikets_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void listView_tikets_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void ItemSelectList()
	{
		int i = listView_tikets.SelectedIndices[0];
		tiket_show tiket_show2 = new tiket_show();
		tiket_show2.textBox_tiket_id.Text = listView_tikets.Items[i].Name.ToString();
		tiket_show2.Show();
	}

	private void btn_new_comment_Click(object sender, EventArgs e)
	{
		tiket_new tiket_new2 = new tiket_new();
		tiket_new2.txt_action.Text = "New";
		DialogResult aaa = tiket_new2.ShowDialog();
		if (aaa == DialogResult.OK)
		{
			listView_tikets.Items.Clear();
			timer1.Enabled = true;
		}
	}

	private void btn_reload_Click(object sender, EventArgs e)
	{
		listView_tikets.Items.Clear();
		timer1.Enabled = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.tiket_list));
		this.listView_tikets = new System.Windows.Forms.ListView();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.btn_reload = new System.Windows.Forms.Button();
		this.btn_new_comment = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.listView_tikets.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_tikets.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_tikets.ForeColor = System.Drawing.Color.White;
		this.listView_tikets.Location = new System.Drawing.Point(14, 68);
		this.listView_tikets.Name = "listView_tikets";
		this.listView_tikets.Size = new System.Drawing.Size(505, 379);
		this.listView_tikets.TabIndex = 6;
		this.listView_tikets.UseCompatibleStateImageBehavior = false;
		this.listView_tikets.ItemActivate += new System.EventHandler(this.listView_tikets_ItemActivate);
		this.listView_tikets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_tikets_MouseClick);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		this.btn_reload.BackColor = System.Drawing.Color.Green;
		this.btn_reload.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_reload.ForeColor = System.Drawing.Color.White;
		this.btn_reload.Location = new System.Drawing.Point(205, 12);
		this.btn_reload.Name = "btn_reload";
		this.btn_reload.Size = new System.Drawing.Size(172, 40);
		this.btn_reload.TabIndex = 9;
		this.btn_reload.Text = "بارگذاری مجدد لیست";
		this.btn_reload.UseVisualStyleBackColor = false;
		this.btn_reload.Visible = false;
		this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
		this.btn_new_comment.BackColor = System.Drawing.Color.Green;
		this.btn_new_comment.Enabled = false;
		this.btn_new_comment.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_new_comment.ForeColor = System.Drawing.Color.White;
		this.btn_new_comment.Image = Filmju.Properties.Resources.ic_plus20;
		this.btn_new_comment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_new_comment.Location = new System.Drawing.Point(14, 12);
		this.btn_new_comment.Name = "btn_new_comment";
		this.btn_new_comment.Size = new System.Drawing.Size(128, 40);
		this.btn_new_comment.TabIndex = 8;
		this.btn_new_comment.Text = "پیام جدید";
		this.btn_new_comment.UseVisualStyleBackColor = false;
		this.btn_new_comment.Click += new System.EventHandler(this.btn_new_comment_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		base.ClientSize = new System.Drawing.Size(656, 467);
		base.Controls.Add(this.btn_reload);
		base.Controls.Add(this.btn_new_comment);
		base.Controls.Add(this.listView_tikets);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "tiket_list";
		this.Text = "tiket_list";
		base.Load += new System.EventHandler(this.tiket_list_Load);
		base.ResumeLayout(false);
	}
}
