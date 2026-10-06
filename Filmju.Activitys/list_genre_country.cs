using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class list_genre_country : Form
{
	private string What_gc;

	private string What_ms;

	private IContainer components;

	public TextBox textBox_gc_what;

	public TextBox textBox_ms_what;

	public TextBox textBox_genre_data;

	private ListView listView_gc;

	private Button btn_close;

	public Label label_title;

	public list_genre_country()
	{
		InitializeComponent();
	}

	private void list_genre_country_Load(object sender, EventArgs e)
	{
		What_gc = textBox_gc_what.Text;
		What_ms = textBox_ms_what.Text;
		string Data = textBox_genre_data.Text;
		if (Data == null)
		{
			Data = "";
		}
		if (What_gc == null)
		{
			What_gc = "";
		}
		if (What_ms == null)
		{
			What_ms = "";
		}
		if (Data.Equals(""))
		{
			return;
		}
		JArray all_array = JArray.Parse(Data);
		int Len_Json = all_array.Count;
		for (int i = 0; i < Len_Json; i++)
		{
			string ObjectsArray = all_array[i].ToString();
			JObject mJsonObject = JObject.Parse(ObjectsArray);
			string id = "";
			string name = "";
			if (What_gc.Equals("genre"))
			{
				id = mJsonObject.GetValue("genre_id").ToString();
				name = mJsonObject.GetValue("name").ToString();
			}
			if (What_gc.Equals("country"))
			{
				id = mJsonObject.GetValue("country_id").ToString();
				name = mJsonObject.GetValue("name").ToString();
			}
			if (!name.Equals(""))
			{
				ListViewItem lvi1 = new ListViewItem();
				lvi1.Text = name;
				lvi1.Name = id;
				listView_gc.Items.Add(lvi1);
			}
		}
	}

	private void listView_gc_MouseClick(object sender, MouseEventArgs e)
	{
		SelectItemList();
	}

	private void listView_gc_ItemActivate(object sender, EventArgs e)
	{
		SelectItemList();
	}

	private void SelectItemList()
	{
		int i = listView_gc.SelectedIndices[0];
		string title = "";
		show_filters show_filters2 = new show_filters();
		show_filters2.textBox_ms.Text = What_ms;
		if (What_gc.Equals("country"))
		{
			show_filters2.textBox_country.Text = listView_gc.Items[i].Name;
			title = "کشور : " + listView_gc.Items[i].Text;
		}
		else if (What_gc.Equals("genre"))
		{
			show_filters2.textBox_genre.Text = listView_gc.Items[i].Name;
			title = "ژانر : " + listView_gc.Items[i].Text;
		}
		if (What_ms.Equals("movie"))
		{
			title = "فیلم های " + title;
		}
		else if (What_ms.Equals("serie"))
		{
			title = "سریال های " + title;
		}
		show_filters2.textBox_order.Text = "NewMovie";
		show_filters2.lable_title.Text = title;
		show_filters2.Show();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.list_genre_country));
		this.textBox_gc_what = new System.Windows.Forms.TextBox();
		this.textBox_ms_what = new System.Windows.Forms.TextBox();
		this.textBox_genre_data = new System.Windows.Forms.TextBox();
		this.listView_gc = new System.Windows.Forms.ListView();
		this.btn_close = new System.Windows.Forms.Button();
		this.label_title = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.textBox_gc_what.Location = new System.Drawing.Point(412, 22);
		this.textBox_gc_what.Name = "textBox_gc_what";
		this.textBox_gc_what.Size = new System.Drawing.Size(100, 20);
		this.textBox_gc_what.TabIndex = 0;
		this.textBox_gc_what.Visible = false;
		this.textBox_ms_what.Location = new System.Drawing.Point(412, 48);
		this.textBox_ms_what.Name = "textBox_ms_what";
		this.textBox_ms_what.Size = new System.Drawing.Size(100, 20);
		this.textBox_ms_what.TabIndex = 1;
		this.textBox_ms_what.Visible = false;
		this.textBox_genre_data.Location = new System.Drawing.Point(412, 74);
		this.textBox_genre_data.Multiline = true;
		this.textBox_genre_data.Name = "textBox_genre_data";
		this.textBox_genre_data.Size = new System.Drawing.Size(100, 26);
		this.textBox_genre_data.TabIndex = 2;
		this.textBox_genre_data.Visible = false;
		this.listView_gc.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		this.listView_gc.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_gc.ForeColor = System.Drawing.Color.White;
		this.listView_gc.Location = new System.Drawing.Point(12, 48);
		this.listView_gc.Name = "listView_gc";
		this.listView_gc.Size = new System.Drawing.Size(379, 320);
		this.listView_gc.TabIndex = 3;
		this.listView_gc.UseCompatibleStateImageBehavior = false;
		this.listView_gc.View = System.Windows.Forms.View.List;
		this.listView_gc.ItemActivate += new System.EventHandler(this.listView_gc_ItemActivate);
		this.listView_gc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_gc_MouseClick);
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 9);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 9;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		this.label_title.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_title.ForeColor = System.Drawing.Color.Yellow;
		this.label_title.Location = new System.Drawing.Point(65, 12);
		this.label_title.Name = "label_title";
		this.label_title.Size = new System.Drawing.Size(325, 29);
		this.label_title.TabIndex = 10;
		this.label_title.Text = "در حال بارگذاری ...";
		this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Purple;
		base.ClientSize = new System.Drawing.Size(403, 376);
		base.Controls.Add(this.label_title);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.listView_gc);
		base.Controls.Add(this.textBox_genre_data);
		base.Controls.Add(this.textBox_ms_what);
		base.Controls.Add(this.textBox_gc_what);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "list_genre_country";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "list_genre_country";
		base.Load += new System.EventHandler(this.list_genre_country_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
