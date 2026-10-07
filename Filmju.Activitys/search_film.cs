using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class search_film : Form
{
	private string SearchKey;

	private AppConfig ac;

	private int page_load_all;

	private ImageList myImageList1;

	private int c_img_list1;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	private Label label1;

	private Panel panel_c;

	private Button btn_search;

	private TextBox textBox_search;

	public ListView list_search_film;

	private Label label_loading;

	private Timer timer1;

	public search_film()
	{
		InitializeComponent();
	}

	private void search_film_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		int Main_Form_Width = Width;
		_ = Height;
		list_search_film.Width = Main_Form_Width;
		ac = new AppConfig();
		SearchKey = "";
		page_load_all = 0;
		c_img_list1 = 0;
		myImageList1 = new ImageList();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		MessageBox.Show("hello");
	}

	private void btn_search_Click(object sender, EventArgs e)
	{
		SearchKey = textBox_search.Text;
		if (SearchKey == null)
		{
			SearchKey = "";
		}
		if (!SearchKey.Equals("") && !SearchKey.Equals(" "))
		{
			page_load_all = 0;
			list_search_film.Items.Clear();
			myImageList1 = new ImageList();
			c_img_list1 = 0;
			timer1.Enabled = true;
		}
		else
		{
			MessageBox.Show("نام فیلم را جهت جستجو وارد کنید");
		}
	}

	private void SetData()
	{
		try
		{
			myImageList1.ColorDepth = ColorDepth.Depth16Bit;
			int page_load = 0;
			if (list_search_film.Items.Count > 0)
			{
				list_search_film.Items[list_search_film.Items.Count - 1].Remove();
				myImageList1.Images.RemoveAt(list_search_film.Items.Count);
			}
			page_load_all++;
			page_load = page_load_all;
			string url = Global.CurrentURL + ac.wiinapVll + Global.keyURL + ac.action_equal + "search&pageno=" + page_load;
			classes myclass = new classes();
			string Args1 = myclass.CreateArgs("q", SearchKey);
			string Args2 = Args1;
			string Data = myclass.PostData(url, Args2);
			JArray all_array = JArray.Parse(Data);
			int Len_Json = all_array.Count;
			myImageList1.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			for (int i = 0; i < Len_Json; i++)
			{
				string ObjectsArray = all_array[i].ToString();
				JObject mJsonObject = JObject.Parse(ObjectsArray);
				string thumbnail_url = mJsonObject.GetValue("thumbnail_url").ToString();
				try
				{
					WebRequest request = WebRequest.Create(thumbnail_url);
					using WebResponse response = request.GetResponse();
					using Stream stream = response.GetResponseStream();
					myImageList1.Images.Add(Image.FromStream(stream));
				}
				catch (Exception)
				{
					myImageList1.Images.Add(Resources.placeholder);
				}
			}
			myImageList1.Images.Add(Resources.loadmore);
			list_search_film.LargeImageList = myImageList1;
			for (int j = 0; j < Len_Json; j++)
			{
				string ObjectsArray2 = all_array[j].ToString();
				JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
				string id = mJsonObject2.GetValue("id").ToString();
				string title = mJsonObject2.GetValue("title").ToString();
				mJsonObject2.GetValue("year").ToString();
				mJsonObject2.GetValue("imdb").ToString();
				list_search_film.Items.Add(id, title, c_img_list1);
				c_img_list1++;
			}
			list_search_film.Items.Add("0", "مشاهده ادامه لیست", c_img_list1);
		}
		catch (Exception)
		{
		}
		ShowLableLoaing("hide");
	}

	private void list_search_film_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void list_search_film_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void ItemSelectList()
	{
		int i = list_search_film.SelectedIndices[0];
		if (list_search_film.Items[i].Name.Equals("0"))
		{
			timer1.Enabled = true;
			return;
		}
		detiles detiles2 = new detiles();
		detiles2.txt_video_id.Text = list_search_film.Items[i].Name.ToString();
		detiles2.Show();
	}

	private void textBox_search_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			btn_search_Click(this, new EventArgs());
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.search_film));
		this.label1 = new System.Windows.Forms.Label();
		this.panel_c = new System.Windows.Forms.Panel();
		this.textBox_search = new System.Windows.Forms.TextBox();
		this.btn_search = new System.Windows.Forms.Button();
		this.list_search_film = new System.Windows.Forms.ListView();
		this.label_loading = new System.Windows.Forms.Label();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel_c.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Yellow;
		this.label1.Location = new System.Drawing.Point(9, 6);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(201, 25);
		this.label1.TabIndex = 1;
		this.label1.Text = "جستجو فیلم و سریال";
		this.panel_c.BackColor = System.Drawing.Color.Indigo;
		this.panel_c.Controls.Add(this.textBox_search);
		this.panel_c.Controls.Add(this.btn_search);
		this.panel_c.Location = new System.Drawing.Point(14, 44);
		this.panel_c.Name = "panel_c";
		this.panel_c.Size = new System.Drawing.Size(451, 42);
		this.panel_c.TabIndex = 6;
		this.textBox_search.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.textBox_search.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_search.ForeColor = System.Drawing.Color.White;
		this.textBox_search.Location = new System.Drawing.Point(122, 7);
		this.textBox_search.Name = "textBox_search";
		this.textBox_search.Size = new System.Drawing.Size(315, 26);
		this.textBox_search.TabIndex = 1;
		this.textBox_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_search_KeyDown);
		this.btn_search.BackColor = System.Drawing.Color.Blue;
		this.btn_search.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_search.ForeColor = System.Drawing.Color.White;
		this.btn_search.Location = new System.Drawing.Point(7, 5);
		this.btn_search.Name = "btn_search";
		this.btn_search.Size = new System.Drawing.Size(96, 32);
		this.btn_search.TabIndex = 0;
		this.btn_search.Text = "جستجو کن";
		this.btn_search.UseVisualStyleBackColor = false;
		this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
		this.list_search_film.BackColor = System.Drawing.Color.DarkSlateGray;
		this.list_search_film.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.list_search_film.ForeColor = System.Drawing.Color.White;
		this.list_search_film.Location = new System.Drawing.Point(14, 91);
		this.list_search_film.Name = "list_search_film";
		this.list_search_film.Size = new System.Drawing.Size(119, 289);
		this.list_search_film.TabIndex = 7;
		this.list_search_film.UseCompatibleStateImageBehavior = false;
		this.list_search_film.ItemActivate += new System.EventHandler(this.list_search_film_ItemActivate);
		this.list_search_film.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_search_film_MouseClick);
		this.label_loading.AutoSize = true;
		this.label_loading.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_loading.ForeColor = System.Drawing.Color.Yellow;
		this.label_loading.Location = new System.Drawing.Point(270, 410);
		this.label_loading.Name = "label_loading";
		this.label_loading.Size = new System.Drawing.Size(195, 25);
		this.label_loading.TabIndex = 8;
		this.label_loading.Text = "در حال بارگذاری ...";
		this.label_loading.Visible = false;
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DarkSlateGray;
		base.ClientSize = new System.Drawing.Size(846, 455);
		base.Controls.Add(this.label_loading);
		base.Controls.Add(this.list_search_film);
		base.Controls.Add(this.panel_c);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "search_film";
		this.Text = "search_film";
		base.Load += new System.EventHandler(this.search_film_Load);
		this.panel_c.ResumeLayout(false);
		this.panel_c.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
