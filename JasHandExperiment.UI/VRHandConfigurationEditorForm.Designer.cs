namespace JasHandExperiment.UI
{
    partial class VRHandConfigurationEditorForm
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.vrHandEditorControl = new JasHandExperiment.UI.VRHandEditorControl();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(623, 499);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(203, 50);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 499);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(203, 50);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // vrHandEditorControl
            // 
            this.vrHandEditorControl.ConfigurationObject = null;
            this.vrHandEditorControl.Location = new System.Drawing.Point(12, 12);
            this.vrHandEditorControl.Name = "vrHandEditorControl";
            this.vrHandEditorControl.Size = new System.Drawing.Size(803, 481);
            this.vrHandEditorControl.TabIndex = 4;
            // 
            // VRHandConfigurationEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 554);
            this.Controls.Add(this.vrHandEditorControl);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Name = "VRHandConfigurationEditorForm";
            this.Text = "VRHandConfigurationEditorForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private VRHandEditorControl vrHandEditorControl;
    }
}