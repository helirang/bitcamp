#include "DailyEmployee.h"

void DailyEmployee::inputEmployee()
{
	Employee::inputEmployee();
	cout << "시급 입력: ";
	cin >> this->perTimePay;
	cout << "일한 시간 입력:";
	cin >> this->wrokHour;
 }
void DailyEmployee::showEmployee()
{
	Employee::showEmployee();
	cout << "시급 : " << this->perTimePay << endl;
	cout << "일한 시간 : " << this->wrokHour << endl;
	cout << "월급 : " << this->calcPay() << endl;
 }
int DailyEmployee::calcPay() {
	return this->perTimePay * this->wrokHour;
 }