using System;
using System.Collections.Generic;

namespace Library
{
    // Interfaz para todo lo que puede recibir ataques
    public interface IAttackable
    {
        int ActualSalud { get; set; }
        int GetTotalDefensa();
    }

    public class Elfo : IAttackable
    {
        public string Nombre { get; set; }
        public int MaxSalud { get; set; }
        public int ActualSalud { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Item ItemEquipado { get; set; }

        public Elfo(string nombre, int maxSalud)
        {
            Nombre = nombre;
            MaxSalud = maxSalud;
            ActualSalud = maxSalud;
        }

        public int GetTotalAtaque()
        {
            int total = 0;
            if (ItemEquipado != null)
                total += ItemEquipado.ValorAtaque;
            return total;
        }

        public int GetTotalDefensa()
        {
            int total = 0;
            if (ItemEquipado != null)
                total += ItemEquipado.ValorDefensa;
            return total;
        }

        // Ahora puede atacar a cualquier IAttackable
        public void Atacar(IAttackable objetivo)
        {
            int danio = GetTotalAtaque() - objetivo.GetTotalDefensa();
            if (danio < 0) danio = 0;

            objetivo.ActualSalud -= danio;
            if (objetivo.ActualSalud < 0) objetivo.ActualSalud = 0;

            Console.WriteLine($"{Nombre} ataca causando {danio} de daño. Salud restante del objetivo: {objetivo.ActualSalud}");
        }

        public void Curar(Item objeto)
        {
            if (Items.Contains(objeto) && objeto.Nombre.ToLower().Contains("poción"))
            {
                ActualSalud += objeto.ValorDefensa; // asumimos que ValorDefensa = cantidad de curación
                if (ActualSalud > MaxSalud) ActualSalud = MaxSalud;

                Console.WriteLine($"{Nombre} usa {objeto.Nombre} y recupera {objeto.ValorDefensa} de salud. Salud actual: {ActualSalud}/{MaxSalud}");
                Items.Remove(objeto);
            }
            else
            {
                Console.WriteLine($"{objeto.Nombre} no es un objeto curativo o no está en el inventario.");
            }
        }

        public void Equipar(Item item)
        {
            if (Items.Contains(item))
            {
                ItemEquipado = item;
                Console.WriteLine($"{Nombre} equipa {item.Nombre}.");
            }
            else
            {
                Console.WriteLine($"{item.Nombre} no está en el inventario.");
            }
        }

        public void SacarItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                if (ItemEquipado == item)
                    ItemEquipado = null;

                Console.WriteLine($"{Nombre} saca {item.Nombre} del inventario.");
            }
            else
            {
                Console.WriteLine($"{item.Nombre} no está en el inventario.");
            }
        }
    }
}
