using UnityEngine;
using System.IO;
using UnityEditor;

public class AssetBundleBuilder
{
    [MenuItem("Asset Bundle/Build")]
    public static void AssetBundleBuild()
    {
        //현재 번들의 위치
        string directoryPath = "./AssetBundle";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        //해당 경로에 에셋 번들에 대한 설정 및 빌드 플랫폼 설정해서 빌드 진행
        BuildPipeline.BuildAssetBundles(directoryPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //에디터에서 보여주는 다이얼로그 (타이틀, 내용, 확인 메세지)
        EditorUtility.DisplayDialog("Asset Bundle Build", "Asset Bundle build completed!", "complete");
        

    }
}
