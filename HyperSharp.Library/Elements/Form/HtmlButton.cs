using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlButton : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlButton(Stack<HtmlElement> elementStack) : base("span")
    {
        this.elementStack = elementStack;
    }

    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="innerContent">The text content of the element.</param>
    public void Button(string innerContent)
    {
        var span = new HtmlElement("button") { InnerText = innerContent };
        elementStack.Peek().AddChild(span);
    }

    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    public void Button(Action innerContent)
    {
        var span  = new HtmlElement("button");
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Button(Action innerContent, params AttributeBuilder[] attributes)
    {
        var button = new HtmlElement("button");
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                button.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(button);
        
        elementStack.Push(button);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="attributes">Attributes to add to the element.</param>
    /// <param name="innerContent">The text content of the element.</param>
    public void Button(string innerContent, params AttributeBuilder[] attributes)
    {
        var button = new HtmlElement("button") { InnerText = innerContent };
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                button.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(button);
    }
}