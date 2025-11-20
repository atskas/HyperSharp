using HyperSharp.Core;

namespace HyperSharp.Elements.Base;

public class AttributeBuilder
{
    public Dictionary<string, string> Attributes { get; } = new();

    /// <summary>
    /// Sets an attribute to the element
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Sets a boolean attribute to the element
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public AttributeBuilder SetBoolean(string key)
    {
        Attributes[key] = null;
        return this;
    }
    
    /// <summary>
    /// Used to specify a unique id for an HTML element.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public AttributeBuilder Id(string id)
    {
        Attributes["id"] = id;
        return this;
    }

    /// <summary>
    /// Assigns CSS classes to an element for styling or scripting.
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Adds inline CSS styles directly to an element.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
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
    
    /// <summary>
    /// Specifies the primary language of the element's content.
    /// /// </summary>
    /// <param name="lang"></param>
    /// <returns></returns>
    public AttributeBuilder Lang(string lang) => Set("lang", lang);
    
    /// <summary>
    /// Provides a name for the element.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AttributeBuilder Name(string name) => Set("name", name);
    
    /// <summary>
    /// Supplies the value for metadata elements. (Only to be used for Meta element)
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public AttributeBuilder Content(string content) => Set("content", content);
    
    /// <summary>
    /// Declares the character encoding used in the document. (Only to be used for Meta element)
    /// </summary>
    /// <param name="charset"></param>
    /// <returns></returns>
    public AttributeBuilder Charset(string charset) => Set("charset", charset);
    
    /// <summary>
    /// Simulates HTTP response headers. (Only to be used for Meta element)
    /// </summary>
    /// <param name="httpEquiv"></param>
    /// <returns></returns>
    public AttributeBuilder HttpEquiv(string httpEquiv) => Set("http-equiv", httpEquiv);
    
    /// <summary>
    /// Specifies the URL of the resource to be used by the element.
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public AttributeBuilder Src(string source) => Set("src", source);
    
    /// <summary>
    /// Sets the width of the element in pixels or percentage.
    /// </summary>
    /// <param name="width"></param>
    /// <returns></returns>
    public AttributeBuilder Width(string width) => Set("width", width);
    
    /// <summary>
    /// Sets the height of the element in pixels or percentage.
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public AttributeBuilder Height(string height) => Set("height", height);
    
    /// <summary>
    /// Provides alternative information for certain elements (like an image) if the
    /// user for some reason cannot view it.
    /// </summary>
    /// <param name="alt"></param>
    /// <returns></returns>
    public AttributeBuilder Alt(string alt) => Set("alt", alt);
}