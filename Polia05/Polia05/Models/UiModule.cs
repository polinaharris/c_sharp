using JetBrains.Annotations;
using System.Diagnostics;

namespace Polia05.Models
{
    public class UiModule
    {
        private readonly ProcessModule _module;

        public string Name => _module.ModuleName;
        public string Path => _module.FileName;

        internal UiModule([NotNull] ProcessModule module)
        {
            _module = module;
        }

        public override bool Equals(object obj)
        {
            return obj is UiModule another && this._module.Equals(another._module);
        }

        public override int GetHashCode()
        {
            return _module.GetHashCode();
        }
    }
}
