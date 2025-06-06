using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlSource : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlSource(Stack<HtmlElement> elementStack) : base("source")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Specifies alternative media resources for media elements.
    /// </summary>
    /// <param name="attributes"></param>
    public void Source(AttributeBuilder attributes)
    {
        var source = new HtmlElement("source", attributes.Attributes);
        elementStack.Peek().AddChild(source);
    }
}