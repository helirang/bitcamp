#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#pragma warning(disable:4996)
#pragma pack(1)

char* toString() // 주소는 반횐되지만, 지역변수는 함수 종료 시 사라지므로. 해당 주소로 가봤자 남은 데이터가 없다.
{
	// 동적할당 - 힙에 생성되어서 함수와는 관계 없이 유지 가능
	//지역변수는 함수 종료 시 사라진다.
	char *name = (char*)malloc(80); //선언의 초기화에서만 대입 연상 가능.
	// 동적 할당 시, main함수에 영향 가능
	// 문자열을 저장(대입)
	// name = "jangs ma"; // 배열명은 상수, 대입연산 불가
	strncpy(name, "jangs ma", 80 ); // 문자열을 배열에 저장할 때는 함수 이용

	//free(name); 하면 데이터 날아감

	return name; //배열명은 주소, 따라서 반환형식은 포인트
	// NULL 확인하기
}

int getString(char* param, int size)
{
	int i;
	for (i = 0; i < size -1 ; ++i) // sizeof(param)/sizeof(char) = 4 , 포인터는 크기가 4바이트이다.
	{
		param[i] = '0' + i;
	}
	param[i] = 0; // 마지막에 반드시 0이라는 값(nul, 끝)을 넣기
	return 0;
	// keep 동적
	// stack around는 배열 먼저 보기
}

int main(int argc, char** argv)
{
	char* p = toString(); 
	// 길이 값이 없음. 문자 배열은 nul문자로 끝낼 수 있기 때문에 반환해도 작동함.
	// 그러나 int나 double 같은 정수, 실수 배열은 리턴 처리를 할 수 없다.
	if (p == NULL)
	{
		printf("문자열이 없다 \n");
	}
	else
	{
		printf("%s \n", p);
		free(p);
	}

	char name[80];
	getString(name, 80); // 배열을 전달해라. 배열명, 길이
	// 문자열을 제외한 것들은 반환처리 x. 오버플로우 발생
	// 전달 처리를 해야 한다. _s = 길이 값을 주라는 것.

	//문자열은 그 끝이 있어서 반환 처리 가능
	// 그 외에는 배열을 반환하는 처리를 하지 않는다.
	// 굳이 반환을 해야 한다면, 구조체에 배열의 길이를 넣고 반환처리를 할 수 있다.

	printf("%s \n", name);

	return 0;
}

/*
중요 - 문자열 / nul문자라는 끝이 있다.
문자열도 배열 - 따라서 문자열을 하나 저장하려면 배열 3개가 필요하다.

반환법은 지양한다.
전달하는 방식을 지향해야한다.
*/