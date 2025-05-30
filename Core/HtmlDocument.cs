using System.Runtime.InteropServices;
using HyperSharp.Elements;
using HyperSharp.Utils;

namespace HypertextSharp.Core;

public class HtmlDocument
{
    private HtmlBuilder builder = new HtmlBuilder();
    private HtmlCompiler compiler = new HtmlCompiler();
    private IndentationHelper indentation = new IndentationHelper();
    private HtmlElement? root;
    
    private readonly Stack<HtmlElement> elementStack = new Stack<HtmlElement>();
    
    #region Html Elements
    
    /// <summary>
    /// Declares HTML5, should be the very first line.
    /// </summary>
    public void Doctype() => builder.Append("<!DOCTYPE html>\n");

    /// <summary>
    /// Root element of an HTML document.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Html(Action innerContent)
    {
        var html = new HtmlElement("html");
        if (root == null) root = html;

        elementStack.Push(html);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Contains metadata and resources needed by the browser but not directly displayed.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Head(Action innerContent)
    {
        var head = new HtmlElement("head");
        elementStack.Peek().AddChild(head);

        elementStack.Push(head);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Contains the visible content of the webpage.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Body(Action innerContent)
    {
        var body = new HtmlElement("body");
        elementStack.Peek().AddChild(body);
        
        elementStack.Push(body);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Div(Action innerContent)
    {
        var div = new HtmlElement("div");
        elementStack.Peek().AddChild(div);
        
        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Div(Dictionary<string, string> attributes ,Action innerContent)
    {
        var div = new HtmlElement("div");
        foreach(var attr in attributes)
            div.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(div);
        
        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Div(Action innerContent, Dictionary<string, string> attributes)
    {
        var div = new HtmlElement("div");
        foreach (var attr in attributes)
            div.SetAttribute(attr.Key, attr.Value);

        elementStack.Peek().AddChild(div);

        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Span(string innerContent)
    {
        var span = new HtmlElement("span") { InnerText = innerContent };
        elementStack.Peek().AddChild(span);
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    public void Span(Action innerContent)
    {
        var span  = new HtmlElement("span");
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Span(Dictionary<string, string> attributes ,Action innerContent)
    {
        var span = new HtmlElement("span");
        foreach(var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Span(Dictionary<string, string> attributes ,string innerContent)
    {
        var span = new HtmlElement("span") { InnerText = innerContent };
        foreach(var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(span);
    }
    
    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Span(Action innerContent, Dictionary<string, string> attributes)
    {
        var span = new HtmlElement("span");
        foreach (var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);

        elementStack.Peek().AddChild(span);

        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Span(string innerContent, Dictionary<string, string> attributes)
    {
        var span = new HtmlElement("span") { InnerText = innerContent };
        foreach(var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(span);
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
    public void Compile()
    {
        builder.Clear(); // Clear previous content
        builder.Append("<!DOCTYPE html>\n");  // Add doctype at top

        if (root != null)
        {
            builder.Append(root.Build(indentation));
        }
        
        // Write built HTML content to file with HtmlCompiler
        compiler.Compile(builder.ToString());
    }
    
    /// <summary>
    /// Used to specify a unique id for an HTML element.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public AttributeBuilder Id(string id) => new AttributeBuilder().Id(id);
    
    /// <summary>
    /// Assigns CSS classes to an element for styling or scripting.
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public AttributeBuilder Class(string className) => new AttributeBuilder().Class(className);
    
    /// <summary>
    /// Adds inline CSS styles directly to an element.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    public AttributeBuilder Style(string style) => new AttributeBuilder().Style(style);
    
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