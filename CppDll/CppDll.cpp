#include "pch.h"
#include "CppDll.h"
#include <Windows.h>
#include <malloc.h>

extern "C" __declspec(dllexport) LPWSTR __stdcall CreateString()
{
	LPWSTR lpwstr = (LPWSTR)malloc(sizeof(WCHAR) * 20);
	return lpwstr;
}

extern "C" __declspec(dllexport) void __stdcall WriteString(LPWSTR lpwstr)
{
	wcscpy_s((wchar_t*)lpwstr, 20, L"a string");
}

extern "C" __declspec(dllexport) void __stdcall FreeString(LPWSTR lpwstr)
{
	free(lpwstr);
}
