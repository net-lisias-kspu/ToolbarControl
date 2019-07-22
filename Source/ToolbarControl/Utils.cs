/*
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
using System.IO;

using UnityEngine;
using DDSHeaders;


namespace ToolbarControl_NS {
	internal static class Utils {

		// The following function was initially copied from @JPLRepo's AmpYear mod, which is covered by the GPL, as is this mod
		//
		// This function will attempt to load either a PNG or a JPG from the specified path.
		// It first checks to see if the actual file is there, if not, it then looks for either a PNG or a JPG
		//
		// easier to specify different cases than to change case to lower.	This will fail on MacOS and Linux
		// if a suffix has mixed case
		internal static string[] imgSuffixes = new string[] { ".png", ".jpg", ".gif", ".dds", ".PNG", ".JPG", ".GIF", ".DDS" };
		internal static Boolean LoadImageFromFile(out Texture2D tex, String fileNamePath)
		{
			tex = null;
			Boolean blnReturn = false;
			bool dds = false;
			try
			{
				string path = fileNamePath;
				if (!System.IO.File.Exists(fileNamePath))
				{
					// Look for the file with an appended suffix.
					for (int i = 0; i < imgSuffixes.Length; i++)

						if (System.IO.File.Exists(fileNamePath + imgSuffixes[i]))
						{
							path = fileNamePath + imgSuffixes[i];
							dds = imgSuffixes[i] == ".dds" || imgSuffixes[i] == ".DDS";
							break;
						}
				}

				//File Exists check
				if (System.IO.File.Exists(path))
				{
					try
					{
						if (dds)
						{
							byte[] bytes = System.IO.File.ReadAllBytes(path);

							BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
							uint num = binaryReader.ReadUInt32();

							if (num != DDSValues.uintMagic)
							{
								UnityEngine.Debug.LogError("DDS: File is not a DDS format file!");
								return false;
							}
							DDSHeader ddSHeader = new DDSHeader(binaryReader);

							TextureFormat tf = TextureFormat.Alpha8;
							if (ddSHeader.ddspf.dwFourCC == DDSValues.uintDXT1)
								tf = TextureFormat.DXT1;
							if (ddSHeader.ddspf.dwFourCC == DDSValues.uintDXT5)
								tf = TextureFormat.DXT5;
							if (tf == TextureFormat.Alpha8)
								return false;
							tex = LoadTextureDXT(bytes, tf);
						}
						else
						{
							tex = new Texture2D(16, 16, TextureFormat.ARGB32, false);
							tex.LoadImage(System.IO.File.ReadAllBytes(path));
						}
						blnReturn = true;
					}
					catch (Exception ex)
					{
						Log.Error("Failed to load the texture:" + path);
						Log.Error(ex.Message);
					}
				}
				else
				{
					Log.Error("Cannot find texture to load:" + fileNamePath);
				}
			}
			catch (Exception ex)
			{
				Log.Error("Failed to load (are you missing a file):" + fileNamePath);
				Log.Error(ex.Message);
			}

			// Preventing a memory leak
			if (!blnReturn && null != tex) UnityEngine.Object.Destroy(tex);

			return blnReturn;
		}

		public static Texture2D LoadTextureDXT(byte[] ddsBytes, TextureFormat textureFormat)
		{
			if (textureFormat != TextureFormat.DXT1 && textureFormat != TextureFormat.DXT5)
				throw new Exception("Invalid TextureFormat. Only DXT1 and DXT5 formats are supported by this method.");

			byte ddsSizeCheck = ddsBytes[4];
			if (ddsSizeCheck != 124)
				throw new Exception("Invalid DDS DXTn texture. Unable to read");  //this header byte should be 124 for DDS image files

			int height = ddsBytes[13] * 256 + ddsBytes[12];
			int width = ddsBytes[17] * 256 + ddsBytes[16];

			int DDS_HEADER_SIZE = 128;
			byte[] dxtBytes = new byte[ddsBytes.Length - DDS_HEADER_SIZE];
			Buffer.BlockCopy(ddsBytes, DDS_HEADER_SIZE, dxtBytes, 0, ddsBytes.Length - DDS_HEADER_SIZE);

			Texture2D texture = new Texture2D(width, height, textureFormat, false);
			texture.LoadRawTextureData(dxtBytes);
			texture.Apply();

			return (texture);
		}

		internal static bool TextureExists(string texturePath)
		{
			if (GameDatabase.Instance.ExistsTexture(texturePath))
				return true;
			string fileNamePath = TexPathname(texturePath);
			for (int i = 0; i < imgSuffixes.Length; ++i)
				if (System.IO.File.Exists(fileNamePath + imgSuffixes[i]))
					return true;
			return false;
		}

		internal static string TexPathname(string path)
		{
			string s =	KSPUtil.ApplicationRootPath + "GameData/" + path;
			Log.Info("TexPathname: " + s);
			return s;
		}

		internal static Texture2D GetTexture(string path, bool mipmap)
		{
			if (!Utils.TextureExists(Utils.TexPathname(path)))
				return GameDatabase.Instance.GetTexture(path, false);

			if (LoadImageFromFile(out Texture2D tex, TexPathname(path)))
				return tex;

			UnityEngine.Object.Destroy(tex);
			return null;
		}
	}
}
