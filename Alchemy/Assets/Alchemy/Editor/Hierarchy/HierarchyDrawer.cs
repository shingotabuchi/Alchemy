using System;
using UnityEditor;
using UnityEngine;

#if UNITY_2022_2_OR_NEWER
using HierarchyItemId = UnityEngine.EntityId;
#else
using HierarchyItemId = System.Int32;
#endif

namespace Alchemy.Editor
{
    /// <summary>
    /// Base class for adding custom drawing processing to hierarchy items.
    /// </summary>
    public abstract class HierarchyDrawer
    {
        public abstract void OnGUI(HierarchyItemId hierarchyItemId, Rect selectionRect);

        protected static Rect GetBackgroundRect(Rect selectionRect)
        {
            return selectionRect.AddXMax(20f);
        }

        protected static GameObject GetGameObject(HierarchyItemId hierarchyItemId)
        {
            return EditorUtility.EntityIdToObject(hierarchyItemId) as GameObject;
        }

        protected static void DrawBackground(HierarchyItemId hierarchyItemId, Rect selectionRect)
        {
            var backgroundRect = GetBackgroundRect(selectionRect);

            Color backgroundColor;
            var e = Event.current;
            var isHover = backgroundRect.Contains(e.mousePosition);

            if (Selection.Contains(hierarchyItemId))
            {
                backgroundColor = EditorColors.HighlightBackground;
            }
            else if (isHover)
            {
                backgroundColor = EditorColors.HighlightBackgroundInactive;
            }
            else
            {
                backgroundColor = EditorColors.WindowBackground;
            }

            EditorGUI.DrawRect(backgroundRect, backgroundColor);
        }
    }
}
