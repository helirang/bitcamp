// library headers
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//에자일 업데이트 개념 

// gloabal variables

// section function body

// start program

int string_def() // 문자열 - 문자 배열 - char [] / #배열명 = 주소(&[]0) = 0번 요소의 주소
{
	// 문자열 - 문자 배열 - char []
	// 문자열의 처리는 첫 글자로부터 '\0' 까지 / 문자열은 종료문자 또는 nul문자가 나올 때 반복을 끝낸다. = 가변 길이 / 가변 길이라고 해서 배열의 길이를 초과할 수는 없다.(c)
	// NULL = 널 포인터 / NUL = 문자
	// c의 배열은 고정 길이 / 문자열은 가변 길이 
	char str[80] = { "korea 2020 fi" }; // 초기값 줄 때, 문자열로 줘도 됨.
	//\0 = 널문자 / Nul문자까지만 출력.
	// 문자열 처리의 기준은 0이기 때문에, 배열 선언시 0으로 초기화 하는게 안정성이 높다.
	// 문자열 출력 = %s, char *, 반복문 사용
	printf("%s \n", str ); // 배열명 [0]번에서부터 널문자 전가지 출력
	
	int v = puts(str); // str = str[0]번의 주소, char *으로 사용 가능
	printf("%d \n",v);

	for (int i = 0; str[i] != '\0'; ++i) // 문자열은 이렇게
	{ // 화면에 1글자씩 출력
		putchar(str[i]);
	}
	putchar("\n");;

	// fputs() // fputs = f가 앞이면 file / 뒤에 f면 format 이런 형식이 있어요.

	return 0;
}

int string_input()//문자열의 끝이 무엇인가? = 키보드에서 문자열의 끝은 \n과 \r이다. \0은 memory에서의 end.
{
	char str[80] = { 0 };
	//키보드
	char ch;
	int i = 0;
	while (( ch = getchar()) != '\n' ) // 문자열은 가변길이이기 떄문에 if문 보다 while문을 자주 사용한다.
	{
		if (i == 0) //입력된 첫 글자가
		{
			if ('a' <= ch && ch <='z') // 소문자이면
			{
				ch -= 32; // 대문자로 바꾼다
			}
		}
		str[i] = ch;
		++i;
	}
	// 반드시 널문자로 끝나야한다.
	str[i] = 0; // 0 = \0 널문자
	 
//	gets_s(str, sizeof(str)-2); // 문자열의 종료에 \0이 있으므로, 안정성을 위해 여유공간을 만든다.
	fgets(str, sizeof(str), stdin);
	printf("%s", str);
	//최대 배열공간
	while (1)
	{
		int v = scanf_s("%s", str, sizeof(str)); // &변수명 but 배열명은 요소0번의 주소이기 때문에 &붙이지 않는다. / &변수명 : 단어로 나누어 받는다.
			//scaf =  공백, tap, \n, \r은 입력 받을 수 없다.
			// _s 함수들은 주소와 크기를 전달해야 한다.
		if (v == 0)
		{
			break;
		}
//		fputs(str, stdout /*where / 어디에 출력할 것인가.*/); // stdin = 키보드, stdout = 모니터
//		fputs("\n", stdout);
		puts(str); // puts는 자동 행내림
	}
	return 0;
}


