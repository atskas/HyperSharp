using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlMeta : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlMeta(Stack<HtmlElement> elementStack) : base("meta")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Represents metadata about the HTML document, such as character encoding,
    /// Typically placed inside the 'Head' element.
    /// </summary>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Meta(params AttributeBuilder[] attributes)
    {
        var meta = new HtmlElement("meta");
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                meta.SetAttribute(kv.Key, kv.Value);
        }

        elementStack.Peek().AddChild(meta);
    }
}