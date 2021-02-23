using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using System;
// using MyScriptureJournal.Data;


namespace MyScriptureJournal.Pages.ScriptureJournalEntries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<ScriptureJournalEntry> ScriptureJournalEntry { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool isSortedByBook { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public SelectList Books { get; set; }
       
        [BindProperty(SupportsGet = true)]       
        public string Book { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from e in _context.ScriptureJournalEntry
                                           orderby e.Book
                                           select e.Book;

            IQueryable<ScriptureJournalEntry> scriptureJournalEntries = isSortedByBook ?
                                          from e in _context.ScriptureJournalEntry
                                          orderby e.Book
                                          select e :
                                          from e in _context.ScriptureJournalEntry
                                          orderby e.Date
                                          select e;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptureJournalEntries = scriptureJournalEntries
                    .Where(s => s.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Book))
            {
                scriptureJournalEntries = scriptureJournalEntries.Where(s => s.Book == Book);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            ScriptureJournalEntry = await scriptureJournalEntries.ToListAsync();
        }
    }
}
