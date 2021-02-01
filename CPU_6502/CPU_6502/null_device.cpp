#include "main.h"
#include <assert.h>

//-----------------------------------------------------------------------------
// Memory I/O Interface
//-----------------------------------------------------------------------------
UINT8 NULL_DEVICE_CLASS::Read8(UINTN Address) {
  return 0xFF;
}

UINT16 NULL_DEVICE_CLASS::Read16(UINTN Address) {
  assert(false);
  return 0xFFFF;
}

UINT32 NULL_DEVICE_CLASS::Read32(UINTN Address) {
  assert(false);
  return 0xFFFFFFFF;
}

VOID NULL_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
}

VOID NULL_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
}

VOID NULL_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
}

//-----------------------------------------------------------------------------
// Class Constructor and Destructor
//-----------------------------------------------------------------------------
NULL_DEVICE_CLASS::NULL_DEVICE_CLASS() :BASE_DEVICE_CLASS(0) {
  //
  // NULL_DEVICE_CLASS() -> NULL_DEVICE_CLASS()
  //
}

NULL_DEVICE_CLASS::~NULL_DEVICE_CLASS() {
  //
  // NULL_DEVICE_CLASS-> NULL_DEVICE_CLASS()
  //
}
