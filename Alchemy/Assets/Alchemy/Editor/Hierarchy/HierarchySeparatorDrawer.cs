using UnityEditor;
using UnityEngine;
using Alchemy.Hierarchy;

#if UNITY_2022_2_OR_NEWER
using HierarchyItemId = UnityEngine.EntityId;
#else
using HierarchyItemId = System.Int32;
#endif

namespace Alchemy.Editor
{
    public sealed class HierarchySeparatorDrawer : HierarchyDrawer
    {
        static Color SeparatorColor => new(0.5f, 0.5f, 0.5f);

        public override void OnGUI(HierarchyItemId hierarchyItemId, Rect selectionRect)
        {
            var gameObject = GetGameObject(hierarchyItemId);
            if (gameObject == null) return;
            if (!gameObject.TryGetComponent<HierarchySeparator>(out _)) return;

            DrawBackground(hierarchyItemId, selectionRect);

            var lineRect = selectionRect.AddY(selectionRect.height * 0.5f).AddXMax(14f).SetHeight(1f);
            EditorGUI.DrawRect(lineRect, SeparatorColor);
        }
    }
}
