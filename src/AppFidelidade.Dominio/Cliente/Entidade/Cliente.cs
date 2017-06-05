﻿using AppFidelidade.Dominio.Administracao.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Cliente
    {
        protected Cliente()
        {
            Filiais = new List<FilialCliente>();
            Compras = new List<Compra>();
        }
        public Cliente(string nome)
        {
            Filiais = new List<FilialCliente>();
            Compras = new List<Compra>();
            Nome = nome;
        }

        #region Metodos
        public decimal ObterCreditoNaFilial(Filial filial)
        {
            var creditoCompras = Compras.Where(p => p.Filial == filial && p.ValorRestanteCredito > 0);
            if (creditoCompras == null)
                return 0;
            return creditoCompras.Sum(p => p.ValorRestanteCredito);
        }
        public bool RetirarCredito(decimal valor, Filial filial)
        {
            if (ObterCreditoNaFilial(filial) < valor)
                return false;
            foreach (var item in Compras.Where(p => p.Filial == filial && p.ValorRestanteCredito > 0))
            {
                var credito = valor - item.ValorRestanteCredito;
                if (credito <= 0)
                {
                    item.RetirarCredito(valor);
                    break;
                }
                else
                {
                    item.RetirarCredito(item.ValorRestanteCredito);
                }

            }
            return true;
        }
        #endregion
        #region attr
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public List<Compra> Compras { get; private set; }
        public List<FilialCliente> Filiais { get; private set; }
        #endregion
    }
}
