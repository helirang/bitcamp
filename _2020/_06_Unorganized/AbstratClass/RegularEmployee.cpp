#include "RegularEmployee.h"


void RegularEmployee::inputEmployee()
{
	Employee::inputEmployee();
	cout << "연봉 입력: ";
	cin >> this->annualPay;
	cout << "보너스 입력: ";
	cin >> this->bonus;
}
void  RegularEmployee::showEmployee()
{
	Employee::showEmployee();
	cout << "연봉 : " << this->annualPay << endl;
	cout << "보너스 : " << this->bonus << endl;
	cout << "월급 : " << this->calcPay() << endl;
}
int  RegularEmployee::calcPay() 
{
	return (this->annualPay + this->bonus) / 12;
}