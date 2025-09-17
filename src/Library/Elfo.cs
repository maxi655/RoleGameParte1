using System.Collections.Generic;

namespace Library;

public class Elfo
{
    public string Nombre { get; set; }
    public int MaxSalud { get; set; }
    public int ActualSalud { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();

    public int GetTotalAtaque()
    {
        int total = 0;
        foreach (var item in Items)
        {
            total += item.Ataque;
        }
        return total;
    }

    public int GetTotalDefensa()
    {
        int total = 0;
        foreach (var item in Items)
        {
            total += item.Defensa;
        }