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

public class serie : Form
{
	private AppConfig ac;

	private int page_load_all;

	private int page_load_Irani;

	private int page_load_dub;

	private int page_load_sub;

	private int page_load_nosub;

	private string Selected_Tab;

	private string Select_Country;

	private string Select_Dub;

	private bool FirstRun_Irani;

	private bool FirstRun_Dub;

	private bool FirstRun_Sub;

	private bool FirstRun_NoSub;

	private string DataGenre;

	private string DataCountry;

	private list_genre_country list_genre_country;

	private ImageList myImageList1 = new ImageList();

	private ImageList myImageList_irani = new ImageList();

	private ImageList myImageList_dub = new ImageList();

	private ImageList myImageList_sub = new ImageList();

	private ImageList myImageList_nosub = new ImageList();

	private int c_img_list1;

	private int c_img_list_irani;

	private int c_img_list_dub;

	private int c_img_list_sub;

	private int c_img_list_nosub;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	private Button btn_genre;

	private Panel panel1;

	private Button btn_country;

	public ListView listView_serie_nosub;

	public ListView listView_serie_sub;

	public ListView listView_serie_dub;

	public ListView listView_serie_irani;

	private Button btnc_irani;

	private Button btnc_all;

	private Panel panel_c;

	private Button btnd_nosub;

	private Button btnd_sub;

	private Button btnd_dub;

	private Button btnd_all;

	private Panel panel_d;

	private Label label_loading;

	public ListView listView_serie;

	private Label label1;

	private Timer timer1;

	public serie()
	{
		InitializeComponent();
	}

