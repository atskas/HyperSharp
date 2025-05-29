using System;
using HypertextSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        HtmlDocument htmlDocument = new HtmlDocument();

        htmlDocument.DOCTYPE();
        htmlDocument.Div(() =>
        {
            htmlDocument.Span("Text");
            htmlDocument.Span(() => htmlDocument.Span("Nested Text"));
        });
        
        htmlDocument.Compile(htmlDocument.GetHtml());
    }
}