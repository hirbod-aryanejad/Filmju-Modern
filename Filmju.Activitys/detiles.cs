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

public class detiles : Form
{
	private string video_id;

	private AppConfig ac;

	private string Data_Comments;

	private string DataLinks;

	private string Subtitles;

	private string What;

	private string State_Play;

	private string State_Download;

	private link_list link_list_download;

	private link_list link_list_play;

	private string Fav_State;

	private string trailer_url;

	private frm_loading frm_loading;

	private int timee;

	private int timee2;

	private IContainer components;

	private Panel panel_main;

	public TextBox txt_video_id;

	private Panel panel2;

	private PictureBox pictureBox_poster;

	private Panel panel3;

	private Button btn_download;

	private Button btn_play;

	private Button btn_add_fav;

	private Label label_country;

	private Label label6;

	private Label label_genre;

	private Label label4;

	private Label label_imdb;

	private Label label2;

	private Label label_title;

	private Button btn_download_sub;

	private Button btn_comments;

	private Button btn_back;

	private Label label_year;

	private Label label9;

	private TextBox textBox1;

	private Panel panel1;

	private Label label_des;

	private Timer timer1;

	private Timer timer_fav;

	private Button btn_trailer;

	public detiles()
	{
		InitializeComponent();
	}

	private void detiles_Load(object sender, EventArgs e)
	{
		State_Play = "F";
		State_Download = "F";
		Fav_State = "";
		trailer_url = "";
		Subtitles = "";
		if (Global.user_name_config == null)
		{
			Global.user_name_config = "";
		}
		if (Global.StateAcc_Config == null)
		{
			Global.StateAcc_Config = "F";
		}
		if (Global.LoginState == null)
		{
			Global.LoginState = "F";
		}
		video_id = txt_video_id.Text;
		ac = new AppConfig();
		DataLinks = "";
		What = "";
		Data_Comments = "";
		FormBorderStyle = FormBorderStyle.None;
		MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
		WindowState = FormWindowState.Maximized;
		int panel_main_width = panel_main.Width;
		int MainForm_width = Width;
		int defrent_width = MainForm_width - panel_main_width;
		panel_main.Left = defrent_width / 2;
		btn_back.Left = defrent_width / 2;
		if (video_id == null)
		{
			video_id = "";
		}
		if (!video_id.Equals(""))
		{
			timer1.Enabled = true;
		}
	}

	private void btn_back_Click(object sender, EventArgs e)
	{
		try
		{
			if (link_list_play != null)
			{
				link_list_play.Close();
			}
			if (link_list_download != null)
			{
				link_list_download.Close();
			}
			ShowLableLoaing("hide");
			Close();
		}
		catch (Exception)
		{
			Close();
		}
	}

