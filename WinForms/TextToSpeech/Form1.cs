using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             PromptBuilder pb = new PromptBuilder();
            //Sam
            pb.StartVoice("Microsoft Anna");
            pb.AppendText("I am Sam. Sam I am.");

            //Mike
            pb.StartVoice(VoiceGender.Male, VoiceAge.Adult);
            pb.AppendText("I'm Mike. Anything Sam can do I can do better.");
            
            //Mary
            pb.StartVoice("Microsoft Mary");
            pb.AppendText("I'm Mary. Anything Mike and Sam can do I can do too.");

            //pause for 1 second
            pb.AppendBreak(new System.TimeSpan(0, 0, 1));

            pb.EndVoice();

            //back to Mike
            pb.AppendText("But can you spell potato?");
            pb.AppendTextWithHint("potato",SayAs.SpellOut);
            pb.AppendText("What do you think, Sam?");
            
            pb.EndVoice();

            //back to Sam
            pb.AppendText("That's the stuff dreams are made of.");
            
            pb.EndVoice();

            //say it all
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SpeakAsync(pb);

        }
    }
}
