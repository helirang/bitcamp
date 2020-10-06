#include "SeatManager.h"
#include "Turboc.h"
#include <iostream>
#include "Customer.h"
#include "MemberManagement.h"
#define BX   120
#define BY   18
#define TOP      1
#define BOTTOM   19
#define LEFT   3
#define RIGHT   38
#define NX  36
using namespace std;

void SeatManager::drawMap()
{
    const char* seat[] = { "_" , "|" };
    for (x = 0; x < BX; x++)
    {
        if (x % 40 < 35) {
            gotoxy(x + 3, TOP);
            cout << seat[0];
            gotoxy(x + 3, TOP + 8);
            cout << seat[0];
            gotoxy(x + 3, BOTTOM - 8);
            cout << seat[0];
            gotoxy(x + 3, BOTTOM);
            cout << seat[0];
        }
    }
    for (y = 0; y < BY; y++)
    {
        if (y < 8 || y> 9) {
            gotoxy(LEFT, y + 2);
            cout << seat[1];
            gotoxy(RIGHT, y + 2);
            cout << seat[1];
            gotoxy(LEFT + 40, y + 2);
            cout << seat[1];
            gotoxy(RIGHT + 40, y + 2);
            cout << seat[1];
            gotoxy(LEFT + 80, y + 2);
            cout << seat[1];
            gotoxy(RIGHT + 80, y + 2);
            cout << seat[1];
        }
    }
    int count = 1;
    for (x = 0;x < BX;x++)
    {
        if (x % 40 == 0)
        {
            gotoxy(x + NX, 9);

            cout << count;
            count++;
        }

    }
    for (x = 0;x < BX;x++)
    {
        if (x % 40 == 0)
        {
            gotoxy(x + NX, 19);
            cout << count;
            count++;
        }
    }
    gotoxy(0, 22);
}
void SeatManager::drawSeat(Customer& cus, int i)
{


    int _x = TOP;
    int _y = BOTTOM;

    if (i >= 1 && i <= 3) {
        switch (i)
        {
        case 1:
            _x = 1;
            break;
        case 2:
            _x = 41;
            break;
        case 3:
            _x = 81;
            break;
        }
        gotoxy(_x + 5, LEFT);
        cout << "회원 번호(ID) : " << cus.getid();
        gotoxy(_x + 5, LEFT + 1);
        cout << "회원 이름 : " << cus.getName();
        gotoxy(_x + 5, LEFT + 2);
        cout << "휴대폰 번호 : " << cus.getPhoneNum();
        /*gotoxy(_x + 5, LEFT + 3);
        cout << "VIP 체크 : " << cus.getVipCheky();*/
        gotoxy(_x + 5, LEFT + 3);
        cout << "남은 요금 : " << cus.getleftMoney();
        gotoxy(_x + 5, LEFT + 5);
        cout << "시작 시간 : " << cus.getInTimeHour() << "시 " << cus.getInTimeMin() << "분";
    }

    if (i >= 4 && i <= 6) {
        switch (i) {

        case 4:
            _y = BOTTOM;
            break;
        case 5:
            _y = BOTTOM + 40;
            break;
        case 6:
            _y = BOTTOM + 80;
            break;
        }

        gotoxy(_y - 13, LEFT + 10);
        cout << "회원 번호(ID) : " << cus.getid();
        gotoxy(_y - 13, LEFT + 11);
        cout << "회원 이름 : " << cus.getName();
        gotoxy(_y - 13, LEFT + 12);
        cout << "휴대폰 번호 : " << cus.getPhoneNum();
        /* gotoxy(_y - 13, LEFT + 13);
         cout << "VIP 체크 : " << cus.getVipCheky();*/
        gotoxy(_y - 13, LEFT + 13);
        cout << "남은 요금 : " << cus.getleftMoney();
        gotoxy(_y - 13, LEFT + 15);
         cout << "시작 시간 : " << cus.getInTimeHour() << "시 " << cus.getInTimeMin() << "분";

    }
    gotoxy(20, 25);

}
void SeatManager::smallClear(int mx, int my)
{
    gotoxy(mx, my);
    cout << "                                                              " << endl;
    gotoxy(mx, my);
}
void SeatManager::bigClear(int mx, int my)
{
    for (int j = 0; j < 7; j++)
    {
        gotoxy(mx, my+j);
        cout << "                                                                               " << endl;
    }
  /*  gotoxy(mx, my);
    cout << "                                                              " << endl;
    cout << "                                                              " << endl;
    cout << "                                                              " << endl;
    cout << "                                                              " << endl;
    cout << "                                                              " << endl;
    cout << "                                                              " << endl;
    gotoxy(mx, my);*/
    gotoxy(mx, my);
}
void SeatManager::SeatModify(Customer& cus, int i)
{
    int _x = TOP;
    int _y = BOTTOM;

    if (i >= 1 && i <= 3) {
        switch (i)
        {
        case 1:
            _x = 1;
            break;
        case 2:
            _x = 41;
            break;
        case 3:
            _x = 81;
            break;
        }
        gotoxy(_x + 5, LEFT + 3);
        cout << "남은 요금 : " << cus.getleftMoney();
    }

    if (i >= 4 && i <= 6) {
        switch (i) {

        case 4:
            _y = BOTTOM;
            break;
        case 5:
            _y = BOTTOM + 40;
            break;
        case 6:
            _y = BOTTOM + 80;
            break;
        }
        gotoxy(_y - 13, LEFT + 13);
        cout << "남은 요금 : " << cus.getleftMoney();
    }
    gotoxy(20, 25);
}
void SeatManager::SeatClear(int i)
{
    int _x = TOP;
    int _y = BOTTOM;

    if (i >= 1 && i <= 3) {
        switch (i)
        {
        case 1:
            _x = 1;
            break;
        case 2:
            _x = 41;
            break;
        case 3:
            _x = 81;
            break;
        }
        for (int numm = 0; numm < 5; numm++)
        {
            if (numm == 4)
            {
                gotoxy(_x+5, LEFT + numm+1);
                cout << "                                        ";
            }
            else
            {
                gotoxy(_x+5, LEFT + numm);
                cout << "                                        ";
            }
        }
    }

    if (i >= 4 && i <= 6) {
        switch (i) {

        case 4:
            _y = BOTTOM;
            break;
        case 5:
            _y = BOTTOM + 40;
            break;
        case 6:
            _y = BOTTOM + 80;
            break;
        }

        for (int numm = 0; numm < 5; numm++)
        {
            if (numm == 4)
            {
                gotoxy(_y - 13, LEFT + 10+ 1 + numm);
                cout << "                                        ";
            }
            else
            {
                gotoxy(_y - 13, LEFT + 10 + numm);
                cout << "                                        ";
            }
        }
    }
    gotoxy(20, 25);


}