using System.Reflection.Metadata.Ecma335;

namespace Biblioteca.Dominio;

public class Emprestimo
{
    public ItemAcervo Item { get; private set; }

    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;

    public DateTime PrazoLimite { get; }

    public Emprestimo(ItemAcervo item)
    {
        item.MarcarComoEmprestado();
        Item = item;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);

    }

    public decimal MultaAtual => Item.CalcularMulta(QtDiasAtrasados);
    public int QtDiasAtrasados
    {
        get
        {
            TimeSpan diasAtrasados = DateTime.Today - PrazoLimite;
            return diasAtrasados.Days;
        }
    }
    public void RegistrarDevolucao()
    {
        Item.MarcarComoDevolvido();
    }
}