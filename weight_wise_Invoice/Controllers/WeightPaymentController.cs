using System;
using System.Web.Mvc;

namespace weight_wise_Invoice.Controllers
{
    public class WeightPaymentController : Controller
    {
        public ActionResult SaveInvoiceData(string customerName, decimal totalAmount)
        {
            Session["CustomerName"] = customerName;
            Session["TotalAmount"] = totalAmount;

            return RedirectToAction("PaymentForm");
        }

        public ActionResult PaymentForm()
        {
            string customerName = Session["CustomerName"] as string;
            decimal? totalAmount = Session["TotalAmount"] as decimal?;

            var model = new Models.WeightPaymentData
            {
                CustomerName = customerName,
                Date = DateTime.Now,
                TotalAmount = totalAmount ?? 0,
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult SubmitPayment(string customerName, decimal totalAmount, string paymentMethod)
        {
            try
            {
                if (string.IsNullOrEmpty(paymentMethod))
                {
                    return Json(new { success = false, message = "Please select a payment method!" });
                }

                // ✅ Payment Process Logic (آپ یہاں database save logic add کریں)
                // Example: Save payment record in DB

                return Json(new { success = true, message = "Payment Successful!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }
    }
}
