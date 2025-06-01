using HyperSharp.Elements;
using HyperSharp.Elements.Elements;
using HyperSharp.Utils;

namespace HyperSharp.Core;

public class HtmlDocument
{
    private HtmlBuilder builder = new HtmlBuilder();
    private HtmlCompiler compiler = new HtmlCompiler();
    private IndentationHelper indentation = new IndentationHelper();
    internal HtmlRoot root;
    
    internal readonly Stack<HtmlElement> ElementStack = new Stack<HtmlElement>();
    
    // Elements
    private readonly HtmlDiv divHelper;
    private readonly HtmlSpan spanHelper;
    private readonly HtmlHead htmlHead;
    private readonly HtmlBody htmlBody;
    private readonly HtmlLink htmlLink;

    public HtmlDocument()
    {
        // Pass all elements to the document
        divHelper = new HtmlDiv(ElementStack);
        spanHelper = new HtmlSpan(ElementStack);
        root = new HtmlRoot(ElementStack);
        htmlHead = new HtmlHead(ElementStack);
        htmlBody = new HtmlBody(ElementStack);
        htmlLink = new HtmlLink(ElementStack);
    }
    
    /// <summary>
    /// Declares HTML5, should be the very first line.
    /// </summary>
    public void Doctype() => builder.Append("<!DOCTYPE html>\n");
    
    #region Forwarded element calls
    #region Div

    /// <inheritdoc cref="HtmlDiv.Div(Action)"/>
    public void Div(Action innerContent)
    {
        EnsureRoot();
        divHelper.Div(innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(Dictionary{string, string} ,Action)"/>
    public void Div(Dictionary<string, string> attributes, Action innerContent)
    {
        EnsureRoot();
        divHelper.Div(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(Action, Dictionary{string, string})"/>
    public void Div(Action innerContent, Dictionary<string, string> attributes)
    {
        EnsureRoot();
        divHelper.Div(innerContent, attributes); 
    }
    
    #endregion
    #region Span

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Span(string innerContent)
    {
        EnsureRoot();
        spanHelper.Span(innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action)"/>
    public void Span(Action innerConent)
    {
        EnsureRoot();
        spanHelper.Span(innerConent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(string, Dictionary{string, string})"/>
    public void Span(string innerContent, Dictionary<string, string> attributes)
    {
        EnsureRoot();
        spanHelper.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action, Dictionary{string, string})"/>
    public void Span(Action innerContent, Dictionary<string, string> attributes)
    {
        EnsureRoot();
        spanHelper.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Dictionary{string, string}, string)"/>
    public void Span(Dictionary<string, string> attributes, string innerContent)
    {
        EnsureRoot();
        spanHelper.Span(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Dictionary{string, string}, Action)"/>
    public void Span(Dictionary<string, string> attributes, Action innerContent)
    {
        EnsureRoot();
        spanHelper.Span(attributes, innerContent);
    }
    
    #endregion
    #region Html
    
    /// <inheritdoc cref="HtmlRoot.Html(Action)"/>
    public void Html(Action innerContent) => root?.Html(innerContent);
    
    #endregion
    #region Head

    /// <inheritdoc cref="HtmlHead.Head(Action)"/>
    public void Head(Action innerContent)
    {
        EnsureRoot();
        htmlHead.Head(innerContent);
    }
    
    #endregion
    #region Body

    /// <inheritdoc cref="HtmlBody.Body(Action)"/>
    public void Body(Action innerContent)
    {
        EnsureRoot();
        htmlBody.Body(innerContent);
    }
    
    #endregion
    #region Link
    
    public void Link(string rel, string href)
    {
        EnsureRoot();
        htmlLink.Link(rel, href);
    }
    
    #endregion
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

        if (root == null || root.Children.Count <= 0 || ElementStack.Count == 0)
        {
            Console.WriteLine("Warning: Html() was not called.");
            Console.WriteLine("Automatically wrapping content.");
            root.Html(() => {});
        }
        
        builder.Append(root.Build(indentation));
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
    
    /// <summary>
    /// User's CSS file path.
    /// </summary>
    /// <param name="path"></param>
    public void SetUserCssPath(string path) => compiler.UserCssPath = path;

    /// <summary>
    /// Automatically wraps content in Html tag if it's not present.
    /// </summary>
    private void EnsureRoot()
    {
        if (root.Children.Count == 0 && ElementStack.Count == 0)
        {
            Console.WriteLine("Html() was not called.");
            Console.WriteLine("Automatically wrapping content.");
            root.Html(() => {});
            ElementStack.Push(root);
        }
    }
}