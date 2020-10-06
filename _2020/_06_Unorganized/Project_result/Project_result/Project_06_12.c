#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>
#include <Windows.h>
#include <time.h>
#pragma warning (disable:4996)

#define WallH	22 // 행
#define WallC	22 // 열
#define EnemyCountt	1// 적 개수 지정(난이도지정)

int mapWall[WallH][WallC] = { 0 }; 	// 2차 배열 맵
const int MapWallH = 1; // 테두리 만들기 1
const int MapWallH2 = 21; // 테두리 만들기 2 


int ShowMap(void)
{
	system("cls");
	int iy = 19, ix = 10; // 유저 시작 좌표
	mapWall[iy][ix] = 9; // 유저

	for (int r = 1; r < WallH; ++r) // 행 : H
	{
		for (int c = 1; c < WallC; ++c) // 열 : W
		{
			mapWall[MapWallH][c] = -1; // 테투리 좌표에 -1 넣기
			mapWall[MapWallH2][c] = -1; ////
		}
		mapWall[r][MapWallH] = -1; // 테두리 좌표에 -1 넣기
		mapWall[r][MapWallH2] = -1; ////
	}

	for (int r = 1; r < WallH; ++r) // 행 : H
	{
		for (int c = 1; c < WallC; ++c) // 열 : W
		{
			printf("%s", (mapWall[r][c] == -1) ? "■" : (mapWall[r][c] == 9) ? "◈" : "□"); // 시작 맵 출력
		}
		putchar('\n');
	}
	return 0;
}

