#include "salesManagement.h"
#include "ProgramManager.h"
#include "Customer.h"
#include <Windows.h>
#include "turboc.h"


int salesManagement::getSalesrecord()
{
	return this->ledger;
}

void salesManagement::setSalesrecord(int money)
{
	this->ledger = money;
}

void salesManagement::addSalesrecord(int money)
{
	this->ledger += money;
}

void salesManagement::subSalesrecord(int money)
{
	this->ledger -= money;
}

void salesManagement::addCalculation(Customer& cus, int money)
{
	int x = cus.getleftMoney() + money;
	cus.setleftMoney(x);
}

void salesManagement::subCalculation(Customer& cus, int money)
{
	int x = cus.getleftMoney() - money;
	cus.setleftMoney(x);
}

void salesManagement::showMenu()
{
	cout << "[1] 요금결제 [2] 정회원 요금 추가" << endl;
}

void salesManagement::customerCalc(Customer* cus, int nowHour, int nowMin, tm out)
{
	Customer cc = *cus;
	int hour = nowHour - cc.getInTimeHour();
	int min = nowMin- cc.getInTimeMin();
	int managerMoney = 0;
	int custMoney;
	int chekMoney = 0;
	int Unpaid = 0;

	hour += 1;
	managerMoney = ((hour * this->timeCal) + ((min % 10 == 0) ? min/10 : min/10+1) * (this->timeCal / 6));
	this->setRecord(cc, managerMoney, out);
	this->addSalesrecord(managerMoney);
	cout << "사용시간 : " << hour << "시간 " << min << "분" << endl;
	cout << "요금 : " << ((hour * this->timeCal) + ((min % 10 == 0) ? min / 10 : min / 10 + 1) * (this->timeCal / 6)) << "원" << endl << endl;
	gotoxy(40, 24);
	if (cc.getid() < 10000)
	{
		managerMoney -= cc.getleftMoney();
		if (managerMoney < 0)
		{
			gotoxy(40, 25);
			cout << "남은 후불 요금 : " << -managerMoney << "원" << endl;
			gotoxy(40, 26);
			cout << "거래 완료 되었습니다. 감사합니다. " << endl;
			cc.setleftMoney(-managerMoney);
			Sleep(2000);
		}
		else if (managerMoney > 0)
		{
			gotoxy(40, 25);
			cout << "후불 요금이 부족합니다. ";
			gotoxy(40, 26);
			cout << "현재 남은 후불 요금 : " << cc.getleftMoney() << "원";
			gotoxy(40, 27);
			cout << "부족한 요금 : " << managerMoney << "원 입니다." << endl;
			cc.setleftMoney(0);
			Sleep(2000);
		}
	}
	if (managerMoney > 0)
	{
		cout << "받은 금액 : ";
		cin >> custMoney;

		chekMoney = managerMoney - custMoney;

		if (chekMoney != 0)
		{
			if (chekMoney > 0)
			{
				while (true)
				{
					gotoxy(40, 28);
					cout << "돈을 더 내라" << chekMoney << "원" << endl;
					gotoxy(40, 29);
					cout << "받은 금액 : ";
					cin >> Unpaid;
					chekMoney -= Unpaid;
					if (chekMoney < 0)
						break;
					else if (chekMoney == 0)
					{
						cout << "거래완료 되었습니다." << endl;
						Sleep(2000);
						break;
					}
					Sleep(2000);
				}
			}
			else
			{
				cout << "거스름 돈" << -chekMoney << "원 입니다." << endl;
				Sleep(2000);
			}
		}
		else
		{
			cout << "거래완료 되었습니다." << endl;
			Sleep(2000);
		}
	}
	for (int i = 0; i < 6; i++)
	{
		gotoxy(40, 24 + i);
		cout << "                                            " << endl;
	}
	for(int j = 0; j < 6; j++)
	{
		gotoxy(0, 24+j);
		cout << "                                                          " << endl;
	}
	*cus = cc;
}

void salesManagement::setRecord(Customer& cus, int money, tm out)
{
	this->sellName.push_back(cus.getName());
	this->sellID.push_back(cus.getid());
	this->sellMoney.push_back(money);
	this->sellTime.push_back(out);
	this->recordNum++;
}

void salesManagement::showRecord()
{
	int end;
	gotoxy(120, 0);
	cout << " >>>> 매출 상세 기록 <<<<         총 매출 : " << this->ledger << "원" << endl;
	gotoxy(120, 1);
	cout << "[거래번호]      [날짜]         [시간]      [ID]       [이름]     [매출]";
	for (int i = 0; i < recordNum; i++)
	{
		gotoxy(120, i + 2);
		printf("  %06d      %d-%02d-%02d       %02d:%02d       %04d       %4s       %d", i+1,this->sellTime[i].tm_year + 1900, this->sellTime[i].tm_mon + 1, this->sellTime[i].tm_mday, this->sellTime[i].tm_hour,
			this->sellTime[i].tm_min, this->sellID[i], this->sellName[i].c_str(), this->sellMoney[i]);
	}
	gotoxy(0, 25);
	cout << " [아무 숫자를 입력하시면 매출 창이 종료됩니다.] ";
	cin >> end;
	gotoxy(0, 25);
	cout << "                                                                          " << endl;
	cout << "                                                                          " << endl;
	for (int i = 0; i < recordNum + 2; i++)
	{
		gotoxy(120, i);
		cout << "                                                                                                   " << endl;
	}
	gotoxy(0, 25);
}