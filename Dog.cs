namespace CSHARP25031903;

public class Dog
{
    public string Name { get; set; }
    public DateTime Birth { get; set; }
    public string Breed { get; set; }
    public bool Sex { get; set; }
    public float Weight { get; set; }
    public int Age => DateTime.Now.Year - Birth.Year;

    public override string ToString() => 
        $"{Name} " +
        $"({(Sex ? "male" : "female")} {Breed}, {Weight:0.0}Kg) " +
        $"born in {Birth.Year}, {Age} years old";
        
}
