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
//		cout << "회원번호를 입력하세요 : ";
//		cin >> inputInt[0];
//		cout << "이름을 입력하세요 : ";
//		cin >> inputString[0];
//		cout << "전화번호를 입력하세요 : ";
//		cin >> inputString[1];
//		cout << "충전할 금액을 선택하세요 : ";
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
//	cout << "매출입니다." << Mana->getSalesrecord() << endl;
//	Mana->setSalesrecord(100000);
//	for (int j = 0; j <= chkMem; j++)
//	{
//		cout << "회원 ID : " << cus[j]->getid() << endl;
//		cout << "이름 : " << cus[j]->getName() << endl;
//		cout << "전화번호 : " << cus[j]->getPhoneNum() << endl;
//		cout << "남은요금 : " << cus[j]->getleftMoney() << endl;
//		Mana->customerShowCalc(*cus[j]);
//	}
//
//	for (int j = 0; j <= chkMem; j++)
//	{
//		Mana->subCalculation(*cus[j],10000);
//		cout << "잔액입니다." << cus[j]->getleftMoney() << endl;
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