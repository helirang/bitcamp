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
	cout << "[1] ��ݰ��� [2] ��ȸ�� ��� �߰�" << endl;
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
	cout << "���ð� : " << hour << "�ð� " << min << "��" << endl;
	cout << "��� : " << ((hour * this->timeCal) + ((min % 10 == 0) ? min / 10 : min / 10 + 1) * (this->timeCal / 6)) << "��" << endl << endl;
	gotoxy(40, 24);
	if (cc.getid() < 10000)
	{
		managerMoney -= cc.getleftMoney();
		if (managerMoney < 0)
		{
			gotoxy(40, 25);
			cout << "���� �ĺ� ��� : " << -managerMoney << "��" << endl;
			gotoxy(40, 26);
			cout << "�ŷ� �Ϸ� �Ǿ����ϴ�. �����մϴ�. " << endl;
			cc.setleftMoney(-managerMoney);
			Sleep(2000);
		}
		else if (managerMoney > 0)
		{
			gotoxy(40, 25);
			cout << "�ĺ� ����� �����մϴ�. ";
			gotoxy(40, 26);
			cout << "���� ���� �ĺ� ��� : " << cc.getleftMoney() << "��";
			gotoxy(40, 27);
			cout << "������ ��� : " << managerMoney << "�� �Դϴ�." << endl;
			cc.setleftMoney(0);
			Sleep(2000);
		}
	}
	if (managerMoney > 0)
	{
		cout << "���� �ݾ� : ";
		cin >> custMoney;

		chekMoney = managerMoney - custMoney;

		if (chekMoney != 0)
		{
			if (chekMoney > 0)
			{
				while (true)
				{
					gotoxy(40, 28);
					cout << "���� �� ����" << chekMoney << "��" << endl;
					gotoxy(40, 29);
					cout << "���� �ݾ� : ";
					cin >> Unpaid;
					chekMoney -= Unpaid;
					if (chekMoney < 0)
						break;
					else if (chekMoney == 0)
					{
						cout << "�ŷ��Ϸ� �Ǿ����ϴ�." << endl;
						Sleep(2000);
						break;
					}
					Sleep(2000);
				}
			}
			else
			{
				cout << "�Ž��� ��" << -chekMoney << "�� �Դϴ�." << endl;
				Sleep(2000);
			}
		}
		else
		{
			cout << "�ŷ��Ϸ� �Ǿ����ϴ�." << endl;
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
	cout << " >>>> ���� �� ��� <<<<         �� ���� : " << this->ledger << "��" << endl;
	gotoxy(120, 1);
	cout << "[�ŷ���ȣ]      [��¥]         [�ð�]      [ID]       [�̸�]     [����]";
	for (int i = 0; i < recordNum; i++)
	{
		gotoxy(120, i + 2);
		printf("  %06d      %d-%02d-%02d       %02d:%02d       %04d       %4s       %d", i+1,this->sellTime[i].tm_year + 1900, this->sellTime[i].tm_mon + 1, this->sellTime[i].tm_mday, this->sellTime[i].tm_hour,
			this->sellTime[i].tm_min, this->sellID[i], this->sellName[i].c_str(), this->sellMoney[i]);
	}
	gotoxy(0, 25);
	cout << " [�ƹ� ���ڸ� �Է��Ͻø� ���� â�� ����˴ϴ�.] ";
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