using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TextEditor1.Models;

namespace TextEditor1.Data
{
    public class TextEditor1Context : DbContext
    {
        public TextEditor1Context (DbContextOptions<TextEditor1Context> options)
            : base(options)
        {
        }

        public DbSet<TextEditor1.Models.Doc> Doc { get; set; } = default!;
    }
}
