#pragma once
#include "Calc.h"
class Add :
    public Calc
{
public:
	void setValue(int x, int y);
	virtual int calculate();
};

