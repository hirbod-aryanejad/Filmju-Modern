using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class vitrin : Form
{
	private AppConfig ac;

	private string NewMovieAndSerieYear;

	private string Tlg_Support;

	private string Tlg_Channel;

	private string Insta_Channel;

	private string link_des;

	private string link_des_title;

	private ImageList myImageList1 = new ImageList();

	private ImageList myImageList_ns = new ImageList();

	private ImageList myImageList_ups = new ImageList();

	private int c_img_list1;

	private int c_img_list_ns;

	private int c_img_list_ups;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	private Label label1;

	private Button btn_more_new_movie;

	private Button btn_link;

	private Button btn_instagram;

	private Button btn_tlg_support;

	private Button btn_tlg_channel;

	public Panel panel_des;

	public Panel panel_des_btns;

	public Label label_des;

	public Panel panel_new_cinema;

	public ListView listView_new_cinema;

	public Panel panel_updated_serie;

	private Button btn_more_updated_serie;

	public ListView listView_updated_serie;

	public Panel panel_new_serie;

	private Button btn_more_new_serie;

	public ListView listView_new_serie;

	public Label label_new_cinema;

	public Label label_new_serie;

	public Label label_updated_serie;

	private Timer timer1;

	public vitrin()
	{
		InitializeComponent();
	}

	private void vitrin_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		_ = Width;
		_ = Height;
		ac = new AppConfig();
		listView_new_cinema.Alignment = ListViewAlignment.Left;
		listView_new_cinema.Height = ac.ItemVideoImgSizeHeight + 80;
		panel_new_cinema.Height = ac.ItemVideoImgSizeHeight + 140;
		listView_new_serie.Alignment = ListViewAlignment.Left;
		listView_new_serie.Height = ac.ItemVideoImgSizeHeight + 80;
		panel_new_serie.Height = ac.ItemVideoImgSizeHeight + 140;
		listView_updated_serie.Alignment = ListViewAlignment.Left;
		listView_updated_serie.Height = ac.ItemVideoImgSizeHeight + 80;
		panel_updated_serie.Height = ac.ItemVideoImgSizeHeight + 140;
		timer1.Enabled = true;
	}

	private void SetData()
	{
		try
		{
			myImageList1.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_ns.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_ups.ColorDepth = ColorDepth.Depth16Bit;
			string url = Global.ULPdisjskfdlkf + ac.CheckDevice + Global.Psdiuisdufscds + ac.key5548112 + "vitrin";
			classes myclass = new classes();
			string Args = "";
			string Data = myclass.PostData(url, Args);
			JObject obj_all = JObject.Parse(Data);
			string NewMovie = obj_all.GetValue("NewMovie").ToString();
			string NewSerie = obj_all.GetValue("NewSerie").ToString();
			string updated_serie = obj_all.GetValue("updated_serie").ToString();
			string messages = obj_all.GetValue("messages").ToString();
			NewMovieAndSerieYear = obj_all.GetValue("NewMovieAndSerieYear").ToString();
			string sosial_ids = obj_all.GetValue("sosial_ids").ToString();
			label_new_cinema.Text = "سینمایی های " + NewMovieAndSerieYear;
			label_new_serie.Text = "سریال های " + NewMovieAndSerieYear;
			JArray all_array_des = JArray.Parse(messages);
			string ObjectsArray_des = all_array_des[0].ToString();
			JObject mJsonObject_des = JObject.Parse(ObjectsArray_des);
			string text_des = mJsonObject_des.GetValue("text_des").ToString();
			link_des = mJsonObject_des.GetValue("link_des").ToString();
			link_des_title = mJsonObject_des.GetValue("link_des_title").ToString();
			label_des.Text = text_des;
			if (link_des == null)
			{
				link_des = "";
			}
			if (!link_des.Equals(""))
			{
				btn_link.Visible = true;
				btn_link.Text = link_des_title;
			}
			JArray all_array_sosial_ids = JArray.Parse(sosial_ids);
			string ObjectsArray_sosial_ids = all_array_sosial_ids[0].ToString();
			JObject mJsonObject_sosial_ids = JObject.Parse(ObjectsArray_sosial_ids);
			Tlg_Channel = mJsonObject_sosial_ids.GetValue("tlg_id").ToString();
			Insta_Channel = mJsonObject_sosial_ids.GetValue("insta_id").ToString();
			Tlg_Support = mJsonObject_sosial_ids.GetValue("tlg_support").ToString();
			JArray all_array = JArray.Parse(NewMovie);
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
			listView_new_cinema.LargeImageList = myImageList1;
			for (int j = 0; j < Len_Json; j++)
			{
				string ObjectsArray2 = all_array[j].ToString();
				JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
				string id = mJsonObject2.GetValue("id").ToString();
				string title = mJsonObject2.GetValue("title").ToString();
				mJsonObject2.GetValue("thumbnail_url").ToString();
				mJsonObject2.GetValue("imdb").ToString();
				listView_new_cinema.Items.Add(id, title, c_img_list1);
				c_img_list1++;
			}
			JArray all_array_ns = JArray.Parse(NewSerie);
			int Len_Json_ns = all_array_ns.Count;
			myImageList_ns.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			for (int k = 0; k < Len_Json_ns; k++)
			{
				string ObjectsArray3 = all_array_ns[k].ToString();
				JObject mJsonObject3 = JObject.Parse(ObjectsArray3);
				string thumbnail_url2 = mJsonObject3.GetValue("thumbnail_url").ToString();
				try
				{
					WebRequest request2 = WebRequest.Create(thumbnail_url2);
					using WebResponse response2 = request2.GetResponse();
					using Stream stream2 = response2.GetResponseStream();
					myImageList_ns.Images.Add(Image.FromStream(stream2));
				}
				catch (Exception)
				{
					myImageList_ns.Images.Add(Resources.placeholder);
				}
			}
			listView_new_serie.LargeImageList = myImageList_ns;
			for (int l = 0; l < Len_Json_ns; l++)
			{
				string ObjectsArray4 = all_array_ns[l].ToString();
				JObject mJsonObject4 = JObject.Parse(ObjectsArray4);
				string id2 = mJsonObject4.GetValue("id").ToString();
				string title2 = mJsonObject4.GetValue("title").ToString();
				mJsonObject4.GetValue("thumbnail_url").ToString();
				mJsonObject4.GetValue("imdb").ToString();
				listView_new_serie.Items.Add(id2, title2, c_img_list_ns);
				c_img_list_ns++;
			}
			JArray all_array_ups = JArray.Parse(updated_serie);
			int Len_Json_ups = all_array_ups.Count;
			myImageList_ups.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			for (int m = 0; m < Len_Json_ups; m++)
			{
				string ObjectsArray5 = all_array_ups[m].ToString();
				JObject mJsonObject5 = JObject.Parse(ObjectsArray5);
				string thumbnail_url3 = mJsonObject5.GetValue("thumbnail_url").ToString();
				try
				{
					WebRequest request3 = WebRequest.Create(thumbnail_url3);
					using WebResponse response3 = request3.GetResponse();
					using Stream stream3 = response3.GetResponseStream();
					myImageList_ups.Images.Add(Image.FromStream(stream3));
				}
				catch (Exception)
				{
					myImageList_ups.Images.Add(Resources.placeholder);
				}
			}
			listView_updated_serie.LargeImageList = myImageList_ups;
			for (int n = 0; n < Len_Json_ups; n++)
			{
				string ObjectsArray6 = all_array_ups[n].ToString();
				JObject mJsonObject6 = JObject.Parse(ObjectsArray6);
				string id3 = mJsonObject6.GetValue("id").ToString();
				string title3 = mJsonObject6.GetValue("title").ToString();
				mJsonObject6.GetValue("thumbnail_url").ToString();
				mJsonObject6.GetValue("imdb").ToString();
				listView_updated_serie.Items.Add(id3, title3, c_img_list_ups);
				c_img_list_ups++;
			}
			btn_instagram.Enabled = true;
			btn_tlg_channel.Enabled = true;
			btn_tlg_support.Enabled = true;
		}
		catch (Exception)
		{
		}
		ShowLableLoaing("hide");
	}

	private void ItemSelectList(string name_list)
	{
		if (name_list.Equals("NewMovie"))
		{
			int i = listView_new_cinema.SelectedIndices[0];
			detiles detiles2 = new detiles();
			detiles2.txt_video_id.Text = listView_new_cinema.Items[i].Name.ToString();
			detiles2.Show();
		}
		else if (name_list.Equals("NewSerie"))
		{
			int i2 = listView_new_serie.SelectedIndices[0];
			detiles detiles3 = new detiles();
			detiles3.txt_video_id.Text = listView_new_serie.Items[i2].Name.ToString();
			detiles3.Show();
		}
		else if (name_list.Equals("UpdatedSerie"))
		{
			int i3 = listView_updated_serie.SelectedIndices[0];
			detiles detiles4 = new detiles();
			detiles4.txt_video_id.Text = listView_updated_serie.Items[i3].Name.ToString();
			detiles4.Show();
		}
	}

	private void listView_new_cinema_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList("NewMovie");
	}

	private void listView_new_cinema_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList("NewMovie");
	}

	private void listView_new_serie_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList("NewSerie");
	}

	private void listView_new_serie_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList("NewSerie");
	}

	private void listView_updated_serie_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList("UpdatedSerie");
	}

	private void listView_updated_serie_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList("UpdatedSerie");
	}

	private void btn_more_new_movie_Click(object sender, EventArgs e)
	{
		if (NewMovieAndSerieYear == null)
		{
			NewMovieAndSerieYear = "";
		}
		show_filters show_filters2 = new show_filters();
		show_filters2.textBox_ms.Text = "movie";
		show_filters2.textBox_year_form.Text = NewMovieAndSerieYear;
		show_filters2.textBox_year_to.Text = NewMovieAndSerieYear;
		show_filters2.textBox_order.Text = "NewMovie";
		show_filters2.lable_title.Text = "سینمایی های " + NewMovieAndSerieYear;
		show_filters2.Show();
	}

	private void btn_more_new_serie_Click(object sender, EventArgs e)
	{
		if (NewMovieAndSerieYear == null)
		{
			NewMovieAndSerieYear = "";
		}
		show_filters show_filters2 = new show_filters();
		show_filters2.textBox_ms.Text = "serie";
		show_filters2.textBox_year_form.Text = NewMovieAndSerieYear;
		show_filters2.textBox_year_to.Text = NewMovieAndSerieYear;
		show_filters2.textBox_order.Text = "NewMovie";
		show_filters2.lable_title.Text = "سریال های " + NewMovieAndSerieYear;
		show_filters2.Show();
	}

	private void btn_more_updated_serie_Click(object sender, EventArgs e)
	{
		if (NewMovieAndSerieYear == null)
		{
			NewMovieAndSerieYear = "";
		}
		show_filters show_filters2 = new show_filters();
		show_filters2.textBox_ms.Text = "serie";
		show_filters2.textBox_order.Text = "LastUpdatedSerie";
		show_filters2.lable_title.Text = "سریال های بروز شده";
		show_filters2.Show();
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

	private void btn_tlg_support_Click(object sender, EventArgs e)
	{
		if (Tlg_Support == null)
		{
			Tlg_Support = "";
		}
		if (!Tlg_Support.Equals(""))
		{
			Process.Start(Tlg_Support);
		}
		else
		{
			MessageBox.Show("آیدی پشتیبانی هنوز وارد نشده است");
		}
	}

	private void btn_tlg_channel_Click(object sender, EventArgs e)
	{
		if (Tlg_Channel == null)
		{
			Tlg_Channel = "";
		}
		if (!Tlg_Channel.Equals(""))
		{
			Process.Start(Tlg_Channel);
		}
		else
		{
			MessageBox.Show("کانال تلگرام هنوز وارد نشده است");
		}
	}

	private void btn_instagram_Click(object sender, EventArgs e)
	{
		if (Insta_Channel == null)
		{
			Insta_Channel = "";
		}
		if (!Insta_Channel.Equals(""))
		{
			Process.Start(Insta_Channel);
		}
		else
		{
			MessageBox.Show("پیج اینستاگرام هنوز وارد نشده است");
		}
	}

	private void btn_link_Click(object sender, EventArgs e)
	{
		if (link_des == null)
		{
			link_des = "";
		}
		if (!link_des.Equals(""))
		{
			Process.Start(link_des);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.vitrin));
		this.panel_new_cinema = new System.Windows.Forms.Panel();
		this.btn_more_new_movie = new System.Windows.Forms.Button();
		this.listView_new_cinema = new System.Windows.Forms.ListView();
		this.label_new_cinema = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.panel_des = new System.Windows.Forms.Panel();
		this.panel_des_btns = new System.Windows.Forms.Panel();
		this.btn_link = new System.Windows.Forms.Button();
		this.btn_instagram = new System.Windows.Forms.Button();
		this.btn_tlg_support = new System.Windows.Forms.Button();
		this.btn_tlg_channel = new System.Windows.Forms.Button();
		this.label_des = new System.Windows.Forms.Label();
		this.panel_updated_serie = new System.Windows.Forms.Panel();
		this.btn_more_updated_serie = new System.Windows.Forms.Button();
		this.listView_updated_serie = new System.Windows.Forms.ListView();
		this.label_updated_serie = new System.Windows.Forms.Label();
		this.panel_new_serie = new System.Windows.Forms.Panel();
		this.btn_more_new_serie = new System.Windows.Forms.Button();
		this.listView_new_serie = new System.Windows.Forms.ListView();
		this.label_new_serie = new System.Windows.Forms.Label();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel_new_cinema.SuspendLayout();
		this.panel_des.SuspendLayout();
		this.panel_des_btns.SuspendLayout();
		this.panel_updated_serie.SuspendLayout();
		this.panel_new_serie.SuspendLayout();
		base.SuspendLayout();
		this.panel_new_cinema.BackColor = System.Drawing.SystemColors.GrayText;
		this.panel_new_cinema.Controls.Add(this.btn_more_new_movie);
		this.panel_new_cinema.Controls.Add(this.listView_new_cinema);
		this.panel_new_cinema.Controls.Add(this.label_new_cinema);
		this.panel_new_cinema.Location = new System.Drawing.Point(14, 277);
		this.panel_new_cinema.Name = "panel_new_cinema";
		this.panel_new_cinema.Size = new System.Drawing.Size(677, 294);
		this.panel_new_cinema.TabIndex = 2;
		this.btn_more_new_movie.BackColor = System.Drawing.Color.Green;
		this.btn_more_new_movie.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_more_new_movie.ForeColor = System.Drawing.Color.White;
		this.btn_more_new_movie.Location = new System.Drawing.Point(16, 9);
		this.btn_more_new_movie.Name = "btn_more_new_movie";
		this.btn_more_new_movie.Size = new System.Drawing.Size(135, 30);
		this.btn_more_new_movie.TabIndex = 4;
		this.btn_more_new_movie.Text = "مشاهده بیشتر";
		this.btn_more_new_movie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_more_new_movie.UseVisualStyleBackColor = false;
		this.btn_more_new_movie.Click += new System.EventHandler(this.btn_more_new_movie_Click);
		this.listView_new_cinema.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_new_cinema.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.listView_new_cinema.ForeColor = System.Drawing.Color.White;
		this.listView_new_cinema.Location = new System.Drawing.Point(16, 43);
		this.listView_new_cinema.Name = "listView_new_cinema";
		this.listView_new_cinema.Size = new System.Drawing.Size(649, 234);
		this.listView_new_cinema.TabIndex = 3;
		this.listView_new_cinema.UseCompatibleStateImageBehavior = false;
		this.listView_new_cinema.ItemActivate += new System.EventHandler(this.listView_new_cinema_ItemActivate);
		this.listView_new_cinema.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_new_cinema_MouseClick);
		this.label_new_cinema.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_new_cinema.ForeColor = System.Drawing.Color.Yellow;
		this.label_new_cinema.Location = new System.Drawing.Point(445, 16);
		this.label_new_cinema.Name = "label_new_cinema";
		this.label_new_cinema.Size = new System.Drawing.Size(220, 23);
		this.label_new_cinema.TabIndex = 2;
		this.label_new_cinema.Text = "سینمایی های";
		this.label_new_cinema.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Yellow;
		this.label1.Location = new System.Drawing.Point(9, 6);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(65, 25);
		this.label1.TabIndex = 3;
		this.label1.Text = "ویترین";
		this.panel_des.BackColor = System.Drawing.Color.DarkSlateGray;
		this.panel_des.Controls.Add(this.panel_des_btns);
		this.panel_des.Controls.Add(this.label_des);
		this.panel_des.Location = new System.Drawing.Point(13, 39);
		this.panel_des.Name = "panel_des";
		this.panel_des.Size = new System.Drawing.Size(740, 201);
		this.panel_des.TabIndex = 4;
		this.panel_des_btns.Controls.Add(this.btn_link);
		this.panel_des_btns.Controls.Add(this.btn_instagram);
		this.panel_des_btns.Controls.Add(this.btn_tlg_support);
		this.panel_des_btns.Controls.Add(this.btn_tlg_channel);
		this.panel_des_btns.Location = new System.Drawing.Point(110, 106);
		this.panel_des_btns.Name = "panel_des_btns";
		this.panel_des_btns.Size = new System.Drawing.Size(534, 92);
		this.panel_des_btns.TabIndex = 4;
		this.btn_link.BackColor = System.Drawing.Color.Green;
		this.btn_link.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_link.ForeColor = System.Drawing.Color.White;
		this.btn_link.Location = new System.Drawing.Point(170, 8);
		this.btn_link.Name = "btn_link";
		this.btn_link.Size = new System.Drawing.Size(191, 34);
		this.btn_link.TabIndex = 8;
		this.btn_link.Text = "ورود به لینک";
		this.btn_link.UseVisualStyleBackColor = false;
		this.btn_link.Visible = false;
		this.btn_link.Click += new System.EventHandler(this.btn_link_Click);
		this.btn_instagram.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.btn_instagram.Enabled = false;
		this.btn_instagram.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_instagram.ForeColor = System.Drawing.Color.White;
		this.btn_instagram.Location = new System.Drawing.Point(44, 49);
		this.btn_instagram.Name = "btn_instagram";
		this.btn_instagram.Size = new System.Drawing.Size(136, 34);
		this.btn_instagram.TabIndex = 6;
		this.btn_instagram.Text = "پیج اینستاگرام";
		this.btn_instagram.UseVisualStyleBackColor = false;
		this.btn_instagram.Click += new System.EventHandler(this.btn_instagram_Click);
		this.btn_tlg_support.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.btn_tlg_support.Enabled = false;
		this.btn_tlg_support.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_tlg_support.ForeColor = System.Drawing.Color.White;
		this.btn_tlg_support.Location = new System.Drawing.Point(352, 49);
		this.btn_tlg_support.Name = "btn_tlg_support";
		this.btn_tlg_support.Size = new System.Drawing.Size(136, 34);
		this.btn_tlg_support.TabIndex = 5;
		this.btn_tlg_support.Text = "پشتیبان تلگرام";
		this.btn_tlg_support.UseVisualStyleBackColor = false;
		this.btn_tlg_support.Click += new System.EventHandler(this.btn_tlg_support_Click);
		this.btn_tlg_channel.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.btn_tlg_channel.Enabled = false;
		this.btn_tlg_channel.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_tlg_channel.ForeColor = System.Drawing.Color.White;
		this.btn_tlg_channel.Location = new System.Drawing.Point(200, 49);
		this.btn_tlg_channel.Name = "btn_tlg_channel";
		this.btn_tlg_channel.Size = new System.Drawing.Size(133, 34);
		this.btn_tlg_channel.TabIndex = 4;
		this.btn_tlg_channel.Text = "کانال تلگرام";
		this.btn_tlg_channel.UseVisualStyleBackColor = false;
		this.btn_tlg_channel.Click += new System.EventHandler(this.btn_tlg_channel_Click);
		this.label_des.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_des.ForeColor = System.Drawing.Color.White;
		this.label_des.Location = new System.Drawing.Point(17, 15);
		this.label_des.Name = "label_des";
		this.label_des.Size = new System.Drawing.Size(706, 88);
		this.label_des.TabIndex = 2;
		this.label_des.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.panel_updated_serie.BackColor = System.Drawing.SystemColors.GrayText;
		this.panel_updated_serie.Controls.Add(this.btn_more_updated_serie);
		this.panel_updated_serie.Controls.Add(this.listView_updated_serie);
		this.panel_updated_serie.Controls.Add(this.label_updated_serie);
		this.panel_updated_serie.Location = new System.Drawing.Point(14, 996);
		this.panel_updated_serie.Name = "panel_updated_serie";
		this.panel_updated_serie.Size = new System.Drawing.Size(677, 294);
		this.panel_updated_serie.TabIndex = 5;
		this.btn_more_updated_serie.BackColor = System.Drawing.Color.Green;
		this.btn_more_updated_serie.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_more_updated_serie.ForeColor = System.Drawing.Color.White;
		this.btn_more_updated_serie.Location = new System.Drawing.Point(16, 9);
		this.btn_more_updated_serie.Name = "btn_more_updated_serie";
		this.btn_more_updated_serie.Size = new System.Drawing.Size(135, 30);
		this.btn_more_updated_serie.TabIndex = 4;
		this.btn_more_updated_serie.Text = "مشاهده بیشتر";
		this.btn_more_updated_serie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_more_updated_serie.UseVisualStyleBackColor = false;
		this.btn_more_updated_serie.Click += new System.EventHandler(this.btn_more_updated_serie_Click);
		this.listView_updated_serie.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_updated_serie.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.listView_updated_serie.ForeColor = System.Drawing.Color.White;
		this.listView_updated_serie.Location = new System.Drawing.Point(16, 43);
		this.listView_updated_serie.Name = "listView_updated_serie";
		this.listView_updated_serie.Size = new System.Drawing.Size(649, 234);
		this.listView_updated_serie.TabIndex = 3;
		this.listView_updated_serie.UseCompatibleStateImageBehavior = false;
		this.listView_updated_serie.ItemActivate += new System.EventHandler(this.listView_updated_serie_ItemActivate);
		this.listView_updated_serie.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_updated_serie_MouseClick);
		this.label_updated_serie.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_updated_serie.ForeColor = System.Drawing.Color.Yellow;
		this.label_updated_serie.Location = new System.Drawing.Point(445, 16);
		this.label_updated_serie.Name = "label_updated_serie";
		this.label_updated_serie.Size = new System.Drawing.Size(220, 23);
		this.label_updated_serie.TabIndex = 2;
		this.label_updated_serie.Text = "سریال های بروز شده";
		this.label_updated_serie.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.panel_new_serie.BackColor = System.Drawing.SystemColors.GrayText;
		this.panel_new_serie.Controls.Add(this.btn_more_new_serie);
		this.panel_new_serie.Controls.Add(this.listView_new_serie);
		this.panel_new_serie.Controls.Add(this.label_new_serie);
		this.panel_new_serie.Location = new System.Drawing.Point(14, 633);
		this.panel_new_serie.Name = "panel_new_serie";
		this.panel_new_serie.Size = new System.Drawing.Size(677, 294);
		this.panel_new_serie.TabIndex = 6;
		this.btn_more_new_serie.BackColor = System.Drawing.Color.Green;
		this.btn_more_new_serie.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_more_new_serie.ForeColor = System.Drawing.Color.White;
		this.btn_more_new_serie.Location = new System.Drawing.Point(16, 9);
		this.btn_more_new_serie.Name = "btn_more_new_serie";
		this.btn_more_new_serie.Size = new System.Drawing.Size(135, 30);
		this.btn_more_new_serie.TabIndex = 4;
		this.btn_more_new_serie.Text = "مشاهده بیشتر";
		this.btn_more_new_serie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btn_more_new_serie.UseVisualStyleBackColor = false;
		this.btn_more_new_serie.Click += new System.EventHandler(this.btn_more_new_serie_Click);
		this.listView_new_serie.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_new_serie.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.listView_new_serie.ForeColor = System.Drawing.Color.White;
		this.listView_new_serie.Location = new System.Drawing.Point(16, 43);
		this.listView_new_serie.Name = "listView_new_serie";
		this.listView_new_serie.Size = new System.Drawing.Size(649, 234);
		this.listView_new_serie.TabIndex = 3;
		this.listView_new_serie.UseCompatibleStateImageBehavior = false;
		this.listView_new_serie.ItemActivate += new System.EventHandler(this.listView_new_serie_ItemActivate);
		this.listView_new_serie.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_new_serie_MouseClick);
		this.label_new_serie.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_new_serie.ForeColor = System.Drawing.Color.Yellow;
		this.label_new_serie.Location = new System.Drawing.Point(445, 16);
		this.label_new_serie.Name = "label_new_serie";
		this.label_new_serie.Size = new System.Drawing.Size(220, 23);
		this.label_new_serie.TabIndex = 2;
		this.label_new_serie.Text = "سریال های";
		this.label_new_serie.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		base.ClientSize = new System.Drawing.Size(802, 465);
		base.Controls.Add(this.panel_new_serie);
		base.Controls.Add(this.panel_updated_serie);
		base.Controls.Add(this.panel_des);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.panel_new_cinema);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "vitrin";
		this.Text = "vitrin";
		base.Load += new System.EventHandler(this.vitrin_Load);
		this.panel_new_cinema.ResumeLayout(false);
		this.panel_des.ResumeLayout(false);
		this.panel_des_btns.ResumeLayout(false);
		this.panel_updated_serie.ResumeLayout(false);
		this.panel_new_serie.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
