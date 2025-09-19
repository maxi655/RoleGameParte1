namespace Library;

public class Spellbook
{
    public List<Hechizo> Hechizos { get; set; } = new List<Hechizo>();

    public void AprenderHechizo(Hechizo hechizo)
    {
        Hechizos.Add(hechizo);
        Console.WriteLine($"Se ha aprendido el hechizo {hechizo.Nombre}.");
    }

    public int GetPoderTotal()
    {
        int total = 0;
        foreach (var h in Hechizos)
            total += h.Poder;
        return total;
    }
}