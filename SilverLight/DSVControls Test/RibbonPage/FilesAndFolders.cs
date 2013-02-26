// Copyright (c) 2010
// by OpenLight Group
// http://openlightgroup.net/
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
//
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Drawing;
using System.IO;

namespace RibbonPage
{

    [Serializable]
    public class FileInfo
    {
        public string Name { get; private set; }
        public string FullName { get;  private set;}
        public string Extension { get; private set; }
        public DirectoryInfo Directory { get; private set; }
        public long Length { get; private set; }

        public FileInfo() { }

        public FileInfo(string name, DirectoryInfo directory, long length)
        {
            Name = name;

            if (directory.FullName != null && directory.FullName.Length > 0)
            {
                if (directory.FullName[directory.FullName.Length - 1] == '\\')
                {
                    FullName = directory.FullName + name;
                }
                else
                {
                    FullName = directory.FullName + "\\" + name;
                }
            }
            else
            {
                FullName = name;
            }

            Extension = "";
            if (name.LastIndexOf('.') > -1)
            {
                Extension = name.Substring(name.LastIndexOf('.'));
            }

            Directory = directory;
            Length = length;
        }
    }

    [Serializable]
    public class DirectoryInfo
    {
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public DirectoryInfo Parent { get; private set; }
        public List<FileInfo> Files { get; private set; }
        public List<DirectoryInfo> Directories { get; private set; }

        public DirectoryInfo() { }

        public DirectoryInfo(string fullName, List<DirectoryInfo> directories, List<FileInfo> files)
        {
            Name = GetDirectoryName(fullName);
            FullName = fullName;

            Files = files == null ? new List<FileInfo>() : files;
            Directories = directories == null ? new List<DirectoryInfo>() : directories;
        }
        
        public DirectoryInfo(string name, DirectoryInfo parent, List<DirectoryInfo> directories, List<FileInfo> files)
        {
            Name = name;

            if (parent.FullName != null && parent.FullName.Length > 0)
            {
                if (parent.FullName[parent.FullName.Length - 1] == '\\')
                {
                    FullName = parent.FullName + name;
                }
                else
                {
                    FullName = parent.FullName + "\\" + name;
                }
            }
            else
            {
                FullName = name;
            }

            Parent = parent;
            Files = files == null ? new List<FileInfo>() : files;
            Directories = directories == null ? new List<DirectoryInfo>() : directories;
        }

        public DirectoryInfo(string fullName)
            :this(fullName,null,null)  {  }

        public DirectoryInfo(string name, DirectoryInfo parent)
            : this(name, parent, null, null) { }


        private string GetDirectoryName(string fullName)
        {
            if (fullName.LastIndexOf('\\') > -1)
            {
                return fullName.Substring(fullName.LastIndexOf('\\')+1);
            }
            return fullName;
        }
    }
}