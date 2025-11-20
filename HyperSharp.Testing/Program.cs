using HyperSharp.Core;

public class Program
{
    private static HtmlDocument Document = new();

    public static void Main()
    {
        string cssFolderPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Testing", "css"));
        Document.SetUserCssPath(cssFolderPath);
        
        Document.Html(() =>
        {
            Document.Link("stylesheet", "CSS/style.css");
            Document.Div(Document.Attributes.Class("container"), () =>
            {
                Document.Heading("Hello, world!", 1);
                Document.Heading(Document.Attributes.Class("greeting"), "What's up, people!!",4);
                Document.Span("The HTML of this website was fully made in C#. Click below for cookies:");
                Document.Div(() =>
                {
                    Document.Button("HERE!");
                });
            });
        });
        
        Document.SetFileName("Greetings");
        Document.Compile();
    }
}