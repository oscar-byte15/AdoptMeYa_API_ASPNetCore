﻿using GrupoWebBackend.Shared.Persistence.Context;

namespace GrupoWebBackend.Shared.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}