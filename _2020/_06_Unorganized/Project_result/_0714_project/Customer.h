#pragma once
#include <iostream>


using namespace std;

class Customer
{
private:
    string name;
    string phoneNum;
    int leftmoney = 0;
    int id = 0;
    int seatNum = 0;
    int timeHour=0, timeMin=0;

public:
    int getid();
    string getName() ;
    string getPhoneNum();
    int getInTimeHour();
    int getInTimeMin();
    int getleftMoney();
    int getseatNum();

    void setid(int id);
    void setName(string name);
    void setPhoneNum(string phoneNum);
    void setInTimeHour(int time);
    void setInTimeMin(int time);
    void setseatNum(int seatNum);
    void setleftMoney(int leftmoney);
};
