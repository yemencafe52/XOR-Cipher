#include "pch.h"
#include "clsTest.h"
#include "clsXor.h"
#include <iostream>;


int main()
{
	char data[] = "abc";
	char pass[] = "123";

	char* res = XorFun(data, 3, pass, 3);
	std::cout << res  << std::endl;

	res = XorFun(res, 3, pass, 3);
	std::cout << res << std::endl;

	system("pause");
	return 0;
}