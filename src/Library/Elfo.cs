namespace Library
{ 
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
        // Experto en información: Elfo es el que conoce
        // sus ítems, por lo tanto él debe calcular su poder de ataque.
        public int GetTotalAtaque()
        {
            int total = 0;
            if (ItemEquipado != null)
                total += ItemEquipado.ValorAtaque;
            return total;
        }
        // Igual que en ataque: Elfo es responsable de calcular su defensa,
        // porque conoce su inventario y equipo. Evitamos depender de otra clase.
        public int GetTotalDefensa()
        {
            int total = 0;
            if (ItemEquipado != null)
                total += ItemEquipado.ValorDefensa;
            return total;
        }

        // Atacar encapsula la lógica de combate. Elfo aplica su ataque
        // contra el objetivo y no permite que exista daño negativo.
        // Se respeta SRP porque el ataque es parte del comportamiento
        // del personaje y no de los ítems.
        public void Atacar(IAttackable objetivo)
        {
            int danio = GetTotalAtaque() - objetivo.GetTotalDefensa();
            if (danio < 0) danio = 0;

            objetivo.ActualSalud -= danio;
            if (objetivo.ActualSalud < 0) objetivo.ActualSalud = 0;

            Console.WriteLine($"{Nombre} ataca causando {danio} de daño. Salud restante del objetivo: {objetivo.ActualSalud}");
        }
        // Curar devuelve salud al personaje. Se eligió que el método esté
        // en Elfo porque es el "experto en su propia vida".
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

