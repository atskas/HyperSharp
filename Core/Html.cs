namespace HypertextSharp.Core;

public class Html
{
    private HtmlBuilder builder = new HtmlBuilder();
    private HtmlCompiler compiler = new HtmlCompiler();
    
    // Helper method for indentation
    // helps keep HTML clean
    private int indentLevel = 0;
    private string Indent() => new string(' ', indentLevel * 2);
    
    #region Html Elements
    
    public string DOCTYPE() => "<!DOCTYPE html>\n";
    
    public void Div(Action innerContent)
    {
        builder.Append($"{Indent()}<div>\n");
        indentLevel++;
        innerContent();
        indentLevel--;
        builder.Append("</div>\n");
    }

    public void Span(string innerContent)
    {
        builder.Append($"{Indent()}<span>{innerContent}</span>\n");;
    }
    
    #endregion
    public string GetHtml() => builder.ToString();
    public void Compile(string output) => compiler.Compile(output);

    public void SetOutputPath(string path) => compiler.OutputPath = path;
    
}