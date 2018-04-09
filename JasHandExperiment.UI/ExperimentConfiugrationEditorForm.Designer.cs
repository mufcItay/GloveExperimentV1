namespace JasHandExperiment.UI
{
    partial class ExperimentConfiugrationEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxSleepHours = new System.Windows.Forms.TextBox();
            this.textBoxSequence = new System.Windows.Forms.TextBox();
            this.labelGroupNumber = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelSleepHours = new System.Windows.Forms.Label();
            this.labelSequence = new System.Windows.Forms.Label();
            this.groupBoxParticipant = new System.Windows.Forms.GroupBox();
            this.comboBoxGroupNumber = new System.Windows.Forms.ComboBox();
            this.comboBoxSubjectNumber = new System.Windows.Forms.ComboBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.labelSubjectNumber = new System.Windows.Forms.Label();
            this.groupBoxSessionInfo = new System.Windows.Forms.GroupBox();
            this.subRunEditorControl = new JasHandExperiment.UI.SubRunEditorControl();
            this.labelSessionNumber = new System.Windows.Forms.Label();
            this.textBoxSessionNumber = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxExperimentParams = new System.Windows.Forms.GroupBox();
            this.buttonReplayUserPressesFileBrowse = new System.Windows.Forms.Button();
            this.labelReplayUserPressesFile = new System.Windows.Forms.Label();
            this.textBoxReplayUserPressesFile = new System.Windows.Forms.TextBox();
            this.labelPressFreq = new System.Windows.Forms.Label();
            this.textBoxPressesFreq = new System.Windows.Forms.TextBox();
            this.buttonBrowseReplayFile = new System.Windows.Forms.Button();
            this.radioButtonTypePWS = new System.Windows.Forms.RadioButton();
            this.radioButtonTypePWR = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeA = new System.Windows.Forms.RadioButton();
            this.labelTypeAdditionalParam = new System.Windows.Forms.Label();
            this.labelExperimentType = new System.Windows.Forms.Label();
            this.textBoxReplayFile = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxFileLocations = new System.Windows.Forms.GroupBox();
            this.buttonBrowseGloveFile = new System.Windows.Forms.Button();
            this.buttonBrowseKeyboardFile = new System.Windows.Forms.Button();
            this.textBoxKeyboardLogDirectory = new System.Windows.Forms.TextBox();
            this.labelConfigurationFile = new System.Windows.Forms.Label();
            this.labelKeyoardLogDirectory = new System.Windows.Forms.Label();
            this.textBoxCurretConfFile = new System.Windows.Forms.TextBox();
            this.labelGloveLogDirectory = new System.Windows.Forms.Label();
            this.textBoxGloveLogDirectory = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.vrHandEditorControl = new JasHandExperiment.UI.VRHandEditorControl();
            this.groupBoxParticipant.SuspendLayout();
            this.groupBoxSessionInfo.SuspendLayout();
            this.groupBoxExperimentParams.SuspendLayout();
            this.groupBoxFileLocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAge
            // 
            this.textBoxAge.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxAge.Location = new System.Drawing.Point(197, 123);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(171, 34);
            this.textBoxAge.TabIndex = 0;
            // 
            // textBoxSleepHours
            // 
            this.textBoxSleepHours.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxSleepHours.Location = new System.Drawing.Point(197, 85);
            this.textBoxSleepHours.Name = "textBoxSleepHours";
            this.textBoxSleepHours.Size = new System.Drawing.Size(171, 34);
            this.textBoxSleepHours.TabIndex = 2;
            // 
            // textBoxSequence
            // 
            this.textBoxSequence.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxSequence.Location = new System.Drawing.Point(134, 44);
            this.textBoxSequence.Name = "textBoxSequence";
            this.textBoxSequence.Size = new System.Drawing.Size(375, 34);
            this.textBoxSequence.TabIndex = 3;
            // 
            // labelGroupNumber
            // 
            this.labelGroupNumber.AutoSize = true;
            this.labelGroupNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelGroupNumber.Location = new System.Drawing.Point(15, 82);
            this.labelGroupNumber.Name = "labelGroupNumber";
            this.labelGroupNumber.Size = new System.Drawing.Size(156, 27);
            this.labelGroupNumber.TabIndex = 4;
            this.labelGroupNumber.Text = "Group Number:";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAge.Location = new System.Drawing.Point(16, 121);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(52, 27);
            this.labelAge.TabIndex = 6;
            this.labelAge.Text = "Age:";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelGender.Location = new System.Drawing.Point(16, 168);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(86, 27);
            this.labelGender.TabIndex = 9;
            this.labelGender.Text = "Gender:";
            // 
            // labelSleepHours
            // 
            this.labelSleepHours.AutoSize = true;
            this.labelSleepHours.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSleepHours.Location = new System.Drawing.Point(15, 88);
            this.labelSleepHours.Name = "labelSleepHours";
            this.labelSleepHours.Size = new System.Drawing.Size(127, 27);
            this.labelSleepHours.TabIndex = 8;
            this.labelSleepHours.Text = "Sleep Hours:";
            // 
            // labelSequence
            // 
            this.labelSequence.AutoSize = true;
            this.labelSequence.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSequence.Location = new System.Drawing.Point(9, 47);
            this.labelSequence.Name = "labelSequence";
            this.labelSequence.Size = new System.Drawing.Size(95, 27);
            this.labelSequence.TabIndex = 7;
            this.labelSequence.Text = "Squence:";
            // 
            // groupBoxParticipant
            // 
            this.groupBoxParticipant.Controls.Add(this.comboBoxGroupNumber);
            this.groupBoxParticipant.Controls.Add(this.comboBoxSubjectNumber);
            this.groupBoxParticipant.Controls.Add(this.radioButtonFemale);
            this.groupBoxParticipant.Controls.Add(this.radioButtonMale);
            this.groupBoxParticipant.Controls.Add(this.textBoxAge);
            this.groupBoxParticipant.Controls.Add(this.labelAge);
            this.groupBoxParticipant.Controls.Add(this.labelGender);
            this.groupBoxParticipant.Controls.Add(this.labelGroupNumber);
            this.groupBoxParticipant.Controls.Add(this.labelSubjectNumber);
            this.groupBoxParticipant.Location = new System.Drawing.Point(772, 14);
            this.groupBoxParticipant.Name = "groupBoxParticipant";
            this.groupBoxParticipant.Size = new System.Drawing.Size(658, 200);
            this.groupBoxParticipant.TabIndex = 10;
            this.groupBoxParticipant.TabStop = false;
            this.groupBoxParticipant.Text = "Participant Info";
            // 
            // comboBoxGroupNumber
            // 
            this.comboBoxGroupNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBoxGroupNumber.FormattingEnabled = true;
            this.comboBoxGroupNumber.Location = new System.Drawing.Point(197, 79);
            this.comboBoxGroupNumber.Name = "comboBoxGroupNumber";
            this.comboBoxGroupNumber.Size = new System.Drawing.Size(323, 35);
            this.comboBoxGroupNumber.TabIndex = 11;
            this.comboBoxGroupNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupNumber_SelectedIndexChanged);
            // 
            // comboBoxSubjectNumber
            // 
            this.comboBoxSubjectNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBoxSubjectNumber.FormattingEnabled = true;
            this.comboBoxSubjectNumber.Location = new System.Drawing.Point(197, 37);
            this.comboBoxSubjectNumber.Name = "comboBoxSubjectNumber";
            this.comboBoxSubjectNumber.Size = new System.Drawing.Size(323, 35);
            this.comboBoxSubjectNumber.TabIndex = 11;
            this.comboBoxSubjectNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubjectNumber_SelectedIndexChanged);
            this.comboBoxSubjectNumber.Leave += new System.EventHandler(this.comboBoxSubjectNumber_Leave);
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonFemale.Location = new System.Drawing.Point(281, 166);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(103, 31);
            this.radioButtonFemale.TabIndex = 10;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonMale.Location = new System.Drawing.Point(197, 166);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(83, 31);
            this.radioButtonMale.TabIndex = 10;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // labelSubjectNumber
            // 
            this.labelSubjectNumber.AutoSize = true;
            this.labelSubjectNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSubjectNumber.Location = new System.Drawing.Point(16, 40);
            this.labelSubjectNumber.Name = "labelSubjectNumber";
            this.labelSubjectNumber.Size = new System.Drawing.Size(164, 27);
            this.labelSubjectNumber.TabIndex = 7;
            this.labelSubjectNumber.Text = "Subject Number:";
            // 
            // groupBoxSessionInfo
            // 
            this.groupBoxSessionInfo.Controls.Add(this.subRunEditorControl);
            this.groupBoxSessionInfo.Controls.Add(this.labelSessionNumber);
            this.groupBoxSessionInfo.Controls.Add(this.textBoxSessionNumber);
            this.groupBoxSessionInfo.Controls.Add(this.labelSleepHours);
            this.groupBoxSessionInfo.Controls.Add(this.textBoxSleepHours);
            this.groupBoxSessionInfo.Location = new System.Drawing.Point(772, 233);
            this.groupBoxSessionInfo.Name = "groupBoxSessionInfo";
            this.groupBoxSessionInfo.Size = new System.Drawing.Size(684, 467);
            this.groupBoxSessionInfo.TabIndex = 11;
            this.groupBoxSessionInfo.TabStop = false;
            this.groupBoxSessionInfo.Text = "Session Info";
            // 
            // subRunEditorControl
            // 
            this.subRunEditorControl.ConfigurationObject = null;
            this.subRunEditorControl.Location = new System.Drawing.Point(20, 177);
            this.subRunEditorControl.Name = "subRunEditorControl";
            this.subRunEditorControl.Size = new System.Drawing.Size(658, 387);
            this.subRunEditorControl.TabIndex = 11;
            // 
            // labelSessionNumber
            // 
            this.labelSessionNumber.AutoSize = true;
            this.labelSessionNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSessionNumber.Location = new System.Drawing.Point(15, 50);
            this.labelSessionNumber.Name = "labelSessionNumber";
            this.labelSessionNumber.Size = new System.Drawing.Size(166, 27);
            this.labelSessionNumber.TabIndex = 10;
            this.labelSessionNumber.Text = "Session Number:";
            // 
            // textBoxSessionNumber
            // 
            this.textBoxSessionNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxSessionNumber.Location = new System.Drawing.Point(197, 47);
            this.textBoxSessionNumber.Name = "textBoxSessionNumber";
            this.textBoxSessionNumber.ReadOnly = true;
            this.textBoxSessionNumber.Size = new System.Drawing.Size(171, 34);
            this.textBoxSessionNumber.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonCancel.Location = new System.Drawing.Point(1292, 40);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(164, 98);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxExperimentParams
            // 
            this.groupBoxExperimentParams.Controls.Add(this.buttonReplayUserPressesFileBrowse);
            this.groupBoxExperimentParams.Controls.Add(this.labelReplayUserPressesFile);
            this.groupBoxExperimentParams.Controls.Add(this.textBoxReplayUserPressesFile);
            this.groupBoxExperimentParams.Controls.Add(this.labelPressFreq);
            this.groupBoxExperimentParams.Controls.Add(this.textBoxPressesFreq);
            this.groupBoxExperimentParams.Controls.Add(this.buttonBrowseReplayFile);
            this.groupBoxExperimentParams.Controls.Add(this.radioButtonTypePWS);
            this.groupBoxExperimentParams.Controls.Add(this.radioButtonTypePWR);
            this.groupBoxExperimentParams.Controls.Add(this.radioButtonTypeA);
            this.groupBoxExperimentParams.Controls.Add(this.labelTypeAdditionalParam);
            this.groupBoxExperimentParams.Controls.Add(this.labelSequence);
            this.groupBoxExperimentParams.Controls.Add(this.labelExperimentType);
            this.groupBoxExperimentParams.Controls.Add(this.textBoxReplayFile);
            this.groupBoxExperimentParams.Controls.Add(this.textBoxSequence);
            this.groupBoxExperimentParams.Location = new System.Drawing.Point(12, 12);
            this.groupBoxExperimentParams.Name = "groupBoxExperimentParams";
            this.groupBoxExperimentParams.Size = new System.Drawing.Size(754, 255);
            this.groupBoxExperimentParams.TabIndex = 12;
            this.groupBoxExperimentParams.TabStop = false;
            this.groupBoxExperimentParams.Text = "Experiment Parameters:";
            // 
            // buttonReplayUserPressesFileBrowse
            // 
            this.buttonReplayUserPressesFileBrowse.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonReplayUserPressesFileBrowse.Location = new System.Drawing.Point(563, 197);
            this.buttonReplayUserPressesFileBrowse.Name = "buttonReplayUserPressesFileBrowse";
            this.buttonReplayUserPressesFileBrowse.Size = new System.Drawing.Size(33, 31);
            this.buttonReplayUserPressesFileBrowse.TabIndex = 21;
            this.buttonReplayUserPressesFileBrowse.Text = "...";
            this.buttonReplayUserPressesFileBrowse.UseVisualStyleBackColor = true;
            this.buttonReplayUserPressesFileBrowse.Click += new System.EventHandler(this.button_ReplayUserPressesFileBrowse_Click);
            // 
            // labelReplayUserPressesFile
            // 
            this.labelReplayUserPressesFile.AutoSize = true;
            this.labelReplayUserPressesFile.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelReplayUserPressesFile.Location = new System.Drawing.Point(9, 197);
            this.labelReplayUserPressesFile.Name = "labelReplayUserPressesFile";
            this.labelReplayUserPressesFile.Size = new System.Drawing.Size(169, 27);
            this.labelReplayUserPressesFile.TabIndex = 20;
            this.labelReplayUserPressesFile.Text = "User Presses File:";
            // 
            // textBoxReplayUserPressesFile
            // 
            this.textBoxReplayUserPressesFile.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxReplayUserPressesFile.Location = new System.Drawing.Point(184, 194);
            this.textBoxReplayUserPressesFile.Name = "textBoxReplayUserPressesFile";
            this.textBoxReplayUserPressesFile.Size = new System.Drawing.Size(373, 34);
            this.textBoxReplayUserPressesFile.TabIndex = 19;
            // 
            // labelPressFreq
            // 
            this.labelPressFreq.AutoSize = true;
            this.labelPressFreq.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPressFreq.Location = new System.Drawing.Point(9, 193);
            this.labelPressFreq.Name = "labelPressFreq";
            this.labelPressFreq.Size = new System.Drawing.Size(186, 27);
            this.labelPressFreq.TabIndex = 18;
            this.labelPressFreq.Text = "Presses Frequency:";
            this.labelPressFreq.Visible = false;
            // 
            // textBoxPressesFreq
            // 
            this.textBoxPressesFreq.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxPressesFreq.Location = new System.Drawing.Point(199, 190);
            this.textBoxPressesFreq.Name = "textBoxPressesFreq";
            this.textBoxPressesFreq.Size = new System.Drawing.Size(310, 34);
            this.textBoxPressesFreq.TabIndex = 17;
            this.textBoxPressesFreq.Visible = false;
            // 
            // buttonBrowseReplayFile
            // 
            this.buttonBrowseReplayFile.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonBrowseReplayFile.Location = new System.Drawing.Point(563, 149);
            this.buttonBrowseReplayFile.Name = "buttonBrowseReplayFile";
            this.buttonBrowseReplayFile.Size = new System.Drawing.Size(33, 31);
            this.buttonBrowseReplayFile.TabIndex = 16;
            this.buttonBrowseReplayFile.Text = "...";
            this.buttonBrowseReplayFile.UseVisualStyleBackColor = true;
            this.buttonBrowseReplayFile.Visible = false;
            this.buttonBrowseReplayFile.Click += new System.EventHandler(this.buttonBrowseReplayFile_Click);
            // 
            // radioButtonTypePWS
            // 
            this.radioButtonTypePWS.AutoSize = true;
            this.radioButtonTypePWS.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonTypePWS.Location = new System.Drawing.Point(458, 95);
            this.radioButtonTypePWS.Name = "radioButtonTypePWS";
            this.radioButtonTypePWS.Size = new System.Drawing.Size(290, 31);
            this.radioButtonTypePWS.TabIndex = 15;
            this.radioButtonTypePWS.TabStop = true;
            this.radioButtonTypePWS.Text = "Passive Watchng Simulation";
            this.radioButtonTypePWS.UseVisualStyleBackColor = true;
            this.radioButtonTypePWS.CheckedChanged += new System.EventHandler(this.radioButtonExperimentType_CheckedChanged);
            // 
            // radioButtonTypePWR
            // 
            this.radioButtonTypePWR.AutoSize = true;
            this.radioButtonTypePWR.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonTypePWR.Location = new System.Drawing.Point(193, 93);
            this.radioButtonTypePWR.Name = "radioButtonTypePWR";
            this.radioButtonTypePWR.Size = new System.Drawing.Size(259, 31);
            this.radioButtonTypePWR.TabIndex = 14;
            this.radioButtonTypePWR.TabStop = true;
            this.radioButtonTypePWR.Text = "Passive Watching Replay";
            this.radioButtonTypePWR.UseVisualStyleBackColor = true;
            this.radioButtonTypePWR.CheckedChanged += new System.EventHandler(this.radioButtonExperimentType_CheckedChanged);
            // 
            // radioButtonTypeA
            // 
            this.radioButtonTypeA.AutoSize = true;
            this.radioButtonTypeA.Checked = true;
            this.radioButtonTypeA.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonTypeA.Location = new System.Drawing.Point(95, 92);
            this.radioButtonTypeA.Name = "radioButtonTypeA";
            this.radioButtonTypeA.Size = new System.Drawing.Size(92, 31);
            this.radioButtonTypeA.TabIndex = 13;
            this.radioButtonTypeA.TabStop = true;
            this.radioButtonTypeA.Text = "Active";
            this.radioButtonTypeA.UseVisualStyleBackColor = true;
            this.radioButtonTypeA.CheckedChanged += new System.EventHandler(this.radioButtonExperimentType_CheckedChanged);
            // 
            // labelTypeAdditionalParam
            // 
            this.labelTypeAdditionalParam.AutoSize = true;
            this.labelTypeAdditionalParam.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTypeAdditionalParam.Location = new System.Drawing.Point(9, 147);
            this.labelTypeAdditionalParam.Name = "labelTypeAdditionalParam";
            this.labelTypeAdditionalParam.Size = new System.Drawing.Size(115, 27);
            this.labelTypeAdditionalParam.TabIndex = 7;
            this.labelTypeAdditionalParam.Text = "Replay File:";
            this.labelTypeAdditionalParam.Visible = false;
            // 
            // labelExperimentType
            // 
            this.labelExperimentType.AutoSize = true;
            this.labelExperimentType.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelExperimentType.Location = new System.Drawing.Point(9, 95);
            this.labelExperimentType.Name = "labelExperimentType";
            this.labelExperimentType.Size = new System.Drawing.Size(61, 27);
            this.labelExperimentType.TabIndex = 12;
            this.labelExperimentType.Text = "Type:";
            // 
            // textBoxReplayFile
            // 
            this.textBoxReplayFile.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxReplayFile.Location = new System.Drawing.Point(184, 146);
            this.textBoxReplayFile.Name = "textBoxReplayFile";
            this.textBoxReplayFile.Size = new System.Drawing.Size(373, 34);
            this.textBoxReplayFile.TabIndex = 3;
            this.textBoxReplayFile.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonSave.Location = new System.Drawing.Point(1076, 41);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(164, 98);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxFileLocations
            // 
            this.groupBoxFileLocations.Controls.Add(this.buttonBrowseGloveFile);
            this.groupBoxFileLocations.Controls.Add(this.buttonBrowseKeyboardFile);
            this.groupBoxFileLocations.Controls.Add(this.textBoxKeyboardLogDirectory);
            this.groupBoxFileLocations.Controls.Add(this.labelConfigurationFile);
            this.groupBoxFileLocations.Controls.Add(this.labelKeyoardLogDirectory);
            this.groupBoxFileLocations.Controls.Add(this.buttonCancel);
            this.groupBoxFileLocations.Controls.Add(this.buttonSave);
            this.groupBoxFileLocations.Controls.Add(this.textBoxCurretConfFile);
            this.groupBoxFileLocations.Controls.Add(this.labelGloveLogDirectory);
            this.groupBoxFileLocations.Controls.Add(this.textBoxGloveLogDirectory);
            this.groupBoxFileLocations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxFileLocations.Location = new System.Drawing.Point(0, 692);
            this.groupBoxFileLocations.Name = "groupBoxFileLocations";
            this.groupBoxFileLocations.Size = new System.Drawing.Size(1463, 182);
            this.groupBoxFileLocations.TabIndex = 13;
            this.groupBoxFileLocations.TabStop = false;
            this.groupBoxFileLocations.Text = "Files";
            // 
            // buttonBrowseGloveFile
            // 
            this.buttonBrowseGloveFile.Location = new System.Drawing.Point(752, 95);
            this.buttonBrowseGloveFile.Name = "buttonBrowseGloveFile";
            this.buttonBrowseGloveFile.Size = new System.Drawing.Size(33, 36);
            this.buttonBrowseGloveFile.TabIndex = 16;
            this.buttonBrowseGloveFile.Text = "...";
            this.buttonBrowseGloveFile.UseVisualStyleBackColor = true;
            this.buttonBrowseGloveFile.Click += new System.EventHandler(this.buttonBrowseGloveFile_Click);
            // 
            // buttonBrowseKeyboardFile
            // 
            this.buttonBrowseKeyboardFile.Location = new System.Drawing.Point(752, 44);
            this.buttonBrowseKeyboardFile.Name = "buttonBrowseKeyboardFile";
            this.buttonBrowseKeyboardFile.Size = new System.Drawing.Size(33, 36);
            this.buttonBrowseKeyboardFile.TabIndex = 14;
            this.buttonBrowseKeyboardFile.Text = "...";
            this.buttonBrowseKeyboardFile.UseVisualStyleBackColor = true;
            this.buttonBrowseKeyboardFile.Click += new System.EventHandler(this.buttonBrowseKeyboardFile_Click);
            // 
            // textBoxKeyboardLogDirectory
            // 
            this.textBoxKeyboardLogDirectory.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxKeyboardLogDirectory.Location = new System.Drawing.Point(276, 40);
            this.textBoxKeyboardLogDirectory.Name = "textBoxKeyboardLogDirectory";
            this.textBoxKeyboardLogDirectory.Size = new System.Drawing.Size(461, 34);
            this.textBoxKeyboardLogDirectory.TabIndex = 13;
            // 
            // labelConfigurationFile
            // 
            this.labelConfigurationFile.AutoSize = true;
            this.labelConfigurationFile.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelConfigurationFile.Location = new System.Drawing.Point(14, 142);
            this.labelConfigurationFile.Name = "labelConfigurationFile";
            this.labelConfigurationFile.Size = new System.Drawing.Size(259, 27);
            this.labelConfigurationFile.TabIndex = 11;
            this.labelConfigurationFile.Text = "Current Configuration File :";
            // 
            // labelKeyoardLogDirectory
            // 
            this.labelKeyoardLogDirectory.AutoSize = true;
            this.labelKeyoardLogDirectory.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelKeyoardLogDirectory.Location = new System.Drawing.Point(14, 41);
            this.labelKeyoardLogDirectory.Name = "labelKeyoardLogDirectory";
            this.labelKeyoardLogDirectory.Size = new System.Drawing.Size(235, 27);
            this.labelKeyoardLogDirectory.TabIndex = 10;
            this.labelKeyoardLogDirectory.Text = "Keyboard Log Directory :";
            // 
            // textBoxCurretConfFile
            // 
            this.textBoxCurretConfFile.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxCurretConfFile.Location = new System.Drawing.Point(276, 139);
            this.textBoxCurretConfFile.Name = "textBoxCurretConfFile";
            this.textBoxCurretConfFile.ReadOnly = true;
            this.textBoxCurretConfFile.Size = new System.Drawing.Size(461, 34);
            this.textBoxCurretConfFile.TabIndex = 9;
            // 
            // labelGloveLogDirectory
            // 
            this.labelGloveLogDirectory.AutoSize = true;
            this.labelGloveLogDirectory.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelGloveLogDirectory.Location = new System.Drawing.Point(14, 94);
            this.labelGloveLogDirectory.Name = "labelGloveLogDirectory";
            this.labelGloveLogDirectory.Size = new System.Drawing.Size(200, 27);
            this.labelGloveLogDirectory.TabIndex = 8;
            this.labelGloveLogDirectory.Text = "Glove Log Directory :";
            // 
            // textBoxGloveLogDirectory
            // 
            this.textBoxGloveLogDirectory.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxGloveLogDirectory.Location = new System.Drawing.Point(276, 91);
            this.textBoxGloveLogDirectory.Name = "textBoxGloveLogDirectory";
            this.textBoxGloveLogDirectory.Size = new System.Drawing.Size(461, 34);
            this.textBoxGloveLogDirectory.TabIndex = 2;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.FileName = "file";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "file";
            this.openFileDialog.Filter = "XML File| *.xml";
            // 
            // vrHandEditorControl
            // 
            this.vrHandEditorControl.ConfigurationObject = null;
            this.vrHandEditorControl.Location = new System.Drawing.Point(18, 273);
            this.vrHandEditorControl.Name = "vrHandEditorControl";
            this.vrHandEditorControl.Size = new System.Drawing.Size(748, 424);
            this.vrHandEditorControl.TabIndex = 15;
            // 
            // ExperimentConfiugrationEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1463, 874);
            this.Controls.Add(this.vrHandEditorControl);
            this.Controls.Add(this.groupBoxFileLocations);
            this.Controls.Add(this.groupBoxExperimentParams);
            this.Controls.Add(this.groupBoxSessionInfo);
            this.Controls.Add(this.groupBoxParticipant);
            this.Name = "ExperimentConfiugrationEditorForm";
            this.Text = "ExperimentConfiugrationEditorForm";
            this.groupBoxParticipant.ResumeLayout(false);
            this.groupBoxParticipant.PerformLayout();
            this.groupBoxSessionInfo.ResumeLayout(false);
            this.groupBoxSessionInfo.PerformLayout();
            this.groupBoxExperimentParams.ResumeLayout(false);
            this.groupBoxExperimentParams.PerformLayout();
            this.groupBoxFileLocations.ResumeLayout(false);
            this.groupBoxFileLocations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxSleepHours;
        private System.Windows.Forms.TextBox textBoxSequence;
        private System.Windows.Forms.Label labelGroupNumber;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelSleepHours;
        private System.Windows.Forms.Label labelSequence;
        private System.Windows.Forms.GroupBox groupBoxParticipant;
        private System.Windows.Forms.GroupBox groupBoxSessionInfo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxSubjectNumber;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.Label labelSubjectNumber;
        private System.Windows.Forms.ComboBox comboBoxGroupNumber;
        private System.Windows.Forms.Label labelSessionNumber;
        private System.Windows.Forms.TextBox textBoxSessionNumber;
        private System.Windows.Forms.GroupBox groupBoxExperimentParams;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxFileLocations;
        private System.Windows.Forms.TextBox textBoxKeyboardLogDirectory;
        private System.Windows.Forms.Label labelConfigurationFile;
        private System.Windows.Forms.Label labelKeyoardLogDirectory;
        private System.Windows.Forms.TextBox textBoxCurretConfFile;
        private System.Windows.Forms.Label labelGloveLogDirectory;
        private System.Windows.Forms.TextBox textBoxGloveLogDirectory;
        private SubRunEditorControl subRunEditorControl;
        private System.Windows.Forms.Button buttonBrowseGloveFile;
        private System.Windows.Forms.Button buttonBrowseKeyboardFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton radioButtonTypePWS;
        private System.Windows.Forms.RadioButton radioButtonTypePWR;
        private System.Windows.Forms.RadioButton radioButtonTypeA;
        private System.Windows.Forms.Label labelTypeAdditionalParam;
        private System.Windows.Forms.Label labelExperimentType;
        private System.Windows.Forms.TextBox textBoxReplayFile;
        private System.Windows.Forms.Button buttonBrowseReplayFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelPressFreq;
        private System.Windows.Forms.TextBox textBoxPressesFreq;
        private VRHandEditorControl vrHandEditorControl;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonReplayUserPressesFileBrowse;
        private System.Windows.Forms.Label labelReplayUserPressesFile;
        private System.Windows.Forms.TextBox textBoxReplayUserPressesFile;
    }
}