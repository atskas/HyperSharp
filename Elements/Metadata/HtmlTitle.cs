using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlTitle : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlTitle(Stack<HtmlElement> elementStack) : base("title")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Defines the page’s title shown in the browser tab.
    /// Typically placed inside the 'Head' element.
    /// </summary>
    /// <param name="title">The text content for the page title.</param>
    public void Title(string title)
    {
        var head = new HtmlElement("title") {InnerText = title};
        elementStack.Peek().AddChild(head);
    }
}