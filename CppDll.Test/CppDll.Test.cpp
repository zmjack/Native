#include "pch.h"
#include <Windows.h>
#include "CppUnitTest.h"
#include "../CppDll/CppDll.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace CppDllTest
{
	TEST_CLASS(CppDllTest)
	{
	public:

		TEST_METHOD(TestMethod1)
		{
			LPWSTR pstr = (LPWSTR)malloc(sizeof(WCHAR) * 20);
			WriteString(pstr);
			Assert::AreEqual(L"string...", pstr);
			free(pstr);
		}
	};
}
