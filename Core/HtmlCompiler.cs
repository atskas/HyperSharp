namespace HypertextSharp.Core;

public class HtmlCompiler
{
    public void Compile(string html)
    {
        File.WriteAllText("output.html", html);
    }
}