using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlLink : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlLink(Stack<HtmlElement> elementStack) : base("link")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Connects an external CSS file to the HTML document.
    /// Typically placed inside the 'Head' element.
    /// </summary>
    /// <param name="rel">The relationship between the document and the linked resource.</param>
    /// <param name="filePath">The path or URL to the css file.</param>
    public void Link(string rel, string href)
    {
        var link = new HtmlElement("link");
        link.SetAttribute("rel", rel);
        link.SetAttribute("href", href);
        
        elementStack.Peek().AddChild(link);
    }
}