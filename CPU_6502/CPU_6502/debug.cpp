#include <windows.h>
#include <stdio.h>
#include <stdarg.h>
#include <debugapi.h>

void DebugOut(const wchar_t *fmt, ...) {
	va_list argp;
	va_start(argp, fmt);
	wchar_t dbg_out[4096];
	vswprintf_s(dbg_out, fmt, argp);
	va_end(argp);
	OutputDebugStringW(dbg_out);
}
