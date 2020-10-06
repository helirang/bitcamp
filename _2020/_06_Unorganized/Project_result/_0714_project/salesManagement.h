#pragma once
#include "ProgramManager.h"
#include "Customer.h"
#include <iostream>
#include <vector>
#include <time.h>

using namespace std;

class salesManagement :
    public ProgramManager
{
private:
    int timeCal = 600;
    int ledger=0;
    int recordNum = 0;
    vector<string> sellName;
    vector<int> sellID;
    vector<int> sellMoney;
    vector<tm> sellTime;

public:
     int getSalesrecord();
     void setSalesrecord(int money = 0);

     void addSalesrecord(int money);
     void subSalesrecord(int money);

     void addCalculation(Customer& cus, int money);
     void subCalculation(Customer& cus, int money);
     void customerCalc(Customer* cus, int nowHour, int nowMin, tm out);

     void setRecord(Customer& cus, int money, tm out);
     void showRecord();

     void showMenu();
 
};

