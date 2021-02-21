using PasswordManagerApp.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerApp.Services
{
    interface IAccountFileReader
    {
        void SayHello();
        List<Account> ReadFile();
        void FlushContents();
        void WriteFile(List<Account> accounts, bool isSnap = false);
    }

    class AccountFileReader : IAccountFileReader
    {
        public void SayHello() { Debug.WriteLine("Hello world!"); }

        public void WriteFile(List<Account> accounts, bool isSnap = false)
        {
            var path = Properties.Settings.Default.accountfile_path;
            if (isSnap) 
            {
                var fileName =DateTime.Now.ToString("yyyyMMddHHmmss_");
                fileName += "snapshot.csv";
                path = Path.Combine(Properties.Settings.Default.snapshot_path, fileName); 
            }

            using (var fileStream = new StreamWriter(path, true))
            {
                accounts.ForEach(x => Write(fileStream, x));
            }
            
        }
        private void Write(StreamWriter fs, Account at)
        {
            fs.WriteLine("{0},{1},{2}", at.AccountTitle, at.UserId, at.Password);
        }

        public void FlushContents()
        {
            var path = Properties.Settings.Default.accountfile_path;
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                // ファイルサイズを0に設定
                fileStream.SetLength(0);
            }
        }

        public List<Account> ReadFile()
        {
            var path = Properties.Settings.Default.accountfile_path;
            if (File.Exists(path) == false) 
            {
                Debug.WriteLine("file not found");
                return null;
            }
            var lines = File.ReadAllLines(path);

            var accounts = new List<Account>();

            foreach (var l in lines)
            {
                var splitted = l.Split(',');
                var cnt = splitted.Length;
                if (splitted.Length < 3) { continue; }
                accounts.Add(new Account
                {
                    AccountTitle = splitted[0],
                    UserId = splitted[1],
                    Password = splitted[2]
                });
            }

            return accounts;
        }
    }
}
