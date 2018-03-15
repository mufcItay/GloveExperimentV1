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
            this.labelSessionNumber = new System.Windows.Forms.Label();
            this.textBoxSessionNumber = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxExperimentParams = new System.Windows.Forms.GroupBox();
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
            this.textBoxKeyboardLogFile = new System.Windows.Forms.TextBox();
            this.labelConfigurationFile = new System.Windows.Forms.Label();
            this.labelKeyoardLogFile = new System.Windows.Forms.Label();
            this.textBoxCurretConfFile = new System.Windows.Forms.TextBox();
            this.labelGloveLogFile = new System.Windows.Forms.Label();
            this.textBoxGloveLogFile = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.subRunEditorControl = new JasHandExperiment.UI.SubRunEditorControl();
            this.vrHandEditorControl = new JasHandExperiment.UI.VRHandEditorControl();
            this.groupBoxParticipant.SuspendLayout();
            this.groupBoxSessionInfo.SuspendLayout();
            this.groupBoxExperimentParams.SuspendLayout();
            this.groupBoxFileLocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(166, 112);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(171, 26);
            this.textBoxAge.TabIndex = 0;
            // 
            // textBoxSleepHours
            // 
            this.textBoxSleepHours.Location = new System.Drawing.Point(166, 73);
            this.textBoxSleepHours.Name = "textBoxSleepHours";
            this.textBoxSleepHours.Size = new System.Drawing.Size(171, 26);
            this.textBoxSleepHours.TabIndex = 2;
            // 
            // textBoxSequence
            // 
            this.textBoxSequence.Location = new System.Drawing.Point(92, 44);
            this.textBoxSequence.Name = "textBoxSequence";
            this.textBoxSequence.Size = new System.Drawing.Size(206, 26);
            this.textBoxSequence.TabIndex = 3;
            // 
            // labelGroupNumber
            // 
            this.labelGroupNumber.AutoSize = true;
            this.labelGroupNumber.Location = new System.Drawing.Point(15, 79);
            this.labelGroupNumber.Name = "labelGroupNumber";
            this.labelGroupNumber.Size = new System.Drawing.Size(118, 20);
            this.labelGroupNumber.TabIndex = 4;
            this.labelGroupNumber.Text = "Group Number:";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(16, 115);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(42, 20);
            this.labelAge.TabIndex = 6;
            this.labelAge.Text = "Age:";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(16, 151);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(67, 20);
            this.labelGender.TabIndex = 9;
            this.labelGender.Text = "Gender:";
            // 
            // labelSleepHours
            // 
            this.labelSleepHours.AutoSize = true;
            this.labelSleepHours.Location = new System.Drawing.Point(15, 79);
            this.labelSleepHours.Name = "labelSleepHours";
            this.labelSleepHours.Size = new System.Drawing.Size(101, 20);
            this.labelSleepHours.TabIndex = 8;
            this.labelSleepHours.Text = "Sleep Hours:";
            // 
            // labelSequence
            // 
            this.labelSequence.AutoSize = true;
            this.labelSequence.Location = new System.Drawing.Point(9, 47);
            this.labelSequence.Name = "labelSequence";
            this.labelSequence.Size = new System.Drawing.Size(77, 20);
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
            this.groupBoxParticipant.Location = new System.Drawing.Point(679, 15);
            this.groupBoxParticipant.Name = "groupBoxParticipant";
            this.groupBoxParticipant.Size = new System.Drawing.Size(678, 200);
            this.groupBoxParticipant.TabIndex = 10;
            this.groupBoxParticipant.TabStop = false;
            this.groupBoxParticipant.Text = "Participant Info";
            // 
            // comboBoxGroupNumber
            // 
            this.comboBoxGroupNumber.FormattingEnabled = true;
            this.comboBoxGroupNumber.Location = new System.Drawing.Point(166, 76);
            this.comboBoxGroupNumber.Name = "comboBoxGroupNumber";
            this.comboBoxGroupNumber.Size = new System.Drawing.Size(323, 28);
            this.comboBoxGroupNumber.TabIndex = 11;
            this.comboBoxGroupNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupNumber_SelectedIndexChanged);
            // 
            // comboBoxSubjectNumber
            // 
            this.comboBoxSubjectNumber.FormattingEnabled = true;
            this.comboBoxSubjectNumber.Location = new System.Drawing.Point(166, 37);
            this.comboBoxSubjectNumber.Name = "comboBoxSubjectNumber";
            this.comboBoxSubjectNumber.Size = new System.Drawing.Size(323, 28);
            this.comboBoxSubjectNumber.TabIndex = 11;
            this.comboBoxSubjectNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubjectNumber_SelectedIndexChanged);
            this.comboBoxSubjectNumber.Leave += new System.EventHandler(this.comboBoxSubjectNumber_Leave);
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(250, 147);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(87, 24);
            this.radioButtonFemale.TabIndex = 10;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Location = new System.Drawing.Point(166, 147);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(68, 24);
            this.radioButtonMale.TabIndex = 10;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // labelSubjectNumber
            // 
            this.labelSubjectNumber.AutoSize = true;
            this.labelSubjectNumber.Location = new System.Drawing.Point(16, 40);
            this.labelSubjectNumber.Name = "labelSubjectNumber";
            this.labelSubjectNumber.Size = new System.Drawing.Size(127, 20);
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
            this.groupBoxSessionInfo.Location = new System.Drawing.Point(679, 221);
            this.groupBoxSessionInfo.Name = "groupBoxSessionInfo";
            this.groupBoxSessionInfo.Size = new System.Drawing.Size(684, 477);
            this.groupBoxSessionInfo.TabIndex = 11;
            this.groupBoxSessionInfo.TabStop = false;
            this.groupBoxSessionInfo.Text = "Session Info";
            // 
            // labelSessionNumber
            // 
            this.labelSessionNumber.AutoSize = true;
            this.labelSessionNumber.Location = new System.Drawing.Point(15, 41);
            this.labelSessionNumber.Name = "labelSessionNumber";
            this.labelSessionNumber.Size = new System.Drawing.Size(130, 20);
            this.labelSessionNumber.TabIndex = 10;
            this.labelSessionNumber.Text = "Session Number:";
            // 
            // textBoxSessionNumber
            // 
            this.textBoxSessionNumber.Location = new System.Drawing.Point(166, 35);
            this.textBoxSessionNumber.Name = "textBoxSessionNumber";
            this.textBoxSessionNumber.ReadOnly = true;
            this.textBoxSessionNumber.Size = new System.Drawing.Size(171, 26);
            this.textBoxSessionNumber.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1221, 25);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(128, 98);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxExperimentParams
            // 
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
            this.groupBoxExperimentParams.Size = new System.Drawing.Size(661, 203);
            this.groupBoxExperimentParams.TabIndex = 12;
            this.groupBoxExperimentParams.TabStop = false;
            this.groupBoxExperimentParams.Text = "Experiment Parameters:";
            // 
            // labelPressFreq
            // 
            this.labelPressFreq.AutoSize = true;
            this.labelPressFreq.Location = new System.Drawing.Point(6, 175);
            this.labelPressFreq.Name = "labelPressFreq";
            this.labelPressFreq.Size = new System.Drawing.Size(149, 20);
            this.labelPressFreq.TabIndex = 18;
            this.labelPressFreq.Text = "Presses Frequency:";
            this.labelPressFreq.Visible = false;
            // 
            // textBoxPressesFreq
            // 
            this.textBoxPressesFreq.Location = new System.Drawing.Point(161, 172);
            this.textBoxPressesFreq.Name = "textBoxPressesFreq";
            this.textBoxPressesFreq.Size = new System.Drawing.Size(310, 26);
            this.textBoxPressesFreq.TabIndex = 17;
            this.textBoxPressesFreq.Visible = false;
            // 
            // buttonBrowseReplayFile
            // 
            this.buttonBrowseReplayFile.Location = new System.Drawing.Point(475, 131);
            this.buttonBrowseReplayFile.Name = "buttonBrowseReplayFile";
            this.buttonBrowseReplayFile.Size = new System.Drawing.Size(34, 26);
            this.buttonBrowseReplayFile.TabIndex = 16;
            this.buttonBrowseReplayFile.Text = "...";
            this.buttonBrowseReplayFile.UseVisualStyleBackColor = true;
            this.buttonBrowseReplayFile.Visible = false;
            this.buttonBrowseReplayFile.Click += new System.EventHandler(this.buttonBrowseReplayFile_Click);
            // 
            // radioButtonTypePWS
            // 
            this.radioButtonTypePWS.AutoSize = true;
            this.radioButtonTypePWS.Location = new System.Drawing.Point(393, 85);
            this.radioButtonTypePWS.Name = "radioButtonTypePWS";
            this.radioButtonTypePWS.Size = new System.Drawing.Size(234, 24);
            this.radioButtonTypePWS.TabIndex = 15;
            this.radioButtonTypePWS.TabStop = true;
            this.radioButtonTypePWS.Text = "Passive Watchng Simulation";
            this.radioButtonTypePWS.UseVisualStyleBackColor = true;
            this.radioButtonTypePWS.CheckedChanged += new System.EventHandler(this.radioButtonExperimentType_CheckedChanged);
            // 
            // radioButtonTypePWR
            // 
            this.radioButtonTypePWR.AutoSize = true;
            this.radioButtonTypePWR.Location = new System.Drawing.Point(177, 85);
            this.radioButtonTypePWR.Name = "radioButtonTypePWR";
            this.radioButtonTypePWR.Size = new System.Drawing.Size(212, 24);
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
            this.radioButtonTypeA.Location = new System.Drawing.Point(96, 85);
            this.radioButtonTypeA.Name = "radioButtonTypeA";
            this.radioButtonTypeA.Size = new System.Drawing.Size(77, 24);
            this.radioButtonTypeA.TabIndex = 13;
            this.radioButtonTypeA.TabStop = true;
            this.radioButtonTypeA.Text = "Active";
            this.radioButtonTypeA.UseVisualStyleBackColor = true;
            this.radioButtonTypeA.CheckedChanged += new System.EventHandler(this.radioButtonExperimentType_CheckedChanged);
            // 
            // labelTypeAdditionalParam
            // 
            this.labelTypeAdditionalParam.AutoSize = true;
            this.labelTypeAdditionalParam.Location = new System.Drawing.Point(6, 137);
            this.labelTypeAdditionalParam.Name = "labelTypeAdditionalParam";
            this.labelTypeAdditionalParam.Size = new System.Drawing.Size(91, 20);
            this.labelTypeAdditionalParam.TabIndex = 7;
            this.labelTypeAdditionalParam.Text = "Replay File:";
            this.labelTypeAdditionalParam.Visible = false;
            // 
            // labelExperimentType
            // 
            this.labelExperimentType.AutoSize = true;
            this.labelExperimentType.Location = new System.Drawing.Point(9, 85);
            this.labelExperimentType.Name = "labelExperimentType";
            this.labelExperimentType.Size = new System.Drawing.Size(47, 20);
            this.labelExperimentType.TabIndex = 12;
            this.labelExperimentType.Text = "Type:";
            // 
            // textBoxReplayFile
            // 
            this.textBoxReplayFile.Location = new System.Drawing.Point(106, 131);
            this.textBoxReplayFile.Name = "textBoxReplayFile";
            this.textBoxReplayFile.Size = new System.Drawing.Size(363, 26);
            this.textBoxReplayFile.TabIndex = 3;
            this.textBoxReplayFile.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1042, 25);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(128, 98);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxFileLocations
            // 
            this.groupBoxFileLocations.Controls.Add(this.buttonBrowseGloveFile);
            this.groupBoxFileLocations.Controls.Add(this.buttonBrowseKeyboardFile);
            this.groupBoxFileLocations.Controls.Add(this.textBoxKeyboardLogFile);
            this.groupBoxFileLocations.Controls.Add(this.labelConfigurationFile);
            this.groupBoxFileLocations.Controls.Add(this.labelKeyoardLogFile);
            this.groupBoxFileLocations.Controls.Add(this.buttonCancel);
            this.groupBoxFileLocations.Controls.Add(this.buttonSave);
            this.groupBoxFileLocations.Controls.Add(this.textBoxCurretConfFile);
            this.groupBoxFileLocations.Controls.Add(this.labelGloveLogFile);
            this.groupBoxFileLocations.Controls.Add(this.textBoxGloveLogFile);
            this.groupBoxFileLocations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxFileLocations.Location = new System.Drawing.Point(0, 715);
            this.groupBoxFileLocations.Name = "groupBoxFileLocations";
            this.groupBoxFileLocations.Size = new System.Drawing.Size(1361, 146);
            this.groupBoxFileLocations.TabIndex = 13;
            this.groupBoxFileLocations.TabStop = false;
            this.groupBoxFileLocations.Text = "Files";
            // 
            // buttonBrowseGloveFile
            // 
            this.buttonBrowseGloveFile.Location = new System.Drawing.Point(638, 72);
            this.buttonBrowseGloveFile.Name = "buttonBrowseGloveFile";
            this.buttonBrowseGloveFile.Size = new System.Drawing.Size(35, 29);
            this.buttonBrowseGloveFile.TabIndex = 16;
            this.buttonBrowseGloveFile.Text = "...";
            this.buttonBrowseGloveFile.UseVisualStyleBackColor = true;
            this.buttonBrowseGloveFile.Click += new System.EventHandler(this.buttonBrowseGloveFile_Click);
            // 
            // buttonBrowseKeyboardFile
            // 
            this.buttonBrowseKeyboardFile.Location = new System.Drawing.Point(638, 36);
            this.buttonBrowseKeyboardFile.Name = "buttonBrowseKeyboardFile";
            this.buttonBrowseKeyboardFile.Size = new System.Drawing.Size(35, 29);
            this.buttonBrowseKeyboardFile.TabIndex = 14;
            this.buttonBrowseKeyboardFile.Text = "...";
            this.buttonBrowseKeyboardFile.UseVisualStyleBackColor = true;
            this.buttonBrowseKeyboardFile.Click += new System.EventHandler(this.buttonBrowseKeyboardFile_Click);
            // 
            // textBoxKeyboardLogFile
            // 
            this.textBoxKeyboardLogFile.Location = new System.Drawing.Point(219, 38);
            this.textBoxKeyboardLogFile.Name = "textBoxKeyboardLogFile";
            this.textBoxKeyboardLogFile.Size = new System.Drawing.Size(413, 26);
            this.textBoxKeyboardLogFile.TabIndex = 13;
            // 
            // labelConfigurationFile
            // 
            this.labelConfigurationFile.AutoSize = true;
            this.labelConfigurationFile.Location = new System.Drawing.Point(15, 113);
            this.labelConfigurationFile.Name = "labelConfigurationFile";
            this.labelConfigurationFile.Size = new System.Drawing.Size(198, 20);
            this.labelConfigurationFile.TabIndex = 11;
            this.labelConfigurationFile.Text = "Current Configuration File :";
            // 
            // labelKeyoardLogFile
            // 
            this.labelKeyoardLogFile.AutoSize = true;
            this.labelKeyoardLogFile.Location = new System.Drawing.Point(15, 41);
            this.labelKeyoardLogFile.Name = "labelKeyoardLogFile";
            this.labelKeyoardLogFile.Size = new System.Drawing.Size(144, 20);
            this.labelKeyoardLogFile.TabIndex = 10;
            this.labelKeyoardLogFile.Text = "Keyboard Log File :";
            // 
            // textBoxCurretConfFile
            // 
            this.textBoxCurretConfFile.Location = new System.Drawing.Point(219, 110);
            this.textBoxCurretConfFile.Name = "textBoxCurretConfFile";
            this.textBoxCurretConfFile.ReadOnly = true;
            this.textBoxCurretConfFile.Size = new System.Drawing.Size(413, 26);
            this.textBoxCurretConfFile.TabIndex = 9;
            // 
            // labelGloveLogFile
            // 
            this.labelGloveLogFile.AutoSize = true;
            this.labelGloveLogFile.Location = new System.Drawing.Point(15, 79);
            this.labelGloveLogFile.Name = "labelGloveLogFile";
            this.labelGloveLogFile.Size = new System.Drawing.Size(118, 20);
            this.labelGloveLogFile.TabIndex = 8;
            this.labelGloveLogFile.Text = "Glove Log File :";
            // 
            // textBoxGloveLogFile
            // 
            this.textBoxGloveLogFile.Location = new System.Drawing.Point(219, 73);
            this.textBoxGloveLogFile.Name = "textBoxGloveLogFile";
            this.textBoxGloveLogFile.Size = new System.Drawing.Size(413, 26);
            this.textBoxGloveLogFile.TabIndex = 2;
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
            // subRunEditorControl
            // 
            this.subRunEditorControl.ConfigurationObject = null;
            this.subRunEditorControl.Location = new System.Drawing.Point(20, 123);
            this.subRunEditorControl.Name = "subRunEditorControl";
            this.subRunEditorControl.Size = new System.Drawing.Size(658, 365);
            this.subRunEditorControl.TabIndex = 11;
            // 
            // vrHandEditorControl
            // 
            this.vrHandEditorControl.ConfigurationObject = null;
            this.vrHandEditorControl.Location = new System.Drawing.Point(18, 234);
            this.vrHandEditorControl.Name = "vrHandEditorControl";
            this.vrHandEditorControl.Size = new System.Drawing.Size(655, 473);
            this.vrHandEditorControl.TabIndex = 15;
            // 
            // ExperimentConfiugrationEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 861);
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
        private System.Windows.Forms.TextBox textBoxKeyboardLogFile;
        private System.Windows.Forms.Label labelConfigurationFile;
        private System.Windows.Forms.Label labelKeyoardLogFile;
        private System.Windows.Forms.TextBox textBoxCurretConfFile;
        private System.Windows.Forms.Label labelGloveLogFile;
        private System.Windows.Forms.TextBox textBoxGloveLogFile;
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
    }
}