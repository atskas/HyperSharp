using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

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
    /// <param name="innerContent">The content of the element.</param>
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
    /// <param name="innerContent">The content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Div(Action innerContent, params AttributeBuilder[] attributes)
    {
        var div = new HtmlElement("div");
        
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                div.Attributes.Add(kv.Key, kv.Value);
        }
        
        elementStack.Peek().AddChild(div);
        
        elementStack.Push(div);
        innerContent();
        elementStack.Pop();
    }
}