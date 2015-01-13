using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3UPorter
{
    /// <summary>
    /// Internal class used to report progress during the copy operation. Immutable for thread
    /// safety, or what.
    /// </summary>
    internal class ProgressReport
    {
        internal ProgressReport(int nFilesCopied,
                                int nFilesSkipped,
                                int nProcessed,
                                int totalFiles,
                                string currentFileName)
        {
            FilesCopied = nFilesCopied;
            FilesSkipped = nFilesSkipped;
            Processed = nProcessed;
            TotalFiles = totalFiles;
            CurrentFileName = currentFileName;
        }

        internal readonly int FilesCopied;

        /// <summary>
        /// Number of files skipped because the source file was missing.
        /// </summary>
        internal readonly int FilesSkipped;
        internal readonly int Processed;
        internal readonly int TotalFiles;
        internal readonly string CurrentFileName;
    }
}
