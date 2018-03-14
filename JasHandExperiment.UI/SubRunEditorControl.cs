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
        private const string XML_FILTER = "XML Files |*.xml";

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
                if (value == null)
                {
                    return;
                }
                propertyGrid_Collection.SelectedObject = mConfigurationObject;
            }
        }

        public SubRunEditorControl()
        {
            InitializeComponent();
        }
        
        private void button_Save_Click(object sender, EventArgs e)
        {
            FileRepository saveRepository = new FileRepository();
            SubRunConfiguration subRunToSave = propertyGrid_Collection.SelectedGridItem.Value as SubRunConfiguration;
            if (subRunToSave != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "";
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
                mConfigurationObject.Add(loadedsubRun);
            }
            propertyGrid_Collection.SelectedObject = mConfigurationObject;
        }
        
        private void button_Add_Click(object sender, EventArgs e)
        {
            SubRunConfiguration subRunToSave = new SubRunConfiguration();
            if (subRunToSave != null)
            {
                mConfigurationObject.Add(subRunToSave);
            }

            propertyGrid_Collection.SelectedObject = mConfigurationObject;
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            SubRunConfiguration subRunToRemove = propertyGrid_Collection.SelectedGridItem.Value as SubRunConfiguration;
            if (subRunToRemove != null)
            {
                mConfigurationObject.Remove(subRunToRemove);
            }
            propertyGrid_Collection.SelectedObject = mConfigurationObject;
        }

        public void XMLHandlingVisible(bool visible)
        {
            button_Load.Visible = visible;
            button_Save.Visible = visible;
        }

    }
}
