#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#pragma pack(1) // 사이즈를 정확히 봐야할 때 써주는 것

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
	char** ap = NULL; //포인터배열 (동적) 2중 포인터
	int count;
	printf(" 문자열 입력개수 : ");
	scanf_s("%d", &count);
	ap = (char**)malloc(count * sizeof(*ap)); // ap가 가리키는 포인터에 배열을 만든 것
	// *ap 포인터가 가리키는 대상의 크기
	for (int i = 0;i < count - 1; ++i) 
	{
		printf(" string >");
		ap[i] = (char*)malloc(80);  // ap가 가리키는 포인터에 배열에 값을 입력
		fgets(ap[i], 80, stdin);
	}
	for (int i = 0; i < count; ++i)
	{
		fputs(ap[i], stdout);
	}
	// 포인터 배열을 다루는 경우, 요소부터 처리한 후 마지막에 배열을 없애야 된다.
	// 즉 포인터 배열은 요소를 가리키는 포인터를, 요소로 가진 포인터 배열이다.
	for (int i = 0; i < count; ++i)
	{
		free(ap[i]);
	}
	free(ap); // 문자열이 같을 때, 데이터를 꽉 차서 사용할 경우 정적 배열이 포인터보다 적은 용량을 쓴다.
	// 왜냐면 포인터 또한 변수라 데이터를 잡아먹기 때문에, 단 배열에 데이터를 꽉 채워서 사용하지 않는다면 포인터가 더욱 효율적
}

int string_points()
{
	//포인터 배열 : 포인터 변수들을 여럿 가지고 있다.
	char* pl[5]; // 포인터를 5개 가지고 있는 배열 / pl은 배열명
	// 포인터의 주소를 저장하는 포인터 변수 **
	for (int i = 0; i < 5; ++i)
	{
		printf("string >"); // 포인터와 배열 구분, 길이 정보도 다름
		pl[i] = (char*)malloc(80); //동적배열 할당
		fgets(pl[i], 80, stdin); // 크기 sizeof(pi[i]) = 포인터 값 4가 나옴.
	}
	for (int i = 0; i < 5; ++i)
	{
		fputs(pl[i], stdout);
	}
	for (int i = 0; i < 5; ++i)
	{
		free(pl[i]); // 할당 받은만큼 해제
	}
		return 0;
}

/*
char [5][80] 정적 배열 - 한번에 5개 배열 생성. 모든 배열에 길이가 똑같음
char* [5] 동적 배열 - 입력 받을 때마다 배열을 생성, 입력된 만큼만 배열 할당.
따라서 메모리 소비를 줄이는데 동적 배열이 뛰어나다.
*/

int string_loop()
{
	//문자열 5개를 저장하는 배열
//	char list[문자열 개수][ 각 문자열 길이];
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
	//문자열 3개를 입력받아 출력하세요
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
	//bmp의 멤버 table에 RGB를 요소로하는 길이 512인 배열을 생성하라
//	RGB pixel[512];
//	bmp.table = pixel; // pixel + - == &pixel[0]

	//동적할당
	int countsofpixel = 1024 * 768; // 가로 * 세로
	bmp.table = (RGB*)malloc(countsofpixel * sizeof(RGB)); // 크기 * 길이
	// main 함수 끝나기 전에 해제

	// meta값 - 국제표준 BMP 파일에 14, 40 총 54바이트에 파일에 대한 정보가 기입되어 있다. 파일 포맷
	free(bmp.table);

//	string_loop();
//	string_points();
	string_dynamic();

	return 0;
}
