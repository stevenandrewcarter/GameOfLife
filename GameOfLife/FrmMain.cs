using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GameOfLife.Engine;
using NLog;

namespace GameOfLife {
  public partial class FrmMain : Form {

    #region Private Variables      
    private BackgroundWorker bgWorker = new BackgroundWorker();
    private World world;
    private int generation;
    private bool invokeClose;
    private int worldSize;
    #endregion

    public FrmMain() {
      worldSize = 150;
      InitializeComponent();      
      this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
      this.UpdateStyles();
      world = new World(worldSize, worldSize);
      world.Seed(25, pnlMain.Width / worldSize, pnlMain.Height / worldSize);
      generation = 0;
      bgWorker.DoWork += bgWorker_DoWork;
      bgWorker.WorkerSupportsCancellation = true;
      bgWorker.RunWorkerAsync();
      invokeClose = false;
      FormClosing += FrmMain_FormClosing;
    }

    void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
      bgWorker.CancelAsync();
      invokeClose = true;
    }

    void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
      while (!bgWorker.CancellationPending) {
        generation++;
        Bitmap BackBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        Graphics g = Graphics.FromImage(BackBuffer);
        world.Evolve(g);
        Graphics Viewable = pnlMain.CreateGraphics();
        Viewable.DrawImageUnscaled(BackBuffer, 0, 0);
        if (InvokeRequired && !invokeClose) {
          try {
            this.Invoke(new MethodInvoker(InvokeStatusBar));
          }
          catch (Exception) {
          }
        }
        System.Threading.Thread.Sleep(100);
      }
    }

    private void InvokeStatusBar() {
      lblGeneration.Text = String.Format("Generation: {0}", generation);
      lblAliveCells.Text = string.Format("Alive Cells: {0} / {1}", world.AliveCells, world.NumberOfCells);
      prgAlivePercentage.Maximum = world.NumberOfCells;
      prgAlivePercentage.Value = world.AliveCells;      
    }
  }
}
