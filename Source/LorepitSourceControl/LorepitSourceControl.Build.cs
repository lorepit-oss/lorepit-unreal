// Copyright Solessfir 2026. All Rights Reserved.

using UnrealBuildTool;

public class LorepitSourceControl : ModuleRules
{
	public LorepitSourceControl(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				"CoreUObject",
			}
		);

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"DesktopWidgets",
				"DeveloperSettings",
				"Engine",
				"Json",
				"MainFrame",
				"SourceControl",
				"SourceControlWindows",
				"Slate",
				"SlateCore",
				"ToolMenus",
				"UnrealEd",
			}
		);
	}
}
