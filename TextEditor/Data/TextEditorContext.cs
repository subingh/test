using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TextEditor.Models;

namespace TextEditor.Data
{
    public class TextEditorContext : DbContext
    {
        public TextEditorContext (DbContextOptions<TextEditorContext> options)
            : base(options)
        {
        }

        public DbSet<TextEditor.Models.Doc> Doc { get; set; } = default!;
    }
}
