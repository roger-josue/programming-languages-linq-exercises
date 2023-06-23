using programming_languages_linq_exercises;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

        var stringifiedLanguages = languages.Select(lang => $"{lang.Year}, {lang.Name}, {lang.ChiefDeveloper}, {lang.Predecessors}");

        PrettyPrintAll(languages);

        var cSharpMatches = languages.Where(lang => lang.Name.Contains("C#") || lang.Predecessors.Contains("C#"));
        Console.WriteLine($"\nMentions C#: ({cSharpMatches.Count()})\n");
        PrettyPrintAll(cSharpMatches);

        var developedByMicrosoft = languages.Where(lang => lang.ChiefDeveloper.Contains("Microsoft"));
        Console.WriteLine($"\nDeveloped by Microsoft: ({developedByMicrosoft.Count()})\n");
        PrettyPrintAll(developedByMicrosoft);

        var lispAsPredecessor = languages.Where(lang => lang.Predecessors.Contains("Lisp"));
        Console.WriteLine($"\nPreceded by Lisp: ({lispAsPredecessor.Count()})\n");
        PrettyPrintAll(lispAsPredecessor);

        Console.WriteLine($"\nTotal languages: {languages.Count}\n");
        var filteredDecade = languages
        .Where(lang => lang.Year >= 1995 && lang.Year <= 2005)
        .Select(lang => $"{lang.Name} was invented in {lang.Year}");
        Console.WriteLine($"\nTotal languages launched between 1995 and 2005: {filteredDecade.Count()}\n");
        PrintAll(filteredDecade);
    }

    static void PrettyPrintAll(IEnumerable<Language> languages)
    {
        foreach (Language lang in languages)
        {
            Console.WriteLine(lang.Prettify());
        }
    }

    static void PrintAll(IEnumerable<Object> sequence)
    {
        foreach (Object lang in sequence)
        {
            Console.WriteLine(lang);
        }
    }
}