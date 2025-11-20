using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlHeading : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    // Base tag placeholder, actual tag set dynamically per heading level.
    private static string name = "h";
    
    public HtmlHeading(Stack<HtmlElement> elementStack) : base(name)
    {
        this.elementStack = elementStack;
    }

    /// <summary>
    /// Represents a section title or heading in a document.
    /// Headings range from level 1 (most important) to level 6 (least important).
    /// </summary>
    /// <param name="innerContent">The text content of the heading.</param>
    /// <param name="level">The level of the heading (1 to 6).</param>
    public void Heading(string innerContent, int level)
    {
        level = Math.Clamp(level, 1, 6);
        
        var heading = new HtmlElement($"h{level}") { InnerText = innerContent };
        elementStack.Peek().AddChild(heading);
    }

    /// <summary>
    /// Represents a section title or heading in a document.
    /// Headings range from level 1 (most important) to level 6 (least important).
    /// </summary>
    /// <param name="innerContent">The content of the heading.</param>
    /// <param name="level">The level of the heading (1 to 6).</param>
    public void Heading(Action innerContent, int level)
    {
        level = Math.Clamp(level, 1, 6);

        var heading = new HtmlElement($"h{level}");
        elementStack.Peek().AddChild(heading);
        
        elementStack.Push(heading);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Represents a section title or heading in a document with custom attributes.
    /// Headings range from level 1 (most important) to level 6 (least important).
    /// </summary>
    /// <param name="attributes">Attributes to add to the element.</param>
    /// <param name="innerContent">The content of the heading.</param>
    /// <param name="level">The level of the heading (1 to 6).</param>
    public void Heading(Action innerContent, int level, params AttributeBuilder[] attributes)
    {
        level = Math.Clamp(level, 1, 6);

        var heading = new HtmlElement($"h{level}");
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(heading);
        
        elementStack.Push(heading);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Represents a section title or heading in a document with custom attributes.
    /// Heading range from level 1 (most important) to level 6 (least important)
    /// </summary>
    /// <param name="innerContent">The text content of the heading.</param>
    /// <param name="attributes">Attributes to add to the element.</param>
    /// <param name="level">The level of the heading (1 to 6)</param>
    public void Heading(string innerContent, int level, params AttributeBuilder[] attributes)
    {
        level = Math.Clamp(level, 1, 6);
        
        var heading = new HtmlElement($"h{level}") { InnerText = innerContent };
        foreach (var attr in attributes)
        {
            foreach (var kv in attr.Attributes)
                Attributes.Add(kv.Key, kv.Value);
        }
        elementStack.Peek().AddChild(heading);
    }
}