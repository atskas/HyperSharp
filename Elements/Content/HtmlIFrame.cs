using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlIFrame : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlIFrame(Stack<HtmlElement> elementStack) : base("iframe")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Embeds another HTML document within the current webpage.
    /// </summary>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void IFrame(AttributeBuilder attributes)
    {
        var iframe = new HtmlElement("iframe", attributes.Attributes);
        elementStack.Peek().AddChild(iframe);
    }
}