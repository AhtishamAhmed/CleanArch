using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Student> students_tbl { get; set; }
        DbSet<Book> book_tbl { get; set; }
        DbSet<FavouriteBook> favouriteBook_tbl { get; set; }

        Task<int> SaveChangesAsync();
    }
}