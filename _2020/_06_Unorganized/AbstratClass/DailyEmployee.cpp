#include "DailyEmployee.h"

void DailyEmployee::inputEmployee()
{
	Employee::inputEmployee();
	cout << "�ñ� �Է�: ";
	cin >> this->perTimePay;
	cout << "���� �ð� �Է�:";
	cin >> this->wrokHour;
 }
void DailyEmployee::showEmployee()
{
	Employee::showEmployee();
	cout << "�ñ� : " << this->perTimePay << endl;
	cout << "���� �ð� : " << this->wrokHour << endl;
	cout << "���� : " << this->calcPay() << endl;
 }
int DailyEmployee::calcPay() {
	return this->perTimePay * this->wrokHour;
 }