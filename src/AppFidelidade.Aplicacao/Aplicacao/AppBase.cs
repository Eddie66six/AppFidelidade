using AppFidelidade.Dominio._Comum.Interface.Repositorio;

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
            return _unitOfWork.Commit();
        }
    }
}
