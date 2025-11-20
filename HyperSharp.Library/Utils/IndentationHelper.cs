namespace HyperSharp.Utils;

internal class IndentationHelper
{
    public int indentLevel = 0;
    public string Indent() => new string(' ', indentLevel * 2);
}