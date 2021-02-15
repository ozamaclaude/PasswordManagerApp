using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PasswordManagerApp.ViewModels
{
    public class ServiceDialogViewModel : BindableBase, IDialogAware
    {
        private string _title = "Notification";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand CloseCommand { get; private set; }

        public event Action<IDialogResult> RequestClose;
        public ServiceDialogViewModel()
        {
            CloseCommand = new DelegateCommand(CloseDialog);
        }

        private string _mainMessage = "";
        public string MainMessage
        {
            get { return _mainMessage; }
            set { SetProperty(ref _mainMessage, value); }
        }

        private void CloseDialog()
        {
            IDialogResult dialogResult = new DialogResult(ButtonResult.OK);
            this.RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var aaa = 1;
            MainMessage = parameters.GetValue<string>("Message1");
            var isWarn = parameters.GetValue<string>("Message2");
            if (isWarn == "True")
            {
                Title = "通知";
                return;
            }
            Title = "エラー";

        }

    }
}
