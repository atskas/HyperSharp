using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlParagraph : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlParagraph(Stack<HtmlElement> elementStack) : base("p")
    {
        this.elementStack = elementStack;
    }

    /// <summary>
    /// Represents a paragraph of text in an HTML document.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    public void Paragraph(Action innerContent)
    {
        var p = new HtmlElement("p");
        elementStack.Peek().AddChild(p);

        elementStack.Push(p);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Represents a paragraph of text in an HTML document.
    /// </summary>
    /// <param name="innerContent">The text content of the element.</param>
    public void Paragraph(string innerContent)
    {
        var p = new HtmlElement("p") {InnerText = innerContent};
        elementStack.Peek().AddChild(p);
    }

    /// <summary>
    /// Represents a paragraph of text in an HTML document.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Paragraph(Action innerContent, params AttributeBuilder[] attributes)
    {
        var p = new HtmlElement("p");
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                p.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(p);
        
        elementStack.Push(p);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Represents a paragraph of text in an HTML document.
    /// </summary>
    /// <param name="innerContent">The text content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Paragraph(string innerContent, params AttributeBuilder[] attributes)
    {
        var p = new HtmlElement("p") {InnerText = innerContent};
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                p.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(p);
    }
}