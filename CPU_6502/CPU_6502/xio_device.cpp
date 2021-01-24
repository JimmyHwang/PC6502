#include "main.h"

#define DEBUG_XIO               0


//-----------------------------------------------------------------------------
// Serial Controller
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Memory I/O Interface
//-----------------------------------------------------------------------------
UINT8 XIO_DEVICE_CLASS::Read8(UINTN Address) {
  return 0;
}

UINT16 XIO_DEVICE_CLASS::Read16(UINTN Address) {
  return 0;
}

UINT32 XIO_DEVICE_CLASS::Read32(UINTN Address) {
  return 0;
}

VOID XIO_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {

}

VOID XIO_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
  
}

VOID XIO_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
  
}
//-----------------------------------------------------------------------------
// Class Constructor and Destructor
//-----------------------------------------------------------------------------
XIO_DEVICE_CLASS::XIO_DEVICE_CLASS():BASE_DEVICE_CLASS() {
  //
  // XIO_DEVICE_CLASS() -> XIO_DEVICE_CLASS()
  //
}

XIO_DEVICE_CLASS::~XIO_DEVICE_CLASS() {
  //
  // XIO_DEVICE_CLASS-> XIO_DEVICE_CLASS()
  //
}
