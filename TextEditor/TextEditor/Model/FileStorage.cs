using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Model
{
    public class FileStorage
    {
        public int Id { get; set; }
        public string file_name { get; set; }
        public string file_format { get; set; }
        public byte[] content { get; set; }
    }
}
