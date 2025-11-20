using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlSpan : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlSpan(Stack<HtmlElement> elementStack) : base("span")
    {
        this.elementStack = elementStack;
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="innerContent">The text content of the element.</param>
    public void Span(string innerContent)
    {
        var span = new HtmlElement("span") { InnerText = innerContent };
        elementStack.Peek().AddChild(span);
    }

    /// <summary>
    /// Generic inline container element for phrasing content.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    public void Span(Action innerContent)
    {
        var span  = new HtmlElement("span");
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Span(Action innerContent, params AttributeBuilder[] attributes)
    {
        var span = new HtmlElement("span");
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                span.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="innerContent">The text content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Span(string innerContent, params AttributeBuilder[] attributes)
    {
        var span = new HtmlElement("span") { InnerText = innerContent };
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                span.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(span);
    }
}