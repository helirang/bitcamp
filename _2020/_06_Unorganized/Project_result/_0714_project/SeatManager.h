#pragma once
#include "ProgramManager.h"
#include "Customer.h"

class SeatManager : public ProgramManager
{
private:
	int x, y;
public:
	void drawMap();
	void drawSeat(Customer& cus, int i);
	void smallClear(int mx, int my);
	void bigClear(int mx, int my);
	void SeatModify(Customer& cus, int i);
	void SeatClear(int i);
};