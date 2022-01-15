﻿using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface ICompraRepository
    {
        void Salva(Compra compra);
        Compra Obter(int compraId);
    }
}
