using CommonTools;
using System;
using System.Windows.Forms;

namespace ConfigurationUI
{
    public partial class EditorForm : Form
    {
        #region Consts
        /// <summary>
        /// filter for configuratino files
        /// </summary>
        private const string XML_FILTER = "XML Files |*.xml"; 
        #endregion

        #region Data Members
        /// <summary>
        /// the type of configurationo bject being edited
        /// </summary>
        private Type mExpConfigurationObjectType;

        /// <summary>
        /// The actual configruation object being edited
        /// </summary>
        private object mExpConfiguration;

        /// <summary>
        /// the repository to save configruation object ot and retrieve it from.
        /// </summary>
        private IConfigurationRepository mRepository;

        #endregion

        #region Ctors``
        public EditorForm(Type expConfigurationObjectType)
        {
            InitializeComponent();
            mExpConfigurationObjectType = expConfigurationObjectType;
            ConfiguartionUtilities.SetPropertyGridRowHeight(propertyGrid_Editor, 25);
        }
        #endregion

        #region Functions

        private void EditorForm_Load(object sender, EventArgs e)
        {
            // try creating file repository and lcreating the configuratino object being edited
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

            // populate the property grid with created configuration object
            propertyGrid_Editor.SelectedObject = mExpConfiguration;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // get configuratino file with file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = XML_FILTER;
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // get confgiuratino object from configuration file XML
                    mRepository.Connect(ofd.FileName);
                    mExpConfiguration = mRepository.GetObject(mExpConfigurationObjectType);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed loading configuration file. exception : " + ex.Message);
                return;
            }
            // populate property grid
            propertyGrid_Editor.SelectedObject = mExpConfiguration;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // get path to save conf file to
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = XML_FILTER;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // save conf object to file file
                    mRepository.Save(mExpConfiguration, sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed saving configuration file. exception : " + ex.Message);
                }

            }
        }

        #endregion
    }
}
