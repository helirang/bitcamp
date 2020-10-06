#include "Employee.h"
#include "DailyEmployee.h"
#include "RegularEmployee.h"
#include "TempEmployee.h"
#include "EmployeeManager.h"
#include <iostream>
#include <Windows.h>
#include <time.h>
#include <stdlib.h>



void main()
{
	EmployeeManager em;
	
	while (1)
	{
		em.showMenu();
		int sel = em.getSelNum();
		if (sel == 3)break;
		switch (sel)
		{
		case 1:
			em.insertEmployee();
			break;
		case 2:
			em.showAllEmployee();
			break;
		default:
			break;
		}
	}

	
	//delete unit[0];
	//delete unit[1]; 
	//delete unit[2];
}