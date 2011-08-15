using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;

namespace ShakenSW.HelpBrowser
{
    /// <summary>
    /// A window that lets the user browse an online help file, using an offline file as backup if internet access is unavailable.
    /// </summary>
    /// <remarks>Must be run from a STA thread.</remarks>
    public partial class HelpBrowser : Form
    {
        /// <summary>
        /// The URI to display if internet access is available
        /// </summary>
        public Uri OnlineUri { get; set; }
        /// <summary>
        /// The URI to display if internet access is unavailable
        /// </summary>
        public Uri OfflineUri { get; set; }

        /// <summary>
        /// Initializes a new <see cref="HelpBrowser"/> with the specified URIs
        /// </summary>
        /// <param name="onlineUri">The URI to display if internet access is available</param>
        /// <param name="offlineUri">The URI to display if internet access is unavailable</param>
        public HelpBrowser(Uri onlineUri, Uri offlineUri)
        {
            OnlineUri = onlineUri;
            OfflineUri = offlineUri;

            // Insert menu items to allow user to force online/offline
            IntPtr menuHandle = GetSystemMenu(this.Handle, false);
            InsertMenu(menuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty);
            InsertMenu(menuHandle, 6, MF_BYPOSITION, MENU_ONLINE, "Use Online Help");
            InsertMenu(menuHandle, 7, MF_BYPOSITION, MENU_OFFLINE, "Use Offline Help");

            InitializeComponent();

            uxWebBrowser.Url = OnlineAvailable(OnlineUri)
                                ? OnlineUri
                                : OfflineUri;
        }

        /// <summary>
        /// Initializes a new <see cref="HelpBrowser"/> with the specified URIs
        /// </summary>
        /// <param name="onlineUri">The URI to display if internet access is available</param>
        /// <param name="offlineUri">The URI to display if internet access is unavailable</param>
        public HelpBrowser(string onlineUri, string offlineUri)
            :this(new Uri(onlineUri), new Uri(offlineUri))
        {
        }

        void uxWebBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Text = uxWebBrowser.DocumentTitle;
        }

        /// <summary>
        /// Returns whether or not the URI is available &amp; returns 200 OK.
        /// </summary>
        /// <param name="uri">The URI to test</param>
        /// <returns><c>true</c> if the URI is available &amp; returns 200 OK; otherwise, <c>false</c></returns>
        private bool OnlineAvailable(Uri uri)
        {
            try
            {
                return ((HttpWebResponse)WebRequest.Create(uri).GetResponse()).StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        // Imports
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem,
                                              string lpNewItem);

        // Commands
        private const Int32 WM_SYSCOMMAND = 0x112;
        private const Int32 MF_SEPARATOR = 0x800;
        private const Int32 MF_BYPOSITION = 0x400;

        // Menu Items
        private const Int32 MENU_ONLINE = 1000;
        private const Int32 MENU_OFFLINE = 1001;

        /// <summary>
        /// Handles window messages 
        /// (here, handles clicks on the menu items)
        /// </summary>
        /// <param name="msg">The message to handle</param>
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND)
            {
                switch (msg.WParam.ToInt32())
                {
                    case MENU_ONLINE:
                        uxWebBrowser.Url = OnlineUri;
                        return;
                    case MENU_OFFLINE:
                        uxWebBrowser.Url = OfflineUri;
                        return;
                    default:
                        break;
                }
            }
            base.WndProc(ref msg);
        }
    }
}
