namespace CSharp_1;

public class Details
{
    private String street;
    
    private int zipCode;
    
    private String city;

    public Details(string street, int zipCode, string city)
    {
        this.street = street;
        this.zipCode = zipCode;
        this.city = city;
    }

    public string Street
    
    {
        get => street;
        set => street = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int ZipCode
    {
        get => zipCode;
        set => zipCode = value;
    }

    public string City
    {
        get => city;
        set => city = value ?? throw new ArgumentNullException(nameof(value));
    }
}