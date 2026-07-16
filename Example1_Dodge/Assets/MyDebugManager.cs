# if UNITY_EDITOR

using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

// OdinMenuEditorWindow를 상속받으면 나만의 툴 창을 만들 수 있습니다.
public class MyDebugWindow : OdinMenuEditorWindow
{
    
    [MenuItem("My Tools/실시간 디버그 창")]
    private static void OpenWindow()
    {
        GetWindow<MyDebugWindow>().Show();
    }

    public int showmeint;

    [Button]
    void Showasdasd()
    {

    }

    // 왼쪽 메뉴에 무엇을 띄워줄지 결정하는 메서드입니다.
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();            

        // 씬 내에 활성화된 오브젝트들을 실시간으로 찾아서 추가하고 싶다면 아래 방식을 씁니다.
        tree.AddObjectAtPath("현재 씬의 스포너들", FindFirstObjectByType<BulletSpawner>());
        tree.AddObjectAtPath("플레이어 컨트롤러", FindFirstObjectByType<PlayerController>());


        return tree;
    }
}

#endif