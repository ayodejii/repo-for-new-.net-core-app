using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BopHubData.Model
{
    public class Attendance
    {
        public Bop Bop { get; set; }
        public Account Attendee { get; set; }

        [Column(Order = 1)]
        public int BopId { get; set; }
        [Column(Order = 2)]
        public int AttendeeId { get; set; }
    }
}
