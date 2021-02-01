#include "main.h"

#define DEBUG_XIO               0

//-----------------------------------------------------------------------------
// Memory I/O Interface
//-----------------------------------------------------------------------------
UINT8 XIO_DEVICE_CLASS::Read8(UINTN Address) {
  UINT8 Data;

  Data = 0;
  Address &= this->AddressMask;
  DebugOut(L"XIO:R8,0x%X=0x%02X", Address, Data);

  return 0;
}

UINT16 XIO_DEVICE_CLASS::Read16(UINTN Address) {
  return 0;
}

UINT32 XIO_DEVICE_CLASS::Read32(UINTN Address) {
  return 0;
}

VOID XIO_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
  Address &= this->AddressMask;
  DebugOut(L"XIO:W8,0x%X=0x%02X", Address, Data);
}

VOID XIO_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
  
}

VOID XIO_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
  
}
//-----------------------------------------------------------------------------
// Class Constructor and Destructor
//-----------------------------------------------------------------------------
XIO_DEVICE_CLASS::XIO_DEVICE_CLASS(UINT16 Size):BASE_DEVICE_CLASS(Size) {
  //
  // XIO_DEVICE_CLASS() -> XIO_DEVICE_CLASS()
  //
}

XIO_DEVICE_CLASS::~XIO_DEVICE_CLASS() {
  //
  // XIO_DEVICE_CLASS-> XIO_DEVICE_CLASS()
  //
}
