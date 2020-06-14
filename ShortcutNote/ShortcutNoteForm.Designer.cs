namespace ShortcutNote
{
    partial class ShortcutNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortcutNote));
            this.TxtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtNote
            // 
            resources.ApplyResources(this.TxtNote, "TxtNote");
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNote_KeyDown);
            // 
            // ShortcutNote
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.TxtNote);
            this.Name = "ShortcutNote";
            this.Load += new System.EventHandler(this.ShortcutNote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShortcutNote_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNote;
    }
}