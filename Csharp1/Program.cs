using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using CSharp_1;
using System;
using System.IO;

// On créer un nouvel objet classe
Classe classe = new Classe();

// On associe les valeurs à notre objet classe
Console.WriteLine("Quel est le nom de votre classe ?");
classe.Nom = Console.ReadLine();
Console.WriteLine("Quel est votre nom de votre école ?");
classe.Ecole = Console.ReadLine();
Console.WriteLine("Quel est votre niveau ?");
classe.Niveau = Console.ReadLine();

// On récupère le chemin d'accès du csv
Console.WriteLine("Route d'accès de votre fichier csv");
string path_csv = Console.ReadLine();

//On initialise la liste d'élèves
List<Personne> listeEleves = [];

using (StreamReader sr = new StreamReader(@path_csv))
{
     // Pour ignorer l’en-tête
    string line;
    bool firstLine = true;

    while ((line = sr.ReadLine()) != null)
    {
        if (firstLine) // Ignore la première ligne d'en-tête
        {
            firstLine = false;
            continue;
        }
                
        string[] values = line.Split(',');
        
        // On créer l'objet eleve
        Personne eleve = new Personne();
        
        // On associe les valeurs au bon paramètre de notre objet
        eleve.Id = int.Parse(values[0]);
        eleve.Nom = values[1];
        eleve.Prenom = values[2];
        String birthdate = values[3];
        String addres = values[4];
        eleve.Taille = int.Parse (values[5]);
        
        // On sépare le string addres en 3 pour avoir la rue, le code postal et la ville
        List<String> listAddress = addres.Split(';').ToList();
        eleve.AdressDetails = new Details(listAddress[0], int.Parse(listAddress[1]), listAddress[2]);
        
        // On calcule l'age avec la date de naissance
        
        DateTime.TryParse(birthdate, out DateTime birth);
        DateTime ajd = DateTime.Today;

        int age = DateTime.Now.Year - birth.Year;

        // Si mois de naissance est après le mois d'aujourdhui
        if (ajd.Month < birth.Month ||
            //  OU si dans le même mois mais que le jour est apres aujourd'hui
            (ajd.Month == birth.Month && ajd.Day < birth.Day))
        {
            age = age - 1;
        }
        
        // On associe age au paramètre age de l'objet eleve
        eleve.Age = age;
        
        // On ajoute eleve dans notre liste d'eleves
        listeEleves.Add(eleve);
    }
}
// On associe la liste d'élèves à notre objet classe
classe.Eleves = listeEleves;

// On calcule la taille moyenne de la classe en cm
int taille_moyenne_cm = (int)classe.Eleves.Average(p => p.Taille);

List<Personne> liste_eleves_plus_grand_moyenne= [];
// Pour chaque élève de la classe
foreach (Personne eleve in classe.Eleves)
{
    // Si l'élève est plus grand que la moyenne ET qu'il habite à Nantes
    if (eleve.Taille > taille_moyenne_cm && eleve.AdressDetails.City == "Nantes"){
        // Alors on calcule sa taille en m puis on l'ajoute à la liste des élèves qui sont plus grands que la moyenne
        eleve.Taille = eleve.Taille / 100f;
        liste_eleves_plus_grand_moyenne.Add(eleve);
        
    }
    
}

// On tri la liste des élèves plus grands que la moyenne dans l'ordre décroissant en fonction de la taille
List<Personne> liste_eleves_tries = liste_eleves_plus_grand_moyenne.OrderByDescending(eleve => eleve.Taille).ToList();

// On initialise la première position qui est la 1
int position = 1;
// Pour chaque élève dans la liste triés
foreach (Personne eleve in liste_eleves_tries)
{
    // On affiche l'élève avec le bon avec l'affichage demandé puis on ajoute 1 à la position
    Console.WriteLine($"{position} - {eleve.Prenom} - {eleve.Taille}");
    position += 1;
    
}

