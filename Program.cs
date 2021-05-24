using Dio.Filmes.Classes;
using Dio.Series.Classes;
using Dio.Series.Enum;
using Dio.Series.Interfaces;
using System;
using System.Collections.Generic;

namespace DIO.Series
{
	class Program
	{
		static SerieRepositorio repositorioSerie = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoObjeto();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						objetoselect("Série", repositorioSerie);
						break;
					case "2":
						objetoselect("Filme", repositorioFilme);
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoObjeto();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void objetoselect<T>(string objeto,IRepositorio<T> repositorio) where T : EntidadeBase
		{
			string opcaoUsuario = ObterOpcaoUsuario(objeto);

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarObjeto(repositorio);
						break;
					case "2":
						InserirObjeto(repositorio);
						break;
					case "3":
						AtualizarObjeto(repositorio);
						break;
					case "4":
						ExcluirObjeto(repositorio);
						break;
					case "5":
						VisualizarObjeto(repositorio);
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario(objeto);
			}
			Console.Clear();
		}
        private static void ExcluirObjeto<T>(IRepositorio<T> repositorio) where T : EntidadeBase
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

		private static void VisualizarObjeto<T>(IRepositorio<T> repositorio) where T : EntidadeBase
		{
			Console.Write("Digite o id: ");
			int indice = int.Parse(Console.ReadLine());

			var objeto = repositorio.RetornaPorId(indice);
			Console.WriteLine(objeto);

		}

		private static void AtualizarObjeto<T>(IRepositorio<T> repositorio) where T : EntidadeBase
		{
			Console.Write("Digite o id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

			if (repositorio.GetType().Equals(typeof(SerieRepositorio)))
			{

				Console.Write("Digite a quantidade de episodios: ");
				int episodios = int.Parse(Console.ReadLine());

				Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										episodios: episodios);

				(repositorio as SerieRepositorio).Atualiza(indiceSerie, atualizaSerie);
			}
			else if (repositorio.GetType().Equals(typeof(FilmeRepositorio)))
			{

				Filme atualizaSerie = new Filme(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				(repositorio as FilmeRepositorio).Atualiza(indiceSerie, atualizaSerie);
			}
		}
		private static void ListarObjeto<T>(IRepositorio<T> repositorio) where T : EntidadeBase
		{ 
			Console.WriteLine("Esses são os conteudos:");
  

			if (repositorio.GetType().Equals(typeof(SerieRepositorio)))
			{
				var lista = repositorio.Lista() as List<Serie>;
				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma conteudo cadastrado.");
					return;
				}

				foreach (var objeto in lista)
				{
					var excluido = objeto.retornaExcluido();

					Console.WriteLine("#ID {0}: - {1} {2}", objeto.retornaId(), objeto.retornaTitulo(), ((bool)excluido ? "*Excluído*" : ""));
				}
			}
			
			else if (repositorio.GetType().Equals(typeof(FilmeRepositorio)))
			{
				var lista = repositorio.Lista() as List<Filme>;
				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma conteudo cadastrado.");
					return;
				}

				foreach (var objeto in lista)
				{
					var excluido = objeto.retornaExcluido();

					Console.WriteLine("#ID {0}: - {1} {2}", objeto.retornaId(), objeto.retornaTitulo(), ((bool)excluido ? "*Excluído*" : ""));
				}
			}

		}

		private static void InserirObjeto<T>(IRepositorio<T> repositorio) where T : EntidadeBase
		{

			Console.WriteLine("Inserir novo conteudo");
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());


			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();



			if (repositorio.GetType().Equals(typeof(SerieRepositorio))) {
				Console.Write("Digite a quantidade de episódio: ");
				int episodios = int.Parse(Console.ReadLine());

				Serie novoobjeto = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										episodios: episodios);
                (repositorio as SerieRepositorio).Insere(novoobjeto);
			}
			if (repositorio.GetType().Equals(typeof(FilmeRepositorio))) {
				Filme novoobjeto = new Filme(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
                (repositorio as FilmeRepositorio).Insere(novoobjeto);
			}
		}

		private static string ObterOpcaoUsuario(string type)
		{
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine("|  Pensou em {0} pensou em RTCVFLix!!!   |", type);
			Console.WriteLine("|  O que voce quer fazer hoje?             |");

			Console.WriteLine("|  1- Listar {0}                         |", type);
			Console.WriteLine("|  2- Inserir nova {0}                   |", type);
			Console.WriteLine("|  3- Atualizar {0}                      |", type);
			Console.WriteLine("|  4- Excluir {0}                        |", type);
			Console.WriteLine("|  5- Visualizar {0}                     |", type);
			Console.WriteLine("|  C- Limpar Tela                          |");
			Console.WriteLine("|  X- Sair                                 |");
			Console.WriteLine("--------------------------------------------");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		private static string ObterOpcaoObjeto()
		{
			Console.WriteLine("-------------------------------------------------------");
			Console.WriteLine("|  Pensou em entretenimento pensou em RTCVFLix!!!     |");
			Console.WriteLine("|  O que voce quer fazer hoje?                        |");
			Console.WriteLine("|  1- Configurar séries                               |");
			Console.WriteLine("|  2- Configurar filmes		                      |");
			Console.WriteLine("|  C- Limpar Tela                                     |");
			Console.WriteLine("|  X- Sair                                            |");
			Console.WriteLine("-------------------------------------------------------");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
