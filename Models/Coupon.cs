using System;
using System.ComponentModel.DataAnnotations;

namespace DemoEPS.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsSent { get; set; } = false;

        [Range(0, 100)]
        public int DiscountPercentage { get; set; } = 10;

        public DateTime? ExpiryDate { get; set; }
    }

    public class CouponModel
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsUsed { get; set; } = false;

        [Range(0, 100)]
        public int DiscountPercentage { get; set; } = 10;

        public int NumberOfDiscountCoupon { get; set; } = 1;

        public DateTime? ExpiryDate { get; set; }
    }

    public class APIResponseModel
    {
        public bool Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}