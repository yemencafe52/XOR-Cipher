#pragma once

extern "C" __declspec(dllexport) char* XorFun(char* inData, int dataLen, char* password, int passwordLen);
extern "C" __declspec(dllexport) void ClearMEM(void*);

