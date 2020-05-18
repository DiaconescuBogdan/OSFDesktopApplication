namespace OSFProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        public int CarID { get; set; }

        public int CostumerID { get; set; }

        public byte ReservStatsID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(10)]
        public string CouponCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }

        public virtual Car Car { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual ReservationStatus ReservationStatus { get; set; }
    }
}
