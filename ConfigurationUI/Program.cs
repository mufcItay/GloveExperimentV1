using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CommonTools;

namespace ConfigurationUI
{
    static class Program
    {
        private const string ROOT_CONFIGURATION_TYPE = "selectedObjectAssemblyQualifiedName";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Object confObj = null;
            Form confForm = null;
            Type expConfigurationObjectType = null;
            if (!LoadAssemblies(Directory.GetCurrentDirectory()))
            {
                return;
            }

            try
            {
                string configurationObjTypeName = ConfigurationManager.AppSettings[ROOT_CONFIGURATION_TYPE];
                expConfigurationObjectType = Type.GetType(configurationObjTypeName);
            }
            catch (ConfigurationErrorsException confEx)
            {
                MessageBox.Show("Failed reading the configuration object type from App.config: " + " exception :" + confEx.Message);
                return;
            }
            var editorAttr = expConfigurationObjectType.GetCustomAttributes(typeof(ConfigurationEditorAttribute), false);

            if (expConfigurationObjectType.BaseType == typeof(Form))
            {
                confForm = Activator.CreateInstance(expConfigurationObjectType) as Form;
            }
            else // attribute of non form
            {
                if (editorAttr.Any())
                {
                    ConfigurationEditorAttribute attr = editorAttr.First() as ConfigurationEditorAttribute;
                    string formTypeName = attr.ObjectType.AssemblyQualifiedName;
                    confForm = Activator.CreateInstance(Type.GetType(formTypeName)) as Form;
                }
                else
                {
                    confObj = new EditorForm(expConfigurationObjectType);
                }
            }
            
            Application.Run(confForm);
        }

        private static bool LoadAssemblies(string folderPath)
        {
            string[] dllsInCD = Directory.GetFiles(folderPath, "*.dll");
            if (dllsInCD.Length == 0)
            {
                MessageBox.Show("No dlls in directory, unable to find configuration object to load");
                return false;
            }
            foreach (string dll in dllsInCD)
            {
                try
                {
                    Assembly.LoadFrom(dll);
                }
                catch (Exception)
                {
                    // write to log
                    //MessageBox.Show("load assembly error :" + e.Message);
                }
            }

            return true;
        }


    }
}
