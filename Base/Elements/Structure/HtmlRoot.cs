using HyperSharp.Elements;
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
    /// <param name="innerContent"></param>
    public void Html(Action innerContent)
    {
        elementStack.Push(this);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Build HTML string from this root element.
    /// </summary>
    /// <param name="indent"></param>
    /// <returns></returns>
    public string Build(IndentationHelper indent)
    {
        return base.Build(indent); // Use HtmlElement.Build from base
    }
}