namespace Library;

public class Mago : IAttackable
{
        public string Nombre { get; set; }
        public int MaxSalud { get; set; }
        public int ActualSalud { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Item ItemEquipado { get; set; }
        public Spellbook Spellbook { get; set; } = new Spellbook();

        public Mago(string nombre, int maxSalud)
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

            total += Spellbook.GetPoderTotal();

            return total;

        }
        
        public int GetTotalDefensa()
        {
            int total = 0;
            if (ItemEquipado != null)
                total += ItemEquipado.ValorDefensa;
            return total;
        }

        public void Atacar(IAttackable objetivo)
        {
            int danio = GetTotalAtaque() - objetivo.GetTotalDefensa();
            if (danio < 0) danio = 0;

            objetivo.ActualSalud -= danio;
            if (objetivo.ActualSalud < 0) objetivo.ActualSalud = 0;

            Console.WriteLine($"{Nombre} lanza un ataque mágico causando {danio} de daño. Salud restante del objetivo: {objetivo.ActualSalud}");
        }

        public void Curar(Item objeto)
        {
            if (Items.Contains(objeto) && objeto.Nombre.ToLower().Contains("poción"))
            {
                ActualSalud += objeto.ValorDefensa;
                if (ActualSalud > MaxSalud) ActualSalud = MaxSalud;

                Console.WriteLine($"{Nombre} usa {objeto.Nombre} y se cura {objeto.ValorDefensa} de vida.");
                Items.Remove(objeto);
            }
        }

        public void Equipar(Item item)
        {
            if (Items.Contains(item))
            {
                ItemEquipado = item;
                Console.WriteLine($"{Nombre} equipa {item.Nombre}.");
            }
        }

        public void SacarItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                if (ItemEquipado == item)
                    ItemEquipado = null;
                Console.WriteLine($"{Nombre} saca {item.Nombre}.");
            }
        }
}
