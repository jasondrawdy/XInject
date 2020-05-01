/*
==============================================================================
Copyright © Jason Drawdy 

All rights reserved.

The MIT License (MIT)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Except as contained in this notice, the name of the above copyright holder
shall not be used in advertising or otherwise to promote the sale, use or
other dealings in this Software without prior written authorization.
==============================================================================
*/

#region Imports

using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Vestris.ResourceLib;
using Mono.Security;

using BrightIdeasSoftware;

#endregion
namespace XInject
{
    public partial class frmMain : Form
    {
        #region Variables

        //Start here because if the user has selected an app icon in VS then
        //it will get the id 32512, which is some kind of special id for app
        //icons. Explorer shows the first icon in the file by default, so
        //we'll give our injected icons names that are higher than 32512 so
        //the originally selected icon is the first one in the file.
        private const int StartID = 40000;

        #endregion
        #region Initialization

        public frmMain()
        {
            InitializeComponent();

            // Change the material skin color.
            var instance = MaterialSkin.MaterialSkinManager.Instance;
            instance.AddFormToManage(this);
            MaterialSkin.ColorScheme scheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.PGrey900, MaterialSkin.Primary.PGrey900, 
                                                                            MaterialSkin.Accent.PGrey900, MaterialSkin.TextShade.BLACK);
            instance.ColorScheme = scheme;
            instance.RemoveFormToManage(this);

            // Create text overlays with colors to match our theme.
            TextOverlay fileOverlay = lvIcons.EmptyListMsgOverlay as TextOverlay;
            fileOverlay.BorderWidth = 0f;
            fileOverlay.Font = new Font(Font.FontFamily, 12);
            fileOverlay.TextColor = Color.DimGray;
            fileOverlay.BackColor = Color.FromArgb(255, 255, 255);
            fileOverlay.BorderColor = Color.FromArgb(40, 146, 255);

            // Create our HotTracking decoration.
            RowBorderDecoration rbd = new RowBorderDecoration();
            rbd.BorderPen = new Pen(Color.FromArgb(64, Color.White), 0);
            rbd.FillBrush = new SolidBrush(Color.FromArgb(64, SystemColors.Highlight));
            rbd.BoundsPadding = new Size(0, 0);
            rbd.CornerRounding = 0.0f;
            lvIcons.HotItemStyle = new HotItemStyle();
            lvIcons.HotItemStyle.Decoration = rbd;

            // Create a custom column sorter.
            lvIcons.CustomSorter = CustomSorter;

            // Set our image selection delegates for both of our listviews.
            colStatus.ImageGetter = delegate (object x)
            {
                IconObject casted = (IconObject)x;
                switch (casted.Status)
                {
                    case "Injected":
                        return 0;
                    case "Idle":
                        return 1;
                    case "Warning":
                        return 2;
                    case "Error":
                        return 3;
                    default:
                        return 1;
                }
            };

            // Set listview column aspects programmatically since we're utilizing executable encryption.
            colName.AspectGetter += delegate (object x)
            { return ((IconObject)x).Name; };
            colExtension.AspectGetter += delegate (object x)
            { return ((IconObject)x).Extension; };
            colPath.AspectGetter += delegate (object x)
            { return ((IconObject)x).Path; };
            colSize.AspectGetter += delegate (object x)
            { return ((IconObject)x).Size; };
            colLength.AspectGetter += delegate (object x)
            { return ((IconObject)x).Length; };
            colStatus.AspectGetter += delegate (object x)
            { return ((IconObject)x).Status; };
        }

