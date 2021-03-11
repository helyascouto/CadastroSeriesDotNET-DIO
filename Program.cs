using System;
using DIO.Series.Interfaces;
using DIO.Series;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoMenu = ObterOpcaoMenu();
            string opcaoUsuario = ObterOpcaoUsuario(opcaoMenu);

            while (opcaoUsuario.ToUpper() != "X")
            {
              

                if (opcaoMenu == "1")
                {

                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarFilme();
                            break;
                        case "2":
                            InserirFilme();
                            break;
                        case "3":
                            AtualizarFilme();
                            break;
                        case "4":
                            ExcluirFilme();
                            break;
                        case "5":
                            VisualizarFilme();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }


                }
                else
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                opcaoUsuario = ObterOpcaoUsuario(ObterOpcaoMenu());

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Exclui(indiceSerie);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id da Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            repositorioFilme.Exclui(indiceFilme);
        }



        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            var serie = repositorioSerie.RetornaPorId(indiceFilme);
            Console.WriteLine(serie);
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o id da Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            var Filme = repositorioFilme.RetornaPorId(indiceFilme);
            Console.WriteLine(Filme);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        }


        private static void AtualizarFilme()
        {
            Console.Write("Digite o id da Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Título da Filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de Início da Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a Descrição da Filme: ");
            string entradaDescricao = Console.ReadLine();
            Filme atualizaFilme = new Filme(id: indiceFilme,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }


        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var listaSeries = repositorioSerie.Lista();

            if (listaSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in listaSeries)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }




        private static void ListarFilme()
        {
            Console.WriteLine("Listar Fimes");
            var listaFilme = repositorioFilme.Lista();
            if (listaFilme.Count == 0)
            {
                Console.WriteLine("Nenhum Fime cadastrado.");
                return;
            }
            foreach (var filme in listaFilme)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }





        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioSerie.Insere(novaSerie);
        }



        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano do Início do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            Filme novoFilme = new Filme(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);
        }

        private static string ObterOpcaoMenu()
        {

            Console.WriteLine("1- Séries || 2- Fimes");
            string opcaoMenu = Console.ReadLine().ToUpper();
            return opcaoMenu;

        }


        private static string ObterOpcaoUsuario(string opcaoUsuario)
        {

            if (opcaoUsuario == "1")
            {
                Console.WriteLine("DIOFLIX Fimes e Séries !!!");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1- Listar séries");
                Console.WriteLine("2- Inserir nova série");
                Console.WriteLine("3- Atualizar série");
                Console.WriteLine("4- Excluir série");
                Console.WriteLine("5- Visualizar série");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                opcaoUsuario = Console.ReadLine().ToUpper();
            }
            else
            {
                Console.WriteLine(" DIOFLIX Fimes e Séries !!!");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1- Listar Filmes");
                Console.WriteLine("2- Inserir novo Filmes");
                Console.WriteLine("3- Atualizar Filmes");
                Console.WriteLine("4- Excluir Filmes");
                Console.WriteLine("5- Visualizar Filmes");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");

                opcaoUsuario = Console.ReadLine().ToUpper();

            }

            return opcaoUsuario;

        }
    }
}
