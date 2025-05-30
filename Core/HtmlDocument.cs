using HyperSharp.Utils;

namespace HypertextSharp.Core;

public class HtmlDocument
{
    private HtmlBuilder builder = new HtmlBuilder();
    private HtmlCompiler compiler = new HtmlCompiler();
    private IndentationHelper indentation = new IndentationHelper();
    
    #region Html Elements
    
    /// <summary>
    /// Declares HTML5, should be the very first line.
    /// </summary>
    public void DOCTYPE() => builder.Append("<!DOCTYPE html>\n");

    /// <summary>
    /// Root element of an HTML document.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Html(Action innerContent)
    {
        builder.Append($"{indentation.Indent()}<html>\n");
        indentation.indentLevel++;
        innerContent();
        indentation.indentLevel--;
        builder.Append($"{indentation.Indent()}</html>\n");
    }
    
    /// <summary>
    /// Contains metadata and resources needed by the browser but not directly displayed.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Head(Action innerContent)
    {
        builder.Append($"{indentation.Indent()}<head>\n");
        indentation.indentLevel++;
        innerContent();
        indentation.indentLevel--;
        builder.Append($"{indentation.Indent()}</head>\n");
    }

    /// <summary>
    /// Contains the visible content of the webpage.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Body(Action innerContent)
    {
        builder.Append($"{indentation.Indent()}<body>\n");
        indentation.indentLevel++;
        innerContent();
        indentation.indentLevel--;
        builder.Append($"{indentation.Indent()}</body>\n");
    }
    
    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Div(Action innerContent)
    {
        builder.Append($"{indentation.Indent()}<div>\n");
        indentation.indentLevel++;
        innerContent();
        indentation.indentLevel--;
        builder.Append($"{indentation.Indent()}</div>\n");
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Span(string innerContent)
    {
        builder.Append($"{indentation.Indent()}<span>{innerContent}</span>\n");;
    }

    /// <summary>
    /// Generic inline container element for phrasing content with nested elements.
    /// </summary>
    public void Span(Action innerContent)
    {
        builder.Append($"{indentation.Indent()}<span>\n");
        indentation.indentLevel++;
        innerContent();
        indentation. indentLevel--;
        builder.Append($"{indentation.Indent()}</span>\n");
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
    
    /// <summary>
    /// Sets file name.
    /// </summary>
    /// <param name="fileName"></param>
    public void SetFileName(string fileName) => compiler.OutputFileName = fileName;
    
}