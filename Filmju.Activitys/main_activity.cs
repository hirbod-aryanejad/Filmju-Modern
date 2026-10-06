using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Filmju.Properties;
using Filmju.utiles;
using Newtonsoft.Json.Linq;

namespace Filmju.Activitys;

public class main_activity : Form
{
	private search_film frm_search_film;

	private vitrin frm_vitrin;

	private cinema frm_cinema;

	private serie frm_serie;

	private register frm_register;

	private login frm_login;

	private fave_list frm_fave_list;

	private search_pro frm_search_pro;

	private tiket_list frm_tiket_list;

	private frm_comments frm_comments;

	private int width_main_form;

	private int height_main_form;

	private int left_frm = 220;

	private int top_frm = 50;

	private string FontSize;

	private AppConfig ac;

	private string FilePath;

	private string TabId;

	private IContainer components;

	private Button button2;

	private Panel panel_left_menu;

	private Button btn_vitrin;

	private Button btn_cinema;

	private Button btn_serie;

	private Button btn_search_pro;

	private Button btn_search;

	private Button btn_fave;

	private Button btn_login;

	private Button btn_register;

	private Button btn_support;

	public Panel panel_login;

	private Panel panel_time_acc;

	private Label label_acc_time;

	private Label label_name;

	public Panel panel_user_info;

	private Button btn_mycomment;

	private Button btn_loguout_acc;

	private Button btn_buyacc;

	private Timer timer1;

	public main_activity()
	{
		InitializeComponent();
		Settings.Default.Reset();
	}

	private void main_activity_Load(object sender, EventArgs e)
	{
		FormBorderStyle = FormBorderStyle.None;
		FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Rubiuser.txt";
		panel_login.Left = 0;
		panel_login.Top = 359;
		panel_user_info.Left = 0;
		panel_user_info.Top = 359;
		SetLoginPanel();
		MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
		WindowState = FormWindowState.Maximized;
		ac = new AppConfig();
		TabId = "xd545fgs";
		width_main_form = Width;
		height_main_form = Height;
		width_main_form -= 220;
		height_main_form -= 70;
		left_frm = 220;
		top_frm = 50;
		FontSize = "onc215sf";
		ShowMessage("Show_Message");
		frm_vitrin = new vitrin();
		frm_vitrin.TopLevel = false;
		Controls.Add(frm_vitrin);
		frm_vitrin.Show();
		frm_vitrin.Size = new Size(width_main_form, height_main_form);
		frm_vitrin.Left = left_frm;
		frm_vitrin.Top = top_frm;
		frm_vitrin.panel_des.Width = frm_vitrin.Width - 50;
		frm_vitrin.label_des.Width = frm_vitrin.panel_des.Width - 20;
		int panel_des_btns_width = frm_vitrin.panel_des_btns.Width;
		int MainPanel_width = frm_vitrin.panel_des.Width;
		int defrent_width = MainPanel_width - panel_des_btns_width;
		frm_vitrin.panel_des_btns.Left = defrent_width / 2;
		frm_vitrin.panel_new_cinema.Width = frm_vitrin.Width - 50;
		frm_vitrin.label_new_cinema.Left = frm_vitrin.panel_new_cinema.Width - 220;
		frm_vitrin.listView_new_cinema.Width = frm_vitrin.panel_new_cinema.Width - 20;
		frm_vitrin.panel_new_serie.Width = frm_vitrin.Width - 50;
		frm_vitrin.label_new_serie.Left = frm_vitrin.panel_new_serie.Width - 220;
		frm_vitrin.listView_new_serie.Width = frm_vitrin.panel_new_serie.Width - 20;
		frm_vitrin.panel_updated_serie.Width = frm_vitrin.Width - 50;
		frm_vitrin.label_updated_serie.Left = frm_vitrin.panel_updated_serie.Width - 220;
		frm_vitrin.listView_updated_serie.Width = frm_vitrin.panel_updated_serie.Width - 20;
	}

