//Task1
List<string> names = new List<string>()
{
    "Andrew",
    "Jylia",
    "Anastasia",
    "Petya",
    "Anton"
};
string tmp;
for (int i = 0; i < names.Count - 1; i++)
{
    for (int j = i + 1; j < names.Count; j++)
    {
        if (string.Compare(names[i], names[j]) >= 0)
        {
            tmp = names[j];
            names[j] = names[i];
            names[i] = tmp;
        }
    }
}
Console.WriteLine(string.Join(", ", names));

//Task2
Console.Write("ФИО: ");
string? fullname = Console.ReadLine();

Console.Write("Возраст: ");
string? age = Console.ReadLine();

Console.Write("Email: ");
string? email = Console.ReadLine();

Console.Write("Github: ");
string? github = Console.ReadLine();

bool isParsed = int.TryParse(age, out int parsedAge);

if (string.IsNullOrEmpty(fullname))
{
    Console.WriteLine("Введите ФИО корректно");
}
else if (string.IsNullOrEmpty(age) || !isParsed)
{
    Console.WriteLine("Введите возраст корректно.");
}
else if (string.IsNullOrEmpty(email) || !email.Contains("@"))
{
    Console.WriteLine("Введите email корректно.");
}
else if (string.IsNullOrEmpty(github) || !github.Contains("github.com"))
{
    Console.WriteLine("Введите github корректно.");
}
else
{
    Console.WriteLine("Информация о пользователе");
    Console.WriteLine("ФИО:");
    fullname?.Split(' ').ToList().ForEach(val => Console.WriteLine($"  {val}"));
    Console.WriteLine($"Возраст: {parsedAge}");
    Console.WriteLine($"Email: {email}");
    Console.WriteLine($"Github: {github}");
}