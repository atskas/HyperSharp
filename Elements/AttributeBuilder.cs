namespace HyperSharp.Elements;

public class AttributeBuilder
{
    public Dictionary<string, string> Attributes { get; } = new();

    public AttributeBuilder Id(string id)
    {
        Attributes["id"] = id;
        return this;
    }

    public AttributeBuilder Class(string className)
    {
        Attributes["class"] = className;
        return this;
    }

    public AttributeBuilder Style(string style)
    {
        Attributes["style"] = style;
        return this;
    }
}