#pragma once
#include <iostream>
using namespace std;
class Employee
{
private:
	string name;
	string companyNum;
public:
	virtual void inputEmployee();
	virtual void showEmployee();
	virtual int calcPay()=0;
};

