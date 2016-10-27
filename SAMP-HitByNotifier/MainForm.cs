using System;
using System.Drawing;
using System.Windows.Forms;
using shadowAPI2;

namespace SAMP_HitByNotifier
{
    public partial class MainForm : Form
    {
        #region Initialisations
        Timer HitTimer = new Timer();
        int newHealth, oldHealth = -1, oldID = -1, newID, Ticks, oldTicks = -1;
        private static int SpamInterval = 1;
        Color messageColor = Color.Blue;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            HitTimer.Interval = 1;
            HitTimer.Tick += HitTimer_Tick;
            DatabaseManager.Initalise();
            SetColor(messageColor);
            Spam = SpamInterval;
            tb_Spam.Text = Spam.ToString();

        }

        private void HitTimer_Tick(object sender, EventArgs e)  //Checks for changes to health
        {
            newHealth = Player.GetHealth();
            if (oldHealth == -1) oldHealth = newHealth;
            else if (newHealth < oldHealth && AntiSpam())  //If health is changed
            {
                oldHealth = newHealth;
                newHit(Game.getWeaponID()); // newHit() sends the message to the game
            }
            else if (newHealth >= oldHealth)
            {
                oldHealth = newHealth;
            }
            Ticks += 1;
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cDialog = new ColorDialog();
            DialogResult dResult = cDialog.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                SetColor(cDialog.Color);
            }
        }

        private void SetColor(Color c)  //Sets Message Color
        {
            button_Color.BackColor = c;
            messageColor = c;
            tb_Color.Text = c.ToHex();
        }

        private void tb_Spam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_Spam_TextChanged(object sender, EventArgs e)
        {
            Spam = Convert.ToInt32(tb_Spam.Text);
        }

        private bool AntiSpam()
        {
            newID = Game.getWeaponID();
            if (oldID == -1) oldID = newID;
            if (oldTicks == -1) oldTicks = Ticks;
            if(oldID != newID || (Ticks - oldTicks) > SpamInterval)
            {
                return true;
            }
            return false;
        }
        private void btn_Link_Click(object sender, EventArgs e)  //Attaches the process to the game
        {
            if (Game.Init())
            {
                rtb_Display.AppendText("Linked to GTA SAN ANDREAS MULTIPLAYER");
                shadowAPI2.Chat.AddMessage("SAMP-HitByNotifier was linked", messageColor);
                HitTimer.Start();
            }
            else
            {
                rtb_Display.AppendText(Environment.NewLine + "Failed to find the game process");
            }
        }

        private void newHit(int ID)  //Called whenever health is decreased
        {
            shadowAPI2.Chat.AddMessage(DatabaseManager.GetMessage(ID), messageColor);
            rtb_Display.AppendText(Environment.NewLine + "Recorded new Hit: " + ID.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)  //The Hex Color Box Text Change Event, used for ensuring Hex Input
        {
            string item = tb_Color.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
              item != String.Empty)
            {
                tb_Color.Text = item.Remove(item.Length - 1, 1);
                tb_Color.SelectionStart = tb_Color.Text.Length;
            }
            if(tb_Color.Text.Length == 6) SetColor(tb_Color.Text.ToColor());  //If complete hex code is input, sets it as the message color
        }

        public static int Spam
        {
            get
            {
                return SpamInterval; 
            }
            set
            {
                SpamInterval = value;
                
            }
        }
    }

    #region Extensions
    public static class Extensions
    {
        public static string ToHex(this Color c)  //Converts Color to Hex String
        {
            return c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static Color ToColor(this string s)  //Converts Hex String to Color
        {
            if (s.Length == 6)
            {
                int[] rgb = new int[3]
                {
                    Int32.Parse(s.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    Int32.Parse(s.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    Int32.Parse(s.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)};
                Color clr = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                return clr;
            }
            else return Color.Empty;
        }
    }
    #endregion
}


