﻿using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        bool CategoriaExiste(Categoria categoria);
        void Save(Categoria categoria);
    }
}
