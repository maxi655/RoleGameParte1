namespace Library;

// Interfaz para todo lo que puede recibir ataques
public interface IAttackable
{
    int ActualSalud { get; set; }
    int GetTotalDefensa();
}