int Move(void)
{
	int game_over_chek = 0; // GAME OVER 체크
	int* gmae_over_chekP; // GAME OVER CHEK 포인터 
	gmae_over_chekP = &game_over_chek;
	char* Game_over = "\n\n GAME OVER \n\n";  // GAME OVER 시 출력할 문자  지정

	int iy = 19, ix = 10; // 유저 시작 위치

	int stratEnemyLine = 2; // 적을 만들 행 위치 지정

	int enemy_make_chek = EnemyCountt; // 만들어진 적의 수를 저장하는 공간
	int enemy_same_chek[EnemyCountt] = { 0 }; // 만들어진 적의 데이터를 저장하는 1차 배열
	srand(time(NULL)); // rand 기본 값을 변경하는 srand
	time_t ti = time(NULL); // 시간 생성

	if (ti % 10 == 0) // 예외가 되는 ti % 10 = 0일때를 처리 / Time Exception
	{
		ti += 1;
	}

	double GameTime;
	GameTime = GetTickCount(); // 플레이 시간 체크용 함수
	// GetTickCount = 시스템 시작 ~ 함수를 호출한 시점까지를 1000분의 1초 단위로 표시
	//GameTime에 게임 시작 당시의, GetTickCount 값을 저장

	ShowMap(); // 시작 맵 출력


	while (1)
	{
		system("cls"); // 화면 갱신

		time_t ti_chek_0 = ti % 10; // 초 단위 체크
		time_t ti_chek_1 = 0; // 적의 직전 생산 시간을 담는 공간 / while의 반복으로 인한 생산 방지

		if (ti_chek_0 != 0 && ti_chek_0 != ti_chek_1) // 매 초마다 출력 // 0일때는 포함이 안되나 위에서 if로 해당 경우를 해결함. ( Exception )
		{
			for (int i = 0; i < EnemyCountt;)
			{


				for (int ii = 0; ii < EnemyCountt;) // 생성되는 좌표가 중복되어 적이 만들어지지 않는 경우를 방지하는 for문
				{
					int o = rand() % 19 + 2; // 난수 생성 2 ~ 21

					if (o > 1 && o < 21 && o) // 적이 테두리 안에서 생성되게 한정함
					{ // 애를 안으로

						if (enemy_same_chek[i] != o) // 중복 체크, 값이 중복될 시 적은 생성되지 않고 rand부터 다시 반복된다.
						{
							mapWall[stratEnemyLine][o] = 2; // 2행 + o열에 적군 추가
							++i; // 생성된 적의 count 개수가 올라감. EnemyCountt에 지정한 값만큼 적이 생성되면 반복 종료.
							++ii;
						}
					}
				}
			}
		}

		for (int r = 1; r < WallH; ++r) // 맵 출력부
		{
			for (int c = 1; c < WallC; ++c)
			{
				printf("%s", (mapWall[r][c] == 9) ? "◈" : // 해당 좌표가 9일시 유저가 표시
					(mapWall[r][c] == -1) ? "■" : // -1이면 테두리가 출력
					(mapWall[r][c] == 2) ? "♣" : "□"); // 2면 적이 출력되고, 아니면 빈 공간으로 출력된다
				if (mapWall[r][c] == 11)
				{
					*gmae_over_chekP = 1; // 해당 좌표가 11 = 유저와 적의 위치가 겹치면 충돌 처리한다. game_over_chek 변수 + 1
				}
			}
			putchar('\n'); // 맵 1칸 내리기
		}

		if (game_over_chek == 1) // 충돌 처리된 값이 있으면
		{
			for (int r = 1; r < WallH; ++r)
			{
				for (int c = 1; c < WallC; ++c)
				{
					mapWall[r][c] = 0; // 모든 맵 지우기
				}
			}
			printf("%.1lf초\n", (GetTickCount() - GameTime) / 1000); // 플레이 시간을 출력한다.
			// %.1lf는 소수점 첫째자리까지 출력
			// 게임이 끝났을 때의 GetTickCount 값에서, 게임을 시작했을 때의 GetTickCount 값을 빼주고 1000으로 나누면 플레이 시간이 대략 출력됨.
			printf("%s", Game_over); // 게임 오버 문구를 출력 
			return 1; // 메인에 1을 반환하여, 유저가 플레이 중 패배 처리 되었음을 알린다.
		}

		if (_kbhit()) // 유저 이동키 입력부
		{
			char ch = _getch(); // 보이지 않는 입력

			if (ch == '\r') // 엔터 키를 입력 시 메인에 0을 반환하여 종료 처리한다.
			{
				return 0;
			}

			if (ch == 'w' || ch == 'W') // 위쪽으로 이동
			{
				if (mapWall[iy - 1][ix] == -1) // 이동하려는 위치가 테두리면 반응하지 않는다.
				{
				}
				else
				{
					mapWall[iy][ix] = 0; // 이동하기 이전 좌표의 값을 0 처리한다.
					--iy;
				}
			}
			if (ch == 's' || ch == 'S') // 아래쪽으로 이동
			{
				if (mapWall[iy + 1][ix] == -1)
				{
				}
				else
				{
					mapWall[iy][ix] = 0;
					++iy;
				}
			}
			if (ch == 'a' || ch == 'A') // 왼쪽으로 이동
			{
				if (mapWall[iy][ix - 1] == -1)
				{
				}
				else
				{
					mapWall[iy][ix] = 0;
					--ix;
				}
			}
			if (ch == 'd' || ch == 'D') // 오른쪽으로 이동
			{
				if (mapWall[iy][ix + 1] == -1)
				{
				}
				else
				{
					mapWall[iy][ix] = 0;
					++ix;
				}
			}
			mapWall[iy][ix] = 9; // 이동한 위치를 맵에 전달하여 저장한다.
		}
		if (ti_chek_0 != 0 && ti_chek_0 != ti_chek_1) //  시간 체크
		{
			for (int r = WallH; r > MapWallH - 1; --r)
			{
				for (int c = WallC; c > MapWallH - 2; --c)
				{
					if (mapWall[r][c] == 2) // 해당 좌표가 적이라면
					{
						if (mapWall[r + 1][c] == -1) // 적이 이동하려는 위치가 테두리라면
						{
							mapWall[r][c] = 0; // 적은 소멸한다.
						}
						else
						{
							mapWall[r + 1][c] += 2; // 적 1칸 이동
							mapWall[r][c] = 0; // 적이 이동한 공간을 비운다
						}
					}
				}
			}
			ti_chek_1 = ti_chek_0; // 사용된 시간을 저장 처리하여, 다음 반복시에 비교 데이터로 사용한다.
		}
	}
	return 0;
}

int main(int argc, char** argv)
{
	int GameST = 0; // 유저가 플레이 중 패배 되었는지, 아니면 중간에 종료 시켰는지를 파악한다.

	while (1)
	{
		GameST = Move(); // ST변수는 Move의 값을 반환 받는다. 1이면 플레이 중 패배, 0이면 도중 종료

		if (GameST == 1) // 유저가 플레이 중 패배한 경우
		{
			char Key = 0;
			printf(" 계속 [ 0 ]  \t\n"); // 0키를 입력하면 재도전 한다.
			scanf(" %c", &Key); // 키 입력부 
							   // 오류 //  "%c"로 출력시 scanf가 enter를 저장해서 버그가 뜬다. " "을 주면 " "이 저장된 enter를 먹어 정상적으로 작동함.

			if (Key == '0') // 0을 입력하면 재도전
			{

			}
			else
			{
				break; // 0 이외의 값이면 종료
			}
		}
		else if (GameST == 0) // 유저가 도중에 게임을 종료한 경우
		{
			break; // 종료처리한다.
		}
	}


	printf("\t\n\t 게임 종료 \n");
	return 0;
}