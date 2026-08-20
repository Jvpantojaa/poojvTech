namespace Biblioteca.Dominio;

public enum FaixaEtaria
{
    Livre,
    Doze,
    Quatorze,
    Dezesseis,
    Dezoito
}

public class Dvd(string titulo, string autor, FaixaEtaria faixaEtaria) : ItemAcervo(titulo, autor)
{
    public FaixaEtaria FaixaEtaria { get; } = faixaEtaria;
    
    public override int PrazoDevolucao => 3;
    public override decimal MultaDiaAtrasado => 3m;
    
    public bool PodeAlugar(int idade)
    {
        return idade >= IdadeMinima();
    }
    
    public int IdadeMinima()
    {
        return FaixaEtaria switch
        {
            FaixaEtaria.Livre => 0,
            FaixaEtaria.Doze => 12,
            FaixaEtaria.Quatorze => 14,
            FaixaEtaria.Dezesseis => 16,
            FaixaEtaria.Dezoito => 18,
            _ => 0
        };
    }
}