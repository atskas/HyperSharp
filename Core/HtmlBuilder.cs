using System.Text;

namespace HyperSharp.Core;

public class HtmlBuilder
{
    private StringBuilder _sb = new StringBuilder();

    internal void Append(string html) => _sb.Append(html);
    internal void Clear() => _sb.Clear();
    public override string ToString() => _sb.ToString();
}