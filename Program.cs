using HyperSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument html = new HtmlDocument();
        
        // Prepare the attributes before building the tree
        var earthStyle = html.Id("earth")
            .Class("earth")
            .Style("color: brown;")
            .Style("padding: 10px;")
            .Style("font-family: Arial;");
        
        var style1 = html.Style("width: 200px; height: 200px; margin: 0 auto;");
        
        // Content will automatically be wrapped in html tag
        // even though I don't call it
        html.Span("Hello!", earthStyle.Attributes);

        html.SetFileName("test1.html");
        html.Compile();
    }
}