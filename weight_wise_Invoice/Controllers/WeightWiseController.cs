using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using weight_wise_Invoice.Models;

public class WeightWiseController : Controller
{
    private string connectionString = "Server=DESKTOP-UNG2TM0;Database=invoice;Integrated Security=True";

    // GET: Show Invoice Form
    public ActionResult WeightInvoice()
    {
        return View();
    }

    // POST: Generate Invoice
    [HttpPost]
    public ActionResult GenerateInvoice(WeightInvoice model)
    {
        try
        {
            model.TotalAmount = model.Quantity * model.Price;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO WeightInvoice (CustomerName, Email, Date, Weight, Quantity, Price, TotalAmount) " +
                               "VALUES (@CustomerName, @Email, @Date, @Weight, @Quantity, @Price, @TotalAmount)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", model.CustomerName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Date", model.Date);
                    cmd.Parameters.AddWithValue("@Weight", model.Weight);
                    cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@TotalAmount", model.TotalAmount);
                    cmd.ExecuteNonQuery();
                }
            }

            TempData["Success"] = "Invoice generated successfully!";
            return View("GenerateInvoice",model);  // ✅ Invoice Page پر Redirect
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Error: " + ex.Message;
            return View("WeightInvoice"); // ❌ Form دوبارہ لوڈ کرو error کے ساتھ
        }
    }

    // GET: Fetch Price for Selected Weight (AJAX)
    public JsonResult GetPrice(string weight)
    {
        decimal price = 0;
        switch (weight)
        {
            case "50 KG":
                price = 5000;
                break;
            case "100 KG":
                price = 9000;
                break;
            case "150 KG":
                price = 13000;
                break;
        }
        return Json(price, JsonRequestBehavior.AllowGet);
    }
}
