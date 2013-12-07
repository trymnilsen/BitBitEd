using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitEd.Core
{
    class WaitCursorHelper: IDisposable
    {
            private Cursor previousCursor;

            public WaitCursorHelper()
            {
                previousCursor = Mouse.OverrideCursor;

                Mouse.OverrideCursor = Cursors.Wait;
            }

            public void Dispose()
            {
                Mouse.OverrideCursor = previousCursor;
            }
    }
}