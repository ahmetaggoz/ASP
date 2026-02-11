using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetSuccessMessage(this Controller controller, string message)
        {
            controller.TempData["SuccessMessage"] = message;
        }

        public static void SetErrorMessage(this Controller controller, string message)
        {
            controller.TempData["ErrorMessage"] = message;
        }

        public static void SetInfoMessage(this Controller controller, string message)
        {
            controller.TempData["InfoMessage"] = message;
        }

        public static void SetWarningMessage(this Controller controller, string message)
        {
            controller.TempData["WarningMessage"] = message;
        }
    }
}
