namespace Library;

public class Item
{
    public int ValorAtaque { get; set; }
    public int ValorDefensa { get; set; }
    public string Nombre { get; set; }

    public Item(string nombre, int valorAtaque, int valorDefensa)
    {
        Nombre = nombre;
        ValorAtaque = valorAtaque;
        ValorDefensa = valorDefensa;
    }
    // Item solo conoce sus propios valores, sin lógica de combate.
    // Así se puede reutilizar en cualquier personaje.
}