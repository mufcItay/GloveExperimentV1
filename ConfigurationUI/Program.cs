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
        #region Consts
        /// <summary>
        /// the key for selected configuration object type to be created for the editor form
        /// </summary>
        private const string ROOT_CONFIGURATION_TYPE = "selectedObjectAssemblyQualifiedName";

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // init form and configuration object of it
            Form confForm = null;
            Type expConfigurationObjectType = null;

            // load assemblies so we will be able to create the editor and conf object dynamically
            if (!LoadAssemblies(Directory.GetCurrentDirectory()))
            {
                return;
            }

            try
            {
                // try identifying the type of configuration object in use
                string configurationObjTypeName = ConfigurationManager.AppSettings[ROOT_CONFIGURATION_TYPE];
                expConfigurationObjectType = Type.GetType(configurationObjTypeName);
            }
            catch (ConfigurationErrorsException confEx)
            {
                MessageBox.Show("Failed reading the configuration object type from App.config: " + " exception :" + confEx.Message);
                return;
            }
            // get the attribute that indicated editor-conf object connection
            var editorAttr = expConfigurationObjectType.GetCustomAttributes(typeof(ConfigurationEditorAttribute), false);

            if (expConfigurationObjectType.BaseType == typeof(Form))
            {
                // create the CONFIGURATION OBJECT
                confForm = Activator.CreateInstance(expConfigurationObjectType) as Form;
            }
            else // attribute of non form
            {
                if (editorAttr.Any())
                {
                    // create the form
                    ConfigurationEditorAttribute attr = editorAttr.First() as ConfigurationEditorAttribute;
                    string formTypeName = attr.ObjectType.AssemblyQualifiedName;
                    confForm = Activator.CreateInstance(Type.GetType(formTypeName)) as Form;
                }
                else
                {
                    // CREATE EDITOR FORM WITH CONF OBJECT AS A PARAMETER
                    confForm = new EditorForm(expConfigurationObjectType);
                }
            }
            
            Application.Run(confForm);
        }

        /// <summary>
        /// The function loads assemblies in current directory,
        /// in order to be able to create editor and conf object dynamically using reflection.
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>boolean indicating successful operation</returns>
        private static bool LoadAssemblies(string folderPath)
        {
            // serach recursivley for dlls
            string[] dllsInCD = Directory.GetFiles(folderPath, "*.dll",SearchOption.AllDirectories);
            if (dllsInCD.Length == 0)
            {
                MessageBox.Show("No dlls in directory, unable to find configuration object to load");
                return false;
            }
            // load each dll, if error occured ignore it
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