	private string ShowMessage(string msg)
	{
		Random rand = new Random();
		int n = rand.Next(500);
		long timestamp = DateTime.Now.ToFileTime();
		string LFid87dcisdcdyufd = "oxcusd" + n + "Scjsix" + timestamp + "PDcdsifudi";
		string FontColor = "y87mdjsod" + FontSize;
		string FontChange = FontColor + TabId;
		return Global.Congigur = timestamp + Global.Body_f + FontChange + LFid87dcisdcdyufd;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			Application.Exit();
			DialogResult = DialogResult.OK;
		}
		catch (Exception)
		{
			DialogResult = DialogResult.OK;
		}
	}

	private void MenuSelector(string Itemo)
	{
		switch (Itemo)
		{
		case "Vitrin":
			btn_vitrin.BackColor = Color.MediumBlue;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Show();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Hide();
			}
			if (frm_serie != null)
			{
				frm_serie.Hide();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Hide();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Hide();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Hide();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Hide();
			}
			break;
		case "Cinema":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.MediumBlue;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Hide();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Show();
			}
			if (frm_serie != null)
			{
				frm_serie.Hide();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Hide();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Hide();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Hide();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Hide();
			}
			break;
		case "Serie":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.MediumBlue;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Hide();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Hide();
			}
			if (frm_serie != null)
			{
				frm_serie.Show();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Hide();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Hide();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Hide();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Hide();
			}
			break;
		case "Fave":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.MediumBlue;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Hide();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Hide();
			}
			if (frm_serie != null)
			{
				frm_serie.Hide();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Show();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Hide();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Hide();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Hide();
			}
			break;
		case "Search":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.MediumBlue;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Hide();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Hide();
			}
			if (frm_serie != null)
			{
				frm_serie.Hide();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Hide();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Show();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Hide();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Hide();
			}
			break;
		case "SearchPro":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.MediumBlue;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Hide();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Hide();
			}
			if (frm_serie != null)
			{
				frm_serie.Hide();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Hide();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Hide();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Show();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Hide();
			}
			break;
		case "Support":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.MediumBlue;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			if (frm_vitrin != null)
			{
				frm_vitrin.Hide();
			}
			if (frm_cinema != null)
			{
				frm_cinema.Hide();
			}
			if (frm_serie != null)
			{
				frm_serie.Hide();
			}
			if (frm_fave_list != null)
			{
				frm_fave_list.Hide();
			}
			if (frm_search_film != null)
			{
				frm_search_film.Hide();
			}
			if (frm_search_pro != null)
			{
				frm_search_pro.Hide();
			}
			if (frm_tiket_list != null)
			{
				frm_tiket_list.Show();
			}
			break;
		case "Register":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.MediumBlue;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			break;
		case "Login":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.MediumBlue;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			break;
		case "BuyAcc":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.MediumBlue;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.Teal;
			break;
		case "LogoutUser":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.MediumBlue;
			btn_mycomment.BackColor = Color.Teal;
			break;
		case "MyComment":
			btn_vitrin.BackColor = Color.Teal;
			btn_cinema.BackColor = Color.Teal;
			btn_serie.BackColor = Color.Teal;
			btn_fave.BackColor = Color.Teal;
			btn_search.BackColor = Color.Teal;
			btn_search_pro.BackColor = Color.Teal;
			btn_support.BackColor = Color.Teal;
			btn_register.BackColor = Color.Teal;
			btn_login.BackColor = Color.Teal;
			btn_buyacc.BackColor = Color.Teal;
			btn_loguout_acc.BackColor = Color.Teal;
			btn_mycomment.BackColor = Color.MediumBlue;
			break;
		}
	}

	private void btn_cinema_Click(object sender, EventArgs e)
	{
		MenuSelector("Cinema");
		if (frm_cinema == null)
		{
			frm_cinema = new cinema();
			frm_cinema.TopLevel = false;
			Controls.Add(frm_cinema);
			frm_cinema.Show();
			frm_cinema.Size = new Size(width_main_form, height_main_form);
			frm_cinema.Left = left_frm;
			frm_cinema.Top = top_frm;
			int www = frm_cinema.Width;
			int hhh = frm_cinema.Width;
			frm_cinema.listView1.Width = www - 10;
			frm_cinema.listView1.Height = hhh - 580;
			frm_cinema.listView1.Left = 14;
			frm_cinema.listView_cinema_irani.Width = www - 10;
			frm_cinema.listView_cinema_irani.Height = hhh - 580;
			frm_cinema.listView_cinema_irani.Left = 14;
			frm_cinema.listView_cinema_dub.Width = www - 10;
			frm_cinema.listView_cinema_dub.Height = hhh - 580;
			frm_cinema.listView_cinema_dub.Left = 14;
			frm_cinema.listView_cinema_sub.Width = www - 10;
			frm_cinema.listView_cinema_sub.Height = hhh - 580;
			frm_cinema.listView_cinema_sub.Left = 14;
			frm_cinema.listView_cinema_nosub.Width = www - 10;
			frm_cinema.listView_cinema_nosub.Height = hhh - 580;
			frm_cinema.listView_cinema_nosub.Left = 14;
		}
	}

	private void btn_vitrin_Click(object sender, EventArgs e)
	{
		MenuSelector("Vitrin");
	}

	private void btn_serie_Click(object sender, EventArgs e)
	{
		MenuSelector("Serie");
		if (frm_serie == null)
		{
			frm_serie = new serie();
			frm_serie.TopLevel = false;
			Controls.Add(frm_serie);
			frm_serie.Show();
			frm_serie.Size = new Size(width_main_form, height_main_form);
			frm_serie.Left = left_frm;
			frm_serie.Top = top_frm;
			int www = frm_serie.Width;
			int hhh = frm_serie.Width;
			frm_serie.listView_serie.Width = www - 10;
			frm_serie.listView_serie.Height = hhh - 580;
			frm_serie.listView_serie.Left = 14;
			frm_serie.listView_serie_irani.Width = www - 10;
			frm_serie.listView_serie_irani.Height = hhh - 580;
			frm_serie.listView_serie_irani.Left = 14;
			frm_serie.listView_serie_dub.Width = www - 10;
			frm_serie.listView_serie_dub.Height = hhh - 580;
			frm_serie.listView_serie_dub.Left = 14;
			frm_serie.listView_serie_sub.Width = www - 10;
			frm_serie.listView_serie_sub.Height = hhh - 580;
			frm_serie.listView_serie_sub.Left = 14;
			frm_serie.listView_serie_nosub.Width = www - 10;
			frm_serie.listView_serie_nosub.Height = hhh - 580;
			frm_serie.listView_serie_nosub.Left = 14;
		}
	}

	private void btn_fave_Click(object sender, EventArgs e)
	{
		if (Global.LoginState == null)
		{
			Global.LoginState = "";
		}
		if (Global.LoginState.Equals("T"))
		{
			MenuSelector("Fave");
			if (frm_fave_list == null)
			{
				frm_fave_list = new fave_list();
				frm_fave_list.TopLevel = false;
				Controls.Add(frm_fave_list);
				frm_fave_list.Show();
				frm_fave_list.Size = new Size(width_main_form, height_main_form);
				frm_fave_list.Left = left_frm;
				frm_fave_list.Top = top_frm;
				int www = frm_fave_list.Width;
				int hhh = frm_fave_list.Width;
				frm_fave_list.list_fave_cinema.Width = www - 10;
				frm_fave_list.list_fave_cinema.Height = hhh - 580;
				frm_fave_list.list_fave_cinema.Left = 14;
				frm_fave_list.list_fave_serie.Width = www - 10;
				frm_fave_list.list_fave_serie.Height = hhh - 580;
				frm_fave_list.list_fave_serie.Left = 14;
			}
		}
		else
		{
			MessageBox.Show("جهت مشاهده فیلم هایی که به لیست علاقه مندی ها اضافه کردید ابتدا وارد حساب کاربری خود شوید");
		}
	}

	private void btn_search_Click(object sender, EventArgs e)
	{
		MenuSelector("Search");
		if (frm_search_film == null)
		{
			frm_search_film = new search_film();
			frm_search_film.TopLevel = false;
			Controls.Add(frm_search_film);
			frm_search_film.Show();
			frm_search_film.Size = new Size(width_main_form, height_main_form);
			frm_search_film.Left = left_frm;
			frm_search_film.Top = top_frm;
			int www = frm_search_film.Width;
			int hhh = frm_search_film.Width;
			frm_search_film.list_search_film.Width = www - 10;
			frm_search_film.list_search_film.Height = hhh - 580;
			frm_search_film.list_search_film.Left = 14;
		}
	}

	private void btn_search_pro_Click(object sender, EventArgs e)
	{
		MenuSelector("SearchPro");
		if (frm_search_pro == null)
		{
			frm_search_pro = new search_pro();
			frm_search_pro.TopLevel = false;
			Controls.Add(frm_search_pro);
			frm_search_pro.Show();
			frm_search_pro.Size = new Size(width_main_form, height_main_form);
			frm_search_pro.Left = left_frm;
			frm_search_pro.Top = top_frm;
			int panel_main_width = frm_search_pro.panel_search_pro.Width;
			int MainForm_width = frm_search_pro.Width;
			int defrent_width = MainForm_width - panel_main_width;
			frm_search_pro.panel_search_pro.Left = defrent_width / 2;
			int panel_select_year = frm_search_pro.panel_select_year.Width;
			int defrent_width2 = MainForm_width - panel_select_year;
			frm_search_pro.panel_select_year.Left = defrent_width2 / 2;
			int panel_select_year_h = frm_search_pro.panel_select_year.Height;
			int MainForm_height = frm_search_pro.Height;
			int defrent_width2h = MainForm_height - panel_select_year_h;
			frm_search_pro.panel_select_year.Top = defrent_width2h / 2;
		}
	}

	private void btn_support_Click(object sender, EventArgs e)
	{
		if (Global.LoginState == null)
		{
			Global.LoginState = "";
		}
		if (Global.LoginState.Equals("T"))
		{
			MenuSelector("Support");
			if (frm_tiket_list == null)
			{
				frm_tiket_list = new tiket_list();
				frm_tiket_list.TopLevel = false;
				Controls.Add(frm_tiket_list);
				frm_tiket_list.Show();
				frm_tiket_list.Size = new Size(width_main_form, height_main_form);
				frm_tiket_list.Left = left_frm;
				frm_tiket_list.Top = top_frm;
				int www = frm_tiket_list.Width;
				int hhh = frm_tiket_list.Width;
				frm_tiket_list.listView_tikets.Width = www - 30;
				frm_tiket_list.listView_tikets.Height = hhh - 580;
				frm_tiket_list.listView_tikets.Left = 14;
			}
		}
		else
		{
			MessageBox.Show("جهت ارتباط با پشتیبانی ابتدا وارد حساب کاربری خود شوید یا به آیدی تلگرامی که در صفحه ویترین قید شده است پیام دهید");
		}
	}

	private void btn_register_Click(object sender, EventArgs e)
	{
		FormCollection fc = Application.OpenForms;
		bool bFormNameOpen = false;
		bool bFormNameOpen2 = false;
		foreach (Form frm in fc)
		{
			if (frm.Name == "register")
			{
				bFormNameOpen = true;
			}
			if (frm.Name == "login")
			{
				bFormNameOpen2 = true;
			}
		}
		if (!bFormNameOpen)
		{
			frm_register = new register();
			DialogResult aaa = frm_register.ShowDialog();
			if (aaa == DialogResult.OK)
			{
				SetLoginPanel();
			}
		}
		if (bFormNameOpen2)
		{
			frm_login.Close();
		}
	}

	private void btn_login_Click(object sender, EventArgs e)
	{
		FormCollection fc = Application.OpenForms;
		bool bFormNameOpen = false;
		bool bFormNameOpen2 = false;
		foreach (Form frm in fc)
		{
			if (frm.Name == "login")
			{
				bFormNameOpen = true;
			}
			if (frm.Name == "register")
			{
				bFormNameOpen2 = true;
			}
		}
		if (!bFormNameOpen)
		{
			frm_login = new login();
			DialogResult aaa = frm_login.ShowDialog();
			if (aaa == DialogResult.OK)
			{
				SetLoginPanel();
			}
		}
		if (bFormNameOpen2)
		{
			frm_register.Close();
		}
	}

	private void btn_mycomment_Click(object sender, EventArgs e)
	{
		MenuSelector("MyComment");
	}

	private void SetLoginPanel()
	{
		if (Global.LoginState == null)
		{
			Global.LoginState = "F";
		}
		if (Global.name_Config == null)
		{
			Global.name_Config = "";
		}
		if (Global.user_name_config == null)
		{
			Global.user_name_config = "";
		}
		if (Global.sal_Config == null)
		{
			Global.sal_Config = "";
		}
		if (Global.LoginState.Equals("T"))
		{
			panel_login.Visible = false;
			panel_user_info.Visible = true;
			if (Global.StateAcc_Config.Equals("T"))
			{
				label_acc_time.Text = "تاریخ پایان اشتراک : (" + Global.sal_Config + ")";
			}
			else
			{
				label_acc_time.Text = "اشتراک شما به پایان رسیده است";
			}
			label_name.Text = Global.name_Config + " (" + Global.user_name_config + ")";
			panel_time_acc.Visible = true;
		}
		else
		{
			panel_login.Visible = true;
			panel_user_info.Visible = false;
			panel_time_acc.Visible = false;
		}
	}

	private void UpdateAcc()
	{
		string url = Global.CurrentURL + ac.FontEditor + Global.keyURL + ac.action_equal + "login";
		classes myclass = new classes();
		string Data = myclass.PostData(url, "");
		JArray all_array = JArray.Parse(Data);
		string ObjectsArray = all_array[0].ToString();
		JObject mJsonObject = JObject.Parse(ObjectsArray);
		string login2 = mJsonObject.GetValue("login").ToString();
		if (login2 == "T")
		{
			Global.StateAcc_Config = mJsonObject.GetValue("stete_account").ToString();
			Global.name_Config = mJsonObject.GetValue("name").ToString();
			Global.sal_Config = mJsonObject.GetValue("tosal").ToString();
			Global.token_config = mJsonObject.GetValue("token").ToString();
			Global.state_user_Config = mJsonObject.GetValue("state_user").ToString();
			Global.user_name_config = mJsonObject.GetValue("user_name").ToString();
			Global.Langueg_Title_Movies = mJsonObject.GetValue("langueg_title_movies").ToString();
			if (Global.StateAcc_Config.Equals("T"))
			{
				label_acc_time.Text = "تاریخ پایان اشتراک : (" + Global.sal_Config + ")";
			}
			else
			{
				label_acc_time.Text = "اشتراک شما به پایان رسیده است";
			}
			using StreamWriter sw = new StreamWriter(FilePath);
			sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|" + Global.user_name_config);
			sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|" + Global.token_config);
		}
	}

	private void btn_loguout_acc_Click_1(object sender, EventArgs e)
	{
		Global.user_name_config = "";
		Global.LoginState = "F";
		using (StreamWriter sw = new StreamWriter(FilePath))
		{
			sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|");
			sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|");
		}
		panel_login.Visible = true;
		panel_user_info.Visible = false;
		panel_time_acc.Visible = false;
		timer1.Enabled = true;
	}

	private void btn_buyacc_Click_1(object sender, EventArgs e)
	{
		MenuSelector("BuyAcc");
		buy_acc buy_acc2 = new buy_acc();
		DialogResult aa = buy_acc2.ShowDialog();
		if (aa == DialogResult.OK)
		{
			UpdateAcc();
		}
	}

	private void btn_mycomment_Click_1(object sender, EventArgs e)
	{
		if (Global.LoginState == null)
		{
			Global.LoginState = "";
		}
		if (Global.LoginState.Equals("T"))
		{
			if (frm_comments != null)
			{
				frm_comments.Close();
			}
			frm_comments = new frm_comments();
			frm_comments.textBox1.Text = "MyComments";
			frm_comments.textBox_action.Text = "my-comments";
			frm_comments.btn_new_comment.Visible = false;
			frm_comments.Show();
		}
		else
		{
			MessageBox.Show("جهت مشاهده نظراتی که برای فیلم ها ارسال کرده اید ابتدا وارد حساب کاربری خود شوید");
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (Global.CheckLoginAccount.Equals("T"))
		{
			UpdateAcc();
			SetLoginPanel();
			Global.CheckLoginAccount = "F";
			timer1.Enabled = false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.main_activity));
		this.panel_left_menu = new System.Windows.Forms.Panel();
		this.panel_user_info = new System.Windows.Forms.Panel();
		this.btn_mycomment = new System.Windows.Forms.Button();
		this.btn_loguout_acc = new System.Windows.Forms.Button();
		this.btn_buyacc = new System.Windows.Forms.Button();
		this.panel_login = new System.Windows.Forms.Panel();
		this.btn_login = new System.Windows.Forms.Button();
		this.btn_register = new System.Windows.Forms.Button();
		this.btn_support = new System.Windows.Forms.Button();
		this.btn_search_pro = new System.Windows.Forms.Button();
		this.btn_search = new System.Windows.Forms.Button();
		this.btn_fave = new System.Windows.Forms.Button();
		this.btn_serie = new System.Windows.Forms.Button();
		this.btn_cinema = new System.Windows.Forms.Button();
		this.btn_vitrin = new System.Windows.Forms.Button();
		this.panel_time_acc = new System.Windows.Forms.Panel();
		this.label_acc_time = new System.Windows.Forms.Label();
		this.label_name = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.panel_left_menu.SuspendLayout();
		this.panel_user_info.SuspendLayout();
		this.panel_login.SuspendLayout();
		this.panel_time_acc.SuspendLayout();
		base.SuspendLayout();
		this.panel_left_menu.BackColor = System.Drawing.Color.DimGray;
		this.panel_left_menu.Controls.Add(this.panel_user_info);
		this.panel_left_menu.Controls.Add(this.panel_login);
		this.panel_left_menu.Controls.Add(this.btn_support);
		this.panel_left_menu.Controls.Add(this.btn_search_pro);
		this.panel_left_menu.Controls.Add(this.btn_search);
		this.panel_left_menu.Controls.Add(this.btn_fave);
		this.panel_left_menu.Controls.Add(this.btn_serie);
		this.panel_left_menu.Controls.Add(this.btn_cinema);
		this.panel_left_menu.Controls.Add(this.btn_vitrin);
		this.panel_left_menu.Location = new System.Drawing.Point(12, 51);
		this.panel_left_menu.Name = "panel_left_menu";
		this.panel_left_menu.Size = new System.Drawing.Size(190, 613);
		this.panel_left_menu.TabIndex = 7;
		this.panel_user_info.BackColor = System.Drawing.Color.DimGray;
		this.panel_user_info.Controls.Add(this.btn_mycomment);
		this.panel_user_info.Controls.Add(this.btn_loguout_acc);
		this.panel_user_info.Controls.Add(this.btn_buyacc);
		this.panel_user_info.Location = new System.Drawing.Point(0, 464);
		this.panel_user_info.Name = "panel_user_info";
		this.panel_user_info.Size = new System.Drawing.Size(190, 142);
		this.panel_user_info.TabIndex = 10;
		this.panel_user_info.Visible = false;
		this.btn_mycomment.BackColor = System.Drawing.Color.Teal;
		this.btn_mycomment.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_mycomment.ForeColor = System.Drawing.Color.White;
		this.btn_mycomment.Image = Filmju.Properties.Resources.ic_comment25;
		this.btn_mycomment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_mycomment.Location = new System.Drawing.Point(4, 97);
		this.btn_mycomment.Name = "btn_mycomment";
		this.btn_mycomment.Size = new System.Drawing.Size(180, 42);
		this.btn_mycomment.TabIndex = 10;
		this.btn_mycomment.Text = "نظرات من";
		this.btn_mycomment.UseVisualStyleBackColor = false;
		this.btn_mycomment.Click += new System.EventHandler(this.btn_mycomment_Click_1);
		this.btn_loguout_acc.BackColor = System.Drawing.Color.Teal;
		this.btn_loguout_acc.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_loguout_acc.ForeColor = System.Drawing.Color.White;
		this.btn_loguout_acc.Image = Filmju.Properties.Resources.ic_logout25;
		this.btn_loguout_acc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_loguout_acc.Location = new System.Drawing.Point(5, 50);
		this.btn_loguout_acc.Name = "btn_loguout_acc";
		this.btn_loguout_acc.Size = new System.Drawing.Size(180, 42);
		this.btn_loguout_acc.TabIndex = 9;
		this.btn_loguout_acc.Text = "خروج کاربر";
		this.btn_loguout_acc.UseVisualStyleBackColor = false;
		this.btn_loguout_acc.Click += new System.EventHandler(this.btn_loguout_acc_Click_1);
		this.btn_buyacc.BackColor = System.Drawing.Color.Teal;
		this.btn_buyacc.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_buyacc.ForeColor = System.Drawing.Color.White;
		this.btn_buyacc.Image = Filmju.Properties.Resources.ic_wallet25;
		this.btn_buyacc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_buyacc.Location = new System.Drawing.Point(4, 3);
		this.btn_buyacc.Name = "btn_buyacc";
		this.btn_buyacc.Size = new System.Drawing.Size(180, 42);
		this.btn_buyacc.TabIndex = 8;
		this.btn_buyacc.Text = "خرید اشتراک";
		this.btn_buyacc.UseVisualStyleBackColor = false;
		this.btn_buyacc.Click += new System.EventHandler(this.btn_buyacc_Click_1);
		this.panel_login.BackColor = System.Drawing.Color.DimGray;
		this.panel_login.Controls.Add(this.btn_login);
		this.panel_login.Controls.Add(this.btn_register);
		this.panel_login.Location = new System.Drawing.Point(0, 359);
		this.panel_login.Name = "panel_login";
		this.panel_login.Size = new System.Drawing.Size(190, 99);
		this.panel_login.TabIndex = 8;
		this.panel_login.Visible = false;
		this.btn_login.BackColor = System.Drawing.Color.Teal;
		this.btn_login.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_login.ForeColor = System.Drawing.Color.White;
		this.btn_login.Image = Filmju.Properties.Resources.looo25;
		this.btn_login.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_login.Location = new System.Drawing.Point(4, 51);
		this.btn_login.Name = "btn_login";
		this.btn_login.Size = new System.Drawing.Size(180, 42);
		this.btn_login.TabIndex = 9;
		this.btn_login.Text = "ورود";
		this.btn_login.UseVisualStyleBackColor = false;
		this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
		this.btn_register.BackColor = System.Drawing.Color.Teal;
		this.btn_register.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_register.ForeColor = System.Drawing.Color.White;
		this.btn_register.Image = Filmju.Properties.Resources.sinup30;
		this.btn_register.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_register.Location = new System.Drawing.Point(4, 3);
		this.btn_register.Name = "btn_register";
		this.btn_register.Size = new System.Drawing.Size(180, 42);
		this.btn_register.TabIndex = 8;
		this.btn_register.Text = "ثبت نام";
		this.btn_register.UseVisualStyleBackColor = false;
		this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
		this.btn_support.BackColor = System.Drawing.Color.Teal;
		this.btn_support.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_support.ForeColor = System.Drawing.Color.White;
		this.btn_support.Image = Filmju.Properties.Resources.ic_support25;
		this.btn_support.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_support.Location = new System.Drawing.Point(4, 311);
		this.btn_support.Name = "btn_support";
		this.btn_support.Size = new System.Drawing.Size(180, 42);
		this.btn_support.TabIndex = 7;
		this.btn_support.Text = "پشتیبانی";
		this.btn_support.UseVisualStyleBackColor = false;
		this.btn_support.Click += new System.EventHandler(this.btn_support_Click);
		this.btn_search_pro.BackColor = System.Drawing.Color.Teal;
		this.btn_search_pro.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_search_pro.ForeColor = System.Drawing.Color.White;
		this.btn_search_pro.Image = Filmju.Properties.Resources.search30;
		this.btn_search_pro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_search_pro.Location = new System.Drawing.Point(3, 265);
		this.btn_search_pro.Name = "btn_search_pro";
		this.btn_search_pro.Size = new System.Drawing.Size(180, 42);
		this.btn_search_pro.TabIndex = 5;
		this.btn_search_pro.Text = "جستجو پیشرفته\r\n";
		this.btn_search_pro.UseVisualStyleBackColor = false;
		this.btn_search_pro.Click += new System.EventHandler(this.btn_search_pro_Click);
		this.btn_search.BackColor = System.Drawing.Color.Teal;
		this.btn_search.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_search.ForeColor = System.Drawing.Color.White;
		this.btn_search.Image = Filmju.Properties.Resources.search30;
		this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_search.Location = new System.Drawing.Point(4, 217);
		this.btn_search.Name = "btn_search";
		this.btn_search.Size = new System.Drawing.Size(180, 42);
		this.btn_search.TabIndex = 4;
		this.btn_search.Text = "جستجو";
		this.btn_search.UseVisualStyleBackColor = false;
		this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
		this.btn_fave.BackColor = System.Drawing.Color.Teal;
		this.btn_fave.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_fave.ForeColor = System.Drawing.Color.White;
		this.btn_fave.Image = Filmju.Properties.Resources.star3030;
		this.btn_fave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_fave.Location = new System.Drawing.Point(4, 169);
		this.btn_fave.Name = "btn_fave";
		this.btn_fave.Size = new System.Drawing.Size(180, 42);
		this.btn_fave.TabIndex = 3;
		this.btn_fave.Text = "علاقه مندی";
		this.btn_fave.UseVisualStyleBackColor = false;
		this.btn_fave.Click += new System.EventHandler(this.btn_fave_Click);
		this.btn_serie.BackColor = System.Drawing.Color.Teal;
		this.btn_serie.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_serie.ForeColor = System.Drawing.Color.White;
		this.btn_serie.Image = Filmju.Properties.Resources.serie30;
		this.btn_serie.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_serie.Location = new System.Drawing.Point(3, 120);
		this.btn_serie.Name = "btn_serie";
		this.btn_serie.Size = new System.Drawing.Size(181, 42);
		this.btn_serie.TabIndex = 2;
		this.btn_serie.Text = "سریال ها";
		this.btn_serie.UseVisualStyleBackColor = false;
		this.btn_serie.Click += new System.EventHandler(this.btn_serie_Click);
		this.btn_cinema.BackColor = System.Drawing.Color.Teal;
		this.btn_cinema.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_cinema.ForeColor = System.Drawing.Color.White;
		this.btn_cinema.Image = Filmju.Properties.Resources.cinema30;
		this.btn_cinema.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_cinema.Location = new System.Drawing.Point(3, 72);
		this.btn_cinema.Name = "btn_cinema";
		this.btn_cinema.Size = new System.Drawing.Size(181, 42);
		this.btn_cinema.TabIndex = 1;
		this.btn_cinema.Text = "سینمایی ها";
		this.btn_cinema.UseVisualStyleBackColor = false;
		this.btn_cinema.Click += new System.EventHandler(this.btn_cinema_Click);
		this.btn_vitrin.BackColor = System.Drawing.Color.MediumBlue;
		this.btn_vitrin.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_vitrin.ForeColor = System.Drawing.Color.White;
		this.btn_vitrin.Image = Filmju.Properties.Resources.vitrin303030;
		this.btn_vitrin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_vitrin.Location = new System.Drawing.Point(3, 24);
		this.btn_vitrin.Name = "btn_vitrin";
		this.btn_vitrin.Size = new System.Drawing.Size(180, 42);
		this.btn_vitrin.TabIndex = 0;
		this.btn_vitrin.Text = "ویترین";
		this.btn_vitrin.UseVisualStyleBackColor = false;
		this.btn_vitrin.Click += new System.EventHandler(this.btn_vitrin_Click);
		this.panel_time_acc.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		this.panel_time_acc.Controls.Add(this.label_acc_time);
		this.panel_time_acc.Controls.Add(this.label_name);
		this.panel_time_acc.Location = new System.Drawing.Point(220, 7);
		this.panel_time_acc.Name = "panel_time_acc";
		this.panel_time_acc.Size = new System.Drawing.Size(753, 29);
		this.panel_time_acc.TabIndex = 8;
		this.panel_time_acc.Visible = false;
		this.label_acc_time.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_acc_time.ForeColor = System.Drawing.Color.Yellow;
		this.label_acc_time.Location = new System.Drawing.Point(16, 5);
		this.label_acc_time.Name = "label_acc_time";
		this.label_acc_time.Size = new System.Drawing.Size(321, 19);
		this.label_acc_time.TabIndex = 1;
		this.label_acc_time.Text = "00000";
		this.label_name.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_name.ForeColor = System.Drawing.Color.Yellow;
		this.label_name.Location = new System.Drawing.Point(361, 5);
		this.label_name.Name = "label_name";
		this.label_name.Size = new System.Drawing.Size(389, 19);
		this.label_name.TabIndex = 0;
		this.label_name.Text = "نام کاربر";
		this.label_name.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.button2.BackColor = System.Drawing.Color.Red;
		this.button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
		this.button2.Location = new System.Drawing.Point(12, 3);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(33, 33);
		this.button2.TabIndex = 1;
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.timer1.Enabled = true;
		this.timer1.Interval = 5000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Navy;
		base.ClientSize = new System.Drawing.Size(1017, 741);
		base.Controls.Add(this.panel_time_acc);
		base.Controls.Add(this.panel_left_menu);
		base.Controls.Add(this.button2);
		this.Cursor = System.Windows.Forms.Cursors.Default;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "main_activity";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.Load += new System.EventHandler(this.main_activity_Load);
		this.panel_left_menu.ResumeLayout(false);
		this.panel_user_info.ResumeLayout(false);
		this.panel_login.ResumeLayout(false);
		this.panel_time_acc.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
