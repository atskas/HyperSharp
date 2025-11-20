using HyperSharp.Elements.Base;
using HyperSharp.Utils;

internal class HtmlRoot : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;

    public HtmlRoot(Stack<HtmlElement> elementStack) : base("html")
    {
        this.elementStack = elementStack;
    }

    /// <summary>
    /// Root element of an HTML document.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    public void Html(Action innerContent)
    {
        elementStack.Push(this);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Root element of an HTML document.
    /// </summary>
    /// <param name="innerContent">The content of the element.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Html(Action innerContent, params AttributeBuilder[] attributes)
    {
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                Attributes.Add(kv.Key, kv.Value);
        }
        
        elementStack.Push(this);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Build HTML string from this root element.
    /// </summary>
    /// <param name="indent"></param>
    /// <returns></returns>
    internal string Build(IndentationHelper indent)
    {
        return base.Build(indent); // Use HtmlElement.Build from base
    }
}