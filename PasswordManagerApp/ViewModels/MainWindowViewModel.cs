using PasswordManagerApp.Commons;
using PasswordManagerApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace PasswordManagerApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "アカウント管理ツール";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _accountTitle = "";
        public string AccountTitle
        {
            get { return _accountTitle; }
            set { SetProperty(ref _accountTitle, value); }
        }

        private string _accountId = "";
        public string AccountId
        {
            get { return _accountId; }
            set { SetProperty(ref _accountId, value); }
        }

        private string _accountPassword = "";
        public string AccountPassword
        {
            get { return _accountPassword; }
            set { SetProperty(ref _accountPassword, value); }
        }

        private ObservableCollection<Account> _accounts
            = new ObservableCollection<Account>();

        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        private IUnityContainer _container;
        private IAccountFileReader _reader;

        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand RegisterCommand { get; private set; }

        public MainWindowViewModel(IUnityContainer container)
        {
            _container = container;
            Setup();
        }

        private void Setup()
        {
            AddCommand = new DelegateCommand(AddAccount);
            RegisterCommand = new DelegateCommand(RegisterAccounts);

            _reader = _container.Resolve<IAccountFileReader>();
            var readLines = _reader.ReadFile();
            readLines.ForEach(x => Accounts.Add(new Account
            {
                AccountTitle = x.AccountTitle,
                UserId = x.UserId,
                Password = x.Password
            }));
        }

        private void AddAccount()
        {
            if (!IsTargetAccountValid()) { return; }
            Accounts.Add(new Account
            {
                AccountTitle = this.AccountTitle,
                UserId = this.AccountId,
                Password = this.AccountPassword
            });
            ClearTempolaryAccount();
        }

        private bool IsTargetAccountValid()
        {
            if(this.AccountTitle == "" || this.AccountId == "" ) { return false; }
            foreach( var ac in Accounts)
            {
                // タイトルは一意
                if(ac.AccountTitle == this.AccountTitle) { return false; }
            }
            return true;
        }

        private void ClearTempolaryAccount()
        {
            this.AccountTitle = "";
            this.AccountId = "";
            this.AccountPassword = "";
        }

        private void RegisterAccounts()
        {
            _reader.FlushContents();
            _reader.WriteFile(Accounts.ToList());
        }
    }
}
