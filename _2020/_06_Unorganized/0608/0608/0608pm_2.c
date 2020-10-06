#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#pragma pack(1) // ����� ��Ȯ�� ������ �� ���ִ� ��

typedef struct _fileheader
{
	char data[14];

}BFH;

typedef struct _infoheader
{
	char data[40];

}BIH;

typedef struct _rgb
{
	char data[3];

}RGB;

typedef struct _bmpImage
{
	BFH fh;
	BIH ih;
	RGB* table;
}BMP;

int string_dynamic()
{
	char** ap = NULL; //�����͹迭 (����) 2�� ������
	int count;
	printf(" ���ڿ� �Է°��� : ");
	scanf_s("%d", &count);
	ap = (char**)malloc(count * sizeof(*ap)); // ap�� ����Ű�� �����Ϳ� �迭�� ���� ��
	// *ap �����Ͱ� ����Ű�� ����� ũ��
	for (int i = 0;i < count - 1; ++i) 
	{
		printf(" string >");
		ap[i] = (char*)malloc(80);  // ap�� ����Ű�� �����Ϳ� �迭�� ���� �Է�
		fgets(ap[i], 80, stdin);
	}
	for (int i = 0; i < count; ++i)
	{
		fputs(ap[i], stdout);
	}
	// ������ �迭�� �ٷ�� ���, ��Һ��� ó���� �� �������� �迭�� ���־� �ȴ�.
	// �� ������ �迭�� ��Ҹ� ����Ű�� �����͸�, ��ҷ� ���� ������ �迭�̴�.
	for (int i = 0; i < count; ++i)
	{
		free(ap[i]);
	}
	free(ap); // ���ڿ��� ���� ��, �����͸� �� ���� ����� ��� ���� �迭�� �����ͺ��� ���� �뷮�� ����.
	// �ֳĸ� ������ ���� ������ �����͸� ��ƸԱ� ������, �� �迭�� �����͸� �� ä���� ������� �ʴ´ٸ� �����Ͱ� ���� ȿ����
}

int string_points()
{
	//������ �迭 : ������ �������� ���� ������ �ִ�.
	char* pl[5]; // �����͸� 5�� ������ �ִ� �迭 / pl�� �迭��
	// �������� �ּҸ� �����ϴ� ������ ���� **
	for (int i = 0; i < 5; ++i)
	{
		printf("string >"); // �����Ϳ� �迭 ����, ���� ������ �ٸ�
		pl[i] = (char*)malloc(80); //�����迭 �Ҵ�
		fgets(pl[i], 80, stdin); // ũ�� sizeof(pi[i]) = ������ �� 4�� ����.
	}
	for (int i = 0; i < 5; ++i)
	{
		fputs(pl[i], stdout);
	}
	for (int i = 0; i < 5; ++i)
	{
		free(pl[i]); // �Ҵ� ������ŭ ����
	}
		return 0;
}

/*
char [5][80] ���� �迭 - �ѹ��� 5�� �迭 ����. ��� �迭�� ���̰� �Ȱ���
char* [5] ���� �迭 - �Է� ���� ������ �迭�� ����, �Էµ� ��ŭ�� �迭 �Ҵ�.
���� �޸� �Һ� ���̴µ� ���� �迭�� �پ��.
*/

int string_loop()
{
	//���ڿ� 5���� �����ϴ� �迭
//	char list[���ڿ� ����][ �� ���ڿ� ����];
	char list[5][80];
	for (int i = 0; i < 5; ++i)
	{
		printf("string > ");
		fgets(list[i], sizeof(list[i]), stdin);
	}
	for (int i = 0; i < 5; ++i)
	{
		fputs(list[i], stdout);
	}

	return 0;
}



int string_array()
{
	//���ڿ� 3���� �Է¹޾� ����ϼ���
	char s1[80];
	char s2[80];
	char s3[80];
	
	printf("string > ");
	fgets(s1, sizeof(s1), stdin);
	printf("string > ");
	fgets(s2, sizeof(s2), stdin);
	printf("string > ");
	fgets(s3, sizeof(s3), stdin);

	fputs(s1, stdout); // file (, FILE stream);
	fputs(s2, stdout);
	fputs(s3, stdout);
	
	return 0;
}

int main(int argc, char** argv)
{
	BMP bmp = { 0 };
	printf("%d \n", sizeof(BMP));
	printf("%d \n", sizeof(bmp));
	//bmp�� ��� table�� RGB�� ��ҷ��ϴ� ���� 512�� �迭�� �����϶�
//	RGB pixel[512];
//	bmp.table = pixel; // pixel + - == &pixel[0]

	//�����Ҵ�
	int countsofpixel = 1024 * 768; // ���� * ����
	bmp.table = (RGB*)malloc(countsofpixel * sizeof(RGB)); // ũ�� * ����
	// main �Լ� ������ ���� ����

	// meta�� - ����ǥ�� BMP ���Ͽ� 14, 40 �� 54����Ʈ�� ���Ͽ� ���� ������ ���ԵǾ� �ִ�. ���� ����
	free(bmp.table);

//	string_loop();
//	string_points();
	string_dynamic();

	return 0;
}
