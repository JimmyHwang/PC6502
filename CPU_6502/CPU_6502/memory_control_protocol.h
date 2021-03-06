
#ifndef __MEMORY_CONTROL_PROTOCOL_H__
#define __MEMORY_CONTROL_PROTOCOL_H__

#include "typedef.h"
#include "dna_status.h"

#ifdef __cplusplus
extern "C" {
#endif

typedef struct _MEMORY_CONTROL_PROTOCOL MEMORY_CONTROL_PROTOCOL;

typedef
UINT8
(*MEMORY_CONTROL_PROTOCOL_MEMORY_READ_8)(
  MEMORY_CONTROL_PROTOCOL *This,
  UINTN Ip
);

typedef
UINT16
(*MEMORY_CONTROL_PROTOCOL_MEMORY_READ_16)(
  MEMORY_CONTROL_PROTOCOL *This,
  UINTN Ip  
);

typedef
UINT32
(*MEMORY_CONTROL_PROTOCOL_MEMORY_READ_32)(
  MEMORY_CONTROL_PROTOCOL *This,
  UINTN Ip
);

typedef
VOID
(*MEMORY_CONTROL_PROTOCOL_MEMORY_WRITE_8)(
  MEMORY_CONTROL_PROTOCOL *This,
  UINTN Ip,
  UINT8 Data  
);

typedef
VOID
(*MEMORY_CONTROL_PROTOCOL_MEMORY_WRITE_16)(
  MEMORY_CONTROL_PROTOCOL *This,
  UINTN Ip,
  UINT16 Data  
);

typedef
VOID
(*MEMORY_CONTROL_PROTOCOL_MEMORY_WRITE_32)(
  MEMORY_CONTROL_PROTOCOL *This,
  UINTN Ip,
  UINT32 Data  
);

///
/// Services to access to images in the images database.
///
struct _MEMORY_CONTROL_PROTOCOL {
  MEMORY_CONTROL_PROTOCOL_MEMORY_READ_8        Read8;
  MEMORY_CONTROL_PROTOCOL_MEMORY_READ_16       Read16;
  MEMORY_CONTROL_PROTOCOL_MEMORY_READ_32       Read32;
  MEMORY_CONTROL_PROTOCOL_MEMORY_WRITE_8       Write8;
  MEMORY_CONTROL_PROTOCOL_MEMORY_WRITE_16      Write16;
  MEMORY_CONTROL_PROTOCOL_MEMORY_WRITE_32      Write32;
};

//extern EFI_GUID gEfiHpHiiImage2ProtocolGuid;
#ifdef __cplusplus
} // closing brace for extern "C"
#endif

#endif
