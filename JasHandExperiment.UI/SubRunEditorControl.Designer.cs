namespace JasHandExperiment.UI
{
    partial class SubRunEditorControl
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.propertyGrid_Collection = new System.Windows.Forms.PropertyGrid();
            this.groupBox_CollectionOperations = new System.Windows.Forms.GroupBox();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Load = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBox_CollectionOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.propertyGrid_Collection);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBox_CollectionOperations);
            this.splitContainerMain.Size = new System.Drawing.Size(505, 324);
            this.splitContainerMain.SplitterDistance = 354;
            this.splitContainerMain.TabIndex = 4;
            // 
            // propertyGrid_Collection
            // 
            this.propertyGrid_Collection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_Collection.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid_Collection.Name = "propertyGrid_Collection";
            this.propertyGrid_Collection.Size = new System.Drawing.Size(354, 324);
            this.propertyGrid_Collection.TabIndex = 8;
            // 
            // groupBox_CollectionOperations
            // 
            this.groupBox_CollectionOperations.Controls.Add(this.button_Remove);
            this.groupBox_CollectionOperations.Controls.Add(this.button_Add);
            this.groupBox_CollectionOperations.Controls.Add(this.button_Load);
            this.groupBox_CollectionOperations.Controls.Add(this.button_Save);
            this.groupBox_CollectionOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_CollectionOperations.Location = new System.Drawing.Point(0, 0);
            this.groupBox_CollectionOperations.Name = "groupBox_CollectionOperations";
            this.groupBox_CollectionOperations.Size = new System.Drawing.Size(147, 324);
            this.groupBox_CollectionOperations.TabIndex = 9;
            this.groupBox_CollectionOperations.TabStop = false;
            this.groupBox_CollectionOperations.Text = "Operations";
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(6, 98);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(123, 39);
            this.button_Remove.TabIndex = 7;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(6, 42);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(123, 39);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(6, 234);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(123, 39);
            this.button_Load.TabIndex = 5;
            this.button_Load.Text = "Load Sub Run";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(6, 178);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(123, 39);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save Sub Run";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // SubRunEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "SubRunEditorControl";
            this.Size = new System.Drawing.Size(505, 324);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBox_CollectionOperations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.PropertyGrid propertyGrid_Collection;
        private System.Windows.Forms.GroupBox groupBox_CollectionOperations;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_Save;
    }
}
