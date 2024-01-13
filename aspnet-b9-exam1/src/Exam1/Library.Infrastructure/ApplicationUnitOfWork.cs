﻿using Library.Application;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public ApplicationUnitOfWork(IBookRepository bookRepository,IApplicationDbContext dbContext):base((DbContext)dbContext)
        {
            bookRepository = bookRepository;   
        }
    }
}
