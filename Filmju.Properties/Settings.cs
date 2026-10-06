using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Filmju.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default => defaultInstance;

	[DebuggerNonUserCode]
	[DefaultSettingValue("150")]
	[ApplicationScopedSetting]
	public int PicSizeItemMovieW => (int)this["PicSizeItemMovieW"];

	[DefaultSettingValue("220")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public int PicSizeItemMovieH => (int)this["PicSizeItemMovieH"];

	[ApplicationScopedSetting]
	[DefaultSettingValue("Fdkcdosd54ds12sdiicdsj74212E")]
	[DebuggerNonUserCode]
	public string FontSizeS => (string)this["FontSizeS"];

	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string user_name
	{
		get
		{
			return (string)this["user_name"];
		}
		set
		{
			this["user_name"] = value;
		}
	}
}
