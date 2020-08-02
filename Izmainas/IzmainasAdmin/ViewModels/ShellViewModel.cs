using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IzmainasAdmin.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<RecordsViewModel>(), new CancellationToken());
        }

        public async Task ViewAll()
        {
            await ActivateItemAsync(IoC.Get<RecordsViewModel>(), new CancellationToken());
        }
    }
}
