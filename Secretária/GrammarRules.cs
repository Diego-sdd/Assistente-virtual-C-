using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretária
{
    public class GrammarRules
    {
        //Listas com comandos

        public static IList<string> WhatTimeIs = new List<string>()
        {
            "Que horas são",
            "Me diga as horas",
            "Poderia me dizer que horas são"
        };
        public static IList<string> whatDateIs = new List<string>()
        {
            "Que dia é hoje",
            "Qual é a data de hoje",
            "Você sabe me dizer a data de hoje",
            "por favor que dia é hoje"

        };
        public static IList<string> JarvisStartListening = new List<string>()
        {
            "Jarvis",
            "Jarvis você está ai ?",
            "Olá jarvis",
            "oi jarvis"
        };
        public static IList<string> JarvisStopListening = new List<string>()
        {
            "Pare de ouvir",
            "Desligar comandos",
            "Parar comandos",
            "Jarvis desligar"
        };
        public static IList<string> MinimizeWindow = new List<string>()
        {
            "Minimizar janela",
            "Minimize a janela",
            "Pare de ouvir",
            "Desligar comandos",
            "Parar comandos",
            "Jarvis desligar"
        };
        public static IList<string> normalWindow = new List<string>()
        {
            "Máximizar janela",
            "Máximize a janela",
            "Abrir janela",
            "Abrir sistema",
            "Abrir tela"
            
        };
        public static IList<string> conversaWindows = new List<string>()
        {
            "Olá tudo bem ?",
            "Tudo bem com você ?",
            "Como você está?",
            "Você está bem ?",
        };
        public static IList<string> conversa2Windows = new List<string>()
        {
            "Qual o seu nome ?",
            "Como é seu nome ?",
            "Se apresente por favor",
            "Qual a sua graça",
        };
        public static IList<string> conversa3Windows = new List<string>()
        {
            "Porque você parou a internet ?",
            "Se eu for mal educada",
            "Se eu for mal educada você cancela",
           

        };
        public static IList<string> conversa4Windows = new List<string>()
        {
            "Meu nome é nicoly",
            "Que desenho é legal",

        };
        public static IList<string> ChanceVoice= new List<string>()
        {
            "Alterar a Voz",
            "Alterar voz",

        };


    }
}
