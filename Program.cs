using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
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
                    
                    case "6":
                        ListarSeriesPorNome();
                        break;

                    case "7":
                        ListarSeriesPorCanon();
                        break;

					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da obra: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da obra: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da obra: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo da obra entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da obra: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a Descrição da obra: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("A obra se passa antes da Batalha de Yavin? S ou N ");
			string aby = Console.ReadLine();
            string entradaPeriodo = "";

            if (aby == "S")
            {
                entradaPeriodo = "BBY";
            }
            else
            {
                entradaPeriodo = "ABY";
            }

            Console.Write("Digite o Ano em que se passa a obra: ");
			int entradaAnoCanon = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Fase)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Fase), i));
			}
			Console.Write("Digite a fase na qual a obra se passa entre as opções acima: ");
			int entradaFase = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Audiencia)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Audiencia), i));
			}
			Console.Write("Digite a audiência recomendada da obra entre as opções acima: ");
			int entradaAudiencia = int.Parse(Console.ReadLine());

            Console.Write("Digite o Ano de lançamento da obra: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Serie atualizaSerie = new Serie(id: indiceSerie,
										tipo: (Tipo)entradaTipo,
										titulo: entradaTitulo,
										descricao: entradaDescricao,
                                        anoCanon: entradaAnoCanon,
                                        periodo: entradaPeriodo,
                                        fase: (Fase)entradaFase,
                                        audiencia: (Audiencia)entradaAudiencia,
                                        ano: entradaAno);


			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries por ID");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void ListarSeriesPorNome()
		{
			Console.WriteLine("Listar séries por nome");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

            lista.Sort((x, y) => x.retornaTitulo().CompareTo(y.retornaTitulo()));

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void ListarSeriesPorCanon()
		{
			Console.WriteLine("Listar séries por ordem no Cânone");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

            lista.Sort((x, y) => x.retornaAnoCanon().CompareTo(y.retornaAnoCanon()));

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo da obra entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da obra: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a Descrição da obra: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("A obra se passa antes da Batalha de Yavin? S ou N ");
			string aby = Console.ReadLine();
            string entradaPeriodo = "";

            if (aby == "S")
            {
                entradaPeriodo = "BBY";
            }
            else
            {
                entradaPeriodo = "ABY";
            }

            Console.Write("Digite o Ano em que se passa a obra: ");
			int entradaAnoCanon = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Fase)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Fase), i));
			}
			Console.Write("Digite a fase na qual a obra se passa entre as opções acima: ");
			int entradaFase = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Audiencia)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Audiencia), i));
			}
			Console.Write("Digite a audiência recomendada da obra entre as opções acima: ");
			int entradaAudiencia = int.Parse(Console.ReadLine());

            Console.Write("Digite o Ano de lançamento da obra: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										tipo: (Tipo)entradaTipo,
										titulo: entradaTitulo,
										descricao: entradaDescricao,
                                        periodo: entradaPeriodo,
                                        anoCanon: entradaAnoCanon,
                                        fase: (Fase)entradaFase,
                                        audiencia: (Audiencia)entradaAudiencia,
                                        ano: entradaAno);;

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Cadastro de Obras no canone de Star Wars");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar obras");
			Console.WriteLine("2- Inserir nova obra");
			Console.WriteLine("3- Atualizar obra");
			Console.WriteLine("4- Excluir obra");
			Console.WriteLine("5- Visualizar obra");
            Console.WriteLine("6- Listar obras por título");
            Console.WriteLine("7- Listar obras por acontecimento");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
