using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife.Engine {
  public class Cell {
    #region Private Variables
    private int x;
    private int y;
    #endregion

    #region Constructor

    public Cell(int xPos, int yPos, int offset) {
      Neighbours = new List<Cell>();
      x = xPos;
      y = yPos;
      CellGraphic = new Rectangle(x * offset, y * offset, 10, 10);
    }

    #endregion

    #region Properties

    public bool Alive { get; set; }
    public List<Cell> Neighbours { get; set; }
    public Rectangle CellGraphic { get; set; }

    #endregion

    #region Public Methods

    public Cell NextGeneration() {
      var nextGeneration = new Cell(x, y, 10) { Neighbours = Neighbours };
      int liveNeighbours = 0;
      foreach (Cell neighbour in Neighbours) {
        if (neighbour.Alive) {
          liveNeighbours++;
        }
      }
      // Check if the nextGeneration is alive
      if (Alive) {
        nextGeneration.Alive = liveNeighbours == 2 || liveNeighbours == 3;        
      }
      else {
        // Check if the nextGeneration is reborn
        nextGeneration.Alive = liveNeighbours == 3;
      }
      return nextGeneration;
    }

    #endregion
  }
}
