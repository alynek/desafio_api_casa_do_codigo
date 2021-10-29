﻿using DesafioCasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioCasaDoCodigo.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> opt) : base(opt){}

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Nome)
                .IsUnique();
        }
    }
}
