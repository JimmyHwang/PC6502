#include "main.h"

PLATFORM_CLASS *gPlatform = NULL;

//-----------------------------------------------------------------------------
// DLL Functions
//-----------------------------------------------------------------------------
int InitializeVM() {
  DNA_STATUS Status;

  gPlatform = new PLATFORM_CLASS();
  if (gPlatform != NULL) {
    Status = DNA_SUCCESS;
  } else {
    Status = DNA_OUT_OF_RESOURCES;
  }

  return Status;
}

int LoadBIOS(const char *filename) {
  DNA_STATUS Status;
  
  Status = gPlatform->LoadBIOS(filename);

  return Status;
}

//-----------------------------------------------------------------------------
// Memory Functions
//-----------------------------------------------------------------------------
int main() {
  PLATFORM_CLASS *Platform = new PLATFORM_CLASS();
  Platform->LoadBIOS("Startup.bin");

  return 0;
}