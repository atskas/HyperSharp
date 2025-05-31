using HyperSharp.Elements;
using HyperSharp.Utils;

internal class HtmlRoot : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    private HtmlElement? rootElement;

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
        // Create the actual root <html> element
        rootElement = new HtmlElement("html");

        // Push root element to stack to allow children to be added
        elementStack.Push(rootElement);
        innerContent();
        elementStack.Pop();
    }

    /// <summary>
    /// Build HTML string from root element, not from this instance.
    /// </summary>
    /// <param name="indent"></param>
    /// <returns></returns>
    public string Build(IndentationHelper indent)
    {
        if (rootElement == null)
            return "<html></html>"; // fallback if not initialized

        return rootElement.Build(indent);
    }
}