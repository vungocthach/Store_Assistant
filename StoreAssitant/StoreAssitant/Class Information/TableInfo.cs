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

        public TableInfo() { Name = "tableName"; Id = 0; }

        public TableInfo(int id, string name) { Id = id; Name = name; }

        public override string ToString()
        {
            return string.Format("StoreAssistant.TableInfo:( ID = {0}; Name = {1}; )", Id, Name);
        }
    }
}
