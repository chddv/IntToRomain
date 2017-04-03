using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace IntToRomain
{
    class Program
    {

        static string intPattern = @"^(?<number>[0-9]){1,4}$"; // expression reguliere pour filtré l'entré utilisateur
        static string[] unites = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" }; // symbole romain des unitée
        static string[] dizaines = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" }; // symbole romain des dizaines
        static string[] centaines = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "XC" }; // symbole romain des centaines
        static string[] milliers = { "", "M", "MM", "MMMM", "MMMMM" }; //   symboles des milliers (les characteres romains se limite à 4999 sans extension (celon Wikipedia: https://fr.wikipedia.org/wiki/Num%C3%A9ration_romaine)

        // recupère chacun des digits d'un entier par récursivité
        private static void GetDigits(int aNumber, ref List<int> digits)
        {
            int tempNumber = aNumber % 10; // récupération du chiffre de gauche dans tempNumber (reste de la division "entiere")
            digits.Add(tempNumber); // ajoute celui-ci au tableau des digits
            if (aNumber /10 > 0) // si la valeur /10 est encore plus grande que 0, on continue avec celle-ci
            {
                GetDigits(aNumber / 10, ref digits);
            }
        }

        // converti un entier en chaine de charactere représentant la valeur de l'entier en nombre Romain
        public static string ConvertToRomain(int aNumber)
        {
            string result = "";
            if (aNumber > 0 && aNumber < 5000)
            {
                List<int> digits = new List<int>(); // creation du tableau recevant les digits
                GetDigits(aNumber, ref digits); // decoupe l'entier en digits
                if (digits.Count > 0) { result = unites[digits[0]]; } // recupere la chaine correspondant à la valeur dans le tableau correspondant au digit
                if (digits.Count > 1) { result = dizaines[digits[1]] + result; }
                if (digits.Count > 2) { result = centaines[digits[2]] + result; }
                if (digits.Count > 3) { result = milliers[digits[3]] + result; }
            }
            else
            {
                Error("[" + aNumber + "] n'est pas un nombre Romain valide.([1-4999])");
            }
            return result;
        }

        // affiche un message d'erreur dans la console
        private static void Error(string msg)
        {
            Console.WriteLine("Error: " + msg);
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Entrez un nombre de 1 à 4999 compris.");
            string inputStr = Console.ReadLine();  // attente d'une chaine de charactere entré par l'utilisateur
            Console.WriteLine("Vous avez entré  [" + inputStr + "]");

            Match match = Regex.Match(inputStr, intPattern); // valide la chaine entrée par l'utilisateur
            if(match.Success)
            {
                if (match.Groups.Count > 0) // valide la présence du group attendu
                {
                    int matchInt = Convert.ToInt32(match.Groups[0].Value); // converti la chaine en valeur entière entré par l'utilisateur
                    string finalResult = ConvertToRomain(matchInt); // converti en nombre romain
                    if(finalResult != "")
                    {
                        Console.WriteLine("Resultat: " + inputStr + " => " + finalResult);   // affiche le résultat
                    }
                }
            }
            else
            {
                Error("Ceci [" + inputStr + "] n'est pas un entier de 4 characteres");
            }
    
            Console.WriteLine("Appuyer sur une touche..");
            Console.ReadKey();
        }
    }
}
