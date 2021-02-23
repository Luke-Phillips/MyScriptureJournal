using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.ScriptureJournalEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.ScriptureJournalEntry.AddRange(
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "1 Nephi",
                        Chapter = "1",
                        Verse = "1",
                        Note = "Despite having many afflictions in his life, Nephi feels blessed and grateful"
                    },
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "John",
                        Chapter = "3",
                        Verse = "16",
                        Note = "For God so loved the world... a classic"
                    },
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "James",
                        Chapter = "1",
                        Verse = "5",
                        Note = "The passage of scripture that moved Joseph to act"
                    },
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "D&C",
                        Chapter = "6",
                        Verse = "36",
                        Note = "This apparent command feels more like a peaceful assurance that we need not doubt nor fear"
                    },
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "James",
                        Chapter = "2",
                        Verse = "17",
                        Note = "This verse and the next show an interesting relationship between faith and works. It's really not possible to have one without the other if you have knowledge of all God wants you to do."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}