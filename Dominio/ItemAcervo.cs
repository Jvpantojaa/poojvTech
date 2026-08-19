namespace Biblioteca.Dominio;

public abstract class ItemAcervo
{
    public ItemAcervo(string titulo, string autor)
    {
        if(string.IsNullOrWhiteSpace(titulo))
        {
            throw new ExcecaoDominio("O título não pode ser vazio.");
        }
        if(string.IsNullOrWhiteSpace(autor))
        {
            throw new ExcecaoDominio("O autor não pode ser vazio.");
        }
        Titulo = titulo;
        Autor = autor;
    }

    public string Titulo { get; private set; } = string.Empty;

    public string Autor { get; private set; } = string.Empty;

    public bool Disponibilidade { get; private set; } = true;

    public abstract int PrazoDevolucao { get; } 

    public abstract decimal MultaDiaAtrasado { get; }

    public decimal CalcularMulta(int p_diasAtrasado)
    {
        return p_diasAtrasado >= 0 ? p_diasAtrasado * MultaDiaAtrasado : 0;
    }

    public void MarcarComoDevolvido()
    {
        if(Disponibilidade)
        {
            throw new ExcecaoDominio("Não está emprestado");
        }
        Disponibilidade = true;
    }
    public void MarcarComoEmprestado()
    {
        if(!Disponibilidade)
        {
            throw new ExcecaoDominio("já está emprestado");
        }
        Disponibilidade = false;
    }

}