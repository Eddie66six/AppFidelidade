﻿using AppFidelidade.Dominio.Cliente.Entidade;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class CompraBasicoViewModel
    {
        public CompraBasicoViewModel()
        {

        }
        public CompraBasicoViewModel(Compra obj)
        {
            IdCompra = obj.IdCompra;
        }
        public long IdCompra { get; set; }
    }
}
