namespace JasHandExperiment.UI
{
    partial class VRHandEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialogModel = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxVRHandEditor = new System.Windows.Forms.GroupBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.labelTone = new System.Windows.Forms.Label();
            this.trackBarTone = new System.Windows.Forms.TrackBar();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.labelHandColor = new System.Windows.Forms.Label();
            this.radioButtonLeftHand = new System.Windows.Forms.RadioButton();
            this.button_ColorDialog = new System.Windows.Forms.Button();
            this.radioButtonRightHand = new System.Windows.Forms.RadioButton();
            this.linkLabelChangeModel = new System.Windows.Forms.LinkLabel();
            this.labelHandToAnimate = new System.Windows.Forms.Label();
            this.elementHost_Hands = new System.Windows.Forms.Integration.ElementHost();
            this.groupBoxVRHandEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTone)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogModel
            // 
            this.openFileDialogModel.Filter = "\"XML Files | *.xml\"";
            // 
            // groupBoxVRHandEditor
            // 
            this.groupBoxVRHandEditor.Controls.Add(this.splitContainerMain);
            this.groupBoxVRHandEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxVRHandEditor.Location = new System.Drawing.Point(0, 0);
            this.groupBoxVRHandEditor.Name = "groupBoxVRHandEditor";
            this.groupBoxVRHandEditor.Size = new System.Drawing.Size(614, 438);
            this.groupBoxVRHandEditor.TabIndex = 6;
            this.groupBoxVRHandEditor.TabStop = false;
            this.groupBoxVRHandEditor.Text = "VR Hand Editor";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 22);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.labelTone);
            this.splitContainerMain.Panel1.Controls.Add(this.trackBarTone);
            this.splitContainerMain.Panel1.Controls.Add(this.radioButtonNone);
            this.splitContainerMain.Panel1.Controls.Add(this.labelHandColor);
            this.splitContainerMain.Panel1.Controls.Add(this.radioButtonLeftHand);
            this.splitContainerMain.Panel1.Controls.Add(this.button_ColorDialog);
            this.splitContainerMain.Panel1.Controls.Add(this.radioButtonRightHand);
            this.splitContainerMain.Panel1.Controls.Add(this.linkLabelChangeModel);
            this.splitContainerMain.Panel1.Controls.Add(this.labelHandToAnimate);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.elementHost_Hands);
            this.splitContainerMain.Size = new System.Drawing.Size(608, 413);
            this.splitContainerMain.SplitterDistance = 196;
            this.splitContainerMain.TabIndex = 3;
            // 
            // labelTone
            // 
            this.labelTone.AutoSize = true;
            this.labelTone.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTone.Location = new System.Drawing.Point(15, 134);
            this.labelTone.Name = "labelTone";
            this.labelTone.Size = new System.Drawing.Size(62, 27);
            this.labelTone.TabIndex = 21;
            this.labelTone.Text = "Tone:";
            // 
            // trackBarTone
            // 
            this.trackBarTone.Location = new System.Drawing.Point(14, 170);
            this.trackBarTone.Maximum = 5;
            this.trackBarTone.Minimum = 1;
            this.trackBarTone.Name = "trackBarTone";
            this.trackBarTone.Size = new System.Drawing.Size(104, 69);
            this.trackBarTone.TabIndex = 20;
            this.trackBarTone.Value = 3;
            this.trackBarTone.Scroll += new System.EventHandler(this.trackBarTone_Scroll);
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.AutoSize = true;
            this.radioButtonNone.Checked = true;
            this.radioButtonNone.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonNone.Location = new System.Drawing.Point(11, 341);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(86, 31);
            this.radioButtonNone.TabIndex = 19;
            this.radioButtonNone.TabStop = true;
            this.radioButtonNone.Text = "None";
            this.radioButtonNone.UseVisualStyleBackColor = true;
            // 
            // labelHandColor
            // 
            this.labelHandColor.AutoSize = true;
            this.labelHandColor.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHandColor.Location = new System.Drawing.Point(15, 47);
            this.labelHandColor.Name = "labelHandColor";
            this.labelHandColor.Size = new System.Drawing.Size(121, 27);
            this.labelHandColor.TabIndex = 8;
            this.labelHandColor.Text = "Hand Color:";
            // 
            // radioButtonLeftHand
            // 
            this.radioButtonLeftHand.AutoSize = true;
            this.radioButtonLeftHand.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonLeftHand.Location = new System.Drawing.Point(11, 311);
            this.radioButtonLeftHand.Name = "radioButtonLeftHand";
            this.radioButtonLeftHand.Size = new System.Drawing.Size(71, 31);
            this.radioButtonLeftHand.TabIndex = 18;
            this.radioButtonLeftHand.Text = "Left";
            this.radioButtonLeftHand.UseVisualStyleBackColor = true;
            // 
            // button_ColorDialog
            // 
            this.button_ColorDialog.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_ColorDialog.Location = new System.Drawing.Point(11, 77);
            this.button_ColorDialog.Name = "button_ColorDialog";
            this.button_ColorDialog.Size = new System.Drawing.Size(171, 46);
            this.button_ColorDialog.TabIndex = 7;
            this.button_ColorDialog.Text = "Manual";
            this.button_ColorDialog.UseVisualStyleBackColor = true;
            this.button_ColorDialog.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // radioButtonRightHand
            // 
            this.radioButtonRightHand.AutoSize = true;
            this.radioButtonRightHand.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonRightHand.Location = new System.Drawing.Point(11, 281);
            this.radioButtonRightHand.Name = "radioButtonRightHand";
            this.radioButtonRightHand.Size = new System.Drawing.Size(83, 31);
            this.radioButtonRightHand.TabIndex = 17;
            this.radioButtonRightHand.Text = "Right";
            this.radioButtonRightHand.UseVisualStyleBackColor = true;
            // 
            // linkLabelChangeModel
            // 
            this.linkLabelChangeModel.AutoSize = true;
            this.linkLabelChangeModel.Location = new System.Drawing.Point(10, 17);
            this.linkLabelChangeModel.Name = "linkLabelChangeModel";
            this.linkLabelChangeModel.Size = new System.Drawing.Size(91, 20);
            this.linkLabelChangeModel.TabIndex = 6;
            this.linkLabelChangeModel.TabStop = true;
            this.linkLabelChangeModel.Text = "HandModel";
            this.linkLabelChangeModel.Visible = false;
            // 
            // labelHandToAnimate
            // 
            this.labelHandToAnimate.AutoSize = true;
            this.labelHandToAnimate.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHandToAnimate.Location = new System.Drawing.Point(15, 241);
            this.labelHandToAnimate.Name = "labelHandToAnimate";
            this.labelHandToAnimate.Size = new System.Drawing.Size(175, 27);
            this.labelHandToAnimate.TabIndex = 16;
            this.labelHandToAnimate.Text = "Hand To Animate:";
            // 
            // elementHost_Hands
            // 
            this.elementHost_Hands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost_Hands.Location = new System.Drawing.Point(0, 0);
            this.elementHost_Hands.Name = "elementHost_Hands";
            this.elementHost_Hands.Size = new System.Drawing.Size(408, 413);
            this.elementHost_Hands.TabIndex = 1;
            this.elementHost_Hands.Text = "Hand Editor";
            this.elementHost_Hands.Child = null;
            // 
            // VRHandEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBoxVRHandEditor);
            this.Name = "VRHandEditorControl";
            this.Size = new System.Drawing.Size(614, 438);
            this.groupBoxVRHandEditor.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogModel;
        private System.Windows.Forms.GroupBox groupBoxVRHandEditor;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Integration.ElementHost elementHost_Hands;
        private System.Windows.Forms.Label labelHandColor;
        private System.Windows.Forms.Button button_ColorDialog;
        private System.Windows.Forms.LinkLabel linkLabelChangeModel;
        private System.Windows.Forms.RadioButton radioButtonNone;
        private System.Windows.Forms.RadioButton radioButtonLeftHand;
        private System.Windows.Forms.RadioButton radioButtonRightHand;
        private System.Windows.Forms.Label labelHandToAnimate;
        private System.Windows.Forms.Label labelTone;
        private System.Windows.Forms.TrackBar trackBarTone;
    }
}
