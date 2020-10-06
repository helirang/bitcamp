#pragma once
class Calc
{
protected:
	int a, b;
public:
	virtual void setValue(int x, int y);
	virtual int calculate() = 0;
};

