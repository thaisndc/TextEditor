using System.Data;

Menu();

void Menu()
{
    Console.Clear();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1 - Open File");
    Console.WriteLine("2 - Create File");
    Console.WriteLine("0 - Exit");

    short option = short.Parse(Console.ReadLine()); // Lê a opção do usuário

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: OpenFile(); break;
        case 2: EditFile(); break;
        default: Menu(); break;
    }

    // Função para abrir e ler um arquivo   
    void OpenFile()
    {
        Console.Clear();
        Console.WriteLine("What is the file path?");
        string path = Console.ReadLine();

        // Abre o arquivo para leitura e exibe o conteúdo
        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text); // Exibe o conteúdo do arquivo
        }

        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }

    // Função para editar/criar um arquivo
    void EditFile()
    {
        Console.Clear();
        Console.WriteLine("Type your text below (ESC to exit)");
        Console.WriteLine("------------------------");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        } 
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        SaveFile(text);
    }

     // Função para salvar o texto em um arquivo
    void SaveFile(string text)
    {
        Console.Clear();
        Console.WriteLine("Where do you want to save the file?");
        var path = Console.ReadLine();

        using (var file = new StreamWriter(path)) 
        {
            file.Write(text);
        }
        
        Console.WriteLine($"File {path} saved successfully!");
        Console.ReadLine();
        Menu();
    }
}