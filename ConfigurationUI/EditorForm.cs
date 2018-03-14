using CommonTools;
using System;
using System.Windows.Forms;

namespace ConfigurationUI
{
    public partial class EditorForm : Form
    {
        private const string XML_FILTER = "XML Files |*.xml";
        private Type mExpConfigurationObjectType;
        private object mExpConfiguration;
        private IConfigurationRepository mRepository;
        public EditorForm(Type expConfigurationObjectType)
        {
            InitializeComponent();
            mExpConfigurationObjectType = expConfigurationObjectType;
            ConfiguartionUtilities.SetPropertyGridRowHeight(propertyGrid_Editor, 25);
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {   
            try
            {
                mRepository = new FileRepository();
                mExpConfiguration = Activator.CreateInstance(mExpConfigurationObjectType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed creating root configuration object. tried to create object : " + mExpConfigurationObjectType + " exception :" + ex.Message);
                Close();
                return;
            }
            
            propertyGrid_Editor.SelectedObject = mExpConfiguration;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = XML_FILTER;
            try
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    mRepository.Connect(ofd.FileName);
                    mExpConfiguration = mRepository.GetObject(mExpConfigurationObjectType);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed loading configuration file. exception : " + ex.Message);
                return;
            }
            propertyGrid_Editor.SelectedObject = mExpConfiguration;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = XML_FILTER;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    mRepository.Save(mExpConfiguration, sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed saving configuration file. exception : " + ex.Message);
                }
                
            }
        }

    }
}
