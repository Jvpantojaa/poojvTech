using Biblioteca.Dominio;

ItemAcervo Rubber = new Dvd("Rubber", "Pneu");
ItemAcervo deathNote = new Revista("Death Note", "Tsugumi Ohba");
ItemAcervo Sharknado = new Dvd("Sharknado", "sharkão");
ItemAcervo Hamlet = new Livro("Hamlet", "William Shakespeare");
ItemAcervo Rei_Lear = new Livro("Rei Lear", "William Shakespeare");
ItemAcervo amnesia = new Revista("Amnésia", "Autor esqueceu");
ItemAcervo Final = new Revista("É o fim", "Autor END...");
ItemAcervo A_volta_dos_que_não_foram = new Revista("A volta dos que não foram", "Autor Foi");


Emprestimo emprestimo = new Emprestimo(Hamlet);
Emprestimo emprestimo1 = new Emprestimo(Rubber);
Emprestimo emprestimo2 = new Emprestimo(deathNote);


emprestimo.RegistrarDevolucao();
emprestimo1.RegistrarDevolucao();
emprestimo2.RegistrarDevolucao();