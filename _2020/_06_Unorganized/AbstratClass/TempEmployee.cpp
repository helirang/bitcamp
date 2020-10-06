#include "TempEmployee.h"

void TempEmployee::inputEmployee()
{
	Employee::inputEmployee();
	cout << "계약 연봉 입력 : ";
	cin >> this->pay;
}
void TempEmployee::showEmployee()
{
	Employee::showEmployee();
	cout << "계약 연봉 " << this->pay << endl;
	cout << "월급 : " << this->calcPay() << endl;
 }
int TempEmployee::calcPay()
{
	return (this->pay) / 12;
 }