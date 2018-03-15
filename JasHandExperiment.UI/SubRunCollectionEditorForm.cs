using CommonTools;
using JasHandExperiment.Configuration;
using System;
using System.Windows.Forms;

namespace JasHandExperiment.UI
{
    public partial class SubRunCollectionEditorForm : Form
    {
        #region Data Members
        /// <summary>
        /// The current configuration object, visible to this control only.
        /// only when user finished editing it will update the general confgiuratino object
        /// </summary>
        private SubRunCollection mCurrentConfiguration;

        /// <summary>
        /// the configuation object being edited
        /// </summary>
        private SubRunCollection mConfigurationObject;

        /// <summary>
        /// property to react to confgiuration object set by updating inner GUI controls and conf objects
        /// </summary>
        public SubRunCollection ConfigurationObject
        {
            get
            {
                return mConfigurationObject;
            }
            set
            {
                mConfigurationObject = value;
                if (value == null)
                {
                    return;
                }
                mCurrentConfiguration = new SubRunCollection(mConfigurationObject);
                subRunEditorControl.ConfigurationObject = mConfigurationObject;
            }
        }
        #endregion

        #region Ctors

        public SubRunCollectionEditorForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void button_OK_Click(object sender, EventArgs e)
        {
            // if user finished editing, update configuration object
            mConfigurationObject.UpdateContents(mCurrentConfiguration);
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            // close without updating configruation
            Close();
        } 
        #endregion
    }
}
