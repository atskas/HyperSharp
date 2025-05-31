using System.Text;
using HyperSharp.Utils;

namespace HyperSharp.Elements;

internal class HtmlElement
{
    public string Name { get; set; }
    public string? InnerText { get; set; }
    public List<HtmlElement> Children { get; set; } = new();
    public Dictionary<string, string> Attributes { get; set; } = new();

    public HtmlElement(string name)
    {
        Name = name;
    }
    
    public void AddChild(HtmlElement child) => Children.Add(child);
    public void SetAttribute(string name, string value) => Attributes[name] = value;

    public string Build(IndentationHelper indentation)
    {
        var attrString = Attributes.Count > 0
            ? " " + string.Join(" ", Attributes.Select(a => $"{a.Key}=\"{a.Value}\""))
            : "";

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