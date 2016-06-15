using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompiler
{
    /// <summary>
    /// Contains dependency information (on what file is the current file dependent, what other files are dependent on this file) for a file
    /// </summary>
    public class Dependencies
    {
        /// <summary>
        /// Contains all files the current file is dependent ont
        /// </summary>
        public HashSet<string> DependentOn { get; set; }

        /// <summary>
        /// Contains all files that are dependent on this file
        /// </summary>
        public HashSet<string> DependentFiles { get; set; }

        public Dependencies()
        {
            DependentOn = new HashSet<string>();
            DependentFiles = new HashSet<string>();
        }
    }
}