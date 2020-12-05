using Plugins.Infra.Contracts;
using Plugins.Infra.Contracts.Rotinas.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Phidelis.Core.MEF
{
    public sealed class PluginManager
    {
        private static PluginManager _instance;
        public static PluginManager Instance()
        {
            if (_instance == null)
                _instance = new PluginManager();
            return _instance;
        }

        private PluginManager() { }
        private AggregateCatalog Catalog { get; set; }
        private CompositionContainer Container { get; set; }

        IEnumerable<Lazy<IMenu>> _menus;
        [ImportMany(typeof(IMenu))]
        public IEnumerable<Lazy<IMenu>> Menus
        {
            get
            {
                if (_menus == null)
                    _menus = new List<Lazy<IMenu>>();

                return _menus;
            }
            set
            {
                _menus = value;
            }
        }

        IEnumerable<Lazy<IRotinaInjection>> _rotinasInjection;
        [ImportMany(typeof(IRotinaInjection))]
        public IEnumerable<Lazy<IRotinaInjection>> RotinasInjection
        {
            get
            {
                if (_rotinasInjection == null)
                    _rotinasInjection = new List<Lazy<IRotinaInjection>>();

                return _rotinasInjection;
            }
            set
            {
                _rotinasInjection = value;
            }
        }

        IEnumerable<Lazy<IModuloInjection>> _modulosInjection;
        [ImportMany(typeof(IModuloInjection))]
        public IEnumerable<Lazy<IModuloInjection>> ModulosInjection
        {
            get
            {
                if (_modulosInjection == null)
                    _modulosInjection = new List<Lazy<IModuloInjection>>();

                return _modulosInjection;
            }
            set
            {
                _modulosInjection = value;
            }
        }

        public void Initialize(string pluginPath)
        {
            this.Catalog = new AggregateCatalog(
                    new AssemblyCatalog(typeof(PluginManager).Assembly)
                    , new DirectoryCatalog(pluginPath, "Plugin.*.dll")
                );
            this.Container = new CompositionContainer(this.Catalog);
            this.Container.ComposeParts(this);
        }
    }
}
