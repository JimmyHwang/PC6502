#ifndef __TYPEDEF_H__
#define __TYPEDEF_H__

#include <stdint.h>
#include <stdbool.h>
using namespace std;

#define CHAR8                   char

#define UINT8                   uint8_t
#define UINT16                  uint16_t
#define UINT32                  uint32_t
#define UINT64                  uint64_t
#define UINTN                  	unsigned long int

#define INT8                    int8_t
#define INT16                   int16_t
#define INT32                   int32_t
#define INT64                   int64_t
#define INTN                  	int64_t

#define BYTE                    uint8_t
#define WORD                    uint16_t
#define DWORD                   uint32_t
#define QWORD                   uint64_t

#define VOID                    void
#define BOOLEAN                 bool

#define TRUE                    1
#define FALSE                   0

#ifndef BREAK_ON_ERROR
#define BREAK_ON_ERROR(condition)   if (condition)            break
#endif

#define _CR(Record, TYPE, Field)  ((TYPE *) ((CHAR8 *) (Record) - (CHAR8 *) &(((TYPE *) 0)->Field)))

#endif
