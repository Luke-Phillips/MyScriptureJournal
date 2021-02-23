using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.ScriptureJournalEntries
{
    public class DeleteModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public DeleteModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScriptureJournalEntry ScriptureJournalEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureJournalEntry = await _context.ScriptureJournalEntry.FirstOrDefaultAsync(m => m.ScriptureJournalEntryID == id);

            if (ScriptureJournalEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureJournalEntry = await _context.ScriptureJournalEntry.FindAsync(id);

            if (ScriptureJournalEntry != null)
            {
                _context.ScriptureJournalEntry.Remove(ScriptureJournalEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
