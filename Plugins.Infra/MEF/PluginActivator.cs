using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;

[assembly: PreApplicationStartMethod(typeof(Phidelis.Portal.Responsavel.MEF.PluginActivator), "Initialize")]
namespace Phidelis.Portal.Responsavel.MEF
{
    public class PluginActivator
    {
        private static readonly DirectoryInfo PluginFolderInfo;

        static PluginActivator()
        {
            PluginFolderInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/plugins"));
        }

        public static void Initialize()
        {
            if (!PluginActivator.PluginFolderInfo.Exists)
                PluginActivator.PluginFolderInfo.Create();

            CopyPluginDlls(PluginFolderInfo, AppDomain.CurrentDomain.DynamicDirectory);
            LoadPluginAssemblies(AppDomain.CurrentDomain.DynamicDirectory);
        }

        private static void CopyPluginDlls(DirectoryInfo sourceFolder, string destinationFolder)
        {
            foreach (var plug in sourceFolder.GetFiles("*.dll", SearchOption.AllDirectories))
            {
                if (!File.Exists(Path.Combine(destinationFolder, plug.Name)))
                {
                    File.Copy(plug.FullName, Path.Combine(destinationFolder, plug.Name), false);
                }
            }
        }

        private static void LoadPluginAssemblies(string dynamicDirectory)
        {
            foreach (var plug in Directory.GetFiles(dynamicDirectory, "*.dll", SearchOption.AllDirectories))
            {
                Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(plug));
                BuildManager.AddReferencedAssembly(assembly);
            }
        }
    }
}
