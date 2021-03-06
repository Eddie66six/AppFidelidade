﻿using AppFidelidade.Aplicacao.Aplicacao._Comum;
using AppFidelidade.Aplicacao.Aplicacao.Administracao;
using AppFidelidade.Aplicacao.Aplicacao.Cliente;
using AppFidelidade.Aplicacao.Aplicacao.Funcionario;
using AppFidelidade.Dominio._Comum.Interface.Applicacao;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Funcionario.Interface.Applicacao;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Infra.Data;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using AppFidelidade.Infra.Data.Repositorio.Administracao;
using AppFidelidade.Infra.Data.Repositorio.Cliente;
using AppFidelidade.Infra.Data.Repositorio.Funcionario;
using SimpleInjector;

namespace AppFidelidade.Infra.Ioc
{
    public static class SimpleInjectContainer
    {
        public static Container RegistrarIoc()
        {
            var registro = new Container();
            registro.Register<Contexto>();
            registro.Register<ContextoManager>();
            registro.Register<IUnitOfWork, UnitOfWork>();

            #region Compartilhado
            registro.Register<IDomainHandler<DomainNotification>, DomainNotificationHandler>();
            #endregion
            #region Comum
            #region Repositorio
            #endregion
            #region Aplicacao
            registro.Register<IAuthAplicacao, AuthAplicacao>();
            #endregion
            #endregion
            #region Administracao
            #region Repositorio
            registro.Register<IEmpresaRepositorio, EmpresaRepositorio>();
            registro.Register<IFilialRepositorio, FilialRepositorio>();
            registro.Register<IRegraRepositorio, RegraRepositorio>();
            registro.Register<IContratoRepositorio, ContratoRepositorio>();
            #endregion
            #region Aplicacao
            registro.Register<IEmpresaAplicacao, EmpresaAplicacao>();
            registro.Register<IFilialAplicacao, FilialAplicacao>();
            registro.Register<IRegraAplicacao, RegraAplicacao>();
            registro.Register<IContratoAplicacao, ContratoAplicacao>();
            #endregion
            #endregion
            #region Cliente
            #region Repositorio
            registro.Register<IClienteRepositorio, ClienteRepositorio>();
            registro.Register<ICompraRepositorio, CompraRepositorio>();
            registro.Register<IFilialClienteRepositorio, FilialClienteRepositorio>();
            #endregion
            #region Aplicacao
            registro.Register<IClienteAplicacao, ClienteAplicacao>();
            registro.Register<ICompraAplicacao, CompraAplicacao>();
            registro.Register<IFilialClienteAplicacao, FilialClienteAplicacao>();
            #endregion
            #endregion
            #region Funcionario
            #region Repositorio
            registro.Register<IFuncionarioRepositorio, FuncionarioRepositorio>();
            #endregion
            #region Aplicacao
            registro.Register<IFuncionarioAplicacao, FuncionarioAplicacao>();
            #endregion
            #endregion
            return registro;
        }
    }
}