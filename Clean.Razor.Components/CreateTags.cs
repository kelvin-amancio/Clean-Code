using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace Clean.Razor.Components
{
    public static class CreateTags
    {
        public static IHtmlContent CreateComponentsHtml(this IHtmlHelper html, string content, string type)
        {
            var tagBuilder = new TagBuilder("div");
            var htmlContent = string.Empty;

            using (var write = new StringWriter())
            {
                if (type == "label")
                {
                    TagBuilder labelAppend = new TagBuilder("label");
                    tagBuilder.AddCssClass("form-floating mb-3");
                    labelAppend.InnerHtml.AppendHtml(content);
                    tagBuilder.InnerHtml.AppendHtml(labelAppend);
                }
                else if(type == "btn")
                {
                    TagBuilder btnAppend = new TagBuilder("button");
                    tagBuilder.AddCssClass("btn btn-primary");
                    btnAppend.InnerHtml.AppendHtml(content);
                    tagBuilder.InnerHtml.AppendHtml(btnAppend);
                }

                tagBuilder.WriteTo(write, HtmlEncoder.Default);
                htmlContent = write.ToString();
            }

            return new HtmlString(htmlContent);
        }
    }
}
