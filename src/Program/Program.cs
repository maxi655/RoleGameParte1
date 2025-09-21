using System;
using Library;

class Program
{
    static void Main(string[] args)
    {
    
        var mago = new Mago("Gandalf", 120);
        var elfo = new Elfo("Legolas", 100);
        var enano = new Enano("Gimli", 140);


        var baston = new Item("Bastón", 15, 5);
        var libro = new Item("Libro", 5, 0);
        var pocion = new Item("Poción", 0, 35);
        var espada = new Item("Espada", 20, 2);
        var arco = new Item("Arco", 10, 0);
        var armadura = new Item("Armadura", 0, 15);
        var hacha = new Item("Hacha", 18, 0);
        var escudo = new Item("Escudo", 0, 10);

        
        mago.Items.Add(baston);
        mago.Items.Add(libro);
        mago.Items.Add(pocion);

        elfo.Items.Add(espada);
        elfo.Items.Add(arco);
        elfo.Items.Add(pocion);

        enano.Items.Add(hacha);
        enano.Items.Add(escudo);
        enano.Items.Add(pocion);

        // Mago aprende hechizos
        var hechizoFuego = new Hechizo("Fuego", 20);
        var hechizoHielo = new Hechizo("Hielo", 10);
        mago.Spellbook.AprenderHechizo(hechizoFuego);
        mago.Spellbook.AprenderHechizo(hechizoHielo);

        
        mago.Equipar(baston);
        elfo.Equipar(espada);
        enano.Equipar(hacha);

        Console.WriteLine("\n Estado inicial ");
        MostrarSalud(mago);
        MostrarSalud(elfo);
        MostrarSalud(enano);

        // Elfo ataca a enano
        Console.WriteLine("\nElfo ataca a Enano:");
        elfo.Atacar(enano);

        // Enano ataca a mago
        Console.WriteLine("\nEnano ataca a Mago:");
        enano.Atacar(mago);

        // Mago lanza ataque  al elfo
        Console.WriteLine("\nMago ataca a Elfo:");
        mago.Atacar(elfo);

        // Elfo usa poción para curarse
        Console.WriteLine("\nElfo se cura:");
        elfo.Curar(pocion);

        // Mostrar estado final
        Console.WriteLine("\n Estado final ");
        MostrarSalud(mago);
        MostrarSalud(elfo);
        MostrarSalud(enano);
        
     
    }

    static void MostrarSalud(IAttackable personaje)
    {
        Console.WriteLine($"{personaje.Nombre}: {personaje.ActualSalud}/{personaje.MaxSalud} de salud.");
    }
    
}