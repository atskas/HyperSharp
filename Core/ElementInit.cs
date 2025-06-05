using HyperSharp.Elements.Base;
using HyperSharp.Elements.Base.Elements;

namespace HyperSharp.Core;

public class ElementInit
{
    internal readonly Stack<HtmlElement> ElementStack = new Stack<HtmlElement>();
    
    internal readonly HtmlDiv htmlDiv;
    internal readonly HtmlSpan htmlSpan;
    internal readonly HtmlHead htmlHead;
    internal readonly HtmlBody htmlBody;
    internal readonly HtmlLink htmlLink;
    internal readonly HtmlButton htmlButton;
    internal readonly HtmlTitle htmlTitle;
    internal readonly HtmlMeta htmlMeta;
    internal HtmlRoot root;

    public ElementInit()
    {
        // Pass all elements to the document
        htmlDiv = new HtmlDiv(ElementStack);
        htmlSpan = new HtmlSpan(ElementStack);
        root = new HtmlRoot(ElementStack);
        htmlHead = new HtmlHead(ElementStack);
        htmlBody = new HtmlBody(ElementStack);
        htmlLink = new HtmlLink(ElementStack);
        htmlButton = new HtmlButton(ElementStack);
        htmlTitle = new HtmlTitle(ElementStack);
        htmlMeta = new HtmlMeta(ElementStack);
    }

}