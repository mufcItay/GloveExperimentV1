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
        private const string SUBJECTS_CONFIGURATIONS_FOLDER_PATH = @"Subject Configurations\";
        private const string CONFIGURATION_FILE_NAME_PATTERN = "subjID"+ CONFIGURATION_FILE_NAME_PATTERN_DELIMITER + "groupID" + CONFIGURATION_FILE_NAME_PATTERN_DELIMITER + "sessionID";
        private const string CONFIGURATION_FILE_NAME_PATTERN_DELIMITER = "_";
        private const int SUBJECTID_INDEX = 0;
        private const int GROUPID_INDEX = 1;
        private const int SESSIONID_INDEX = 2;
        private const int DEFAULT_NEW_SESSION_ID = 1;
        private const int DEFAULT_SLEEPING_HOURS = 0;


        private ExperimentConfiguration mExpConfiguration;
        private List<String> mSavedConfFiles;
        private Dictionary<String, int> mSubjectToSessionIDDict;
        private string mLastSelectedSubject;

        public ExperimentConfiugrationEditorForm()
        {
            InitializeComponent();
            CreateFolders();
            mExpConfiguration = new ExperimentConfiguration();
            // add a default first sub run
            mExpConfiguration.SubRuns.Add(new SubRunConfiguration());

            mSubjectToSessionIDDict = new Dictionary<string, int>();
            FillComboboxes();
            FillGUIData(mExpConfiguration);
            subRunEditorControl.XMLHandlingVisible(false);
        }

        private void CreateFolders()
        {
            if (!Directory.Exists(SUBJECTS_CONFIGURATIONS_FOLDER_PATH))
            {
                Directory.CreateDirectory(SUBJECTS_CONFIGURATIONS_FOLDER_PATH);
            }
            if (!Directory.Exists(OutputFilesConfiguration.GLOVE_MOVEMENTS_FOLDER))
            {
                Directory.CreateDirectory(OutputFilesConfiguration.GLOVE_MOVEMENTS_FOLDER);
            }
            if (!Directory.Exists(OutputFilesConfiguration.USER_PRESSES_FOLDER))
            {
                Directory.CreateDirectory(OutputFilesConfiguration.USER_PRESSES_FOLDER);
            }
        }

        private void ExperimentConfiugrationEditorForm_Load(object sender, EventArgs e)
        {
        }

        private void FillGUIData(ExperimentConfiguration exp)
        {
            textBoxSequence.Text = exp.Squence;
            vrHandEditorControl.ConfigurationObject = exp.VRHandConfiguration;
            textBoxAge.Text = exp.ParticipantConfiguration.Age.ToString();
            radioButtonFemale.Checked = exp.ParticipantConfiguration.Gender == GenderType.Female;
            radioButtonMale.Checked = exp.ParticipantConfiguration.Gender == GenderType.Male;
            comboBoxGroupNumber.Text = exp.ParticipantConfiguration.GroupNumber.ToString();
            string subjectNumberStr = exp.ParticipantConfiguration.Number.ToString();
            comboBoxSubjectNumber.Text = subjectNumberStr;
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
            SetExperimentTypeControlsState(exp);
        }

        private void FillComboboxes()
        {
            comboBoxGroupNumber.Text = string.Empty;
            comboBoxSubjectNumber.Text = string.Empty;
            List<String> groupNumbersList = new List<string>();
            List<String> subjectNumbersList = new List<string>();
            mSavedConfFiles = Directory.GetFiles(SUBJECTS_CONFIGURATIONS_FOLDER_PATH, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            foreach (var file in mSavedConfFiles)
            {
                var fileNameParts = file.Split(CONFIGURATION_FILE_NAME_PATTERN_DELIMITER.ToCharArray());
                if (!subjectNumbersList.Contains(fileNameParts[SUBJECTID_INDEX].Split('\\')[1]))
                {
                    subjectNumbersList.Add(fileNameParts[SUBJECTID_INDEX].Split('\\')[1]);
                }
                if (!subjectNumbersList.Contains(fileNameParts[SUBJECTID_INDEX]))
                {
                    groupNumbersList.Add(fileNameParts[GROUPID_INDEX]);
                }
                int sessionId;
                if (!int.TryParse(fileNameParts[SESSIONID_INDEX].Split('.')[0], out sessionId))
                {
                    throw new FormatException("configuration objects directory located at : " + SUBJECTS_CONFIGURATIONS_FOLDER_PATH + "has file : " + file + " with invalid name, the right name pattern should be : " + CONFIGURATION_FILE_NAME_PATTERN);
                }
                string subjectId = fileNameParts[SUBJECTID_INDEX].Split('\\')[1];
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
            UpdateSubjectDataOnGUI();
        }

        private void UpdateSubjectDataOnGUI()
        {
            string selectedSubjectFile = mSavedConfFiles.Where(x =>
            {
                string subjectPart = x.Split(CONFIGURATION_FILE_NAME_PATTERN_DELIMITER.ToCharArray())[SUBJECTID_INDEX];
                subjectPart = subjectPart.Split('\\')[1];
                return comboBoxSubjectNumber.Text.Equals(subjectPart);
            }).FirstOrDefault();

            if (string.IsNullOrEmpty(selectedSubjectFile))
            {
                return;
            }
            try
            {
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
            FillGUIData(mExpConfiguration);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateConfigurationFromGUI();
            GenericValidator<ExperimentConfiguration> validator = new GenericValidator<ExperimentConfiguration>(mExpConfiguration);
            var invalidProps = validator.GetInvalidPropertiesErrors();
            if (invalidProps.Any())
            {
                MessageBox.Show("Invalid Properties, configure them please");
                return;
            }
            FileRepository repository = new FileRepository();
            string subjectId = mExpConfiguration.ParticipantConfiguration.Number.ToString();
            try
            {
                repository.Save(mExpConfiguration, mExpConfiguration.OutputFilesConfiguration.ConfigurationFilePath);
                // if not first session
                if (mSubjectToSessionIDDict.ContainsKey(subjectId) && mSubjectToSessionIDDict[subjectId] != 1)
                {
                    // delete older session file
                    string sessionIdToDelete = (mSubjectToSessionIDDict[subjectId] -1).ToString();
                    // delete old session
                    string oldFilePath = GetConfigurationFilePath(subjectId, mExpConfiguration.ParticipantConfiguration.GroupNumber.ToString(), sessionIdToDelete);
                    // if the file exists means we creating new session, not updating it, so old file exists
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving configuration file. exception : " + ex.Message);
            }
            FillComboboxes();
        }

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
            mExpConfiguration.SubRuns= subRunEditorControl.ConfigurationObject;
            // experiment type
            mExpConfiguration.ExperimentType = GetSelectedExperimentType();
            if(mExpConfiguration.ExperimentType == ExperimentType.PassiveSimulation)
            {
                uint pressFreq;
                if(!uint.TryParse(textBoxPressesFreq.Text, out pressFreq))
                {
                    MessageBox.Show("Bad presses frequency!");
                    return;
                }
                mExpConfiguration.PressFrequency = pressFreq;

                mExpConfiguration.ReplayFilePath = textBoxReplayFile.Text;
            }
            else if(mExpConfiguration.ExperimentType == ExperimentType.PassiveWatchingReplay)
            {
                mExpConfiguration.ReplayFilePath = textBoxReplayFile.Text;
            }

            // file paths
            mExpConfiguration.OutputFilesConfiguration.GloveMovementLogPath = textBoxGloveLogFile.Text;
            mExpConfiguration.OutputFilesConfiguration.UserPressesLogPath = textBoxKeyboardLogFile.Text;
            string fileName = GetConfigurationFilePath(comboBoxSubjectNumber.Text, comboBoxGroupNumber.Text, textBoxSessionNumber.Text);
            textBoxCurretConfFile.Text = fileName;
            mExpConfiguration.OutputFilesConfiguration.ConfigurationFilePath= textBoxCurretConfFile.Text;
        }

        private void comboBoxGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = GetConfigurationFilePath(comboBoxSubjectNumber.Text, comboBoxGroupNumber.Text, textBoxSessionNumber.Text);
            textBoxCurretConfFile.Text = fileName;
        }

        private string GetConfigurationFilePath(string participantID,string groupId, string sessionID)
        {
            StringBuilder sb = new StringBuilder();
            // participant id
            sb.Append(SUBJECTS_CONFIGURATIONS_FOLDER_PATH);
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

        private void ClearGUI(uint subjectId)
        {
            mExpConfiguration = new ExperimentConfiguration();
            mExpConfiguration.SubRuns.Add(new SubRunConfiguration());
            mExpConfiguration.ParticipantConfiguration.Number = subjectId;
            FillGUIData(mExpConfiguration);
        }

        private void comboBoxSubjectNumber_Leave(object sender, EventArgs e)
        {
            if (!comboBoxSubjectNumber.Text.Equals(mLastSelectedSubject))
            {
                ApplySubjectNumberComboboxUpdate();
            }
        }

        private void ApplySubjectNumberComboboxUpdate()
        {
            string selectedSubjectId = comboBoxSubjectNumber.Text;
            mLastSelectedSubject = selectedSubjectId;
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

        private void GetFilePath(TextBox tBoxToSet)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tBoxToSet.Text = saveFileDialog.FileName;
            }
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            mExpConfiguration.VRHandConfiguration.HandGender = radioButtonMale.Checked ? GenderType.Male : GenderType.Female;
            vrHandEditorControl.SetModelPath(mExpConfiguration.VRHandConfiguration.HandModel);
        }

        private void radioButtonExperimentType_CheckedChanged(object sender, EventArgs e)
        {
            mExpConfiguration.ExperimentType = GetSelectedExperimentType();
            SetExperimentTypeControlsState(mExpConfiguration);
        }
        
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

        private void SetExperimentTypeControlsState(ExperimentConfiguration exp)
        {
            textBoxPressesFreq.Text = exp.PressFrequency.ToString();
            textBoxReplayFile.Text = exp.ReplayFilePath;
            switch (exp.ExperimentType)
            {   
                case ExperimentType.Active:
                    textBoxReplayFile.Visible = false;
                    labelTypeAdditionalParam.Visible = false;
                    buttonBrowseReplayFile.Visible = false;
                    textBoxReplayFile.Text = string.Empty;
                    textBoxPressesFreq.Visible = false;
                    labelPressFreq.Visible = false;
                    break;
                case ExperimentType.PassiveWatchingReplay:
                    textBoxReplayFile.Visible = true;
                    labelTypeAdditionalParam.Visible = true;
                    buttonBrowseReplayFile.Visible = true;
                    textBoxPressesFreq.Visible = false;
                    labelPressFreq.Visible = false;
                    break;
                case ExperimentType.PassiveSimulation:
                    textBoxReplayFile.Visible = true;
                    labelTypeAdditionalParam.Visible = true;
                    buttonBrowseReplayFile.Visible = true;
                    textBoxPressesFreq.Visible = true;
                    labelPressFreq.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void buttonBrowseReplayFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxReplayFile.Text = openFileDialog.FileName;
            }
        }
    }
}
