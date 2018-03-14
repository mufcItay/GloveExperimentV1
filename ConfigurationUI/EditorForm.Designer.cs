namespace ConfigurationUI
{
    partial class EditorForm
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
            this.propertyGrid_Editor = new System.Windows.Forms.PropertyGrid();
            this.groupBox_Buttons = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBox_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.propertyGrid_Editor);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBox_Buttons);
            this.splitContainerMain.Size = new System.Drawing.Size(922, 678);
            this.splitContainerMain.SplitterDistance = 724;
            this.splitContainerMain.TabIndex = 0;
            // 
            // propertyGrid_Editor
            // 
            this.propertyGrid_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_Editor.Font = new System.Drawing.Font("Arial", 10F);
            this.propertyGrid_Editor.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid_Editor.Name = "propertyGrid_Editor";
            this.propertyGrid_Editor.Size = new System.Drawing.Size(724, 678);
            this.propertyGrid_Editor.TabIndex = 3;
            this.propertyGrid_Editor.UseCompatibleTextRendering = true;
            // 
            // groupBox_Buttons
            // 
            this.groupBox_Buttons.Controls.Add(this.buttonSave);
            this.groupBox_Buttons.Controls.Add(this.buttonLoad);
            this.groupBox_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Buttons.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Buttons.Name = "groupBox_Buttons";
            this.groupBox_Buttons.Size = new System.Drawing.Size(194, 678);
            this.groupBox_Buttons.TabIndex = 0;
            this.groupBox_Buttons.TabStop = false;
            this.groupBox_Buttons.Text = "Operations";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 116);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(182, 55);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(6, 55);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(182, 55);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 678);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBox_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.PropertyGrid propertyGrid_Editor;
        private System.Windows.Forms.GroupBox groupBox_Buttons;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
    }
}

