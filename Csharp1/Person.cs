using CSharp_1;

public class Personne
{
    private String prenom;
    private string nom;
    private int age;
    private Details adressDetails;
    private float taille;
    private int id;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public float Taille
    {
        get => taille;
        set => taille = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public Details AdressDetails
    {
        get => adressDetails;
        set => adressDetails = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Prenom
    {
        get => prenom;
        set => prenom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    
}