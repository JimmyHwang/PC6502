#ifndef __DNA_STATUS_H__
#define __DNA_STATUS_H__

//
// DNA_STATUS Defination
//
typedef int DNA_STATUS;

#define DNA_SUCCESS             0x0000
#define DNA_LOAD_ERROR          0x0001
#define DNA_INVALID_PARAMETER   0x0002
#define DNA_UNSUPPORTED         0x0003
#define DNA_NOT_READY           0x0004
#define DNA_NOT_FOUND           0x0005
#define DNA_NOT_STARTED         0x0006
#define DNA_OUT_OF_RESOURCES    0x0007
#define DNA_ACCESS_DENIED       0x0008

#define DNA_ERROR(a)              (((INTN) (a)) != DNA_SUCCESS)
#define DNA_ASSERT(a)             (assert(a == DNA_SUCCESS))
#define ASSERT(a)                 (assert(a))

#ifndef BREAK_DNA_ERROR
#define BREAK_DNA_ERROR(status)     if (DNA_ERROR(status))    break
#endif
#ifndef BREAK_ON_ERROR
#define BREAK_ON_ERROR(condition)   if (condition)            break
#endif
#ifndef BREAK_ON_ERROR_EX
#define BREAK_ON_ERROR_EX(condition,code)   if (condition) {Status=code;break;}
#endif

#define FREE_NON_NULL(Pointer)  \
  if ((Pointer) != NULL) {      \
    FreePool((Pointer));        \
    (Pointer) = NULL;           \
  }
    
#endif