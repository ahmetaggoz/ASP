using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogProject.TagHelpers
{
    [HtmlTargetElement("view-count")]
    public class ViewCountTagHelper : TagHelper
    {
        public int Count { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "view-count text-muted small");

            var icon = "<i class='fas fa-eye me-1'></i>";
            var text = Count == 1 ? "görüntülenme" : "görüntülenme";

            output.Content.SetHtmlContent($"{icon}-{Count} {text}");
        }
    }
}
