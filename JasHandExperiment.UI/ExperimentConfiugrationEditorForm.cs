using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment.UI
{
    [ConfigurationEditor(typeof(ExperimentConfiguration))]
    public partial class ExperimentConfiugrationEditorForm : Form
    {
        #region Consts
        private const string CONFIGURATION_FILE_NAME_PATTERN = "subjID" + CONFIGURATION_FILE_NAME_PATTERN_DELIMITER + "groupID" + CONFIGURATION_FILE_NAME_PATTERN_DELIMITER + "sessionID";
        private const string CONFIGURATION_FILE_NAME_PATTERN_DELIMITER = "_";
        private const char DIR_SLASH = '\\';

        private const int SUBJECTID_INDEX = 0;
        private const int GROUPID_INDEX = 1;
        private const int SESSIONID_INDEX = 2;
        private const int DEFAULT_NEW_SESSION_ID = 1;
        private const int DEFAULT_SLEEPING_HOURS = 0;

        #endregion

        #region Data Members

        /// <summary>
        /// The configuration object being edited.
        /// </summary>
        private ExperimentConfiguration mExpConfiguration;

        /// <summary>
        /// list of file names, of currently available configurations saved earlier
        /// </summary>
        private List<String> mSavedConfFiles;

        /// <summary>
        /// dictionary that mapps between subjects to their current session
        /// </summary>
        private Dictionary<String, int> mSubjectToSessionIDDict;

        /// <summary>
        /// remembers last selected subject for GUI puposes
        /// </summary>
        private string mLastSelectedSubject;

        /// <summary>
        /// the repositroey of runtime configuration. here we set the current configruatino fiel of the experiment.
        /// </summary>
        private FileRepository mRuntimeRepository;


        /// <summary>
        /// The runtime confgiruation loaded from runtime repositroy
        /// </summary>
        private RuntimeConfiguration mRuntimeConfiguration;

        #endregion


        #region Ctors

        public ExperimentConfiugrationEditorForm()
        {
            InitializeComponent();
            // create outputfiles directories
            mExpConfiguration = new ExperimentConfiguration();
            mRuntimeRepository = new FileRepository();

            mRuntimeRepository.Connect(RuntimeConfiguration.RUNTIME_CONF_FILE_NAME);
            mRuntimeConfiguration = mRuntimeRepository.GetObject<RuntimeConfiguration>();

            CreateFolders();

            // add a default first sub run
            mExpConfiguration.SubRuns.Add(new SubRunConfiguration());
            mSubjectToSessionIDDict = new Dictionary<string, int>();

            // fill GUI
            FillComboboxes();
            FillGUIData(mExpConfiguration);
            subRunEditorControl.XMLHandlingVisible(false);
        }
        #endregion

        #region Functions
        /// <summary>
        /// The functions creates output files directories if they havn't been created
        /// </summary>
        private void CreateFolders()
        {
            if (!Directory.Exists(mRuntimeConfiguration.PathToSubjectDir))
            {
                Directory.CreateDirectory(mRuntimeConfiguration.PathToSubjectDir);
            }
            if (!Directory.Exists(RuntimeConfiguration.DEFAULT_GLOVE_MOVEMENTS_FOLDER))
            {
                Directory.CreateDirectory(RuntimeConfiguration.DEFAULT_GLOVE_MOVEMENTS_FOLDER);
            }
            if (!Directory.Exists(RuntimeConfiguration.DEFAULT_USER_PRESSES_FOLDER))
            {
                Directory.CreateDirectory(RuntimeConfiguration.DEFAULT_USER_PRESSES_FOLDER);
            }
        }

        /// <summary>
        /// The function fills GUI controls with the configuraton object data.
        /// </summary>
        /// <param name="exp">the configuration object to set data from</param>
        private void FillGUIData(ExperimentConfiguration exp)
        {
            // fill controls
            textBoxSequence.Text = exp.Squence;
            vrHandEditorControl.ConfigurationObject = exp.VRHandConfiguration;
            textBoxAge.Text = exp.ParticipantConfiguration.Age.ToString();
            radioButtonFemale.Checked = exp.ParticipantConfiguration.Gender == GenderType.Female;
            radioButtonMale.Checked = exp.ParticipantConfiguration.Gender == GenderType.Male;
            comboBoxGroupNumber.Text = exp.ParticipantConfiguration.GroupNumber.ToString();
            string subjectNumberStr = exp.ParticipantConfiguration.Number.ToString();
            comboBoxSubjectNumber.Text = subjectNumberStr;
            // handle sessions
            if (exp.SessionsConfiguration.Any())
            {

                textBoxSessionNumber.Text = mSubjectToSessionIDDict[subjectNumberStr].ToString();
                textBoxSleepHours.Text = (exp.SessionsConfiguration.Last().SleepHours).ToString();
            }
            else
            {
                textBoxSessionNumber.Text = DEFAULT_NEW_SESSION_ID.ToString();
                textBoxSleepHours.Text = DEFAULT_SLEEPING_HOURS.ToString();
            }
            // sub runs
            subRunEditorControl.ConfigurationObject = exp.SubRuns;
            // file paths
            textBoxGloveLogFile.Text = exp.OutputFilesConfiguration.GloveMovementLogPath;
            textBoxKeyboardLogFile.Text = exp.OutputFilesConfiguration.UserPressesLogPath;

            string subjectId = exp.ParticipantConfiguration.Number.ToString();
            int confFileSessionId = DEFAULT_NEW_SESSION_ID;
            if (mSubjectToSessionIDDict.ContainsKey(subjectId))
            {
                confFileSessionId = mSubjectToSessionIDDict[subjectId];
            }
            string fileName = GetConfigurationFilePath(subjectId, exp.ParticipantConfiguration.GroupNumber.ToString(), confFileSessionId.ToString());
            textBoxCurretConfFile.Text = fileName;

            // handle experiment type
            SetExperimentTypeControlsState(exp);
        }

        /// <summary>
        /// The function fils comboboxes of the gui
        /// </summary>
        private void FillComboboxes()
        {
            comboBoxGroupNumber.Text = string.Empty;
            comboBoxSubjectNumber.Text = string.Empty;
            List<String> groupNumbersList = new List<string>();
            List<String> subjectNumbersList = new List<string>();
            mSavedConfFiles = Directory.GetFiles(RuntimeConfiguration.DEFAULT_SUBJECTS_CONFIGURATIONS_FOLDER_PATH, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            // learn how to fill vomoboxes according to ptten of file names in saved configuration files list
            foreach (var file in mSavedConfFiles)
            {
                // file name format is :    SUBJECTID_GROUPID_SESSIONID.xml
                string fileName = file.Split(DIR_SLASH).Last();
                var fileNameParts = fileName.Split(CONFIGURATION_FILE_NAME_PATTERN_DELIMITER.ToCharArray());
                if (!subjectNumbersList.Contains(fileNameParts[SUBJECTID_INDEX]))
                {
                    subjectNumbersList.Add(fileNameParts[SUBJECTID_INDEX]);
                }
                if (!groupNumbersList.Contains(fileNameParts[GROUPID_INDEX]))
                {
                    groupNumbersList.Add(fileNameParts[GROUPID_INDEX]);
                }
                int sessionId;
                if (!int.TryParse(fileNameParts[SESSIONID_INDEX].Split('.')[0], out sessionId))
                {
                    throw new FormatException("configuration objects directory located at : " + RuntimeConfiguration.DEFAULT_SUBJECTS_CONFIGURATIONS_FOLDER_PATH + "has file : " + file + " with invalid name, the right name pattern should be : " + CONFIGURATION_FILE_NAME_PATTERN);
                }
                string subjectId = fileNameParts[SUBJECTID_INDEX];
                if (mSubjectToSessionIDDict.ContainsKey(subjectId))
                {
                    // increment cause we want to work on next session
                    mSubjectToSessionIDDict[subjectId] = sessionId;
                }
                else
                {
                    sessionId++;
                    mSubjectToSessionIDDict.Add(subjectId, sessionId);
                }
            }
            comboBoxGroupNumber.DataSource = groupNumbersList;
            comboBoxSubjectNumber.DataSource = subjectNumbersList;

            // return to last selected subject if there is one
            if (!string.IsNullOrEmpty(mLastSelectedSubject))
            {
                comboBoxSubjectNumber.SelectedItem = mLastSelectedSubject;
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxSubjectNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            // handle subject number comobox selection change by updating GUI
            UpdateSubjectDataOnGUI();
        }

        /// <summary>
        /// the fucntion updated GUI accordign to newly selected subject
        /// </summary>
        private void UpdateSubjectDataOnGUI()
        {
            // get selected subject
            string selectedSubjectFile = mSavedConfFiles.Where(x =>
            {
                string fileName = x.Split(DIR_SLASH).Last();
                string subjectPart = fileName.Split(CONFIGURATION_FILE_NAME_PATTERN_DELIMITER.ToCharArray())[SUBJECTID_INDEX];
                return comboBoxSubjectNumber.Text.Equals(subjectPart);
            }).FirstOrDefault();

            if (string.IsNullOrEmpty(selectedSubjectFile))
            {
                return;
            }
            try
            {
                // read the configruation file of the subject
                var repository = new FileRepository();
                repository.Connect(selectedSubjectFile);
                mExpConfiguration = repository.GetObject<ExperimentConfiguration>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed creating configuration object. exception :" + ex.Message);
                Close();
                return;
            }
            //populate GUI according to loaded configuration object
            FillGUIData(mExpConfiguration);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // get all changes to the confgiruation objct
            UpdateConfigurationFromGUI();
            // validate the configurated values
            GenericValidator<ExperimentConfiguration> validator = new GenericValidator<ExperimentConfiguration>(mExpConfiguration);
            var invalidProps = validator.GetInvalidPropertiesErrors();
            if (invalidProps.Any())
            {
                // react to invalid configuration
                MessageBox.Show("Invalid Properties, configure them please");
                return;
            }
            //save configuratino to file
            SaveToFile(mExpConfiguration);
            // populate GUI
            FillComboboxes();
        }

        /// <summary>
        /// The functino saves the configuration to file in subjects directory,
        /// and replaces current configuration by the saved one.
        /// </summary>
        /// <param name="conf">the confiuration object to save to file</param>
        private void SaveToFile(ExperimentConfiguration conf)
        {
            string subjectId = conf.ParticipantConfiguration.Number.ToString();

            FileRepository repository = new FileRepository();

            try
            {
                // save the configuration
                repository.Save(mExpConfiguration, conf.OutputFilesConfiguration.ConfigurationFilePath);
                // if not first session
                if (mSubjectToSessionIDDict.ContainsKey(subjectId) && mSubjectToSessionIDDict[subjectId] != 1)
                {
                    // delete older session file
                    string sessionIdToDelete = (mSubjectToSessionIDDict[subjectId] - 1).ToString();
                    // delete old session
                    string oldFilePath = GetConfigurationFilePath(subjectId, conf.ParticipantConfiguration.GroupNumber.ToString(), sessionIdToDelete);
                    // if the file exists means we creating new session, not updating it, so old file exists
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                // save the path to conifguration file to runtime conf
                mRuntimeConfiguration.PathToConfigurationFile = conf.OutputFilesConfiguration.ConfigurationFilePath;
                mRuntimeRepository.Save(mRuntimeConfiguration, RuntimeConfiguration.RUNTIME_CONF_FILE_NAME);
                mRuntimeRepository.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving configuration file. exception : " + ex.Message);
            }
        }

        /// <summary>
        /// The fucntion gets all configurated data from GUI and updated the configuration object edited
        /// </summary>
        private void UpdateConfigurationFromGUI()
        {
            //subject number
            uint subjectNumber;
            if (!uint.TryParse(comboBoxSubjectNumber.Text, out subjectNumber))
            {
                MessageBox.Show("Bad subject name");
                return;
            }
            mExpConfiguration.ParticipantConfiguration.Number = subjectNumber;

            // group
            uint groupNumber;
            if (!uint.TryParse(comboBoxGroupNumber.Text, out groupNumber))
            {
                MessageBox.Show("Bad group name");
                return;
            }
            mExpConfiguration.ParticipantConfiguration.GroupNumber = groupNumber;

            //age
            uint age;
            if (!uint.TryParse(textBoxAge.Text, out age))
            {
                MessageBox.Show("Bad age");
                return;
            }
            mExpConfiguration.ParticipantConfiguration.Age = age;

            //gender
            mExpConfiguration.ParticipantConfiguration.Gender = GenderType.Male;
            if (radioButtonFemale.Checked)
            {
                mExpConfiguration.ParticipantConfiguration.Gender = GenderType.Female;
            }

            //Hand
            mExpConfiguration.VRHandConfiguration = vrHandEditorControl.ConfigurationObject;
            mExpConfiguration.VRHandConfiguration.HandGender = mExpConfiguration.ParticipantConfiguration.Gender;

            //Sequence
            mExpConfiguration.Squence = textBoxSequence.Text;

            //Session Number
            uint sessionNumber;
            if (!uint.TryParse(textBoxSessionNumber.Text, out sessionNumber))
            {
                MessageBox.Show("Bad Session Number");
                return;
            }
            uint sleepHours;
            if (!uint.TryParse(textBoxSleepHours.Text, out sleepHours))
            {
                MessageBox.Show("Bad sleeep hours");
                return;
            }
            var newSess = new SessionConfiguration();
            newSess.Number = sessionNumber;
            newSess.SleepHours = sleepHours;
            mExpConfiguration.SessionsConfiguration.Add(newSess);

            //Hand
            mExpConfiguration.SubRuns = subRunEditorControl.ConfigurationObject;
            // experiment type
            mExpConfiguration.ExperimentType = GetSelectedExperimentType();
            if (mExpConfiguration.ExperimentType == ExperimentType.PassiveSimulation)
            {
                uint pressFreq;
                if (!uint.TryParse(textBoxPressesFreq.Text, out pressFreq))
                {
                    MessageBox.Show("Bad presses frequency!");
                    return;
                }
                mExpConfiguration.PressFrequency = pressFreq;

                mExpConfiguration.ReplayFilePath = textBoxReplayFile.Text;
            }
            else if (mExpConfiguration.ExperimentType == ExperimentType.PassiveWatchingReplay)
            {
                mExpConfiguration.ReplayFilePath = textBoxReplayFile.Text;
            }

            // file paths
            mExpConfiguration.OutputFilesConfiguration.GloveMovementLogPath = textBoxGloveLogFile.Text;
            mExpConfiguration.OutputFilesConfiguration.UserPressesLogPath = textBoxKeyboardLogFile.Text;
            string fileName = GetConfigurationFilePath(comboBoxSubjectNumber.Text, comboBoxGroupNumber.Text, textBoxSessionNumber.Text);
            textBoxCurretConfFile.Text = fileName;
            mExpConfiguration.OutputFilesConfiguration.ConfigurationFilePath = textBoxCurretConfFile.Text;
        }

        private void comboBoxGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            // react to group number selection change
            string fileName = GetConfigurationFilePath(comboBoxSubjectNumber.Text, comboBoxGroupNumber.Text, textBoxSessionNumber.Text);
            textBoxCurretConfFile.Text = fileName;
        }

        /// <summary>
        /// the function the file path for given subject,group,session combination.
        /// </summary>
        /// <param name="participantID">subject number</param>
        /// <param name="groupId">group number</param>
        /// <param name="sessionID">sessino number</param>
        /// <returns>the file name relevant to arguments according to the configration file name pattern needed</returns>
        private string GetConfigurationFilePath(string participantID, string groupId, string sessionID)
        {
            StringBuilder sb = new StringBuilder();
            // participant id
            sb.Append(RuntimeConfiguration.DEFAULT_SUBJECTS_CONFIGURATIONS_FOLDER_PATH);
            sb.Append(participantID);
            // group id
            sb.Append(CONFIGURATION_FILE_NAME_PATTERN_DELIMITER);
            sb.Append(groupId);
            // session id
            sb.Append(CONFIGURATION_FILE_NAME_PATTERN_DELIMITER);
            sb.Append(sessionID);
            sb.Append(".xml");
            return sb.ToString();
        }

        /// <summary>
        /// the function clears GUI controls and initializes subject number to given one
        /// </summary>
        /// <param name="subjectId">subject number to set after clearing GUI</param>
        private void ClearGUI(uint subjectId)
        {
            mExpConfiguration = new ExperimentConfiguration();
            mExpConfiguration.SubRuns.Add(new SubRunConfiguration());
            mExpConfiguration.ParticipantConfiguration.Number = subjectId;
            FillGUIData(mExpConfiguration);
        }

        private void comboBoxSubjectNumber_Leave(object sender, EventArgs e)
        {
            // when leaving subject number combobox, update GUI
            if (!comboBoxSubjectNumber.Text.Equals(mLastSelectedSubject))
            {
                ApplySubjectNumberComboboxUpdate();
            }
        }

        /// <summary>
        /// the fucntion applies changing the subject number and refreshes inner state and GUI accordingly
        /// </summary>
        private void ApplySubjectNumberComboboxUpdate()
        {
            if (!string.IsNullOrEmpty(mLastSelectedSubject))
            {
                // if we switched from an unsaved subject remove redundant dictionary entry
                if (mSubjectToSessionIDDict.ContainsKey(mLastSelectedSubject) &&
                    !comboBoxSubjectNumber.Items.Contains(mLastSelectedSubject))
                {
                    mSubjectToSessionIDDict.Remove(mLastSelectedSubject);
                }
            }

            // get applied subject number
            string selectedSubjectId = comboBoxSubjectNumber.Text;
            mLastSelectedSubject = selectedSubjectId;
            
            // if new subject number
            if (!comboBoxSubjectNumber.Items.Contains(selectedSubjectId))
            {
                uint subjectId;
                if (!uint.TryParse(selectedSubjectId, out subjectId))
                {
                    MessageBox.Show("Invalid Subject Number");
                    return;
                }
                mSubjectToSessionIDDict.Add(selectedSubjectId, DEFAULT_NEW_SESSION_ID);
                ClearGUI(subjectId);
            }
            else
            {
                // if the subject number already exsits, just update GUI
                UpdateSubjectDataOnGUI();
            }
        }

        private void buttonBrowseKeyboardFile_Click(object sender, EventArgs e)
        {
            GetFilePath(textBoxKeyboardLogFile);
        }

        private void buttonBrowseGloveFile_Click(object sender, EventArgs e)
        {
            GetFilePath(textBoxGloveLogFile);
        }

        /// <summary>
        /// the function connects given file dialog to a text box
        /// </summary>
        /// <param name="tBoxToSet">the text box to set according to selected file name in save file dialog</param>
        private void GetFilePath(TextBox tBoxToSet)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tBoxToSet.Text = saveFileDialog.FileName;
            }
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            // the ufunction reacts to changes in gender by changing hand model
            mExpConfiguration.VRHandConfiguration.HandGender = radioButtonMale.Checked ? GenderType.Male : GenderType.Female;
            vrHandEditorControl.SetModelPath(mExpConfiguration.VRHandConfiguration.HandModel);
        }

        private void radioButtonExperimentType_CheckedChanged(object sender, EventArgs e)
        {
            // the function reacts to changing experiment type by changing GUI and inner satate
            mExpConfiguration.ExperimentType = GetSelectedExperimentType();
            SetExperimentTypeControlsState(mExpConfiguration);
        }

        /// <summary>
        /// the function gets selected experiment type from GUI and returnes it
        /// </summary>
        /// <returns>selected experiment type</returns>
        private ExperimentType GetSelectedExperimentType()
        {
            if (radioButtonTypeA.Checked)
            {
                return ExperimentType.Active;
            }
            else if (radioButtonTypePWR.Checked)
            {
                return ExperimentType.PassiveWatchingReplay;
            }
            return ExperimentType.PassiveSimulation;
        }

        /// <summary>
        /// the function reacts to experiment type by changing GUI controls visibility.
        /// for example simulation experiment type need a place to edit user presses frequency,
        /// but in active experiemt type user presses frequency is irelevant and sould not be editable
        /// </summary>
        /// <param name="exp">the experiment configruatino object to react to</param>
        private void SetExperimentTypeControlsState(ExperimentConfiguration exp)
        {
            textBoxPressesFreq.Text = exp.PressFrequency.ToString();
            textBoxReplayFile.Text = exp.ReplayFilePath;
            switch (exp.ExperimentType)
            {
                case ExperimentType.Active:
                    textBoxReplayFile.Text = string.Empty;

                    textBoxReplayFile.Visible = false;
                    labelTypeAdditionalParam.Visible = false;
                    buttonBrowseReplayFile.Visible = false;
                    textBoxPressesFreq.Visible = false;
                    labelPressFreq.Visible = false;

                    radioButtonTypeA.Checked = true;
                    break;
                case ExperimentType.PassiveWatchingReplay:
                    textBoxReplayFile.Visible = true;
                    labelTypeAdditionalParam.Visible = true;
                    buttonBrowseReplayFile.Visible = true;
                    textBoxPressesFreq.Visible = false;
                    labelPressFreq.Visible = false;
                    
                    radioButtonTypePWR.Checked = true;
                    break;
                case ExperimentType.PassiveSimulation:
                    textBoxReplayFile.Visible = true;
                    labelTypeAdditionalParam.Visible = true;
                    buttonBrowseReplayFile.Visible = true;
                    textBoxPressesFreq.Visible = true;
                    labelPressFreq.Visible = true;


                    radioButtonTypePWS.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void buttonBrowseReplayFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxReplayFile.Text = openFileDialog.FileName;
            }
        } 
        #endregion
    }
}
