// Copyright Solessfir 2026. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class LorepitSourceControlTests : ModuleRules
{
	public LorepitSourceControlTests(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				"LorepitSourceControl",
				"SourceControl",
			}
		);

		PrivateIncludePaths.Add(Path.Combine(ModuleDirectory, "..", "LorepitSourceControl", "Private"));
	}
}
