class Carteirinha
{
    private string nome;
    private DateTime dataNascimento;
    
    public string Nome
    {
        get { return nome; }
        set { nome = value.ToUpper(); }
    }
    
    public DateTime DataNascimento
    {
        get { return dataNascimento; }
        set { dataNascimento = value; }
    }
}

