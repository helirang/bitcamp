#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>

int main(int argc, char** argv)
{
	while (1)
	{
		printf("1. �ּ� �Է�\n");
		printf("2. �ּ� �˻�\n");
		printf("3. �ּ� ����\n");
		printf("4. �ּ� ����\n");
		printf("5. �ּ� ���\n");
		/*char sel = getchar(); ���� + ����*/
		//f1�� ������ ������ �˷���

		char sel = _getch(); // ���ڸ�
		printf("\n %c �� �����ϼ̽��ϴ� \n", sel);
		printf("������ �����ϼ̽��ϴ�\n");
		printf("****************\n\n");

		// Ű����� �ܼ��� �������ִ� ����, getchar() -> ���ۿ� ����.
		// _getch()�� ���۸� ��ġ�� �ʴ´�. 
	}
	// ctrl k + f�� �ڵ� ����
	return 0;
}
