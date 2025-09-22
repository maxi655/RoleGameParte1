namespace Library;

public class Spellbook
{
    public List<Hechizo> Hechizos { get; set; } = new List<Hechizo>();

    public void AprenderHechizo(Hechizo hechizo)
    {
        Hechizos.Add(hechizo);
        Console.WriteLine($"Se ha aprendido el hechizo {hechizo.Nombre}.");
    }
    // El libro es el que conoce la lista de hechizos,
    // por lo tanto él debe calcular su poder total.
    // Esto evita que otra clase tenga que recorrer la lista de hechizos.
    public int GetPoderTotal()
    {
        int total = 0;
        foreach (var h in Hechizos)
            total += h.Poder;
        return total;
    }
}