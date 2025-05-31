using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

internal class HtmlBody : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlBody(Stack<HtmlElement> elementStack) : base("head")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Contains the visible content of the webpage.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Body(Action innerContent)
    {
        var body = new HtmlElement("body");
        elementStack.Peek().AddChild(body);
        
        elementStack.Push(body);
        innerContent();
        elementStack.Pop();
    }
}