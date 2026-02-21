using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace WebApi.Utilities.Formatters
{
    public class CsvOutFormatter : TextOutputFormatter
    {
       public CsvOutFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        {
            if (typeof(ClothesDto).IsAssignableFrom(type) || typeof(IEnumerable<ClothesDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        private static void FormatCsv(StringBuilder buffer, ClothesDto clothes)
        {
            buffer.AppendLine($"{clothes.Id},{clothes.Name},{clothes.Price}");
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<ClothesDto>)
            {
                foreach (var clothes in (IEnumerable<ClothesDto>)context.Object)
                {
                    FormatCsv(buffer, clothes);
                }
            }
            else if (context.Object is ClothesDto)
            {
                FormatCsv(buffer, (ClothesDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
    }
}
