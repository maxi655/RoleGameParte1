namespace Library;

public class Hechizo
{
    public string Nombre { get; set; }
    public int Poder { get; set; }

    public Hechizo(string nombre, int poder)
    {
        Nombre = nombre;
        Poder = poder;
    }
}