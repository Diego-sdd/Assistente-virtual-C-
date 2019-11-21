using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretária
{
    public class Runner
    {    //INSERIR O COMANDO    EX: FALA QUE HORAS SÃO
        public static void whaTimeIs()
        {
            Speaker.Speak(DateTime.Now.ToShortTimeString());

        }
        public static void whatDateIs()
        {
            Speaker.Speak(DateTime.Now.ToShortDateString());
        }
        public static void whatLocalization()
        {
            
        }
        public static void JarvisStopListening()
        {
            Speaker.Speak("Até mais tarde, quando precisar é so chamar".ToString());
            
        }
        public static void JarvisStartListening()
        {
            Speaker.Speak("Olá, diego no que eu posso ajudar".ToString());
        }
        public static void conversaWindows()
        {
            Speaker.Speak("Estou bem e você ? Como você está".ToString());
        }
        public static void conversa2Windows()
        {
            Speaker.Speak("Meu nome é JARVIS, sou sua assistente virtual, estou aqui para te ajudar".ToString());
        }
        public static void conversa3Windows()
        {
            Speaker.Speak("Meu nome é TV, se você ser mal educada eu não vou deixar você assistir Youtube, para você ser minha amiga, você tem que obdecer sua mãe, seu pai e seus irmãos. Quando você não ser educada, eu não deixo você assistir.".ToString());
        }
        public static void conversa4Windows()
        {
            Speaker.Speak("Olá nicoly, você é muito legal, você deve assitir desenhos, pepa pig, raposel, branca de neve.".ToString());
        }
    }
}
