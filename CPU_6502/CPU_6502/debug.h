#pragma once
#ifndef __DEBUG_H__
#define __DEBUG_H__

#include <stdio.h>
#include <assert.h>
#include <stdarg.h>
#include <assert.h>

#ifdef _UNICODE
typedef wchar_t TCHAR;
#else
typedef char TCHAR;
#endif // _UNICODE

typedef wchar_t WCHAR;
typedef const TCHAR* LPCTSTR;
typedef const WCHAR* LPCWSTR;

#ifdef UNICODE
#define LPCTSTR LPCWSTR
#else
#define LPCTSTR LPCSTR
#endif   

void DebugOut(const wchar_t *fmt, ...);

#endif