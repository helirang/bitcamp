#include <iostream>
#include "Customer.h"
#include "ProgramManager.h"
#include "salesManagement.h"
#include <vector>
#include <iterator>
#include <Windows.h>
#include "SeatManager.h"
#include "MemberManagement.h"
#include "DrawLine.h"
#include "turboc.h"
#include <time.h>
#pragma warning(disable:4996)
using namespace std;

void main()
{
	MemberManagement MMG;
	salesManagement SMG;
	SeatManager STMG;
	DrawLine DL;
	int cho = 0;
	int sel = 0;
	int choSub = 0;
	int num = 0;
	time_t curTime = time(NULL);
	struct tm* pLocal = NULL;
	Customer numnum;

	DL.title();
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	system("cls");
	//STMG.drawMap();
	while (true)
	{
		STMG.drawMap();
		pLocal = localtime(&curTime);
		gotoxy(10, 0);
		printf("%04d��%02d��%02d�� %02d:%02d",
			pLocal->tm_year + 1900, pLocal->tm_mon + 1, pLocal->tm_mday,
			pLocal->tm_hour, pLocal->tm_min);
		gotoxy(0, 22);
		cout << " >>> BIT �ǽù濡 ���� ���� ȯ���մϴ� <<< " << endl;
		cout << "�� �޴� ��" << endl;
		cout << "1.ȸ������ " << "2.��ݰ�� " << "3.�¼� ���� " << "4.���� Ȯ�� " << "5.���α׷� ���� " << endl;
		cout << "�Է� : ";
		cin >> cho;
		STMG.bigClear(0, 24);
		switch (cho)
		{
		case 1:
		
			MMG.showMenu();
			sel = MMG.getSelNum();
			STMG.bigClear(0, 24);
			if (sel == 1)
			{
				MMG.insetMember();
				
			}
			else if (sel == 2) {
				MMG.showAllMember();
				Sleep(2000);
			}
			else if (sel == 3) {
				MMG.ModifyMember();
			
			}
			else if (sel == 4) {
				MMG.deleteMember();
			}
			else if (sel == 5) {
				MMG.searchMember();
				Sleep(2000);
			}
			break;

		case 2:
		
			SMG.showMenu();
			cin >> choSub;
			STMG.bigClear(0, 24);
			if (choSub == 1)
			{
				num = MMG.searchMemberUsing();
				if (num == 10000)
				{
					STMG.bigClear(0, 24);
					MMG.chekMember();
					Sleep(2000);
					break;
				}
				if (MMG.Member[num]->getseatNum() == 0)
				{
					cout << "PC�� ����� ���� �ƴմϴ�." << endl;
					Sleep(2000);
					break;
				}
				pLocal = localtime(&curTime);
				SMG.customerCalc(MMG.Member[num], pLocal->tm_hour, pLocal->tm_min, *pLocal);
				STMG.SeatClear(MMG.Member[num]->getseatNum());
				MMG.Member[num]->setseatNum(0);
			}
			else if (choSub == 2)
			{
				num = MMG.searchMemberUsing();

				if (num == 10000)
				{
					STMG.bigClear(0, 24);
					MMG.chekMember();
					Sleep(2000);
					break;
				}
				int FullmemberMoney;
				cout << "������ ��� : ";
				cin >> FullmemberMoney;
				SMG.addCalculation(*MMG.Member[num], FullmemberMoney);
				STMG.SeatModify(*MMG.Member[num], MMG.Member[num]->getseatNum());

				break;

		case 3:
			int seat;

			num = MMG.searchMemberUsing();

			if (num == 10000)
			{
				STMG.bigClear(0, 24);
				MMG.chekMember();
				Sleep(2000);
				break;
			}
			cout << "����ڸ��� �����Ͻðڽ��ϱ�?";
			cin >> seat;

			STMG.bigClear(0, 24);

			MMG.Member[num]->setseatNum(seat);
			MMG.Member[num]->setInTimeHour(pLocal->tm_hour);
			MMG.Member[num]->setInTimeMin(pLocal->tm_min);
			/*SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);*/
			// Custormer a
			STMG.drawSeat(*MMG.Member[num], seat);
			/*SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);*/
			break;

		case 4:

			cout << " [4] ����Ȯ�� ";
			SMG.showRecord();
			break;

		case 5:
			gotoxy(0, 26);
			cout << "���α׷��� �����մϴ�." << endl;
			Sleep(3000);
			exit(0);
			break;
		case 6:
			gotoxy(0, 26);
			num = MMG.searchMemberUsing();
			cout << MMG.Member[num] << endl;
			numnum = *MMG.Member[num];
			cout << numnum.getid() << numnum.getName();
			Sleep(10000);
		default:
			gotoxy(0, 26);
			cout << "�߸��� �Է��Դϴ�." << endl;

			Sleep(3000);
			break;
			}
		}
		STMG.bigClear(0, 24);
		gotoxy(0, 24);
	}

}