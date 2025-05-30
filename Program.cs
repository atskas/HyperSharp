using System;
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
                    HTML.Span("Hello, world!");
                });
            });
        });
        
        // Compile document
        HTML.SetFileName("test1.html");
        HTML.Compile();
    }
}