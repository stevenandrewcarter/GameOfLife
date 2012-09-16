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
      this.pnlMain = new System.Windows.Forms.Panel();
      this.stsInfo.SuspendLayout();
      this.SuspendLayout();
      // 
      // stsInfo
      // 
      this.stsInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGeneration,
            this.lblAliveCells,
            this.prgAlivePercentage});
      this.stsInfo.Location = new System.Drawing.Point(0, 538);
      this.stsInfo.Name = "stsInfo";
      this.stsInfo.Size = new System.Drawing.Size(784, 24);
      this.stsInfo.TabIndex = 0;
      this.stsInfo.Text = "statusStrip1";
      // 
      // lblGeneration
      // 
      this.lblGeneration.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblGeneration.Name = "lblGeneration";
      this.lblGeneration.Size = new System.Drawing.Size(72, 19);
      this.lblGeneration.Text = "Generation:";
      // 
      // lblAliveCells
      // 
      this.lblAliveCells.Name = "lblAliveCells";
      this.lblAliveCells.Size = new System.Drawing.Size(64, 19);
      this.lblAliveCells.Text = "Alive Cells:";
      // 
      // prgAlivePercentage
      // 
      this.prgAlivePercentage.Name = "prgAlivePercentage";
      this.prgAlivePercentage.Size = new System.Drawing.Size(100, 18);
      // 
      // pnlMain
      // 
      this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMain.Location = new System.Drawing.Point(0, 0);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(784, 538);
      this.pnlMain.TabIndex = 1;
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 562);
      this.Controls.Add(this.pnlMain);
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
    private System.Windows.Forms.Panel pnlMain;
  }
}

