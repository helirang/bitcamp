#pragma once
#include "ProgramManager.h"
#include "Customer.h"

#define MEM_NUM	20
class MemberManagement : public ProgramManager
{

private:
	//Customer* Member[MEM_NUM];
	int memNum = 0;
		
		
	public:
		Customer* Member[MEM_NUM];
		void showMenu();
		int getSelNum();
		void insetMember();
		void showAllMember();
		void searchMember();
		void ModifyMember();
		void deleteMember();
		int searchMemberUsing();
		void chekMember();
		~MemberManagement();
		//void newgetTime(int timedo);
	};



