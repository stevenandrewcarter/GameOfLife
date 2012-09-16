using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace GameOfLife.Engine {
  public class World {

    #region Private Variables

    private int height;
    private int width;    

    #endregion

    #region Constructor

    public World(int aHeight, int aWidth) {
      height = aHeight;
      width = aWidth;
      CurrentWorld = new Cell[height, width];
      NextWorld = new Cell[height, width];
      NumberOfCells = height * width;
    }

    #endregion

    #region Properties

    public Cell[,] CurrentWorld { get; private set; }
    public Cell[,] NextWorld { get; private set; }
    public int AliveCells { get; private set; }
    public int NumberOfCells { get; private set; }

    #endregion

    #region Public Methods

    /// <summary>
    /// Seeds the world with the Cells
    /// </summary>
    /// <param name="lifeChance">Chance that the cell will be alive</param>
    public void Seed(int lifeChance) {
      Random rnd = new Random(Environment.TickCount);
      // Generate the cells
      for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
          CurrentWorld[i, j] = new Cell(i, j, 10) { Alive = rnd.Next(100) < lifeChance };
        }
      }
      // Detect the neighbours
      for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
          DetectNeighbours(ref CurrentWorld[i, j], i, j);
        }
      }
    }

    public void Evolve(Graphics g) {
      g.Clear(Color.Black);
      for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
          NextWorld[i, j] = CurrentWorld[i, j].NextGeneration();
        }
      }
      CurrentWorld = NextWorld;
      AliveCells = 0;
      for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
          Cell cell = CurrentWorld[i, j];
          if (cell.Alive) { AliveCells++; }
          DetectNeighbours(ref CurrentWorld[i, j], i, j);
          double ratio = ((double)cell.Neighbours.Count / 8.0) * 255;
          Color cellColourOne = cell.Alive ? Color.FromArgb(0, 0, (int)ratio) : Color.Black;
          Color cellColourTwo = cell.Alive ? Color.FromArgb(0, (int)ratio, 0) : Color.Black;
          LinearGradientBrush lBrush = new LinearGradientBrush(cell.CellGraphic, cellColourOne, cellColourTwo, LinearGradientMode.BackwardDiagonal);
          g.FillRectangle(lBrush, cell.CellGraphic); 
        }
      }      
    }

    #endregion

    #region Private Methods

    private void DetectNeighbours(ref Cell cell, int xPos, int yPos) {
      cell.Neighbours.Clear();                          
      // Get the north position
      int northPos = xPos == 0 ? height - 1 : xPos - 1;
      cell.Neighbours.Add(CurrentWorld[northPos, yPos]);
      // Get the south position
      int southPos = xPos == height - 1 ? southPos = 0 : xPos + 1;
      cell.Neighbours.Add(CurrentWorld[southPos, yPos]);
      // Get the east position      
      int eastPos = yPos == 0 ? width - 1 : yPos - 1;
      cell.Neighbours.Add(CurrentWorld[xPos, eastPos]);
      // Get the south position      
      int westPos = yPos == width - 1 ? 0 : yPos + 1;      
      cell.Neighbours.Add(CurrentWorld[xPos, westPos]);
      cell.Neighbours.Add(CurrentWorld[northPos, eastPos]);
      cell.Neighbours.Add(CurrentWorld[northPos, westPos]);
      cell.Neighbours.Add(CurrentWorld[southPos, eastPos]);
      cell.Neighbours.Add(CurrentWorld[southPos, westPos]);
    }

    #endregion
  }
}