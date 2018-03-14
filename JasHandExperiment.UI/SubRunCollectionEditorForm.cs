using CommonTools;
using JasHandExperiment.Configuration;
using System;
using System.Windows.Forms;

namespace JasHandExperiment.UI
{
    public partial class SubRunCollectionEditorForm : Form
    {
        private SubRunCollection mCurrentConfiguration;

        private SubRunCollection mConfigurationObject;
        public SubRunCollection ConfigurationObject
        {
            get
            {
                return mConfigurationObject;
            }
            set
            {
                mConfigurationObject = value;
                if(value == null)
                {
                    return;
                }
                mCurrentConfiguration = new SubRunCollection(mConfigurationObject);
                subRunEditorControl.ConfigurationObject = mConfigurationObject;
            }
        }

        public SubRunCollectionEditorForm()
        {
            InitializeComponent();
        }
        
        private void button_OK_Click(object sender, EventArgs e)
        {
            mConfigurationObject.UpdateContents(mCurrentConfiguration);
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
