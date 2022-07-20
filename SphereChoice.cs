using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class SphereChoice : MonoBehaviour {

 	public List<Material> MatListList = new List<Material>();
	public GameObject MenuSphere ; 
	List<string> Options = new List<string>();
	public Dropdown MatDropdown ;
	public static Material material ;

	// Use this for initialization
	void Start () {
		
		MatDropdown.ClearOptions();		

        for (int i = 0; i < MatListList.Count; i++)
        {
            if (MatListList[i] != null)
            {
                string option = MatListList[i].name.Replace('_',' ');
                string newstring = "";

                for (int j = 0; j < option.Length; j++)
                {
                    if (char.IsUpper(option[j]))
                        newstring += " ";
                    newstring += option[j].ToString();
                }

                Options.Add(newstring);
            }
        }

        MatDropdown.AddOptions(Options);
		MatDropdown.value = 0 ;
		MatDropdown.RefreshShownValue();
	}
		
	public void SetMaterial (int materialIndex)
	{		
		material = MatListList[materialIndex];
		MenuSphere.GetComponent<Renderer>().material = material;
    }


}
