using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC6502 {
  class BREAK_POINT {
    public UInt16 Address;
    public int Type;
    public int Enabled;

    public BREAK_POINT(UInt16 Addr) {
      Address = Addr;
      Type = 0;
      Enabled = 1;
    }
  }

  class BREAK_POINT_CLASS {
    byte[] BitmapTable = new byte[0x2000];
    public List<BREAK_POINT> Items = new List<BREAK_POINT>();

    public BREAK_POINT_CLASS() {
      int i;
      for (i = 0; i < 0x2000; i++) {
        BitmapTable[i] = 0;
      }
    }

    public void Clear() {
      Items.Clear();
    }

    public bool IsExists(UInt16 Address) {
      bool st = false;
      int index = Items.FindIndex(x => x.Address == Address);
      if (index != -1) {
        st = true;
      }
      return st;
    }

    public void Toggle(UInt16 Address) {
      int index = Items.FindIndex(x => x.Address == Address);
      if (index == -1) {
        BREAK_POINT bp = new BREAK_POINT(Address);
        Items.Add(bp);
      } else {
        Items.RemoveAt(index);
      }
    }
  }
}
