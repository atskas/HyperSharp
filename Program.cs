using System;
using HyperSharp.Elements;
using HypertextSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument HTML = new HtmlDocument();
        
        HTML.Html(() =>
        {
            HTML.Head(() =>
            {
            });

            HTML.Body(() =>
            {
                HTML.Div(() =>
                {
                    HTML.Span("Hello, world!", new AttributeBuilder()
                        .Class("red-text")
                        .Style("color:red; font-size:18px;")
                        .Attributes);
                }, new AttributeBuilder()
                    .Id("container")
                    .Class("box")
                    .Attributes);
            });
        });
        
        HTML.SetFileName("test1.html");
        HTML.Compile();
    }
}