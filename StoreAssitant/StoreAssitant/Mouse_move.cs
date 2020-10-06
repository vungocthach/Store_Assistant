using System;

namespace StoreAssitant
{
    internal class Mouse_move
    {
        private TableControl tableControl;
        private EventArgs e;

        public Mouse_move(TableControl tableControl, EventArgs e)
        {
            this.tableControl = tableControl;
            this.e = e;
        }
    }
}