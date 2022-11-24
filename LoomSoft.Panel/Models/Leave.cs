namespace LoomSoft.Panel.Models
{
    public class Leave : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int TimeType { get; set; } // İzin Tipi
        public int LeaveType { get; set; } // İzin Sebebi
        public string Reason { get; set; } // İzin Nedeni
        public int RangeType { get; set; } // SüreAralığı
        public DateTime StartTime { get; set; } // Başlangıç Zamanı
        public DateTime EndTime { get; set; } // Bitiş Zamanı
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? Situation { get; set; }
        public int? Result { get; set; }

        public Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual List<LeaveStep> LeaveSteps { get; set; }

    }
}
