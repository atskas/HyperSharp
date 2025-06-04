using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

internal class HtmlHead : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlHead(Stack<HtmlElement> elementStack) : base("head")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Contains metadata and resources needed by the browser but not directly displayed.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Head(Action innerContent)
    {
        var head = new HtmlElement("head");
        elementStack.Peek().AddChild(head);

        elementStack.Push(head);
        innerContent();
        elementStack.Pop();
    }
}