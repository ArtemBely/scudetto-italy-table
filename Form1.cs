using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scudetto_italy
{
    public partial class Form1 : Form
    {
        public Player player;
        public List<Player> players = new List<Player>();
        private int fontSize = 10;
        private ListBox playerListBox, clubsListBox;
        private Button button, button2, button3, button4,
        button5, cancelButton, okButton, okBestButton;
        private Label label1, label2, label3, label4, label5;
        private ComboBox cb;
        private TextBox tb1, tb3, tb4;
        private Form form2, form3;
        private ListViewItem item, itemLv;
        private ListView playerListView;
        public Form1()
        {
             this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            playerListView = new ListView();
            playerListView.View = View.Details;
            playerListView.GridLines = true;
            playerListView.Size = new Size(900, 500);
            playerListView.Columns.Add("Team", 150);
            playerListView.Columns.Add("Name", 150);
            playerListView.Columns.Add("Lastname", 150);
            playerListView.Columns.Add("Goals", 150);
            playerListView.Columns.Add("Assists", 150);
            playerListView.Columns.Add("Scores", 150);
            playerListView.BackColor = Color.FromArgb(245, 248, 248);
            //playerListView.SelectedIndexChanged += listView1_Click;

            Controls.Add(playerListView);

            playerListBox = new ListBox();
            playerListBox.Width = 600;
            playerListBox.Height = 150;
            playerListBox.Name = "gameListBox";
            playerListBox.Dock = DockStyle.Bottom;
            playerListBox.BackColor = Color.FromArgb(245, 248, 248);
            Controls.Add(playerListBox);

            button = new Button();
            button.Text = "Add player";
            button.Location = new Point(935, 20);
            button.Height = 40;  
            button.Width = 200;
            button.BackColor = Color.FromArgb(0, 81, 255);
            button.ForeColor = Color.FromArgb(255, 255, 255);
            button.Font = new Font("Arial", fontSize);

            button.Click += button1_Click; 
            Controls.Add(button);

            button2 = new Button();
            button2.Text = "Edit player";
            button2.Location = new Point(935, 80);
            button2.Height = 40;  
            button2.Width = 200;
            button2.BackColor = Color.FromArgb(0, 81, 255);
            button2.ForeColor = Color.FromArgb(255, 255, 255);
            button2.Font = new Font("Arial", fontSize);
            //button2.Click += button1_Click; 
            Controls.Add(button2);

            button3 = new Button();
            button3.Text = "Delete player";
            button3.Location = new Point(935, 140);
            button3.Height = 40;  
            button3.Width = 200;
            button3.BackColor = Color.FromArgb(0, 81, 255);
            button3.ForeColor = Color.FromArgb(255, 255, 255);
            button3.Font = new Font("Arial", fontSize);
            //button3.Click += deleteItem;
            Controls.Add(button3);

            button4 = new Button();
            button4.Text = "Find player";
            button4.Location = new Point(935, 200);
            button4.Height = 40;
            button4.Width = 200;
            button4.BackColor = Color.FromArgb(0, 81, 255);
            button4.ForeColor = Color.FromArgb(255, 255, 255);
            button4.Font = new Font("Arial", fontSize);
            Controls.Add(button4);

            button5 = new Button();
            button5.Text = "Switch to Serie B";
            button5.Location = new Point(935, 260);
            button5.Height = 40;
            button5.Width = 200;
            button5.BackColor = Color.FromArgb(0, 81, 255);
            button5.ForeColor = Color.FromArgb(255, 255, 255);
            button5.Font = new Font("Arial", fontSize);
            button5.Click += switchLeague;
            Controls.Add(button5);

            this.BackgroundImage = Image.FromFile
            (System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal)
            + @"../../Downloads/italy.jpg");
        }

        private void switchLeague(object sender, EventArgs e)
        {
            if(button5.Text.Equals("Switch to Serie B")) button5.Text = "Switch to Serie A";
            else button5.Text = "Switch to Serie B";
        }

         private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form();
            cancelButton = new Button();
            okButton = new Button();

            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label1.Text = "Name";
            label2.Text = "Lastname";
            label3.Text = "Goals";

            tb1 = new TextBox();
            tb3 = new TextBox();
            cb = new ComboBox();
            // cb.Items.Add(TabSizeMode.);
            // cb.Items.Add(FootballClub.Arsenal);
            // cb.Items.Add(FootballClub.Barcelona);
            // cb.Items.Add(FootballClub.FCPorto);
            // cb.Items.Add(FootballClub.RealMadrid);
            // cb.Items.Add(FootballClub.None);

            cancelButton.Text = "Cancel";
            cancelButton.Height = 40;
            cancelButton.Width = 120;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(12, 230);
            cancelButton.Click += new EventHandler(cancelButton_Click);
            form2.Controls.Add(cancelButton);

            player = new Player(tb1.Text, "lastname", (Team)Enum.Parse(typeof(Team), cb.Text), int.Parse(tb3.Text), int.Parse(tb3.Text), int.Parse(tb3.Text));


            okButton.Text = "OK";
            okButton.Height = 40;
            okButton.Width = 120;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(338, 230);

            // if(selectedPlayer == null)
            // {
            //     okButton.Click += new EventHandler(addPlayer);
            // }
            // else okButton.Click += new EventHandler(editPlayer);

            form2.Controls.Add(okButton);
            label1.Location = new Point(12, 30);
            label2.Location = new Point(12, 90);
            label3.Location = new Point(12, 150);
            form2.Controls.Add(label1);
            form2.Controls.Add(label2);
            form2.Controls.Add(label3);

            tb1.Location = new Point(120, 30);
            tb1.Height = 20;
            tb1.Width = 200;
            cb.Location = new Point(120, 90);
            cb.Height = 20;
            cb.Width = 200;
            tb3.Location = new Point(120, 150);
            tb3.Height = 20;
            tb3.Width = 200;
            // if(selectedPlayer != null) { 
            //     tb3.Text = selectedPlayer.GoalCount.ToString();
            //     tb1.Text = selectedPlayer.Name;
            //     cb.Text = selectedPlayer.Club.ToString();
            //  }
            form2.Controls.Add(tb1);
            form2.Controls.Add(cb);
            form2.Controls.Add(tb3);

            form2.Text = "Add player";
            form2.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form2.ClientSize = new System.Drawing.Size(470, 300);
            form2.FormBorderStyle = FormBorderStyle.FixedSingle;
            form2.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //selectedPlayer = null;
            this.DialogResult = DialogResult.Cancel;
            form2.Close();
        }
        }
}