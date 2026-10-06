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

public class show_filters : Form
{
	private AppConfig ac;

	private int page_load_all;

	private string Selected_Genre;

	private string Selected_Country;

	private string Selected_MvoviSerie;

	private string Selected_DubSub;

	private string Selected_Imdb;

	private string Selected_Order;

	private string Selected_Year_From;

	private string Selected_Year_To;

	private ImageList myImageList1 = new ImageList();

	private int c_img_list1;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	private Button btn_back;

	private ListView listView_filter;

	private Timer timer1;

	public TextBox textBox_ms;

	public TextBox textBox_dubsub;

	public TextBox textBox_genre;

	public TextBox textBox_country;

	public TextBox textBox_imdb;

	public TextBox textBox_year_form;

	public TextBox textBox_year_to;

	public TextBox textBox_order;

	public Label lable_title;

	public show_filters()
	{
		InitializeComponent();
	}

	private void show_filters_Load(object sender, EventArgs e)
	{
		Selected_MvoviSerie = textBox_ms.Text;
		Selected_Genre = textBox_genre.Text;
		Selected_Country = textBox_country.Text;
		Selected_DubSub = textBox_dubsub.Text;
		Selected_Imdb = textBox_imdb.Text;
		Selected_Order = textBox_order.Text;
		Selected_Year_From = textBox_year_form.Text;
		Selected_Year_To = textBox_year_to.Text;
		if (Selected_MvoviSerie == null)
		{
			Selected_MvoviSerie = "";
		}
		if (Selected_Genre == null)
		{
			Selected_Genre = "";
		}
		if (Selected_Country == null)
		{
			Selected_Country = "";
		}
		if (Selected_DubSub == null)
		{
			Selected_DubSub = "";
		}
		if (Selected_Imdb == null)
		{
			Selected_Imdb = "";
		}
		if (Selected_Order == null)
		{
			Selected_Order = "";
		}
		if (Selected_Year_From == null)
		{
			Selected_Year_From = "";
		}
		if (Selected_Year_To == null)
		{
			Selected_Year_To = "";
		}
		FormBorderStyle = FormBorderStyle.None;
		MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
		WindowState = FormWindowState.Maximized;
		int Main_Form_Width = Width;
		int Main_Form_Height = Height;
		listView_filter.Width = Main_Form_Width - 15;
		listView_filter.Height = Main_Form_Height - listView_filter.Top - 30;
		int lable_title_width = lable_title.Width;
		int defrent_width = Main_Form_Width - lable_title_width;
		lable_title.Left = defrent_width / 2;
		ac = new AppConfig();
		page_load_all = 0;
		timer1.Enabled = true;
	}

