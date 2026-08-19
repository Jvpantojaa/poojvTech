namespace Biblioteca.Dominio;

public class Carteirinha
{
    public string Nome { get; }
    public DateTime DataNascimento { get; }
    private List<Emprestimo> _emprestimos = new();
    public IReadOnlyList<Emprestimo> Emprestimos => _emprestimos;

    public Carteirinha(string nome, DateTime dataNascimento)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new InvalidOperationException("O nome não pode ser vazio.");
        }

        if (dataNascimento > DateTime.Now)
        {
            throw new InvalidOperationException("Data de nascimento não pode ser futura.");
        }

        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public int CalcularIdade()
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;
        if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
        return idade;
    }

    public int QuantidadeEmprestada     
        => _emprestimos.Count(e => e.Ativo);

    public bool PodePegarMais()
    {
        return QuantidadeEmprestada < 3;
        
    }

    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        _emprestimos.Add(emprestimo);
    }
}