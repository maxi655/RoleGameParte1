using Library;  

namespace LibraryTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    // Justificación:
    // Necesario para comprobar que al atacar a otro personaje, su salud disminuye correctamente
    // según la diferencia entre ataque y defensa.
    [Test]
    public void Atacar_DisminuyeSaludCorrectamente()
    {
        Elfo elfo = new Elfo("Legolas", 100);
        Enano enano = new Enano("Gimli", 120);

        Item espada = new Item("Espada", 20, 0);
        Item armadura = new Item("Armadura", 0, 5);

        elfo.Items.Add(espada);
        elfo.Equipar(espada);

        enano.Items.Add(armadura);
        enano.Equipar(armadura);

        int saludInicial = enano.ActualSalud;
        elfo.Atacar(enano);

        Assert.Less(enano.ActualSalud, saludInicial,
            "El ataque debe reducir la salud del objetivo en función del ataque menos la defensa.");
    }
}