	private void SetData()
	{
		try
		{
			myImageList1.ColorDepth = ColorDepth.Depth16Bit;
			int page_load = 0;
			if (listView_filter.Items.Count > 0)
			{
				listView_filter.Items[listView_filter.Items.Count - 1].Remove();
				myImageList1.Images.RemoveAt(listView_filter.Items.Count);
			}
			page_load_all++;
			page_load = page_load_all;
			string url = Global.CurrentURL + ac.CheckDevice + Global.keyURL + ac.action_equal + "filter_search&pageno=" + page_load;
			classes myclass = new classes();
			string Args1 = myclass.CreateArgs("type", Selected_MvoviSerie);
			string Args2 = myclass.CreateArgs("dub", Selected_DubSub);
			string Args3 = myclass.CreateArgs("genre", Selected_Genre);
			string Args4 = myclass.CreateArgs("country", Selected_Country);
			string Args5 = myclass.CreateArgs("imdb", Selected_Imdb);
			string Args6 = myclass.CreateArgs("sort_by", Selected_Order);
			string Args7 = myclass.CreateArgs("select_dub", Selected_Order);
			string Args8 = myclass.CreateArgs("year_from", Selected_Year_From);
			string Args9 = myclass.CreateArgs("year_to", Selected_Year_To);
			string Args10 = Args1 + "&" + Args2 + "&" + Args3 + "&" + Args4 + "&" + Args5 + "&" + Args6 + "&" + Args7 + "&" + Args8 + "&" + Args9;
			string Data = myclass.PostData(url, Args10);
			JObject obj_all = JObject.Parse(Data);
			string AllVideo = obj_all.GetValue("all").ToString();
			JArray all_array = JArray.Parse(AllVideo);
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
			listView_filter.LargeImageList = myImageList1;
			for (int j = 0; j < Len_Json; j++)
			{
				string ObjectsArray2 = all_array[j].ToString();
				JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
				string id = mJsonObject2.GetValue("videos_id").ToString();
				string title = mJsonObject2.GetValue("title").ToString();
				mJsonObject2.GetValue("thumbnail_url").ToString();
				mJsonObject2.GetValue("imdb").ToString();
				listView_filter.Items.Add(id, title, c_img_list1);
				c_img_list1++;
			}
			listView_filter.Items.Add("0", "مشاهده ادامه لیست", c_img_list1);
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

	private void btn_back_Click(object sender, EventArgs e)
	{
		ShowLableLoaing("hide");
		Close();
	}

	private void listView_filter_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void listView_filter_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void ItemSelectList()
	{
		int i = listView_filter.SelectedIndices[0];
		if (listView_filter.Items[i].Name.Equals("0"))
		{
			timer1.Enabled = true;
			return;
		}
		detiles detiles2 = new detiles();
		detiles2.txt_video_id.Text = listView_filter.Items[i].Name.ToString();
		detiles2.Show();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.show_filters));
		this.btn_back = new System.Windows.Forms.Button();
		this.listView_filter = new System.Windows.Forms.ListView();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.textBox_ms = new System.Windows.Forms.TextBox();
		this.textBox_dubsub = new System.Windows.Forms.TextBox();
		this.textBox_genre = new System.Windows.Forms.TextBox();
		this.textBox_country = new System.Windows.Forms.TextBox();
		this.textBox_imdb = new System.Windows.Forms.TextBox();
		this.textBox_year_form = new System.Windows.Forms.TextBox();
		this.textBox_year_to = new System.Windows.Forms.TextBox();
		this.textBox_order = new System.Windows.Forms.TextBox();
		this.lable_title = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.btn_back.BackColor = System.Drawing.Color.Red;
		this.btn_back.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_back.ForeColor = System.Drawing.Color.Yellow;
		this.btn_back.Image = Filmju.Properties.Resources.back_icon;
		this.btn_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_back.Location = new System.Drawing.Point(12, 12);
		this.btn_back.Name = "btn_back";
		this.btn_back.Size = new System.Drawing.Size(172, 40);
		this.btn_back.TabIndex = 3;
		this.btn_back.Text = "برگشت";
		this.btn_back.UseVisualStyleBackColor = false;
		this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
		this.listView_filter.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_filter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_filter.ForeColor = System.Drawing.Color.White;
		this.listView_filter.Location = new System.Drawing.Point(12, 72);
		this.listView_filter.Name = "listView_filter";
		this.listView_filter.Size = new System.Drawing.Size(246, 278);
		this.listView_filter.TabIndex = 4;
		this.listView_filter.UseCompatibleStateImageBehavior = false;
		this.listView_filter.ItemActivate += new System.EventHandler(this.listView_filter_ItemActivate);
		this.listView_filter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_filter_MouseClick);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		this.textBox_ms.Location = new System.Drawing.Point(542, 72);
		this.textBox_ms.Name = "textBox_ms";
		this.textBox_ms.Size = new System.Drawing.Size(126, 20);
		this.textBox_ms.TabIndex = 5;
		this.textBox_ms.Visible = false;
		this.textBox_dubsub.Location = new System.Drawing.Point(542, 112);
		this.textBox_dubsub.Name = "textBox_dubsub";
		this.textBox_dubsub.Size = new System.Drawing.Size(126, 20);
		this.textBox_dubsub.TabIndex = 6;
		this.textBox_dubsub.Visible = false;
		this.textBox_genre.Location = new System.Drawing.Point(542, 147);
		this.textBox_genre.Name = "textBox_genre";
		this.textBox_genre.Size = new System.Drawing.Size(126, 20);
		this.textBox_genre.TabIndex = 7;
		this.textBox_genre.Visible = false;
		this.textBox_country.Location = new System.Drawing.Point(542, 182);
		this.textBox_country.Name = "textBox_country";
		this.textBox_country.Size = new System.Drawing.Size(126, 20);
		this.textBox_country.TabIndex = 8;
		this.textBox_country.Visible = false;
		this.textBox_imdb.Location = new System.Drawing.Point(542, 219);
		this.textBox_imdb.Name = "textBox_imdb";
		this.textBox_imdb.Size = new System.Drawing.Size(126, 20);
		this.textBox_imdb.TabIndex = 9;
		this.textBox_imdb.Visible = false;
		this.textBox_year_form.Location = new System.Drawing.Point(542, 261);
		this.textBox_year_form.Name = "textBox_year_form";
		this.textBox_year_form.Size = new System.Drawing.Size(126, 20);
		this.textBox_year_form.TabIndex = 10;
		this.textBox_year_form.Visible = false;
		this.textBox_year_to.Location = new System.Drawing.Point(542, 301);
		this.textBox_year_to.Name = "textBox_year_to";
		this.textBox_year_to.Size = new System.Drawing.Size(126, 20);
		this.textBox_year_to.TabIndex = 11;
		this.textBox_year_to.Visible = false;
		this.textBox_order.Location = new System.Drawing.Point(542, 336);
		this.textBox_order.Name = "textBox_order";
		this.textBox_order.Size = new System.Drawing.Size(126, 20);
		this.textBox_order.TabIndex = 12;
		this.textBox_order.Visible = false;
		this.lable_title.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lable_title.ForeColor = System.Drawing.Color.Yellow;
		this.lable_title.Location = new System.Drawing.Point(212, 13);
		this.lable_title.Name = "lable_title";
		this.lable_title.Size = new System.Drawing.Size(393, 38);
		this.lable_title.TabIndex = 13;
		this.lable_title.Text = "در حال بارگذاری ...";
		this.lable_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DarkSlateGray;
		base.ClientSize = new System.Drawing.Size(746, 498);
		base.Controls.Add(this.lable_title);
		base.Controls.Add(this.textBox_order);
		base.Controls.Add(this.textBox_year_to);
		base.Controls.Add(this.textBox_year_form);
		base.Controls.Add(this.textBox_imdb);
		base.Controls.Add(this.textBox_country);
		base.Controls.Add(this.textBox_genre);
		base.Controls.Add(this.textBox_dubsub);
		base.Controls.Add(this.textBox_ms);
		base.Controls.Add(this.listView_filter);
		base.Controls.Add(this.btn_back);
		this.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "show_filters";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "show_filters";
		base.Load += new System.EventHandler(this.show_filters_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
