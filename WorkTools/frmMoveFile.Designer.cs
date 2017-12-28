namespace WorkTools {
    partial class frmMoveFile {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoveFile));
            this.ll = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnMoveToLast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ll
            // 
            this.ll.AutoSize = true;
            this.ll.Location = new System.Drawing.Point(14, 14);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(49, 13);
            this.ll.TabIndex = 0;
            this.ll.Text = "Filename";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(14, 38);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(35, 13);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Directory";
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDirectory.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(14, 87);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentDirectory.TabIndex = 2;
            this.lblCurrentDirectory.Text = "label2";
            this.lblCurrentDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblCurrentDirectory_MouseClick);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Location = new System.Drawing.Point(17, 151);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(678, 46);
            this.btnMove.TabIndex = 3;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            this.btnMove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnMove_KeyDown);
            // 
            // btnMoveToLast
            // 
            this.btnMoveToLast.Location = new System.Drawing.Point(17, 203);
            this.btnMoveToLast.Name = "btnMoveToLast";
            this.btnMoveToLast.Size = new System.Drawing.Size(678, 46);
            this.btnMoveToLast.TabIndex = 4;
            this.btnMoveToLast.Text = "Move To:";
            this.btnMoveToLast.UseVisualStyleBackColor = true;
            this.btnMoveToLast.Click += new System.EventHandler(this.btnMoveToLast_Click);
            this.btnMoveToLast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnMoveToLast_KeyDown);
            // 
            // frmMoveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 261);
            this.Controls.Add(this.btnMoveToLast);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.lblCurrentDirectory);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMoveFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move File";
            this.Load += new System.EventHandler(this.frmMoveFile_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMoveFile_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ll;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnMoveToLast;
    }
}