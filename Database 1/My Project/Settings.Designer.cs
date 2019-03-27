namespace Database_1
{
    namespace My
    {
        [global::System.Runtime.CompilerServices.CompilerGenerated()]
        [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal sealed partial class MySettings : global::System.Configuration.ApplicationSettingsBase
        {
            private static MySettings defaultInstance = (MySettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings());

            /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            public static MySettings Default
            {
                get
                {

                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return defaultInstance;
                }
            }

            [global::System.Configuration.ApplicationScopedSetting()]
            [global::System.Diagnostics.DebuggerNonUserCode()]
            [global::System.Configuration.SpecialSetting(global::System.Configuration.SpecialSetting.ConnectionString)]
            [global::System.Configuration.DefaultSettingValue("Data Source=NJ-SALESDBDEV;Initial Catalog=PDI_SALESTRACING;Integrated Security=Tr" + "ue")]
            public string PDI_SALESTRACINGConnectionString
            {
                get
                {
                    return System.Convert.ToString(this["PDI_SALESTRACINGConnectionString"]);
                }
            }
        }
    }

    namespace My
    {
        [global::Microsoft.VisualBasic.HideModuleName()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Runtime.CompilerServices.CompilerGenerated()]
        internal static class MySettingsProperty
        {
            [global::System.ComponentModel.Design.HelpKeyword("My.Settings")]
            internal static global::Database_1.My.MySettings Settings
            {
                get
                {
                    return global::Database_1.My.MySettings.Default;
                }
            }
        }
    }
}
