using System;
using HypertextSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument HTML = new HtmlDocument();

        HTML.DOCTYPE();
        HTML.Html(() =>
        {
            HTML.Head(() =>
            {
            });

            HTML.Body(() =>
            {
                HTML.Div(() =>
                {
                    HTML.Span("This is inside the body.");
                });
            });
        });
        
        // Compile document
        HTML.Compile(HTML.GetHtml());
    }
}