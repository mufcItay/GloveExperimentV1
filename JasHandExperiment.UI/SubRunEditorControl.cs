using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment.UI
{
    public partial class SubRunEditorControl : UserControl
    {
        #region Consts
        private const string XML_FILTER = "XML Files |*.xml";

        #endregion

        #region Data Members
        /// <summary>
        /// The configration object being edited
        /// </summary>
        private SubRunCollection mConfigurationObject;

        /// <summary>
        /// property to react to conf object set by updating GUI
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
                //populate propert grid
                propertyGrid_Collection.SelectedObject = mConfigurationObject;
            }
        }
        #endregion

        #region Ctors
        public SubRunEditorControl()
        {
            InitializeComponent();
            ConfiguartionUtilities.SetPropertyGridRowHeight(propertyGrid_Collection, 25);
        }
        #endregion

        #region Functions
        private void button_Save_Click(object sender, EventArgs e)
        {
            // CURRENTLY UNUSED

            // create repository and save subrun to file
            FileRepository saveRepository = new FileRepository();
            SubRunConfiguration subRunToSave = propertyGrid_Collection.SelectedGridItem.Value as SubRunConfiguration;
            if (subRunToSave != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = XML_FILTER;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        saveRepository.Save(subRunToSave, sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed saving configuration file. exception : " + ex.Message);
                    }
                }
                return;
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            // CURRENTLY UNUSED

            // read sub run from file 
            FileRepository loadRepository = new FileRepository();
            SubRunConfiguration loadedsubRun = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = XML_FILTER;
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    loadRepository.Connect(ofd.FileName);
                    loadedsubRun = loadRepository.GetObject<SubRunConfiguration>();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed loading configuration file. exception : " + ex.Message);
                return;
            }
            if (loadedsubRun != null)
            {
                // add sub run to configuration
                mConfigurationObject.Add(loadedsubRun);
            }
            //refresh GUI
            propertyGrid_Collection.SelectedObject = mConfigurationObject;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            // create new subrun
            SubRunConfiguration subRunToSave = new SubRunConfiguration();
            if (subRunToSave != null)
            {
                // add to configuratino object
                mConfigurationObject.Add(subRunToSave);
            }
            //refresh GUI
            propertyGrid_Collection.SelectedObject = mConfigurationObject;
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            // get selected sub runs
            SubRunConfiguration subRunToRemove = propertyGrid_Collection.SelectedGridItem.Value as SubRunConfiguration;
            if (subRunToRemove != null)
            {
                // remove from configuration
                mConfigurationObject.Remove(subRunToRemove);
            }
            //refresh GUI
            propertyGrid_Collection.SelectedObject = mConfigurationObject;
        }

        /// <summary>
        /// Yet to be used. makes saving sub runs to files invisible/visible
        /// </summary>
        /// <param name="visible"></param>
        public void XMLHandlingVisible(bool visible)
        {
            button_Load.Visible = visible;
            button_Save.Visible = visible;
        }

        #endregion
    }
}
