using CommonTools;
using JasHandExperiment.Configuration;
using System;
using System.Windows.Forms;

namespace JasHandExperiment.UI
{

    [ConfigurationEditor(typeof(VRHandConfiguration))]
    public partial class VRHandConfigurationEditorForm : Form
    {
        #region Data Members
        /// <summary>
        /// the configuration object being edited
        /// </summary>
        private VRHandConfiguration mConfigurationObject;

        /// <summary>
        /// property to react to configuration object set
        /// </summary>
        public VRHandConfiguration ConfigurationObject
        {
            get
            {
                return mConfigurationObject;
            }
            set
            {
                // switch between old and new configuration and set gui controls accordingly
                mConfigurationObject = value;
                mCurrentConfiguration = new VRHandConfiguration(mConfigurationObject);
                vrHandEditorControl.ConfigurationObject = mConfigurationObject;
            }
        }

        /// <summary>
        /// current configuration being edited, available only for this control not directly affect ExperimentConfigurationObject
        /// </summary>
        private VRHandConfiguration mCurrentConfiguration;

        #endregion
        #region Ctors
        public VRHandConfigurationEditorForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void button_OK_Click(object sender, EventArgs e)
        {
            // user finished editing, update configuration object
            mConfigurationObject.UpdateContents(vrHandEditorControl.ConfigurationObject);
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            // avoid updating configuration object
            Close();
        } 
        #endregion

    }
}
