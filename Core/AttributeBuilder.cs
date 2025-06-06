using HyperSharp.Core;

namespace HyperSharp.Elements.Base;

public class AttributeBuilder
{
    public Dictionary<string, string> Attributes { get; } = new();

    public AttributeBuilder Set(string key, string value)
    {
        if (Attributes.ContainsKey(key))
        {
            // Append with a space separator
            Attributes[key] += " " + value;
        }
        else
        {
            Attributes[key] = value;
        }

        return this;
    }

    public AttributeBuilder Set(string key)
    {
        Attributes[key] = key;
        return this;

        return this;
    }
    
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
    

    public AttributeBuilder Lang(string lang) => Set("lang", lang);
    public AttributeBuilder Name(string name) => Set("name", name);
    public AttributeBuilder Content(string content) => Set("content", content);
    public AttributeBuilder Charset(string charset) => Set("charset", charset);
    public AttributeBuilder HttpEquiv(string httpEquiv) => Set("http-equiv", httpEquiv);

    public AttributeBuilder Src(string source) => Set("src", source);
    
    public AttributeBuilder Width(string width) => Set("width", width);
    
    public AttributeBuilder Height(string height) => Set("height", height);
}