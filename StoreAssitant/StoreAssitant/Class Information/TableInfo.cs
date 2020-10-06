using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    internal class TableInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("StoreAssistant.TableInfo:( ID = {0}; Name = {1}; )", Id, Name);
        }
    }
}
