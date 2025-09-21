public interface IAttackable
{
    string Nombre { get; }
    int ActualSalud { get; set; }
    int MaxSalud { get; }
    int GetTotalDefensa();
}