using Abstraction.Entities;

Console.Write("Informe o número de contribuintes: ");
int n = int.Parse(Console.ReadLine());

List<TaxPayer> list = new();

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Dados da {i + 1}a pessoa:");
    Console.Write("Pessoa física ou jurídica (f/j)? ");
    char ans = char.Parse(Console.ReadLine());

    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Renda anual: ");
    double anualIncome = double.Parse(Console.ReadLine());

    if (ans == 'f')
    {
        Console.Write("Despesas médias: ");
        double healthExpenditures = double.Parse(Console.ReadLine());

        list.Add(new Individual(name, anualIncome, healthExpenditures));
    }
    else if (ans == 'j')
    {
        Console.Write("Número de funcionários: ");
        int numberOfEmployees = int.Parse(Console.ReadLine());

        list.Add(new Company(name, anualIncome, numberOfEmployees));
    }
    else
    {
        Console.WriteLine("Erro. Opção inválida.");
    }
}

Console.WriteLine("Taxas pagas:");
foreach (TaxPayer taxPayer in list)
{
    Console.WriteLine($"{taxPayer.Name}: R${taxPayer.Tax():F2}");
}

double sum = 0;
foreach (TaxPayer taxPayer in list)
{
    sum += taxPayer.Tax();
}

Console.WriteLine($"Total arrecadado: R${sum}");
