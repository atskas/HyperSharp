using System.Runtime.CompilerServices;
using HyperSharp.Elements.Base;
using HyperSharp.Elements.Base.Elements;
using HyperSharp.Utils;

namespace HyperSharp.Core;

public class HtmlDocument
{
    private HtmlBuilder builder = new();
    private HtmlCompiler compiler = new();
    private IndentationHelper indentation = new();
    private ElementInit Elements = new();

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
        Elements.htmlDiv.Div(innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(AttributeBuilder attributes ,Action)"/>
    public void Div(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        Elements.htmlDiv.Div(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(Action, AttributeBuilder attributes)"/>
    public void Div(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlDiv.Div(innerContent, attributes);
    }

    #endregion

    #region Span

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Span(string innerContent)
    {
        EnsureRoot();
        Elements.htmlSpan.Span(innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action)"/>
    public void Span(Action innerConent)
    {
        EnsureRoot();
        Elements.htmlSpan.Span(innerConent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(string, AttributeBuilder attributes)"/>
    public void Span(string innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action, AttributeBuilder attributes)"/>
    public void Span(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(AttributeBuilder attributes, string)"/>
    public void Span(AttributeBuilder attributes, string innerContent)
    {
        EnsureRoot();
        Elements.htmlSpan.Span(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(AttributeBuilder attributes, Action)"/>
    public void Span(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        Elements.htmlSpan.Span(attributes, innerContent);
    }

    #endregion

    #region Html

    /// <inheritdoc cref="HtmlRoot.Html(Action)"/>
    public void Html(Action innerContent) => Elements.root.Html(innerContent);

    /// <inheritdoc cref="HtmlRoot.Html(AttributeBuilder attributes, Action)"/>
    public void Html(AttributeBuilder attributes, Action innerContent) => Elements.root.Html(attributes, innerContent);

    #endregion

    #region Head

    /// <inheritdoc cref="HtmlHead.Head(Action)"/>
    public void Head(Action innerContent)
    {
        EnsureRoot();
        Elements.htmlHead.Head(innerContent);
    }

    #endregion

    #region Body

    /// <inheritdoc cref="HtmlBody.Body(Action)"/>
    public void Body(Action innerContent)
    {
        EnsureRoot();
        Elements.htmlBody.Body(innerContent);
    }

    #endregion

    #region Link

    /// <inheritdoc cref="HtmlLink.Link(string, string)"/>
    public void Link(string rel, string href)
    {
        EnsureRoot();
        Elements.htmlLink.Link(rel, href);
    }

    #endregion

    #region Button

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Button(string innerContent)
    {
        EnsureRoot();
        Elements.htmlButton.Button(innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action)"/>
    public void Button(Action innerConent)
    {
        EnsureRoot();
        Elements.htmlButton.Button(innerConent);
    }

    /// <inheritdoc cref="HtmlButton.Button(string, AttributeBuilder attributes)"/>
    public void Button(string innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action, AttributeBuilder attributes)"/>
    public void Button(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(AttributeBuilder attributes, string)"/>
    public void Button(AttributeBuilder attributes, string innerContent)
    {
        EnsureRoot();
        Elements.htmlButton.Button(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(AttributeBuilder attributes, Action)"/>
    public void Button(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        Elements.htmlButton.Button(attributes, innerContent);
    }

    #endregion

    #region Title

    /// <inheritdoc cref="HtmlTitle.Title(string)"/>
    public void Title(string title)
    {
        EnsureRoot();
        Elements.htmlTitle.Title(title);
    }

    #endregion

    #region Meta

    /// <inheritdoc cref="HtmlMeta.Meta(AttributeBuilder attributes)"/>
    public void Meta(AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlMeta.Meta(attributes);
    }

    #endregion

    #region IFrame


    /// <inheritdoc cref="HtmlIFrame.IFrame(AttributeBuilder attributes)"/>
    public void IFrame(AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlIFrame.IFrame(attributes);
    }

    #endregion

    #region Video

    /// <inheritdoc cref="HtmlVideo.Video(AttributeBuilder attributes)"/>
    public void Video(AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlVideo.Video(attributes);
    }

    /// <inheritdoc cref="HtmlVideo.Video(Action innerContent, AttributeBuilder attributes)"/>
    public void Video(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        Elements.htmlVideo.Video(innerContent, attributes);
    }
    
    /// <inheritdoc cref="HtmlVideo.Video(AttributeBuilder attributes, Action innerContent)"/>
    public void Video(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        Elements.htmlVideo.Video(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlVideo.Video(Action innerContent)"/>
    public void Video(Action innerContent)
    {
        EnsureRoot();
        Elements.htmlVideo.Video(innerContent);
    }

    #endregion
    #region Source

    public void Source(AttributeBuilder source)
    {
        EnsureRoot();
        Elements.htmlSource.Source(source);
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

    public AttributeBuilder Src(string src) => new AttributeBuilder().Src(src);

    public AttributeBuilder Width(string width) => new AttributeBuilder().Width(width);

    public AttributeBuilder Height(string height) => new AttributeBuilder().Height(height);

    /// <summary>
    /// Custom attribute setter.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public AttributeBuilder Set(string key, string value) => new AttributeBuilder().Set(key, value);
    public AttributeBuilder Set(string key) => new AttributeBuilder().Set(key);
    
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
        
        builder.Append(Elements.root.Build(indentation));
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
        if (Elements.root == null || Elements.ElementStack.Count == 0)
        {
            Console.WriteLine("Warning: Html() was not called.");
            Console.WriteLine("Automatically wrapping content.");
            Elements.root.Html(() => {});
            Elements.ElementStack.Push(Elements.root);
        }
    }
    
    #endregion
}