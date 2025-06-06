using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlIFrame : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlIFrame(Stack<HtmlElement> elementStack) : base("iframe")
    {
        this.elementStack = elementStack;
    }
    
    public void IFrame(AttributeBuilder attributes)
    {
        var iframe = new HtmlElement("iframe", attributes.Attributes);
        elementStack.Peek().AddChild(iframe);
    }
}