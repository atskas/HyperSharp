using System;
using System.IO;
namespace HypertextSharp.Core;

internal class HtmlCompiler
{
    public string? OutputPath { get; set; } = null;
    
    public void Compile(string html)
    {
        // Get the user's documents folder
        string outputParentPath = OutputPath ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Subfolder inside of documents for output
        string outputDir = Path.Combine(outputParentPath, "HypertextSharp_Output");

        // Ensure the directory exists
        Directory.CreateDirectory(outputDir);

        string outputPath = Path.Combine(outputDir, "output.html");

        Console.WriteLine($"Writing output to: {outputPath}");

        File.WriteAllText(outputPath, html);
    }

}