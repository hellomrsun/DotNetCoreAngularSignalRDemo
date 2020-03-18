using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignalrDotnetCoreApi.Database.Entities
{
    [Table("MembershipVsBenefit", Schema = "dbo")]
    public class MembershipVsBenefit
    {
        [Key, Column(Order =0)]
        [ForeignKey("Benefit")]
        public int BenefitId { get; set; }

        public Benefit Benefit { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Membership")]
        public int MembershipId { get; set; }

        public Membership Membership { get; set; }
    }
}
