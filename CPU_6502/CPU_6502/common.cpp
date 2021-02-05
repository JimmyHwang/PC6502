#include "main.h"

string Hex02(UINT8 data) {
  char buffer[8];
  string result = "";

  sprintf(buffer, "%02X", data);
  result = buffer;

  return result;
}

string Hex04(UINT16 data) {
  char buffer[8];
  string result = "";

  sprintf(buffer, "%04X", data);
  result = buffer;

  return result;
}

char *ExportJsonString(json j) {
  int rlen;
  char *result;

  string jstr = j.dump();
  rlen = strlen(jstr.c_str()) + 1;
  result = (char *)malloc(rlen);
  strcpy(result, jstr.c_str());

  return result;
}
