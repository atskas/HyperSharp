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
        
        var fireStyle = html.Id("fire")
            .Style("color: red;")
            .Style("padding: 10px;");
        
        var style1 = html.Style("width: 200px; height: 200px; margin: 0 auto;");
        
        html.Html(() =>
        {
            html.Head(() =>
            {
            });

            html.Body(() =>
            {
                html.Div(() => { html.Span("Hello, world!", earthStyle.Attributes); }, style1.Attributes);
                html.Div(() => { html.Span("Goodbye, world!", fireStyle.Attributes); }, style1.Attributes);
            });
        });

        html.SetFileName("test1.html");
        html.Compile();
    }
}