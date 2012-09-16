using System;
using GameOfLife.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test {
  
  [TestClass]
  public class CellTests {

    private Cell cell;

    [TestInitialize]
    public void Setup() {
      cell = new Cell(1, 1, 1, 1, 1);
    }

    [TestMethod]
    public void NextGenerationDiesUnderPopulated() {
      cell.Alive = true;
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });      
      Cell nextGeneration = cell.NextGeneration();
      Assert.AreEqual(false, nextGeneration.Alive);
    }

    [TestMethod]
    public void NextGenerationAliveWithTwoNeighbours() {
      cell.Alive = true;
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      Cell nextGeneration = cell.NextGeneration();
      Assert.AreEqual(true, nextGeneration.Alive);
    }

    [TestMethod]
    public void NextGenerationAliveWithThreeoNeighbours() {
      cell.Alive = true;
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      Cell nextGeneration = cell.NextGeneration();
      Assert.AreEqual(true, nextGeneration.Alive);
    }

    [TestMethod]
    public void NextGenerationDiesWithFouroNeighbours() {
      cell.Alive = true;
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      Cell nextGeneration = cell.NextGeneration();
      Assert.AreEqual(false, nextGeneration.Alive);
    }

    [TestMethod]
    public void NextGenerationAliveWithThreeNeighbours() {
      cell.Alive = false;
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });
      cell.Neighbours.Add(new Cell(1, 1, 1, 1, 1) { Alive = true });      
      Cell nextGeneration = cell.NextGeneration();
      Assert.AreEqual(true, nextGeneration.Alive);
    }
  }
}
