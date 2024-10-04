namespace ConverterArquivos;

class Program
{
    static void Main(string[] args)
    {
        ConvertFile();
    }

    static void ConvertFile()
    {
        Console.Clear();

        string fileName = GetFileName("Digite o nome do arquivo: ");
        string fileExtension = GetFileExtension("Digite a extensão do arquivo (ex: jpg, png, gif, js, html): ");
        string filePath = Path.Combine(".", "Arquivos", fileName + fileExtension);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Arquivo não encontrado!");
            return;
        }

        Console.Clear();

        var newFileExtension = GetFileExtension("Deseja converter para qual extensão? (ex: jpg, png, gif, js, html): ");
        string newFilePath = Path.Combine(".", "Arquivos", fileName + newFileExtension);

        if (File.Exists(newFilePath))
        {
            Console.WriteLine("Erro: Esse arquivo já existe!");
            return;
        }

        TryConvertFile(filePath, newFilePath);
    }

    static string GetFileName(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    static string GetFileExtension(string message)
    {
        Console.Write(message);
        string extension = Console.ReadLine().ToLower();
        return extension.StartsWith(".") ? extension : "." + extension;
    }

    static void TryConvertFile(string sourceFile, string newFile)
    {
        try
        {
            File.Move(sourceFile, newFile);
            Console.Clear();
            Console.WriteLine($"Arquivo convertido com sucesso: {newFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao converter: {ex.Message}");
        }
    }
}
