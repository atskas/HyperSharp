using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

internal class HtmlTitle : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlTitle(Stack<HtmlElement> elementStack) : base("title")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Defines the page’s title shown in the browser tab.
    /// </summary>
    /// <param name="title"></param>
    public void Title(string title)
    {
        var head = new HtmlElement("title") {InnerText = title};
        elementStack.Peek().AddChild(head);
    }
}