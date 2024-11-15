<h1 align="center">
Helpers
</h1>
<div align="center">
Additional helpful scripts for unity, that are designed to be used in multiple projects
</div>

# Contents:
- [Audio 🔊](#audio-)
- [PoolSystem 🔄](#pool-system-)
  - [Pool ♻️](#pool-)
  - [PooledObject 📦](#pooled-object-)
  - [Factory 🏭](#factory-)
- [SaveSystem 💾](#save-system-)
- [UI 📺](#ui-)
  - [DummyImage 🖼️](#dummy-image-)
  - [InputManager 📐](#input-manager-)
  - [ButtonHelper 🆒](#button-helper-)


# Audio 🔊
For audio maangement, is used <b>FMOD</b> - sound engine that cover all needs, this is first project where I used it and now it will be a permanent component
of all my projects.
<br><img src="https://private-user-images.githubusercontent.com/39275545/386687627-1febb380-ebf3-4033-bc81-b3ef3a731d50.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzE2ODk1NDUsIm5iZiI6MTczMTY4OTI0NSwicGF0aCI6Ii8zOTI3NTU0NS8zODY2ODc2MjctMWZlYmIzODAtZWJmMy00MDMzLWJjODEtYjNlZjNhNzMxZDUwLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDExMTUlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQxMTE1VDE2NDcyNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWFiYWQwMzQ1M2E4NmVkMTRkZjE5Yzc0MWQyODY3NmNjNGM2MmY1MDMxM2M3ZjAwZTljYWQ3ZWE2MWY3YmVkYmQmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.neGeJZdYJD7kbr6gx6tT2OmX7lM-i5Iq1IwCEkPqoqE" alt="FmodEvents" width="500">

It’s great tool for memory management for audio. Instead of working with audio self, need to create events from audio clips.
These events need to be stored in banks that can be loaded and unloaded at runtime. Also, it has intuitive and powerful profiling window, personally I used
it to check the optimal amount of event instances in scene, like - shoot or hit audio.
<br><img src="https://private-user-images.githubusercontent.com/39275545/386687636-be4f81a7-27c1-440f-b347-fb7f47945fa5.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzE2ODk1NDUsIm5iZiI6MTczMTY4OTI0NSwicGF0aCI6Ii8zOTI3NTU0NS8zODY2ODc2MzYtYmU0ZjgxYTctMjdjMS00NDBmLWIzNDctZmI3ZjQ3OTQ1ZmE1LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDExMTUlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQxMTE1VDE2NDcyNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTI5YzEyM2M4ZTVjNzIyNDdiMmEzZTM2MTMyODQ4NmQxNDI3OGYzZWUzZTNiMTdhYzQ3NWViMTYzNmNhNGM1NTMmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.qocOXVS8EbVoV-p4gB8OxIdcO9uGZeQl7CDO_AB7Ad0" width="500">

For controlling volume and effect during runtime, I used VCA and Snapshots that also are extremely easy to set and change in unity. And last but not
least - Audio Optimization, all settings that can be changed in Unity (EncodingFormat, LoadingMode, SampleRate) are done in FMOD.
<br><img src="https://private-user-images.githubusercontent.com/39275545/386687629-fed1c409-621c-4cd4-85a5-ce04588027a2.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzE2ODk1NDUsIm5iZiI6MTczMTY4OTI0NSwicGF0aCI6Ii8zOTI3NTU0NS8zODY2ODc2MjktZmVkMWM0MDktNjIxYy00Y2Q0LTg1YTUtY2UwNDU4ODAyN2EyLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDExMTUlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQxMTE1VDE2NDcyNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTZjMTAxZmFiMzIzOGI0ZTA1ZjZhODk2YzZiOWE5YzcxZjZlZmI2ZmUyNGEwZDQzMTFlZGIzMzRiNzAyZDFiODImWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.Lya2mjy2_-K5n-x8v3DnQiOs9n4U6reRabfA3_1oIq8" width="250">


# <br>Pool System 🔄
For memory and cpu optimization, it’s a good practice to use pooling system instead of creating and destroy objects each time.
Unity has its own PoolSystem, but I wanted to make my own, because I have more control of it, can expand it and so on. My PoolSystem has 3
components : [Pool](#pool-), [PooledObject](#pooled-object-), [Factory](#factory-).
<br><img src="https://private-user-images.githubusercontent.com/39275545/386687614-1a4ab067-558f-48f3-b773-1306439f2dd1.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzE2ODk1NDUsIm5iZiI6MTczMTY4OTI0NSwicGF0aCI6Ii8zOTI3NTU0NS8zODY2ODc2MTQtMWE0YWIwNjctNTU4Zi00OGYzLWI3NzMtMTMwNjQzOWYyZGQxLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDExMTUlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQxMTE1VDE2NDcyNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWU4MDVjNmU2OGJlNTY2OWNiOTRmOTQ1ZjM3ZDRhYTE3NzFjMzhiYjYzMGQ4ZjVkOTc4OTdjM2JlY2I2MWFkYzcmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.niD1zxbIiUlZ5uEyp8C7Ws20RcXhpLoXUnfFlF1AexM" alt="Pool" width="370">

## Pool ♻️
Pool is just a generic pool class, used only for get and release objects, similar to unity’s one, but simplified

## Pooled Object 📦
Base class for objects that are pooled. Has the option to set some config when it is instantiated and when it gets from pool (ex: set initial speed,
set different texture each time when it gets from pool). And also has option to release itself to pool (ex: when bullet hit something)
```csharp
using System;
using UnityEngine;

namespace Helpers.PoolSystem
{
public class PooledObject : MonoBehaviour
{
    public event Action OnReleaseToPool;

    public virtual void Init(Action<PooledObject> onReleaseToPool, object config) => OnReleaseToPool += () => onReleaseToPool(this);

    public virtual void Set(object config = null) { }

    protected virtual void OnReleaseToPool_raise() => OnReleaseToPool?.Invoke();
}
}
```


## Factory 🏭
Because creation of objects using pool was similar for each pooled object (bullet, effects, enemies) I decided to use a factory pattern for it.
I have two factories that can be used in any projects <b>([FactoryGO](PoolSystem/FactoryGO.cs), [FactoryFmodEvents](PoolSystem/FactoryFmodEvents.cs))</b>. Both of them are used just to set pools and both of them
use a Builder from more friendly LINQ-style code and as a bonus it resolves some “issues” like - the need to have multiple constructors, telescoping
constructors, using optional parameters.
<br><img src="https://private-user-images.githubusercontent.com/39275545/386687621-30d25ebc-8dcd-4f93-b81a-88f1eeae7782.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzE2ODk1NDUsIm5iZiI6MTczMTY4OTI0NSwicGF0aCI6Ii8zOTI3NTU0NS8zODY2ODc2MjEtMzBkMjVlYmMtOGRjZC00ZjkzLWI4MWEtODhmMWVlYWU3NzgyLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDExMTUlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQxMTE1VDE2NDcyNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPThhMmYxMGMwZjgyODlmMDAwNDM1MDhiZTdlYTNlMGM4NjFmZTk0MjI1N2Y0MmM2OTc0NDllM2Q1OWM5MGM3NTEmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.a4I6svvu2pulwPFWAdEPqpZKKTQDYztjIJb2dqHAAB8" alt="Factory" width="800">


# <br>Save System 💾
Generic and common easy to use save system that can save or load files from device. Also it has byte encoding, it’s not necessary for this project,
BUT I WANTED IT !!!
```csharp
using System;
using Constants;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Source.Session
{
public class SaveSystem
{
    public void Save<T>(string filePath, T sessionElement)
    {
        if (Directory.Exists(ConstSession.SAVES_FOLDER_PATH) == false)
            Directory.CreateDirectory(ConstSession.SAVES_FOLDER_PATH);

        using (FileStream fs = File.Open(filePath, FileMode.Create))
        {
            BinaryWriter writer = new BinaryWriter(fs);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sessionElement));
            writer.Write(Convert.ToBase64String(plainTextBytes));
            writer.Flush();
        }
    }
    
    public T Load<T>(string filePath) where T: class
    {
        if (!Directory.Exists(ConstSession.SAVES_FOLDER_PATH) || !File.Exists(filePath)) return null;

        using (FileStream fs = File.Open(filePath, FileMode.Open))
        {
            BinaryReader reader = new BinaryReader(fs);
            byte[] encodedBytes = Convert.FromBase64String(reader.ReadString());
            var value = Encoding.UTF8.GetString(encodedBytes);
            return JsonConvert.DeserializeObject<T>(value);;
        }
    }

    public static void ResetSaves()
    {
        if (Directory.Exists(ConstSession.SAVES_FOLDER_PATH))
            Directory.Delete(ConstSession.SAVES_FOLDER_PATH, true);
    }
}
}
```


# <br>UI 📺
## Dummy Image 🖼️
just an empty image, good solution for cases when it need to get raycast but without any UI elements

## Input Manager 📐
I used it to handle UI LockInput, but instead of disabling the whole UI from EventSystem, I decided to create a Canvas on the whole screen with
DummyImage that will block input on the UI. With this implementation we still can tap on several UI elements if their sorting order is higher than on
BlockInput one.
<br>I also added solution for checking PointerOverUI, in this project I didn’t used it, but my experience told me that it must be here.

## Button Helper 🆒
Just an implementation of pointers interfaces that raise event when it’s needed.