	private void serie_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		int Main_Form_Width = Width;
		_ = Height;
		listView_serie.Width = Main_Form_Width;
		DataGenre = "";
		DataCountry = "";
		Selected_Tab = "All";
		Select_Country = "";
		Select_Dub = "";
		FirstRun_Irani = true;
		FirstRun_Dub = true;
		FirstRun_Sub = true;
		FirstRun_NoSub = true;
		ac = new AppConfig();
		page_load_all = 0;
		page_load_Irani = 0;
		page_load_dub = 0;
		page_load_sub = 0;
		page_load_nosub = 0;
		timer1.Enabled = true;
	}

	private void SetData()
	{
		try
		{
			myImageList1.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_irani.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_dub.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_sub.ColorDepth = ColorDepth.Depth16Bit;
			myImageList_nosub.ColorDepth = ColorDepth.Depth16Bit;
			int page_load = 0;
			if (Selected_Tab.Equals("All"))
			{
				if (listView_serie.Items.Count > 0)
				{
					listView_serie.Items[listView_serie.Items.Count - 1].Remove();
					myImageList1.Images.RemoveAt(listView_serie.Items.Count);
				}
				page_load_all++;
				page_load = page_load_all;
			}
			else if (Selected_Tab.Equals("Irani"))
			{
				if (listView_serie_irani.Items.Count > 0)
				{
					listView_serie_irani.Items[listView_serie_irani.Items.Count - 1].Remove();
					myImageList_irani.Images.RemoveAt(listView_serie_irani.Items.Count);
				}
				page_load_Irani++;
				page_load = page_load_Irani;
			}
			else if (Selected_Tab.Equals("Dub"))
			{
				if (listView_serie_dub.Items.Count > 0)
				{
					listView_serie_dub.Items[listView_serie_dub.Items.Count - 1].Remove();
					myImageList_dub.Images.RemoveAt(listView_serie_dub.Items.Count);
				}
				page_load_dub++;
				page_load = page_load_dub;
			}
			else if (Selected_Tab.Equals("Sub"))
			{
				if (listView_serie_sub.Items.Count > 0)
				{
					listView_serie_sub.Items[listView_serie_sub.Items.Count - 1].Remove();
					myImageList_sub.Images.RemoveAt(listView_serie_sub.Items.Count);
				}
				page_load_sub++;
				page_load = page_load_sub;
			}
			else if (Selected_Tab.Equals("NoSub"))
			{
				if (listView_serie_nosub.Items.Count > 0)
				{
					listView_serie_nosub.Items[listView_serie_nosub.Items.Count - 1].Remove();
					myImageList_nosub.Images.RemoveAt(listView_serie_nosub.Items.Count);
				}
				page_load_nosub++;
				page_load = page_load_nosub;
			}
			string url = Global.CurrentURL + ac.wiinapVll + Global.keyURL + ac.action_equal + "home_seryal&pageno=" + page_load;
			classes myclass = new classes();
			string Args1 = myclass.CreateArgs("c", Select_Country);
			string Args2 = myclass.CreateArgs("select_dub", Select_Dub);
			string Args3 = Args1 + "&" + Args2;
			string Data = myclass.PostData(url, Args3);
			JObject obj_all = JObject.Parse(Data);
			string AllVideo = obj_all.GetValue("all").ToString();
			DataGenre = obj_all.GetValue("genre").ToString();
			DataCountry = obj_all.GetValue("country").ToString();
			JArray all_array = JArray.Parse(AllVideo);
			int Len_Json = all_array.Count;
			if (Selected_Tab.Equals("All"))
			{
				myImageList1.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			}
			else if (Selected_Tab.Equals("Irani"))
			{
				myImageList_irani.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			}
			else if (Selected_Tab.Equals("Dub"))
			{
				myImageList_dub.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			}
			else if (Selected_Tab.Equals("Sub"))
			{
				myImageList_sub.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			}
			else if (Selected_Tab.Equals("NoSub"))
			{
				myImageList_nosub.ImageSize = new Size(ac.ItemVideoImgSizeWidth, ac.ItemVideoImgSizeHeight);
			}
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
					if (Selected_Tab.Equals("All"))
					{
						myImageList1.Images.Add(Image.FromStream(stream));
					}
					else if (Selected_Tab.Equals("Irani"))
					{
						myImageList_irani.Images.Add(Image.FromStream(stream));
					}
					else if (Selected_Tab.Equals("Dub"))
					{
						myImageList_dub.Images.Add(Image.FromStream(stream));
					}
					else if (Selected_Tab.Equals("Sub"))
					{
						myImageList_sub.Images.Add(Image.FromStream(stream));
					}
					else if (Selected_Tab.Equals("NoSub"))
					{
						myImageList_nosub.Images.Add(Image.FromStream(stream));
					}
				}
				catch (Exception)
				{
					if (Selected_Tab.Equals("All"))
					{
						myImageList1.Images.Add(Resources.placeholder);
					}
					else if (Selected_Tab.Equals("Irani"))
					{
						myImageList_irani.Images.Add(Resources.placeholder);
					}
					else if (Selected_Tab.Equals("Dub"))
					{
						myImageList_dub.Images.Add(Resources.placeholder);
					}
					else if (Selected_Tab.Equals("Sub"))
					{
						myImageList_sub.Images.Add(Resources.placeholder);
					}
					else if (Selected_Tab.Equals("NoSub"))
					{
						myImageList_nosub.Images.Add(Resources.placeholder);
					}
				}
			}
			if (Selected_Tab.Equals("All"))
			{
				myImageList1.Images.Add(Resources.loadmore);
				listView_serie.LargeImageList = myImageList1;
			}
			else if (Selected_Tab.Equals("Irani"))
			{
				myImageList_irani.Images.Add(Resources.loadmore);
				listView_serie_irani.LargeImageList = myImageList_irani;
			}
			else if (Selected_Tab.Equals("Dub"))
			{
				myImageList_dub.Images.Add(Resources.loadmore);
				listView_serie_dub.LargeImageList = myImageList_dub;
			}
			else if (Selected_Tab.Equals("Sub"))
			{
				myImageList_sub.Images.Add(Resources.loadmore);
				listView_serie_sub.LargeImageList = myImageList_sub;
			}
			else if (Selected_Tab.Equals("NoSub"))
			{
				myImageList_nosub.Images.Add(Resources.loadmore);
				listView_serie_nosub.LargeImageList = myImageList_nosub;
			}
			for (int j = 0; j < Len_Json; j++)
			{
				string ObjectsArray2 = all_array[j].ToString();
				JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
				string id = mJsonObject2.GetValue("id").ToString();
				string title = mJsonObject2.GetValue("title").ToString();
				mJsonObject2.GetValue("thumbnail_url").ToString();
				mJsonObject2.GetValue("imdb").ToString();
				if (Selected_Tab.Equals("All"))
				{
					listView_serie.Items.Add(id, title, c_img_list1);
					c_img_list1++;
				}
				else if (Selected_Tab.Equals("Irani"))
				{
					listView_serie_irani.Items.Add(id, title, c_img_list_irani);
					c_img_list_irani++;
				}
				else if (Selected_Tab.Equals("Dub"))
				{
					listView_serie_dub.Items.Add(id, title, c_img_list_dub);
					c_img_list_dub++;
				}
				else if (Selected_Tab.Equals("Sub"))
				{
					listView_serie_sub.Items.Add(id, title, c_img_list_sub);
					c_img_list_sub++;
				}
				else if (Selected_Tab.Equals("NoSub"))
				{
					listView_serie_nosub.Items.Add(id, title, c_img_list_nosub);
					c_img_list_nosub++;
				}
			}
			if (Selected_Tab.Equals("All"))
			{
				listView_serie.Items.Add("0", "مشاهده ادامه لیست", c_img_list1);
			}
			else if (Selected_Tab.Equals("Irani"))
			{
				listView_serie_irani.Items.Add("0", "مشاهده ادامه لیست", c_img_list_irani);
			}
			else if (Selected_Tab.Equals("Dub"))
			{
				listView_serie_dub.Items.Add("0", "مشاهده ادامه لیست", c_img_list_dub);
			}
			else if (Selected_Tab.Equals("Sub"))
			{
				listView_serie_sub.Items.Add("0", "مشاهده ادامه لیست", c_img_list_sub);
			}
			else if (Selected_Tab.Equals("NoSub"))
			{
				listView_serie_nosub.Items.Add("0", "مشاهده ادامه لیست", c_img_list_nosub);
			}
		}
		catch (Exception)
		{
		}
		panel_c.Enabled = true;
		panel_d.Enabled = true;
		panel1.Enabled = true;
		ShowLableLoaing("hide");
	}

	private void ItemSelectList()
	{
		if (Selected_Tab.Equals("All"))
		{
			int i = listView_serie.SelectedIndices[0];
			if (listView_serie.Items[i].Name.Equals("0"))
			{
				timer1.Enabled = true;
				return;
			}
			detiles detiles2 = new detiles();
			detiles2.txt_video_id.Text = listView_serie.Items[i].Name.ToString();
			detiles2.Show();
		}
		else if (Selected_Tab.Equals("Irani"))
		{
			int i2 = listView_serie_irani.SelectedIndices[0];
			if (listView_serie_irani.Items[i2].Name.Equals("0"))
			{
				timer1.Enabled = true;
				return;
			}
			detiles detiles3 = new detiles();
			detiles3.txt_video_id.Text = listView_serie_irani.Items[i2].Name.ToString();
			detiles3.Show();
		}
		else if (Selected_Tab.Equals("Dub"))
		{
			int i3 = listView_serie_dub.SelectedIndices[0];
			if (listView_serie_dub.Items[i3].Name.Equals("0"))
			{
				timer1.Enabled = true;
				return;
			}
			detiles detiles4 = new detiles();
			detiles4.txt_video_id.Text = listView_serie_dub.Items[i3].Name.ToString();
			detiles4.Show();
		}
		else if (Selected_Tab.Equals("Sub"))
		{
			int i4 = listView_serie_sub.SelectedIndices[0];
			if (listView_serie_sub.Items[i4].Name.Equals("0"))
			{
				timer1.Enabled = true;
				return;
			}
			detiles detiles5 = new detiles();
			detiles5.txt_video_id.Text = listView_serie_sub.Items[i4].Name.ToString();
			detiles5.Show();
		}
		else if (Selected_Tab.Equals("NoSub"))
		{
			int i5 = listView_serie_nosub.SelectedIndices[0];
			if (listView_serie_nosub.Items[i5].Name.Equals("0"))
			{
				timer1.Enabled = true;
				return;
			}
			detiles detiles6 = new detiles();
			detiles6.txt_video_id.Text = listView_serie_nosub.Items[i5].Name.ToString();
			detiles6.Show();
		}
	}

	private void btnc_all_Click(object sender, EventArgs e)
	{
		panel_d.Visible = true;
		Selected_Tab = "All";
		Select_Country = "2";
		Select_Dub = "";
		MenuSelectorCountry("All");
	}

	private void btnc_irani_Click(object sender, EventArgs e)
	{
		panel_d.Visible = false;
		Selected_Tab = "Irani";
		Select_Country = "1";
		Select_Dub = "";
		MenuSelectorCountry("Irani");
		if (FirstRun_Irani)
		{
			FirstRun_Irani = false;
			timer1.Enabled = true;
		}
	}

	private void btnd_all_Click(object sender, EventArgs e)
	{
		Selected_Tab = "All";
		Select_Country = "2";
		Select_Dub = "";
		MenuSelectorDub("All");
	}

	private void btnd_dub_Click(object sender, EventArgs e)
	{
		Selected_Tab = "Dub";
		Select_Country = "2";
		Select_Dub = "T";
		MenuSelectorDub("Dub");
		if (FirstRun_Dub)
		{
			FirstRun_Dub = false;
			timer1.Enabled = true;
		}
	}

	private void btnd_sub_Click(object sender, EventArgs e)
	{
		Selected_Tab = "Sub";
		Select_Country = "2";
		Select_Dub = "F";
		MenuSelectorDub("Sub");
		if (FirstRun_Sub)
		{
			FirstRun_Sub = false;
			timer1.Enabled = true;
		}
	}

	private void btnd_nosub_Click(object sender, EventArgs e)
	{
		Selected_Tab = "NoSub";
		Select_Country = "2";
		Select_Dub = "B";
		MenuSelectorDub("NoSub");
		if (FirstRun_NoSub)
		{
			FirstRun_NoSub = false;
			timer1.Enabled = true;
		}
	}

	private void MenuSelectorDub(string Itemo)
	{
		switch (Itemo)
		{
		case "All":
			btnd_all.BackColor = Color.DeepSkyBlue;
			btnd_dub.BackColor = Color.Wheat;
			btnd_sub.BackColor = Color.Wheat;
			btnd_nosub.BackColor = Color.Wheat;
			listView_serie.Visible = true;
			listView_serie_dub.Visible = false;
			listView_serie_sub.Visible = false;
			listView_serie_nosub.Visible = false;
			break;
		case "Dub":
			btnd_all.BackColor = Color.Wheat;
			btnd_dub.BackColor = Color.DeepSkyBlue;
			btnd_sub.BackColor = Color.Wheat;
			btnd_nosub.BackColor = Color.Wheat;
			listView_serie.Visible = false;
			listView_serie_dub.Visible = true;
			listView_serie_sub.Visible = false;
			listView_serie_nosub.Visible = false;
			break;
		case "Sub":
			btnd_all.BackColor = Color.Wheat;
			btnd_dub.BackColor = Color.Wheat;
			btnd_sub.BackColor = Color.DeepSkyBlue;
			btnd_nosub.BackColor = Color.Wheat;
			listView_serie.Visible = false;
			listView_serie_dub.Visible = false;
			listView_serie_sub.Visible = true;
			listView_serie_nosub.Visible = false;
			break;
		case "NoSub":
			btnd_all.BackColor = Color.Wheat;
			btnd_dub.BackColor = Color.Wheat;
			btnd_sub.BackColor = Color.Wheat;
			btnd_nosub.BackColor = Color.DeepSkyBlue;
			listView_serie.Visible = false;
			listView_serie_dub.Visible = false;
			listView_serie_sub.Visible = false;
			listView_serie_nosub.Visible = true;
			break;
		}
	}

	private void MenuSelectorCountry(string Itemo)
	{
		if (Itemo == "All")
		{
			btnc_all.BackColor = Color.DeepSkyBlue;
			btnc_irani.BackColor = Color.Wheat;
			listView_serie.Visible = true;
			listView_serie_irani.Visible = false;
		}
		else if (Itemo == "Irani")
		{
			btnc_all.BackColor = Color.Wheat;
			btnc_irani.BackColor = Color.DeepSkyBlue;
			listView_serie.Visible = false;
			listView_serie_irani.Visible = true;
			listView_serie_dub.Visible = false;
			listView_serie_sub.Visible = false;
			listView_serie_nosub.Visible = false;
		}
	}

	private void btn_genre_Click(object sender, EventArgs e)
	{
		if (DataGenre == null)
		{
			DataGenre = "";
		}
		if (!DataGenre.Equals(""))
		{
			if (list_genre_country != null)
			{
				list_genre_country.Close();
			}
			list_genre_country = new list_genre_country();
			list_genre_country.textBox_ms_what.Text = "serie";
			list_genre_country.textBox_gc_what.Text = "genre";
			list_genre_country.textBox_genre_data.Text = DataGenre;
			list_genre_country.label_title.Text = "انتخاب سریال بر اساس ژانر";
			list_genre_country.Show();
		}
		else
		{
			MessageBox.Show("لطفا صبر کنید تا اطلاعات کامل بارگذاری شوند!");
		}
	}

	private void btn_country_Click(object sender, EventArgs e)
	{
		if (DataCountry == null)
		{
			DataCountry = "";
		}
		if (!DataCountry.Equals(""))
		{
			if (list_genre_country != null)
			{
				list_genre_country.Close();
			}
			list_genre_country = new list_genre_country();
			list_genre_country.textBox_ms_what.Text = "serie";
			list_genre_country.textBox_gc_what.Text = "country";
			list_genre_country.textBox_genre_data.Text = DataCountry;
			list_genre_country.label_title.Text = "انتخاب سریال بر اساس کشور";
			list_genre_country.Show();
		}
		else
		{
			MessageBox.Show("لطفا صبر کنید تا اطلاعات کامل بارگذاری شوند!");
		}
	}

	private void listView_serie_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_irani_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_irani_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_dub_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_dub_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_sub_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_sub_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_nosub_ItemActivate(object sender, EventArgs e)
	{
		ItemSelectList();
	}

	private void listView_serie_nosub_MouseClick(object sender, MouseEventArgs e)
	{
		ItemSelectList();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.serie));
		this.btn_genre = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.btn_country = new System.Windows.Forms.Button();
		this.listView_serie_nosub = new System.Windows.Forms.ListView();
		this.listView_serie_sub = new System.Windows.Forms.ListView();
		this.listView_serie_dub = new System.Windows.Forms.ListView();
		this.listView_serie_irani = new System.Windows.Forms.ListView();
		this.btnc_irani = new System.Windows.Forms.Button();
		this.btnc_all = new System.Windows.Forms.Button();
		this.panel_c = new System.Windows.Forms.Panel();
		this.btnd_nosub = new System.Windows.Forms.Button();
		this.btnd_sub = new System.Windows.Forms.Button();
		this.btnd_dub = new System.Windows.Forms.Button();
		this.btnd_all = new System.Windows.Forms.Button();
		this.panel_d = new System.Windows.Forms.Panel();
		this.label_loading = new System.Windows.Forms.Label();
		this.listView_serie = new System.Windows.Forms.ListView();
		this.label1 = new System.Windows.Forms.Label();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel1.SuspendLayout();
		this.panel_c.SuspendLayout();
		this.panel_d.SuspendLayout();
		base.SuspendLayout();
		this.btn_genre.BackColor = System.Drawing.Color.Wheat;
		this.btn_genre.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_genre.Location = new System.Drawing.Point(111, 5);
		this.btn_genre.Name = "btn_genre";
		this.btn_genre.Size = new System.Drawing.Size(96, 32);
		this.btn_genre.TabIndex = 1;
		this.btn_genre.Text = "ژانر ها";
		this.btn_genre.UseVisualStyleBackColor = false;
		this.btn_genre.Click += new System.EventHandler(this.btn_genre_Click);
		this.panel1.BackColor = System.Drawing.Color.Indigo;
		this.panel1.Controls.Add(this.btn_country);
		this.panel1.Controls.Add(this.btn_genre);
		this.panel1.Enabled = false;
		this.panel1.Location = new System.Drawing.Point(738, 39);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(215, 42);
		this.panel1.TabIndex = 15;
		this.btn_country.BackColor = System.Drawing.Color.Wheat;
		this.btn_country.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_country.Location = new System.Drawing.Point(9, 5);
		this.btn_country.Name = "btn_country";
		this.btn_country.Size = new System.Drawing.Size(96, 32);
		this.btn_country.TabIndex = 2;
		this.btn_country.Text = "کشور ها";
		this.btn_country.UseVisualStyleBackColor = false;
		this.btn_country.Click += new System.EventHandler(this.btn_country_Click);
		this.listView_serie_nosub.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_serie_nosub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_serie_nosub.ForeColor = System.Drawing.Color.White;
		this.listView_serie_nosub.Location = new System.Drawing.Point(513, 91);
		this.listView_serie_nosub.Name = "listView_serie_nosub";
		this.listView_serie_nosub.Size = new System.Drawing.Size(92, 289);
		this.listView_serie_nosub.TabIndex = 19;
		this.listView_serie_nosub.UseCompatibleStateImageBehavior = false;
		this.listView_serie_nosub.Visible = false;
		this.listView_serie_nosub.ItemActivate += new System.EventHandler(this.listView_serie_nosub_ItemActivate);
		this.listView_serie_nosub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_serie_nosub_MouseClick);
		this.listView_serie_sub.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_serie_sub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_serie_sub.ForeColor = System.Drawing.Color.White;
		this.listView_serie_sub.Location = new System.Drawing.Point(398, 91);
		this.listView_serie_sub.Name = "listView_serie_sub";
		this.listView_serie_sub.Size = new System.Drawing.Size(92, 289);
		this.listView_serie_sub.TabIndex = 18;
		this.listView_serie_sub.UseCompatibleStateImageBehavior = false;
		this.listView_serie_sub.Visible = false;
		this.listView_serie_sub.ItemActivate += new System.EventHandler(this.listView_serie_sub_ItemActivate);
		this.listView_serie_sub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_serie_sub_MouseClick);
		this.listView_serie_dub.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_serie_dub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_serie_dub.ForeColor = System.Drawing.Color.White;
		this.listView_serie_dub.Location = new System.Drawing.Point(269, 91);
		this.listView_serie_dub.Name = "listView_serie_dub";
		this.listView_serie_dub.Size = new System.Drawing.Size(92, 289);
		this.listView_serie_dub.TabIndex = 17;
		this.listView_serie_dub.UseCompatibleStateImageBehavior = false;
		this.listView_serie_dub.Visible = false;
		this.listView_serie_dub.ItemActivate += new System.EventHandler(this.listView_serie_dub_ItemActivate);
		this.listView_serie_dub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_serie_dub_MouseClick);
		this.listView_serie_irani.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_serie_irani.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_serie_irani.ForeColor = System.Drawing.Color.White;
		this.listView_serie_irani.Location = new System.Drawing.Point(139, 91);
		this.listView_serie_irani.Name = "listView_serie_irani";
		this.listView_serie_irani.Size = new System.Drawing.Size(101, 289);
		this.listView_serie_irani.TabIndex = 16;
		this.listView_serie_irani.UseCompatibleStateImageBehavior = false;
		this.listView_serie_irani.Visible = false;
		this.listView_serie_irani.ItemActivate += new System.EventHandler(this.listView_serie_irani_ItemActivate);
		this.listView_serie_irani.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_serie_irani_MouseClick);
		this.btnc_irani.BackColor = System.Drawing.Color.Wheat;
		this.btnc_irani.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnc_irani.Location = new System.Drawing.Point(8, 5);
		this.btnc_irani.Name = "btnc_irani";
		this.btnc_irani.Size = new System.Drawing.Size(96, 32);
		this.btnc_irani.TabIndex = 1;
		this.btnc_irani.Text = "ایرانی";
		this.btnc_irani.UseVisualStyleBackColor = false;
		this.btnc_irani.Click += new System.EventHandler(this.btnc_irani_Click);
		this.btnc_all.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.btnc_all.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnc_all.Location = new System.Drawing.Point(110, 5);
		this.btnc_all.Name = "btnc_all";
		this.btnc_all.Size = new System.Drawing.Size(96, 32);
		this.btnc_all.TabIndex = 0;
		this.btnc_all.Text = "همه";
		this.btnc_all.UseVisualStyleBackColor = false;
		this.btnc_all.Click += new System.EventHandler(this.btnc_all_Click);
		this.panel_c.BackColor = System.Drawing.Color.Indigo;
		this.panel_c.Controls.Add(this.btnc_irani);
		this.panel_c.Controls.Add(this.btnc_all);
		this.panel_c.Enabled = false;
		this.panel_c.Location = new System.Drawing.Point(473, 39);
		this.panel_c.Name = "panel_c";
		this.panel_c.Size = new System.Drawing.Size(215, 42);
		this.panel_c.TabIndex = 14;
		this.btnd_nosub.BackColor = System.Drawing.Color.Wheat;
		this.btnd_nosub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnd_nosub.Location = new System.Drawing.Point(3, 4);
		this.btnd_nosub.Name = "btnd_nosub";
		this.btnd_nosub.Size = new System.Drawing.Size(96, 32);
		this.btnd_nosub.TabIndex = 3;
		this.btnd_nosub.Text = "زیرنویس جدا";
		this.btnd_nosub.UseVisualStyleBackColor = false;
		this.btnd_nosub.Click += new System.EventHandler(this.btnd_nosub_Click);
		this.btnd_sub.BackColor = System.Drawing.Color.Wheat;
		this.btnd_sub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnd_sub.Location = new System.Drawing.Point(105, 5);
		this.btnd_sub.Name = "btnd_sub";
		this.btnd_sub.Size = new System.Drawing.Size(96, 32);
		this.btnd_sub.TabIndex = 2;
		this.btnd_sub.Text = "زیرنویس";
		this.btnd_sub.UseVisualStyleBackColor = false;
		this.btnd_sub.Click += new System.EventHandler(this.btnd_sub_Click);
		this.btnd_dub.BackColor = System.Drawing.Color.Wheat;
		this.btnd_dub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnd_dub.Location = new System.Drawing.Point(207, 5);
		this.btnd_dub.Name = "btnd_dub";
		this.btnd_dub.Size = new System.Drawing.Size(96, 32);
		this.btnd_dub.TabIndex = 1;
		this.btnd_dub.Text = "دوبله";
		this.btnd_dub.UseVisualStyleBackColor = false;
		this.btnd_dub.Click += new System.EventHandler(this.btnd_dub_Click);
		this.btnd_all.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.btnd_all.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnd_all.Location = new System.Drawing.Point(309, 5);
		this.btnd_all.Name = "btnd_all";
		this.btnd_all.Size = new System.Drawing.Size(96, 32);
		this.btnd_all.TabIndex = 0;
		this.btnd_all.Text = "همه";
		this.btnd_all.UseVisualStyleBackColor = false;
		this.btnd_all.Click += new System.EventHandler(this.btnd_all_Click);
		this.panel_d.BackColor = System.Drawing.Color.Indigo;
		this.panel_d.Controls.Add(this.btnd_nosub);
		this.panel_d.Controls.Add(this.btnd_sub);
		this.panel_d.Controls.Add(this.btnd_dub);
		this.panel_d.Controls.Add(this.btnd_all);
		this.panel_d.Enabled = false;
		this.panel_d.Location = new System.Drawing.Point(13, 39);
		this.panel_d.Name = "panel_d";
		this.panel_d.Size = new System.Drawing.Size(416, 42);
		this.panel_d.TabIndex = 13;
		this.label_loading.AutoSize = true;
		this.label_loading.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_loading.ForeColor = System.Drawing.Color.Yellow;
		this.label_loading.Location = new System.Drawing.Point(11, 421);
		this.label_loading.Name = "label_loading";
		this.label_loading.Size = new System.Drawing.Size(195, 25);
		this.label_loading.TabIndex = 12;
		this.label_loading.Text = "در حال بارگذاری ...";
		this.label_loading.Visible = false;
		this.listView_serie.BackColor = System.Drawing.Color.DarkSlateGray;
		this.listView_serie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.listView_serie.ForeColor = System.Drawing.Color.White;
		this.listView_serie.Location = new System.Drawing.Point(14, 91);
		this.listView_serie.Name = "listView_serie";
		this.listView_serie.Size = new System.Drawing.Size(119, 289);
		this.listView_serie.TabIndex = 11;
		this.listView_serie.UseCompatibleStateImageBehavior = false;
		this.listView_serie.ItemActivate += new System.EventHandler(this.listView_serie_ItemActivate);
		this.listView_serie.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_serie_MouseClick);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Yellow;
		this.label1.Location = new System.Drawing.Point(9, 6);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(95, 25);
		this.label1.TabIndex = 10;
		this.label1.Text = "سریال ها";
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DarkSlateGray;
		base.ClientSize = new System.Drawing.Size(967, 461);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.listView_serie_nosub);
		base.Controls.Add(this.listView_serie_sub);
		base.Controls.Add(this.listView_serie_dub);
		base.Controls.Add(this.listView_serie_irani);
		base.Controls.Add(this.panel_c);
		base.Controls.Add(this.panel_d);
		base.Controls.Add(this.label_loading);
		base.Controls.Add(this.listView_serie);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "serie";
		this.Text = "serie";
		base.Load += new System.EventHandler(this.serie_Load);
		this.panel1.ResumeLayout(false);
		this.panel_c.ResumeLayout(false);
		this.panel_d.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
