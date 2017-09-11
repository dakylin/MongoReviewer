namespace MongoReviewer
{
    partial class frmMain
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
            this.TV1 = new System.Windows.Forms.TreeView();
            this.LV = new System.Windows.Forms.ListView();
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // TV1
            // 
            this.TV1.Location = new System.Drawing.Point(12, 12);
            this.TV1.Name = "TV1";
            this.TV1.Size = new System.Drawing.Size(249, 462);
            this.TV1.TabIndex = 0;
            this.TV1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV1_AfterSelect);
            // 
            // LV
            // 
            this.LV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Key,
            this.Value,
            this.Type});
            this.LV.GridLines = true;
            this.LV.Location = new System.Drawing.Point(287, 87);
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(755, 387);
            this.LV.TabIndex = 1;
            this.LV.UseCompatibleStateImageBehavior = false;
            this.LV.View = System.Windows.Forms.View.Details;
            // 
            // Key
            // 
            this.Key.Text = "Key";
            // 
            // Value
            // 
            this.Value.Text = "Value";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 486);
            this.Controls.Add(this.LV);
            this.Controls.Add(this.TV1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Mongo Viewer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TV1;
        private System.Windows.Forms.ListView LV;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ColumnHeader Type;
    }
}