	private void SetDataDetitles()
	{
		try
		{
			string url = Global.CurrentURL + ac.wiinapVll + Global.keyURL + ac.action_equal + "detials";
			classes myclass = new classes();
			string Args1 = myclass.CreateArgs("user_name", Global.user_name_config);
			string Args2 = myclass.CreateArgs("token", Global.token_config);
			string Args3 = myclass.CreateArgs("id", video_id);
			string Args4 = myclass.CreateArgs("langueg", "");
			string Args5 = Args1 + "&" + Args2 + "&" + Args3 + "&" + Args4;
			string Data = myclass.PostData(url, Args5);
			if (Data.Equals("Error"))
			{
				MessageBox.Show("خطا در ارتباط با سرور! مجدد تلاش کنید");
			}
			else
			{
				JObject obj_all = JObject.Parse(Data);
				string detiles2 = obj_all.GetValue("detiles").ToString();
				Data_Comments = obj_all.GetValue("comments").ToString();
				JArray arr_detiles = JArray.Parse(detiles2);
				string ObjectsArray = arr_detiles[0].ToString();
				JObject mJsonObject = JObject.Parse(ObjectsArray);
				string title = mJsonObject.GetValue("title").ToString();
				string description = mJsonObject.GetValue("description").ToString();
				string year = mJsonObject.GetValue("year").ToString();
				string imdb_rating = mJsonObject.GetValue("imdb_rating").ToString();
				string thumbnail_url = mJsonObject.GetValue("thumbnail_url").ToString();
				trailer_url = mJsonObject.GetValue("trailer_url").ToString();
				string genre = mJsonObject.GetValue("genre").ToString();
				string country = mJsonObject.GetValue("country").ToString();
				State_Download = mJsonObject.GetValue("StateDownload").ToString();
				State_Play = mJsonObject.GetValue("StatePlay").ToString();
				Global.LinkLearnPlayOnline = mJsonObject.GetValue("LinkLearnPlayOnline").ToString();
				What = mJsonObject.GetValue("is_movie").ToString();
				DataLinks = mJsonObject.GetValue("download_link").ToString();
				Fav_State = mJsonObject.GetValue("fav").ToString();
				string is_duble = mJsonObject.GetValue("is_duble").ToString();
				Subtitles = mJsonObject.GetValue("subtitles").ToString();
				label_title.Text = title;
				label_des.Text = description;
				label_imdb.Text = imdb_rating;
				label_genre.Text = genre;
				label_country.Text = country;
				label_year.Text = year;
				textBox1.Text = detiles2 ?? "";
				btn_add_fav.Enabled = true;
				btn_comments.Enabled = true;
				btn_play.Enabled = true;
				btn_download.Enabled = true;
				if (trailer_url == null)
				{
					trailer_url = "";
				}
				if (!trailer_url.Equals(""))
				{
					btn_trailer.Enabled = true;
				}
				if (Fav_State.Equals("T"))
				{
					btn_add_fav.Text = "حذف";
					btn_add_fav.Image = Resources.star_full3030;
				}
				else
				{
					btn_add_fav.Text = "افزودن";
					btn_add_fav.Image = Resources.star3030;
				}
				if (is_duble == null)
				{
					is_duble = "";
				}
				if (!Subtitles.Equals(""))
				{
					JArray all_array = JArray.Parse(Subtitles);
					int Len_json_sub = all_array.Count;
					if (Len_json_sub > 0)
					{
						btn_download_sub.Enabled = true;
					}
					else
					{
						btn_download_sub.Enabled = false;
					}
				}
				WebRequest request = WebRequest.Create(thumbnail_url);
				using WebResponse response = request.GetResponse();
				using Stream stream = response.GetResponseStream();
				pictureBox_poster.Image = Image.FromStream(stream);
			}
		}
		catch (Exception)
		{
		}
		ShowLableLoaing("hide");
	}

	private void btn_play_Click(object sender, EventArgs e)
	{
		if (State_Play == null)
		{
			State_Play = "";
		}
		bool Checking = true;
		if (State_Play.Equals("T"))
		{
			Checking = true;
		}
		else if (State_Play.Equals("F"))
		{
			Checking = false;
		}
		if (Checking)
		{
			if (Global.LoginState.Equals("T"))
			{
				if (Global.StateAcc_Config.Equals("T"))
				{
					Checking = false;
				}
				else
				{
					ShowPopBuyAcc("play");
				}
			}
			else
			{
				ShowPopLogin("play");
			}
		}
		if (Checking)
		{
			return;
		}
		if (DataLinks == null)
		{
			DataLinks = "";
		}
		if (!DataLinks.Equals(""))
		{
			try
			{
				if (link_list_play != null)
				{
					link_list_play.Close();
				}
			}
			catch (Exception)
			{
			}
			link_list_play = new link_list();
			link_list_play.textBox_links.Text = DataLinks;
			link_list_play.textBox_what.Text = What;
			link_list_play.textBox_PlayDown.Text = "Play";
			link_list_play.Show();
		}
		else
		{
			MessageBox.Show("لطفا صبر کنید تا بارگذاری کامل شود");
		}
	}

