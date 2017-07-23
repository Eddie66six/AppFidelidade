using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;

namespace AppFidelidade.Aplicacao.Aplicacao
{
    public class AppBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected AppBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Commit()
        {
            if (DomainEvent._domainNotificationHandler.HasNotifications())
                return false;
            return _unitOfWork.Commit();
        }
    }
}