        #endregion
        #region Controls

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (lvIcons.Items.Count == 0)
            {
                lvIcons.View = View.SmallIcon;
                btnInject.Enabled = false;
            }
            else
            {
                lvIcons.View = View.Details;
                btnInject.Enabled = true;
            }
        }
        
        private void lvIcons_CanDrop(object sender, OlvDropEventArgs e)
        {
            DataObject d = (DataObject)e.DataObject;
            if (d.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvIcons_Dropped(object sender, OlvDropEventArgs e)
        {
            DataObject d = (DataObject)e.DataObject;
            if (d.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                try
                {
                    string[] data = (string[])d.GetData(DataFormats.FileDrop);
                    List<IconObject> icons = new List<IconObject>();
                    foreach (string file in data)
                    {
                        if (Path.GetFileName(file).Contains(".ico"))
                        {
                            string name = Path.GetFileName(file).Replace(Path.GetExtension(file), "");
                            string extension = Path.GetExtension(file);
                            string path = file;
                            long length = new FileInfo(file).Length;
                            string size = length.ToFileSize();
                            string status = "Idle";
                            IconObject io = new IconObject(name, extension, path, size, length.ToString(), status);
                            icons.Add(io);
                        }
                    }

                    if (icons.Count > 0)
                        lvIcons.AddObjects(icons);

                    if (lvIcons.Items.Count == 0)
                    {
                        lvIcons.View = View.SmallIcon;
                        btnInject.Enabled = false;
                    }
                    else
                    {
                        lvIcons.View = View.Details;
                        if (txtAssemblyPath.Text == "")
                            btnInject.Enabled = false;
                        else
                            btnInject.Enabled = true;
                    }
                }
                catch { }
            }
        }

        private void txtAssemblyPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose an Assembly";
            ofd.Filter = "Executable File (*.exe)|*.exe";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAssemblyPath.Text = ofd.FileName;
                if (lvIcons.Items.Count > 0)
                {
                    if (txtAssemblyPath.Text == "")
                        btnInject.Enabled = false;
                    else
                        btnInject.Enabled = true;
                }
            }
        }

        private void txtCertificatePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a Certificate";
            ofd.Filter = "All Files (*.*)|*.*";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCertificatePath.Text = ofd.FileName;
            }
        }

        private void chkResign_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResign.Checked)
                txtCertificatePath.Enabled = true;
            else
                txtCertificatePath.Enabled = false;
        }

        private void conMain_Opening(object sender, CancelEventArgs e)
        {
            if (lvIcons.SelectedObjects.Count > 0)
                conRemove.Enabled = true;
            else
                conRemove.Enabled = false;

            if (lvIcons.Items.Count > 0)
                conSelectAll.Enabled = true;
            else
                conSelectAll.Enabled = false;
        }

        private void conAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Choose Icons to Inject";
            ofd.Filter = "Icon File (*.ico)|*.ico";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<IconObject> icons = new List<IconObject>();
                foreach (string file in ofd.FileNames)
                {
                    string name = Path.GetFileName(file).Replace(Path.GetExtension(file), "");
                    string extension = Path.GetExtension(file);
                    string path = file;
                    long length = new FileInfo(file).Length;
                    string size = length.ToFileSize();
                    string status = "Idle";
                    IconObject io = new IconObject(name, extension, path, size, length.ToString(), status);
                    icons.Add(io);
                }
                lvIcons.AddObjects(icons);

                if (lvIcons.Items.Count == 0)
                {
                    lvIcons.View = View.SmallIcon;
                    btnInject.Enabled = false;
                }
                else
                {
                    lvIcons.View = View.Details;
                    if (txtAssemblyPath.Text == "")
                        btnInject.Enabled = false;
                    else
                        btnInject.Enabled = true;
                }
            }
        }

        private void conRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to remove?", "XInject", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (IconObject io in lvIcons.SelectedObjects)
                {
                    lvIcons.RemoveObject(io);
                }

                if (lvIcons.Items.Count == 0)
                {
                    lvIcons.View = View.SmallIcon;
                    btnInject.Enabled = false;
                }
                else
                {
                    lvIcons.View = View.Details;
                    if (txtAssemblyPath.Text == "")
                        btnInject.Enabled = false;
                    else
                        btnInject.Enabled = true;
                }
            }
        }

        private void conSelectAll_Click(object sender, EventArgs e)
        {
            lvIcons.SelectAll();
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => Inject());
            t.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        #region Methods

        // Method for injecting icons into a .NET assembly.
        private void Inject()
        {
            // Reset the status on our icons if we're re-injecting.
            foreach (IconObject io in lvIcons.Objects)
            {
                if (io.Status == "Injected")
                    io.Status = "Idle";
                else if (io.Status == "Warning")
                    io.Status = "Idle";
                else if (io.Status == "Error")
                    io.Status = "Idle";
                Invoke(new Action(() => lvIcons.RebuildColumns()));
            }

            // Start the injection process.
            try
            {
                // Make sure that our executable file actually exists.
                string assembly = txtAssemblyPath.Text;
                if (!File.Exists(assembly))
                {
                    throw new FileNotFoundException("The file '" + Path.GetFileName(assembly) + "' doesn't exist!");
                }

                // Create a list for our icons and then verify that they exist.
                List<string> iconFiles = new List<string>();
                foreach (IconObject io in lvIcons.Objects)
                    iconFiles.Add(io.Path);
                VerifyIconFiles(iconFiles);


                // Allow re-signing of assembly using RSA.
                string strongNameKeyFile = txtCertificatePath.Text;
                if (chkResign.Checked)
                {

                    //Verify that the assembly is signed to begin with. We don't support signing unsigned assemblies,
                    //only re-signing them.
                    if (strongNameKeyFile != null)
                    {
                        using (var stream = new FileStream(assembly, FileMode.Open, FileAccess.Read))
                        {
                            var signature = new StrongName().StrongHash(stream, StrongName.StrongNameOptions.Signature);
                            if (signature.SignaturePosition == 0 && signature.SignatureLength == 0)
                            {
                                throw new ArgumentException("Assembly is not signed. XInject can only re-sign assemblies.");
                            }
                        }
                    }
                }

                // Try and insert the icons into our assembly.
                ushort iconMaxId = GetMaxIconId(assembly);
                int groupIconIdCounter = StartID;
                int errorCount = 0;
                foreach (string icoFile in iconFiles)
                {
                    try
                    {
                        groupIconIdCounter++;
                        IconDirectoryResource newIcon = new IconDirectoryResource(new IconFile(icoFile));
                        newIcon.Name.Id = new IntPtr(groupIconIdCounter);
                        foreach (var icon in newIcon.Icons)
                        {
                            icon.Id = ++iconMaxId;
                        }
                        newIcon.SaveTo(assembly);
                        foreach (IconObject io in lvIcons.Objects)
                        {
                            if (io.Path == icoFile)
                            {
                                io.Status = "Injected";
                                break;
                            }
                        }
                        Invoke(new Action(() => lvIcons.RebuildColumns()));
                    }
                    catch
                    {
                        foreach (IconObject io in lvIcons.Objects)
                        {
                            if (io.Path == icoFile)
                            {
                                io.Status = "Error";
                                errorCount++;
                                break;
                            }
                        }
                        Invoke(new Action(() => lvIcons.RebuildColumns()));
                    }
                }

                // Re-sign our assembly file.
                if (chkResign.Checked)
                {
                    if (strongNameKeyFile != null)
                        ResignAssembly(assembly, strongNameKeyFile);
                }

                // Cleanup any temp files that may be lying around.
                foreach (string file in Directory.EnumerateFiles(assembly.Replace(Path.GetFileName(assembly), ""), "*.*", SearchOption.TopDirectoryOnly))
                {
                    if (Path.GetExtension(file) == ".tmp")
                    {
                        File.Delete(file);
                    }
                }

                // Let the user know we're done inserting our icons.
                if (errorCount == 0)
                    MessageBox.Show("XInject has successfully injected the choosen icons!", "XInject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("XInject has finished working but some icons could not be injected!", "XInject", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "XInject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Re-signs the assembly with a strong key after the icons have been injected.
        /// Throws an error if the assembly wasn't signed before, we don't handle signing
        /// for the first time, only re-signing.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="strongNameKey"></param>
        private static void ResignAssembly(string assembly, string strongNameKey)
        {
            new StrongName(File.ReadAllBytes(strongNameKey)).Sign(assembly);
        }

        /// <summary>
        /// Get the max icon id currently in the assembly so we don't overwrite
        /// the existing icons with our new icons
        /// </summary>
        private static ushort GetMaxIconId(string assembly)
        {
            using (var info = new ResourceInfo())
            {
                info.Load(assembly);

                ResourceId groupIconId = new ResourceId(Kernel32.ResourceTypes.RT_GROUP_ICON);
                if (info.Resources.ContainsKey(groupIconId))
                {
                    return info.Resources[groupIconId].OfType<IconDirectoryResource>().Max(idr => idr.Icons.Max(icon => icon.Id));
                }
            }
            return 0;
        }

        private static void VerifyIconFiles(List<string> iconFiles)
        {
            foreach (string icoFile in iconFiles)
            {
                if (!File.Exists(icoFile))
                {
                    throw new FileNotFoundException("The file '" + icoFile + "' doesn't exist!");
                }
                else if (!icoFile.ToLower().EndsWith(".ico"))
                {
                    throw new ArgumentException("The file '" + icoFile + "' is not an icon file!");
                }
            }
        }

        // Sorting method to organize our file sizes.
        private void CustomSorter(OLVColumn column, SortOrder order)
        {
            if (column == colSize)
            {
                lvIcons.ListViewItemSorter = new FileSizeComparer(colLength, order);
            }
            else
            {
                lvIcons.ListViewItemSorter = new ColumnComparer(column, order);
            }
        }

        #endregion
    }

    #region Comparers

    public class FileSizeComparer : IComparer, IComparer<OLVListItem>
    {
        OLVColumn column;
        SortOrder sortOrder;
        public FileSizeComparer(OLVColumn col, SortOrder order)
        {
            column = col;
            sortOrder = order;
        }

        public int Compare(object x, object y)
        {
            return Compare((OLVListItem)x, (OLVListItem)y);
        }

        public int Compare(OLVListItem x, OLVListItem y)
        {
            if (sortOrder == SortOrder.None)
                return 0;

            int result = 0;
            object x1 = column.GetValue(x.RowObject);
            object y1 = column.GetValue(y.RowObject);

            // Handle nulls. Null values come last
            bool xIsNull = (x1 == null || x1 == System.DBNull.Value);
            bool yIsNull = (y1 == null || y1 == System.DBNull.Value);

            if (xIsNull || yIsNull)
            {
                if (xIsNull && yIsNull)
                    result = 0;
                else
                    result = (xIsNull ? -1 : 1);
            }
            else
            {
                result = CompareValues(x1, y1);
            }

            if (sortOrder == SortOrder.Descending)
                result = 0 - result;

            return result;
        }

        public int CompareValues(object x, object y)
        {
            string x1 = x as string;
            string y1 = y as string;
            int x2 = 0;
            int y2 = 0;
            int.TryParse(x1, out x2);
            int.TryParse(y1, out y2);
            if (x2 > y2)
                return 1;
            if (x2 < y2)
                return -1;
            else
                return 0;
        }
    }

    #endregion
    #region Formatters

    public static class StringExtensions
    {
        public static string ReverseString(this string input)
        {
            char[] myArray = input.ToCharArray();
            Array.Reverse(myArray);

            string output = string.Empty;

            foreach (char character in myArray)
            {
                output += character;
            }

            return output;
        }

        public static string ToFileSize(this long l)
        {
            return String.Format(new FileSizeFormatProvider(), "{0:fs}", l);
        }
    }

    public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        private const string fileSizeFormat = "fs";
        private const Decimal OneKiloByte = 1024M;
        private const Decimal OneMegaByte = OneKiloByte * 1024M;
        private const Decimal OneGigaByte = OneMegaByte * 1024M;
        private const Decimal OneTeraByte = OneGigaByte * 1024M;
        private const Decimal OnePetaByte = OneTeraByte * 1024M;

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null || !format.StartsWith(fileSizeFormat))
            {
                return defaultFormat(format, arg, formatProvider);
            }

            if (arg is string)
            {
                return defaultFormat(format, arg, formatProvider);
            }

            Decimal size;

            try
            {
                size = Convert.ToDecimal(arg);
            }
            catch (InvalidCastException)
            {
                return defaultFormat(format, arg, formatProvider);
            }

            string suffix;
            if (size > OnePetaByte)
            {
                size /= OnePetaByte;
                suffix = " PB";
            }
            else if (size > OneTeraByte)
            {
                size /= OneTeraByte;
                suffix = " TB";
            }
            else if (size > OneGigaByte)
            {
                size /= OneGigaByte;
                suffix = " GB";
            }
            else if (size > OneMegaByte)
            {
                size /= OneMegaByte;
                suffix = " MB";
            }
            else if (size > OneKiloByte)
            {
                size /= OneKiloByte;
                suffix = " KB";
            }
            else
            {
                suffix = " B";
            }

            string precision = format.Substring(2);
            if (String.IsNullOrEmpty(precision)) precision = "2";
            return String.Format("{0:N" + precision + "}{1}", size, suffix);

        }

        private static string defaultFormat(string format, object arg, IFormatProvider formatProvider)
        {
            IFormattable formattableArg = arg as IFormattable;
            if (formattableArg != null)
            {
                return formattableArg.ToString(format, formatProvider);
            }
            return arg.ToString();
        }

    }

    #endregion
}
