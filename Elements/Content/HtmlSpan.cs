using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

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
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Span(AttributeBuilder attributes, Action innerContent)
    {
        var span = new HtmlElement("span", attributes.Attributes);
        
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Span(Action innerContent, AttributeBuilder attributes)
    {
        var span = new HtmlElement("span", attributes.Attributes);
        
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Span(string innerContent, AttributeBuilder attributes)
    {
        var span = new HtmlElement("span", attributes.Attributes) { InnerText = innerContent };
        elementStack.Peek().AddChild(span);
    }
    
    /// <summary>
    /// Generic inline container for phrasing content.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Span(AttributeBuilder attributes, string innerContent)
    {
        var span = new HtmlElement("span", attributes.Attributes) { InnerText = innerContent };
        elementStack.Peek().AddChild(span);
    }
}