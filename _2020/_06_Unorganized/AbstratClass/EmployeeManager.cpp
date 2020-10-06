#include "EmployeeManager.h"
#include "TempEmployee.h"
#include "DailyEmployee.h"
#include "RegularEmployee.h"

//#include <iostream>
//using namespace std;

void EmployeeManager::showMenu()
{
	cout << "1. ����Է�" << endl;
	cout << "2. �����ü���" << endl;
	cout << "3. ���α׷� ����" << endl;
}

int  EmployeeManager::getSelNum()
{
	int num = 0;
	cout << "�޴��� ���� >> ";
	cin >> num;
	return num;
}
void  EmployeeManager::insertEmployee()
{
	if (this->empNum == EMP_NUM)
	{
		cout << "�� �̻� �Է� ���մϴ�." << endl;
	}
	cout << "---��� ������ �����ϼ���---" << endl;
	cout << "1. ������" << endl;
	cout << "2. �ӽ���" << endl;
	cout << "3. �Ͽ���" << endl;
	int sel = getSelNum();

	if (sel == 1)
	{
		RegularEmployee* regularEmp = new RegularEmployee();
		regularEmp->inputEmployee();

		this->employee[this->empNum] = regularEmp;
		this->empNum++;
	}
	else if (sel == 2)
	{
		TempEmployee* TempEmp = new TempEmployee();
		TempEmp->inputEmployee();

		this->employee[this->empNum] = TempEmp;
		this->empNum++;
	}
	else if (sel == 3)
	{
		DailyEmployee* DailyEmp = new DailyEmployee();
		DailyEmp->inputEmployee();

		this->employee[this->empNum] = DailyEmp;
		this->empNum++;
	}
	else cout << "�߸��Է�" << endl;
}
void  EmployeeManager::showAllEmployee()
{
	for (int i = 0; i < this->empNum;i++)
	{
		employee[i]->showEmployee();
	}
}