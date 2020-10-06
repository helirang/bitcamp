#include "MemberManagement.h"
#include "Customer.h"
#include <iostream>

using namespace std;


MemberManagement::~MemberManagement()
{
	for (int i = 0; i < memNum; i++)
	{
		delete Member[i];
	}
}

void MemberManagement::showMenu() {
	cout << "1.회원정보 추가" << endl;
	cout << "2.회원정보 전체 출력" << endl;
	cout << "3.회원정보 수정" << endl;
	cout << "4.회원정보 삭제" << endl;
	cout << "5.회원정보 검색" << endl;
}
int MemberManagement::getSelNum() {
	int num = 0;
	cout << "메뉴를 선택하세요 : ";
	cin >> num;
	return num;
}

void MemberManagement::insetMember() {

	cout << "회원 추가";

	if (this->memNum == MEM_NUM)
	{
		return;
	}
	string name;
	string phoneNumber;
	cout << "이름을 입력하세요: ";
	cin >> name;
	cout << endl;
	cout << "전화번호를 입력하세요: ";
	cin >> phoneNumber;
	cout << endl;
	this->Member[memNum] = new Customer();
	this->Member[memNum]->setName(name);
	this->Member[memNum]->setPhoneNum(phoneNumber);
	this->Member[memNum]->setid(memNum+1);

	this->memNum++;
	

}
void MemberManagement::showAllMember() {
	cout << "ID\t" << "이름\t" << "전화번호\t"<< endl;
	for (int i = 0; i < memNum; i++)
	{
		cout << this->Member[i]->getid() << "\t" 
			<< this->Member[i]->getName() << "\t" 
			<< this->Member[i]->getPhoneNum()
			<< endl;
	}
}
void MemberManagement::searchMember() {
	char name[10];
	cout << "이름을 입력하세요: ";
	cin >> name;
	int count = 0;
	while (1) {
		for (int i = 0; i < memNum; i++)
		{
			if (this->Member[i]->getName() == name)
			{
				cout << "이름:" << this->Member[i]->getName() << endl;
				cout << "번호:" << this->Member[i]->getPhoneNum() << endl;
				cout << this->Member[i]->getleftMoney() << "원" << endl;
				count++;
			}
		}
		if (count == 0)
			cout << "검색하신 회원이 없습니다" << endl;
		break;
	}

}
void MemberManagement::chekMember()
{
		cout << "등록되지 않은 고객입니다." << endl;

}

int MemberManagement::searchMemberUsing()
{
	char name[10];
	cout << "이름을 입력하세요: ";
	cin >> name;
	for (int i = 0; i < memNum; i++)
	{
		if (this->Member[i]->getName() == name)
		{
			return i;
		}
	}
	return 10000;
}
void MemberManagement::ModifyMember() 
{
	char name[10];
	
	cout << "이름을 입력하세요: ";
	cin >> name;
	for (int i = 0; i < memNum; i++)
	{
		if (this->Member[i]->getName() == name)
		{
			string Nname;
			string NphonNum;
			cout << "수정할 이름을 입력하세요: ";
			cin >> Nname;
			cout << "수정할 번호를 입력하세요: ";
			cin >> NphonNum;
			this->Member[i]->setName(Nname);
			this->Member[i]->setPhoneNum(NphonNum);
		}
	}

	

}
void MemberManagement::deleteMember() 
{
	char name[10];
	cout << "이름을 입력하세요: ";
	cin >> name;
	for (int i = 0; i < memNum; i++)
	{
		if (this->Member[i]->getName() == name)
		{
				Member[i] = 0;
		}
	}

}





