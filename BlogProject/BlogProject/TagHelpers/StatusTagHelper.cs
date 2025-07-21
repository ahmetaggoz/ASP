using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogProject.TagHelpers
{
    [HtmlTargetElement("status")]
    public class StatusTagHelper : TagHelper
    {
        public bool IsPublished { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            if(IsPublished)
            {
                output.Attributes.SetAttribute("class", "badge bg-success");
                output.Content.SetContent("Yayında");
            }
            else
            {
                output.Attributes.SetAttribute("class", "badge bg-warning text-dark");
                output.Content.SetContent("Taslak");
            }
        }
    }
}