int ptr4string() // 문자열은 포인터 없이 사용하기 어렵다
// 문자열과 포인터 같이 사용하기
{
	char aStr[80] = "korea 2020";
	char* pStr; // = 연산의 왼쪽 오른쪽 자료형 일치시키기

	pStr = aStr; // [0]번 요소의 주소 char* // 배열명 = 포인터*
	// pStr = aStr[0]; 는 자료형 일치 x. 0번요소의 값
	// pStr = &aStr[0]; 는 자료형 일치 O. 0번요소의 주소 // char 형 변수의 주소
	// pstr = &astr[40]; 는 다른건, 배열명 x, 요소 40번.
	// 포인터 변수를 배열명으로 생각.
	// 요소명 = 배열명[번호] 
	pStr[0] = 'A'; // = astr[0]
	pStr[1] = ' B'; // = astr[1]

	// 1차배열의 요소 =  변수인다
	// 다차배열의 요소 = 배열이다 // 다차배열에서 *이 여러개 나오는 이유.

	printf("%s \n", aStr); //문자열 출력

	char(*pp)[80]; //배열포인터 변수, 포인터는 80짜리 배열을 가리킨다.
	pp = &aStr; // 배열의 주소
	printf("%s \n", *pp); // astr // (*pp) = pp[0] // = 0[pp]
	// p+0 = &p[0] / *(p+0) = p[0] = *(0+p) = 0[p]
	pp = 0;
	printf("%d \n", pp + 1); // 주소 + ( 1 * sizeof()); = 0 + ( 1 * 80 ) = 80;
	// 포인터가 가르키는 곳에 다음 번지로 간다는 뜻. 
	// pp + 1 = pp주소가 끝나는 곳에서 1칸 이동. 0~79 다음 1개 = 즉 80번지로 이동.

	// char* p; //포인터변수 - char 형 변수의 주소
	// const = 상수 변수
	// const char* cp; // 문자값을 변경하지 않는다는 선언, 주소는 변경 가능
	// const char * cp = const -> char* / cp는 변경 가능
//	cp = 1004;
//	cp = 2004;
//	cp = 3004;
	// *cp = 'A';

//	char* const ccp; // const ccp, 포인터의 가리키는 곳의 값은 변경 가능 but 포인터의 주소는 변경 불가.
	//ccp = 1004;
//	*ccp = 1400;
	// const char* const ccp; // 완전 상수 주소도 값도 못 바꿈;

	// p = "korea 2020"; // p는 포인터니까, 이것은 문자열의 시작 주소를 저장하는 것이다.
	// *p = 'k'; // p가 가리키는 곳에 값을 저장
	// const 키워드를 붙이는 이유, 빌드에 에러가 떠서 알기 쉽게 하기 위해 const 사용
	// " "로 표현되는 문자열 상수는 변경할 수 없다.
	// p로는 시작 되나, 에러가 발생. const 사용시 오류 표시, 실행 안됨.

	// " "도 연산자로서 반환하는 값이 있다.
	// 즉 " "로 표시하면 컴퓨터는 해당 ""안에 있는 문자를 저장하기 위해 데이터에 배열을 만들고 저장한 후, 해당 배열의 주소를 반환한다. 
	// 컴퓨터가 저장한 공간은 읽기만 가능한 곳이기에 쓰기 불가, 해당 값을 사용하기 위해 반환 값인 주소를 사용하는 포인터를 사용.
	return 0;
}

int op4pointer()
{
	//배열 요소번호와 포인터 연산의 관계
	// 배열 - 데이터를 묶음으로 모아 놓은 것.
	// 포인터 - 주소를 다루는 것.
	char str[80] = { 'k', 'o', 'r', 'e', 'a', '\n' };
	char* p = &str[0]; // str

	printf("%p - %c \n", p, *p); //p는 주소, *p는 해당 주소의 값 / 
	// p = &str / *p = str[0]
	printf("%p - %c \n", p+0, *(p+0)); // 주소 + 정수 == 주소
	printf("%p - %c \n", p + 1, *(p + 1));
	// *p +1 = p포인터가 가르키는 값에 +1을 한 것.  *(p+1)은 p주소에 +1을 하여 변경된 주소값에 값을 표현하는 것.
	printf("%p - %c \n", p + 2, *(p + 2));
	printf("%p - %c \n", p + 3, *(p + 3));
	printf("%p - %c \n", p + 4, *(p + 4));

	printf("%p - %c \n", &str[0], str[0]); //%p는 주소 
	printf("%p - %c \n", &str[1], str[1]);
	printf("%p - %c \n", &str[2], str[2]);
	printf("%p - %c \n", &str[3], str[3]);
	printf("%p - %c \n", &str[4], str[4]);

	//포인터 / *p = &str / p + 1의 계산방법이 배열 포인터와 다름.
	//배열포인터 / char(*pppp)[80]; / pppp = &str;
	// 포인터와 배열포인터 구분.
	// 포인터의 형식마다 이동하는 거리가 다르다. int형은 4칸, char형은 1칸 등등.
	p = 0;
	char(*pppp)[80];
	pppp = &str;
	printf("%d - %d \n", p , p + 1);
	printf("%d - %d \n", pppp, pppp + 1);
	return 0;
}

int main(int argc, char** argv)	
{
	op4pointer(); // 문자열의 끝이 있다.
}

/*
문자열 : '/0' 을 끝으로 하는 문자 배열
문자열 처리를 위한 포인터
동적할당 ; 포인터를 이용하여 실행 중 메모리의 생성과 삭제 관리
배열, 구조체, 구조체 배열
*/