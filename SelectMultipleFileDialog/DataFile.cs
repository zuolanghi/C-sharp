using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectMultipleFileDialog
{
    class DataFile
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }   
        public long size { get; set; }
        public float progress { get; set; }
        public int speed { get; set; }

        public string path { get; set; }
    }
}
