namespace CSharp_1;

public class Classe
{
    private List<Personne> eleves;
    private string nom;
    private string ecole;
    private string niveau;

    public List<Personne> Eleves
    {
        get => eleves;
        set => eleves = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Ecole
    {
        get => ecole;
        set => ecole = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Niveau
    {
        get => niveau;
        set => niveau = value ?? throw new ArgumentNullException(nameof(value));
    }
}