using System;
using static System.Console;

enum TipoDinosauro
{
    Brontosauro,
    Triceratopo,
    Pterodattilo,
    TRex,
    Stegosauro
}

enum Taglia
{
    Piccolo,
    Medio,
    Grande
}

struct Dinosauro
{
    public int codice;
    public TipoDinosauro tipo;
    public Taglia taglia;
    public int eta;
    public int forza;
    public string proprietario;

    public Dinosauro(int c, TipoDinosauro t, Taglia ta, int e, int f, string p)
    {
        codice = c;
        tipo = t;
        taglia = ta;
        eta = e;
        forza = f;
        proprietario = p;
    }

    public void Stampa()
    {
        WriteLine($"Codice: {codice} - Tipo: {tipo} - Taglia: {taglia} - Eta: {eta} - Forza: {forza} - Proprietario: {proprietario}");
    }
}

class Program
{
    static bool pieno = false;

    static void Main(string[] args)
    {
        Dinosauro[] recinto = new Dinosauro[10];
        string scelta;

        do
        {
            WriteLine("\n===== MENU =====");
            WriteLine("1. Riempi il recinto");
            WriteLine("2. Scambia dinosauro tramite codice");
            WriteLine("3. Scambia proprietari tra due dinosauri");
            WriteLine("4. Visualizza tutti");
            WriteLine("5. Filtra per tipo");
            WriteLine("6. Filtra per taglia");
            WriteLine("e. Esci");

            do
            {
                WriteLine("Scegli una delle funzioni:");
                scelta = ReadLine();
            } while (scelta != "1" && scelta != "2" && scelta != "3" &&
                     scelta != "4" && scelta != "5" && scelta != "6" && scelta != "e");

            switch (scelta)
            {
                case "1":
                    RiempiRecinto(recinto);
                    break;
                case "2":
                    if (!pieno) WriteLine("Prima riempi il recinto!");
                    else ScambiaDinosauro(recinto);
                    break;
                case "3":
                    if (!pieno) WriteLine("Prima riempi il recinto!");
                    else ScambiaProprietari(recinto);
                    break;
                case "4":
                    if (!pieno) WriteLine("Prima riempi il recinto!");
                    else Visualizza(recinto);
                    break;
                case "5":
                    if (!pieno) WriteLine("Prima riempi il recinto!");
                    else FiltraPerTipo(recinto);
                    break;
                case "6":
                    if (!pieno) WriteLine("Prima riempi il recinto!");
                    else FiltraPerTaglia(recinto);
                    break;
                case "e":
                    WriteLine("Arrivederci da Bedrock! Yabadabaduu!");
                    break;
            }

        } while (scelta != "e");
    }

    // CERCA PER CODICE (ritorna posizione, -1 se non trovato)
    static int CercaCodice(Dinosauro[] recinto, int cod)
    {
        for (int i = 0; i < recinto.Length; i++)
        {
            if (recinto[i].codice == cod)
                return i;
        }
        return -1;
    }

    // RIEMPI IL RECINTO
    static void RiempiRecinto(Dinosauro[] recinto)
    {
        for (int i = 0; i < recinto.Length; i++)
        {
            WriteLine("\nDinosauro n: " + (i + 1));

            int codice;
            do
            {
                WriteLine("Inserisci codice:");
            } while (!int.TryParse(ReadLine(), out codice));

            int sTipo;
            do
            {
                WriteLine("Tipo (0=Brontosauro, 1=Triceratopo, 2=Pterodattilo, 3=TRex, 4=Stegosauro):");
            } while (!int.TryParse(ReadLine(), out sTipo) || sTipo < 0 || sTipo > 4);
            TipoDinosauro tipo = (TipoDinosauro)sTipo;

            int sTaglia;
            do
            {
                WriteLine("Taglia (0=Piccolo, 1=Medio, 2=Grande):");
            } while (!int.TryParse(ReadLine(), out sTaglia) || sTaglia < 0 || sTaglia > 2);
            Taglia taglia = (Taglia)sTaglia;

            int eta;
            do
            {
                WriteLine("Inserisci eta:");
            } while (!int.TryParse(ReadLine(), out eta) || eta < 0);

            int forza;
            do
            {
                WriteLine("Inserisci Forza (1-100):");
            } while (!int.TryParse(ReadLine(), out forza) || forza < 1 || forza > 100);

            Write("Proprietario: ");
            string proprietario = ReadLine();

            recinto[i] = new Dinosauro(codice, tipo, taglia, eta, forza, proprietario);
        }
        pieno = true;
        WriteLine("Recinto pieno! Yabadabaduu!");
    }

