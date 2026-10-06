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

public class fave_list : Form
{
	private AppConfig ac;

	private string Selected_Tab;

	private ImageList myImageList_cinema = new ImageList();

	private ImageList myImageList_serie = new ImageList();

	private int c_img_cinema;

	private int c_img_serie;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	public ListView list_fave_serie;

	private Panel panel_c;

	private Button btnc_fave_serie;

	private Button btnc_fave_cinema;

	private Label label_loading;

	public ListView list_fave_cinema;

	private Label label_title;

	private Timer timer1;

	private Panel panel1;

	private Button btn_reload;

	public fave_list()
	{
		InitializeComponent();
	}

	private void fave_list_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		ac = new AppConfig();
		Selected_Tab = "cinema";
		int Main_Form_Width = Width;
		_ = Height;
		list_fave_cinema.Width = Main_Form_Width;
		if (Global.user_name_config == null)
		{
			Global.user_name_config = "";
		}
		if (!Global.user_name_config.Equals(""))
		{
			timer1.Enabled = true;
		}
	}

	private void SetData()
	{
		try
		{
			myImageList_cinema.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_serie.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_cinema.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			myImageList_serie.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			string url = Global.CurrentURL + ac.CheckDevice + Global.keyURL + ac.action_equal + "show-faves";
			classes myclass = new classes();
			string Args = "";
			string Data = myclass.PostData(url, Args);
			if (Data == null)
			{
				Data = "";
			}
			if (!Data.Equals(""))
			{
				JArray all_array = JArray.Parse(Data);
				int Len_Json = all_array.Count;
				for (int i = 0; i < Len_Json; i++)
				{
					string ObjectsArray = all_array[i].ToString();
					JObject mJsonObject = JObject.Parse(ObjectsArray);
					string thumbnail_url = mJsonObject.GetValue("thumbnail_url").ToString();
					string is_movie = mJsonObject.GetValue("is_movie").ToString();
					try
					{
						WebRequest request = WebRequest.Create(thumbnail_url);
						using WebResponse response = request.GetResponse();
						using Stream stream = response.GetResponseStream();
						if (is_movie.Equals("1"))
						{
							myImageList_cinema.Images.Add(Image.FromStream(stream));
						}
						else if (is_movie.Equals("0"))
						{
							myImageList_serie.Images.Add(Image.FromStream(stream));
						}
					}
					catch (Exception)
					{
						if (is_movie.Equals("1"))
						{
							myImageList_cinema.Images.Add(Resources.placeholder);
						}
						else if (is_movie.Equals("0"))
						{
							myImageList_serie.Images.Add(Resources.placeholder);
						}
					}
				}
				list_fave_cinema.LargeImageList = myImageList_cinema;
				list_fave_serie.LargeImageList = myImageList_serie;
				for (int j = 0; j < Len_Json; j++)
				{
					string ObjectsArray2 = all_array[j].ToString();
					JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
					string id = mJsonObject2.GetValue("id").ToString();
					string title = mJsonObject2.GetValue("title").ToString();
					mJsonObject2.GetValue("thumbnail_url").ToString();
					string is_movie2 = mJsonObject2.GetValue("is_movie").ToString();
					if (is_movie2.Equals("1"))
					{
						list_fave_cinema.Items.Add(id, title, c_img_cinema);
						c_img_cinema++;
					}
					else if (is_movie2.Equals("0"))
					{
						list_fave_serie.Items.Add(id, title, c_img_serie);
						c_img_serie++;
					}
				}
			}
			btnc_fave_cinema.Enabled = true;
			btnc_fave_serie.Enabled = true;
			btn_reload.Enabled = true;
		}
		catch (Exception)
		{
		}
		ShowLableLoaing("hide");
	}

	private void btnc_fave_cinema_Click(object sender, EventArgs e)
	{
		Selected_Tab = "cinema";
		MenuSelectorCat("cinema");
	}

	private void btnc_fave_serie_Click(object sender, EventArgs e)
	{
		Selected_Tab = "serie";
		MenuSelectorCat("serie");
	}

	private void MenuSelectorCat(string Itemo)
	{
		if (Itemo == "cinema")
		{
			btnc_fave_cinema.BackColor = Color.DeepSkyBlue;
			btnc_fave_serie.BackColor = Color.Wheat;
			list_fave_cinema.Visible = true;
			list_fave_serie.Visible = false;
			label_title.Text = "علاقه مندی ها (سینمایی)";
		}
		else if (Itemo == "serie")
		{
			btnc_fave_cinema.BackColor = Color.Wheat;
			btnc_fave_serie.BackColor = Color.DeepSkyBlue;
			list_fave_cinema.Visible = false;
			list_fave_serie.Visible = true;
			label_title.Text = "علاقه مندی ها (سریال)";
		}
	}

	private void list_fave_cinema_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void list_fave_cinema_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void list_fave_serie_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void list_fave_serie_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void ItemSelectList()
	{
		if (Selected_Tab.Equals("cinema"))
		{
			int i = list_fave_cinema.SelectedIndices[0];
			detiles detiles2 = new detiles();
			detiles2.txt_video_id.Text = list_fave_cinema.Items[i].Name.ToString();
			detiles2.Show();
		}
		else if (Selected_Tab.Equals("serie"))
		{
			int i2 = list_fave_serie.SelectedIndices[0];
			detiles detiles3 = new detiles();
			detiles3.txt_video_id.Text = list_fave_serie.Items[i2].Name.ToString();
			detiles3.Show();
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

	private void btn_reload_Click(object sender, EventArgs e)
	{
		list_fave_cinema.Items.Clear();
		list_fave_serie.Items.Clear();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.fave_list));
		this.list_fave_serie = new System.Windows.Forms.ListView();
		this.panel_c = new System.Windows.Forms.Panel();
		this.btnc_fave_serie = new System.Windows.Forms.Button();
		this.btnc_fave_cinema = new System.Windows.Forms.Button();
		this.label_loading = new System.Windows.Forms.Label();
		this.list_fave_cinema = new System.Windows.Forms.ListView();
		this.label_title = new System.Windows.Forms.Label();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel1 = new System.Windows.Forms.Panel();
		this.btn_reload = new System.Windows.Forms.Button();
		this.panel_c.SuspendLayout();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.list_fave_serie.BackColor = System.Drawing.Color.DarkSlateGray;
		this.list_fave_serie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.list_fave_serie.ForeColor = System.Drawing.Color.White;
		this.list_fave_serie.Location = new System.Drawing.Point(151, 92);
		this.list_fave_serie.Name = "list_fave_serie";
		this.list_fave_serie.Size = new System.Drawing.Size(101, 289);
		this.list_fave_serie.TabIndex = 11;
		this.list_fave_serie.UseCompatibleStateImageBehavior = false;
		this.list_fave_serie.Visible = false;
		this.list_fave_serie.ItemActivate += new System.EventHandler(this.list_fave_serie_ItemActivate);
		this.list_fave_serie.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_fave_serie_MouseClick);
		this.panel_c.BackColor = System.Drawing.Color.Indigo;
		this.panel_c.Controls.Add(this.btnc_fave_serie);
		this.panel_c.Controls.Add(this.btnc_fave_cinema);
		this.panel_c.Location = new System.Drawing.Point(473, 39);
		this.panel_c.Name = "panel_c";
		this.panel_c.Size = new System.Drawing.Size(215, 42);
		this.panel_c.TabIndex = 10;
		this.btnc_fave_serie.BackColor = System.Drawing.Color.Wheat;
		this.btnc_fave_serie.Enabled = false;
		this.btnc_fave_serie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnc_fave_serie.Location = new System.Drawing.Point(8, 5);
		this.btnc_fave_serie.Name = "btnc_fave_serie";
		this.btnc_fave_serie.Size = new System.Drawing.Size(96, 32);
		this.btnc_fave_serie.TabIndex = 1;
		this.btnc_fave_serie.Text = "سریال";
		this.btnc_fave_serie.UseVisualStyleBackColor = false;
		this.btnc_fave_serie.Click += new System.EventHandler(this.btnc_fave_serie_Click);
		this.btnc_fave_cinema.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.btnc_fave_cinema.Enabled = false;
		this.btnc_fave_cinema.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnc_fave_cinema.Location = new System.Drawing.Point(110, 5);
		this.btnc_fave_cinema.Name = "btnc_fave_cinema";
		this.btnc_fave_cinema.Size = new System.Drawing.Size(96, 32);
		this.btnc_fave_cinema.TabIndex = 0;
		this.btnc_fave_cinema.Text = "سینمایی";
		this.btnc_fave_cinema.UseVisualStyleBackColor = false;
		this.btnc_fave_cinema.Click += new System.EventHandler(this.btnc_fave_cinema_Click);
		this.label_loading.AutoSize = true;
		this.label_loading.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_loading.ForeColor = System.Drawing.Color.Yellow;
		this.label_loading.Location = new System.Drawing.Point(42, 433);
		this.label_loading.Name = "label_loading";
		this.label_loading.Size = new System.Drawing.Size(195, 25);
		this.label_loading.TabIndex = 9;
		this.label_loading.Text = "در حال بارگذاری ...";
		this.label_loading.Visible = false;
		this.list_fave_cinema.BackColor = System.Drawing.Color.DarkSlateGray;
		this.list_fave_cinema.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.list_fave_cinema.ForeColor = System.Drawing.Color.White;
		this.list_fave_cinema.Location = new System.Drawing.Point(14, 91);
		this.list_fave_cinema.Name = "list_fave_cinema";
		this.list_fave_cinema.Size = new System.Drawing.Size(119, 289);
		this.list_fave_cinema.TabIndex = 8;
		this.list_fave_cinema.UseCompatibleStateImageBehavior = false;
		this.list_fave_cinema.ItemActivate += new System.EventHandler(this.list_fave_cinema_ItemActivate);
		this.list_fave_cinema.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_fave_cinema_MouseClick);
		this.label_title.AutoSize = true;
		this.label_title.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_title.ForeColor = System.Drawing.Color.Yellow;
		this.label_title.Location = new System.Drawing.Point(9, 6);
		this.label_title.Name = "label_title";
		this.label_title.Size = new System.Drawing.Size(245, 25);
		this.label_title.TabIndex = 7;
		this.label_title.Text = "علاقه مندی ها (سینمایی)";
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		this.panel1.BackColor = System.Drawing.Color.Indigo;
		this.panel1.Controls.Add(this.btn_reload);
		this.panel1.Location = new System.Drawing.Point(271, 39);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(158, 42);
		this.panel1.TabIndex = 11;
		this.btn_reload.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
		this.btn_reload.Enabled = false;
		this.btn_reload.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_reload.Location = new System.Drawing.Point(10, 5);
		this.btn_reload.Name = "btn_reload";
		this.btn_reload.Size = new System.Drawing.Size(137, 32);
		this.btn_reload.TabIndex = 0;
		this.btn_reload.Text = "بروزرسانی لیست";
		this.btn_reload.UseVisualStyleBackColor = false;
		this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DarkSlateGray;
		base.ClientSize = new System.Drawing.Size(742, 484);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.list_fave_serie);
		base.Controls.Add(this.panel_c);
		base.Controls.Add(this.label_loading);
		base.Controls.Add(this.list_fave_cinema);
		base.Controls.Add(this.label_title);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "fave_list";
		this.Text = "fave_list";
		base.Load += new System.EventHandler(this.fave_list_Load);
		this.panel_c.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
