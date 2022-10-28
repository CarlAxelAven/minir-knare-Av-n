using System;
using static System.Console;
//Välkomnande meddelande
Console.WriteLine("Välkommen till Miniräknaren!");
//Förbereder lite variabler
short prime = 0;
bool contin;
char option;
string help;
double numone, numtwo;
//en lista för att spara historik för räkningar
List<string> history = new List<string>();
//menyn
//OBS! Användaren måste mata in ett tal för att kunna ta sig vidare i programmet
while (prime != 3)
{
    
    WriteLine();
    WriteLine("Skriv en siffra kopplad till en funktion in menyn");
    WriteLine();
    WriteLine("1. Starta miniräknaren");
    WriteLine("2. Historik");
    WriteLine("3. Stäng av programmet");
    prime = short.Parse(ReadLine());
    //Kollar att användaren inte skrivit ett för stort nummer
    if (prime > 3 || prime < 1)
    {
        WriteLine("Du har inte skrivit in en siffra för en menyfunktion. Försök igen");
        ReadKey();
        Clear();
    }
    switch (prime) {
        //Användaren matar in det första talet
        case 1:
            contin = false;
            while (!contin) {
                Clear();
                WriteLine("Skriv din ekvation del för del, börja med det första talet:");
                help = ReadLine();
                //Kollar om ett tal har matats in
                while (double.TryParse(help, out numone) == false)
                {
                    WriteLine("Det du har skrivit är inte ett tal");
                    help = ReadLine();
                }
                WriteLine();
                //Användaren matar in deras matematiska operation
                WriteLine("Tackar, skriv nu mattesymbolen du vill använda");
                option = char.Parse(ReadLine());
                //Kollar om en matematisk operation har matats in
                while (option != '*' && option != '+' && option != '-' && option != '/')
                {
                    WriteLine("Du har inte skrivit en giltig symbol. Välj mellan att skriva '+', '-', '*', och '/'");
                    option = char.Parse(ReadLine());
                }
                //Användaren matar in det andra talet
                WriteLine("Sådär, skriv nu det andra talet");
                help = ReadLine();
                //Kollar om ett tal har matats in
                while (double.TryParse(help, out numtwo) == false)
                {
                    WriteLine("Det du har skrivit är inte ett tal");
                    help = ReadLine();
                }
                //Skickar vidare till metoden där allt räknas ut
                calc(numone, option, numtwo, history);
                WriteLine();
                WriteLine("Vill du fortsätta på miniräknaren? Ja/Nej");
                string read = ReadLine().ToLower();
                WriteLine(read);
                //Frågar användaren om de vill avsluta eller fortsätta
                if(read == "ja")
                {
                    WriteLine("Ok!");
                    ReadKey();
                    Clear();
                    contin = false;
                }
                else if(read == "nej")
                {
                    WriteLine("Ok!");
                    ReadKey();
                    contin = true;
                    Clear();
                }
                else
                {
                    WriteLine("Felskrivet, du tvingas nu tillbaka till huvudmenyn");
                    ReadKey();
                    contin = true; 
                    Clear();
                }
            }
                break;
        case 2:
            //Visas resultat från senast till tidigast
            Clear();
            WriteLine();
            WriteLine("Här är de tidigare resultaten:");
                history.Reverse();
            foreach (string i in history)
            {
                WriteLine(i);
            }
            history.Reverse();
            break;
        case 3:
            //stänger av while loopen via att välja 3 i huvudmenyn
            WriteLine("Adjö");
            break;
            
                   }
    
}
//miniräknarmetoden, tar emot båda talen och matematiska operatören och även historiken för att fortsätta på
void calc(double numone, char option, double numtwo, List<string> history)
{
    double answer;
    string temp;
    switch (option){
        //Plusekvationen
        case '+':
            WriteLine("Du vill lägga ihop {0} och {1}", numone, numtwo);
            answer = numone + numtwo;
            WriteLine("De två talen tillsammans är " + answer);
            //Sparar svaret som en string och lägger till det till listan
            temp = answer.ToString();
            history.Add(temp);
            return;
            break;
            //minusekvationen
        case '-':
            WriteLine("Du vill dra av {0} från {1}", numtwo, numone);
            answer = numone - numtwo;
            Console.WriteLine("När du drar av {0} från {1} så får du {2}", numtwo, numone, answer);
            //Sparar svaret som en string och lägger till det till listan
            temp = answer.ToString();
            history.Add(temp);
            return;
            break;
            //mulitiplikationsekvationen
        case '*':
            WriteLine("Du vill gångra {0} med {1}", numone, numtwo);
            answer = numone * numtwo;
            WriteLine("När de två talen gångras så får du " + answer);
            //Sparar svaret som en string och lägger till det till listan
            temp = answer.ToString();
            history.Add(temp);
            return;
            break;
        case '/':
            //divisionsekvationen, kollar först om numtwo är en nolla
            while(numtwo == 0)
            {
                //skriver att man inte kan dela med noll och ber om ett nytt delningstal
                WriteLine("Du kan inte dela nummer med noll, du får tyvärr skriva ett annat tal.");
                string help = ReadLine();
                
                while (double.TryParse(help, out numtwo) == false)
                {
                    WriteLine("Det du har skrivit är inte ett tal");
                    help = ReadLine();
                }
            }
            WriteLine("Du vill dela " + numone + " med " + numtwo);
            answer =numone / numtwo;
            WriteLine(numone + " delat på " + numtwo + " är lika med " + answer);
            //Sparar svaret som en string och lägger till det till listan
            temp = answer.ToString();
            history.Add(temp);
            return;
            break;
    }
}