using System.Text;
using HyperSharp.Utils;

namespace HyperSharp.Elements.Base;

internal class HtmlElement
{
    // There's not that many self-closing tags,
    // so hardcoding this is perfectly fine.
    private static readonly HashSet<string> SelfClosing = new HashSet<string>
    {
        "area", "base", "br", "col", "embed",
        "hr", "img", "input", "link", "meta",
        "param", "source", "track", "wbr"
    };
    
    public string Name { get; set; }
    public string? InnerText { get; set; }
    public List<HtmlElement> Children { get; set; } = new();
    public Dictionary<string, string> Attributes { get; set; } = new();

    public HtmlElement(string name)
    {
        Name = name;
    }
    
    public HtmlElement(string name, Dictionary<string, string>? attributes)
    {
        Name = name;
        if (attributes != null)
            foreach (var attr in attributes)
                Attributes[attr.Key] = attr.Value;
    }
    
    public void AddChild(HtmlElement child) => Children.Add(child);
    public void SetAttribute(string name, string value) => Attributes[name] = value;

    public string Build(IndentationHelper indentation)
    {
        var attrString = Attributes.Count > 0
            ? " " + string.Join(" ", Attributes.Select(a => $"{a.Key}=\"{a.Value}\""))
            : "";
        
        if (SelfClosing.Contains(Name))
        {
            return $"{indentation.Indent()}<{Name}{attrString}/>\n";
        }

        if (Children.Count == 0 && string.IsNullOrEmpty(InnerText))
            return $"{indentation.Indent()}<{Name}{attrString}></{Name}>\n";

        if (Children.Count == 0)
            return $"{indentation.Indent()}<{Name}{attrString}>{InnerText}</{Name}>\n";
        
        var sb = new StringBuilder();
        sb.Append($"{indentation.Indent()}<{Name}{attrString}>\n");

        indentation.indentLevel++;
        foreach (var child in Children)
            sb.Append(child.Build(indentation));
        indentation.indentLevel--;

        sb.Append($"{indentation.Indent()}</{Name}>\n");
        return sb.ToString();
    }
}