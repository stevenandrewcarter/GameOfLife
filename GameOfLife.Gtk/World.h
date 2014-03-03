#pragma once
#include <gtk-2.0\gtk\gtk.h>
#include <vector>
#include "Cell.h"

typedef Cell** MATRIX;

class World
{
public:
  World(int aHeight, int aWidth);
  ~World(void);

  int GetAliveCells();
  int GetNumberOfCells();

  MATRIX GetWorld();
  MATRIX GetNextWorld();

  void Seed(int lifeChance, int cellWidth, int cellHeight);
  void Evolve(cairo_t* cr);

private:
  int height;
  int width;
  int numberOfCells;
  int aliveCells;
  MATRIX currentWorld;
  MATRIX nextWorld;

  void DetectNeighbours(Cell* cell, int xPos, int yPos);  
};