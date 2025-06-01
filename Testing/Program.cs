using HyperSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument html = new HtmlDocument();
        
        // Prepare the attributes before building the tree
        var style1 = html.Id("earth")
            .Class("earth")
            .Style("color: brown;")
            .Style("padding: 10px;")
            .Style("font-family: Arial;");
            
        // Content will automatically be wrapped in html tag
        // even though I don't call it
        html.Span("Hello, world!!", style1.Attributes);

        html.SetFileName("test1.html");
        html.Compile();
    }
}