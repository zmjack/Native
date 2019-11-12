#include "pch.h"
#include <string.h>

extern "C" __declspec(dllexport) void writeString(char *s)
{
	strcpy_s(s, 20, "a string");
}
