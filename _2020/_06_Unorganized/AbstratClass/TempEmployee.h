#pragma once
#include "Employee.h"
class TempEmployee :
    public Employee
{private:
	int pay;
public:
	virtual void inputEmployee();
	virtual void showEmployee();
	virtual int calcPay();
};

