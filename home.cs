using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class home : MonoBehaviour
{
    DatabaseReference childs;
    public InputField name;
    public InputField password;

 public void Save()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://graduation-project-11.firebaseio.com/");
        childs = FirebaseDatabase.DefaultInstance.RootReference;
        
        childs.Child(name.text).Child("password").SetValueAsync(password.text); 
        
        Text n = GameObject.Find("Canvas/Panel/alert").GetComponent<Text>();
        n.text="Password saved";
    }


    public void Retrieve(){
       FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://graduation-project-11.firebaseio.com/");
        childs = FirebaseDatabase.DefaultInstance.RootReference;

      FirebaseDatabase.DefaultInstance.GetReference(name.text).ValueChanged += FirebaseSaveLoadScript_ValueChanged;
  }

  private void FirebaseSaveLoadScript_ValueChanged(object sender, ValueChangedEventArgs e){
      
        
        
        Text n = GameObject.Find("Canvas/Panel/alert").GetComponent<Text>();
        n.text = e.Snapshot.Child("password").GetValue(true).ToString();

  }

  public void GotoHome()
    {SceneManager.LoadScene("home"); }


public void GotoRetrieve()
    {SceneManager.LoadScene("retrieve"); }


public void GotoSave()
    {SceneManager.LoadScene("save"); }




}
