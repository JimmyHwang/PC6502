
#ifndef __CPU_CONTROL_PROTOCOL_H__
#define __CPU_CONTROL_PROTOCOL_H__

#include "typedef.h"
#include "dna_status.h"

#ifdef __cplusplus
extern "C" {
#endif

#define CPU_VREG_IRQ_STATUS             0x00000000  // (R/x)
#define     VREG_IRQ_RUNNING            0x00000001  // 1:In Interrupt Routing

typedef struct _CPU_CONTROL_PROTOCOL CPU_CONTROL_PROTOCOL;

typedef
VOID
(*CPU_CONTROL_PROTOCOL_RESET)(
  CPU_CONTROL_PROTOCOL *This
);

typedef
VOID
(*CPU_CONTROL_PROTOCOL_IRQ)(
  CPU_CONTROL_PROTOCOL *This,
  UINT8 Number
);

typedef
VOID
(*CPU_CONTROL_PROTOCOL_NMI)(
  CPU_CONTROL_PROTOCOL *This
);

typedef
VOID
(*CPU_CONTROL_PROTOCOL_HALT)(
  CPU_CONTROL_PROTOCOL *This
);

typedef
int
(*CPU_CONTROL_PROTOCOL_RUN)(
  CPU_CONTROL_PROTOCOL *This,
  UINTN Count
);

typedef
DNA_STATUS
(*CPU_CONTROL_PROTOCOL_SET)(
  CPU_CONTROL_PROTOCOL *This,
  int Index,
  UINTN Data
);

typedef
DNA_STATUS
(*CPU_CONTROL_PROTOCOL_GET)(
  CPU_CONTROL_PROTOCOL *This,
  int Index,
  UINTN *Data
);

//
// Services to access to images in the images database.
//
struct _CPU_CONTROL_PROTOCOL {
  CPU_CONTROL_PROTOCOL_RESET                Reset;
  CPU_CONTROL_PROTOCOL_RUN                  Run;
  CPU_CONTROL_PROTOCOL_IRQ                  IRQ;
  CPU_CONTROL_PROTOCOL_NMI                  NMI;
  CPU_CONTROL_PROTOCOL_HALT                 Halt;
  CPU_CONTROL_PROTOCOL_SET                  Set;
  CPU_CONTROL_PROTOCOL_GET                  Get;
};

//extern EFI_GUID gEfiHpHiiImage2ProtocolGuid;
#ifdef __cplusplus
} // closing brace for extern "C"
#endif

#endif
