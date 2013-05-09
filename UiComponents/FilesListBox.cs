﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FilesBrowser
{
    /// <summary>
    /// Represents a ListBox control with file names as items.
    /// </summary>
    [Description("Display a list of files that the user can select from"),
     DefaultProperty("DirectoryName"),
     DefaultEvent("FileSelected")]
    public class FilesListBox : ListBox
    {
        #region Events

        /// <summary>
        /// Occures whenever a file is selected by a double click on the control.
        /// </summary>
        [Description("Occures whenever a file is selected by a double click on the control"),
        Category("Action")]
        public event FileSelectedEventHandler FileSelected;

        /// <summary>
        /// Occures whenever a file is selected by a double click on the control.
        /// </summary>
        [Description("Occures whenever a SelectedPath is changing"),
        Category("Action")]
        public event SelectedPathChangedEventHandler SelectedPathChanged;

        #endregion

        #region Properties
               
        string _selectedPath = "C:\\";
        /// <summary>
        /// Gets or sets the directory name that the files should relate to
        /// </summary>        
        [Description("Gets or sets the directory name that the files should relate to"),
        DefaultValue("C:\\"), Category("Data")]
        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                if (_selectedPath != string.Empty && !String.IsNullOrEmpty(value) && Directory.Exists(value))
                { 
                    PopulatingItems(value);
                    OnSelectedPathChanged(new SelectedPathChangedEventArgs(_selectedPath, value));
                    _selectedPath = value;
                }
            }
        }

        bool _showFiles = true;
        /// <summary>
        /// Gets or sets a value indicating wheater to show directories on the control
        /// </summary>        
        [Description("Gets or sets a value indicating wheater to show files on the control"),
        DefaultValue(true), Category("Behavior")]
        public bool ShowFiles
        {
            get { return _showFiles; }
            set
            {
                _showFiles = value;
                PopulatingItems();
            }
        }

        bool _showDirectories = true;         
        /// <summary>
        /// Gets or sets a value indicating wheater to show directories on the control
        /// </summary>        
        [Description("Gets or sets a value indicating wheater to show directories on the control"),
        DefaultValue(true), Category("Behavior")]
        public bool ShowDirectories
        {
            get { return _showDirectories; }
            set 
            { 
                _showDirectories = value; 
                PopulatingItems();
            }
        }

        bool _showBackIcon = true;
        /// <summary>
        /// Gets or sets a value indicating wheater to show the back directory icon
        /// on the control (when the IsToShowDirectories property is true)
        /// </summary>        
        [Description("Gets or sets a value indicating wheater to show the back directory icon on the control (when the IsToShowDirectories property is true)"),
       DefaultValue(true), Category("Behavior")]       
        public bool ShowBackIcon
        {
            get { return _showBackIcon; }
            set
            {
                _showBackIcon = value;
                PopulatingItems();
            }
        }

        /// <summary>
        /// Gets an array containting the currently selected files (without directories) 
        /// in the FilesListBox.
        /// </summary>
        [Browsable(false)]             
        public string[] SelectedFiles
        {
            get
            {
                ArrayList selectedFiles = new ArrayList();
                foreach (object file in SelectedItems)
                {
                    string selectedFile = GetFullName(file.ToString());
                    // .. ---> go back one level
                    if (selectedFile.EndsWith(".."))
                    {
                        continue;
                    }
                    // only files should be selected
                    else if (File.Exists(selectedFile))
                    {
                        selectedFiles.Add(selectedFile);
                    }                    
                }
                return selectedFiles.ToArray(typeof(string)) as string[];
            }
        }
        /// <summary>
        /// Gets the currently selected file in the FilesListBox
        /// </summary>
        [Browsable(false)]
        public string SelectedFile
        {
            get
            {
                string[] selectedFiles = SelectedFiles;
                if (selectedFiles.Length > 0)
                    return selectedFiles[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets an array containting the currently selected directories (without files) 
        /// in the FilesListBox.
        /// </summary>
        [Browsable(false)]
        public string[] SelectedDirectories
        {
            get
            {
                ArrayList selectedDirectories = new ArrayList();
                foreach (object file in SelectedItems)
                {
                    string selectedDirectory = GetFullName(file.ToString());
                    // .. ---> go back one level
                    if (selectedDirectory.EndsWith(".."))
                    {
                        continue;
                    }
                    // only files should be selected
                    else if (Directory.Exists(selectedDirectory))
                    {
                        selectedDirectories.Add(selectedDirectory);
                    }
                }
                return selectedDirectories.ToArray(typeof(string)) as string[];
            }
        }
        /// <summary>
        /// Gets the currently selected directory in the FilesListBox
        /// </summary>
        [Browsable(false)]
        public string SelectedDirectory
        {
            get
            {
                string[] selectedDirectories = SelectedDirectories;
                if (selectedDirectories.Length > 0)
                    return selectedDirectories[0];
                else
                    return null;
            }
        }

        private IconSize _fileIconSize = IconSize.Small;
        /// <summary>
        /// Gets or sets the icon size, this value also sets the item heigth
        /// </summary>
        [Description("Specifies the size of the icon of each file - small or large"),
         DefaultValue(typeof(IconSize), "IconSize.Small"), Category("Appearance")] 
        public IconSize FileIconSize
        {
            get { return _fileIconSize; }
            set 
            { 
                _fileIconSize = value;
                switch (_fileIconSize)
                {
                    case IconSize.Small:
                        base.ItemHeight = 16;
                        break;
                    case IconSize.Large:
                        base.ItemHeight = 32;
                        break;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the item height. can only be 32 or 16.
        /// </summary>
        [Browsable(false)]
        public override int ItemHeight
        {
            get
            {
                return base.ItemHeight;
            }
            set
            {
                if (value == 32)
                {
                    FileIconSize = IconSize.Large;
                    base.ItemHeight = 32;
                }
                else
                {
                    FileIconSize = IconSize.Small;
                    base.ItemHeight = 16;
                }
                
            }
        }

        #endregion

        #region Ctor(s)

        /// <summary>
        /// Intializes a new instance of the FilesListBox class, to view a list of
        /// files inside a ListBox control.
        /// </summary>
        public FilesListBox()
        {
            SelectionMode = SelectionMode.One;
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        /// <summary>
        /// Intializes a new instance of the FilesListBox class, to view a list of
        /// files inside a ListBox control.
        /// </summary>
        /// <param name="directoryName">The directory to start from</param>
        public FilesListBox(string directoryName)
            : this()
        {
            _selectedPath = SelectedPath;
            PopulatingItems();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Adds the specified directory to the list.
        /// </summary>
        /// <param name="directoryName"></param>
        private void AddDirectory(string directoryName)
        {
            Items.Add(directoryName);
        }

        /// <summary>
        /// Adds the specified file to the list.
        /// </summary>
        /// <param name="fileName"></param>
        private void AddFile(string fileName)
        {
            Items.Add(fileName);
        }

        /// <summary>
        /// Gets the full file name, by adding the directory name to the file specified.
        /// </summary>
        /// <param name="fileNameOnly"></param>
        /// <returns></returns>
        private string GetFullName(string fileNameOnly)
        {
            return Path.Combine(_selectedPath, fileNameOnly);
        }

        /// <summary>
        /// Populate the list box with files and directories according to the 
        /// directoryName property
        /// </summary>
        private void PopulatingItems(string _selectedPath = null)
        {
            // Ignore when in desing mode
            if (DesignMode)
                return;

            var selecteditem = -1;
            var selectedPath = _selectedPath ?? this._selectedPath;
            var selectedDirectory = SelectedDirectory;
            //this.BeginUpdate();
            this.Items.Clear();
            // Shows the back directory item (            
            if (_showBackIcon && selectedPath.Length > 3)
            {
                Items.Add("..");
                if (String.Compare(selectedDirectory, selectedPath.TrimEnd(new []{Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar}), true) == 0)
                    selecteditem = 0;
            }
            try
            {
                // Fills all directory items
                if (_showDirectories)
                {
                    string[] dirNames = Directory.GetDirectories(selectedPath);
                    foreach (string dir in dirNames)
                    {
                        string realDir = Path.GetFileName(dir);
                        Items.Add(realDir);
                        if (String.Compare(this._selectedPath, dir, true) == 0)
                            selecteditem = Items.Count - 1;
                    }
                }
                // Fills all list items
                if (_showFiles)
                {
                    string[] fileNames = Directory.GetFiles(selectedPath);
                    foreach (string file in fileNames)
                    {
                        string fileName = Path.GetFileName(file);
                        Items.Add(fileName);
                    }
                }

                if (selecteditem >= 0)
                    base.SelectedIndex = selecteditem;
            }
            catch
            {
                // eat this - back is still optional even when no other items exists
            }
            //this.EndUpdate();
            Invalidate();
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Overrides, when double click on the list - fires the FileSelected event,
        /// or, for directory, move into it.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (SelectedItem == null) return;
            string selectedFile = GetFullName(SelectedItem.ToString());
            // .. ---> go back one level
            if (selectedFile.EndsWith("..")) {
                var ___selectedPath = _selectedPath;
                // Removes the \ in the end, so that the parent will return the real parent.
                if (___selectedPath.EndsWith("\\"))
                    ___selectedPath = _selectedPath.Remove(_selectedPath.Length - 1, 1);
                ___selectedPath =  Directory.GetParent(_selectedPath).FullName;

                SelectedPath = ___selectedPath;
            }
            // go inside the directory
            else if (Directory.Exists(selectedFile)) {
                if (_showBackIcon) {
                    SelectedPath = selectedFile + "\\";
                }
            } else {
                OnFileSelected(new FileSelectEventArgs(selectedFile));
            }
            base.OnMouseDoubleClick(e);
        }
        /// <summary>
        /// Fires the FileSelected event.
        /// </summary>
        /// <param name="fse"></param>
        protected void OnFileSelected(FileSelectEventArgs fse)
        {
            if (FileSelected != null)
                FileSelected(this, fse);
        }

        protected void OnSelectedPathChanged(SelectedPathChangedEventArgs spce)
        {
            if (SelectedPathChanged != null)
                SelectedPathChanged(this, spce);
        }  
        

        #endregion

        #region Painting
        /// <summary>
        /// Paints each file with its icon.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();            
            Rectangle bounds = e.Bounds;
            if (e.Index > -1 && e.Index < Items.Count)
            {
                Size imageSize;
                string fileNameOnly = Items[e.Index].ToString();
                string fullFileName = GetFullName(fileNameOnly);
                Icon fileIcon = null;
                Rectangle imageRectangle = new Rectangle( bounds.Left + 1, bounds.Top +1 , ItemHeight - 2,ItemHeight - 2);
                if (fileNameOnly.Equals(".."))
                {                    
                    // When .. is the string - draws directory icon                    
                    fileIcon =
                        IconExtractor.GetFileIcon(Application.StartupPath, _fileIconSize);
                    e.Graphics.DrawIcon(fileIcon,imageRectangle);                    
                }
                else
                {
                    fileIcon =
                        IconExtractor.GetFileIcon(fullFileName, _fileIconSize);
                        // Icon.ExtractAssociatedIcon(item);
                    e.Graphics.DrawIcon(fileIcon,imageRectangle);
                }
                imageSize = imageRectangle.Size;
                fileIcon.Dispose();

              
                Rectangle fileNameRec = new Rectangle(bounds.Left + imageSize.Width + 3, bounds.Top , bounds.Width - imageSize.Width - 3, bounds.Height);
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(fileNameOnly, e.Font, new SolidBrush(e.ForeColor),
                    fileNameRec, format);
            }
            
            base.OnDrawItem(e);
        }        

        #endregion
    }

    #region Enums
    /// <summary>
    /// Specifies the icon size (16 or 32)
    /// </summary>
    public enum IconSize
    {
        /// <summary>
        /// 16X16 icon
        /// </summary>
        Small,
        /// <summary>
        /// 32X32 icon
        /// </summary>
        Large       
    }
    #endregion

    #region FileSelectEventArgs
    /// <summary>
    /// Represents the method that is used to handle file selected event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fse"></param>
    public delegate void FileSelectedEventHandler(object sender, FileSelectEventArgs fse);

    public delegate void SelectedPathChangedEventHandler(object sender, SelectedPathChangedEventArgs fse);

    /// <summary>
    /// Provides for FileSelect event.
    /// </summary>
    public class FileSelectEventArgs : EventArgs
    {
        private string fileName;

        /// <summary>
        /// Gets or sets the file name that trigered the event.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = FileName; }
        }
        /// <summary>
        /// Initializes a new instance of the FileSelectEventArgs in order to provide
        /// data for FileSelected event.
        /// </summary>
        /// <param name="fileName"></param>
        public FileSelectEventArgs(string fileName)
        {
            this.fileName = fileName;
        }

    }
    
    public class SelectedPathChangedEventArgs : EventArgs
    {
        public string OldSelectedPath
        {
            get { return oldSelectedPath; }
            set { oldSelectedPath = OldSelectedPath; }
        } private string oldSelectedPath;

        public string NewSelectedPath
        {
            get { return newSelectedPath; }
            set { newSelectedPath = NewSelectedPath; }
        } private string newSelectedPath;

        public SelectedPathChangedEventArgs(string oldSelectedPath, string newSelectedPath)
        {
            this.oldSelectedPath = oldSelectedPath;
            this.newSelectedPath = newSelectedPath;
        }

    }
    #endregion

    #region Icon Extractor
    /// <summary>
    /// Util class to extract icons from files or directories.
    /// </summary>
    class IconExtractor
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        
        class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath,
                                        uint dwFileAttributes,
                                        ref SHFILEINFO psfi,
                                        uint cbSizeFileInfo,
                                        uint uFlags);
        }   
       
        /// <summary>
        /// Gets the icon asotiated with the filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetFileIcon(string fileName, IconSize _iconSize)
        {
            System.Drawing.Icon myIcon = null;
            try
            {
                IntPtr hImgSmall;    //the handle to the system image list
                SHFILEINFO shinfo = new SHFILEINFO();

                //Use this to get the small Icon
                hImgSmall = Win32.SHGetFileInfo(fileName, 0, ref shinfo,
                                                (uint)Marshal.SizeOf(shinfo),
                                                Win32.SHGFI_ICON |
                                               (_iconSize == IconSize.Small ? Win32.SHGFI_SMALLICON : Win32.SHGFI_LARGEICON) );

                //The icon is returned in the hIcon member of the shinfo
                //struct
                myIcon =
                        System.Drawing.Icon.FromHandle(shinfo.hIcon);
            }
            catch
            {
                return null;
            }
            return myIcon;
        }   
    }
    #endregion
}
