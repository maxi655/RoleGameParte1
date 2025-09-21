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
    
    [Test]
    public void Curar_NoSuperaSaludMax()
    {
        var elfo = new Elfo("Legolas", 100);
        elfo.ActualSalud = 80;
    
        var pocion = new Item("Poción curativa", 0, 50);
        elfo.Items.Add(pocion);
    
        elfo.Curar(pocion); // intenta curar más de lo necesario
    
        Assert.AreEqual(100, elfo.ActualSalud);
    }
    
    // Justificación: 
    // Este test es necesario porque asegura que el método Curar respeta el tope de salud máxima. 
    // Sin esta validación, el personaje podría terminar con más puntos de salud de los permitidos, 
    // rompiendo la lógica del juego.
    
    [Test]
    public void SacarItem_EliminaDelInventarioYDesEquipa()
    {
        var elfo = new Elfo("Legolas", 100);
        var arco = new Item("Arco", 10, 0);
        elfo.Items.Add(arco);
        elfo.Equipar(arco);
    
        elfo.SacarItem(arco);
    
        Assert.IsFalse(elfo.Items.Contains(arco));
        Assert.IsNull(elfo.ItemEquipado);
    }
    
    // Justificación: 
    // Este test es necesario para garantizar que al remover un ítem no queden referencias "fantasma". 
    // Si el ítem se elimina del inventario pero sigue equipado, el personaje tendría estadísticas 
    // alteradas de manera indebida.

    
}