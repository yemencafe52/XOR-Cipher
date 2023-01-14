#include "pch.h"
#include "clsXor.h"

char* XorFun(char* inData, int dataLen, char* password, int passwordLen)
{
	char* res = new char[dataLen];
	int index = 0;

	memset(res, 0, dataLen);

	for (int i = 0; i < dataLen; i++)
	{
		res[i] = inData[i] ^ password[index];

		if ((index + 1) < passwordLen)
		{
			index++;
		}
		else
		{
			index = 0;
		}
	}

	return res;
}

void ClearMEM(void* ptr)
{
	char* p = (char*)ptr;
	delete p;
}

