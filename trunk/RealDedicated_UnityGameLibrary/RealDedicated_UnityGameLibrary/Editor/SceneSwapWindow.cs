using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace RealDedicated_UnityGameLibrary
{
    public class SceneSwapWindow : EditorWindow
    {
        #region Members
        private static FileInfo[] ScenesFileInfo_Master = new FileInfo[0];
        private static List<FileInfo[]> foldoutSceneGroups = new List<FileInfo[]>();
        private Vector2 scrollPos;
        private Vector2 scrollPosRecentScenes;

        private List<FileInfo> recentlyOpenedScenes = new List<FileInfo>();
        private int maxRecentOpenedSceneSize = 3;

        private string searchString = "";
        #endregion

        #region Methods
        [MenuItem("Window/SceneSwap Window")]
        static void ShowWindow()
        {
            SceneSwapWindow window = (SceneSwapWindow)EditorWindow.GetWindow(typeof(SceneSwapWindow));
        }

        private static void RefreshScenes()
        {
            ScenesFileInfo_Master = (new DirectoryInfo(Application.dataPath + "/Scenes")).GetFiles("*.unity", SearchOption.AllDirectories);
            CreateFoldoutSceneGroups();
        }

        private static void CreateFoldoutSceneGroups()
        {

        }

        void OnGUI()
        {
            GUILayout.BeginVertical();
            this.searchString = EditorGUILayout.TextField(this.searchString);
            GUILayout.Box("Recent Scenes");
            if (this.recentlyOpenedScenes.Count > 0)
                this.DisplayRecentSceneButtons();

            GUILayout.Box("All Scenes");
            this.DisplayButtons();
            GUILayout.EndVertical();
        }

        private void DisplayRecentSceneButtons()
        {
            this.scrollPosRecentScenes = EditorGUILayout.BeginScrollView(this.scrollPosRecentScenes);
            for (int i = 0; i < this.recentlyOpenedScenes.Count; i++)
            {
                if (this.recentlyOpenedScenes[i].Name.Contains(this.searchString) || this.searchString == "")
                {
                    this.DrawButton(recentlyOpenedScenes[i]);
                }
            }
            EditorGUILayout.EndScrollView();
        }

        private void DisplayButtons()
        {
            this.scrollPos = EditorGUILayout.BeginScrollView(this.scrollPos);
            for (int i = 0; i < ScenesFileInfo_Master.Length; i++)
            {
                if (ScenesFileInfo_Master[i].Name.Contains(this.searchString) || this.searchString == "")
                {
                    this.DrawButton(ScenesFileInfo_Master[i]);
                }
            }
            EditorGUILayout.EndScrollView();
        }

        private void DrawButton(FileInfo sceneInfo)
        {
            if (GUILayout.Button(sceneInfo.Name))
            {
                this.LoadSelectedScene(sceneInfo);
            }
        }

        private void LoadSelectedScene(FileInfo selectedSceneFileInfo)
        {
            EditorApplication.SaveCurrentSceneIfUserWantsTo();
            EditorApplication.OpenScene(this.GetScenePath(selectedSceneFileInfo));
            this.AddRecentScene(selectedSceneFileInfo);
        }

        private string GetScenePath(FileInfo sceneFileInfo)
        {
            string tempPath = "";
            string[] pathPieces = sceneFileInfo.FullName.Split('\\');
            bool concatinating = false;
            foreach (string pathSegment in pathPieces)
            {
                if (pathSegment.Contains("Assets"))
                    concatinating = true;

                if (concatinating && pathSegment != sceneFileInfo.Name)
                    tempPath += pathSegment + "/";
                else if (concatinating)
                    tempPath += pathSegment;
            }

            return tempPath;
        }

        #region RecentScenes
        private void AddRecentScene(FileInfo newlyOpenedScene)
        {
            if (!this.InRecentSceneList(newlyOpenedScene.Name))
            {
                if (this.recentlyOpenedScenes.Count < this.maxRecentOpenedSceneSize)
                {
                    this.recentlyOpenedScenes.Add(newlyOpenedScene);
                }
                else
                {
                    this.recentlyOpenedScenes[0] = newlyOpenedScene;
                }
            }
        }

        private bool InRecentSceneList(string sceneName)
        {
            foreach (FileInfo recentScene in this.recentlyOpenedScenes)
            {
                if (recentScene.Name == sceneName)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
        #endregion

        #region Events
        void OnProjectChange()
        {
            RefreshScenes();
        }

        void OnInspectorUpdate()
        {
            RefreshScenes();
        }
        #endregion
    }
}
