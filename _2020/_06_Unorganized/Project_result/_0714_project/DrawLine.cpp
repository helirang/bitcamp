#include "DrawLine.h"
void DrawLine::drawXLine(int sX, int eX, int yPos, const char* icon)
{
	int x = 0;
	for (x = sX; x <= eX; x++)
	{
		gotoxy(x, yPos);
		puts(icon);
	}
}
void DrawLine::drawYLine(int sY, int eY, int xPos, const char* icon)
{
	int y = 0;
	for (y = sY; y <= eY; y++)
	{
		gotoxy(xPos, y);
		puts(icon);
	}
}
void DrawLine::title() {
	setcursortype(NOCURSOR);
	while (_kbhit()) _getch();

	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);
	drawXLine(0, (WIDTH + 150) / 2, 0, "★");
	drawYLine(0, HEIGHT + 1, 0, "★");
	drawXLine(0, (WIDTH + 150) / 2, HEIGHT + 1, "★");
	drawYLine(0, HEIGHT + 1, WIDTH + 36, "★");
	gotoxy((WIDTH) / 2, 7);
	printf("+---------------------------------+\n");
	gotoxy((WIDTH) / 2, 8);
	printf("|         BIT CAMP PC ROOM        |\n");
	gotoxy((WIDTH) / 2, 9);
	printf("+---------------------------------+\n");

	gotoxy(WIDTH + 3, 9);
	cout << "＿＿＿＿__" << endl;
	gotoxy(WIDTH + 3, 10);
	cout << "/ ......　　....../" << endl;
	gotoxy(WIDTH + 3, 11);
	cout << "||:::　　∧∧ |" << endl;
	gotoxy(WIDTH + 3, 13);
	cout << "|￣＼(= ㅇヮㅇ).＼" << endl;
	gotoxy(WIDTH + 3, 15);
	cout << "|　　 |:  ￣ ￣ ~:|" << endl;
	gotoxy(WIDTH + 3, 16);
	cout << "|　　 |:   :|" << endl;
	gotoxy(WIDTH + 3, 17);
	cout << "￣￣￣￣￣￣" << endl;

	gotoxy(WIDTH - 70, 9);
	cout << "            __＿＿＿＿" << endl;
	gotoxy(WIDTH - 70, 10);
	cout << "   ＼ ......　　......＼" << endl;
	gotoxy(WIDTH - 70, 12);
	cout << "      | ∧∧　　   :::||" << endl;
	gotoxy(WIDTH - 70, 13);
	cout << "    /.(ㅇヮㅇ = ) / ￣ |" << endl;
	gotoxy(WIDTH - 70, 15);
	cout << "    |:~  ￣ ￣    :|   |" << endl;
	gotoxy(WIDTH - 70, 16);
	cout << "            　|:  :|   |" << endl;
	gotoxy(WIDTH - 70, 17);
	cout << "            ￣￣￣￣￣￣" << endl;
	while (1) {
		if (_kbhit()) {
			char key = 0;
			key = _getch();
			if (key == 0) exit(0);
			else break; //
		}
		gotoxy((WIDTH + 15) / 2, 19);
		cout << "<< 관리자모드 실행 >>";
		Sleep(50);


		gotoxy(WIDTH, 24);
		cout << "TEAM  || 안정현 || 최광현 || 안예주\n";
	}
}