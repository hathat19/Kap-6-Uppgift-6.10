using System;
using System.Collections.Generic;
namespace Uppgift6_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Färger
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            //-------------------------------------------

            Console.WriteLine("Skriv något:");
            string text = Console.ReadLine();
            Console.WriteLine(AntalTalIText(text));
        }

        static int AntalTalIText(string text, char decimalSign = ',')
        {
            int nrOfNrs = 0;
            //Går igenom hela texten
            for (int i = 0; i < text.Length; i++)
            {
                if (IntEllerInte(text[i]))
                {
                    for (int j = i+1; j <= text.Length; j++)
                    {
                        if (j == text.Length && IntEllerInte(text[j-1]))
                        {
                            nrOfNrs++;
                            i = j;
                            break;
                        }
                        else if (j == text.Length)
                        {
                            i = j;
                            break;
                        }

                        if (IntEllerInte(text[j]) == false && text[j] != decimalSign)
                        {
                            nrOfNrs++;
                            i = j;
                            break;
                        }
                        else if (text[j] == decimalSign && text[j-1] == decimalSign)
                        {
                            nrOfNrs++;
                            i = j;
                            break;
                        }
                    }
                }
            }
            return nrOfNrs;
        }

        static bool IntEllerInte(char n)
        {
            //Om char n inte kan ändras till en int så är den inte en int
            try
            {
                int x = int.Parse(n.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
/*Skapa ett program med en metod som heter AntalTalIText. Metoden ska ta emot en
sträng som den sedan delar upp vid alla mellanslag och undersöker hur många av
uppdelningarna som är tal. Om metoden exempelvis anropas med strängen
&quot;5 4,1 hej 9,04&quot;

så ska den returnera 3. Var uppmärksam på att decimaltal i strängen skrivs med
kommatecken och inte med punkt om du har svenska som språk på din dator.*/