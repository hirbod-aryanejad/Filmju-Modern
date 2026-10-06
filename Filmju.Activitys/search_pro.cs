using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class search_pro : Form
{
	private AppConfig ac;

	private string[] GenreList;

	private string[] CountryList;

	private string[] MovieSerieList;

	private string[] DubSubList;

	private string[] ImdbList;

	private string[] OrderList;

	private string Selected_Genre;

	private string Selected_Country;

	private string Selected_MvoviSerie;

	private string Selected_DubSub;

	private string Selected_Imdb;

	private string Selected_Order;

	private string Selected_Year_From;

	private string Selected_Year_To;

	private frm_loading frm_loading;

	private int timee;

	private IContainer components;

	private Label label1;

	private ComboBox comboBox_country;

	private ComboBox comboBox_genre;

	private Button btn_submit;

	private ComboBox comboBox_imdb;

	private ComboBox comboBox_dubsub;

	private ComboBox comboBox_ms;

	private Label label8;

	private ComboBox comboBox_order;

	private Label label7;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	public Panel panel_search_pro;

	private Timer timer1;

	private Label label_year;

	private Button btn_set_year;

	private Label label10;

	private Label label9;

	private TextBox textBox_year_to;

	private TextBox textBox_year_from;

	public Panel panel_select_year;

	public search_pro()
	{
		InitializeComponent();
	}

	private void search_pro_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		WindowState = FormWindowState.Normal;
		ac = new AppConfig();
		Selected_Genre = "all";
		Selected_Country = "all";
		Selected_MvoviSerie = "all";
		Selected_DubSub = "all";
		Selected_Imdb = "all";
		Selected_Order = "all";
		Selected_Year_From = "";
		Selected_Year_To = "";
		MovieSerieList = new string[3];
		comboBox_ms.Text = "مهم نیست";
		comboBox_ms.Items.Add("مهم نیست");
		MovieSerieList[0] = "all";
		comboBox_ms.Items.Add("سینمایی");
		MovieSerieList[1] = "movie";
		comboBox_ms.Items.Add("سریال");
		MovieSerieList[2] = "serie";
		DubSubList = new string[4];
		comboBox_dubsub.Text = "مهم نیست";
		comboBox_dubsub.Items.Add("مهم نیست");
		DubSubList[0] = "all";
		comboBox_dubsub.Items.Add("دوبله");
		DubSubList[1] = "dub";
		comboBox_dubsub.Items.Add("زیرنویس");
		DubSubList[2] = "sub";
		comboBox_dubsub.Items.Add("بدون زیرنویس");
		DubSubList[3] = "nosub";
		ImdbList = new string[19];
		comboBox_imdb.Text = "مهم نیست";
		comboBox_imdb.Items.Add("مهم نیست");
		ImdbList[0] = "all";
		comboBox_imdb.Items.Add("حداقل امتیاز 1.0");
		ImdbList[1] = "1.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 1.5");
		ImdbList[2] = "1.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 2.0");
		ImdbList[3] = "2.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 2.5");
		ImdbList[4] = "2.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 3.0");
		ImdbList[5] = "3.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 3.5");
		ImdbList[6] = "3.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 4.0");
		ImdbList[7] = "4.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 4.5");
		ImdbList[8] = "4.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 5.0");
		ImdbList[9] = "5.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 5.5");
		ImdbList[10] = "5.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 6.0");
		ImdbList[11] = "6.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 6.5");
		ImdbList[12] = "6.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 7.0");
		ImdbList[13] = "7.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 7.5");
		ImdbList[14] = "7.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 8.0");
		ImdbList[15] = "8.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 8.5");
		ImdbList[16] = "8.5";
		comboBox_imdb.Items.Add("حداقل امتیاز 9.0");
		ImdbList[17] = "9.0";
		comboBox_imdb.Items.Add("حداقل امتیاز 9.5");
		ImdbList[18] = "9.5";
		OrderList = new string[7];
		comboBox_order.Text = "مهم نیست";
		comboBox_order.Items.Add("مهم نیست");
		OrderList[0] = "all";
		comboBox_order.Items.Add("سال (جدیدترین)");
		OrderList[1] = "YearNew";
		comboBox_order.Items.Add("سال (قدیمی ترین)");
		OrderList[2] = "YearOld";
		comboBox_order.Items.Add("امتیاز (بیشترین)");
		OrderList[3] = "ImdbLager";
		comboBox_order.Items.Add("امتیاز (کمترین)");
		OrderList[4] = "ImdbSmall";
		comboBox_order.Items.Add("روبی باکس (جدیدترین)");
		OrderList[5] = "NewMovie";
		comboBox_order.Items.Add("روبی باکس (قدیمی ترین)");
		OrderList[6] = "OldMovie";
		timer1.Enabled = true;
	}

	private void SetData()
	{
		try
		{
			string url = Global.ULPdisjskfdlkf + ac.CheckDevice + Global.Psdiuisdufscds + ac.key5548112 + "Filter_Option";
			classes myclass = new classes();
			string Args = "";
			string Data = myclass.PostData(url, Args);
			JObject obj_all = JObject.Parse(Data);
			string DataGenre = obj_all.GetValue("genre").ToString();
			string DataCountry = obj_all.GetValue("country").ToString();
			JArray all_array = JArray.Parse(DataGenre);
			int Len_Json = all_array.Count;
			GenreList = new string[Len_Json + 1];
			comboBox_genre.Items.Add("مهم نیست");
			comboBox_genre.Text = "مهم نیست";
			GenreList[0] = "all";
			for (int i = 0; i < Len_Json; i++)
			{
				string ObjectsArray = all_array[i].ToString();
				JObject mJsonObject = JObject.Parse(ObjectsArray);
				string id = mJsonObject.GetValue("genre_id").ToString();
				string name = mJsonObject.GetValue("name").ToString();
				GenreList[i + 1] = id.ToString();
				comboBox_genre.Items.Add(name);
			}
			JArray all_array_country = JArray.Parse(DataCountry);
			int Len_Json_country = all_array_country.Count;
			CountryList = new string[Len_Json_country + 1];
			comboBox_country.Items.Add("مهم نیست");
			comboBox_country.Text = "مهم نیست";
			CountryList[0] = "all";
			for (int j = 0; j < Len_Json_country; j++)
			{
				string ObjectsArray2 = all_array_country[j].ToString();
				JObject mJsonObject2 = JObject.Parse(ObjectsArray2);
				string id2 = mJsonObject2.GetValue("country_id").ToString();
				string name2 = mJsonObject2.GetValue("name").ToString();
				CountryList[j + 1] = id2.ToString();
				comboBox_country.Items.Add(name2);
			}
			comboBox_country.Enabled = true;
			comboBox_dubsub.Enabled = true;
			comboBox_genre.Enabled = true;
			comboBox_imdb.Enabled = true;
			comboBox_ms.Enabled = true;
			comboBox_order.Enabled = true;
			label_year.Enabled = true;
		}
		catch (Exception)
		{
		}
		ShowLableLoaing("hide");
		btn_submit.Enabled = true;
	}

	private void btn_submit_Click(object sender, EventArgs e)
	{
		show_filters show_filters2 = new show_filters();
		show_filters2.textBox_ms.Text = Selected_MvoviSerie;
		show_filters2.textBox_dubsub.Text = Selected_DubSub;
		show_filters2.textBox_genre.Text = Selected_Genre;
		show_filters2.textBox_country.Text = Selected_Country;
		show_filters2.textBox_imdb.Text = Selected_Imdb;
		show_filters2.textBox_order.Text = Selected_Order;
		show_filters2.textBox_year_form.Text = Selected_Year_From;
		show_filters2.textBox_year_to.Text = Selected_Year_To;
		show_filters2.lable_title.Text = "";
		show_filters2.Show();
	}

	private void comboBox_genre_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = comboBox_genre.SelectedText;
		int SelectedIndex = comboBox_genre.SelectedIndex;
		Selected_Genre = GenreList[SelectedIndex];
	}

	private void comboBox_country_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = comboBox_country.SelectedText;
		int SelectedIndex = comboBox_country.SelectedIndex;
		Selected_Country = CountryList[SelectedIndex];
	}

	private void comboBox_ms_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = comboBox_ms.SelectedText;
		int SelectedIndex = comboBox_ms.SelectedIndex;
		Selected_MvoviSerie = MovieSerieList[SelectedIndex];
	}

	private void comboBox_dubsub_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = comboBox_dubsub.SelectedText;
		int SelectedIndex = comboBox_dubsub.SelectedIndex;
		Selected_DubSub = DubSubList[SelectedIndex];
	}

	private void comboBox_imdb_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = comboBox_imdb.SelectedText;
		int SelectedIndex = comboBox_imdb.SelectedIndex;
		Selected_Imdb = ImdbList[SelectedIndex];
	}

	private void comboBox_order_SelectionChangeCommitted(object sender, EventArgs e)
	{
		_ = comboBox_order.SelectedText;
		int SelectedIndex = comboBox_order.SelectedIndex;
		Selected_Order = OrderList[SelectedIndex];
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

	private void btn_set_year_Click(object sender, EventArgs e)
	{
		string year_from = textBox_year_from.Text.ToString();
		string year_to = textBox_year_to.Text.ToString();
		if (year_from == null)
		{
			year_from = "";
		}
		if (year_to == null)
		{
			year_to = "";
		}
		Selected_Year_From = year_from;
		Selected_Year_To = year_to;
		if (Selected_Year_From == null)
		{
			Selected_Year_From = "";
		}
		if (Selected_Year_To == null)
		{
			Selected_Year_To = "";
		}
		bool is_error = false;
		try
		{
			if (!Selected_Year_From.Equals("") && !Selected_Year_To.Equals(""))
			{
				int year_f = int.Parse(Selected_Year_From);
				int year_t = int.Parse(Selected_Year_To);
				if (year_f > year_t)
				{
					MessageBox.Show("تاریخ شروع نمی تواند بزرگتر از تاریخ پایان باشد");
					is_error = true;
				}
			}
		}
		catch (Exception)
		{
			is_error = true;
			MessageBox.Show("تاریخ نامعتبر می باشد . به صورت اعداد انگلیسی وارد کنید");
		}
		if (!is_error)
		{
			string txt_temp = "مهم نیست";
			if (!Selected_Year_From.Equals(""))
			{
				txt_temp = "از : " + Selected_Year_From;
			}
			if (Selected_Year_From.Equals(""))
			{
				txt_temp = "";
			}
			if (!Selected_Year_To.Equals(""))
			{
				txt_temp = txt_temp + " - تا : " + Selected_Year_To;
			}
			if (txt_temp.Length == 0)
			{
				txt_temp = "مهم نیست";
			}
			label_year.Text = txt_temp;
			panel_select_year.Visible = false;
			btn_submit.Enabled = true;
		}
	}

	private void textBox_year_from_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
	}

	private void textBox_year_to_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
	}

	private void label_year_Click(object sender, EventArgs e)
	{
		btn_submit.Enabled = false;
		panel_select_year.Visible = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.search_pro));
		this.label1 = new System.Windows.Forms.Label();
		this.panel_search_pro = new System.Windows.Forms.Panel();
		this.label_year = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.comboBox_order = new System.Windows.Forms.ComboBox();
		this.label7 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.comboBox_imdb = new System.Windows.Forms.ComboBox();
		this.comboBox_dubsub = new System.Windows.Forms.ComboBox();
		this.comboBox_ms = new System.Windows.Forms.ComboBox();
		this.btn_submit = new System.Windows.Forms.Button();
		this.comboBox_country = new System.Windows.Forms.ComboBox();
		this.comboBox_genre = new System.Windows.Forms.ComboBox();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel_select_year = new System.Windows.Forms.Panel();
		this.btn_set_year = new System.Windows.Forms.Button();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.textBox_year_to = new System.Windows.Forms.TextBox();
		this.textBox_year_from = new System.Windows.Forms.TextBox();
		this.panel_search_pro.SuspendLayout();
		this.panel_select_year.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Yellow;
		this.label1.Location = new System.Drawing.Point(9, 6);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(175, 25);
		this.label1.TabIndex = 2;
		this.label1.Text = "جستجوی پیشرفته";
		this.panel_search_pro.Controls.Add(this.label_year);
		this.panel_search_pro.Controls.Add(this.label8);
		this.panel_search_pro.Controls.Add(this.comboBox_order);
		this.panel_search_pro.Controls.Add(this.label7);
		this.panel_search_pro.Controls.Add(this.label6);
		this.panel_search_pro.Controls.Add(this.label5);
		this.panel_search_pro.Controls.Add(this.label4);
		this.panel_search_pro.Controls.Add(this.label3);
		this.panel_search_pro.Controls.Add(this.label2);
		this.panel_search_pro.Controls.Add(this.comboBox_imdb);
		this.panel_search_pro.Controls.Add(this.comboBox_dubsub);
		this.panel_search_pro.Controls.Add(this.comboBox_ms);
		this.panel_search_pro.Controls.Add(this.btn_submit);
		this.panel_search_pro.Controls.Add(this.comboBox_country);
		this.panel_search_pro.Controls.Add(this.comboBox_genre);
		this.panel_search_pro.Location = new System.Drawing.Point(14, 49);
		this.panel_search_pro.Name = "panel_search_pro";
		this.panel_search_pro.Size = new System.Drawing.Size(630, 374);
		this.panel_search_pro.TabIndex = 3;
		this.label_year.BackColor = System.Drawing.Color.White;
		this.label_year.Enabled = false;
		this.label_year.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.label_year.Location = new System.Drawing.Point(47, 130);
		this.label_year.Name = "label_year";
		this.label_year.Size = new System.Drawing.Size(163, 24);
		this.label_year.TabIndex = 14;
		this.label_year.Text = "مهم نیست";
		this.label_year.Click += new System.EventHandler(this.label_year_Click);
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.ForeColor = System.Drawing.Color.Yellow;
		this.label8.Location = new System.Drawing.Point(504, 170);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(102, 18);
		this.label8.TabIndex = 13;
		this.label8.Text = "ترتیب بر اساس";
		this.comboBox_order.Enabled = false;
		this.comboBox_order.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_order.FormattingEnabled = true;
		this.comboBox_order.Location = new System.Drawing.Point(335, 170);
		this.comboBox_order.Name = "comboBox_order";
		this.comboBox_order.Size = new System.Drawing.Size(163, 24);
		this.comboBox_order.TabIndex = 12;
		this.comboBox_order.SelectionChangeCommitted += new System.EventHandler(this.comboBox_order_SelectionChangeCommitted);
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.Color.Yellow;
		this.label7.Location = new System.Drawing.Point(229, 130);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(80, 18);
		this.label7.TabIndex = 11;
		this.label7.Text = "سال انتشار";
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.ForeColor = System.Drawing.Color.Yellow;
		this.label6.Location = new System.Drawing.Point(504, 124);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(75, 18);
		this.label6.TabIndex = 10;
		this.label6.Text = "imdb امتیاز";
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Yellow;
		this.label5.Location = new System.Drawing.Point(229, 75);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(62, 18);
		this.label5.TabIndex = 9;
		this.label5.Text = "کشور ها";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Yellow;
		this.label4.Location = new System.Drawing.Point(504, 75);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(46, 18);
		this.label4.TabIndex = 8;
		this.label4.Text = "ژانر ها";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Yellow;
		this.label3.Location = new System.Drawing.Point(229, 31);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(42, 18);
		this.label3.TabIndex = 7;
		this.label3.Text = "محتوا";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.Yellow;
		this.label2.Location = new System.Drawing.Point(504, 25);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(44, 18);
		this.label2.TabIndex = 6;
		this.label2.Text = "دسته";
		this.comboBox_imdb.Enabled = false;
		this.comboBox_imdb.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_imdb.FormattingEnabled = true;
		this.comboBox_imdb.Location = new System.Drawing.Point(335, 124);
		this.comboBox_imdb.Name = "comboBox_imdb";
		this.comboBox_imdb.Size = new System.Drawing.Size(163, 24);
		this.comboBox_imdb.TabIndex = 5;
		this.comboBox_imdb.SelectionChangeCommitted += new System.EventHandler(this.comboBox_imdb_SelectionChangeCommitted);
		this.comboBox_dubsub.Enabled = false;
		this.comboBox_dubsub.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_dubsub.FormattingEnabled = true;
		this.comboBox_dubsub.Location = new System.Drawing.Point(47, 25);
		this.comboBox_dubsub.Name = "comboBox_dubsub";
		this.comboBox_dubsub.Size = new System.Drawing.Size(163, 24);
		this.comboBox_dubsub.TabIndex = 4;
		this.comboBox_dubsub.SelectionChangeCommitted += new System.EventHandler(this.comboBox_dubsub_SelectionChangeCommitted);
		this.comboBox_ms.Enabled = false;
		this.comboBox_ms.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_ms.FormattingEnabled = true;
		this.comboBox_ms.Location = new System.Drawing.Point(335, 24);
		this.comboBox_ms.Name = "comboBox_ms";
		this.comboBox_ms.Size = new System.Drawing.Size(163, 24);
		this.comboBox_ms.TabIndex = 3;
		this.comboBox_ms.SelectionChangeCommitted += new System.EventHandler(this.comboBox_ms_SelectionChangeCommitted);
		this.btn_submit.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_submit.Enabled = false;
		this.btn_submit.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_submit.ForeColor = System.Drawing.Color.White;
		this.btn_submit.Location = new System.Drawing.Point(232, 266);
		this.btn_submit.Name = "btn_submit";
		this.btn_submit.Size = new System.Drawing.Size(123, 41);
		this.btn_submit.TabIndex = 2;
		this.btn_submit.Text = "جستجو";
		this.btn_submit.UseVisualStyleBackColor = false;
		this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
		this.comboBox_country.Enabled = false;
		this.comboBox_country.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_country.FormattingEnabled = true;
		this.comboBox_country.Location = new System.Drawing.Point(47, 75);
		this.comboBox_country.Name = "comboBox_country";
		this.comboBox_country.Size = new System.Drawing.Size(163, 24);
		this.comboBox_country.TabIndex = 1;
		this.comboBox_country.SelectionChangeCommitted += new System.EventHandler(this.comboBox_country_SelectionChangeCommitted);
		this.comboBox_genre.Enabled = false;
		this.comboBox_genre.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_genre.FormattingEnabled = true;
		this.comboBox_genre.Location = new System.Drawing.Point(335, 75);
		this.comboBox_genre.Name = "comboBox_genre";
		this.comboBox_genre.Size = new System.Drawing.Size(163, 24);
		this.comboBox_genre.TabIndex = 0;
		this.comboBox_genre.SelectionChangeCommitted += new System.EventHandler(this.comboBox_genre_SelectionChangeCommitted);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		this.panel_select_year.BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.panel_select_year.Controls.Add(this.btn_set_year);
		this.panel_select_year.Controls.Add(this.label10);
		this.panel_select_year.Controls.Add(this.label9);
		this.panel_select_year.Controls.Add(this.textBox_year_to);
		this.panel_select_year.Controls.Add(this.textBox_year_from);
		this.panel_select_year.Location = new System.Drawing.Point(694, 137);
		this.panel_select_year.Name = "panel_select_year";
		this.panel_select_year.Size = new System.Drawing.Size(321, 172);
		this.panel_select_year.TabIndex = 4;
		this.panel_select_year.Visible = false;
		this.btn_set_year.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btn_set_year.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_set_year.ForeColor = System.Drawing.Color.White;
		this.btn_set_year.Location = new System.Drawing.Point(114, 126);
		this.btn_set_year.Name = "btn_set_year";
		this.btn_set_year.Size = new System.Drawing.Size(90, 29);
		this.btn_set_year.TabIndex = 4;
		this.btn_set_year.Text = "باشه";
		this.btn_set_year.UseVisualStyleBackColor = false;
		this.btn_set_year.Click += new System.EventHandler(this.btn_set_year_Click);
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label10.ForeColor = System.Drawing.Color.White;
		this.label10.Location = new System.Drawing.Point(200, 82);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(111, 19);
		this.label10.TabIndex = 3;
		this.label10.Text = ": تاریخ انتشار تا";
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.ForeColor = System.Drawing.Color.White;
		this.label9.Location = new System.Drawing.Point(200, 30);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(112, 19);
		this.label9.TabIndex = 2;
		this.label9.Text = ": تاریخ انتشار از";
		this.textBox_year_to.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_year_to.Location = new System.Drawing.Point(47, 78);
		this.textBox_year_to.MaxLength = 4;
		this.textBox_year_to.Name = "textBox_year_to";
		this.textBox_year_to.Size = new System.Drawing.Size(147, 27);
		this.textBox_year_to.TabIndex = 1;
		this.textBox_year_to.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_year_to_KeyPress);
		this.textBox_year_from.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox_year_from.Location = new System.Drawing.Point(47, 27);
		this.textBox_year_from.MaxLength = 4;
		this.textBox_year_from.Name = "textBox_year_from";
		this.textBox_year_from.Size = new System.Drawing.Size(147, 27);
		this.textBox_year_from.TabIndex = 0;
		this.textBox_year_from.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_year_from_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DarkSlateGray;
		base.ClientSize = new System.Drawing.Size(1027, 478);
		base.Controls.Add(this.panel_select_year);
		base.Controls.Add(this.panel_search_pro);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "search_pro";
		this.Text = "search_pro";
		base.Load += new System.EventHandler(this.search_pro_Load);
		this.panel_search_pro.ResumeLayout(false);
		this.panel_search_pro.PerformLayout();
		this.panel_select_year.ResumeLayout(false);
		this.panel_select_year.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
