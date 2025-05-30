using HyperSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument html = new HtmlDocument();
        
        // Prepare the attributes before building the tree
        var earthStyle = html.Id("earth")
            .Class("box")
            .Style("background-color: brown;")
            .Style("color: white;")
            .Style("padding: 10px;");

        html.Html(() =>
        {
            html.Head(() =>
            {
            });

            html.Body(() =>
            {
                html.Div(() =>
                {
                    html.Span("Hello, world!", earthStyle.Attributes);
                });
            });
        });

        html.SetFileName("test1.html");
        html.Compile();
    }
}