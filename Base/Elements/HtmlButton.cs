using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

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
    /// <param name="innerContent"></param>
    public void Button(string innerContent)
    {
        var span = new HtmlElement("button") { InnerText = innerContent };
        elementStack.Peek().AddChild(span);
    }

    /// <summary>
    /// Clickable button.
    /// </summary>
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
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Button(Dictionary<string, string> attributes ,Action innerContent)
    {
        var span = new HtmlElement("button");
        foreach(var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(span);
        
        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Button(Dictionary<string, string> attributes ,string innerContent)
    {
        var span = new HtmlElement("button") { InnerText = innerContent };
        foreach(var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(span);
    }
    
    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Button(Action innerContent, Dictionary<string, string> attributes)
    {
        var span = new HtmlElement("button");
        foreach (var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);

        elementStack.Peek().AddChild(span);

        elementStack.Push(span);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Clickable button.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Button(string innerContent, Dictionary<string, string> attributes)
    {
        var span = new HtmlElement("button") { InnerText = innerContent };
        foreach(var attr in attributes)
            span.SetAttribute(attr.Key, attr.Value);
        
        elementStack.Peek().AddChild(span);
    }
}