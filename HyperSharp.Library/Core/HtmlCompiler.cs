namespace HyperSharp.Core;

internal class HtmlCompiler
{
    public string? OutputPath { get; set; } = null;
    public string? OutputFileName { get; set; } = null;
    public string? UserCssPath { get; set; } = null;
    
    public void Compile(string html)
    {
        // Determine output folders
        string outputParentPath = OutputPath ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
        string outputDir = Path.Combine(outputParentPath, "HyperSharp_Output");
        string cssOutputDir = Path.Combine(outputDir, "CSS");
        
        Directory.CreateDirectory(outputDir); 
        Directory.CreateDirectory(cssOutputDir);
        
        string outputHtmlPath = Path.Combine(outputDir, OutputFileName ?? "output.html");

        // Copy CSS files if UserCssPath is specified
        if (!string.IsNullOrEmpty(UserCssPath) && Directory.Exists(UserCssPath)) 
        { 
            foreach (var cssFilePath in Directory.GetFiles(UserCssPath, "*.css")) 
            { 
                string fileName = Path.GetFileName(cssFilePath); 
                string destPath = Path.Combine(cssOutputDir, fileName);
                
                foreach(var file in Directory.GetFiles(UserCssPath, "*.css"))
                    Console.WriteLine("Found CSS file: " + file);
                File.Copy(cssFilePath, destPath, overwrite: true); 
                Console.WriteLine($"Copied CSS file: {fileName} to {destPath}");
            }
        }
        else if (!string.IsNullOrEmpty(UserCssPath) && File.Exists(UserCssPath) && UserCssPath.EndsWith(".css", StringComparison.OrdinalIgnoreCase)) 
        { 
            // If UserCssPath points directly to a CSS file, copy it directly
            string fileName = Path.GetFileName(UserCssPath);
            string destPath = Path.Combine(cssOutputDir, fileName);
            File.Copy(UserCssPath, destPath, overwrite: true);
            Console.WriteLine($"Copied CSS file: {fileName} to {destPath}");
        }

        // Write the HTML output
        File.WriteAllText(outputHtmlPath, html);
        
        Console.WriteLine($"HTML output written to: {outputHtmlPath}");
    }
}