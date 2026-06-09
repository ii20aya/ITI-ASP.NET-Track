using ComplaintSystem.Models.Enum;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ComplaintSystem.TagHelpers
{
    /// <summary>
    /// Custom Tag Helper: renders a styled badge for a ComplaintStatus value.
    ///
    /// Usage in Razor:
    ///   &lt;complaint-status status="@item.Status"&gt;&lt;/complaint-status&gt;
    ///
    /// Renders as:
    ///   &lt;span class="badge bg-warning text-dark"&gt;⏳ Pending&lt;/span&gt;
    /// </summary>
    [HtmlTargetElement("complaint-status")]
    public class StatusTagHelper : TagHelper
    {
        /// <summary>The status value to display.</summary>
        public ComplaintStatus Status { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";    // renders as <span>

            var (cssClass, icon, label) = Status switch
            {
                ComplaintStatus.Pending => ("badge bg-warning text-dark", "⏳", "Pending"),
                ComplaintStatus.InProgress => ("badge bg-info    text-dark", "🔄", "In Progress"),
                ComplaintStatus.Resolved => ("badge bg-success", "✅", "Resolved"),
                ComplaintStatus.Rejected => ("badge bg-danger", "❌", "Rejected"),
                _ => ("badge bg-secondary", "❓", "Unknown"),
            };

            output.Attributes.SetAttribute("class", cssClass);
            output.Content.SetHtmlContent($"{icon}&nbsp;{label}");
        }
    }
}