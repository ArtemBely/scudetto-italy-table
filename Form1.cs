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
        public Player? selectedPlayer = null;
        public Player? searchingPlayer = null;
        private int fontSize = 10;
        private ListBox playerListBox, clubsListBox;
        private Button button, button2, button3, button4,
        button5, button6, button7, cancelButton, okButton, okBestButton;
        private Label label1, label2, label3, label4, label5, label6;
        private ComboBox cb;
        private TextBox tb1, tb3, tb4, tb5, tb6, finder;
        private Form form2, form3;
        private ListViewItem item, itemLv;
        private ListView playerListView;
        public League standings;
        public Team[] seriaBTeams = { Team.Parma, Team.SPAL, Team.Benevento, Team.Como, Team.Ascoli,
                Team.Palermo, Team.Brescia, Team.Ternana, Team.Perugia, Team.Genoa };
        public Team[] seriaATeams = { Team.Roma, Team.Bologna, Team.Inter, Team.Cremoneze, Team.Juventus,
                Team.Lecce, Team.Milan, Team.Napoli, Team.Verona, Team.Empoli };
        public Form1()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            standings = new League(1, "Seria A", seriaATeams);

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
            playerListView.SelectedIndexChanged += listView1_Click;

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
            button2.Click += button1_Click; 
            Controls.Add(button2);

            button3 = new Button();
            button3.Text = "Delete player";
            button3.Location = new Point(935, 140);
            button3.Height = 40;  
            button3.Width = 200;
            button3.BackColor = Color.FromArgb(0, 81, 255);
            button3.ForeColor = Color.FromArgb(255, 255, 255);
            button3.Font = new Font("Arial", fontSize);
            button3.Click += deleteItem;
            Controls.Add(button3);

            button4 = new Button();
            button4.Text = "Find player";
            button4.Location = new Point(935, 200);
            button4.Height = 40;
            button4.Width = 200;
            button4.BackColor = Color.FromArgb(0, 81, 255);
            button4.ForeColor = Color.FromArgb(255, 255, 255);
            button4.Font = new Font("Arial", fontSize);
            button4.Click += findButtonClicked;
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

            button6 = new Button();
            button6.Text = "Show clubs statistic";
            button6.Location = new Point(935, 320);
            button6.Height = 40;
            button6.Width = 200;
            button6.BackColor = Color.FromArgb(0, 81, 255);
            button6.ForeColor = Color.FromArgb(255, 255, 255);
            button6.Font = new Font("Arial", fontSize);
            //button6.Click += switchLeague;
            Controls.Add(button6);

            button7 = new Button();
            button7.Text = "Save statistics";
            button7.Location = new Point(935, 380);
            button7.Height = 40;
            button7.Width = 200;
            button7.BackColor = Color.FromArgb(0, 81, 255);
            button7.ForeColor = Color.FromArgb(255, 255, 255);
            button7.Font = new Font("Arial", fontSize);
            //button6.Click += switchLeague;
            Controls.Add(button7);

            this.BackgroundImage = Image.FromFile
            (System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal)
            + @"../../Downloads/italy.jpg");
        }

        private void switchLeague(object sender, EventArgs e)
        {
            if(button5.Text.Equals("Switch to Serie B")) {
                button5.Text = "Switch to Serie A";
                standings = new League(2, "Seria B", seriaBTeams);
            }
            else {
                button5.Text = "Switch to Serie B";
                //standings = new League(2, "Seria B", seriaBTeams);
                standings = new League(1, "Seria A", seriaATeams);
            }
        }

        private void findButtonClicked(object sender, EventArgs e)
        {
            form3 = new Form();
            cancelButton = new Button();
            okButton = new Button();

            label1 = new Label();
            label1.Text = "Search player by name";
            finder = new TextBox();
            cancelButton.Text = "Cancel";
            cancelButton.Height = 40;
            cancelButton.Width = 120;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(12, 130);
            cancelButton.Click += new EventHandler(cancelButtonFind_Click);
            form3.Controls.Add(cancelButton);

            okButton.Text = "OK";
            okButton.Height = 40;
            okButton.Width = 120;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(238, 130);

            okButton.Click += new EventHandler(findPlayer);

            form3.Controls.Add(okButton);
            label1.Location = new Point(12, 30);
            form3.Controls.Add(label1);

            finder.Location = new Point(120, 30);
            finder.Height = 20;
            finder.Width = 200;
            form3.Controls.Add(finder);

            form3.Text = "Find player";
            form3.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form3.ClientSize = new System.Drawing.Size(370, 200);
            form3.FormBorderStyle = FormBorderStyle.FixedSingle;
            form3.Show();
        }

         private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form();
            cancelButton = new Button();
            okButton = new Button();

            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label1.Text = "Team";
            label2.Text = "Name";
            label3.Text = "Lastname";
            label4.Text = "Goals";
            label5.Text = "Assists";
            cb = new ComboBox();
            tb1 = new TextBox();
            tb3 = new TextBox();
            tb4 = new TextBox();
            tb5 = new TextBox();
            tb6 = new TextBox();

            if(standings.Name.Equals("Seria A")) {
                cb.Items.Add(Team.Roma);
                cb.Items.Add(Team.Bologna);
                cb.Items.Add(Team.Inter);
                cb.Items.Add(Team.Cremoneze);
                cb.Items.Add(Team.Juventus);
                cb.Items.Add(Team.Lecce);
                cb.Items.Add(Team.Milan);
                cb.Items.Add(Team.Napoli);
                cb.Items.Add(Team.Verona);
                cb.Items.Add(Team.Empoli);
            } else {   
                cb.Items.Add(Team.Parma);
                cb.Items.Add(Team.SPAL);
                cb.Items.Add(Team.Benevento);
                cb.Items.Add(Team.Como);
                cb.Items.Add(Team.Ascoli);
                cb.Items.Add(Team.Palermo);
                cb.Items.Add(Team.Brescia);
                cb.Items.Add(Team.Ternana);
                cb.Items.Add(Team.Perugia);
                cb.Items.Add(Team.Genoa);
            }

            cancelButton.Text = "Cancel";
            cancelButton.Height = 40;
            cancelButton.Width = 120;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(12, 430);
            cancelButton.Click += new EventHandler(cancelButton_Click);
            form2.Controls.Add(cancelButton);

            okButton.Text = "OK";
            okButton.Height = 40;
            okButton.Width = 120;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(238, 430);

            if(selectedPlayer == null)
            {
                okButton.Click += new EventHandler(addPlayer);
            }
            else okButton.Click += new EventHandler(editPlayer);

            form2.Controls.Add(okButton);
            label1.Location = new Point(12, 30);
            label2.Location = new Point(12, 90);
            label3.Location = new Point(12, 150);
            label4.Location = new Point(12, 210);
            label5.Location = new Point(12, 270);
            form2.Controls.Add(label1);
            form2.Controls.Add(label2);
            form2.Controls.Add(label3);
            form2.Controls.Add(label4);
            form2.Controls.Add(label5);
            form2.Controls.Add(label6);

            cb.Location = new Point(120, 30);
            cb.Height = 20;
            cb.Width = 200;
            tb1.Location = new Point(120, 90);
            tb1.Height = 20;
            tb1.Width = 200;
            tb3.Location = new Point(120, 150);
            tb3.Height = 20;
            tb3.Width = 200;
            tb4.Location = new Point(120, 210);
            tb4.Height = 20;
            tb4.Width = 200;
            tb5.Location = new Point(120, 270);
            tb5.Height = 20;
            tb5.Width = 200;
            if(selectedPlayer != null) { 
                cb.Text = selectedPlayer.Club.ToString();
                tb1.Text = selectedPlayer.Name;
                tb3.Text = selectedPlayer.LastName;
                tb4.Text = selectedPlayer.GoalCount.ToString();
                tb5.Text = selectedPlayer.Assist.ToString();
                tb6.Text = selectedPlayer.Scores.ToString();
             }
            form2.Controls.Add(tb1);
            form2.Controls.Add(cb);
            form2.Controls.Add(tb3);
            form2.Controls.Add(tb4);
            form2.Controls.Add(tb5);

            form2.Text = "Add / edit player";
            form2.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form2.ClientSize = new System.Drawing.Size(370, 500);
            form2.FormBorderStyle = FormBorderStyle.FixedSingle;
            form2.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            selectedPlayer = null;
            this.DialogResult = DialogResult.Cancel;
            form2.Close();
        }
        private void cancelButtonFind_Click(object sender, EventArgs e)
        {
            selectedPlayer = null;
            this.DialogResult = DialogResult.Cancel;
            form3.Close();
        }
        private bool checkDataType()
        {
            var isName = int.TryParse(tb1.Text, out int j);
            var isLastName = int.TryParse(tb3.Text, out int i);
            var isNumericGoal = int.TryParse(tb4.Text, out int n);
            var isNumericAssists = int.TryParse(tb5.Text, out int p);
            var enumType = Enum.IsDefined(typeof(Team), cb.Text);
            if (!isNumericAssists | !isNumericGoal | isName | !enumType | tb1.Text.Length == 0)
            {
                MessageBox.Show("Please use correct format of data");
                return false;
            }
            return true;
        }
        private void addPlayer(object sender, EventArgs e)
        {
            if (!checkDataType()) return;
            player = new Player(tb1.Text, tb3.Text, (Team)Enum.Parse(typeof(Team), cb.Text), int.Parse(tb4.Text), int.Parse(tb5.Text), (int.Parse(tb4.Text) + int.Parse(tb5.Text)));
            players.Add(player);
            Console.WriteLine(players[0]);
            string[] row = { player.Club.ToString(), player.Name, player.LastName, player.GoalCount.ToString(), player.Assist.ToString(), player.Scores.ToString() };
            item = new ListViewItem(row);
            playerListView.Items.Add(item);
            item.Tag = player;
            string listViewAction = DateTime.Now + " | Player "  + player?.Name + " was added.";
            playerListBox.Items.Add(listViewAction);
            playerListView.Items[0].Selected = true;
        }
        private void deleteItem(object sender, EventArgs e)
        {
            if (selectedPlayer == null)
            {
                return;
            }
            foreach (ListViewItem Item in playerListView.SelectedItems)
            {
                players.RemoveAt(Item.Index);
                playerListView.Items.Remove(Item);
            }
            string listViewAction = DateTime.Now + " | Player was deleted: " + player?.Name;
            playerListBox.Items.Add(listViewAction);
            selectedPlayer = null;
        }
        private void findPlayer(object sender, EventArgs e)
        {
            if (finder.Text.Length == 0)
            {
                MessageBox.Show("Please use correct format of data");
                return;
            }
            foreach (Player player in players) {
                if(player != null && player.Name.Equals(finder.Text)) {
                    searchingPlayer = player;
                    MessageBox.Show("Player " + searchingPlayer.Name.ToString() + " from " +
                    searchingPlayer.Club.ToString() + " with " + searchingPlayer.Scores.ToString() + " scores was found.");
                    string listViewAction = DateTime.Now + " | Player was found: " + searchingPlayer?.Name;
                    playerListBox.Items.Add(listViewAction);
                    selectedPlayer = null;
                    return;
                }
            }
            MessageBox.Show("Player doesn't exist");
            return;
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            if (playerListView.SelectedItems.Count == 0)
            {
                return;
            }
            var firstSelectedItem = playerListView.SelectedItems[0];
            selectedPlayer = (Player)firstSelectedItem.Tag;
            Console.WriteLine($"Selected player: {selectedPlayer.Name}, Club: {selectedPlayer.Club.ToString()}, Goals: {selectedPlayer.GoalCount.ToString()}");
        }
        private void editPlayer(object sender, EventArgs e)
        {
            if (!checkDataType()) return;
            player = new Player(tb1.Text, tb3.Text, (Team)Enum.Parse(typeof(Team), cb.Text), int.Parse(tb4.Text), int.Parse(tb5.Text), (int.Parse(tb4.Text) + int.Parse(tb5.Text)));
            var lvi = playerListView.SelectedItems[0];
            lvi.SubItems[0].Text = cb.Text;
            lvi.SubItems[1].Text = tb1.Text;
            lvi.SubItems[2].Text = tb3.Text;
            lvi.SubItems[3].Text = tb4.Text;
            lvi.SubItems[4].Text = tb5.Text;
            lvi.SubItems[5].Text = (int.Parse(tb4.Text) + int.Parse(tb5.Text)).ToString();

            if(selectedPlayer != null && playerListView.FocusedItem != null) {
                        var index = playerListView.FocusedItem.Index;
                        players[index].Club = (Team)Enum.Parse(typeof(Team), cb.Text);
                        players[index].Name = tb1.Text;
                        players[index].LastName = tb3.Text;
                        players[index].GoalCount = int.Parse(tb4.Text);
                        players[index].Assist = int.Parse(tb5.Text);
                        players[index].Scores = int.Parse(tb4.Text) + int.Parse(tb5.Text);
            }

            string listViewAction = DateTime.Now + " | Player was edited: " + player?.Name;
            playerListBox.Items.Add(listViewAction);
            selectedPlayer = null;
        }
    }
}