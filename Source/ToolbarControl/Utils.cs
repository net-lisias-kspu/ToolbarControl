/*
Disclaimer: this file was heavily modified by LisiasT 2019

Copyright (c) 2013-2016, Maik Schreiber
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;

using UnityEngine;


namespace ToolbarControl_NS {

	// Yes, some third-party Add'Ons are using this Interface. :)
	// I'm trying to restrict the access to keep things more-or-less under control.
	// If you are reading this, you probably found something breaking due the changes. Kick me on the Forum
	// or by a private Github message and I will help. :)
	// (but ideally we should have a generic, shareable, utility for these things)
	public static class Utils {

		public static Boolean LoadImageFromFile(out Texture2D tex, String fileNamePath)
		{
			try
			{ 
				tex = KSPe.Util.Image.Texture2D.LoadFromFile(fileNamePath);
				return true;
			}
			catch (KSPe.Util.Image.Error e)
			{
				tex = null;
				Log.Exception(e, "Could not load texture {0}", fileNamePath);
				return false;
			}
		}

		public static Texture2D GetTexture(string path, bool mipmap)
		{
			return KSPe.Util.Image.Texture2D.Get(path, mipmap);
		}

		public static bool TextureExists(string texturePath)
		{
			return KSPe.Util.Image.Texture2D.Exists(texturePath);
		}
	}
}
