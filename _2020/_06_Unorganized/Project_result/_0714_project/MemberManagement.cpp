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
	cout << "1.ȸ������ �߰�" << endl;
	cout << "2.ȸ������ ��ü ���" << endl;
	cout << "3.ȸ������ ����" << endl;
	cout << "4.ȸ������ ����" << endl;
	cout << "5.ȸ������ �˻�" << endl;
}
int MemberManagement::getSelNum() {
	int num = 0;
	cout << "�޴��� �����ϼ��� : ";
	cin >> num;
	return num;
}

void MemberManagement::insetMember() {

	cout << "ȸ�� �߰�";

	if (this->memNum == MEM_NUM)
	{
		return;
	}
	string name;
	string phoneNumber;
	cout << "�̸��� �Է��ϼ���: ";
	cin >> name;
	cout << endl;
	cout << "��ȭ��ȣ�� �Է��ϼ���: ";
	cin >> phoneNumber;
	cout << endl;
	this->Member[memNum] = new Customer();
	this->Member[memNum]->setName(name);
	this->Member[memNum]->setPhoneNum(phoneNumber);
	this->Member[memNum]->setid(memNum+1);

	this->memNum++;
	

}
void MemberManagement::showAllMember() {
	cout << "ID\t" << "�̸�\t" << "��ȭ��ȣ\t"<< endl;
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
	cout << "�̸��� �Է��ϼ���: ";
	cin >> name;
	int count = 0;
	while (1) {
		for (int i = 0; i < memNum; i++)
		{
			if (this->Member[i]->getName() == name)
			{
				cout << "�̸�:" << this->Member[i]->getName() << endl;
				cout << "��ȣ:" << this->Member[i]->getPhoneNum() << endl;
				cout << this->Member[i]->getleftMoney() << "��" << endl;
				count++;
			}
		}
		if (count == 0)
			cout << "�˻��Ͻ� ȸ���� �����ϴ�" << endl;
		break;
	}

}
void MemberManagement::chekMember()
{
		cout << "��ϵ��� ���� ���Դϴ�." << endl;

}

int MemberManagement::searchMemberUsing()
{
	char name[10];
	cout << "�̸��� �Է��ϼ���: ";
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
	
	cout << "�̸��� �Է��ϼ���: ";
	cin >> name;
	for (int i = 0; i < memNum; i++)
	{
		if (this->Member[i]->getName() == name)
		{
			string Nname;
			string NphonNum;
			cout << "������ �̸��� �Է��ϼ���: ";
			cin >> Nname;
			cout << "������ ��ȣ�� �Է��ϼ���: ";
			cin >> NphonNum;
			this->Member[i]->setName(Nname);
			this->Member[i]->setPhoneNum(NphonNum);
		}
	}

	

}
void MemberManagement::deleteMember() 
{
	char name[10];
	cout << "�̸��� �Է��ϼ���: ";
	cin >> name;
	for (int i = 0; i < memNum; i++)
	{
		if (this->Member[i]->getName() == name)
		{
				Member[i] = 0;
		}
	}

}





