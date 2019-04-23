﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MaterialEditor
{
    //public sealed class ShowInMaterialEditorMenu : CodeGenerateSystem.ShowInMenu
    //{
    //    public ShowInMaterialEditorMenu(string showNames, string description = "")
    //        : base(showNames, description)
    //    {

    //    }
    //}

    public class Program
    {
        //public static string TechniquesFolder = "Techniques";

        // 临时材质的id
        public static Guid TemplateMaterialId = Guid.Parse("F2CAA741-533D-4D36-9649-DA4191CDBFA0");
        public static Guid TemplateTechniqueId = Guid.Parse("A0326A64-8FE4-4968-A395-A2CBA05A68BD");
        public static string TempMaterialFileName = "TempD3DShowMaterial" + CSUtility.Support.IFileConfig.MaterialExtension;
        public static string TempTechniqueFileName = "TempD3DShowTechnique" + CSUtility.Support.IFileConfig.MaterialTechniqueExtension;
        public static string LinkFileExtend = ".link";
        public static string LinkTemplateExtend = ".temp";
        //static MaterialFileInfo m_matFileInfo = new MaterialFileInfo();
        //public static MaterialFileInfo MatFileInfo
        //{
        //    get { return m_matFileInfo; }
        //}

        //public static List<String> GetMaterialTechNames(string strFullFileName)
        //{
        //    // 读取材质的Tech信息
        //    var rd = new System.IO.StreamReader(strFullFileName);
        //    string strFileHead = "";
        //    rd.ReadLine();  // 跳过"/*Material"
        //    string strTemp = rd.ReadLine();
        //    while (strTemp != "*/")
        //    {
        //        strFileHead += strTemp;
        //        strTemp = rd.ReadLine();
        //    }

        //    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        //    xmlDoc.LoadXml(strFileHead);

        //    List<String> nameList = new List<String>();
        //    foreach (System.Xml.XmlElement cNode in xmlDoc.DocumentElement.ChildNodes)
        //    {
        //        nameList.Add(cNode.GetAttribute("Name"));
        //    }

        //    return nameList;
        //}

        public static bool IsShaderKeyWorld(string str)
        {
            var lowerStr = str.ToLower();
            switch (lowerStr)
            {
                case "texture":
                case "int":
                case "float":
                case "float2":
                case "float3":
                case "float4":
                case "float3x3":
                case "float4x4":
                case "abs":
                case "acos":
                case "all":
                case "AllMemoryBarrier":
                case "AllMemoryBarrierWithGroupSync":
                case "any":
                case "asdouble":
                case "asfloat":
                case "asin":
                case "asint":
                case "asuint":
                case "atan":
                case "atan2":
                case "ceil":
                case "clamp":
                case "clip":
                case "cos":
                case "cosh":
                case "countbits":
                case "cross":
                case "D3DCOLORtoUBYTE4":
                case "ddx":
                case "ddx_coarse":
                case "ddx_fine":
                case "ddy":
                case "ddy_coarse":
                case "ddy_fine":
                case "degrees":
                case "determinant":
                case "DeviceMemoryBarrier":
                case "DeviceMemoryBarrierWithGroupSync":
                case "distance":
                case "dot":
                case "dst":
                case "EvaluateAttributeAtCentroid":
                case "EvaluateAttributeAtSample":
                case "EvaluateAttributeSnapped":
                case "exp":
                case "exp2":
                case "f16tof32":
                case "f32tof16":
                case "faceforward":
                case "firstbithigh":
                case "firstbitlow":
                case "floor":
                case "fmod":
                case "frac":
                case "frexp":
                case "fwidth":
                case "GetRenderTargetSampleCount":
                case "GetRenderTargetSamplePosition":
                case "GroupMemoryBarrier":
                case "GroupMemoryBarrierWithGroupSync":
                case "InterlockedAdd":
                case "InterlockedAnd":
                case "InterlockedCompareExchange":
                case "InterlockedCompareStore":
                case "InterlockedExchange":
                case "InterlockedMax":
                case "InterlockedMin":
                case "InterlockedOr":
                case "InterlockedXor":
                case "isfinite":
                case "isinf":
                case "isnan":
                case "ldexp":
                case "length":
                case "lerp":
                case "lit":
                case "log":
                case "log10":
                case "log2":
                case "mad":
                case "max":
                case "min":
                case "modf":
                case "mul":
                case "noise":
                case "normalize":
                case "pow":
                case "Process2DQuadTessFactorsAvg":
                case "Process2DQuadTessFactorsMax":
                case "Process2DQuadTessFactorsMin":
                case "ProcessIsolineTessFactors":
                case "ProcessQuadTessFactorsAvg":
                case "ProcessQuadTessFactorsMax":
                case "ProcessQuadTessFactorsMin":
                case "ProcessTriTessFactorsAvg":
                case "ProcessTriTessFactorsMax":
                case "ProcessTriTessFactorsMin":
                case "radians":
                case "rcp":
                case "reflect":
                case "refract":
                case "reversebits":
                case "round":
                case "rsqrt":
                case "saturate":
                case "sign":
                case "sin":
                case "sincos":
                case "sinh":
                case "smoothstep":
                case "sqrt":
                case "step":
                case "tan":
                case "tanh":
                case "tex1D":
                case "tex1Dbias":
                case "tex1Dgrad":
                case "tex1Dlod":
                case "tex1Dproj":
                case "tex2D":
                case "tex2Dbias":
                case "tex2Dgrad":
                case "tex2Dlod":
                case "tex2Dproj":
                case "tex3D":
                case "tex3Dbias":
                case "tex3Dgrad":
                case "tex3Dlod":
                case "tex3Dproj":
                case "texCUBE":
                case "texCUBEbias":
                case "texCUBEgrad":
                case "texCUBElod":
                case "texCUBEproj":
                case "transpose":
                case "trunc":
                    return true;
            }

            return false;
        }

        public static string GetValuedGUIDString(Guid guid)
        {
            string retString = guid.ToString();
            retString = retString.Replace("-", "_");

            return retString;
        }

        public static string GetInitialNewString(string strType)
        {
            string strRet = "";
            switch (strType)
            {
                case "int":
                    strRet = "0";
                    break;

                case "float":
                case "float1":
                    strRet = "0";
                    break;

                case "float2":
                    strRet = "float2(0, 0)";
                    break;

                case "float3":
                    strRet = "float3(0, 0, 0)";
                    break;

                case "float4":
                    strRet = "float4(0, 0, 0, 0)";
                    break;
            }

            return strRet;
        }

        public static Dictionary<UInt64, string> MatFileUniqueIDDic = new Dictionary<UInt64, string>();

        // 遍历目录获得所有材质的UniqueId信息
        public static void GetAllMaterialUniqueIds()
        {
            MatFileUniqueIDDic.Clear();
            GetAllMaterialUniqueIds(CSUtility.Support.IFileManager.Instance.Root + CSUtility.Support.IFileConfig.DefaultResourceDirectory);
        }
        private static void GetAllMaterialUniqueIds(string folder)
        {
            foreach (var file in System.IO.Directory.EnumerateFiles(folder))
            {
                try
                {
                    if (("." + CSUtility.Support.IFileManager.Instance.GetFileExtension(file)) == CSUtility.Support.IFileConfig.MaterialExtension)
                    {
                        MaterialFileInfo info = new MaterialFileInfo();
                        info.LoadMaterialFile(file);

                        var relFile = CSUtility.Support.IFileManager.Instance._GetRelativePathFromAbsPath(file, CSUtility.Support.IFileManager.Instance.Root + CSUtility.Support.IFileConfig.DefaultResourceDirectory);
                        var uniqueId = CCore.Material.Material.AssignUniqueIDWithString(relFile + info.ExtendString);
                        MatFileUniqueIDDic[uniqueId] = relFile;
                    }
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }

            foreach (var dir in System.IO.Directory.EnumerateDirectories(folder))
            {
                GetAllMaterialUniqueIds(dir);
            }
        }

        public static string GetNoRepeatUniqueIdExtString(string fileName, string extStr)
        {
            var uniqueId = CCore.Material.Material.AssignUniqueIDWithString(fileName + extStr);
            string tempFile;
            if (MatFileUniqueIDDic.TryGetValue(uniqueId, out tempFile))
            {
                if (tempFile != fileName)
                {
                    extStr = Guid.NewGuid().ToString();
                    GetNoRepeatUniqueIdExtString(fileName, extStr);
                }
                else
                    return extStr;
            }

            return extStr;
        }

        public static void SaveMaterial(MaterialEditor.MaterialResourceInfo resInfo)
        {
            if (resInfo == null || resInfo.MatInfo == null)
                return;

            //if (resInfo.IsDirty)
            {
                var relativePath = CSUtility.Support.IFileManager.Instance._GetRelativePathFromAbsPath(resInfo.AbsResourceFileName, CSUtility.Support.IFileManager.Instance.Root + CSUtility.Support.IFileConfig.DefaultResourceDirectory);
                resInfo.MatInfo.SaveMaterialFile(relativePath);
                resInfo.IsDirty = false;

                var mtl = CCore.Engine.Instance.Client.Graphics.MaterialMgr.GetMaterialDefaultTechnique(resInfo.Id, true);
                CCore.Engine.Instance.Client.Graphics.MaterialMgr.RefreshEffect(mtl);

    #warning RefreshTerrainEffect
                //// 判断该材质是否在地形中使用，如果使用则更新地形材质
                //var terrainPanel = Program.GetControl(typeof(MainEditor.Panel.TerrainPanel), MainEditor.Panel.TerrainPanel.StaticKeyValue) as MainEditor.Panel.TerrainPanel;
                //if (terrainPanel != null)
                //{
                //    foreach (var vMatId in terrainPanel.MaterialIdList)
                //    {
                //        if (vMatId == SourceInfo.MatFileInfo.MaterialId)
                //        {
                //            terrainPanel.RefreshTerrainEffect(mtl);
                //            break;
                //        }
                //    }
                //}

                resInfo.ParentBrowser.ReCreateSnapshot(resInfo);
            }
        }

        public static Brush GetBrushFromValueType(string valueType, FrameworkElement element)
        {
            valueType = valueType.ToLower();
            switch(valueType)
            {
                case "int":
                    return element.TryFindResource("ValueLink_int") as Brush;
                case "float":
                case "float1":
                    return element.TryFindResource("ValueLink_float1") as Brush;
                case "float2":
                    return element.TryFindResource("ValueLink_float2") as Brush;
                case "float3":
                    return element.TryFindResource("ValueLink_float3") as Brush;
                case "float4":
                    return element.TryFindResource("ValueLink_float4") as Brush;
                case "float3x3":
                    return element.TryFindResource("ValueLink_float3X3") as Brush;
                case "float4x4":
                    return element.TryFindResource("ValueLink_float4X4") as Brush;
                case "sampler2D":
                case "texture":
                    return element.TryFindResource("TextureLink") as Brush;
                default:
                    return element.TryFindResource("ValueLink") as Brush;
            }
        }

        public static Type GetTypeFromValueType(string valueType)
        {
            valueType = valueType.ToLower();
            switch(valueType)
            {
                case "texture":
                    return null;
                case "int":
                    return typeof(System.Int32);
                case "float":
                case "float1":
                    return typeof(System.Single);
                case "float2":
                    return typeof(SlimDX.Vector2);
                case "float3":
                    return typeof(SlimDX.Vector3);
                case "float4":
                    return typeof(SlimDX.Vector4);
                case "float3x3":
                    return null;
                case "float4x4":
                    return typeof(SlimDX.Matrix);
            }

            return null;
        }

        public static string GetTypeValue(string valueType, object value)
        {
            valueType = valueType.ToLower();
            switch (valueType)
            {
                case "texture":
                    return null;
                case "int":
                    return System.Convert.ToInt32(value).ToString();
                case "float":
                case "float1":
                    return System.Convert.ToSingle(value).ToString();
                case "float2":
                    {
                        var val = (SlimDX.Vector2)value;
                        if (val == null)
                            return "";
                        return "float2(" + val.X + "," + val.Y + ")";
                    }
                case "float3":
                    {
                        var val = (SlimDX.Vector3)value;
                        if (val == null)
                            return "";
                        return "float3(" + val.X + "," + val.Y + "," + val.Z + ")";
                    }
                case "float4":
                    {
                        var val = (SlimDX.Vector4)value;
                        if (val == null)
                            return "";
                        return "float4(" + val.X + "," + val.Y + "," + val.Z + "," + val.W + ")";
                    }
                case "float3x3":
                    return "";
                case "float4x4":
                    return "";
            }

            return "";
        }

        // 判断idx位置的代码段在{与}之中是否包含测试字符串
        public static bool IsSegmentContainString(int idx, string segment, string checkString)
        {
            if (string.IsNullOrEmpty(segment))
                return false;

            if (idx >= segment.Length)
                idx = segment.Length - 1;

            var rightbIdx = segment.LastIndexOf('}', idx);
            var leftbIdx = segment.LastIndexOf('{', idx);
            if (leftbIdx < 0)
                return segment.Contains(checkString);

            if(leftbIdx > rightbIdx)
            {
                var ctIdx = segment.IndexOf(checkString, leftbIdx, idx - leftbIdx);
                if (ctIdx < 0)
                    return false;
                else
                    return true;
            }
            else
            {
                var subStr = segment.Remove(leftbIdx, idx - leftbIdx + 1);
                return IsSegmentContainString(leftbIdx - 1, subStr, checkString);
            }
        }
    }
}