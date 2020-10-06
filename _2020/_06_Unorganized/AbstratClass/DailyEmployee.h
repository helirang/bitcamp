#pragma once
#include "Employee.h"
class DailyEmployee :
    public Employee
{
private:
	int perTimePay;
	int wrokHour;
public:
	virtual void inputEmployee();
	virtual void showEmployee();
	virtual int calcPay();
};

