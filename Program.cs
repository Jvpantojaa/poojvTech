using Biblioteca.Dominio;

class Program
{
    static void Main()
    {
        Console.WriteLine("📚 BIBLIOTECA DA DONA ZENAIDE\n");
        Console.WriteLine("═".PadRight(60, '═'));

        Console.WriteLine("\n🎬 CENA 1: MARINA E O DVD DE 16 ANOS");
        Console.WriteLine("─".PadRight(60, '─'));

        var carteirinhaMarina = new Carteirinha("Marina", new DateTime(2011, 5, 10));
        var dvd16 = new Dvd("Deadpool", "Fox", FaixaEtaria.Dezesseis);

        int idadeMarina = carteirinhaMarina.CalcularIdade();
        Console.WriteLine($"📌 {carteirinhaMarina.Nome} tem {idadeMarina} anos.");
        Console.WriteLine($"📌 Quer levar o DVD '{dvd16.Titulo}' (Faixa Etária: {dvd16.FaixaEtaria})");

        if (dvd16.PodeAlugar(idadeMarina))
        {
            Console.WriteLine($"✅ {carteirinhaMarina.Nome} pode levar!");
        }
        else
        {
            Console.WriteLine($"❌ {carteirinhaMarina.Nome} NÃO pode levar!");
            Console.WriteLine($"📌 Motivo: Precisa ter {dvd16.IdadeMinima()} anos. Ela tem {idadeMarina}.");
        }

        Console.WriteLine("\n🎬 CENA 2: CAIO COM 3 ITENS QUER O 4º");
        Console.WriteLine("─".PadRight(60, '─'));

        var carteirinhaCaio = new Carteirinha("Caio", new DateTime(2000, 3, 20));

        var livro1 = new Livro("O Senhor dos Anéis", "Tolkien");
        var livro2 = new Livro("Harry Potter", "Rowling");
        var livro3 = new Livro("1984", "Orwell");
        var livro4 = new Livro("Dom Casmurro", "Machado");

        Console.WriteLine($"📌 {carteirinhaCaio.Nome} pegou 3 livros:");

        var emp1 = new Emprestimo(carteirinhaCaio, livro1);
        var emp2 = new Emprestimo(carteirinhaCaio, livro2);
        var emp3 = new Emprestimo(carteirinhaCaio, livro3);

        Console.WriteLine($"   ✅ 1º: {livro1.Titulo}");
        Console.WriteLine($"   ✅ 2º: {livro2.Titulo}");
        Console.WriteLine($"   ✅ 3º: {livro3.Titulo}");
        Console.WriteLine($"📌 {carteirinhaCaio.Nome} tem {carteirinhaCaio.QuantidadeEmprestada} itens.");

        Console.WriteLine($"📌 Quer pegar o 4º: '{livro4.Titulo}'");

        try
        {
            var emp4 = new Emprestimo(carteirinhaCaio, livro4);
            Console.WriteLine("✅ Conseguiu pegar!");
        }
        catch (ExcecaoDominio ex)
        {
            Console.WriteLine($"❌ {carteirinhaCaio.Nome} NÃO pode pegar!");
            Console.WriteLine($"📌 Motivo: {ex.Message}");
        }

        Console.WriteLine("\n🎬 CENA 3: CAIO DEVOLVE 1 E PEGA OUTRO");
        Console.WriteLine("─".PadRight(60, '─'));

        Console.WriteLine($"📌 {carteirinhaCaio.Nome} devolveu '{livro1.Titulo}'");
        emp1.RegistrarDevolucao();

        Console.WriteLine($"📌 Agora tem {carteirinhaCaio.QuantidadeEmprestada} itens.");

        Console.WriteLine($"📌 Quer pegar '{livro4.Titulo}'");

        var emp4Caio = new Emprestimo(carteirinhaCaio, livro4);
        Console.WriteLine($"✅ {carteirinhaCaio.Nome} levou '{livro4.Titulo}'!");
        Console.WriteLine($"📌 Agora tem {carteirinhaCaio.QuantidadeEmprestada} itens.");

        Console.WriteLine("\n🎬 CENA 4: ITEM JÁ EMPRESTADO");
        Console.WriteLine("─".PadRight(60, '─'));

        var carteirinhaJoao = new Carteirinha("João", new DateTime(1995, 8, 12));
        var livroPopular = new Livro("O Alquimista", "Paulo Coelho");

        Console.WriteLine($"📌 {carteirinhaJoao.Nome} pegou '{livroPopular.Titulo}'");
        var empJoao = new Emprestimo(carteirinhaJoao, livroPopular);

        Console.WriteLine($"📌 {livroPopular.Titulo} está disponível? {livroPopular.Disponibilidade}");

        var carteirinhaMaria = new Carteirinha("Maria", new DateTime(1998, 2, 28));
        Console.WriteLine($"📌 {carteirinhaMaria.Nome} tentou pegar '{livroPopular.Titulo}'");

        try
        {
            var empMaria = new Emprestimo(carteirinhaMaria, livroPopular);
            Console.WriteLine("✅ Conseguiu pegar!");
        }
        catch (ExcecaoDominio ex)
        {
            Console.WriteLine($"❌ {carteirinhaMaria.Nome} NÃO pode pegar!");
            Console.WriteLine($"📌 Motivo: {ex.Message}");
        }

        Console.WriteLine($"📌 {livroPopular.Titulo} continua com {carteirinhaJoao.Nome}.");

        Console.WriteLine("\n🎬 CENA 5: SR. ELIAS - MULTA PAGA NÃO ACUMULA");
        Console.WriteLine("─".PadRight(60, '─'));

        var carteirinhaElias = new Carteirinha("Elias", new DateTime(1970, 3, 15));
        var revista = new Revista("Veja", "Editora Abril");

        Console.WriteLine($"📌 {carteirinhaElias.Nome} pegou a revista '{revista.Titulo}'");

        var empElias = new Emprestimo(carteirinhaElias, revista);

        Console.WriteLine($"📌 Devolveu com 5 dias de atraso.");
        empElias.RegistrarDevolucao();

        Console.WriteLine($"📌 Dias atrasados: {empElias.QtDiasAtrasados}");
        decimal multa = empElias.MultaAtual;
        Console.WriteLine($"📌 Multa a pagar: R$ {multa:F2}");

        Console.WriteLine($"📌 {carteirinhaElias.Nome} pagou a multa.");
        empElias.RegistrarPagamentoMulta();

        Console.WriteLine($"📌 Multa paga: {empElias.MultaPaga}");
        Console.WriteLine($"📌 Multa atual: R$ {empElias.MultaAtual:F2}");

        Console.WriteLine($"\n📌 Duas semanas depois...");
        Console.WriteLine($"📌 Alguém pergunta: Quanto o Sr. Elias devia?");

        if (empElias.MultaPaga)
        {
            Console.WriteLine($"📌 Resposta: R$ {multa:F2} (já foi paga)");
            Console.WriteLine($"📌 Valor não aumentou. Está registrado como pago.");
        }

        Console.WriteLine("\n" + "═".PadRight(60, '═'));
        Console.WriteLine("\n✅ Todas as cenas foram executadas com sucesso!");
    }
}