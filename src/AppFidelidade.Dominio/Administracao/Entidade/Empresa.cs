﻿using System;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Empresa
    {
        protected Empresa()
        {
            Filiais = new List<Filial>();
        }
        public Empresa(string nome)
        {
            Filiais = new List<Filial>();
            Nome = nome;
        }

        public Filial CriarFilial(Filial filial)
        {
            Filiais.Add(filial);
            return filial;
        }

        #region Metodos
        public void Excluir()
        {
            DataExclusao = DateTime.UtcNow;
        }
        #endregion
        #region attr
        public int IdEmpresa { get; private set; }
        public string Nome { get; private set; }
        public DateTime? DataExclusao { get; private set; }
        public List<Filial> Filiais { get; private set; }
        #endregion
    }
}
