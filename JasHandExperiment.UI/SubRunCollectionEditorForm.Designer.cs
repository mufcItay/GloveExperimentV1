namespace JasHandExperiment.UI
{
    partial class SubRunCollectionEditorForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBox_Operations = new System.Windows.Forms.GroupBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.subRunEditorControl = new JasHandExperiment.UI.SubRunEditorControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBox_Operations.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.subRunEditorControl);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBox_Operations);
            this.splitContainerMain.Size = new System.Drawing.Size(660, 547);
            this.splitContainerMain.SplitterDistance = 463;
            this.splitContainerMain.TabIndex = 1;
            // 
            // groupBox_Operations
            // 
            this.groupBox_Operations.Controls.Add(this.button_OK);
            this.groupBox_Operations.Controls.Add(this.button_Cancel);
            this.groupBox_Operations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Operations.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Operations.Name = "groupBox_Operations";
            this.groupBox_Operations.Size = new System.Drawing.Size(660, 80);
            this.groupBox_Operations.TabIndex = 3;
            this.groupBox_Operations.TabStop = false;
            this.groupBox_Operations.Text = "Operations";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(67, 27);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(203, 50);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(407, 27);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(203, 50);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // subRunEditorControl
            // 
            this.subRunEditorControl.ConfigurationObject = null;
            this.subRunEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subRunEditorControl.Location = new System.Drawing.Point(0, 0);
            this.subRunEditorControl.Name = "subRunEditorControl";
            this.subRunEditorControl.Size = new System.Drawing.Size(660, 463);
            this.subRunEditorControl.TabIndex = 0;
            // 
            // SubRunCollectionEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 547);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "SubRunCollectionEditorForm";
            this.Text = "VRHandConfigurationEditorForm";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBox_Operations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBox_Operations;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private SubRunEditorControl subRunEditorControl;
    }
}