using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Entities.Models.Order;
using System.Globalization;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Infrastructure.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent FormatCurrency(this IHtmlHelper html, decimal amount)
        {
            return new HtmlString(amount.ToString("C", new CultureInfo("tr-TR")));
        }

        public static IHtmlContent StatusBadge(this IHtmlHelper html, OrderStatus status)
        {
            var badgeClass = status switch
            {
                OrderStatus.Pending => "bg-warning",
                OrderStatus.Processing => "bg-info",
                OrderStatus.Shipped => "bg-primary",
                OrderStatus.Delivered => "bg-success",
                OrderStatus.Cancelled => "bg-danger",
                _ => "bg-secondary"
            };

            var statusText = status switch
            {
                OrderStatus.Pending => "Beklemede",
                OrderStatus.Processing => "İşleniyor",
                OrderStatus.Shipped => "Kargoda",
                OrderStatus.Delivered => "Teslim Edildi",
                OrderStatus.Cancelled => "İptal Edildi",
                _ => status.ToString()
            };

            return new HtmlString($"<span class=\"badge {badgeClass}\">{statusText}</span>");
        }

        public static IHtmlContent ActiveBadge(this IHtmlHelper html, bool isActive)
        {
            var badgeClass = isActive ? "bg-success" : "bg-secondary";
            var text = isActive ? "Aktif" : "Pasif";
            return new HtmlString($"<span class=\"badge {badgeClass}\">{text}</span>");
        }
    }
}
