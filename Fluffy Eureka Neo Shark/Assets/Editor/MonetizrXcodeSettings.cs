//
//  Monetizr.cs
//  Monetizr iOS integration script for Unity
//
//  Created by Ben Thornburg on 11/17/16.
//  Copyright © 2016 TheMonetizr. All rights reserved.
//

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using UnityEditor.iOS.Xcode;
using System.IO;

public class MonetizrXcodeSettings
{
	[PostProcessBuild(999)]
	public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
	{
		if (buildTarget == BuildTarget.iOS)
		{
			// Get Xcode project file
			string projectPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

			// Read project and store it to use Unity Xcode SDK
			PBXProject pbxProject = new PBXProject();
			pbxProject.ReadFromFile(projectPath);

			// Enable ObjC Modules and Exceptions to play nicely with Shopify SDK (required for Monetizr SDK)
			string target = pbxProject.TargetGuidByName("Unity-iPhone");
			pbxProject.SetBuildProperty(target, "CLANG_ENABLE_MODULES", "YES");
			pbxProject.SetBuildProperty(target, "GCC_ENABLE_OBJC_EXCEPTIONS", "YES");

			// Save changes
			pbxProject.WriteToFile(projectPath);
		}
	}
}
