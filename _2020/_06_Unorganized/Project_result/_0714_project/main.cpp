//#include <iostream>
//#include "Customer.h"
//#include "ProgramManager.h"
//#include "salesManagement.h"
//#include <vector>
//#include <iterator>
//#include <Windows.h>
//
//
//using namespace std;
//
//
//int main()
//{
//	//Customer* cus[20] = { new Customer };
//	vector<Customer*> cus;
//	salesManagement* Mana = new salesManagement;
//	int i = 0;
//	int chkMem = -1;
//
//	for (i = 0;i < 3; ++i)
//	{
//		cus.push_back(new Customer);
//		int inputInt[2];
//		string inputString[2];
//		cout << "ȸ����ȣ�� �Է��ϼ��� : ";
//		cin >> inputInt[0];
//		cout << "�̸��� �Է��ϼ��� : ";
//		cin >> inputString[0];
//		cout << "��ȭ��ȣ�� �Է��ϼ��� : ";
//		cin >> inputString[1];
//		cout << "������ �ݾ��� �����ϼ��� : ";
//		cin >> inputInt[1];
//
//		cus[i]->setid(inputInt[0]);
//		cus[i]->setleftMoney(inputInt[1]);
//		cus[i]->setName(inputString[0]);
//		cus[i]->setPhoneNum(inputString[1]);
//
//		cus[i]->setTime(((int)GetTickCount64()));
//		Sleep(2000);
//		chkMem++;
//	}
//
//
//	Mana->setSalesrecord();
//	cout << "�����Դϴ�." << Mana->getSalesrecord() << endl;
//	Mana->setSalesrecord(100000);
//	for (int j = 0; j <= chkMem; j++)
//	{
//		cout << "ȸ�� ID : " << cus[j]->getid() << endl;
//		cout << "�̸� : " << cus[j]->getName() << endl;
//		cout << "��ȭ��ȣ : " << cus[j]->getPhoneNum() << endl;
//		cout << "������� : " << cus[j]->getleftMoney() << endl;
//		Mana->customerShowCalc(*cus[j]);
//	}
//
//	for (int j = 0; j <= chkMem; j++)
//	{
//		Mana->subCalculation(*cus[j],10000);
//		cout << "�ܾ��Դϴ�." << cus[j]->getleftMoney() << endl;
//	}
//	
//	for(; chkMem >= 0; --chkMem)
//	{
//		cout << chkMem << endl;
//		delete cus[chkMem];
//	}
//	
//	delete Mana;
//}