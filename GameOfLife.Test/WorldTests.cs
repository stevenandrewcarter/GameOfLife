using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.Engine;

namespace GameOfLife.Test {
  [TestClass]
  public class WorldTests {
    [TestMethod]
    public void ConstructorTest() {
      World world = new World(20, 20);
      Assert.AreEqual(400, world.CurrentWorld.Length);
      Assert.AreEqual(400, world.NextWorld.Length);
    }

  }
}