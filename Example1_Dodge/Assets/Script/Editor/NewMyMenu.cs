using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using PlasticGui.WorkspaceWindow.Open;

public class NewMyMenu : OdinMenuEditorWindow
{
    [MenuItem("My Tools/새로운메뉴")]
    private static void OpenWindow()
    {
        GetWindow<NewMyMenu>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        
        tree.AddAllAssetsAtPath("스포너","Assets",typeof(BulletSpawner));
        tree.AddAllAssetsAtPath("총알","Assets",typeof(Bullet));

        return tree;
    }
    private void OnInspectorUpdate()
    {
        Repaint();
    }
}
