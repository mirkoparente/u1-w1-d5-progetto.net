using System;
using System.Collections.Generic;
using System.Globalization;

namespace u1_w1_d5_progetto.net
{
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CF { get; set; }
        public string Sesso { get; set; }
        public string ComuneRes { get; set; }
        public double RedditoAnnuale { get; set; }


        public Contribuente() { }
        public Contribuente(string nome, string cognome, DateTime dataNascita, string cf, string sesso, string comuneRes, double redditoAnnuale)
        {

            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CF = cf;
            Sesso = sesso;
            ComuneRes = comuneRes;
            RedditoAnnuale = redditoAnnuale;

        }


        public void Menu()
        {
            Console.WriteLine("################ AGENZIA DELLE USCITE ###########################");
            Console.WriteLine("Premi 1 per l' inserimento di una nuova dichiarazione");
            Console.WriteLine("Premi 2 per la lista completa di tutti i contribuenti");
            Console.WriteLine("Premi 3 per  uscire");
            Console.WriteLine("#################################################################");
            Console.WriteLine("");



            int scelta = int.Parse(Console.ReadLine());
            if (scelta == 1)
            {
                Inserisci();
            }
            else if (scelta == 2)
            {
                ListaContribuenti.MostraLista();
                Menu();
            }
            else if (scelta == 3)
            {
                Environment.Exit(0);
            }
        }



        public void Inserisci()
        {

            try
            {
                Console.WriteLine("Inserisci i dati del contribuente:");
                Console.WriteLine("");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();
                Console.Write("Data di nascita: ");
                Console.WriteLine("* inserire la data seguita dagli spazi GG MM AAAA");
                DateTime dataNascita = DateTime.Parse(Console.ReadLine().Replace(" ", "/"));
                Console.Write("Codice Fiscale: ");
                string cf = Console.ReadLine();
                Console.Write("Sesso (M/F): ");
                string sesso = Console.ReadLine();
                Console.Write("Comune di residenza: ");
                string comuneRes = Console.ReadLine();
                Console.Write("Reddito annuale: ");
                double redditoAnnuale = double.Parse(Console.ReadLine());


                if (nome != "" || cognome != "" || cf != "" || comuneRes != "")
                {


                    Contribuente contr = new Contribuente(nome, cognome, dataNascita, cf, sesso, comuneRes, redditoAnnuale);



                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;


                    Console.WriteLine("################ DATI CONTRIBUENTE ###########################");
                    Console.WriteLine($"Nome :{myTI.ToTitleCase(contr.Nome)}");
                    Console.WriteLine($"Cognome : {myTI.ToTitleCase(contr.Cognome)}");
                    Console.WriteLine($"Nato il : {contr.DataNascita.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Residente in : {myTI.ToTitleCase(contr.ComuneRes)}");
                    Console.WriteLine($"Codice Fiscale : {myTI.ToUpper(contr.CF)}");
                    Console.WriteLine($"Sesso : {myTI.ToTitleCase(contr.Sesso)}");
                    Console.WriteLine($"Reddito Dichiarato : € {contr.RedditoAnnuale.ToString("N")}");
                    Console.WriteLine($"                       +++++IMPOSTA DA VERSARE+++++ € {contr.Calcolo().ToString("N")}");
                    Console.WriteLine("##############################################################");
                    Console.WriteLine();


                    Cont contribuente = new Cont() { Nome = contr.Nome, Cognome = contr.Cognome, CF = contr.CF, DataNascita = contr.DataNascita, RedditoAnnuale = contr.Calcolo() };
                    ListaContribuenti.ListaCont.Add(contribuente);

                    Menu();

                }
                else
                {
                    Console.WriteLine("Devi inserire del testo valido, non puoi lasciare input vuoti!");
                    Menu();
                }


            }

            catch (System.FormatException)
            {


                Console.WriteLine($"Inserisci i campi nel  formato corretto");
                Menu();
            }
        }
        public double Calcolo()
        {


            if (RedditoAnnuale <= 15000)
            {
                return (RedditoAnnuale * 23) / 100;
            }
            else if (RedditoAnnuale <= 28000)
            {
                return 3450 + (RedditoAnnuale - 15000) * 27 / 100;
            }
            else if (RedditoAnnuale <= 55000)
            {
                return 6960 + (RedditoAnnuale - 28000) * 38 / 100;
            }
            else if (RedditoAnnuale <= 75000)
            {
                return 17220 + (RedditoAnnuale - 55000) * 41 / 100;
            }
            else
            {
                return 25420 + (RedditoAnnuale - 75000) * 43 / 100;
            }
        }

    }

    public class Cont
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CF { get; set; }
        public double RedditoAnnuale { get; set; }

    }

    public class ListaContribuenti
    {
        public static List<Cont> ListaCont = new List<Cont>();

        public static void MostraLista()
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;


            Console.WriteLine("################ CONTRIBUENTI CON DICHIARAZIONE PRESENTATA ###########################");

            if (ListaCont.Count > 0)
            {
                foreach (Cont cont in ListaCont)
                {

                    Console.WriteLine($"Contribuente :{myTI.ToTitleCase(cont.Nome)} {myTI.ToTitleCase(cont.Cognome)} Codice Fiscale : {myTI.ToUpper(cont.CF)} Data Di Nascita: {cont.DataNascita.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Importo da versare € {cont.RedditoAnnuale.ToString("N")}");
                }
            }
            else
            {
                Console.WriteLine("Ancora nessuna dichiarazione");

            }
            Console.WriteLine("#######################################################################################");
            Console.WriteLine();
        }
    }
}
