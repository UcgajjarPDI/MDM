/* TODO ERROR: Skipped IfDirectiveTrivia */
using System.Web.SessionState;
using System.Configuration;
using System.Web.Caching;
using System.Collections.Specialized;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Profile;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Collections.Generic;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Text.RegularExpressions;
using System;
using System.Xml.Linq;

namespace Database_1
{
    namespace My
    {
        /// <summary>
    /// Module used to define the properties that are available in the My Namespace for Web projects.
    /// </summary>
    /// <remarks></remarks>
        [global::Microsoft.VisualBasic.HideModuleName()]
        static class MyWebExtension
        {
            private static ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Devices.ServerComputer> s_Computer = new ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Devices.ServerComputer>();
            private static ThreadSafeObjectProvider<global::Microsoft.VisualBasic.ApplicationServices.WebUser> s_User = new ThreadSafeObjectProvider<global::Microsoft.VisualBasic.ApplicationServices.WebUser>();
            private static ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Logging.AspLog> s_Log = new ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Logging.AspLog>();
            /// <summary>
        /// Returns information about the host computer.
        /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            internal static global::Microsoft.VisualBasic.Devices.ServerComputer Computer
            {
                get
                {
                    return s_Computer.GetInstance();
                }
            }
            /// <summary>
        /// Returns information for the current Web user.
        /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            internal static global::Microsoft.VisualBasic.ApplicationServices.WebUser User
            {
                get
                {
                    return s_User.GetInstance();
                }
            }
            /// <summary>
        /// Returns Request object.
        /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [global::System.ComponentModel.Design.HelpKeyword("My.Request")]
            internal static global::System.Web.HttpRequest Request
            {
                [global::System.Diagnostics.DebuggerHidden()]
                get
                {
                    global::System.Web.HttpContext CurrentContext = global::System.Web.HttpContext.Current;
                    if (CurrentContext != null)
                        return CurrentContext.Request;
                    return null;
                }
            }
            /// <summary>
        /// Returns Response object.
        /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [global::System.ComponentModel.Design.HelpKeyword("My.Response")]
            internal static global::System.Web.HttpResponse Response
            {
                [global::System.Diagnostics.DebuggerHidden()]
                get
                {
                    global::System.Web.HttpContext CurrentContext = global::System.Web.HttpContext.Current;
                    if (CurrentContext != null)
                        return CurrentContext.Response;
                    return null;
                }
            }
            /// <summary>
        /// Returns the Asp log object.
        /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            internal static global::Microsoft.VisualBasic.Logging.AspLog Log
            {
                get
                {
                    return s_Log.GetInstance();
                }
            }
        }
    }
}

/* TODO ERROR: Skipped EndIfDirectiveTrivia */

