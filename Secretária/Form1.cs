using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Speech.Recognition; // Adicionar nameSpeech

namespace Secretária
{
    public partial class Form1 : Form
    {
        //Foms
        private SelecVoz selectVoice = null;
        private SpeechRecognitionEngine engine;  //engine de reconhecimento

        private bool isJarvisListening = true;

        public Form1()
        {
            InitializeComponent();
        }
        private void LoadSpeech()
        {
            try
            {
                engine = new SpeechRecognitionEngine(); //Instancia
                engine.SetInputToDefaultAudioDevice();  //microfone

                Choices cNumbers = new Choices();

                for (int i = 0; i <= 100; i++)
                    cNumbers.Add(i.ToString());

                Choices c_commandosOfSystem = new Choices();
                c_commandosOfSystem.Add(GrammarRules.WhatTimeIs.ToArray()); // Adicioando WhatsTimeIs da classe GrammarRules
                c_commandosOfSystem.Add(GrammarRules.whatDateIs.ToArray());  // WhatDateIs      da classe GrammarRules        
                c_commandosOfSystem.Add(GrammarRules.JarvisStartListening.ToArray());
                c_commandosOfSystem.Add(GrammarRules.JarvisStopListening.ToArray());
                c_commandosOfSystem.Add(GrammarRules.MinimizeWindow.ToArray()); // minimizar janela
                c_commandosOfSystem.Add(GrammarRules.normalWindow.ToArray());  //Máximizar janela
                c_commandosOfSystem.Add(GrammarRules.conversaWindows.ToArray()); //Conversa
                c_commandosOfSystem.Add(GrammarRules.conversa2Windows.ToArray()); //apresentação
                c_commandosOfSystem.Add(GrammarRules.conversa3Windows.ToArray());
                c_commandosOfSystem.Add(GrammarRules.conversa4Windows.ToArray());
                c_commandosOfSystem.Add(GrammarRules.ChanceVoice.ToArray()); //Mudar voz do sistema
                //Comando "pare de ouvir"  == Jarvis




                GrammarBuilder gb_comandsOfSystem = new GrammarBuilder();
                gb_comandsOfSystem.Append(c_commandosOfSystem);

                Grammar g_commandsOfSystem = new Grammar(gb_comandsOfSystem);
                g_commandsOfSystem.Name = "sys";  //Ajuda identificar em qual grámatica foi chamado o comando

                GrammarBuilder gbNumber = new GrammarBuilder();
                gbNumber.Append(cNumbers); // 5 vezes
                gbNumber.Append(new Choices("vezes", "mais", "menos", "por"));
                gbNumber.Append(cNumbers);

                Grammar gNumbers = new Grammar(gbNumber);
                gNumbers.Name = "calc";


                engine.LoadGrammar(g_commandsOfSystem); //carregar a gramática
                //carregar a gramática

               // engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);

                //nivel do aúdio

                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);

                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej); 

                engine.RecognizeAsync(RecognizeMode.Multiple); //Iniciar o reconhecimento

                Speaker.Speak ( "Estou carregando os arquivos ");
            }

            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro", ex.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            Speaker.Speak("Já carreguei os arquivos");
        }


        //Metodo que é chamado qunado al é reconhecido
        private void rec (object s, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text; // String reconhecida
            float conf = e.Result.Confidence;




            string date = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            string log_filename = "log//" + date  + ".txt";
            StreamWriter sw = File.AppendText(log_filename);
            if (File.Exists(log_filename))
            {
                sw.WriteLine(speech);
            }
            else
            {
                sw.WriteLine(speech);
            }
            sw.Close();






            if(conf > 0.80f)
            {
                this.label1.ForeColor = Color.Black;

                if(GrammarRules.JarvisStopListening.Any(x => x == speech))
                {
                  
                    isJarvisListening = false;
                    Runner.JarvisStopListening();
                        
                }
                else if(GrammarRules.JarvisStartListening.Any(x => x == speech))
                {
                  
                    isJarvisListening = true;
                    Runner.JarvisStartListening();
                }
                if(isJarvisListening == true)
                {
                    switch (e.Result.Grammar.Name)
                    {
                        case "sys":
                            //Se o speech == "que horas são , etec"  classe = "GrammarRules"
                            if (GrammarRules.WhatTimeIs.Any(x => x == speech))
                            {
                                Runner.whaTimeIs();
                            }
                            else if (GrammarRules.whatDateIs.Any(XmlReadMode => XmlReadMode == speech))
                            {
                                Runner.whatDateIs();
                            }
                            else if (GrammarRules.MinimizeWindow.Any(x => x == speech))
                            {
                                MinimizerWindow();
                            }
                            else if(GrammarRules.normalWindow.Any(x => x == speech))
                            {
                                normalWindow();
                            }
                            else if(GrammarRules.conversaWindows.Any(x => x == speech))
                            {
                                Runner.conversaWindows();
                            }
                            else if(GrammarRules.conversa2Windows.Any(x => x == speech))
                            {
                                Runner.conversa2Windows();
                            }
                            else if (GrammarRules.conversa3Windows.Any(x => x == speech))
                            {
                                Runner.conversa3Windows();
                            }
                            else if (GrammarRules.conversa4Windows.Any(x => x == speech))
                            {
                                Runner.conversa4Windows();
                            }
                            else if (GrammarRules.ChanceVoice.Any(x => x == speech))
                            {
                                if(selectVoice == null || selectVoice.IsDisposed == true)
                                    selectVoice = new SelecVoz();
                                selectVoice.Show();
                                
                                
                                
                            }
                            break;
                        case "calc":
                            Speaker.Speak(CalcSolver.Solve(speech));
                            break;
                    }
                }
                
            }
           
        }


        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }
        private void rej(object s, SpeechRecognitionRejectedEventArgs e)
        {
            this.label1.ForeColor = Color.Red;
        }


        //Minimizar janela
        private void MinimizerWindow()
        {
            if(this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                Speaker.Speak("Minimizando a janela", "Okay", "Como quiser", "Como quiser, até mais");
            }
            else
            {
                Speaker.Speak("Já está minimizada", "Já estou minimizada", "Já fechei a janela");
            }
        }

        //Máximizar janela
        private void normalWindow()
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                Speaker.Speak("Máximizando a janela", "Abrindo a janela", "Estou de volta");
            }
            else
            {
                Speaker.Speak("Já estou máximizado", "Estou aqui senhor");
            }
        }
    }
}
