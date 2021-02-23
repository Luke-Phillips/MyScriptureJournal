using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/

namespace MyScriptureJournal.Models
{
    public class ScriptureJournalEntry
    {
        public int ScriptureJournalEntryID { get; set; }

        [Display(Name = "Date Added"), DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Book { get; set; }

        [RegularExpression(@"^[1-9][0-9]*(-[1-9][0-9]*)?$")]
        [Required]
        public string Chapter { get; set; }

        [RegularExpression(@"^[1-9][0-9]*(-[1-9][0-9]*)?$")]
        [Required]
        public string Verse { get; set; }

        public string Note { get; set; }
    }
}
