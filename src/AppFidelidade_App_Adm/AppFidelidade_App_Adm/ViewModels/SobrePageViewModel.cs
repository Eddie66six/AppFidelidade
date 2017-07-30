using AppFidelidade_App_Adm.Models.Filiais;
using Prism.Services;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class SobrePageViewModel : BaseViewModel
    {
        private readonly IPageDialogService _dialogService;
        private bool _adm;

        public bool Adm
        {
            get { return _adm; }
            set { SetProperty(ref _adm, value); }
        }
        public SobrePageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            Adm = false;
        }

        private InformcoesBasicaFilial _informcoesBasicaFilial;

        public InformcoesBasicaFilial InformcoesBasicaFilial
        {
            get { return _informcoesBasicaFilial; }
            set { SetProperty(ref _informcoesBasicaFilial, value); }
        }


        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            if (Data.ObterTipoFuncionario() == 1)
            {
                Adm = true;
                var api = new Services.AppFidelidadeService(Data.ObterToken());
                var result = await api.ObterInformacoesBasicasFilial(Data.ObterIdFilial(), Data.ObterIdFuncionario());
                if (result == null || result.Item1 != null)
                {
                    await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                    AtivarLoad(false);
                }
                else
                {
                    InformcoesBasicaFilial = result.Item2;
                }
            }
            AtivarLoad(false);
        }
    }
}
