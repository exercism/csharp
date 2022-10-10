using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string OpeningTag(string tag) => $"<{tag}>";
    private static string ClosingTag(string tag) => $"</{tag}>";
    private static string WrapInTag(this string text, string tag) => $"{OpeningTag(tag)}{text}{ClosingTag(tag)}";
    private static bool StartsWithTag(this string text, string tag) => text.StartsWith(OpeningTag(tag));

    private const string HeaderMarkdown = "#";
    private const string BoldMarkdown = "__";
    private const string ItalicMarkdown = "_";
    private const string ListItemMarkdown = "*";

    private const string BoldTag = "strong";
    private const string ItalicTag = "em";
    private const string ParagraphTag = "p";
    private const string ListTag = "ul";
    private const string ListItemTag = "li";

    private static string ParseDelimited(this string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = "$1".WrapInTag(tag);
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string ParseBold(this string markdown) => markdown.ParseDelimited(BoldMarkdown, BoldTag);
    private static string ParseItalic(this string markdown) => markdown.ParseDelimited(ItalicMarkdown, ItalicTag);

    private static string ParseText(this string markdown, bool list)
    {
        var textHtml = markdown
            .ParseBold()
            .ParseItalic();

        return list ? textHtml : textHtml.WrapInTag(ParagraphTag);
    }

    private static Tuple<bool, string> ParseHeader(this string markdown, bool list)
    {
        var headerNumber =
            markdown
                .TakeWhile(c => c == HeaderMarkdown[0])
                .Count();

        if (headerNumber == 0 || headerNumber > 6)
            return null;

        var headerTag = $"h{headerNumber}";
        var headerHtml = markdown.Substring(headerNumber + 1).WrapInTag(headerTag);
        var html = list ? ClosingTag(ListTag) + headerHtml : headerHtml;

        return Tuple.Create(false, html);
    }

    private static Tuple<bool, string> ParseLineItem(this string markdown, bool list)
    {
        if (!markdown.StartsWith(ListItemMarkdown))
            return null;

        var innerHtml =
            markdown
                .Substring(2)
                .ParseText(true)
                .WrapInTag(ListItemTag);

        var html = list ? innerHtml : OpeningTag(ListTag) + innerHtml;
        return Tuple.Create(true, html);
    }

    private static Tuple<bool, string> ParseParagraph(this string markdown, bool list)
    {
        if (list)
            return Tuple.Create(false, ClosingTag(ListTag) + markdown.ParseText(false));

        return Tuple.Create(false, markdown.ParseText(list));
    }

    private static Tuple<bool, string> ParseLine(Tuple<bool, string> accumulator, string markdown)
    {
        var list = accumulator.Item1;
        var html = accumulator.Item2;

        var result =
            markdown.ParseHeader(list) ??
            markdown.ParseLineItem(list) ??
            markdown.ParseParagraph(list);

        if (result == null)
            throw new ArgumentException("Invalid markdown");

        return Tuple.Create(result.Item1, html + result.Item2);
    }

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = lines.Aggregate(Tuple.Create(false, ""), ParseLine);

        var list = result.Item1;
        var html = result.Item2;

        return list ? html + ClosingTag(ListTag) : html;
    }
}