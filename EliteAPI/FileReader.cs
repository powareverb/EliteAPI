﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EliteAPI
{
    internal static class FileReader
    {
        internal static IEnumerable<string> ReadAllLines(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        internal static string ReadAllText(string path)
        {
            return string.Join(Environment.NewLine, ReadAllLines(path));
        }
    }
}