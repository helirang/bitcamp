#pragma once
#include "Employee.h"
class RegularEmployee :
    public Employee
{private:
	int annualPay;
	int bonus;
public:
	virtual void inputEmployee();
	virtual void showEmployee();
	virtual int calcPay();
};

