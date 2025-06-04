using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

internal class HtmlDiv : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlDiv(Stack<HtmlElement> elementStack) : base("div")
    {
        this.elementStack = elementStack;
    }

    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Div(Action innerContent)
    {
        var div = new HtmlElement("div");
        elementStack.Peek().AddChild(div);

        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Div(AttributeBuilder attributes, Action innerContent)
    {
        var div = new HtmlElement("div", attributes.Attributes);
        
        elementStack.Peek().AddChild(div);
        
        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Container element used to group other elements together.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Div(Action innerContent, AttributeBuilder attributes)
    {
        var div = new HtmlElement("div", attributes.Attributes);
        
        elementStack.Peek().AddChild(div);
        
        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }
}