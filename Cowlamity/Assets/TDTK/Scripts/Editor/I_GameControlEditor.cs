using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;

using TDTK;

namespace TDTK {

	[CustomEditor(typeof(GameControl))]
	public class GameControlEditor : TDEditorInspector{

		private static GameControl instance;
		
		
		void Awake(){
			instance = (GameControl)target;
			LoadDB();
		}
		
		
		public override void OnInspectorGUI(){
			base.OnInspectorGUI();
			
			GUI.changed = false;
			Undo.RecordObject(instance, "GameControl");
			
			EditorGUILayout.Space();
			
			
				cont=new GUIContent("Level ID:", "Indicate what level this scene is. This is used to determined if any perk should become available");
				instance.levelID=EditorGUILayout.IntField(cont, instance.levelID, GUILayout.ExpandWidth(true));
			
			
			EditorGUILayout.Space();
			
			
				EditorGUILayout.BeginHorizontal();
				cont=new GUIContent("Player Life (capped):", "The amount of life the player has. Under certain setting player might be able to gain life, check to have the player life capped");
				instance.playerLife=EditorGUILayout.IntField(cont, instance.playerLife, GUILayout.ExpandWidth(true));
				instance.capLife=EditorGUILayout.Toggle(instance.capLife, GUILayout.MaxWidth(20));
				EditorGUILayout.EndHorizontal();
				
				if(instance.capLife){
					cont=new GUIContent("Player Life Max:", "Maximum amount of life the player can have");
					instance.playerLifeCap=EditorGUILayout.IntField(cont, instance.playerLifeCap);
				}
				
				EditorGUILayout.BeginHorizontal();
				cont=new GUIContent("Enable Life Regen:", "Check to have the player life regenerate overtime");
				instance.enableLifeGen=EditorGUILayout.Toggle(cont, instance.enableLifeGen);
				
				if(instance.enableLifeGen){
					cont=new GUIContent("  Rate:", "The rate at which the player life regenerate (per second)");
					EditorGUILayout.LabelField(cont, GUILayout.MaxWidth(45));
					instance.lifeRegenRate=EditorGUILayout.FloatField(instance.lifeRegenRate);
				}
				EditorGUILayout.EndHorizontal();
			
				
			EditorGUILayout.Space();
			
				
				cont=new GUIContent("Tower Refund Ratio:", "The ratio of the total tower value that the player will receive when they sell a tower. The value takes into account the cost to build the tower as well as the resources spent to upgrade it.");
				instance.sellTowerRefundRatio=EditorGUILayout.FloatField(cont, instance.sellTowerRefundRatio);
				
				cont=new GUIContent("ResetTargetOnEachShot:", "Check to have the turret tower's target reset the target after each shot, forcing them to acquire a new target.\nThis would be useful in some case to highlight the target priority mode use by the tower");
				instance.resetTargetAfterShoot=EditorGUILayout.Toggle(cont, instance.resetTargetAfterShoot);
				
				EditorGUILayout.Space();
				
				cont=new GUIContent("MainMenu Name:", "Scene's name of the main menu to be loaded when return to menu on UI is called");
				instance.mainMenu=EditorGUILayout.TextField(cont, instance.mainMenu);
				cont=new GUIContent("NextScene Name:", "Scene's name to be loaded when this level is completed");
				instance.nextScene=EditorGUILayout.TextField(cont, instance.nextScene);
			
			
			EditorGUILayout.Space();
			
			DefaultInspector();
			
			if(GUI.changed) EditorUtility.SetDirty(instance);
		}
	}

}