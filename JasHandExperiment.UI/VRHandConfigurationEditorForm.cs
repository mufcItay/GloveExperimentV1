using CommonTools;
using JasHandExperiment.Configuration;
using System;
using System.Windows.Forms;

namespace JasHandExperiment.UI
{

    [ConfigurationEditor(typeof(VRHandConfiguration))]
    public partial class VRHandConfigurationEditorForm : Form
    {
        private VRHandConfiguration mConfigurationObject;
        public VRHandConfiguration ConfigurationObject
        {
            get
            {
                return mConfigurationObject;
            }
            set
            {
                mConfigurationObject = value;
                mCurrentConfiguration = new VRHandConfiguration(mConfigurationObject);
                vrHandEditorControl.ConfigurationObject = mConfigurationObject;
            }
        }

        private VRHandConfiguration mCurrentConfiguration;
        public VRHandConfigurationEditorForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            mConfigurationObject.UpdateContents(vrHandEditorControl.ConfigurationObject);
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
