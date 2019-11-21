using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace Secretária
{
    public partial class SelecVoz : Form
    {
        private SpeechSynthesizer sp = new SpeechSynthesizer();
        public SelecVoz()
        {
            InitializeComponent();
            foreach(InstalledVoice voice in sp.GetInstalledVoices())
            {
                comboBox1.Items.Add(voice.VoiceInfo.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
        //Form carregado
        private void SelecVoz_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Speaker.SetVoice(comboBox1.SelectedItem.ToString());
            Speaker.SetVoice("A voz foi alterada");
        }
    }
}
