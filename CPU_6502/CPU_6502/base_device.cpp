#include "typedef.h"
#include "dna_status.h"
#include "base_device.h"

UINT8 BASE_DEVICE_CLASS::Read8(UINTN Address) {
  UINT8 Data;
  
  Address &= this->AddressMask;
  if (Address < this->Size) {
    Data = *(UINT8 *)(this->Buffer + Address);
  } else {
    Data = 0;
  }
  
  return Data;
}

UINT16 BASE_DEVICE_CLASS::Read16(UINTN Address) {
  UINT16 Data;
  
  Address &= this->AddressMask;
  if (Address < this->Size) {
    Data = *(UINT16 *)(this->Buffer + Address);
  } else {
    Data = 0;
  }
  
  return Data;
}

UINT32 BASE_DEVICE_CLASS::Read32(UINTN Address) {
  UINT32 Data;
  
  Address &= this->AddressMask;
  if (Address < this->Size) {
    Data = *(UINT32 *)(this->Buffer + Address);
  } else {
    Data = 0;
  }
  
  return Data;
}

VOID BASE_DEVICE_CLASS::Write8(UINTN Address, UINT8 Data) {
  Address &= this->AddressMask;
  if (Address < this->Size) {
    *(UINT8 *)(this->Buffer + Address) = Data;
  }
}

VOID BASE_DEVICE_CLASS::Write16(UINTN Address, UINT16 Data) {
  Address &= this->AddressMask;
  if (Address < this->Size) {
    *(UINT16 *)(this->Buffer + Address) = Data;
  }
}

VOID BASE_DEVICE_CLASS::Write32(UINTN Address, UINT32 Data) {
  Address &= this->AddressMask;
  if (Address < this->Size) {
    *(UINT32 *)(this->Buffer + Address) = Data;
  }
}

json BASE_DEVICE_CLASS::Talk(json Message) {
  json result;

  result = {};

  return result;
}

BASE_DEVICE_CLASS::BASE_DEVICE_CLASS(string Type, UINT16 Size) {
  this->Type = Type;
  this->AddressMask = Size - 1;
  this->ReadOnly = false;
  this->Filename = "";
  this->Base = 0;
}

BASE_DEVICE_CLASS::~BASE_DEVICE_CLASS() {
}
