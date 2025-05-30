using System;
using HyperSharp.Elements;
using HypertextSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument HTML = new HtmlDocument();
        
        // Prepare the attributes before building the tree
        var earthStyle = HTML.Id("earth")
            .Class("box")
            .Style("background-color: brown;")
            .Style("color: white;")
            .Style("padding: 10px;");

        HTML.Html(() =>
        {
            HTML.Head(() =>
            {
            });

            HTML.Body(() =>
            {
                HTML.Div(() =>
                {
                    HTML.Span("Hello, world!", earthStyle.Attributes);
                });
            });
        });

        HTML.SetFileName("test1.html");
        HTML.Compile();
    }
}