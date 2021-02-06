#include "main.h"

#define DEBUG_XIO               0

//-----------------------------------------------------------------------------
// Memory I/O Interface
//-----------------------------------------------------------------------------
UINT8 XIO_DEVICE_CLASS::Read8(UINTN Address) {
  UINTN Index;
  UINT8 Data;
  
  Index = Address & 0x0F;
  if (Index < 8) {
    Data = this->Regs[Index & 3];
  } else {
    Data = this->Regs[0x08];
  }
  //DebugOut(L"XIO:R8,0x%X=0x%02X", Index, Data);

  return Data;
}

UINT16 XIO_DEVICE_CLASS::Read16(UINTN Address) {
  return 0;
}

UINT32 XIO_DEVICE_CLASS::Read32(UINTN Address) {
  return 0;
}

VOID XIO_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
  UINTN Index;
  UINT8 Mask;

  Index = Address & 0x0F;
  //DebugOut(L"XIO:W8,0x%X=0x%02X", Index, Data);
  if (Index < 8) {
    this->Regs[Index & 3] = Data;
  } else {
    Mask = Data ^ 0xFF;
    this->Regs[0x08] &= Mask;
  }
  json j;
  j["Target"] = "XIO";
  j["Mode"] = MEMORY_ACCESS_WRITE;
  j["Address"] = Index;
  j["Data"] = Data;
  VM->Callback(ExportJsonString(j));
}

VOID XIO_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
  
}

VOID XIO_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
  
}

json XIO_DEVICE_CLASS::Talk(json args) {
  json result;
  string name;

  result = {};
  if (args["Command"] == "Click") {
    name = args["Name"];
    if (name == "Reset") {
      this->Regs[0x08] |= 0x08;
    } else if (name == "Start") {
      this->Regs[0x08] |= 0x04;
    } else if (name == "Minute") {
      this->Regs[0x08] |= 0x02;
    } else if (name == "Second") {
      this->Regs[0x08] |= 0x01;
    }
  }
  result["Status"] = "Success";
  //DebugOut(L"XIO::Regs[0x08]=0x%X", this->Regs[0x08]);

  return result;
}


//-----------------------------------------------------------------------------
// Class Constructor and Destructor
//-----------------------------------------------------------------------------
XIO_DEVICE_CLASS::XIO_DEVICE_CLASS(UINT16 Size):BASE_DEVICE_CLASS("XIO", Size) {
  //
  // XIO_DEVICE_CLASS() -> XIO_DEVICE_CLASS()
  //
}

XIO_DEVICE_CLASS::~XIO_DEVICE_CLASS() {
  //
  // XIO_DEVICE_CLASS-> XIO_DEVICE_CLASS()
  //
}
