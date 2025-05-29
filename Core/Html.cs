namespace HypertextSharp.Core;

public class Html
{
    private HtmlBuilder builder = new HtmlBuilder();
    private HtmlCompiler compiler = new HtmlCompiler();
    
    public void Div(Action innerContent)
    {
        builder.Append("<div>");
        innerContent();
        builder.Append("</div>");
    }

    public void Span(string innerContent)
    {
        builder.Append("<span>");
        builder.Append(innerContent);
        builder.Append("</span>");
    }
    
    public string GetHtml() => builder.ToString();
    public void Compile(string output) => compiler.Compile(output);

    public string OutputPath
    {
        get => compiler.OutputPath;
        set => compiler.OutputPath = value;
    }
}