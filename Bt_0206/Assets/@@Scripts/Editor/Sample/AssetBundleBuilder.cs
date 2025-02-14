using UnityEngine;
using System.IO;
using UnityEditor;

public class AssetBundleBuilder
{
    [MenuItem("Asset Bundle/Build")]
    public static void AssetBundleBuild()
    {
        //���� ������ ��ġ
        string directoryPath = "./AssetBundle";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        //�ش� ��ο� ���� ���鿡 ���� ���� �� ���� �÷��� �����ؼ� ���� ����
        BuildPipeline.BuildAssetBundles(directoryPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //�����Ϳ��� �����ִ� ���̾�α� (Ÿ��Ʋ, ����, Ȯ�� �޼���)
        EditorUtility.DisplayDialog("Asset Bundle Build", "Asset Bundle build completed!", "complete");
        

    }
}
