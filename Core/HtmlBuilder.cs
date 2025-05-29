using System.Text;

namespace HypertextSharp.Core;

public class HtmlBuilder
{
    private StringBuilder _sb = new StringBuilder();

    public void Append(string html) => _sb.Append(html);
    public override string ToString() => _sb.ToString();
}