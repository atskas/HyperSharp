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
    private ElementInit elements = new();

    public AttributeBuilder Attributes
    {
        get { return new AttributeBuilder(); }
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
        elements.htmlDiv.Div(innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(AttributeBuilder attributes ,Action)"/>
    public void Div(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        elements.htmlDiv.Div(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(Action, AttributeBuilder attributes)"/>
    public void Div(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlDiv.Div(innerContent, attributes);
    }

    #endregion

    #region Span

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Span(string innerContent)
    {
        EnsureRoot();
        elements.htmlSpan.Span(innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action)"/>
    public void Span(Action innerConent)
    {
        EnsureRoot();
        elements.htmlSpan.Span(innerConent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(string, AttributeBuilder attributes)"/>
    public void Span(string innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action, AttributeBuilder attributes)"/>
    public void Span(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(AttributeBuilder attributes, string)"/>
    public void Span(AttributeBuilder attributes, string innerContent)
    {
        EnsureRoot();
        elements.htmlSpan.Span(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(AttributeBuilder attributes, Action)"/>
    public void Span(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        elements.htmlSpan.Span(attributes, innerContent);
    }

    #endregion

    #region Html

    /// <inheritdoc cref="HtmlRoot.Html(Action)"/>
    public void Html(Action innerContent) => elements.root.Html(innerContent);

    /// <inheritdoc cref="HtmlRoot.Html(AttributeBuilder attributes, Action)"/>
    public void Html(AttributeBuilder attributes, Action innerContent) => elements.root.Html(attributes, innerContent);

    #endregion

    #region Head

    /// <inheritdoc cref="HtmlHead.Head(Action)"/>
    public void Head(Action innerContent)
    {
        EnsureRoot();
        elements.htmlHead.Head(innerContent);
    }

    #endregion

    #region Body

    /// <inheritdoc cref="HtmlBody.Body(Action)"/>
    public void Body(Action innerContent)
    {
        EnsureRoot();
        elements.htmlBody.Body(innerContent);
    }

    #endregion

    #region Link

    /// <inheritdoc cref="HtmlLink.Link(string, string)"/>
    public void Link(string rel, string href)
    {
        EnsureRoot();
        elements.htmlLink.Link(rel, href);
    }

    #endregion

    #region Button

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Button(string innerContent)
    {
        EnsureRoot();
        elements.htmlButton.Button(innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action)"/>
    public void Button(Action innerConent)
    {
        EnsureRoot();
        elements.htmlButton.Button(innerConent);
    }

    /// <inheritdoc cref="HtmlButton.Button(string, AttributeBuilder attributes)"/>
    public void Button(string innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action, AttributeBuilder attributes)"/>
    public void Button(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(AttributeBuilder attributes, string)"/>
    public void Button(AttributeBuilder attributes, string innerContent)
    {
        EnsureRoot();
        elements.htmlButton.Button(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(AttributeBuilder attributes, Action)"/>
    public void Button(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        elements.htmlButton.Button(attributes, innerContent);
    }

    #endregion

    #region Title

    /// <inheritdoc cref="HtmlTitle.Title(string)"/>
    public void Title(string title)
    {
        EnsureRoot();
        elements.htmlTitle.Title(title);
    }

    #endregion

    #region Meta

    /// <inheritdoc cref="HtmlMeta.Meta(AttributeBuilder attributes)"/>
    public void Meta(AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlMeta.Meta(attributes);
    }

    #endregion

    #region IFrame


    /// <inheritdoc cref="HtmlIFrame.IFrame(AttributeBuilder attributes)"/>
    public void IFrame(AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlIFrame.IFrame(attributes);
    }

    #endregion

    #region Video

    /// <inheritdoc cref="HtmlVideo.Video(AttributeBuilder attributes)"/>
    public void Video(AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlVideo.Video(attributes);
    }

    /// <inheritdoc cref="HtmlVideo.Video(Action innerContent, AttributeBuilder attributes)"/>
    public void Video(Action innerContent, AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.htmlVideo.Video(innerContent, attributes);
    }
    
    /// <inheritdoc cref="HtmlVideo.Video(AttributeBuilder attributes, Action innerContent)"/>
    public void Video(AttributeBuilder attributes, Action innerContent)
    {
        EnsureRoot();
        elements.htmlVideo.Video(attributes, innerContent);
    }

    /// <inheritdoc cref="HtmlVideo.Video(Action innerContent)"/>
    public void Video(Action innerContent)
    {
        EnsureRoot();
        elements.htmlVideo.Video(innerContent);
    }

    #endregion
    
    #region Source

    public void Source(AttributeBuilder source)
    {
        EnsureRoot();
        elements.htmlSource.Source(source);
    } 
    
    #endregion
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
        Doctype();  // Add doctype at top
        
        builder.Append(elements.root.Build(indentation));
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
        if (elements.root == null || elements.ElementStack.Count == 0)
        {
            Console.WriteLine("Warning: Html() was not called.");
            Console.WriteLine("Automatically wrapping content.");
            elements.root.Html(() => {});
            elements.ElementStack.Push(elements.root);
        }
    }
    
    #endregion
}