#include "Employee.h"


void Employee::inputEmployee()
{
	cout << "이름을 입력: ";
	cin >> this->name;
	cout << "사번을 입력: ";
	cin >> this->companyNum;
}
void Employee::showEmployee()
{
	cout << "이름 : " << this->name << endl;
	cout << "사번 : " << this->companyNum << endl;
}