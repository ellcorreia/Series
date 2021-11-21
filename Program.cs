using System;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string UserOption = GetUserOption();

			while (UserOption.ToUpper() != "X")
			{
				switch (UserOption)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						AddSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
                        DeleteSerie();
						break;
					case "5":
                        ViewSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				UserOption = GetUserOption();
			}

			Console.WriteLine("Thank you for using our services.");
			Console.ReadLine();
        }

        private static void DeleteSerie()
		{
			Console.Write("Enter the serie id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repository.Delete(indiceSerie);
		}

        private static void ViewSerie()
		{
			Console.Write("Enter the serie id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repository.ReturnById(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void UpdateSerie()
		{
			Console.Write("Enter the serie id: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Enter gender among the above options: ");
			int InGenre = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Title: ");
			string InTitle = Console.ReadLine();

			Console.Write("Enter the Series Start Year: ");
			int InYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Description: ");
			string InDescription = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										Genre: (Genre)InGenre,
										Title: InTitle,
										Year: InYear,
										Description: InDescription);

			repository.Add(indiceSerie, atualizaSerie);
		}
        private static void ListSeries()
		{
			Console.WriteLine("List series");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("No registered series.");
				return;
			}

			foreach (var serie in list)
			{
                var Deleted = serie.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (Deleted ? "*Deleted*" : ""));
			}
		}

        private static void AddSerie()
		{
			Console.WriteLine("Insert new series");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Type gender among the above options: ");
			int InGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string InTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int InYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string InDescription = Console.ReadLine();

			Serie novaSerie = new Serie(id: repository.NextId(),
										Genre: (Genre)InGenre,
										Title: InTitle,
										Year: InYear,
										Description: InDescription);

			repository.Update(novaSerie);
		}

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("ELL Series at your disposal!!!");
			Console.WriteLine("Enter the desired option:");

			Console.WriteLine("1- List series");
			Console.WriteLine("2- Insert new series");
			Console.WriteLine("3- Upgrade series");
			Console.WriteLine("4- Delete series");
			Console.WriteLine("5- Series view");
			Console.WriteLine("C- Clear Screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string UserOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return UserOption;
		}
    }
}