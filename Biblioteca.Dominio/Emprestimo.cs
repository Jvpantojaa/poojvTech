namespace Biblioteca.Dominio;

public class Emprestimo
{
    public Carteirinha Carteirinha { get; }
    public ItemAcervo Item { get; private set; }
    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;
    public DateTime PrazoLimite { get; }
    public bool Ativo { get; private set; } = true;
    public bool MultaPaga { get; private set; } = false;
    public DateTime? DataPagamentoMulta { get; private set; }

    public Emprestimo(Carteirinha carteirinha, ItemAcervo item)
    {
        if (!carteirinha.PodePegarMais())
        {
            throw new ExcecaoDominio($"{carteirinha.Nome} já tem 3 itens emprestados. Devolva um primeiro.");
        }

        carteirinha.AdicionarEmprestimo(this);
        item.MarcarComoEmprestado();

        Carteirinha = carteirinha;
        Item = item;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
    }

    public decimal MultaAtual
    {
        get
        {
            if (MultaPaga)
                return 0;

            return Item.CalcularMulta(QtDiasAtrasados);
        }
    }

    public int QtDiasAtrasados
    {
        get
        {
            TimeSpan diasAtrasados = DateTime.Today - PrazoLimite;
            return diasAtrasados.Days > 0 ? diasAtrasados.Days : 0;
        }
    }

    public void RegistrarDevolucao()
    {
        if (!Ativo)
        {
            throw new ExcecaoDominio("Este empréstimo já foi devolvido.");
        }

        Item.MarcarComoDevolvido();
        Ativo = false;
    }

    public void RegistrarPagamentoMulta()
    {
        if (MultaPaga)
        {
            throw new ExcecaoDominio("Esta multa já foi paga.");
        }

        if (QtDiasAtrasados <= 0)
        {
            throw new ExcecaoDominio("Não há multa a pagar. O item não está atrasado.");
        }

        MultaPaga = true;
        DataPagamentoMulta = DateTime.Today;
    }

    public bool DeveMulta => QtDiasAtrasados > 0 && !MultaPaga;
}