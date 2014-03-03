#pragma once
#include <list>

class Cell
{
public:
  Cell() 
  { 
    x = 0;
    y = 0;
    height = 0;
    width = 0;
  };

  Cell(int aX, int aY, int aWidth, int aHeight);
  ~Cell(void);

  bool IsAlive();
  void SetAlive(bool isAlive);

  Cell NextGeneration();

  void SetNeighbours(std::list<Cell*> newNeighbours);
  void AddNeighbour(Cell* neighbour);
  std::list<Cell*> GetNeighbours();

  void ClearNeighbours();

  int GetX();
  int GetY();
  int GetWidth();
  int GetHeight();
private:
  bool alive;
  int x;
  int y;
  int width;
  int height;
  std::list<Cell*> neighbours;  
};