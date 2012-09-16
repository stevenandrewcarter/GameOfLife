namespace GameOfLife {
  partial class FrmMain {
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
      this.stsInfo = new System.Windows.Forms.StatusStrip();
      this.lblGeneration = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblAliveCells = new System.Windows.Forms.ToolStripStatusLabel();
      this.prgAlivePercentage = new System.Windows.Forms.ToolStripProgressBar();
      this.stsInfo.SuspendLayout();
      this.SuspendLayout();
      // 
      // stsInfo
      // 
      this.stsInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGeneration,
            this.lblAliveCells,
            this.prgAlivePercentage});
      this.stsInfo.Location = new System.Drawing.Point(0, 420);
      this.stsInfo.Name = "stsInfo";
      this.stsInfo.Size = new System.Drawing.Size(624, 22);
      this.stsInfo.TabIndex = 0;
      this.stsInfo.Text = "statusStrip1";
      // 
      // lblGeneration
      // 
      this.lblGeneration.Name = "lblGeneration";
      this.lblGeneration.Size = new System.Drawing.Size(68, 17);
      this.lblGeneration.Text = "Generation:";
      // 
      // lblAliveCells
      // 
      this.lblAliveCells.Name = "lblAliveCells";
      this.lblAliveCells.Size = new System.Drawing.Size(64, 17);
      this.lblAliveCells.Text = "Alive Cells:";
      // 
      // prgAlivePercentage
      // 
      this.prgAlivePercentage.Name = "prgAlivePercentage";
      this.prgAlivePercentage.Size = new System.Drawing.Size(100, 16);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 442);
      this.Controls.Add(this.stsInfo);
      this.Name = "FrmMain";
      this.Text = "Game Of Life";
      this.stsInfo.ResumeLayout(false);
      this.stsInfo.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip stsInfo;
    private System.Windows.Forms.ToolStripStatusLabel lblGeneration;
    private System.Windows.Forms.ToolStripStatusLabel lblAliveCells;
    private System.Windows.Forms.ToolStripProgressBar prgAlivePercentage;
  }
}

