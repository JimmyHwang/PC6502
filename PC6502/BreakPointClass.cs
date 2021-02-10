using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC6502 {
  class BREAK_POINT {
    public dynamic Data = new ExpandoObject();

    public BREAK_POINT(UInt16 Addr) {
      Data.Address = Addr;
      Data.Data = 0;
      Data.Access = 0;
      Data.Register = 0;
      Data.Compare = 0;
    }
  }

  class BREAK_POINT_CLASS {
    public List<BREAK_POINT> Items = new List<BREAK_POINT>();

    public BREAK_POINT_CLASS() {
    }

    public void Clear() {
      Items.Clear();
    }

    public bool IsExists(UInt16 Address) {
      bool st = false;
      int index = Items.FindIndex(x => x.Data.Address == Address);
      if (index != -1) {
        st = true;
      }
      return st;
    }

    public BREAK_POINT Find(UInt16 Address) {
      BREAK_POINT result;

      result = null;
      int index = Items.FindIndex(x => x.Data.Address == Address);
      if (index != -1) {
        result = Items[index];        
      }

      return result;
    }

    public BREAK_POINT Toggle(UInt16 Address) {
      BREAK_POINT result;

      result = null;
      int index = Items.FindIndex(x => x.Data.Address == Address);
      if (index == -1) {
        BREAK_POINT bp = new BREAK_POINT(Address);
        Items.Add(bp);
        result = bp;
      } else {
        Items.RemoveAt(index);
      }

      return result;
    }
  }
}
