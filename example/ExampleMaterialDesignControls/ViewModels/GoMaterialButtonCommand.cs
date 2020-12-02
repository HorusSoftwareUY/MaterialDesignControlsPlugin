using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
    internal class GoMaterialButtonCommand : ICommand
    {
        private Func<Task> p;

        public GoMaterialButtonCommand(Func<Task> p)
        {
            this.p = p;
        }
    }
}