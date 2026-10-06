using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class link_list : Form
{
	private string DataLinks;

	private string PlayOrDownload;

	private string What_ms;

	private string[] SessionLinks;

	private select_player select_player;

	private show_dowload_link show_dowload_link;

	private IContainer components;

	private ComboBox combo_select_session;

	private Label label_select;

	private ListView listView_links;

	public TextBox textBox_links;

	public TextBox textBox_what;

	private Label label2;

	public TextBox textBox_PlayDown;

	private Button btn_close;

	public link_list()
	{
		InitializeComponent();
	}

	private void link_list_Load(object sender, EventArgs e)
	{
		listView_links.View = View.Details;
		listView_links.Columns.Add("قسمت / کیفیت");
		listView_links.Columns.Add("حجم");
		listView_links.Columns[0].Width = 280;
		listView_links.Columns[1].Width = 150;
		listView_links.Columns[0].TextAlign = HorizontalAlignment.Right;
		listView_links.Columns[1].TextAlign = HorizontalAlignment.Right;
		DataLinks = textBox_links.Text;
		What_ms = textBox_what.Text;
		PlayOrDownload = textBox_PlayDown.Text;
		if (DataLinks == null)
		{
			DataLinks = "";
		}
		if (What_ms == null)
		{
			What_ms = "";
		}
		if (What_ms.Equals("1"))
		{
			label_select.Visible = false;
			combo_select_session.Visible = false;
		}
		else if (What_ms.Equals("0"))
		{
			label_select.Visible = true;
			combo_select_session.Visible = true;
		}
		if (DataLinks.Equals(""))
		{
			return;
		}
		if (What_ms.Equals("1"))
		{
			JArray arr_links = JArray.Parse(DataLinks);
			int Len_Json = arr_links.Count;
			for (int i = 0; i < Len_Json; i++)
			{
				string ObjectsArray = arr_links[i].ToString();
				JObject mJsonObject = JObject.Parse(ObjectsArray);
				string link = mJsonObject.GetValue("link").ToString();
				string name = mJsonObject.GetValue("name").ToString();
				string video_size = mJsonObject.GetValue("video_size").ToString();
				ListViewItem lvi1 = new ListViewItem();
				lvi1.Text = name;
				lvi1.Name = link;
				lvi1.SubItems.Add(video_size);
				listView_links.Items.Add(lvi1);
			}
		}
		else
		{
			if (!What_ms.Equals("0"))
			{
				return;
			}
			JArray arr_links2 = JArray.Parse(DataLinks);
			int Len_Json2 = arr_links2.Count;
			SessionLinks = new string[Len_Json2];
			for (int j = 0; j < Len_Json2; j++)
			{
				string ObjectsArray2 = arr_links2[j].ToString();
				JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
				string session_title = mJsonObject2.GetValue("session_title").ToString();
				string links = mJsonObject2.GetValue("links").ToString();
				combo_select_session.Items.Add(session_title);
				SessionLinks[j] = links.ToString();
				if (j == 0)
				{
					combo_select_session.Text = session_title;
					SetDataList(0);
				}
			}
		}
	}

	private void listView_links_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void listView_links_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void ItemSelectList()
	{
		int i = listView_links.SelectedIndices[0];
		string link = listView_links.Items[i].Name;
		string title = listView_links.Items[i].Text;
		if (link == null)
		{
			link = "";
		}
		if (!link.Equals(""))
		{
			if (PlayOrDownload.Equals("Play"))
			{
				try
				{
					if (select_player != null)
					{
						select_player.Close();
					}
				}
				catch (Exception)
				{
				}
				select_player = new select_player();
				select_player.text_play_link.Text = link;
				select_player.label_title.Text = title;
				select_player.Show();
			}
			else
			{
				if (!PlayOrDownload.Equals("Download"))
				{
					return;
				}
				try
				{
					if (show_dowload_link != null)
					{
						show_dowload_link.Close();
					}
				}
				catch (Exception)
				{
				}
				show_dowload_link = new show_dowload_link();
				show_dowload_link.textBox_download_link.Text = link;
				show_dowload_link.label_title.Text = title;
				show_dowload_link.Show();
			}
		}
		else
		{
			MessageBox.Show("لینک کیفیت مورد نظر موجود نیست");
		}
	}

	private void combo_select_session_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = combo_select_session.SelectedText;
		int SelectedIndex = combo_select_session.SelectedIndex;
		SetDataList(SelectedIndex);
	}

	private void SetDataList(int j)
	{
		listView_links.Items.Clear();
		string links = SessionLinks[j];
		if (links == null)
		{
			links = "";
		}
		if (!links.Equals(""))
		{
			JArray arr_links = JArray.Parse(links);
			int Len_Json = arr_links.Count;
			for (int i = 0; i < Len_Json; i++)
			{
				string ObjectsArray = arr_links[i].ToString();
				JObject mJsonObject = JObject.Parse(ObjectsArray);
				string link = mJsonObject.GetValue("link").ToString();
				string name = mJsonObject.GetValue("name").ToString();
				string video_size = mJsonObject.GetValue("video_size").ToString();
				ListViewItem lvi1 = new ListViewItem();
				lvi1.Text = name;
				lvi1.Name = link;
				lvi1.SubItems.Add(video_size);
				listView_links.Items.Add(lvi1);
			}
		}
	}

	private void btn_close_Click(object sender, EventArgs e)
	{
		try
		{
			if (PlayOrDownload.Equals("Play") && select_player != null)
			{
				select_player.Close();
			}
			if (PlayOrDownload.Equals("Download") && show_dowload_link != null)
			{
				show_dowload_link.Close();
			}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.link_list));
		this.combo_select_session = new System.Windows.Forms.ComboBox();
		this.label_select = new System.Windows.Forms.Label();
		this.listView_links = new System.Windows.Forms.ListView();
		this.textBox_links = new System.Windows.Forms.TextBox();
		this.textBox_what = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox_PlayDown = new System.Windows.Forms.TextBox();
		this.btn_close = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.combo_select_session.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.combo_select_session.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.combo_select_session.ForeColor = System.Drawing.Color.White;
		this.combo_select_session.FormattingEnabled = true;
		this.combo_select_session.Location = new System.Drawing.Point(89, 15);
		this.combo_select_session.Name = "combo_select_session";
		this.combo_select_session.Size = new System.Drawing.Size(294, 27);
		this.combo_select_session.TabIndex = 0;
		this.combo_select_session.Visible = false;
		this.combo_select_session.SelectionChangeCommitted += new System.EventHandler(this.combo_select_session_SelectionChangeCommitted);
		this.label_select.AutoSize = true;
		this.label_select.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_select.ForeColor = System.Drawing.Color.White;
		this.label_select.Location = new System.Drawing.Point(389, 18);
		this.label_select.Name = "label_select";
		this.label_select.Size = new System.Drawing.Size(99, 19);
		this.label_select.TabIndex = 1;
		this.label_select.Text = "انتخاب فصل";
		this.label_select.Visible = false;
		this.listView_links.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		this.listView_links.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_links.ForeColor = System.Drawing.Color.White;
		this.listView_links.Location = new System.Drawing.Point(12, 91);
		this.listView_links.Name = "listView_links";
		this.listView_links.Size = new System.Drawing.Size(476, 390);
		this.listView_links.TabIndex = 2;
		this.listView_links.UseCompatibleStateImageBehavior = false;
		this.listView_links.View = System.Windows.Forms.View.Tile;
		this.listView_links.ItemActivate += new System.EventHandler(this.listView_links_ItemActivate);
		this.listView_links.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_links_MouseClick);
		this.textBox_links.Location = new System.Drawing.Point(518, 65);
		this.textBox_links.Multiline = true;
		this.textBox_links.Name = "textBox_links";
		this.textBox_links.Size = new System.Drawing.Size(103, 27);
		this.textBox_links.TabIndex = 3;
		this.textBox_links.Visible = false;
		this.textBox_what.Location = new System.Drawing.Point(518, 20);
		this.textBox_what.Name = "textBox_what";
		this.textBox_what.Size = new System.Drawing.Size(103, 20);
		this.textBox_what.TabIndex = 4;
		this.textBox_what.Visible = false;
		this.label2.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.Yellow;
		this.label2.Location = new System.Drawing.Point(9, 46);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(487, 42);
		this.label2.TabIndex = 5;
		this.label2.Text = "جهت انتخاب قسمت یا کیفیت مورد نظر ، به موارد موجود در ستون سمت چپ کلیک کنید";
		this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.textBox_PlayDown.Location = new System.Drawing.Point(518, 42);
		this.textBox_PlayDown.Name = "textBox_PlayDown";
		this.textBox_PlayDown.Size = new System.Drawing.Size(100, 20);
		this.textBox_PlayDown.TabIndex = 6;
		this.textBox_PlayDown.Visible = false;
		this.btn_close.BackColor = System.Drawing.Color.Red;
		this.btn_close.Image = (System.Drawing.Image)resources.GetObject("btn_close.Image");
		this.btn_close.Location = new System.Drawing.Point(12, 9);
		this.btn_close.Name = "btn_close";
		this.btn_close.Size = new System.Drawing.Size(33, 33);
		this.btn_close.TabIndex = 7;
		this.btn_close.UseVisualStyleBackColor = false;
		this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Purple;
		base.ClientSize = new System.Drawing.Size(498, 490);
		base.Controls.Add(this.btn_close);
		base.Controls.Add(this.textBox_PlayDown);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBox_what);
		base.Controls.Add(this.textBox_links);
		base.Controls.Add(this.listView_links);
		base.Controls.Add(this.label_select);
		base.Controls.Add(this.combo_select_session);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "link_list";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "link_list";
		base.Load += new System.EventHandler(this.link_list_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
