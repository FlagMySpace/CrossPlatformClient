﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlagMySpace.Agnostic.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FlagMySpace.Agnostic.Resources.Resource", typeof(Resource).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid email address.
        /// </summary>
        internal static string EmailValidatorUtility_IsValidEmail_Invalid_email_address {
            get {
                return ResourceManager.GetString("EmailValidatorUtility_IsValidEmail_Invalid_email_address", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email must not be empty.
        /// </summary>
        internal static string EmailValidatorUtility_ValidateEmail_Email_must_not_be_empty {
            get {
                return ResourceManager.GetString("EmailValidatorUtility_ValidateEmail_Email_must_not_be_empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Timeout when trying to validate email address.
        /// </summary>
        internal static string EmailValidatorUtility_ValidateEmail_Timeout_when_trying_to_validate_email_address {
            get {
                return ResourceManager.GetString("EmailValidatorUtility_ValidateEmail_Timeout_when_trying_to_validate_email_address" +
                        "", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username must not be empty.
        /// </summary>
        internal static string MockUsernameValidatorUtility_ValidateUsername_Username_must_not_be_empty {
            get {
                return ResourceManager.GetString("MockUsernameValidatorUtility_ValidateUsername_Username_must_not_be_empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password mismatch.
        /// </summary>
        internal static string PasswordValidatorUtility_ValidatePassword_Password_mismatch {
            get {
                return ResourceManager.GetString("PasswordValidatorUtility_ValidatePassword_Password_mismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must not be empty.
        /// </summary>
        internal static string PasswordValidatorUtility_ValidatePassword_Password_must_not_be_empty {
            get {
                return ResourceManager.GetString("PasswordValidatorUtility_ValidatePassword_Password_must_not_be_empty", resourceCulture);
            }
        }
    }
}
