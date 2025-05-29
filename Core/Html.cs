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
    
    /// <summary>
    /// Declares HTML5, should be the very first line.
    /// </summary>
    public void DOCTYPE() => builder.Append("<!DOCTYPE html>\n");
    
    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Div(Action innerContent)
    {
        builder.Append($"{Indent()}<div>\n");
        indentLevel++;
        innerContent();
        indentLevel--;
        builder.Append($"{Indent()}</div>\n");
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Span(string innerContent)
    {
        builder.Append($"{Indent()}<span>{innerContent}</span>\n");;
    }

    /// <summary>
    /// Generic inline container element for phrasing content with nested elements.
    /// </summary>
    public void Span(Action innerContent)
    {
        builder.Append($"{Indent()}<span>\n");
        indentLevel++;
        innerContent();
        indentLevel--;
        builder.Append($"{Indent()}</span>\n");
    }
    
    #endregion
    /// <summary>
    /// Builds document to a string.
    /// </summary>
    /// <returns></returns>
    public string GetHtml() => builder.ToString();
    
    /// <summary>
    /// Compiles document to an html file.
    /// </summary>
    /// <param name="output"></param>
    public void Compile(string output) => compiler.Compile(output);
    
    /// <summary>
    /// Sets file output path.
    /// </summary>
    /// <param name="path"></param>

    public void SetOutputPath(string path) => compiler.OutputPath = path;
    
}