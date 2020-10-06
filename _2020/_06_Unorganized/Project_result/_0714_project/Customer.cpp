#include "Customer.h"
#include <iostream>
using namespace std;

int Customer::getid()
{
    return id;
}
string Customer::getName()
{
    return name;
}
string Customer::getPhoneNum()
{
    return phoneNum;
}
int Customer::getInTimeHour()
{
    return this->timeHour;
}
int Customer::getInTimeMin()
{
    return this->timeMin;
}
int Customer::getleftMoney()
{
    return leftmoney;
}
int Customer::getseatNum() {
    return seatNum;
}

void Customer::setid(int id)
{
    this->id = id;
}
void Customer::setName(string name)
{
    this->name = name;
}
void Customer::setPhoneNum(string phoneNum)
{
    this->phoneNum = phoneNum;
}
void Customer::setInTimeHour(int time)
{
    this->timeHour = time;
}
void Customer::setInTimeMin(int time)
{
    this->timeMin = time;
}
void Customer::setleftMoney(int money)
{
    this->leftmoney = money;
}
void Customer::setseatNum(int seatNum) {
    this->seatNum = seatNum;
}