    // SCAMBIA DINOSAURO 
    static void ScambiaDinosauro(Dinosauro[] recinto)
    {
        int cod;
        do
        {
            WriteLine("Codice del dinosauro da portare via:");
        } while (!int.TryParse(ReadLine(), out cod));

        int pos = CercaCodice(recinto, cod);
        if (pos == -1)
        {
            WriteLine("Dinosauro non trovato!");
            return;
        }

        WriteLine("Dinosauro trovato:");
        recinto[pos].Stampa();

        WriteLine("\nInserisci il nuovo dinosauro:");

        int codice;
        do
        {
            WriteLine("Inserisci codice:");
        } while (!int.TryParse(ReadLine(), out codice));

        int sTipo;
        do
        {
            WriteLine("Tipo (0=Brontosauro, 1=Triceratopo, 2=Pterodattilo, 3=TRex, 4=Stegosauro):");
        } while (!int.TryParse(ReadLine(), out sTipo) || sTipo < 0 || sTipo > 4);
        TipoDinosauro tipo = (TipoDinosauro)sTipo;

        int sTaglia;
        do
        {
            WriteLine("Taglia (0=Piccolo, 1=Medio, 2=Grande):");
        } while (!int.TryParse(ReadLine(), out sTaglia) || sTaglia < 0 || sTaglia > 2);
        Taglia taglia = (Taglia)sTaglia;

        int eta;
        do
        {
            WriteLine("Inserisci eta:");
        } while (!int.TryParse(ReadLine(), out eta) || eta < 0);

        int forza;
        do
        {
            WriteLine("Inserisci Forza (1-100):");
        } while (!int.TryParse(ReadLine(), out forza) || forza < 1 || forza > 100);

        Write("Proprietario: ");
        string proprietario = ReadLine();

        recinto[pos] = new Dinosauro(codice, tipo, taglia, eta, forza, proprietario);
        WriteLine("Sostituzione fatta!");
    }

    //SCAMBIA PROPRIETARI 
    static void ScambiaProprietari(Dinosauro[] recinto)
    {
        int cod1, cod2;

        do
        {
            WriteLine("Codice primo dinosauro:");
        } while (!int.TryParse(ReadLine(), out cod1));

        int posTipo = CercaCodice(recinto, cod1);
        if (posTipo == -1)
        {
            WriteLine("Primo dinosauro non trovato!");
            return;
        }

        do
        {
            WriteLine("Codice secondo dinosauro:");
        } while (!int.TryParse(ReadLine(), out cod2));

        int posTaglia = CercaCodice(recinto, cod2);
        if (posTaglia == -1)
        {
            WriteLine("Secondo dinosauro non trovato!");
            return;
        }

        string temp = recinto[posTipo].proprietario;
        recinto[posTipo].proprietario = recinto[posTaglia].proprietario;
        recinto[posTaglia].proprietario = temp;

        WriteLine("Proprietari scambiati!");
    }

    //   VISUALIZZA TUTTI 
    static void Visualizza(Dinosauro[] recinto)
    {
        WriteLine("\n=== RECINTO DI BEDROCK ===");
        for (int i = 0; i < recinto.Length; i++)
        {
            recinto[i].Stampa();
        }
    }

    // FILTRA PER TIPO 
    static void FiltraPerTipo(Dinosauro[] recinto)
    {
        int s;
        do
        {
            WriteLine("Tipo (0=Brontosauro, 1=Triceratopo, 2=Pterodattilo, 3=TRex, 4=Stegosauro):");
        } while (!int.TryParse(ReadLine(), out s) || s < 0 || s > 4);

        TipoDinosauro t = (TipoDinosauro)s;
        bool trovato = false;

        for (int i = 0; i < recinto.Length; i++)
        {
            if (recinto[i].tipo == t)
            {
                recinto[i].Stampa();
                trovato = true;
            }
        }
        if (!trovato)
            WriteLine("Nessun dinosauro di quel tipo.");
    }

    // FILTRA PER TAGLIA 
    static void FiltraPerTaglia(Dinosauro[] recinto)
    {
        int s;
        do
        {
            WriteLine("Taglia (0=Piccolo, 1=Medio, 2=Grande):");
        } while (!int.TryParse(ReadLine(), out s) || s < 0 || s > 2);

        Taglia t = (Taglia)s;
        bool trovato = false;

        for (int i = 0; i < recinto.Length; i++)
        {
            if (recinto[i].taglia == t)
            {
                recinto[i].Stampa();
                trovato = true;
            }
        }
        if (!trovato)
            WriteLine("Nessun dinosauro di quella taglia.");
    }
}