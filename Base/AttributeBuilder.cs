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
        if (Attributes.ContainsKey("class"))
        {
            Attributes["class"] += " " + className;
        }
        else
        {
            Attributes["class"] = className;
        }
        return this;
    }


    public AttributeBuilder Style(string style)
    {
        if (Attributes.ContainsKey("style"))
        {
            Attributes["style"] += " " + style;
        }
        else
        {
            Attributes["style"] = style;
        }
        return this;
    }

    public AttributeBuilder Lang(string lang)
    {
        Attributes["lang"] = lang;
        return this;
    }

    public AttributeBuilder Name(string name)
    {
        Attributes["name"] = name;
        return this;
    }

    // Only to be used on "meta" tag
    public AttributeBuilder Content(string content)
    {
        Attributes["content"] = content;
        return this;
    }

    // Only to be used on "meta" tag
    public AttributeBuilder Charset(string charset)
    {
        Attributes["charset"] = charset;
        return this;
    }

    // Only to be used on "meta" tag
    public AttributeBuilder HttpEquiv(string httpEquiv)
    {
        Attributes["http-equiv"] = httpEquiv;
        return this;
    }
}