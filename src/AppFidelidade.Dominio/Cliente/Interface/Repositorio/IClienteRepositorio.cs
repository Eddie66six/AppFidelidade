﻿using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Interface.Repositorio
{
    public interface IClienteRepositorio : IBaseRepositorio<Entidade.Cliente>
    {
        Entidade.Cliente ObterPorId(int id, string[] includes);
        List<Entidade.Cliente> ObterPorFilial(int idFilial, string[] includes);
        Entidade.Cliente ObeterPorTokenId(string tokenId, string[] includes);
        bool VerificaSeTokenIdJaExiste(string tokenId);
        decimal ObterTotalCreditosCliente(int idCliente);
        Entidade.Cliente ObterPorAuth(string userId);
    }
}