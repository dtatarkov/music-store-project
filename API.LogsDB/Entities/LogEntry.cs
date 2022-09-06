using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.LogsDB.Entities
{
    [Table("LogEntries")]
    public class LogEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EntryId { get; set; }

        [StringLength(50)]
        public string Application { get; set; } = string.Empty;
        public DateTimeOffset Logged { get; set; } = DateTimeOffset.Now;

        [StringLength(50)]
        public string Level { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        [StringLength(250)]
        public string Logger { get; set; } = string.Empty;
        public string Callsite { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
    }
}
