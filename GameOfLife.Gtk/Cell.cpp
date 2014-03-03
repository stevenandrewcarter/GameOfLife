#include "Cell.h"

Cell::Cell(int aX, int aY, int aWidth, int aHeight)
{
  x = aX;
  y = aY;
  width = aWidth;
  height = aHeight;
  alive = true;
}

Cell::~Cell(void)
{
}

bool Cell::IsAlive()
{
  return alive;
}

Cell Cell::NextGeneration()
{	
  Cell nextGen = Cell(x, y, width, height);
  nextGen.SetNeighbours(neighbours);
  int liveNeighbours = 0;
  for (std::list<Cell*>::iterator i = neighbours.begin(); i != neighbours.end(); i++)
  {
    if ((*i)->IsAlive())
    {
      liveNeighbours++;
    }
  }
  // Check if the nextGeneration is alive
  if (alive) {
    nextGen.SetAlive(liveNeighbours == 2 || liveNeighbours == 3);
  }
  else {
    // Check if the nextGeneration is reborn
    nextGen.SetAlive(liveNeighbours == 3);
  }
  return nextGen;
}

void Cell::SetNeighbours(std::list<Cell*> newNeighbours)
{
  neighbours = newNeighbours;
}

void Cell::SetAlive(bool isAlive)
{
  alive = isAlive;
}

void Cell::ClearNeighbours()
{
  neighbours.clear();
}

std::list<Cell*> Cell::GetNeighbours()
{
  return neighbours;
}

int Cell::GetX()
{
  return x;
}

int Cell::GetY()
{
  return y;
}

int Cell::GetWidth()
{
  return width;
}

int Cell::GetHeight()
{
  return height;
}

void Cell::AddNeighbour(Cell* neighbour)
{
  neighbours.push_back(neighbour);
}