using System.Threading.Channels;
using System.Security.AccessControl;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Journal
{

    internal class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "journal.json";
            if (!File.Exists(fileName))
                File.Create(fileName);
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),
                WriteIndented = true
            };
            var entries = new LinkedList<JournalEntry>();
            entries = JsonSerializer.Deserialize<LinkedList<JournalEntry>>(File.ReadAllText(fileName), options);
            bool continueLoop = true;
            var json = "";
            LinkedListNode<JournalEntry>? printedEntry = null;
            while (continueLoop)
            {
                JournalIntroduction(entries);
                if (entries != null)
                {
                    if (printedEntry == null)
                        printedEntry = entries.Last;
                    PrintEntry(printedEntry);
                }
                string input = Console.ReadLine();
                switch (input)
                {
                    case "novy":
                        entries.AddLast(TakeEntry());
                        printedEntry = entries.Last;
                        Console.Clear();
                        break;
                    case "uloz":
                        Console.WriteLine("Příkaz uloz jde použít pouze v režimu ukládání nového záznamu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "dalsi":
                        if (printedEntry == null || printedEntry.Next == null)
                        {
                            Console.WriteLine("Další záznam neexistuje");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        printedEntry = printedEntry.Next;
                        Console.Clear();
                        break;
                    case "predchozi":
                        if (printedEntry == null || printedEntry.Previous == null)
                        {
                            Console.WriteLine("Předchozí záznam neexistuje");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        printedEntry = printedEntry.Previous;
                        Console.Clear();
                        break;
                    case "smaz":
                        if (printedEntry == null)
                        {
                            Console.WriteLine("Neexistuje záznam ke smazání");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                        if (printedEntry.Previous == null)
                        {
                            entries.Remove(printedEntry);
                            Console.WriteLine("Záznam smazán");
                            printedEntry = null;
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        printedEntry = printedEntry.Previous;
                        entries.Remove(printedEntry.Next);
                        Console.WriteLine("Záznam smazán");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "zavri":
                        json = JsonSerializer.Serialize(entries, options);
                        File.WriteAllText(fileName, json);
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Toto není platný vstup, zadejte prosím nový");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
        static void JournalIntroduction(LinkedList<JournalEntry> entries)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(
                "Deník se ovládá následujícími příkazy:\npredchozi - ukáže předchodzí záznam\ndalsi - ukáže další záznam\nnovy - vytvoří nový záznam\nuloz - uloží nový záznam\nsmaz - smaže aktuální záznam\nzavri - zavře deník");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Pocet zaznamu: {entries.Count}");
        }
        static JournalEntry TakeEntry()
        {
            JournalEntry entry = new();
            DateOnly date;
            do
            {
                Console.WriteLine("Datum:");
            } while (!DateOnly.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", out date));
            entry.Date = date.ToString();

            Console.WriteLine("Text:");
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "uloz")
                    break;
                input += "\n";
                entry.Entry += input;
            }
            return entry;
        }
        static void PrintEntry(LinkedListNode<JournalEntry> entryNode)
        {
            if (entryNode == null)
                return;
            JournalEntry entry = entryNode.Value;
            Console.WriteLine($"Datum: {entry.Date}\n\n{entry.Entry}");
            Console.WriteLine("----------------------------------");
        }
    }
    public class JournalEntry
    {
        public string Date { get; set; }
        public string Entry { get; set; }
    }
}
