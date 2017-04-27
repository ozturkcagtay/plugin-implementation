using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PluginBusiness
    {
        #region Singleton Section
        private static PluginBusiness instance;
        private PluginBusiness() { }
        public static PluginBusiness Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PluginBusiness();
                }
                return instance;
            }
        }
        #endregion

        #region Station Fields
        string _path = System.AppDomain.CurrentDomain.BaseDirectory;
        #endregion

        public ICollection<IPlugin> ListPlugins()
        {
            try
            {
                string[] dllFileList = null;
                var pluginList = new List<IPlugin>();
                var assemblies = new List<Assembly>();

                #region Validations
                if (Directory.Exists(_path) == false)
                {
                    throw new Exception(String.Format("Directory not found ! {0}",_path));
                }
                #endregion

                #region List Dll File Names
                dllFileList = Directory.GetFiles(String.Format("{0}\\{1}",_path,"Plugins"),"*.dll");
                #endregion

                #region Get Assemblies With Reflection
                foreach(string dll in dllFileList)
                {
                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(dll);
                    Assembly assembly = Assembly.Load(assemblyName);
                    assemblies.Add(assembly);
                }
                #endregion

                #region Get Plugins from Assemblies
                Type pluginType = typeof(IPlugin);
                ICollection<Type> pluginTypes = new List<Type>();

                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();
                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }

                ICollection<IPlugin> plugins = new List<IPlugin>(pluginTypes.Count);
                
                foreach (Type type in pluginTypes)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }
                #endregion

                return plugins;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
