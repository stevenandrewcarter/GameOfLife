#include "World.h"
#include <list>

World::World(int aHeight, int aWidth)
{
  aliveCells = 0;
  height = aHeight;
  width = aWidth;    
  currentWorld = new Cell*[height];
  for(int i = 0; i < height; i++) 
  {   
    currentWorld[i] = new Cell[width];
  }
  nextWorld = new Cell*[height];
  for(int i = 0; i < height; i++) 
  {   
    nextWorld[i] = new Cell[width];
  }
  numberOfCells = height * width;
}

World::~World(void)
{
}

int World::GetAliveCells() 
{
  return aliveCells;
}

int World::GetNumberOfCells()
{
  return numberOfCells;
}

MATRIX World::GetWorld()
{
  return currentWorld;
}

MATRIX World::GetNextWorld()
{
  return nextWorld;
}

void World::Seed(int lifeChance, int cellWidth, int cellHeight)
{
  // Generate the cells
  for(int i = 0; i < height; i++)
  {    
    for(int j = 0; j < width; j++)
    {
      currentWorld[i][j] = Cell(i, j, cellWidth, cellHeight);
      currentWorld[i][j].SetAlive(rand() % 100 < lifeChance);
    }
  }
  // Detect the neighbours
  for (int i = 0; i < height; i++) {
    for (int j = 0; j < width; j++) {
      DetectNeighbours(&currentWorld[i][j], i, j);
    }
  }
}

void World::Evolve(cairo_t* cr)
{
  for (int i = 0; i < height; i++) {
    for (int j = 0; j < width; j++) {
      nextWorld[i][j] = currentWorld[i][j].NextGeneration();
    }
  }
  // CurrentWorld = NextWorld;
  aliveCells = 0;
  for (int i = 0; i < height; i++) {
    for (int j = 0; j < width; j++) {
      Cell cell = currentWorld[i][j];
      // DetectNeighbours(&cell, i, j);
      if (cell.IsAlive()) 
      { 
        aliveCells++;         
        cairo_set_source_rgb(cr, 0, 0, 255);
      }
      else
      {
        cairo_set_source_rgb(cr, 0, 0, 0);
      }      
      cairo_rectangle(cr, cell.GetX() * cell.GetWidth(), cell.GetY() * cell.GetHeight(), cell.GetWidth(), cell.GetHeight()); 
      cairo_fill (cr);
    }
  }      
}

void World::DetectNeighbours(Cell* cell, int xPos, int yPos)
{
  cell->ClearNeighbours();  
  // Get the north position
  int northPos = xPos == 0 ? height - 1 : xPos - 1;
  cell->AddNeighbour(&currentWorld[northPos][yPos]);
  // Get the south position
  int southPos = xPos == height - 1 ? southPos = 0 : xPos + 1;
  cell->AddNeighbour(&currentWorld[southPos][yPos]);
  // Get the east position      
  int eastPos = yPos == 0 ? width - 1 : yPos - 1;
  cell->AddNeighbour(&currentWorld[xPos][eastPos]);
  // Get the south position      
  int westPos = yPos == width - 1 ? 0 : yPos + 1;      
  cell->AddNeighbour(&currentWorld[xPos][westPos]);
  cell->AddNeighbour(&currentWorld[northPos][eastPos]);
  cell->AddNeighbour(&currentWorld[northPos][westPos]);
  cell->AddNeighbour(&currentWorld[southPos][eastPos]);
  cell->AddNeighbour(&currentWorld[southPos][westPos]);  
}