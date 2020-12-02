using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExampleMaterialDesignControls.Pages
{
    internal class newCommand : ICommand
    {
        private Func<Task> p;

        public newCommand(Func<Task> p)
        {
            this.p = p;
        }
    }
}