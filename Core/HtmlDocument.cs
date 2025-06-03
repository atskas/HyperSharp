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
    
    #region HTML Element Initialization

    private readonly HtmlDiv htmlDiv;
    private readonly HtmlSpan htmlSpan;
    private readonly HtmlHead htmlHead;
    private readonly HtmlBody htmlBody;
    private readonly HtmlLink htmlLink;
    private readonly HtmlButton htmlButton;
    private readonly HtmlTitle htmlTitle;
    private readonly HtmlMeta htmlMeta;

    public HtmlDocument()
    {
        // Pass all elements to the document
        htmlDiv = new HtmlDiv(ElementStack);
        htmlSpan = new HtmlSpan(ElementStack);
        root = new HtmlRoot(ElementStack);
        htmlHead = new HtmlHead(ElementStack);
        htmlBody = new HtmlBody(ElementStack);
        htmlLink = new HtmlLink(ElementStack);
        htmlButton = new HtmlButton(ElementStack);
        htmlTitle = new HtmlTitle(ElementStack);
        htmlMeta = new HtmlMeta(ElementStack);
    }
    
    #endregion
    
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
        htmlDiv.Div(innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(AttributeBuilder attributes ,Action)"/>
    public void Div(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        htmlDiv.Div(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(Action, AttributeBuilder attributes)"/>
    public void Div(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        htmlDiv.Div(innerContent, attributes); 
    }
    
    #endregion
    #region Span

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Span(string innerContent)
    {
        EnsureRoot();
        htmlSpan.Span(innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action)"/>
    public void Span(Action innerConent)
    {
        EnsureRoot();
        htmlSpan.Span(innerConent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(string, AttributeBuilder attributes)"/>
    public void Span(string innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        htmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action, AttributeBuilder attributes)"/>
    public void Span(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        htmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(AttributeBuilder attributes, string)"/>
    public void Span(AttributeBuilder attributes, string innerContent)
    {
        EnsureRoot();
        htmlSpan.Span(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(AttributeBuilder attributes, Action)"/>
    public void Span(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        htmlSpan.Span(attributes, innerContent);
    }
    
    #endregion
    #region Html

    /// <inheritdoc cref="HtmlRoot.Html(Action)"/>
    public void Html(Action innerContent) => root.Html(innerContent);
    
    /// <inheritdoc cref="HtmlRoot.Html(AttributeBuilder attributes, Action)"/>
    public void Html(AttributeBuilder attributes, Action innerContent) => root.Html(attributes, innerContent);
    
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
    
    /// <inheritdoc cref="HtmlLink.Link(string, string)"/>
    public void Link(string rel, string href)
    {
        EnsureRoot();
        htmlLink.Link(rel, href);
    }
    
    #endregion
    #region Button

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Button(string innerContent)
    {
        EnsureRoot();
        htmlButton.Button(innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action)"/>
    public void Button(Action innerConent)
    {
        EnsureRoot();
        htmlButton.Button(innerConent);
    }

    /// <inheritdoc cref="HtmlButton.Button(string, AttributeBuilder attributes)"/>
    public void Button(string innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        htmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action, AttributeBuilder attributes)"/>
    public void Button(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        htmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(AttributeBuilder attributes, string)"/>
    public void Button(AttributeBuilder attributes, string innerContent)
    {
        EnsureRoot();
        htmlButton.Button(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(AttributeBuilder attributes, Action)"/>
    public void Button(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        htmlButton.Button(attributes, innerContent);
    }
    
    #endregion
    #region Title
    
    /// <inheritdoc cref="HtmlTitle.Title(string)"/>
    public void Title(string title)
    {
        EnsureRoot();
        htmlTitle.Title(title);
    }
    
    #endregion
    #region Meta

    /// <inheritdoc cref="HtmlMeta.Meta(AttributeBuilder attributes)"/>
    public void Meta(AttributeBuilder attributes)
    {
        EnsureRoot();
        htmlMeta.Meta(attributes);
    }
    
    #endregion
    #endregion
    
    #region Attributes
    
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
    /// Specifies the primary language of the element's content.
    /// </summary>
    /// <param name="lang"></param>
    /// <returns></returns>
    public AttributeBuilder Lang(string lang) => new AttributeBuilder().Lang(lang);
    
    /// <summary>
    /// Provides a name for the element.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AttributeBuilder Name(string name) => new AttributeBuilder().Name(name);
    
    /// <summary>
    /// Supplies the value for metadata elements. (Only to be used for Meta element)
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public AttributeBuilder Content(string content) => new AttributeBuilder().Content(content);
    
    /// <summary>
    /// Declares the character encoding used in the document. (Only to be used for Meta element)
    /// </summary>
    /// <param name="charset"></param>
    /// <returns></returns>
    public AttributeBuilder Charset(string charset) => new AttributeBuilder().Charset(charset);
    
    /// <summary>
    /// Simulates HTTP response headers. (Only to be used for Meta element)
    /// </summary>
    /// <param name="httpEquiv"></param>
    /// <returns></returns>
    public AttributeBuilder HttpEquiv(string httpEquiv) => new AttributeBuilder().HttpEquiv(httpEquiv);
    
    #endregion
    
    #region Compilation and Configuration
    
    /// <summary>
    /// Builds document to a string.
    /// </summary>
    /// <returns></returns>
    public string GetHtml() => builder.ToString();
    
    /// <summary>
    /// Compiles document to a html file.
    /// </summary>
    public void Compile()
    {
        builder.Clear(); // Clear previous content
        builder.Append("<!DOCTYPE html>\n");  // Add doctype at top
        
        builder.Append(root.Build(indentation));
        // Write built HTML content to file with HtmlCompiler
        compiler.Compile(builder.ToString());
    }
    
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
        if (root == null || ElementStack.Count == 0)
        {
            Console.WriteLine("Warning: Html() was not called.");
            Console.WriteLine("Automatically wrapping content.");
            root.Html(() => {});
            ElementStack.Push(root);
        }
    }
    
    #endregion
}