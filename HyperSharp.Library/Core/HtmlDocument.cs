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
        elements.HtmlDiv.Div(innerContent);
    }

    /// <inheritdoc cref="HtmlDiv.Div(Action, AttributeBuilder[])"/>
    public void Div(Action innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlDiv.Div(innerContent, attributes);
    }

    #endregion

    #region Span

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Span(string innerContent)
    {
        EnsureRoot();
        elements.HtmlSpan.Span(innerContent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action)"/>
    public void Span(Action innerConent)
    {
        EnsureRoot();
        elements.HtmlSpan.Span(innerConent);
    }

    /// <inheritdoc cref="HtmlSpan.Span(string, AttributeBuilder[])"/>
    public void Span(string innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlSpan.Span(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlSpan.Span(Action, AttributeBuilder[])"/>
    public void Span(Action innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlSpan.Span(innerContent, attributes);
    }

    #endregion

    #region Html

    /// <inheritdoc cref="HtmlRoot.Html(Action)"/>
    public void Html(Action innerContent) => elements.Root.Html(innerContent);

    /// <inheritdoc cref="HtmlRoot.Html(Action, AttributeBuilder[])"/>
    public void Html(Action innerContent, params AttributeBuilder[] attributes) => elements.Root.Html(innerContent, attributes);

    #endregion

    #region Head

    /// <inheritdoc cref="HtmlHead.Head(Action)"/>
    public void Head(Action innerContent)
    {
        EnsureRoot();
        elements.HtmlHead.Head(innerContent);
    }

    #endregion

    #region Body

    /// <inheritdoc cref="HtmlBody.Body(Action)"/>
    public void Body(Action innerContent)
    {
        EnsureRoot();
        elements.HtmlBody.Body(innerContent);
    }

    #endregion

    #region Link

    /// <inheritdoc cref="HtmlLink.Link(string, string)"/>
    public void Link(string rel, string href)
    {
        EnsureRoot();
        elements.HtmlLink.Link(rel, href);
    }

    #endregion

    #region Button

    /// <inheritdoc cref="HtmlSpan.Span(string)"/>
    public void Button(string innerContent)
    {
        EnsureRoot();
        elements.HtmlButton.Button(innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action)"/>
    public void Button(Action innerContent)
    {
        EnsureRoot();
        elements.HtmlButton.Button(innerContent);
    }

    /// <inheritdoc cref="HtmlButton.Button(string, AttributeBuilder[])"/>
    public void Button(string innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlButton.Button(innerContent, attributes);
    }

    /// <inheritdoc cref="HtmlButton.Button(Action, AttributeBuilder[])"/>
    public void Button(Action innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlButton.Button(innerContent, attributes);
    }

    #endregion

    #region Title

    /// <inheritdoc cref="HtmlTitle.Title(string)"/>
    public void Title(string title)
    {
        EnsureRoot();
        elements.HtmlTitle.Title(title);
    }

    #endregion

    #region Meta

    /// <inheritdoc cref="HtmlMeta.Meta(AttributeBuilder[])"/>
    public void Meta(AttributeBuilder attributes)
    {
        EnsureRoot();
        elements.HtmlMeta.Meta(attributes);
    }

    #endregion

    #region IFrame


    /// <inheritdoc cref="HtmlIFrame.IFrame(AttributeBuilder[])"/>
    public void IFrame(params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlIFrame.IFrame(attributes);
    }

    #endregion
    
    #region Paragraph

    /// <inheritdoc cref="HtmlParagraph.Paragraph(Action)"/>
    public void Paragraph(Action innerContent)
    {
        EnsureRoot();
        elements.HtmlParagraph.Paragraph(innerContent);
    }

    /// <inheritdoc cref="HtmlParagraph.Paragraph(string)"/>
    public void Paragraph(string innerContent)
    {
        EnsureRoot();
        elements.HtmlParagraph.Paragraph(innerContent);
    }

    /// <inheritdoc cref="HtmlParagraph.Paragraph(Action, AttributeBuilder[])"/>
    public void Paragraph(Action innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlParagraph.Paragraph(innerContent, attributes);
    }
    
    /// <inheritdoc cref="HtmlParagraph.Paragraph(string, AttributeBuilder[])"/>
    public void Paragraph(string innerContent, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlParagraph.Paragraph(innerContent, attributes);
    }

    #endregion
    
    #region Heading

    /// <inheritdoc cref="HtmlHeading.Heading(string, int)"/>
    public void Heading(string innerContent, int level)
    {
        EnsureRoot();
        elements.HtmlHeading.Heading(innerContent, level);
    }

    /// <inheritdoc cref="HtmlHeading.Heading(Action, int)"/>
    public void Heading(Action innerContent, int level)
    {
        EnsureRoot();
        elements.HtmlHeading.Heading(innerContent, level);
    }

    /// <inheritdoc cref="HtmlHeading.Heading(Action, int, AttributeBuilder[])"/>
    public void Heading(Action innerContent, int level, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlHeading.Heading(innerContent, level, attributes);
    }
    
    /// <inheritdoc cref="HtmlHeading.Heading(string, int, AttributeBuilder[])"/>
    public void Heading(string innerContent, int level, params AttributeBuilder[] attributes)
    {
        EnsureRoot();
        elements.HtmlHeading.Heading(innerContent, level, attributes);
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
        
        builder.Append(elements.Root.Build(indentation));
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
    /// <param name="fileName">The name of the output HTML file (without path).</param>
    public void SetFileName(string fileName) => compiler.OutputFileName = fileName;
    
    /// <summary>
    /// User's CSS file path.
    /// All .css files in this path will be copied to the output folder's /CSS directory.
    /// </summary>
    /// <param name="path">The path where the user keeps their CSS files / The direct path to a CSS file.</param>
    public void SetUserCssPath(string path) => compiler.UserCssPath = path;

    /// <summary>
    /// Automatically wraps content in Html tag if it's not present.
    /// </summary>
    private void EnsureRoot()
    {
        if (elements.Root == null || elements.ElementStack.Count == 0)
        {
            Console.WriteLine("Warning: Html() was not called.");
            Console.WriteLine("Automatically wrapping content.");
            elements.Root.Html(() => {});
            elements.ElementStack.Push(elements.Root);
        }
    }
    
    #endregion
}