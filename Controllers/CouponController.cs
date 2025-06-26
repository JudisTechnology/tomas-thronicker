using DemoEPS.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class CouponController : Controller
{
    private AppDbContext db = new AppDbContext();

    public ActionResult Index()
    {
        return View(db.Coupons.ToList());
    }

    public ActionResult Create()
    {
        CouponModel couponModel = new CouponModel();
        return View(couponModel);
    }

    [HttpPost]
    public ActionResult Create(CouponModel couponModel)
    {
        for (int i = 0; i < couponModel.NumberOfDiscountCoupon; i++)
        {
            Coupon coupon = new Coupon();
            coupon.Code = GenerateCouponCode();
            coupon.ExpiryDate = couponModel.ExpiryDate;
            coupon.DiscountPercentage = couponModel.DiscountPercentage;
            db.Coupons.Add(coupon);
            db.SaveChanges();
        }

        return RedirectToAction("Index", new { msg = "Coupon created successfully" });
    }

    private string GenerateCouponCode()
    {
        var guid = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        return $"{guid}";
    }

    public ActionResult SendCouponCode(string code)
    {
        var coupon = db.Coupons.Where(c => string.Compare(c.Code, code, true) == 0).FirstOrDefault();
        if (coupon != null)
        {
            coupon.IsSent = true;
            db.SaveChanges();
        }

        return RedirectToAction("Index", new { msg = "Coupon sent successfully" });
    }
}