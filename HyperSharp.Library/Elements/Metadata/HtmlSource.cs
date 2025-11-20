using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlSource : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlSource(Stack<HtmlElement> elementStack) : base("source")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Specifies alternative media resources for media elements.
    /// </summary>
    /// <param name="attributes">Attributes to add to the element.</param>
    public void Source(params AttributeBuilder[] attributes)
    {
        var source = new HtmlElement("source");
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                source.Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(source);
    }
}