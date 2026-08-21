using Biblioteca.Dominio;


Carteirinha marina = new Carteirinha("Marina", new DateTime(2011, 5, 10));
Dvd dvd16 = new Dvd("Deadpool", "Fox", FaixaEtaria.Dezesseis);

if (dvd16.PodeAlugar(marina.CalcularIdade()))
{
    Console.WriteLine("Marina pode levar o DVD");
}
else
{
    Console.WriteLine("Marina não pode levar o DVD");
}

Carteirinha caio = new Carteirinha("Caio", new DateTime(2000, 3, 20));

Livro livro1 = new Livro("O Senhor dos Anéis", "Tolkien");
Livro livro2 = new Livro("Harry Potter", "Rowling");
Livro livro3 = new Livro("1984", "Orwell");
Livro livro4 = new Livro("Dom Casmurro", "Machado");

Emprestimo emp1 = new Emprestimo(caio, livro1);
Emprestimo emp2 = new Emprestimo(caio, livro2);
Emprestimo emp3 = new Emprestimo(caio, livro3);

try
{
    Emprestimo emp4 = new Emprestimo(caio, livro4);
    Console.WriteLine("Caio conseguiu pegar o 4o item");
}
catch (ExcecaoDominio)
{
    Console.WriteLine("Caio não pode pegar o 4o item");
}

emp1.RegistrarDevolucao();

Emprestimo emp5 = new Emprestimo(caio, livro4);
Console.WriteLine("Caio pegou o 4o item depois de devolver um");

Carteirinha joao = new Carteirinha("Joao", new DateTime(1995, 8, 12));
Livro livroPopular = new Livro("O Alquimista", "Paulo Coelho");

Emprestimo empJoao = new Emprestimo(joao, livroPopular);

Carteirinha maria = new Carteirinha("Maria", new DateTime(1998, 2, 28));

try
{
    Emprestimo empMaria = new Emprestimo(maria, livroPopular);
    Console.WriteLine("Maria conseguiu pegar o livro");
}
catch (ExcecaoDominio)
{
    Console.WriteLine("Maria não pode pegar o livro porque já está emprestado");
}

Carteirinha elias = new Carteirinha("Elias", new DateTime(1970, 3, 15));
Revista revista = new Revista("Veja", "Editora Abril");

Emprestimo empElias = new Emprestimo(elias, revista);
empElias.RegistrarDevolucao();

if (empElias.QtDiasAtrasados > 0)
{
    decimal multa = empElias.MultaAtual;
    empElias.RegistrarPagamentoMulta();
    Console.WriteLine($"Multa paga: {multa}");
}
else
{
    Console.WriteLine("Sem multa a pagar");
}

Console.WriteLine($"Multa atual depois de duas semanas: {empElias.MultaAtual}");


var livroNovo = new Livro("O Cortiço", "Aluísio Azevedo");
var revistaNova = new Revista("Piauí", "Alvinegra");
Console.WriteLine($"Cena 6 - {livroNovo.Titulo} e o Id {livroNovo.Id}, " +
                  $"{revistaNova.Titulo} e o Id {revistaNova.Id}");
