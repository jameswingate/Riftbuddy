using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Riftbuddy
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            Rectangle workArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workArea.Right - (Size.Width + 30),
                                      workArea.Bottom - (Size.Height + 30));

            this.Deactivate += Config_LostFocus;

            comboBoxServer.Items.AddRange(new string[] { "RU", "KR", "BR1", "OC1", "JP1", "NA1", "EUN1", "EUW1", "TR1", "LA1", "LA2" });
        }

        private void Config_LostFocus(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxSummonerName.Text.Length != 0)
            {
                if (comboBoxServer.SelectedIndex > -1)
                {
                    APIHandler.Username = textBoxSummonerName.Text;
                    APIHandler.Server = comboBoxServer.SelectedItem.ToString();

                    APIHandler.GetSummoner();
                }
                else
                {
                    SynthesisHandler.Synthesise("You must select your server.");
                }
            }
            else
            {
                SynthesisHandler.Synthesise("You must enter your summoner name.");
            }
        }
    }
}
