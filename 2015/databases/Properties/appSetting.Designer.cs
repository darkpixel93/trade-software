﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace application {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class appSetting : global::System.Configuration.ApplicationSettingsBase {
        
        private static appSetting defaultInstance = ((appSetting)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new appSetting())));
        
        public static appSetting Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(local);Initial Catalog=ketoan-work;Integrated Security=True")]
        public string masterDbConnectionString {
            get {
                return application.configuration.GetMasterConnectionString();
                return ((string)(this["masterDbConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(local);Initial Catalog=ketoan-work;Integrated Security=True")]
        public string applicationDbConnectionString {
            get {
                return application.configuration.GetApplicationConnectionString();
                return ((string)(this["applicationDbConnectionString"]));
            }
        }
    }
}
