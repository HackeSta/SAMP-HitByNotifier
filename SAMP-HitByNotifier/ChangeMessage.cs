using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAMP_HitByNotifier
{
    public partial class ChangeMessage : Form
    {
        public ChangeMessage()
        {
            InitializeComponent();
            dd_weaponid.DataSource = DatabaseManager.WeaponNames;
        }

        private void dd_weaponid_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Message.Text = DatabaseManager.GetMessage(DatabaseManager.NameToID(dd_weaponid.GetItemText(dd_weaponid.SelectedItem)));
        }

        private void button_messageSet_Click(object sender, EventArgs e)
        {
            DatabaseManager.UpdateMessage(DatabaseManager.NameToID(dd_weaponid.GetItemText(dd_weaponid.SelectedItem)), tb_Message.Text);
        }
    }
}
