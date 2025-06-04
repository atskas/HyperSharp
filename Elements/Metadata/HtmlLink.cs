using HyperSharp.Core;

namespace HyperSharp.Elements.Elements;

internal class HtmlLink : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlLink(Stack<HtmlElement> elementStack) : base("link")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Connects an external CSS file to the HTML document.
    /// </summary>
    /// <param name="rel"></param>
    /// <param name="filePath"></param>
    public void Link(string rel, string href)
    {
        var link = new HtmlElement("link");
        link.SetAttribute("rel", rel);
        link.SetAttribute("href", href);
        
        elementStack.Peek().AddChild(link);
    }
}