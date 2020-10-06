#pragma once
#include "Customer.h"
#include "turboc.h"
class DrawLine : public Customer
{	
protected:
#define WIDTH	80
#define HEIGHT	25
public:
	void drawXLine(int sX, int eX, int yPos, const char* icon);
	void drawYLine(int sY, int eY, int xPos, const char* icon);
	void title();
};

