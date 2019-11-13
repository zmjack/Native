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
			LPWSTR s = (LPWSTR)malloc(20);
			WriteString(s);
			Assert::AreEqual(s, L"a string");
		}
	};
}
