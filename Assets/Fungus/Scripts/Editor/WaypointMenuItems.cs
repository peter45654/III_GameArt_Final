using UnityEngine;
using UnityEditor;

namespace Fungus.EditorUtils
{
    public class WaypointMenuItems
    {
        [MenuItem("Tools/Fungus/Create/Waypoint", false, 111)]
        static void CreateWaypoint()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Waypoint" );
            if (prefab == null)
            {
                return ;
            }
            GameObject go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            PrefabUtility.DisconnectPrefabInstance(go);

            Undo.RegisterCreatedObjectUndo(go, "Create Object");

            return ;

        }

    }
}