	private void btn_download_Click(object sender, EventArgs e)
	{
		if (State_Download == null)
		{
			State_Download = "";
		}
		bool Checking = true;
		if (State_Download.Equals("T"))
		{
			Checking = true;
		}
		else if (State_Download.Equals("F"))
		{
			Checking = false;
		}
		if (Checking)
		{
			if (Global.LoginState.Equals("T"))
			{
				if (Global.StateAcc_Config.Equals("T"))
				{
					Checking = false;
				}
				else
				{
					ShowPopBuyAcc("download");
				}
			}
			else
			{
				ShowPopLogin("download");
			}
		}
		if (Checking)
		{
			return;
		}
		if (DataLinks == null)
		{
			DataLinks = "";
		}
		if (!DataLinks.Equals(""))
		{
			try
			{
				if (link_list_download != null)
				{
					link_list_download.Close();
				}
			}
			catch (Exception)
			{
			}
			link_list_download = new link_list();
			link_list_download.textBox_links.Text = DataLinks;
			link_list_download.textBox_what.Text = What;
			link_list_download.textBox_PlayDown.Text = "Download";
			link_list_download.Show();
		}
		else
		{
			MessageBox.Show("لطفا صبر کنید تا بارگذاری کامل شود");
		}
	}

	private void ShowPopBuyAcc(string msg_type)
	{
		string msg2 = "";
		if (msg_type.Equals("play"))
		{
			msg2 = "برای پخش فیلم ها نیاز به تهیه اشتراک می باشد. آیا تمایل به تهیه اشتراک دارید؟";
		}
		else if (msg_type.Equals("download"))
		{
			msg2 = "برای دانلود فیلم ها نیاز به تهیه اشتراک می باشد. آیا تمایل به تهیه اشتراک دارید؟";
		}
		DialogResult dialogResult = MessageBox.Show(msg2, "ورود به حساب کاربری", MessageBoxButtons.YesNo);
		if (dialogResult == DialogResult.Yes)
		{
			buy_acc buy_acc2 = new buy_acc();
			DialogResult aa = buy_acc2.ShowDialog();
			if (aa == DialogResult.OK)
			{
				UpdateAcc();
			}
		}
		else
		{
			_ = 7;
		}
	}

	private void ShowPopLogin(string msg_type)
	{
		string msg2 = "";
		if (msg_type.Equals("play"))
		{
			msg2 = "برای پخش فیلم ها باید وارد حساب کاربری شوید!";
		}
		else if (msg_type.Equals("download"))
		{
			msg2 = "برای دانلود فیلم ها باید وارد حساب کاربری شوید!";
		}
		else if (msg_type.Equals("fav"))
		{
			msg2 = "برای افزودن فیلم ها به لیست علاقه مندی ها باید وارد حساب کاربری شوید!";
		}
		DialogResult dialogResult = MessageBox.Show(msg2, "ورود به حساب کاربری", MessageBoxButtons.YesNo);
		if (dialogResult == DialogResult.Yes)
		{
			login frm_login = new login();
			frm_login.Show();
		}
		else
		{
			_ = 7;
		}
	}

	private void UpdateAcc()
	{
		string url = Global.CurrentURL + ac.wiinapUsers + Global.keyURL + ac.action_equal + "login";
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
			string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Rubiuser.txt";
			using StreamWriter sw = new StreamWriter(FilePath);
			sw.WriteLine("pe34r43widoi56564DSIFdoc324iosiofdsipof324234|" + Global.user_name_config);
			sw.WriteLine("DSF21390Opdsopfdefcd536667spopfdsoifu34osdufoi|" + Global.token_config);
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
			SetDataDetitles();
		}
	}

	private void timer_fav_Tick(object sender, EventArgs e)
	{
		ShowLableLoaing("show");
		timee2++;
		if (timee2 == 2)
		{
			timee2 = 0;
			timer_fav.Enabled = false;
			SetFave();
		}
	}

	private void btn_comments_Click(object sender, EventArgs e)
	{
		if (Data_Comments == null)
		{
			Data_Comments = "";
		}
		if (!Data_Comments.Equals(""))
		{
			frm_comments frm_comments2 = new frm_comments();
			frm_comments2.textBox1.Text = Data_Comments;
			frm_comments2.textBox_video_id.Text = video_id;
			frm_comments2.Show();
		}
	}

	private void btn_add_fav_Click(object sender, EventArgs e)
	{
		if (Global.LoginState.Equals("T"))
		{
			if (!video_id.Equals(""))
			{
				btn_add_fav.Enabled = false;
				timer_fav.Enabled = true;
			}
		}
		else
		{
			ShowPopLogin("fav");
		}
	}

	private void SetFave()
	{
		try
		{
			string action = "";
			action = ((!Fav_State.Equals("T")) ? "new_faves" : "delete_faves");
			string url = Global.CurrentURL + ac.wiinapVll + Global.keyURL + ac.action_equal + action;
			classes myclass = new classes();
			string Args1 = myclass.CreateArgs("id", video_id);
			string Args2 = Args1;
			string Data = myclass.PostData(url, Args2);
			JArray all_array = JArray.Parse(Data);
			string ObjectsArray = all_array[0].ToString();
			JObject mJsonObject = JObject.Parse(ObjectsArray);
			string state = mJsonObject.GetValue("state").ToString();
			string msg = mJsonObject.GetValue("msg").ToString();
			if (state.Equals("T"))
			{
				Fav_State = "T";
				btn_add_fav.Text = "حذف";
				btn_add_fav.Image = Resources.star_full3030;
			}
			else if (state.Equals("Del"))
			{
				Fav_State = "F";
				btn_add_fav.Text = "افزودن";
				btn_add_fav.Image = Resources.star3030;
			}
			ShowLableLoaing("hide");
			MessageBox.Show(msg);
		}
		catch (Exception)
		{
			ShowLableLoaing("hide");
		}
		btn_add_fav.Enabled = true;
	}

	private void btn_trailer_Click(object sender, EventArgs e)
	{
		if (trailer_url == null)
		{
			trailer_url = "";
		}
		if (!trailer_url.Equals(""))
		{
			select_player select_player2 = new select_player();
			select_player2.text_play_link.Text = trailer_url;
			select_player2.label_title.Text = "پخش تیزر";
			select_player2.Show();
		}
	}

	private void btn_download_sub_Click(object sender, EventArgs e)
	{
		if (State_Download == null)
		{
			State_Download = "";
		}
		bool Checking = true;
		if (State_Download.Equals("T"))
		{
			Checking = true;
		}
		else if (State_Download.Equals("F"))
		{
			Checking = false;
		}
		if (Checking)
		{
			if (Global.LoginState.Equals("T"))
			{
				if (Global.StateAcc_Config.Equals("T"))
				{
					Checking = false;
				}
				else
				{
					ShowPopBuyAcc("download");
				}
			}
			else
			{
				ShowPopLogin("download");
			}
		}
		if (Checking)
		{
			return;
		}
		if (Subtitles == null)
		{
			Subtitles = "";
		}
		if (!Subtitles.Equals(""))
		{
			try
			{
				if (link_list_download != null)
				{
					link_list_download.Close();
				}
			}
			catch (Exception)
			{
			}
			link_list_download = new link_list();
			link_list_download.textBox_links.Text = Subtitles;
			link_list_download.textBox_what.Text = "1";
			link_list_download.textBox_PlayDown.Text = "Download";
			link_list_download.Show();
		}
		else
		{
			MessageBox.Show("لطفا صبر کنید تا بارگذاری کامل شود");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.detiles));
		this.panel_main = new System.Windows.Forms.Panel();
		this.panel1 = new System.Windows.Forms.Panel();
		this.label_des = new System.Windows.Forms.Label();
		this.panel3 = new System.Windows.Forms.Panel();
		this.btn_download_sub = new System.Windows.Forms.Button();
		this.btn_comments = new System.Windows.Forms.Button();
		this.btn_download = new System.Windows.Forms.Button();
		this.btn_play = new System.Windows.Forms.Button();
		this.btn_add_fav = new System.Windows.Forms.Button();
		this.panel2 = new System.Windows.Forms.Panel();
		this.btn_trailer = new System.Windows.Forms.Button();
		this.label_year = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label_country = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label_genre = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label_imdb = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label_title = new System.Windows.Forms.Label();
		this.pictureBox_poster = new System.Windows.Forms.PictureBox();
		this.txt_video_id = new System.Windows.Forms.TextBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.timer_fav = new System.Windows.Forms.Timer(this.components);
		this.btn_back = new System.Windows.Forms.Button();
		this.panel_main.SuspendLayout();
		this.panel1.SuspendLayout();
		this.panel3.SuspendLayout();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox_poster).BeginInit();
		base.SuspendLayout();
		this.panel_main.BackColor = System.Drawing.Color.DarkSlateGray;
		this.panel_main.Controls.Add(this.panel1);
		this.panel_main.Controls.Add(this.panel3);
		this.panel_main.Controls.Add(this.panel2);
		this.panel_main.Location = new System.Drawing.Point(38, 58);
		this.panel_main.Name = "panel_main";
		this.panel_main.Size = new System.Drawing.Size(895, 575);
		this.panel_main.TabIndex = 0;
		this.panel1.AutoScroll = true;
		this.panel1.Controls.Add(this.label_des);
		this.panel1.Location = new System.Drawing.Point(21, 363);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(857, 191);
		this.panel1.TabIndex = 4;
		this.label_des.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label_des.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_des.ForeColor = System.Drawing.Color.White;
		this.label_des.Location = new System.Drawing.Point(3, 0);
		this.label_des.Name = "label_des";
		this.label_des.Size = new System.Drawing.Size(835, 469);
		this.label_des.TabIndex = 3;
		this.label_des.Text = "توضحیات فیلم یا سریال";
		this.label_des.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.panel3.BackColor = System.Drawing.Color.Teal;
		this.panel3.Controls.Add(this.btn_download_sub);
		this.panel3.Controls.Add(this.btn_comments);
		this.panel3.Controls.Add(this.btn_download);
		this.panel3.Controls.Add(this.btn_play);
		this.panel3.Controls.Add(this.btn_add_fav);
		this.panel3.Location = new System.Drawing.Point(18, 267);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(860, 80);
		this.panel3.TabIndex = 1;
		this.btn_download_sub.BackColor = System.Drawing.Color.FromArgb(10, 89, 250);
		this.btn_download_sub.Enabled = false;
		this.btn_download_sub.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_download_sub.ForeColor = System.Drawing.Color.White;
		this.btn_download_sub.Image = Filmju.Properties.Resources.download28;
		this.btn_download_sub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_download_sub.Location = new System.Drawing.Point(195, 12);
		this.btn_download_sub.Name = "btn_download_sub";
		this.btn_download_sub.Size = new System.Drawing.Size(157, 53);
		this.btn_download_sub.TabIndex = 4;
		this.btn_download_sub.Text = "دانلود زیرنویس";
		this.btn_download_sub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_download_sub.UseVisualStyleBackColor = false;
		this.btn_download_sub.Click += new System.EventHandler(this.btn_download_sub_Click);
		this.btn_comments.BackColor = System.Drawing.Color.FromArgb(10, 89, 250);
		this.btn_comments.Enabled = false;
		this.btn_comments.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_comments.ForeColor = System.Drawing.Color.White;
		this.btn_comments.Image = Filmju.Properties.Resources.comment30;
		this.btn_comments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_comments.Location = new System.Drawing.Point(32, 12);
		this.btn_comments.Name = "btn_comments";
		this.btn_comments.Size = new System.Drawing.Size(157, 53);
		this.btn_comments.TabIndex = 3;
		this.btn_comments.Text = "نظرات";
		this.btn_comments.UseVisualStyleBackColor = false;
		this.btn_comments.Click += new System.EventHandler(this.btn_comments_Click);
		this.btn_download.BackColor = System.Drawing.Color.FromArgb(10, 89, 250);
		this.btn_download.Enabled = false;
		this.btn_download.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_download.ForeColor = System.Drawing.Color.White;
		this.btn_download.Image = Filmju.Properties.Resources.download28;
		this.btn_download.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_download.Location = new System.Drawing.Point(358, 12);
		this.btn_download.Name = "btn_download";
		this.btn_download.Size = new System.Drawing.Size(157, 53);
		this.btn_download.TabIndex = 2;
		this.btn_download.Text = "دانلود";
		this.btn_download.UseVisualStyleBackColor = false;
		this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
		this.btn_play.BackColor = System.Drawing.Color.FromArgb(10, 89, 250);
		this.btn_play.Enabled = false;
		this.btn_play.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_play.ForeColor = System.Drawing.Color.White;
		this.btn_play.Image = Filmju.Properties.Resources.play31;
		this.btn_play.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_play.Location = new System.Drawing.Point(521, 12);
		this.btn_play.Name = "btn_play";
		this.btn_play.Size = new System.Drawing.Size(157, 53);
		this.btn_play.TabIndex = 1;
		this.btn_play.Text = "پخش آنلاین";
		this.btn_play.UseVisualStyleBackColor = false;
		this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
		this.btn_add_fav.BackColor = System.Drawing.Color.FromArgb(10, 89, 250);
		this.btn_add_fav.Enabled = false;
		this.btn_add_fav.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_add_fav.ForeColor = System.Drawing.Color.White;
		this.btn_add_fav.Image = Filmju.Properties.Resources.star3030;
		this.btn_add_fav.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_add_fav.Location = new System.Drawing.Point(684, 12);
		this.btn_add_fav.Name = "btn_add_fav";
		this.btn_add_fav.Size = new System.Drawing.Size(157, 53);
		this.btn_add_fav.TabIndex = 0;
		this.btn_add_fav.Text = "افزودن";
		this.btn_add_fav.UseVisualStyleBackColor = false;
		this.btn_add_fav.Click += new System.EventHandler(this.btn_add_fav_Click);
		this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
		this.panel2.Controls.Add(this.btn_trailer);
		this.panel2.Controls.Add(this.label_year);
		this.panel2.Controls.Add(this.label9);
		this.panel2.Controls.Add(this.label_country);
		this.panel2.Controls.Add(this.label6);
		this.panel2.Controls.Add(this.label_genre);
		this.panel2.Controls.Add(this.label4);
		this.panel2.Controls.Add(this.label_imdb);
		this.panel2.Controls.Add(this.label2);
		this.panel2.Controls.Add(this.label_title);
		this.panel2.Controls.Add(this.pictureBox_poster);
		this.panel2.Location = new System.Drawing.Point(18, 12);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(860, 240);
		this.panel2.TabIndex = 0;
		this.btn_trailer.BackColor = System.Drawing.Color.FromArgb(10, 89, 250);
		this.btn_trailer.Enabled = false;
		this.btn_trailer.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_trailer.ForeColor = System.Drawing.Color.White;
		this.btn_trailer.Image = Filmju.Properties.Resources.play31;
		this.btn_trailer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_trailer.Location = new System.Drawing.Point(184, 180);
		this.btn_trailer.Name = "btn_trailer";
		this.btn_trailer.Size = new System.Drawing.Size(157, 53);
		this.btn_trailer.TabIndex = 10;
		this.btn_trailer.Text = "تیزر (تریلر)";
		this.btn_trailer.UseVisualStyleBackColor = false;
		this.btn_trailer.Click += new System.EventHandler(this.btn_trailer_Click);
		this.label_year.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_year.ForeColor = System.Drawing.Color.Yellow;
		this.label_year.Location = new System.Drawing.Point(632, 204);
		this.label_year.Name = "label_year";
		this.label_year.Size = new System.Drawing.Size(163, 19);
		this.label_year.TabIndex = 9;
		this.label_year.Text = "در حال بارگذاری";
		this.label_year.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.ForeColor = System.Drawing.Color.Yellow;
		this.label9.Location = new System.Drawing.Point(794, 204);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(62, 19);
		this.label9.TabIndex = 8;
		this.label9.Text = ": انتشار";
		this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label_country.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_country.ForeColor = System.Drawing.Color.Yellow;
		this.label_country.Location = new System.Drawing.Point(184, 175);
		this.label_country.Name = "label_country";
		this.label_country.Size = new System.Drawing.Size(611, 19);
		this.label_country.TabIndex = 7;
		this.label_country.Text = "در حال بارگذاری\r\n";
		this.label_country.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.ForeColor = System.Drawing.Color.Yellow;
		this.label6.Location = new System.Drawing.Point(799, 175);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(58, 19);
		this.label6.TabIndex = 6;
		this.label6.Text = ": کشور";
		this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label_genre.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_genre.ForeColor = System.Drawing.Color.Yellow;
		this.label_genre.Location = new System.Drawing.Point(180, 140);
		this.label_genre.Name = "label_genre";
		this.label_genre.Size = new System.Drawing.Size(615, 19);
		this.label_genre.TabIndex = 5;
		this.label_genre.Text = "در حال بارگذاری";
		this.label_genre.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Yellow;
		this.label4.Location = new System.Drawing.Point(816, 140);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(41, 19);
		this.label4.TabIndex = 4;
		this.label4.Text = ": ژانر";
		this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label_imdb.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_imdb.ForeColor = System.Drawing.Color.Yellow;
		this.label_imdb.Location = new System.Drawing.Point(739, 112);
		this.label_imdb.Name = "label_imdb";
		this.label_imdb.Size = new System.Drawing.Size(56, 19);
		this.label_imdb.TabIndex = 3;
		this.label_imdb.Text = "0.0";
		this.label_imdb.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.Yellow;
		this.label2.Location = new System.Drawing.Point(801, 112);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 19);
		this.label2.TabIndex = 2;
		this.label2.Text = ": imdb";
		this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.label_title.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label_title.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label_title.ForeColor = System.Drawing.Color.White;
		this.label_title.Location = new System.Drawing.Point(185, 3);
		this.label_title.Name = "label_title";
		this.label_title.Size = new System.Drawing.Size(672, 95);
		this.label_title.TabIndex = 1;
		this.label_title.Text = "در حال بارگذاری";
		this.label_title.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.pictureBox_poster.Image = Filmju.Properties.Resources.placeholder;
		this.pictureBox_poster.Location = new System.Drawing.Point(3, 3);
		this.pictureBox_poster.Name = "pictureBox_poster";
		this.pictureBox_poster.Size = new System.Drawing.Size(176, 230);
		this.pictureBox_poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox_poster.TabIndex = 0;
		this.pictureBox_poster.TabStop = false;
		this.txt_video_id.Location = new System.Drawing.Point(668, 4);
		this.txt_video_id.Name = "txt_video_id";
		this.txt_video_id.Size = new System.Drawing.Size(88, 20);
		this.txt_video_id.TabIndex = 1;
		this.txt_video_id.Visible = false;
		this.textBox1.Location = new System.Drawing.Point(346, 4);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(316, 48);
		this.textBox1.TabIndex = 3;
		this.textBox1.Visible = false;
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
		this.timer_fav.Interval = 1000;
		this.timer_fav.Tick += new System.EventHandler(this.timer_fav_Tick);
		this.btn_back.BackColor = System.Drawing.Color.Red;
		this.btn_back.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btn_back.ForeColor = System.Drawing.Color.Yellow;
		this.btn_back.Image = Filmju.Properties.Resources.back_icon;
		this.btn_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_back.Location = new System.Drawing.Point(38, 12);
		this.btn_back.Name = "btn_back";
		this.btn_back.Size = new System.Drawing.Size(172, 40);
		this.btn_back.TabIndex = 2;
		this.btn_back.Text = "برگشت";
		this.btn_back.UseVisualStyleBackColor = false;
		this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		base.ClientSize = new System.Drawing.Size(999, 624);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.btn_back);
		base.Controls.Add(this.txt_video_id);
		base.Controls.Add(this.panel_main);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "detiles";
		this.Text = "detiles";
		base.Load += new System.EventHandler(this.detiles_Load);
		this.panel_main.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.panel3.ResumeLayout(false);
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox_poster).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
